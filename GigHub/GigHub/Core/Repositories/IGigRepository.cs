using System.Collections.Generic;
using GigHub.Core.Models;
using GigHub.Core.ViewModels;

namespace GigHub.Core.Repositories
{
    public interface IGigRepository
    {
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        Gig GetGigWithAttendees(int gigId);
        IEnumerable<Gig> GetUsersGigs(string userId);
        Gig GetGigById(int id, string userId);
        Gig GetGigByIdWithAttendancesWithArtistAndArtistFollowers(int id);
        void AddGig(Gig gig);
        void ModifyGig(GigFormViewModel viewModel, Gig gig);
    }
}