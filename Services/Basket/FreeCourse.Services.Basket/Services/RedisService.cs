﻿using System;
using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;

namespace FreeCourse.Services.Basket.Services
{
	public class RedisService
	{
        private readonly string _host;

        private readonly int _port;

        private ConnectionMultiplexer _ConnectionMultiplexer;

        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _ConnectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

        public List<RedisKey> GetKeys() => _ConnectionMultiplexer.GetServer($"{_host}:{_port}").Keys(1).ToList();

        public IDatabase GetDb(int db = 1) => _ConnectionMultiplexer.GetDatabase(db);
    }
}

