using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academics;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Academics.DAL
{
    public static class RegistrationsDAL
    {
        public static String Insert(Registration item)
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
            else if (String.IsNullOrEmpty(item.TypeCode))
                return String.Format("TypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SubCourseCode.ToString()))
                return String.Format("SubCourseCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Status))
                return String.Format("Status {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TicketCode.ToString()))
                return String.Format("TicketCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PinCode.ToString()))
                return String.Format("PinCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Signed.ToString()))
                return String.Format("Signed {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SignedBy))
                return String.Format("SignedBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SignedOn.ToString()))
                return String.Format("SignedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SelfSigned.ToString()))
                return String.Format("SelfSigned {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SelfSignedOn.ToString()))
                return String.Format("SelfSignedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (AcademicsEntities context = new AcademicsEntities())
            {
                try
                {
                    context.Registrations.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Registration item)
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
            else if (String.IsNullOrEmpty(item.TypeCode))
                return String.Format("TypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SubCourseCode.ToString()))
                return String.Format("SubCourseCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Status))
                return String.Format("Status {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TicketCode.ToString()))
                return String.Format("TicketCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PinCode.ToString()))
                return String.Format("PinCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Signed.ToString()))
                return String.Format("Signed {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SignedBy))
                return String.Format("SignedBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SignedOn.ToString()))
                return String.Format("SignedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SelfSigned.ToString()))
                return String.Format("SelfSigned {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SelfSignedOn.ToString()))
                return String.Format("SelfSignedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (AcademicsEntities context = new AcademicsEntities())
            {
                try
                {
                    context.Registrations.AddObject(item);
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
            using (AcademicsEntities context = new AcademicsEntities())
            {
                try
                {
                    var del = (from item in context.Registrations where (item.Code == Code) select item).FirstOrDefault();
                    context.Registrations.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Registration item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Academics].[SPRegistrationsDelete]" })
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
        public static List<Registration> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<Registration> objs = new List<Registration>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (AcademicsEntities context = new AcademicsEntities())
                    {
                        var item = context.SPRegistrationsSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        Registration items = new Registration
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
                            TypeCode = item.TypeCode,
                            SubCourseCode = item.SubCourseCode,
                            Status = item.Status,
                            TicketCode = item.TicketCode,
                            PinCode = item.PinCode,
                            Signed = item.Signed,
                            SignedBy = item.SignedBy,
                            SignedOn = item.SignedOn,
                            SelfSigned = item.SelfSigned,
                            SelfSignedOn = item.SelfSignedOn,
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
                    using (AcademicsEntities context = new AcademicsEntities())
                    {
                        var items = context.SPRegistrationsSelect(Code, UniversityCode, Deleted);
                        foreach (Registration item in items)
                        {
                            Registration x = new Registration
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
                                TypeCode = item.TypeCode,
                                SubCourseCode = item.SubCourseCode,
                                Status = item.Status,
                                TicketCode = item.TicketCode,
                                PinCode = item.PinCode,
                                Signed = item.Signed,
                                SignedBy = item.SignedBy,
                                SignedOn = item.SignedOn,
                                SelfSigned = item.SelfSigned,
                                SelfSignedOn = item.SelfSignedOn,
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
                return new List<Registration>();
            }
        }
    }
}
