using System.Collections.Generic;
using System.Threading.Tasks;
using TabletopTelegramBot.Models;
using TabletopTelegramBot.Settings;
using Telegram.Bot;

namespace TabletopTelegramBot.Application
{
    public class Bot
    {
        private static TelegramBotClient _botClient;
        private static List<Command> _botCommandsList;

        public static IEnumerable<Command> Commands => _botCommandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (_botClient != null)
            {
                return _botClient;
            }
            
            _botCommandsList = new List<Command>();
            _botCommandsList.Add(new StartCommand());

            var settings = new BotSettings();
            _botClient = new TelegramBotClient(settings.Token);
//            var hook = string.Format(settings.Url, "api/message/update");
            await _botClient.SetWebhookAsync("");
            
            return _botClient;
        }
    }
}