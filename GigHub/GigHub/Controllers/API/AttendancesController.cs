using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Persistance;

namespace GigHub.Controllers.API
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
            {
                return BadRequest("The attendance already exists.");
            }

            var attend = new Attendance()
            {
                GigId = dto.GigId,
                AttendeeId = userId,
            };

            _context.Attendances.Add(attend);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult CancelAttendance(int id)
        {
            var userId = User.Identity.GetUserId();

            if (!_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == id))
            {
                return BadRequest("Attendance does not exist.");
            }

            var attendance = _context.Attendances.Single(a => a.AttendeeId == userId && a.GigId == id);

            _context.Attendances.Remove(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
