﻿using System.Collections.Generic;
using ClassLibrary.BL.Interfaces;

namespace ClassLibrary.BL.Model
{
    public class Lesson : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<LessonInSchedule> LessonsInSchedule { get; set; } = null!;
    }
}