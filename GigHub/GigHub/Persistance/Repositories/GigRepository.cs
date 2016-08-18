using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Core.ViewModels;

namespace GigHub.Persistance.Repositories
{
    public class GigRepository : IGigRepository
    {
        private ApplicationDbContext _context;
        public GigRepository(ApplicationDbContext _context)
        {

            this._context = _context;
        }


        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
        }

        public Gig GetGigWithAttendees(int gigId)
        {
            return _context.Gigs
                 .Include(g => g.Attendances.Select(a => a.Attendee))
                 .SingleOrDefault(g => g.Id == gigId);
        }


        public IEnumerable<Gig> GetUsersGigs(string userId)
        {
            return _context.Gigs
                .Where(g => g.ArtistId == userId &&
                            g.DateTime > DateTime.Now &&
                            !g.IsCancelled)
                .Include(g => g.Genre)
                .ToList();
        }

        public Gig GetGigById(int id, string userId)
        {
            return _context.Gigs.Single(g => g.Id == id && g.ArtistId == userId);
        }

        public Gig GetGigByIdWithAttendancesWithArtistAndArtistFollowers(int id)
        {
            return _context.Gigs
                .Include(g => g.Attendances)
                .Include(g => g.Artist)
                .Include(g => g.Artist.Followers)
                .Single(g => g.Id == id);
        }

        public void AddGig(Gig gig)
        {
            _context.Gigs.Add(gig);
        }

        public void ModifyGig(GigFormViewModel viewModel, Gig gig)
        {
            gig.Modify(viewModel.GetDateTime(), viewModel.Venue, viewModel.Genre);
        }
    }
}