using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace SkyMarket
{
    class MyBot
    {
        string games_p = null;

        DiscordClient discord;
        public MyBot()
        {
            Tuple<string, Nullable<double>>[] games =
                      { new Tuple<string, Nullable<double>>("Fallout 3:    $", 13.95),
                        new Tuple<string, Nullable<double>>("GTA V:    $", 45.95),
                        new Tuple<string, Nullable<double>>("Rocket League:    $", 19.95) };

           

        discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;

            });

            var commands = discord.GetService<CommandService>();

            commands.CreateCommand("catalogue")
                .Do(async (e) =>
                 {
                     foreach (var game in games)
                     {
                         await e.Channel.SendMessage(game.ToString().Replace("(", string.Empty).Replace(")", string.Empty).Replace(",", string.Empty) + " NZD");
                     }

                 });

            discord.ExecuteAndWait( async () => 
            {
                await discord.Connect("MjkwNzQxNTgyMDk5OTA2NTYx.C6fZFg.oBvgkSWip820E5TzLaM12jYw5sI", TokenType.Bot);
                
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
