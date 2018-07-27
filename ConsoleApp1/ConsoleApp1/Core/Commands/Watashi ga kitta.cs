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
    public class Animu : ModuleBase<SocketCommandContext>
    {
        [Command("tasukete"), Alias("T"), Summary("anime")]
        public async Task Summon([Remainder]string Input = "None")
      
        {
            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithAuthor("Tasukete!", Context.User.GetAvatarUrl());
            Embed.WithColor(40, 200, 150);
            Embed.WithDescription("***Watashi ga kita!***");
            Embed.WithImageUrl("https://scontent-lht6-1.cdninstagram.com/vp/0b671a0dc900b4bf65679b6c6960b8f7/5BC9D0A9/t51.2885-15/e35/36136592_162623954604988_518047272932474880_n.jpg?efg=eyJ1cmxnZW4iOiJ1cmxnZW5fZnJvbV9pZyJ9&ig_cache_key=MTgxNTIxNjkyMDI3OTAyMDUxOA%3D%3D.2");
            await Context.Channel.SendMessageAsync("", false, Embed.Build());
        }
    }
}