namespace SCP3114;

using LabApi.Events.Arguments.PlayerEvents;
using PlayerRoles;

public class EventHandler
{
    public Random rand;
    public int number;
    public int max_scp3114;
    internal EventHandler()
    {
        rand = new Random();
        LabApi.Events.Handlers.ServerEvents.RoundRestarted += OnRestarted;
        LabApi.Events.Handlers.PlayerEvents.ChangedRole += OnRoleChange;
        Restart();
    }

    ~EventHandler()
    {
        LabApi.Events.Handlers.ServerEvents.RoundRestarted -= OnRestarted;
        LabApi.Events.Handlers.PlayerEvents.ChangedRole -= OnRoleChange;
    }

    private void OnRestarted()
    {
        Restart();
    }
    private void Restart()
    {
        this.max_scp3114 = 1;
        this.number = rand.Next(1, 101);
    }
    private void OnRoleChange(PlayerChangedRoleEventArgs ev)
    {
        if (ev.ChangeReason == PlayerRoles.RoleChangeReason.RoundStart
            && this.max_scp3114 > 0
            && this.number > 75
            && (ev.Player.Role == RoleTypeId.Scp096
                || ev.Player.Role == RoleTypeId.Scp079))
        {
            this.max_scp3114 -= 1;
            ev.Player.SetRole(PlayerRoles.RoleTypeId.Scp3114, PlayerRoles.RoleChangeReason.LateJoin, PlayerRoles.RoleSpawnFlags.UseSpawnpoint);
            ev.Player.SendBroadcast($"You were changed to SCP-3114 because of active plugin: {ThisPlugin.Instance.Name}", 10);
        }
    }
}
