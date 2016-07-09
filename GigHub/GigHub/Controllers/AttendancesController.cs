using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
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
        public IHttpActionResult Attend([FromBody]int gigID)
        {
            var attend = new Attendance()
            {
                GigId = gigID,
                AttendeeId = User.Identity.GetUserId(),
            };

            _context.Attendances.Add(attend);
            _context.SaveChanges();

            return Ok();
        }
    }
}
