using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using Discord;
using Discord.Commands;
using System.Reflection;
using System.IO;

namespace Balesk_Bot.Core.Commands
{
    public class HelloWorld : ModuleBase<SocketCommandContext>
    {
        [Command("summon"), Alias("credits", "call"), Summary("Hello world command")]
        public async Task Summon()
        {
            await Context.Channel.SendMessageAsync("You call and I answer. Evolved onto Enigmafiend with aid from Nitrox, Inspiration from Lordicon and Motivation from my aunt");
        }

     
    }
}