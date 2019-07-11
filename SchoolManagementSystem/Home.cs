﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolManagementSystem.Presentation;

namespace SchoolManagementSystem
{
    public partial class frmHome : Form
    {
        frmClass cst = new frmClass();
        frmSection section = new frmSection();
        frmRole role = new frmRole();
        frmUser user = new frmUser();
        frmSubject subject = new frmSubject();
        frmClassWiseSubjectList cwsl = new frmClassWiseSubjectList();
        frmClassWiseSection cws = new frmClassWiseSection();
        frmAttedndance attendance = new frmAttedndance();
        frmTeacher teacher = new frmTeacher();

        public frmHome()
        {
            InitializeComponent();
        }


        private void menuClick(Form frm)
        {
            //if (frm.IsDisposed)
            //    frm = new Form();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cst.IsDisposed)
                cst = new frmClass();
            menuClick(cst);
        }

        private void roleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (role.IsDisposed)
                role = new frmRole();
            menuClick(role);
        }

        private void subjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (subject.IsDisposed)
                subject = new frmSubject();
            menuClick(subject);
        }

        private void classWiseSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cwsl.IsDisposed)
                cwsl = new frmClassWiseSubjectList();
            menuClick(cwsl);
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user.IsDisposed)
                user = new frmUser();
            menuClick(user);
        }

        private void sectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (section.IsDisposed)
                section = new frmSection();
            menuClick(section);
        }

        private void classWiseSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cws.IsDisposed)
                cws = new frmClassWiseSection();
            menuClick(cws);
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (attendance.IsDisposed)
                attendance = new frmAttedndance();
            menuClick(attendance);
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (teacher.IsDisposed)
                teacher = new frmTeacher();
            menuClick(teacher);
        }
    }
}
