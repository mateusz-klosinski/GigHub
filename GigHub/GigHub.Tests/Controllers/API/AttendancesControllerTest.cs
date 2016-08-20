using FluentAssertions;
using GigHub.Controllers.API;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace GigHub.Tests.Controllers.API
{
    [TestClass]
    public class AttendancesControllerTest
    {
        private AttendancesController _controller;
        private string _userId;
        private Mock<IAttendanceRepository> _mockRepository;
        private int _gigId;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IAttendanceRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Attendances).Returns(_mockRepository.Object);

            _controller = new AttendancesController(mockUoW.Object);

            _userId = "1";
            _gigId = 1;
            _controller.MockCurrentUser(_userId, "test@test1.pl");
        }

        [TestMethod]
        public void Attend_AttendanceAlreadyExists_ShoulReturnBadRequest()
        {
            var attendance = new Attendance() { AttendeeId = _userId, GigId = _gigId };

            _mockRepository.Setup(r => r.GetAttendanceById(_userId, _gigId)).Returns(attendance);

            var dto = new AttendanceDto { GigId = _gigId };

            var result = _controller.Attend(dto);

            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }


        [TestMethod]
        public void Atteend_ValidRequest_ShouldReturnOk()
        {
            var dto = new AttendanceDto() { GigId = _gigId };

            var result = _controller.Attend(dto);

            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public void CancelAttendance_AttendanceDoesNotExists_ShouldReturnBadRequest()
        {
            var result = _controller.CancelAttendance(_gigId);

            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }

        [TestMethod]
        public void CancelAttendance_ValidRequest_ShouldReturnOk()
        {
            var attendance = new Attendance { AttendeeId = _userId, GigId = _gigId };

            _mockRepository.Setup(r => r.GetAttendanceById(_userId, _gigId)).Returns(attendance);

            var result = _controller.CancelAttendance(_gigId);

            result.Should().BeOfType<OkResult>();
        }
    }
}
