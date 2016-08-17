using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Repositories
{
    public class AttendanceRepository
    {
        private ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext _context)
        {

            this._context = _context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Gig.DateTime >= DateTime.Now)
                .ToList();
        }
    }
}