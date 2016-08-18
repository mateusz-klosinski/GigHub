using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers.API
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_unitOfWork.Attendances.GetAttendanceById(userId, dto.GigId) != null)
            {
                return BadRequest("The attendance already exists.");
            }

            var attend = new Attendance()
            {
                GigId = dto.GigId,
                AttendeeId = userId,
            };

            _unitOfWork.Attendances.AddAttendance(attend);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult CancelAttendance(int id)
        {
            var userId = User.Identity.GetUserId();

            if (_unitOfWork.Attendances.GetAttendanceById(userId, id) == null)
            {
                return BadRequest("Attendance does not exist.");
            }

            var attendance = _unitOfWork.Attendances.GetAttendanceById(userId, id);

            _unitOfWork.Attendances.RemoveAttendance(attendance);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
