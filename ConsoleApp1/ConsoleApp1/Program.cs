using System.Reflection;
using System.Threading.Tasks;
using System;
using System.IO;
using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace Balesk_Bot
{
    class Program
    {
        private DiscordSocketClient Client;
        private CommandService Commands;


        static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Debug
            });

            Commands = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = true,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });

            Client.MessageReceived += Client_MessageReceived;
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly());

            Client.Ready += Client_Ready;
            Client.Log += Client_Log;

            String Token = "NDY4NDQxMjY2NDA2MDMxMzgw.Di5ZMQ.dH7dgBCkLslOnvHH07UxdQJcwfQ";
            //using (var Stream = new FileStream((Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).Replace(@"bin\Debug\netcoreapp2.0", @"Data\Token.txt"), FileMode.Open, FileAccess.Read))
            //using (var ReadToken = new StreamReader(Stream))
            {
                Token = "NDY4NDQxMjY2NDA2MDMxMzgw.Di5ZMQ.dH7dgBCkLslOnvHH07UxdQJcwfQ";
            }
            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();

            await Task.Delay(-1);
        }

        private async Task Client_Log(LogMessage Message)
        {
            Console.WriteLine($"{DateTime.Now} at {Message.Source}] {Message.Message}");
        }

          private async Task Client_Ready()
        {
            await Client.SetGameAsync("A Balesk Baj Ramp", "https://duelmasters.wikia.com/wiki/Balesk_Baj_Turbo", StreamType.Twitch);
        }

        private async Task Client_MessageReceived(SocketMessage MassageParam)
        {
            var Message = MassageParam as SocketUserMessage;
            var Context = new SocketCommandContext(Client, Message);

            if (Context.Message == null || Context.Message.Content == "") return;
            if (Context.User.IsBot) return;

            int ArgPos = 0;
            if (!(Message.HasStringPrefix("b!", ref ArgPos) || Message.HasMentionPrefix(Client.CurrentUser, ref ArgPos))) return;
            var Result = await Commands.ExecuteAsync(Context, ArgPos);
            if (!Result.IsSuccess)
                Console.WriteLine($"{DateTime.Now} at Commands, Something went wrong. Text {Context.Message.Content} | Error: {Result.ErrorReason}");
        }
    }
}
