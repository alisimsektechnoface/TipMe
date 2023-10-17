using Application.Features.Invoices.Queries.GetByQrCode;
using Application.Features.Invoices.Rules;
using Application.Features.Options.Queries.GetById;
using Application.Features.Options.Queries.GetOptionsWithGroup;
using Application.Features.SystemParameters.Constants;
using Application.Services.Repositories;
using Application.Services.SystemParameters;
using AutoMapper;
using Core.Domain.Entities;
using Core.Helpers.Helpers;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq.Expressions;

namespace Application.Services.Invoices;

public class InvoicesManager : IInvoicesService
{
    private readonly IMapper _mapper;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IOptionRepository _optionRepository;
    private readonly IWebHostEnvironment _host;
    private readonly ISystemParametersService _systemParametersService;
    private readonly InvoiceBusinessRules _invoiceBusinessRules;

    public InvoicesManager(IMapper mapper, IWebHostEnvironment host, ISystemParametersService systemParametersService, IInvoiceRepository invoiceRepository, IOptionRepository optionRepository, InvoiceBusinessRules invoiceBusinessRules)
    {
        _mapper = mapper;
        _invoiceRepository = invoiceRepository;
        _optionRepository = optionRepository;
        _systemParametersService = systemParametersService;
        _invoiceBusinessRules = invoiceBusinessRules;

        _host = host;
    }

    public async Task<Invoice?> GetAsync(
        Expression<Func<Invoice, bool>> predicate,
        Func<IQueryable<Invoice>, IIncludableQueryable<Invoice, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Invoice? invoice = await _invoiceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return invoice;
    }

    public async Task<IPaginate<Invoice>?> GetListAsync(
        Expression<Func<Invoice, bool>>? predicate = null,
        Func<IQueryable<Invoice>, IOrderedQueryable<Invoice>>? orderBy = null,
        Func<IQueryable<Invoice>, IIncludableQueryable<Invoice, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Invoice> invoiceList = await _invoiceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return invoiceList;
    }

    public async Task<Invoice> AddAsync(Invoice invoice)
    {
        Invoice addedInvoice = await _invoiceRepository.AddAsync(invoice);

        return addedInvoice;
    }

    public async Task<Invoice> UpdateAsync(Invoice invoice)
    {
        Invoice updatedInvoice = await _invoiceRepository.UpdateAsync(invoice);

        return updatedInvoice;
    }

    public async Task<Invoice> DeleteAsync(Invoice invoice, bool permanent = false)
    {
        Invoice deletedInvoice = await _invoiceRepository.DeleteAsync(invoice);

        return deletedInvoice;
    }

    public async Task<GetByQrCodeResponse> GetByQrCode(string qrCode, CancellationToken cancellationToken)
    {
        Invoice? invoice = await _invoiceRepository.GetAsync(
            predicate: i => i.QrCode == qrCode && !i.IsTipped,
            include: i => i.Include(x => x.Waiter).ThenInclude(x => x.Store),
            cancellationToken: cancellationToken);

        await _invoiceBusinessRules.InvoiceShouldExistWhenSelected(invoice);

        GetByQrCodeResponse response = _mapper.Map<GetByQrCodeResponse>(invoice);

        var groupedItems = await _optionRepository.Query().GroupBy(item => item.IsHappy).ToListAsync();
        GetOptionsWithGroupResponse options = new GetOptionsWithGroupResponse();
        foreach (var group in groupedItems)
        {
            if (group.Key)
            {
                options.Happy = _mapper.Map<List<GetByIdOptionResponse>>(group.ToList());
            }
            else
            {
                options.Unhappy = _mapper.Map<List<GetByIdOptionResponse>>(group.ToList());
            }
        }
        response.Options = options;
        return response;
    }

