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
    public static class SemestersDAL
    {
        public static String Insert(Semester item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StartDate.ToString()))
                return String.Format("StartDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Endate.ToString()))
                return String.Format("Endate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RegistrationClosingDate.ToString()))
                return String.Format("RegistrationClosingDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterStatus))
                return String.Format("SemesterStatus {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TotalDays.ToString()))
                return String.Format("TotalDays {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Applicable.ToString()))
                return String.Format("Applicable {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (AcademicsEntities context = new AcademicsEntities())
            {
                try
                {
                    context.Semesters.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Semester item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StartDate.ToString()))
                return String.Format("StartDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Endate.ToString()))
                return String.Format("Endate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RegistrationClosingDate.ToString()))
                return String.Format("RegistrationClosingDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterStatus))
                return String.Format("SemesterStatus {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TotalDays.ToString()))
                return String.Format("TotalDays {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Applicable.ToString()))
                return String.Format("Applicable {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (AcademicsEntities context = new AcademicsEntities())
            {
                try
                {
                    context.Semesters.AddObject(item);
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
                    var del = (from item in context.Semesters where (item.Code == Code) select item).FirstOrDefault();
                    context.Semesters.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Semester item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Academics].[SPSemestersDelete]" })
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
        public static List<Semester> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<Semester> objs = new List<Semester>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (AcademicsEntities context = new AcademicsEntities())
                    {
                        var item = context.SPSemestersSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        Semester items = new Semester
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            SessionCode = item.SessionCode,
                            SemesterCode = item.SemesterCode,
                            StartDate = item.StartDate,
                            Endate = item.Endate,
                            RegistrationClosingDate = item.RegistrationClosingDate,
                            SemesterStatus = item.SemesterStatus,
                            TotalDays = item.TotalDays,
                            Applicable = item.Applicable,
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
                        var items = context.SPSemestersSelect(Code, UniversityCode, Deleted);
                        foreach (Semester item in items)
                        {
                            Semester x = new Semester
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                SessionCode = item.SessionCode,
                                SemesterCode = item.SemesterCode,
                                StartDate = item.StartDate,
                                Endate = item.Endate,
                                RegistrationClosingDate = item.RegistrationClosingDate,
                                SemesterStatus = item.SemesterStatus,
                                TotalDays = item.TotalDays,
                                Applicable = item.Applicable,
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
                return new List<Semester>();
            }
        }
    }
}
