using System.Linq;
using System.Management;

namespace CSharpACLib.Hardware
{
    class TowerWmiInfo
    {
        private readonly ManagementScope _scope;
        public TowerWmiInfo(string towerAddress)
        {
            _scope = new ManagementScope($"\\\\{towerAddress}\\root\\CIMV2", null);
            _scope.Connect();
        }

        public TowerWmiInfo()
        {
            _scope = new ManagementScope("\\\\.\\root\\CIMV2", null);
            _scope.Connect();
        }

        public string GetPcUuid()
        {
            var query = new ObjectQuery {QueryString = "SELECT UUID FROM Win32_ComputerSystemProduct" };
            var searcher = new ManagementObjectSearcher(_scope, query) {Query = query};
            var queryCollection = from ManagementObject x in searcher.Get() select x;
            return (string)queryCollection.FirstOrDefault()?["UUID"];
        }

        public Baseboard GetBaseboard()
        {
            var query = new ObjectQuery { QueryString = "SELECT Manufacturer,Product,SerialNumber FROM Win32_BaseBoard" };
            var searcher = new ManagementObjectSearcher(_scope, query) { Query = query };
            var queryCollection = from ManagementObject x in searcher.Get() select x;
            var obj = queryCollection.FirstOrDefault();
            var baseboard = new Baseboard
            {
                Manufacturer = obj?["Manufacturer"].ToString(),
                Product = obj?["Product"].ToString(),
                SerialNumber = obj?["SerialNumber"].ToString()
            };
            return baseboard;
        }

        public SystemEnclosure GetSystemEnclosure()
        {
            var query = new ObjectQuery { QueryString = "SELECT Manufacturer,SerialNumber FROM Win32_SystemEnclosure" };
            var searcher = new ManagementObjectSearcher(_scope, query) { Query = query };
            var queryCollection = from ManagementObject x in searcher.Get() select x;
            var obj = queryCollection.FirstOrDefault();
            var systemEnclosure = new SystemEnclosure
            {
                Manufacturer = obj?["Manufacturer"].ToString(),
                SerialNumber = obj?["SerialNumber"].ToString()
            };
            return systemEnclosure;
        }
    }
}
