using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        Attendance GetAttendanceById(string attendeeId, int gigId);
        void AddAttendance(Attendance attendance);
        void RemoveAttendance(Attendance attendance);
    }
}