﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SchoolManagementSystem.Class
{
    class AttendanceReport : Base
    {
        public int Id { get; set; }

        public DateTime InTime { get; set; }

        public DateTime OutTime { get; set; }

        public DateTime TodayDate { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int PersonId { get; set; }

        public int ClassId { get; set; }

        public int SectionId { get; set; }

        public int StudentId { get; set; }

        public int PersonType { get; set; }

        public char Status { get; set; }

        private static readonly String table = "attendance_tbl";

        public DataSet Select()
        {
            //Command = CommandBuilder("select DATE, IN_TIME from " + table + " where DATE between @fromDate and @toDate ORDER BY DATE");
            String queryString = "SELECT vcsws.*,aat.* FROM attendance_tbl aat LEFT JOIN view_class_section_wise_student_tbl vcsws ON(vcsws.STUDENT_ID = aat.PERSON_ID AND aat.PERSON_TYPE = 1) " +
                "WHERE vcsws.CLASS_ID IS NOT null and DATE between @fromDate and @toDate ";

            if (ClassId != 0)
            {
                Console.WriteLine("class"+ ClassId);
                queryString += " and CLASS_ID = @classId ";
            }

            if (SectionId != 0)
            {
                Console.WriteLine("section " + SectionId);
                queryString += " and SECTION_ID = @sectionId ";
            }

            if (StudentId != 0)
            {
                Console.WriteLine("student" + StudentId);
                queryString += " and STUDENT_ID = @studentId ";
            }

            queryString += " ORDER BY DATE";
            Command = CommandBuilder(queryString);
            
            Command.Parameters.AddWithValue("@fromDate", FromDate.Date);
            Command.Parameters.AddWithValue("@toDate", ToDate.Date);
            if (ClassId != 0)
            {
                Command.Parameters.AddWithValue("@classId", ClassId);
            }
            if (SectionId != 0)
            {
                Command.Parameters.AddWithValue("@sectionId", SectionId);
            }
            if (StudentId != 0)
            {
                Command.Parameters.AddWithValue("@studentId", StudentId);
            }
            return ExecuteDataSet(Command);
        }
    }
}
