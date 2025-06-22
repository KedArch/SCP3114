namespace SCP3114;

using System.Diagnostics;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Features.Console;
using LabApi.Features.Wrappers;

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
            && this.number < 100.0/7
            && ev.Player.IsSCP
            && Player.Count > 7)
        {
            this.max_scp3114 -= 1;
            ev.Player.SetRole(PlayerRoles.RoleTypeId.Scp3114, PlayerRoles.RoleChangeReason.None, PlayerRoles.RoleSpawnFlags.UseSpawnpoint);
            ev.Player.SendBroadcast($"You were changed to SCP-3114 because of active plugin: {ThisPlugin.Instance.Name}", 10);
        }
    }
}
