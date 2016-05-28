using System;
using CSharpACLib.Entities;
using CSharpACLib.Hardware;

namespace CSharpACLib
{
    public class AccessControl
    {
        private readonly Api _api;
        private readonly Configuration _config;
        public AccessControl(Configuration configuration)
        {
            _api = new Api(configuration.BaseApiUrl, configuration.PublicKeyHash);
            _config = configuration;
        }

        public bool AccessAllowed()
        {
            var tower = new Tower(_config.HashSalt);
            try
            {
                var bid = _api.Check(tower.UniqueKey, _config.ProductId);
                return bid.IsActive && !bid.IsExpired;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AccessAllowed(int productId)
        {
            var tower = new Tower(_config.HashSalt);
            try
            {
                var bid = _api.Check(tower.UniqueKey, productId);
                return bid.IsActive && !bid.IsExpired;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Bid RequestAccess()
        {
            var tower = new Tower(_config.HashSalt);
            return _api.Add(tower.Name, tower.UniqueKey, _config.ProductId);
        }

        public Bid RequestAccess(int productId)
        {
            var tower = new Tower(_config.HashSalt);
            return _api.Add(tower.Name, tower.UniqueKey, productId);
        }
    }
}
