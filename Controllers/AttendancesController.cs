using LabBigSchool.DTOs;
using LabBigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabBigSchool.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {


        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDTO)
        {
            var userID = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeID == userID && a.CouresID == attendanceDTO.CourseId))
                return BadRequest("The Attendance already exists!");
            var attendance = new Attendance
            {
                CouresID = attendanceDTO.CourseId,
                AttendeeID = userID
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }
    }


}
