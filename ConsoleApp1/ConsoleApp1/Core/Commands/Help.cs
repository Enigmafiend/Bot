using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Balesk_Bot.Core.Commands
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("Help"), Alias("help", "Tasukete"), Summary("online check command")]
        public async Task help()
        {
            //Add more command sytax as program grows
            await Context.Channel.SendMessageAsync("```Use b!summon for Online Check and credits \n" +
                ("Use b!c to display a creature's information \n" +
                "Use b!s to display a spell's information \n" +
                "b!tasukete and b!hate for speacial weeb stuf.```"));
        }
    }
}
