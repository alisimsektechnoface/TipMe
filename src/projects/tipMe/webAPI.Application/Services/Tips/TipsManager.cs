using Application.Features.SystemParameters.Constants;
using Application.Features.Tips.Commands.PaymentRequestMobile;
using Application.Features.Tips.Commands.PaymentRequestWithCard;
using Application.Features.Tips.Rules;
using Application.Services.Repositories;
using Application.Services.SystemParameters;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Tips;

public class TipsManager : ITipsService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITipRepository _tipRepository;
    private readonly ISystemParametersService _systemParametersService;
    private readonly TipBusinessRules _tipBusinessRules;

    public TipsManager(ITipRepository tipRepository, IHttpContextAccessor httpContextAccessor, ISystemParametersService systemParametersService, TipBusinessRules tipBusinessRules)
    {
        _tipRepository = tipRepository;
        _tipBusinessRules = tipBusinessRules;
        _systemParametersService = systemParametersService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Tip?> GetAsync(
        Expression<Func<Tip, bool>> predicate,
        Func<IQueryable<Tip>, IIncludableQueryable<Tip, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Tip? tip = await _tipRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return tip;
    }

    public async Task<IPaginate<Tip>?> GetListAsync(
        Expression<Func<Tip, bool>>? predicate = null,
        Func<IQueryable<Tip>, IOrderedQueryable<Tip>>? orderBy = null,
        Func<IQueryable<Tip>, IIncludableQueryable<Tip, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Tip> tipList = await _tipRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return tipList;
    }

    public async Task<Tip> AddAsync(Tip tip)
    {
        Tip addedTip = await _tipRepository.AddAsync(tip);

        return addedTip;
    }

    public async Task<Tip> UpdateAsync(Tip tip)
    {
        Tip updatedTip = await _tipRepository.UpdateAsync(tip);

        return updatedTip;
    }

    public async Task<Tip> DeleteAsync(Tip tip, bool permanent = false)
    {
        Tip deletedTip = await _tipRepository.DeleteAsync(tip);

        return deletedTip;
    }

    public async Task<ThreedsInitialize> PaymentRequestWithCart3D(PaymentRequestWithCardRequest request, Invoice invoice)
    {
        string price = (request.TaxAmount + request.TipAmount).ToString().Replace(",", ".");

        CreatePaymentRequest paymentRequest = new CreatePaymentRequest();
        paymentRequest.Locale = Locale.TR.ToString();
        paymentRequest.ConversationId = invoice.Id.ToString();
        paymentRequest.Price = price;
        paymentRequest.PaidPrice = price;
        paymentRequest.Currency = Currency.TRY.ToString();
        paymentRequest.BasketId = invoice.Id.ToString();
        paymentRequest.PaymentChannel = PaymentChannel.WEB.ToString();
        paymentRequest.PaymentGroup = PaymentGroup.PRODUCT.ToString();
        paymentRequest.Installment = 1;
        paymentRequest.CallbackUrl = "http://tipmeui.nayacreative.com/callback.aspx";

        PaymentCard paymentCard = new PaymentCard();
        paymentCard.CardHolderName = request.CardHolderName;
        paymentCard.CardNumber = request.CardNumber;
        paymentCard.ExpireMonth = request.ExpireMonth;
        paymentCard.ExpireYear = request.ExpireYear;
        paymentCard.Cvc = request.Cvc;
        paymentCard.RegisterCard = 1;
        paymentRequest.PaymentCard = paymentCard;

        Buyer buyer = new Buyer();
        buyer.Id = "BY789";
        buyer.Name = "John";
        buyer.Surname = "Doe";
        buyer.GsmNumber = "+905350000000";
        buyer.Email = "email@email.com";
        buyer.IdentityNumber = "74300864791";
        buyer.LastLoginDate = "2015-10-05 12:43:35";
        buyer.RegistrationDate = "2013-04-21 15:12:09";
        buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        buyer.Ip = "85.34.78.112";
        buyer.City = "Istanbul";
        buyer.Country = "Turkey";
        buyer.ZipCode = "34732";
        paymentRequest.Buyer = buyer;

        Address billingAddress = new Address();
        billingAddress.ContactName = "Jane Doe";
        billingAddress.City = "Istanbul";
        billingAddress.Country = "Turkey";
        billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        billingAddress.ZipCode = "34742";
        paymentRequest.BillingAddress = billingAddress;

        List<BasketItem> basketItems = new List<BasketItem>();
        BasketItem firstBasketItem = new BasketItem();
        firstBasketItem.Id = "Tip";
        firstBasketItem.Name = "Tip";
        firstBasketItem.Category1 = "Tip";
        firstBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
        firstBasketItem.Price = price;
        basketItems.Add(firstBasketItem);

        paymentRequest.BasketItems = basketItems;
        var checkoutFormInitialize = ThreedsInitialize.Create(paymentRequest, await GetIyzipayOptionsAsync());

        return checkoutFormInitialize;
    }
    public async Task<Payment> PaymentRequestWithCart(PaymentRequestWithCardRequest request, Invoice invoice)
    {
        string price = (request.TaxAmount + request.TipAmount).ToString().Replace(",", ".");

        CreatePaymentRequest paymentRequest = new CreatePaymentRequest();
        paymentRequest.Locale = Locale.TR.ToString();
        paymentRequest.ConversationId = invoice.Id.ToString();
        paymentRequest.Price = price;
        paymentRequest.PaidPrice = price;
        paymentRequest.Currency = Currency.TRY.ToString();
        paymentRequest.BasketId = invoice.Id.ToString();
        paymentRequest.PaymentChannel = PaymentChannel.WEB.ToString();
        paymentRequest.PaymentGroup = PaymentGroup.PRODUCT.ToString();
        paymentRequest.Installment = 1;

        PaymentCard paymentCard = new PaymentCard();
        paymentCard.CardHolderName = request.CardHolderName;
        paymentCard.CardNumber = request.CardNumber;
        paymentCard.ExpireMonth = request.ExpireMonth;
        paymentCard.ExpireYear = request.ExpireYear;
        paymentCard.Cvc = request.Cvc;
        paymentCard.RegisterCard = 1;
        paymentRequest.PaymentCard = paymentCard;

        Buyer buyer = new Buyer();
        buyer.Id = "BY789";
        buyer.Name = "John";
        buyer.Surname = "Doe";
        buyer.GsmNumber = "+905350000000";
        buyer.Email = "email@email.com";
        buyer.IdentityNumber = "74300864791";
        buyer.LastLoginDate = "2015-10-05 12:43:35";
        buyer.RegistrationDate = "2013-04-21 15:12:09";
        buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        buyer.Ip = "85.34.78.112";
        buyer.City = "Istanbul";
        buyer.Country = "Turkey";
        buyer.ZipCode = "34732";
        paymentRequest.Buyer = buyer;

        Address billingAddress = new Address();
        billingAddress.ContactName = "Jane Doe";
        billingAddress.City = "Istanbul";
        billingAddress.Country = "Turkey";
        billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        billingAddress.ZipCode = "34742";
        paymentRequest.BillingAddress = billingAddress;

        List<BasketItem> basketItems = new List<BasketItem>();
        BasketItem firstBasketItem = new BasketItem();
        firstBasketItem.Id = "Tip";
        firstBasketItem.Name = "Tip";
        firstBasketItem.Category1 = "Tip";
        firstBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
        firstBasketItem.Price = price;
        basketItems.Add(firstBasketItem);

        paymentRequest.BasketItems = basketItems;
        var checkoutFormInitialize = Payment.Create(paymentRequest, await GetIyzipayOptionsAsync());

        return checkoutFormInitialize;
    }

    public async Task<CheckoutFormInitialize> PaymentRequest(decimal tipAmount, Invoice invoice)
    {
        string price = tipAmount.ToString().Replace(",", ".");
        //string myHostUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
        //string myHostUrl1 = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}";

        string iyzicoCallbackUrl = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_IyzicoCallbackUrl);

        CreateCheckoutFormInitializeRequest paymentRequest = new CreateCheckoutFormInitializeRequest();
        //CreatePaymentRequest paymentRequest = new CreatePaymentRequest();
        paymentRequest.Locale = Locale.TR.ToString();
        paymentRequest.ConversationId = invoice.Id.ToString();
        paymentRequest.Price = price;
        paymentRequest.PaidPrice = price;
        paymentRequest.Currency = Currency.TRY.ToString();
        paymentRequest.BasketId = invoice.Id.ToString();
        paymentRequest.PaymentGroup = PaymentGroup.PRODUCT.ToString();
        //paymentRequest.CallbackUrl = myHostUrl + "/api/Tips/PaymentResult/" + invoice.QrCode;
        paymentRequest.CallbackUrl = iyzicoCallbackUrl + "?qrCode=" + invoice.QrCode;

        Buyer buyer = new Buyer();
        buyer.Id = "BY789";
        buyer.Name = "John";
        buyer.Surname = "Doe";
        buyer.GsmNumber = "+905350000000";
        buyer.Email = "email@email.com";
        buyer.IdentityNumber = "74300864791";
        buyer.LastLoginDate = "2015-10-05 12:43:35";
        buyer.RegistrationDate = "2013-04-21 15:12:09";
        buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        buyer.Ip = "85.34.78.112";
        buyer.City = "Istanbul";
        buyer.Country = "Turkey";
        buyer.ZipCode = "34732";
        paymentRequest.Buyer = buyer;

        Address billingAddress = new Address();
        billingAddress.ContactName = "Jane Doe";
        billingAddress.City = "Istanbul";
        billingAddress.Country = "Turkey";
        billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        billingAddress.ZipCode = "34742";
        paymentRequest.BillingAddress = billingAddress;

        //Address shippingAddress = new Address();
        //shippingAddress.ContactName = "Jane Doe";
        //shippingAddress.City = "Istanbul";
        //shippingAddress.Country = "Turkey";
        //shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        //shippingAddress.ZipCode = "34742";
        //paymentRequest.ShippingAddress = shippingAddress;

        List<BasketItem> basketItems = new List<BasketItem>();
        BasketItem firstBasketItem = new BasketItem();
        firstBasketItem.Id = "Tip";
        firstBasketItem.Name = "Tip";
        firstBasketItem.Category1 = "Tip";
        firstBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
        firstBasketItem.Price = price;
        basketItems.Add(firstBasketItem);

        paymentRequest.BasketItems = basketItems;
        CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(paymentRequest, await GetIyzipayOptionsAsync());

        return checkoutFormInitialize;
    }

    public async Task<CheckoutForm> PaymentResultToken(string token)
    {
        RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest();
        request.Token = token;
        CheckoutForm checkoutForm = CheckoutForm.Retrieve(request, await GetIyzipayOptionsAsync());

        return checkoutForm;
    }

    public async Task<CheckoutForm> PaymentResultQrCode(string qrCode)
    {
        Tip? tip = await _tipRepository.GetAsync(x => x.QrCode == qrCode, enableTracking: false);
        await _tipBusinessRules.TipShouldExistWhenSelected(tip);
        RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest();
        request.Token = tip.PaymentReference;
        CheckoutForm checkoutForm = CheckoutForm.Retrieve(request, await GetIyzipayOptionsAsync());
        return checkoutForm;
    }

    private async Task<Iyzipay.Options> GetIyzipayOptionsAsync()
    {
        string iyzicoApiKey = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_IyzicoApiKey);
        string iyzicoSecretKey = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_IyzicoSecretKey);
        string iyzicoBaseUrl = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_IyzicoBaseUrl);

        Iyzipay.Options options = new Iyzipay.Options();
        options.ApiKey = iyzicoApiKey;
        options.SecretKey = iyzicoSecretKey;
        options.BaseUrl = iyzicoBaseUrl;

        return options;
    }


    #region Mobile


    public async Task<PaymentRequestMobileResponse> PaymentRequestMobile(decimal tipAmount, Invoice invoice)
    {
        PaymentRequestMobileResponse response = new PaymentRequestMobileResponse();

        string price = tipAmount.ToString().Replace(",", ".");
        string iyzicoCallbackUrl = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_IyzicoCallbackUrl);

        CreateCheckoutFormInitializeRequest paymentRequest = new CreateCheckoutFormInitializeRequest();
        paymentRequest.Locale = Locale.TR.ToString();
        paymentRequest.ConversationId = invoice.Id.ToString();
        paymentRequest.Price = price;
        paymentRequest.PaidPrice = price;
        paymentRequest.Currency = Currency.TRY.ToString();
        paymentRequest.BasketId = invoice.Id.ToString();
        paymentRequest.PaymentGroup = PaymentGroup.PRODUCT.ToString();
        paymentRequest.PaymentSource = "MOBILE_SDK";
        paymentRequest.CallbackUrl = iyzicoCallbackUrl + "?qrCode=" + invoice.QrCode;

        Buyer buyer = new Buyer();
        buyer.Id = "BY789";
        buyer.Name = "John";
        buyer.Surname = "Doe";
        buyer.GsmNumber = "+905350000000";
        buyer.Email = "email@email.com";
        buyer.IdentityNumber = "74300864791";
        buyer.LastLoginDate = "2015-10-05 12:43:35";
        buyer.RegistrationDate = "2013-04-21 15:12:09";
        buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        buyer.Ip = "85.34.78.112";
        buyer.City = "Istanbul";
        buyer.Country = "Turkey";
        buyer.ZipCode = "34732";
        paymentRequest.Buyer = buyer;

        Address billingAddress = new Address();
        billingAddress.ContactName = "Jane Doe";
        billingAddress.City = "Istanbul";
        billingAddress.Country = "Turkey";
        billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        billingAddress.ZipCode = "34742";
        paymentRequest.BillingAddress = billingAddress;

        List<BasketItem> basketItems = new List<BasketItem>();
        BasketItem firstBasketItem = new BasketItem();
        firstBasketItem.Id = "Tip";
        firstBasketItem.Name = "Tip";
        firstBasketItem.Category1 = "Tip";
        firstBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
        firstBasketItem.Price = price;
        basketItems.Add(firstBasketItem);

        paymentRequest.BasketItems = basketItems;

        response.PaymentBody = paymentRequest;
        response.Options = await GetIyzipayOptionsMobile();
        return response;
    }
    public async Task<bool> SavePaymentTokenMobile(string qrCode, string token)
    {
        Tip? tip = await _tipRepository.GetAsync(x => x.QrCode == qrCode, enableTracking: false);
        tip.PaymentReference = token;
        await _tipRepository.UpdateAsync(tip);

        return true;
    }
    private async Task<PaymentRequestMobileOptions> GetIyzipayOptionsMobile()
    {
        string iyzicoApiKey = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_IyzicoApiKey);
        string iyzicoSecretKey = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_IyzicoSecretKey);
        string iyzicoBaseUrl = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_IyzicoBaseUrl);
        string iyzicoBaseUrlMobile = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_IyzicoBaseUrlMobile);
        string iyzicoThirdPartyClientId = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_IyzicoThirdPartyClientId);
        string iyzicoThirdPartyClientSecret = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_IyzicoThirdPartyClientSecret);
        string iyzicoSdkType = await _systemParametersService.GetValueByKey(SystemParametersConstants.str_IyzicoSdkType);

        PaymentRequestMobileOptions options = new PaymentRequestMobileOptions();

        options.ApiKey = iyzicoApiKey;
        options.SecretKey = iyzicoSecretKey;
        options.BaseUrl = iyzicoBaseUrl;
        options.BaseUrlMobile = iyzicoBaseUrlMobile;
        options.ThirdPartyClientId = iyzicoThirdPartyClientId;
        options.ThirdPartyClientSecret = iyzicoThirdPartyClientSecret;
        options.SdkType = iyzicoSdkType;

        return options;
    }
    #endregion
}
