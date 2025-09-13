using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;

namespace SCP3114
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "SCP3114";
        public override string Author => "KedArch";
        public override Version Version => new(1, 0, 0);

        private EventHandler handler = null!;

        public override void OnEnabled()
        {
            handler = new EventHandler(Name, Config.Chance);
            Server.AllPlayersSpawned += handler.OnAllPlayersSpawned;
        }

        public override void OnDisabled()
        {
            Server.AllPlayersSpawned += handler.OnAllPlayersSpawned;
            handler = null!;
        }
    }
}

