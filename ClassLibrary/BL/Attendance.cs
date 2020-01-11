﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.BL
{
    public class Attendance
    {
        public int Id { get; set; }
        public bool IsPresent { get; set; }

        public int LessonInScheduleId { get; set; }
        public LessonInSchedule LessonInSchedule { get; set; } = null!;
        
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
    }
}
