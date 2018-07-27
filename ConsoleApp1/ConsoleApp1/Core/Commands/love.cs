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
    public class Animu2 : ModuleBase<SocketCommandContext>
    {
        [Command("hate"), Alias("H"), Summary("anime")]
        public async Task Summon([Remainder]string Input = "None")


        {
            EmbedBuilder Embed = new EmbedBuilder();
            
            Embed.WithColor(40, 200, 150);
            Embed.WithDescription("***BA BAKA***");
            Embed.WithImageUrl("https://scontent.fisb5-1.fna.fbcdn.net/v/t1.0-9/37353528_485080761930841_8786809510527238144_n.jpg?_nc_cat=0&oh=ae8550861abe17cf329af2b0c6b9c11e&oe=5BCF0C19");
            await Context.Channel.SendMessageAsync("", false, Embed.Build());
        }




    }
}