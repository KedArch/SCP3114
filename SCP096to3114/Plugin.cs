namespace SCP096to3114;

using LabApi.Loader.Features.Plugins;

public class ThisPlugin : Plugin
{
    private EventHandler? _eventHandler;

    public static ThisPlugin Instance { get; private set; } = null!;

    public override string Name => "SCP 096 to 3114";
    public override string Author => "KedArch";
    public override Version Version => new(1, 0, 0);

    public override string Description => "Change SCP 096 to 3114 on spawn";
    public override Version RequiredApiVersion => new(LabApi.Features.LabApiProperties.CompiledVersion);

        public override void Enable()
    {
        Instance = this;
        _eventHandler = new EventHandler();
    }

    public override void Disable()
    {
        _eventHandler = null;
        Instance = null!;
    }
}
