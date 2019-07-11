﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SchoolManagementSystem.Class
{
    class Teacher: Base
    {
        public int Id { get; set; }

        public string TeacherName { get; set; }

        public string Mobile { get; set; }

        public string Address { get; set; }

        public DateTime JoiningDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int ActiveStatus { get; set; }

        private static readonly String table = "teacher_setup_tbl";

        public Boolean Insert()
        {
            Command = CommandBuilder("insert into " + table + " (TEACHER_NAME,MOBILE,ADDRESS,JOINING_DATE,END_DATE) values(@teacherName,@mobile,@address,@joiningDate,@endDate)");
            Command.Parameters.AddWithValue("@teacherName", TeacherName);
            Command.Parameters.AddWithValue("@mobile", Mobile);
            Command.Parameters.AddWithValue("@address", Address);
            Command.Parameters.AddWithValue("@joiningDate", JoiningDate);
            Command.Parameters.AddWithValue("@endDate", EndDate);
            return Execute(Command);
        }

        public bool Update()
        {
            Command = CommandBuilder("update " + table + " set TEACHER_NAME = @teacherName, MOBILE = @mobile, ADDRESS = @address, JOINING_DATE = @joiningDate, END_DATE = @endDate  where ID = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@teacherName", TeacherName);
            Command.Parameters.AddWithValue("@mobile", Mobile);
            Command.Parameters.AddWithValue("@address", Address);
            Command.Parameters.AddWithValue("@joiningDate", JoiningDate);
            Command.Parameters.AddWithValue("@endDate", EndDate);
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = CommandBuilder("update " + table + " set ACTIVE_STATUS = @activeStatus where ID = @id");
            //Command = CommandBuilder("delete from " + table + " where ID = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@activeStatus", ActiveStatus);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = CommandBuilder("select ID, TEACHER_NAME,MOBILE,ADDRESS,JOINING_DATE,END_DATE from " + table + " where ID = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Reader = ExecuteReader(Command);
            while (Reader.Read())
            {
                TeacherName = Reader["TEACHER_NAME"].ToString();
                Mobile = Reader["MOBILE"].ToString();
                Address = Reader["ADDRESS"].ToString();
                JoiningDate = (DateTime) Reader["JOINING_DATE"];
                EndDate = (DateTime) Reader["END_DATE"];
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            Command = CommandBuilder("select ID, TEACHER_NAME,MOBILE,ADDRESS,JOINING_DATE,END_DATE from " + table + " where ACTIVE_STATUS = @activeStatus");
            Command.Parameters.AddWithValue("@activeStatus", ActiveStatus);
            if (TeacherName != null && !TeacherName.Trim().Equals(""))
            {
                Command.CommandText += " AND TEACHER_NAME like @search";
                Command.Parameters.AddWithValue("@search", "%" + TeacherName + "%");
            }
            return ExecuteDataSet(Command);
        }
    }
}
