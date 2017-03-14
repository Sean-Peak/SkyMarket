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
        DiscordClient discord;
        public MyBot()
        {
            

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

            commands.CreateCommand("test")
                .Do(async (e) =>
                 {
                     await e.Channel.SendMessage("worked");
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
