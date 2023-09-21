using bot_telegram.classes;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot;
using Message = Telegram.Bot.Types.Message;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        TelegramBotClient client;
        private async void Form1_Load(object sender, EventArgs e)
        {
             client = new TelegramBotClient("6679000224:AAEadbxPSpnxpZQ9sM-aoCQuG6wUo2l120M");
            await client.DeleteWebhookAsync();
            await StartReceiver();
        }
        public async Task StartReceiver()
        {
            try
            {

            var Token = new CancellationTokenSource();
            var cancToken = Token.Token;
            var ReOpt = new ReceiverOptions { AllowedUpdates = { } };
            await client.ReceiveAsync(OnMessage, ErrorMessage, ReOpt, cancToken);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task OnMessage(ITelegramBotClient client, Update update, CancellationToken canc)
        {

            try
            {

                if (update.Message is Message msg)
                {
                    if (msg.Text == "/onepiece") 
                    {

                    await client.SendTextMessageAsync(msg.Chat.Id, "Ciao qui puoi vedere tutti gli episodi di One Piece https://www.animeunity.to/anime/2998-one-piece-ita");
                    }else if(msg.Text == "/project")
                    {
                        await client.SendTextMessageAsync(msg.Chat.Id, "Questi sono i link per scricare il progetto Betacomio Frontend:https://github.com/ChristianvVett/FrontEnd, Backend:https://github.com/GabrielePagnotta/Betacomio-Project \b ricordati di installare i seguenti comandi :npm install -------  npm install ngx-bootstrap --legacy-peer-deps  -------  npm install @emailjs/browser --save --------  npm install ngx-pagination --save -------- npm install bootstrap@3.3.7ATTENZIONE: VANNO INSTALLATI NELLA DIRECTORY DEL PROGETTO");
                    }
                }
            }

            catch (Exception)
            {

                throw;
            }
        }

        public async Task ErrorMessage(ITelegramBotClient teleg, Exception e, CancellationToken cancel)
        {
            if (e is ApiRequestException e1)
            {
                await client.SendTextMessageAsync("-812711304", e.Message.ToString());
            }
        }

        public async Task SendMessage(Message msg)
        {

        }
    }
}