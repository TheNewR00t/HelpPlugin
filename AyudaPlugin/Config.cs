using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyudaPlugin
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("Put your discord weebhock here")]
        public string webhook { get; set; } = "https://your-weebhock";
        [Description("Message that appears to the staff when someone asks for help in scp")]
        public string helpMensaje { get; set; } = "Need help";
        [Description("Message that says a staff will be coming soon")]
        public string Staff { get; set; } = "Some staff will come to help you, wait a moment";
        [Description("User")]
        public string DiscordText1 { get; set; } = "The user";
        [Description("Message that appears to the staff when someone asks for help in discord")]
        public string DiscordText2 { get; set; } = "need help";
        [Description("")]
        public string CommandName { get; set; } = "Staff";
        public int SecondsOfMensaje { get; set; } = 6;
    }
}
