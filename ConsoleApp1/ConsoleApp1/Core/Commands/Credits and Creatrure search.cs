using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using HtmlAgilityPack;
using System.Net.Http;
using System.Xml.XPath;
using System.IO;
using System.Text.RegularExpressions;

namespace Balesk_Bot.Core.Commands
{
    public class Creature : ModuleBase<SocketCommandContext>
    {
      

     
        [Command("c"), Alias("scard"), Summary("embeds text for creature")]
        public async Task Embed([Remainder]string Input = null)

        {

             string Iurl = Input;
            Console.WriteLine(Input);
           // Input = Input.Replace(' ', '_'); //Brings input into format to be made into url
            Console.WriteLine("Making it into image url"); //Debugging stuff
            string url = (linkfinder(Input)); //Converts the input name to url
          
            ///Console.WriteLine(url);
            Iurl = (url + "?action=edit");
            EmbedBuilder Embed = new EmbedBuilder();
            using (WebClient client = new WebClient()) 

             {
                string htmlCode = client.DownloadString(Iurl);
                // Console.WriteLine(htmlCode); -> Prints the entire source code of the page(Use for debugging)
                //Below you can see me using a very unstable code to choose and pick the data i want from a page of code

                string output = Textfinder(htmlCode, "{{Cardtable ", " flavor =");


                //A very manual way of formating the text but hey it works

                String St1 = output.Replace(".jpg", "");
                String St2 = St1.Replace("|", "");
                String St3 = St2.Replace("[[", "");
                String St4 = St3.Replace("]]", "");
                String St5 = St4.Replace("{{", "");
                String St6 = St5.Replace("}}", "");
                String St7 = St6.Replace("â", "");
                string title = Input.Replace('_', ' ');
               /// Console.WriteLine("Step 1");
                String civ = Textfinder(St7, "civilization =", "type =");
                ///Console.WriteLine("Step2");
                String type = Textfinder(St7, "type =", "ocgname =");
                ///Console.WriteLine("Step3");
                String race = Textfinder(St7, "race =", "cost =");
                ///Console.WriteLine("Step4");
                string cost = Textfinder(St7, "cost =", "power =");
                string effect = Textfinder(St7, "effect =", "ocgeffect =");
                string power = Textfinder(St7, "power =", effect);
                power = power.Replace("effect =", "");
                //makes it tidy here and does some more formating
                civ = civ.Replace("civilization2 = ", "");
                civ = civ.Replace("civilization3 = ", "");
                civ = civ.Replace("civilization4 = ", "");
                civ = civ.Replace("civilization5 = ", "");
                race = race.Replace("race2 = ", "");
                race = race.Replace("race3 = ", "");
                race = race.Replace("race4 = ", "");
                race = race.Replace("race5 = ", "");
                race = race.Replace("race6 = ", "");
                race = race.Replace("race7 = ", "");
                race = race.Replace("race8 = ", "");
                race = race.Replace("race9 = ", "");
                race = race.Replace("race10 = ", "");
                //now to get the image
                
                
                    string htmlCode2 = client.DownloadString(url);

                    String St = htmlCode2;
                    int pFrom = St.IndexOf("<meta property=") + "<meta property=".Length;
                    int pTo = St.LastIndexOf("x");
                    ///Console.WriteLine("About to substract");
                    String result1 = St.Substring(pFrom, 1500);

                    String st2 = result1;
                    int pFrom2 = st2.IndexOf("og:image") + "content=".Length;
                    int pTo2 = st2.LastIndexOf("/revision");
                    ////Console.WriteLine("About to substract");
                    String result2 = st2.Substring(pFrom2, pTo2 - pFrom2);

                    String st3 = result2;
                    int pFrom3 = st3.IndexOf("https") + "https".Length;
                    int pTo3 = st3.LastIndexOf(".jpg");
                    ///Console.WriteLine("About to substract");
                   String result3 = st3.Substring(pFrom3, pTo3 - pFrom3);
                ///Console.WriteLine(result3);
        
                Embed.WithAuthor(title);
                Embed.WithColor(30, 30, 50);
                Embed.WithImageUrl("https" + result3 + ".jpg");
                Embed.AddField("Link to page is", url);
                Embed.AddField("Cost:", cost);
                Embed.AddField("Civilization:", civ);
                Embed.AddField("Race:", race);
                Embed.AddField("Type:", type);
                Embed.AddField("Effect:", $"{effect}");
                Embed.AddField("Power:", $"**{power}**");
                
                
                
                   

            }
         
            await Context.Channel.SendMessageAsync("", false, Embed.Build());
        }
        private static string linkfinder(string Input)
        {
            using (WebClient client = new WebClient())
            {
                Input = Input.Replace(' ', '+');
                string htmlCode = client.DownloadString("https://duelmasters.wikia.com/wiki/Special:Search?search=" + Input);

                String St = htmlCode;
                int pFrom = St.IndexOf("searchmatch") + "searchmatch".Length;
                int pTo = St.LastIndexOf("footer");
                Console.WriteLine("About to substract");
                String result1 = St.Substring(pFrom, 1500);

                String St3 = result1;
                int pFrom3 = St3.IndexOf("href=") + "href".Length;
                int pTo3 = St3.IndexOf("result");
                Console.WriteLine("About to substract");
                String result3 = St3.Substring(pFrom3, pTo3 - pFrom3);
                result3 = result3.Replace("class=", "");
                result3 = result3.Replace('"', ' ');
                result3 = result3.Replace(" ", "");
                result3 = result3.Replace("/Rulings", "");
                result3 = result3.Replace("/Trivia", "");
                result3 = result3.Replace("/Tips", "");
                result3 = result3.Replace("/Gallery", "");
                result3 = result3.Replace("=", "");
                return result3;
                

            }
        }


        private static string Textfinder(string St, string x, string y)
        {





            int pFrom = St.IndexOf($"{x}") + x.Length;
            int pTo = St.LastIndexOf($"{y}");
            Console.WriteLine("About to substract");
            String result1 = St.Substring(pFrom, pTo - pFrom);
            return result1;
        }

    }
}
