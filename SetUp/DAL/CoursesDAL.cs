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
    public static class CoursesDAL
    {
        public static String Insert(Cours item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FacultyCode.ToString()))
                return String.Format("FacultyCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DepartmentCode.ToString()))
                return String.Format("DepartmentCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Acronym))
                return String.Format("Acronym {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Description))
                return String.Format("Description {0}", Messages.Warning);
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
                    context.Courses.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Cours item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FacultyCode.ToString()))
                return String.Format("FacultyCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DepartmentCode.ToString()))
                return String.Format("DepartmentCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Acronym))
                return String.Format("Acronym {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Description))
                return String.Format("Description {0}", Messages.Warning);
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
                    context.Courses.AddObject(item);
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
                    var del = (from item in context.Courses where (item.Code == Code) select item).FirstOrDefault();
                    context.Courses.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Cours item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[SetUp].[SPCoursesDelete]" })
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
        public static List<Cours> Retrieve(Int64 Code, String UniversityCode, Int64 FacultyCode, Int64 DepartmentCode, Boolean Deleted)
        {
            List<Cours> objs = new List<Cours>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(FacultyCode.ToString()) & !String.IsNullOrEmpty(DepartmentCode.ToString()) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var item = context.SPCoursesSelect(Code, UniversityCode, FacultyCode, DepartmentCode, Deleted).FirstOrDefault();
                        Cours items = new Cours
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            FacultyCode = item.FacultyCode,
                            DepartmentCode = item.DepartmentCode,
                            Acronym = item.Acronym,
                            Description = item.Description,
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
                        var items = context.SPCoursesSelect(Code, UniversityCode, FacultyCode, DepartmentCode, Deleted);
                        foreach (Cours item in items)
                        {
                            Cours x = new Cours
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                FacultyCode = item.FacultyCode,
                                DepartmentCode = item.DepartmentCode,
                                Acronym = item.Acronym,
                                Description = item.Description,
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
                return new List<Cours>();
            }
        }
    }
}
