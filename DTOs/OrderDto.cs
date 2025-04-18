namespace ECommerceApi.DTOs
{
    public class OrderDto
    {
        public string UserId { get; set; }  // JWT sonrası otomatik alınabilir
        public List<OrderItemDto> Items { get; set; }
    }
}
