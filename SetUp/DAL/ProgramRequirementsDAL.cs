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
    public static class ProgramRequirementsDAL
    {
        public static String Insert(ProgramRequirement item)
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
            else if (String.IsNullOrEmpty(item.MinimumCredit.ToString()))
                return String.Format("MinimumCredit {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.MaximumCredit.ToString()))
                return String.Format("MaximumCredit {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TotalDuration.ToString()))
                return String.Format("TotalDuration {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DurationUnit))
                return String.Format("DurationUnit {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EntryMode.ToString()))
                return String.Format("EntryMode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModeOfStudy))
                return String.Format("ModeOfStudy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.ProgramRequirements.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(ProgramRequirement item)
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
            else if (String.IsNullOrEmpty(item.MinimumCredit.ToString()))
                return String.Format("MinimumCredit {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.MaximumCredit.ToString()))
                return String.Format("MaximumCredit {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TotalDuration.ToString()))
                return String.Format("TotalDuration {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DurationUnit))
                return String.Format("DurationUnit {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EntryMode.ToString()))
                return String.Format("EntryMode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModeOfStudy))
                return String.Format("ModeOfStudy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.ProgramRequirements.AddObject(item);
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
                    var del = (from item in context.ProgramRequirements where (item.Code == Code) select item).FirstOrDefault();
                    context.ProgramRequirements.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(ProgramRequirement item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[SetUp].[SPProgramRequirementsDelete]" })
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
        public static List<ProgramRequirement> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<ProgramRequirement> objs = new List<ProgramRequirement>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var item = context.SPProgramRequirementsSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        ProgramRequirement items = new ProgramRequirement
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            FacultyCode = item.FacultyCode,
                            DepartmentCode = item.DepartmentCode,
                            CourseCode = item.CourseCode,
                            ProgramCode = item.ProgramCode,
                            MinimumCredit = item.MinimumCredit,
                            MaximumCredit = item.MaximumCredit,
                            TotalDuration = item.TotalDuration,
                            DurationUnit = item.DurationUnit,
                            EntryMode = item.EntryMode,
                            ModeOfStudy = item.ModeOfStudy,
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
                        var items = context.SPProgramRequirementsSelect(Code, UniversityCode, Deleted);
                        foreach (ProgramRequirement item in items)
                        {
                            ProgramRequirement x = new ProgramRequirement
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                FacultyCode = item.FacultyCode,
                                DepartmentCode = item.DepartmentCode,
                                CourseCode = item.CourseCode,
                                ProgramCode = item.ProgramCode,
                                MinimumCredit = item.MinimumCredit,
                                MaximumCredit = item.MaximumCredit,
                                TotalDuration = item.TotalDuration,
                                DurationUnit = item.DurationUnit,
                                EntryMode = item.EntryMode,
                                ModeOfStudy = item.ModeOfStudy,
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
                return new List<ProgramRequirement>();
            }
        }
    }
}
