using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers.API
{
    [Authorize]
    public class FollowsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowsDto dto)
        {
            var artistId = _unitOfWork.Users.GetUserIdByName(dto.ArtistName);
            var userId = User.Identity.GetUserId();


            if (artistId == userId || (_unitOfWork.Follows.GetFollowById(userId, artistId) != null))
            {
                return BadRequest("Duplikat lub odwo³anie do samego siebie.");
            }

            var follow = new Follow()
            {
                FollowerId = userId,
                ArtistId = artistId,
            };

            _unitOfWork.Follows.AddFollow(follow);
            _unitOfWork.Complete();

            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult UnFollow(FollowsDto dto)
        {
            var artistId = _unitOfWork.Users.GetUserIdByName(dto.ArtistName);
            var userId = User.Identity.GetUserId();


            var follow = _unitOfWork.Follows.GetFollowById(userId, artistId);

            if (follow == null)
                return NotFound();

            _unitOfWork.Follows.RemoveFollow(follow);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
