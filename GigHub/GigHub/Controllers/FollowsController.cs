using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Dtos;
using GigHub.Migrations;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowsDto dto)
        {
            var artistId = _context.Users.Single(u => u.Name == dto.ArtistName).Id;
            var userId = User.Identity.GetUserId();


            if (artistId == userId || _context.Follows.Any(f => f.ArtistId == artistId && f.FollowerId == userId))
            {
                return BadRequest("Duplikat lub odwołanie do samego siebie.");
            }

            var follow = new Follow()
            {
                FollowerId = userId,
                ArtistId = artistId,
            };

            _context.Follows.Add(follow);
            _context.SaveChanges();

            return Ok();
        }
    }
}
