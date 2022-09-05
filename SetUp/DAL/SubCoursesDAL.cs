using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SetUp;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SetUp.DAL
{
    public static class SubCoursesDAL
    {
        public static String Insert(SubCours item)
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
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StatusCode))
                return String.Format("StatusCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Practical.ToString()))
                return String.Format("Practical {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Laboratory.ToString()))
                return String.Format("Laboratory {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Credit.ToString()))
                return String.Format("Credit {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Title))
                return String.Format("Title {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PrefixCode))
                return String.Format("PrefixCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SubNo.ToString()))
                return String.Format("SubNo {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SubCode))
                return String.Format("SubCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Notes))
                return String.Format("Notes {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.SubCourses.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(SubCours item)
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
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StatusCode))
                return String.Format("StatusCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Practical.ToString()))
                return String.Format("Practical {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Laboratory.ToString()))
                return String.Format("Laboratory {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Credit.ToString()))
                return String.Format("Credit {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Title))
                return String.Format("Title {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PrefixCode))
                return String.Format("PrefixCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SubNo.ToString()))
                return String.Format("SubNo {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SubCode))
                return String.Format("SubCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Notes))
                return String.Format("Notes {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.SubCourses.AddObject(item);
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
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    var del = (from item in context.SubCourses where (item.Code == Code) select item).FirstOrDefault();
                    context.SubCourses.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(SubCours item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[SetUp].[SPSubCoursesDelete]" })
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
        public static List<SubCours> Retrieve(Int64 Code, String UniversityCode, Int64 FacultyCode, Int64 DepartmentCode, Int64 CourseCode, Int64 ProgramCode, String SemesterCode, Int64 LevelCode, Boolean Deleted)
        {
            List<SubCours> objs = new List<SubCours>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var item = context.SPSubCoursesSelect(Code, UniversityCode, FacultyCode, DepartmentCode, CourseCode, ProgramCode, SemesterCode, LevelCode, Deleted).FirstOrDefault();
                        SubCours items = new SubCours
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            FacultyCode = item.FacultyCode,
                            DepartmentCode = item.DepartmentCode,
                            CourseCode = item.CourseCode,
                            ProgramCode = item.ProgramCode,
                            LevelCode = item.LevelCode,
                            SemesterCode = item.SemesterCode,
                            StatusCode = item.StatusCode,
                            Practical = item.Practical,
                            Laboratory = item.Laboratory,
                            Credit = item.Credit,
                            Title = item.Title,
                            PrefixCode = item.PrefixCode,
                            SubNo = item.SubNo,
                            SubCode = item.SubCode,
                            Notes = item.Notes,
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
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var items = context.SPSubCoursesSelect(Code, UniversityCode, FacultyCode, DepartmentCode, CourseCode, ProgramCode, SemesterCode, LevelCode, Deleted);
                        foreach (SubCours item in items)
                        {
                            SubCours x = new SubCours
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                FacultyCode = item.FacultyCode,
                                DepartmentCode = item.DepartmentCode,
                                CourseCode = item.CourseCode,
                                ProgramCode = item.ProgramCode,
                                LevelCode = item.LevelCode,
                                SemesterCode = item.SemesterCode,
                                StatusCode = item.StatusCode,
                                Practical = item.Practical,
                                Laboratory = item.Laboratory,
                                Credit = item.Credit,
                                Title = item.Title,
                                PrefixCode = item.PrefixCode,
                                SubNo = item.SubNo,
                                SubCode = item.SubCode,
                                Notes = item.Notes,
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
                return new List<SubCours>();
            }
        }
    }
}
