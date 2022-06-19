using LabBigSchool.DTOs;
using LabBigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LabBigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
    public FollowingsController()
    {
        _dbContext = new ApplicationDbContext();
    }
    [System.Web.Http.HttpPost]
    public IHttpActionResult Attend(FollowingDto followingDto)
    {
        var userID = User.Identity.GetUserId();
        if (_dbContext.followings.Any(f => f.FollowerID == userID && f.FolloweeID == followingDto.FolloweeId))
        return BadRequest("The Attendance already exists!");
        var following = new Following
        {
            FollowerID = userID,
            FolloweeID = followingDto.FolloweeId
        };
        _dbContext.followings.Add(following);
        _dbContext.SaveChanges();
        return Ok();
    }
}
}