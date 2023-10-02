using Application.Features.Tips.Rules;
using Application.Services.Repositories;
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
    private readonly TipBusinessRules _tipBusinessRules;

    public TipsManager(ITipRepository tipRepository, IHttpContextAccessor httpContextAccessor, TipBusinessRules tipBusinessRules)
    {
        _tipRepository = tipRepository;
        _tipBusinessRules = tipBusinessRules;
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

    public async Task<CheckoutFormInitialize> PaymentRequest(decimal tipAmount, string redirectUrl, Invoice invoice)
    {
        string price = tipAmount.ToString().Replace(",", ".");
        //string myHostUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
        //string myHostUrl1 = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}";


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
        paymentRequest.CallbackUrl = redirectUrl + "?qrCode=" + invoice.QrCode;

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
        CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(paymentRequest, GetIyzipayOptions());

        return checkoutFormInitialize;
    }

    public async Task<CheckoutForm> PaymentResultToken(string token)
    {
        RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest();
        request.Token = token;
        CheckoutForm checkoutForm = CheckoutForm.Retrieve(request, GetIyzipayOptions());

        return checkoutForm;
    }

    public async Task<CheckoutForm> PaymentResultQrCode(string qrCode)
    {
        Tip? tip = await _tipRepository.GetAsync(x => x.QrCode == qrCode, enableTracking: false);
        await _tipBusinessRules.TipShouldExistWhenSelected(tip);
        RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest();
        request.Token = tip.PaymentReference;
        CheckoutForm checkoutForm = CheckoutForm.Retrieve(request, GetIyzipayOptions());

        return checkoutForm;
    }

    private Iyzipay.Options GetIyzipayOptions()
    {
        Iyzipay.Options options = new Iyzipay.Options();
        options.ApiKey = "sandbox-vcSUn51fGnZHb25sb7kNsHZcPQBvSpmq";
        options.SecretKey = "sandbox-voeiJp8AQNr4cTfl2G2RRWUt5vZ8friX";
        options.BaseUrl = "https://sandbox-api.iyzipay.com";

        return options;
    }
}
