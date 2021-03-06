﻿using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Persistance.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext context)
        {

            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Gig.DateTime >= DateTime.Now)
                .ToList();
        }

        public Attendance GetAttendanceById(string attendeeId, int gigId)
        {
            return _context.Attendances.SingleOrDefault(a => a.AttendeeId == attendeeId && a.GigId == gigId);
        }

        public void AddAttendance(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
        }

        public void RemoveAttendance(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
        }
    }
}