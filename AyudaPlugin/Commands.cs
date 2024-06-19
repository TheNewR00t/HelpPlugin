using CommandSystem;
using Exiled.API.Features;
using PluginAPI.Roles;
using RemoteAdmin;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AyudaPlugin
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Commands : ICommand 
    {
        public string Command { get; } = $"{Plugin.Instance.Config.CommandName}";
        public string[] Aliases { get; } = new string[] { null };
        public string Description { get; } = "Call a staff";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            if (sender is PlayerCommandSender playerSender)
            {
                string playerName = playerSender.Nickname;


                foreach (Player pl in Player.List)
                {
                    if (pl.ReferenceHub.serverRoles.RemoteAdmin)
                        pl.ShowHint($"{player.Nickname} {Plugin.Instance.Config.helpMensaje}", Plugin.Instance.Config.SecondsOfMensaje);
                }

                ExecuteCoroutine(SendWebhookCoroutine(playerName));
                response = $"{playerName} {Plugin.Instance.Config.Staff}";
                return true;
            }

            response = "This command can only be used by a player.";
            return false;
        }

        private async Task SendWebhookCoroutine(string playerName)
        {
            await SendWebhook(playerName);
        }

        private async Task SendWebhook(string playerName)
        {
            string webhookUrl = Plugin.Instance.Config.webhook;

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent("{\"content\"\" " + $"{Plugin.Instance.Config.DiscordText1} " + playerName + $" {Plugin.Instance.Config.DiscordText2}" + "\"}", Encoding.UTF8, "application/json");
                await client.PostAsync(webhookUrl, content);
            }
        }

        private void ExecuteCoroutine(Task task)
        {
            Task.Run(async () => await task);
        }
    }
}
