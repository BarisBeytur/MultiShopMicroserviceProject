using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {

        private readonly string _host;
        private readonly int _port;

        public RedisService(IConfiguration configuration)
        {
            _host = configuration.GetSection("RedisSettings:Host").Value;
            _port = int.Parse(configuration.GetSection("RedisSettings:Port").Value);
        }

        public ConnectionMultiplexer Connect()
        {
            return ConnectionMultiplexer.Connect($"{_host}:{_port}"); ;
        }

        public IDatabase GetDb(int db = 1)
        {
            return Connect().GetDatabase(0);
        }

    }
}
