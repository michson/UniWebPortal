using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Assessment.DAL
{
    public static class AttendanceDAL
    {
        public static String Insert(Attendance item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FacultyCode.ToString()))
                return String.Format("FacultyCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DepartmentCode.ToString()))
                return String.Format("DepartmentCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CourseCode.ToString()))
                return String.Format("CourseCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ProgramCode.ToString()))
                return String.Format("ProgramCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LevelCode.ToString()))
                return String.Format("LevelCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode.ToString()))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StudentCode.ToString()))
                return String.Format("StudentCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.MatricNo))
                return String.Format("MatricNo {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AttendanceStatus))
                return String.Format("AttendanceStatus {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SubCourseCode.ToString()))
                return String.Format("SubCourseCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StaffCode))
                return String.Format("StaffCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AttendanceType))
                return String.Format("AttendanceType {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Remark))
                return String.Format("Remark {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (AssessmentEntities context = new AssessmentEntities())
            {
                try
                {
                    context.Attendances.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Attendance item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FacultyCode.ToString()))
                return String.Format("FacultyCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DepartmentCode.ToString()))
                return String.Format("DepartmentCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CourseCode.ToString()))
                return String.Format("CourseCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ProgramCode.ToString()))
                return String.Format("ProgramCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LevelCode.ToString()))
                return String.Format("LevelCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode.ToString()))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StudentCode.ToString()))
                return String.Format("StudentCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.MatricNo))
                return String.Format("MatricNo {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AttendanceStatus))
                return String.Format("AttendanceStatus {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SubCourseCode.ToString()))
                return String.Format("SubCourseCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StaffCode))
                return String.Format("StaffCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AttendanceType))
                return String.Format("AttendanceType {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Remark))
                return String.Format("Remark {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (AssessmentEntities context = new AssessmentEntities())
            {
                try
                {
                    context.Attendances.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String DeletePermanently(Int64 Code)
        {
            if (String.IsNullOrEmpty(Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            using (AssessmentEntities context = new AssessmentEntities())
            {
                try
                {
                    var del = (from item in context.Attendances where (item.Code == Code) select item).FirstOrDefault();
                    context.Attendances.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Attendance item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Assessment].[SPAttendanceDelete]" })
                    {
                        cmd.Parameters.AddWithValue("@Code", item.Code);
                        cmd.Parameters.AddWithValue("@Deleted", item.Deleted);
                        cmd.Parameters.AddWithValue("@DeletedOn", item.DeletedOn);
                        cmd.Parameters.AddWithValue("@DeletedBy", item.DeletedBy);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        return Messages.Deleted;
                    }
                }
            }
            catch (Exception ex)
            {
                return String.Format("{0}:\n{1}", ex.Message, Messages.Warning);
            }
        }
        public static List<Attendance> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<Attendance> objs = new List<Attendance>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (AssessmentEntities context = new AssessmentEntities())
                    {
                        var item = context.SPAttendanceSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        Attendance items = new Attendance
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            FacultyCode = item.FacultyCode,
                            DepartmentCode = item.DepartmentCode,
                            CourseCode = item.CourseCode,
                            ProgramCode = item.ProgramCode,
                            LevelCode = item.LevelCode,
                            SessionCode = item.SessionCode,
                            SemesterCode = item.SemesterCode,
                            StudentCode = item.StudentCode,
                            MatricNo = item.MatricNo,
                            AttendanceStatus = item.AttendanceStatus,
                            SubCourseCode = item.SubCourseCode,
                            StaffCode = item.StaffCode,
                            AttendanceType = item.AttendanceType,
                            Remark = item.Remark,
                            ScreenCode = item.ScreenCode,
                            CreatedOn = item.CreatedOn,
                            CreatedBy = item.CreatedBy,
                            ModifiedOn = item.ModifiedOn,
                            ModifiedBy = item.ModifiedBy,
                            Deleted = item.Deleted,
                            DeletedOn = item.DeletedOn,
                            DeletedBy = item.DeletedBy
                        };
                        objs.Add(items);
                    }
                }
                else
                {
                    using (AssessmentEntities context = new AssessmentEntities())
                    {
                        var items = context.SPAttendanceSelect(Code, UniversityCode, Deleted);
                        foreach (Attendance item in items)
                        {
                            Attendance x = new Attendance
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                FacultyCode = item.FacultyCode,
                                DepartmentCode = item.DepartmentCode,
                                CourseCode = item.CourseCode,
                                ProgramCode = item.ProgramCode,
                                LevelCode = item.LevelCode,
                                SessionCode = item.SessionCode,
                                SemesterCode = item.SemesterCode,
                                StudentCode = item.StudentCode,
                                MatricNo = item.MatricNo,
                                AttendanceStatus = item.AttendanceStatus,
                                SubCourseCode = item.SubCourseCode,
                                StaffCode = item.StaffCode,
                                AttendanceType = item.AttendanceType,
                                Remark = item.Remark,
                                ScreenCode = item.ScreenCode,
                                CreatedOn = item.CreatedOn,
                                CreatedBy = item.CreatedBy,
                                ModifiedOn = item.ModifiedOn,
                                ModifiedBy = item.ModifiedBy,
                                Deleted = item.Deleted,
                                DeletedOn = item.DeletedOn,
                                DeletedBy = item.DeletedBy
                            };
                            objs.Add(x);
                        }
                    }
                }
                return objs;
            }
            catch
            {
                return new List<Attendance>();
            }
        }
    }
}
