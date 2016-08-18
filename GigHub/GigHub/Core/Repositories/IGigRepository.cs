using GigHub.Core.Models;
using GigHub.Core.ViewModels;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface IGigRepository
    {
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        Gig GetGigWithAttendees(int gigId);
        IEnumerable<Gig> GetUsersGigs(string userId);
        Gig GetGigById(int id, string userId);
        Gig GetGigByIdWithAttendancesWithArtistAndArtistFollowers(int id);
        IEnumerable<Gig> GetUpcomingGigs();
        void AddGig(Gig gig);
        void ModifyGig(GigFormViewModel viewModel, Gig gig);
    }
}