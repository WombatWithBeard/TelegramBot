using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TabletopTelegramBot.Application;
using Telegram.Bot.Types;

namespace TabletopTelegramBot.Controllers
{
    [ApiController]
    [Route("api/message/update")]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public async Task<OkResult> Post([FromBody]Update update)
        {
            if (update == null) return Ok();

            var commands = Bot.Commands;
            var message = update.Message;
            var botClient = await Bot.GetBotClientAsync();

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    await command.Execute(message, botClient);
                    break;
                }
            }
            return Ok();
        }
    }
}