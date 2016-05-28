namespace CSharpACLib.Hardware
{
    class Tower
    {
        private readonly TowerWmiInfo _towerInfo;
        private readonly string _hashSalt;
        public Tower(string hashSalt)
        {
            _towerInfo = new TowerWmiInfo();
            _hashSalt = hashSalt;
        }
        private string Uuid => _towerInfo.GetPcUuid();

        private Baseboard Baseboard => _towerInfo.GetBaseboard();

        private SystemEnclosure SystemEnclosure => _towerInfo.GetSystemEnclosure();

        private string GetUniqueKey()
        {
            var baseboardHash = Baseboard.GetHash();
            var systemEnclosureHash = SystemEnclosure.GetHash();
            var uuidHash = Util.Sha256(Uuid);
            return Util.Sha256($"{baseboardHash}:{systemEnclosureHash}:{uuidHash}:{_hashSalt}");
        }

        public string Name => System.Environment.MachineName;
        public string UniqueKey => GetUniqueKey();
    }
}
