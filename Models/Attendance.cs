﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LabBigSchool.Models
{
    public class Attendance
    {
        public Course Course { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CouresID { get; set; }
        public ApplicationUser Attendee { get; set; }
        [Key]
        [Column(Order = 2)]
        public string AttendeeID { get; set; }
    }
}