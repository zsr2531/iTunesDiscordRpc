using System;

namespace iTunesDiscordRpc
{
    public readonly ref struct iTunesInfo
    {
        public static bool PullData(out iTunesInfo info)
        {
            info = default;
            string name = null, author = null, album = null;
            long trackLength = 0, playerPosition = 0;

            if (!Api.GetCurrentTrackName(ref name))
                return false;
            if (!Api.GetCurrentTrackAuthor(ref author))
                return false;
            if (!Api.GetCurrentTrackAlbum(ref album))
                return false;
            if (!Api.GetCurrentTrackLength(ref trackLength))
                return false;
            if (!Api.GetCurrentPosition(ref playerPosition))
                return false;

            var timeLeft = TimeSpan.FromSeconds(trackLength - playerPosition);
            info = new iTunesInfo(name, author, album, timeLeft);

            return true;
        }

        private iTunesInfo(string name, string author, string album, TimeSpan timeLeft)
        {
            Name = name;
            Author = author;
            Album = album;
            TimeLeft = timeLeft;
        }

        public readonly string Name, Author, Album;
        public readonly TimeSpan TimeLeft;

        public bool Equals(iTunesInfo other)
        {
            return Name == other.Name && Author == other.Author && Album == other.Album
                && TimeLeft.Subtract(other.TimeLeft).Seconds < 20;
        }
    }
}
