using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selection.Data_Access_Layer;

namespace Selection.Business_Logic_Layer
{
    public class BLL
    {
        DAL DataLayer;
        public BLL()
        {
            DataLayer = new DAL();
        }
        public Students GetStudentByID(int id)
        {
            return DataLayer.GetStudentByID(id);
        }
        public Result Register(Students student)
        {
            Result error = new Result();
            if (GetStudentByID(student.ID) == null)
            {
                error.Error = !DataLayer.RegisterStudent(student);
            }
            else
            {

                error.Error = true;
                error.Message = "دانشجو با این شماره دانشجویی وجود دارد";
            }

            return error;
        }
        public List<Courses> GetCourses()
        {
            return DataLayer.GetCourses();
        }
        public Result CheckPassword(int StudentId, string Password)
        {
            Students student = DataLayer.GetStudentByID(StudentId);
            Result error = new Result();
            if (student != null)
            {
                if (student.Phone == Password)
                    error.Error = false;
                else
                {
                    error.Error = true;
                    error.Message = "پسورد اشتباه است";
                }
                return error;
            }
            else
            {
                error.Error = true;
                error.Message = "کاربری با این مشخصات یافت نشد";

                return error;
            }
        }
        public bool BindeCourse(int studentId, int CourseId)
        {
            TakenCourse takenCourses = new TakenCourse()
            {
                ID = studentId,
                CoureseId = CourseId
            };
            if (CheackTakenCourse(takenCourses))
                return false;
            else
                return DataLayer.BindCourse(takenCourses); 

        }
        public bool CheackTakenCourse(TakenCourse takenCourses)
        {

            return DataLayer.CheackTakenCourse(takenCourses);
        }

    }
}
