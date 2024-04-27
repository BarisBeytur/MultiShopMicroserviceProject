﻿using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {

        private readonly string _host;
        private readonly int _port;
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public ConnectionMultiplexer Connect()
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

            return _connectionMultiplexer;
        }

        public IDatabase GetDb(int db = 1)
        {
            return _connectionMultiplexer.GetDatabase(0);
        }

    }
}
