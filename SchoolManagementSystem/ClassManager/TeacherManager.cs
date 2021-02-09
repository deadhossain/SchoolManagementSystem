﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.Class;
using System.IO;
using System.Data;

namespace SchoolManagementSystem.ClassManager
{
    class TeacherManager
    {
        public string SaveTeacher(Teacher aTeacher)
        {
            if (aTeacher.Insert())
            {
                return "New Teacher has been inserted";
            }
            else
            {
                File.AppendAllText("logs.txt", DateTime.Now.ToString() + " :: Inserting Teacher " + Environment.NewLine);
                File.AppendAllText("logs.txt", DateTime.Now.ToString() + " :: " + aTeacher.Error + Environment.NewLine);
                return aTeacher.Error;
            }
        }

        public String UpdateTeacher(Teacher aTeacher)
        {
            if (aTeacher.Update())
            {
                return "Teacher has been updated";
            }
            else
            {
                File.AppendAllText("logs.txt", DateTime.Now.ToString() + " :: Updating Teacher " + Environment.NewLine);
                File.AppendAllText("logs.txt", DateTime.Now.ToString() + " :: " + aTeacher.Error + Environment.NewLine);
                return aTeacher.Error;
            }
        }

        public string DeleteTeacher(Teacher aTeacher)
        {
            if (aTeacher.Delete())
            {
                return "Teacher has been deleted";
            }
            else
            {
                File.AppendAllText("logs.txt", DateTime.Now.ToString() + " :: Deleting Teacher " + Environment.NewLine);
                File.AppendAllText("logs.txt", DateTime.Now.ToString() + " :: " + aTeacher.Error + Environment.NewLine);
                return aTeacher.Error;
            }
        }

        public byte[] GetFingerDataById(Teacher aTeacher)
        {
            return aTeacher.SelectFingerById();
        }

        public DataTable GetAllTeacherData(Teacher aTeacher)
        {
            DataSet ds = aTeacher.Select();
            if (ds == null)
                return null;
            return ds.Tables[0];
        }

        public string SaveFingerInfo(Teacher aTeacher)
        {
            if (aTeacher.InsertFinger())
            {
                return "New Finger information has been inserted";
            }
            else
            {
                File.AppendAllText("logs.txt", DateTime.Now.ToString() + " :: Inserting Teacher " + Environment.NewLine);
                File.AppendAllText("logs.txt", DateTime.Now.ToString() + " :: " + aTeacher.Error + Environment.NewLine);
                return aTeacher.Error;
            }
        }

        public DataTable GetAllFingerData(Teacher aTeacher)
        {
            DataSet ds = aTeacher.SelectAllFinger();
            if (ds == null)
                return null;
            return ds.Tables[0];
        }
    }
}
