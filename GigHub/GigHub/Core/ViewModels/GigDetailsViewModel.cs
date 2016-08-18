using System;

namespace GigHub.Core.ViewModels
{
    public class GigDetailsViewModel
    {
        public bool Actions { get; set; }

        public bool IsAttending { get; set; }

        public bool IsArtistFollowed { get; set; }

        public string ArtistName { get; set; }

        public string Venue { get; set; }

        public DateTime DateTime { get; set; }


        public string GetDate()
        {
            return DateTime.ToString("dd MMM");
        }

        public string GetTime()
        {
            return DateTime.ToString("HH:mm");
        }

    }
}