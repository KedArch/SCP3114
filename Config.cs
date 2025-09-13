using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCP3114 {
    public class Config : IConfig
    {
        [Description("Whether or not the plugin should be enabled. Default: true")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not debug logs should be shown. Default: false")]
        public bool Debug { get; set; } = false;

        [Description("Chance for SCP-3114 to spawn at the start of the round. Default: 14.285")]
        public double Chance { get; set; } = 14.285;
    }
}
