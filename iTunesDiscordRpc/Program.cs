using DiscordRPC;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace iTunesDiscordRpc
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Api.Initialize())
            {
                int last = Marshal.GetLastWin32Error();
                Console.WriteLine("ERROR: " + last);
                return;
            }

            using var client = new DiscordRpcClient("784746309226594305");
            client.Initialize();

            Console.WriteLine("Ready!");
            iTunesInfo data = default;

            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(false).Key == ConsoleKey.Escape)
                    break;
                if (!iTunesInfo.PullData(out var fresh))
                    break;

                if (fresh.Equals(data))
                    continue;

                data = fresh;

                var presence = new RichPresence
                {
                    State = data.Author,
                    Details = data.Name,
                    Timestamps = Timestamps.FromTimeSpan(data.TimeLeft),
                    Assets = new Assets
                    {
                        LargeImageText = data.Album,
                        LargeImageKey = "download"
                    }
                };

                client.SetPresence(presence);

                Thread.Sleep(1000);
            }

            Api.UnInitialize();
        }
    }
}
