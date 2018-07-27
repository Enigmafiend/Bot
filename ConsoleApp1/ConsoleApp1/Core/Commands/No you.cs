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
    public class Animu3 : ModuleBase<SocketCommandContext>
    {
        [Command("n"), Alias("no you"), Summary("anime")]
        public async Task Summon([Remainder]string Input = "None")


        {
            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithAuthor("Tasukete!", Context.User.GetAvatarUrl());
            Embed.WithColor(40, 200, 150);
            Embed.WithDescription("***No you!***");
            Embed.WithImageUrl("https://img-comment-fun.9cache.com/media/aoOge00/a0NnaLz2_700wa_0.gif");

            await Context.Channel.SendMessageAsync("", false, Embed.Build());
        }




    }
}