    public async Task<string> QrCodeGenerate(string input, string fileName)
    {
        string result = string.Empty;

        using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
        {
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q))
            {
                QRCode qrCode = new QRCode(qrCodeData);
                Base64QRCode qrCode1 = new Base64QRCode(qrCodeData);

                Bitmap qrCodeImage1 = qrCode.GetGraphic(20, Color.Black, Color.White, true);
                string path = Path.Combine(_host.WebRootPath, "Resources", "QrCodes");
                qrCodeImage1.Save(filename: $@"{path}\{fileName}.png", ImageFormat.Png);
                result = $@"{path}\{fileName}.png";
            }
        }

        return result;
    }

    public Bitmap GetBitmapQrCodeGenerate(string input)
    {
        Bitmap qrCodeImage;
        using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
        {
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q))
            {
                QRCode qrCode = new QRCode(qrCodeData);
                Base64QRCode qrCodeBase64 = new Base64QRCode(qrCodeData);

                qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, true);
            }
        }
        return qrCodeImage;
    }
    public Base64QRCode GetBase64QrCodeGenerate(string input)
    {
        Base64QRCode qrCodeBase64;
        using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
        {
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q))
            {
                QRCode qrCode = new QRCode(qrCodeData);
                qrCodeBase64 = new Base64QRCode(qrCodeData);
            }
        }
        return qrCodeBase64;
    }
    public async Task<string> AdditionGenerate(string qrCode)
    {
        string filePath = string.Empty;

        Invoice? invoice = await this._invoiceRepository.GetAsync(x => x.QrCode == qrCode,
            include: i => i.Include(x => x.Tip).Include(x => x.Waiter).ThenInclude(x => x.Store));

        await _invoiceBusinessRules.InvoiceShouldExistWhenSelected(invoice);

        string invoiceTitle = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_InvoiceTitle);
        string invoiceTemplate = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_InvoiceTemplate);

        if (invoiceTemplate is not null)
        {
            var date = invoice.TipDate ?? invoice.InvoiceDate;
            string qrImg = await GetImgSrc(qrCode);
            invoiceTemplate = invoiceTemplate
                .Replace("{InvoiceTitle}", invoiceTitle)
                .Replace("{StoreName}", invoice.Waiter?.Store?.Name)
                .Replace("{TipAmount}", invoice.Currency + (invoice.Tip?.TipAmount ?? 0).ToString())
                .Replace("{TaxAmount}", invoice.Currency + (invoice.Tip?.TaxAmount ?? 0).ToString())
                .Replace("{Total}", invoice.Currency + (invoice.Tip?.TipAmount + (invoice.Tip?.TaxAmount ?? 0)).ToString())
                .Replace("{TipDate}", date.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture))
                .Replace("{QrCodeImg}", qrImg);
            ;
            var itemHtml = string.Empty;

            itemHtml += "   <tr>" +
                     "		    <td>" + "1" + "</td>" +
                     "		    <td>" + "Mercimek Çorbası" + "</td>" +
                     "		    <td>" + "₺80.00" + "</td>" +
                     "	    </tr>";

            itemHtml += "   <tr>" +
                     "		    <td>" + "3" + "</td>" +
                     "		    <td>" + "Kebap" + "</td>" +
                     "		    <td>" + "₺600.00" + "</td>" +
                     "	    </tr>";
            itemHtml += "   <tr>" +
                     "		    <td>" + "2" + "</td>" +
                     "		    <td>" + "Künefe" + "</td>" +
                     "		    <td>" + "₺180.00" + "</td>" +
                     "	    </tr>";
            itemHtml += "   <tr>" +
                     "		    <td>" + "14" + "</td>" +
                     "		    <td>" + "Çay" + "</td>" +
                     "		    <td>" + "₺140.00" + "</td>" +
                     "	    </tr>";
            itemHtml += "   <tr >" +
                     "		    <td>" + "" + "</td>" +
                     "		    <td style='text-align:right;'><b>" + "Toplam : " + "</b></td>" +
                     "		    <td><b>" + "₺1000.00" + "</b></td>" +
                     "	    </tr>";
            var html = "<table style='width:100%;margin-bottom:15px;' border='0'>" +
                    "<thead><tr>" +
                    "<th scope='col'>" + "Adet" + "</th>" +
                    "<th scope='col'>" + "Ürün" + "</th>" +
                    "<th scope='col'>" + "Fiyat" + " </th>" +
                    "</tr></thead>" +
                    "<tbody>" + itemHtml + "  </tbody>" +
                    "</table>";
            invoiceTemplate = invoiceTemplate.Replace("{Items}", html);

            filePath = Path.Combine("Resources", "Additions", qrCode + ".pdf");
            string fullPath = Path.Combine(_host.WebRootPath, filePath);

            HtmlToPdfHelper.ChromiumHtmlToPdf(fullPath, invoiceTemplate, paperFormat: ChromiumHtmlToPdfLib.Enums.PaperFormat.A5);
        }

        return filePath;
    }

    public async Task<string> GetImgSrc(string qrCode)
    {
        string imageurl = string.Empty;
        string webUrl = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_WebUrl);
        string input = webUrl + "/?qrcode=" + qrCode;
        var qr = GetBitmapQrCodeGenerate(input);

        using (var stream = new MemoryStream())
        {
            qr.Save(stream, ImageFormat.Png);
            string base64 = Convert.ToBase64String(stream.ToArray());
            imageurl = "data:image/png;base64, " + base64 + "";
        }

        return imageurl;
    }
}
