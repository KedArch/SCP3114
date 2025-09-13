using PlayerRoles;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace SCP3114 {
    public class EventHandler
    {
        private string pluginName;
        private double spawnChance;

        public EventHandler(string name, double chance)
        {
            pluginName = name;
            spawnChance = chance;
        }

        public void OnAllPlayersSpawned()
        {
            Random rand = new Random();
            float number = rand.Next(1, 10001)/100;
            Log.Debug($"SCP3114: rolled {number} with threshold {spawnChance}");
            if (number > spawnChance)
            {
                return;
            }
            List<Player> scps = new List<Player>();
            foreach (Player player in Player.List)
            {
                if (player.IsScp)
                {
                    scps.Add(player);
                }
            }
            if (scps.Count > 1)
            {
                Player player = scps[rand.Next(scps.Count)];
                player.Role.Set(RoleTypeId.Scp3114, SpawnReason.RoundStart, RoleSpawnFlags.UseSpawnpoint);
                player.Broadcast(10, $"You were changed to SCP-3114 because of active plugin: {pluginName}");
            }
        }
    }
}
