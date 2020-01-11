﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.BL
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Homework> Homeworks { get; set; } = null!;
        public List<Attendance> Attendace { get; set; } = null!;
    }
}
