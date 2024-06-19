using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyudaPlugin
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; } = new();
        public override string Name => "HelpPlugin";
        public override void OnEnabled()
        {
            Instance = this;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Instance = null;

            base.OnDisabled();
        }
    }
}
