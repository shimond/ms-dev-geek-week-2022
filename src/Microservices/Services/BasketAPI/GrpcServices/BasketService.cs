using BasketAPI;
using BasketAPI.Contracts;
using Grpc.Core;
using StackExchange.Redis;

namespace BasketAPI.GrpcServices;
public class BasketService : BasketAPI.Basket.BasketBase
{
    private readonly ILogger<BasketService> _logger;
    private readonly IBasketRepository _basketRepository;

    public BasketService(ILogger<BasketService> logger, IBasketRepository basketRepository)
    {
        _logger = logger;
        _basketRepository = basketRepository;
    }

    public override async Task<CustomerBasketResponse> GetBasketById(BasketRequest request, ServerCallContext context)
    {
        var result = await _basketRepository.GetBasketAsync(request.Id);
        if (result != null)
        {
            CustomerBasketResponse customerBasketResponse = Map(result);
            return customerBasketResponse;
        }
        return null;
    }

    private static CustomerBasketResponse Map( Models.CustomerBasket result)
    {
        CustomerBasketResponse customerBasketResponse = new CustomerBasketResponse() { Buyerid = result.BuyerId };
        result.Items.ForEach(x =>
        {
            customerBasketResponse.Items.Add(new BasketItemResponse()
            {
                Id = x.Id,
                Productid = x.ProductId,
                Productname = x.ProductName,
                Unitprice = (double)x.UnitPrice,
                Quantity = x.Quantity,
                Pictureurl = x.Pictureurl
            });
        });
        return customerBasketResponse;
    }

    public override async Task<CustomerBasketResponse> UpdateBasket(CustomerBasketRequest request, ServerCallContext context)
    {
        var basket = new Models.CustomerBasket(request.Buyerid, request.Items.Select(x => new Models.BasketItem(x.Id, x.Productid, x.Productname, (decimal)x.Unitprice, x.Quantity, x.Pictureurl)).ToList());
        var result = await  _basketRepository.UpdateBasketAsync(basket);
        return Map(result);
    }
}