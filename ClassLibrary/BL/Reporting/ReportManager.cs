﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary.BL.Model;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.BL.Reporting
{
    public class ReportManager
    {
        private readonly IReportWriter reportWriter;
        private readonly LibraryContext context;

        public ReportManager(IReportWriter reportWriter, LibraryContext context)
        {
            this.reportWriter = reportWriter;
            this.context = context;
        }

        public void GenerateReportByLessonId(int lessonId)
        {
            var results = context.Attendances
                .Include(a => a.LessonInSchedule)
                .ToList()
                .Where(a => a.LessonInSchedule.LessonId == lessonId);

            reportWriter.WriteReport(results);
        }

        public void GenerateReportByStudentId(int studentId)
        {
            var results = context.Attendances
                .Where(a => a.StudentId == studentId);

            reportWriter.WriteReport(results);
        }
    }
}