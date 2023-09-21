using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Message = Telegram.Bot.Types.Message;

namespace bot_telegram.classes
{
    public class TeleBot
    {
        TelegramBotClient client = new TelegramBotClient("6679000224:AAEadbxPSpnxpZQ9sM-aoCQuG6wUo2l120M");


        public async Task StartReceiver()
        {
            var Token = new CancellationTokenSource();
            var cancToken = Token.Token;
            var ReOpt = new ReceiverOptions { AllowedUpdates = { } };
            await client.ReceiveAsync(OnMessage, ErrorMessage, ReOpt, cancToken);
        }

        public async Task OnMessage(ITelegramBotClient client, Update update, CancellationToken canc)
        {
            if (update.Message is Message msg)
            {
                await client.SendTextMessageAsync(msg.Chat.Id, "Ciao!");
            }
        }

        public async Task ErrorMessage(ITelegramBotClient teleg, Exception e, CancellationToken cancel)
        {
            if (e is ApiRequestException e1)
            {
                await client.SendTextMessageAsync("", e.Message.ToString());
            }
        }

      
    }
}