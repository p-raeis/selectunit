using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selection.Data_Access_Layer
{
    public class DAL
    {
        SelectUnitEntities1 db;
        public DAL()
        {
            db = new SelectUnitEntities1();
        }
        public bool RegisterStudent(Students student)
        {

            try
            {
                db.Students.Add(student);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public Students GetStudentByID(int Id)
        {
            try
            {
                return db.Students.Where(x => x.ID == Id).SingleOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public List<Courses> GetCourses()
        {
            try
            {
                return db.Courses.ToList();
            }
            catch
            {
                return null;
            }
        }
        public bool BindCourse(TakenCourse takenCourses)
        {
            try
            {
                db.TakenCourse.Add(takenCourses);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                var x = ex.Message;
                return false;
            }
        }
        public bool CheackTakenCourse(TakenCourse takenCourses)
        {
            try
            {
                return db.TakenCourse.Where(x=>x.CoureseId==takenCourses.CoureseId && x.ID==takenCourses.ID).FirstOrDefault() != null;
            }
            catch(Exception ex)
            {
                var x = ex.Message;
                return false;
            }
        }
    }
}
