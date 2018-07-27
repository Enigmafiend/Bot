using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Balesk_Bot.Core.Commands
{
    public class bash : ModuleBase<SocketCommandContext>
    {
        [Command("bash"), Alias("r"), Summary("Creates invite link")]
        public async Task Bash([Remainder]string Input = "None")
        {
            if (!(Context.User.Id == 249808259760914433))
            {
                await Context.Channel.SendMessageAsync("***UwU*** You cant do that!");
                return;
            }

            else
            {
                await Context.Channel.SendMessageAsync("Shut up weeb");
                return;
            }
         


            
        }
    }
}
