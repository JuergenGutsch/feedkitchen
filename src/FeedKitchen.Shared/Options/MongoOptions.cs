namespace FeedKitchen.Shared.Options
{
    public class MongoOptions
    {
        public string MONGO_INITDB_ROOT_USERNAME { get; set; }
        public string MONGO_INITDB_ROOT_PASSWORD { get; set; }
        public string ME_CONFIG_MONGODB_ADMINUSERNAME { get; set; }
        public string ME_CONFIG_MONGODB_ADMINPASSWORD { get; set; }
        public string MONGODB_USERNAME { get; set; }
        public string MONGODB_PASSWORD { get; set; }
        public string MONGODB_SERVER { get; set; }
        public string MONGODB_DATABASE { get; set; }
    }
}