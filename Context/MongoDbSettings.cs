namespace ECommerceApi.Context
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ProductsCollection { get; set; }
        public string CategoriesCollection { get; set; }
        public string CartItemsCollection { get; set; }
        public string OrdersCollection { get; set; }
        public string UsersCollection { get; set; }
    }
}
