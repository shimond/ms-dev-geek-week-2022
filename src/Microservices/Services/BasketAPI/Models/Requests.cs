namespace BasketAPI.Models
{
    public record CustomerBasket(string BuyerId, List<BasketItem> Items);
    public record BasketItem(string Id, int ProductId, string ProductName, decimal UnitPrice, int Quantity, string Pictureurl);
}
