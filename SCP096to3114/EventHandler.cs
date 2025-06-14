namespace SCP096to3114;

using LabApi.Events.Arguments.PlayerEvents;
using PlayerRoles;

public class EventHandler
{
    internal EventHandler()
    {
        LabApi.Events.Handlers.PlayerEvents.ChangedRole += OnRoleChange;
    }

    ~EventHandler()
    {
        LabApi.Events.Handlers.PlayerEvents.ChangedRole -= OnRoleChange;
    }

    private void OnRoleChange(PlayerChangedRoleEventArgs ev)
    {
        if (ev.ChangeReason == PlayerRoles.RoleChangeReason.RoundStart && ev.Player.Role == RoleTypeId.Scp096)
        {
            ev.Player.SetRole(PlayerRoles.RoleTypeId.Scp3114, PlayerRoles.RoleChangeReason.LateJoin, PlayerRoles.RoleSpawnFlags.UseSpawnpoint);
            ev.Player.SendBroadcast($"You were changed to SCP-3114 because of active plugin: {ThisPlugin.Instance.Name}", 10);
        }
    }
}
