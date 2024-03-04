﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidKinder.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string NameSurname { get; set; }
        public string Gender { get; set; }
        public int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
        public int Age { get; set; }
    }
}