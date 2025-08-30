using PlayerRoles;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.Events;
using Server = Exiled.Events.Handlers.Server;

namespace SCP3114
{
    public class SCP3114 : Plugin<Config>
    {
        public override string Name => "SCP3114";
        public override string Author => "KedArch";
        public override Version Version => new(1, 0, 0);

        private EventHandler handler = null!;

        public override void OnEnabled()
        {
            handler = new EventHandler(Name);
            Server.AllPlayersSpawned += handler.OnAllPlayersSpawned;
        }

        public override void OnDisabled()
        {
            Server.AllPlayersSpawned += handler.OnAllPlayersSpawned;
            handler = null!;
        }
    }

    public class EventHandler
    {
        private string pluginName;
        private float chance;

        public EventHandler(string name)
        {
            pluginName = name;
            // 7 main SCPs
            chance = 100/7;
        }

        public void OnAllPlayersSpawned()
        {
            Random rand = new Random();
            float number = rand.Next(1, 10001)/100;
            Log.Debug($"SCP3114: {number}/{chance}");
            if (number > chance)
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

