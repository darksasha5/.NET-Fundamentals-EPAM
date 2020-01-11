﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.BL
{
    public class LessonInSchedule
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
    }
}
