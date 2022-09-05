using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Registry;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Registry.DAL
{
    public static class ExamsDAL
    {
        public static String Insert(Exam item)
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
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EntryMode))
                return String.Format("EntryMode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StudyMode))
                return String.Format("StudyMode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AwardCode))
                return String.Format("AwardCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TypeCode))
                return String.Format("TypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DateApplied.ToString()))
                return String.Format("DateApplied {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Notes))
                return String.Format("Notes {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfSitting.ToString()))
                return String.Format("NoOfSitting {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfCredits.ToString()))
                return String.Format("NoOfCredits {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfPasses.ToString()))
                return String.Format("NoOfPasses {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfDistinctions.ToString()))
                return String.Format("NoOfDistinctions {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfFails.ToString()))
                return String.Format("NoOfFails {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Total.ToString()))
                return String.Format("Total {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (RegistryEntities context = new RegistryEntities())
            {
                try
                {
                    context.Exams.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Exam item)
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
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EntryMode))
                return String.Format("EntryMode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StudyMode))
                return String.Format("StudyMode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AwardCode))
                return String.Format("AwardCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TypeCode))
                return String.Format("TypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DateApplied.ToString()))
                return String.Format("DateApplied {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Notes))
                return String.Format("Notes {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfSitting.ToString()))
                return String.Format("NoOfSitting {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfCredits.ToString()))
                return String.Format("NoOfCredits {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfPasses.ToString()))
                return String.Format("NoOfPasses {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfDistinctions.ToString()))
                return String.Format("NoOfDistinctions {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfFails.ToString()))
                return String.Format("NoOfFails {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Total.ToString()))
                return String.Format("Total {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (RegistryEntities context = new RegistryEntities())
            {
                try
                {
                    context.Exams.AddObject(item);
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
            using (RegistryEntities context = new RegistryEntities())
            {
                try
                {
                    var del = (from item in context.Exams where (item.Code == Code) select item).FirstOrDefault();
                    context.Exams.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Exam item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Registry].[SPExamsSelect]" })
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
        public static List<Exam> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<Exam> objs = new List<Exam>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (RegistryEntities context = new RegistryEntities())
                    {
                        var item = context.SPExamsSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        Exam items = new Exam
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            FacultyCode = item.FacultyCode,
                            DepartmentCode = item.DepartmentCode,
                            CourseCode = item.CourseCode,
                            ProgramCode = item.ProgramCode,
                            LevelCode = item.LevelCode,
                            SessionCode = item.SessionCode,
                            AccountCode = item.AccountCode,
                            EntryMode = item.EntryMode,
                            StudyMode = item.StudyMode,
                            AwardCode = item.AwardCode,
                            TypeCode = item.TypeCode,
                            DateApplied = item.DateApplied,
                            Notes = item.Notes,
                            NoOfSitting = item.NoOfSitting,
                            NoOfCredits = item.NoOfCredits,
                            NoOfPasses = item.NoOfPasses,
                            NoOfDistinctions = item.NoOfDistinctions,
                            NoOfFails = item.NoOfFails,
                            Total = item.Total,
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
                    using (RegistryEntities context = new RegistryEntities())
                    {
                        var items = context.SPExamsSelect(Code, UniversityCode, Deleted);
                        foreach (Exam item in items)
                        {
                            Exam x = new Exam
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                FacultyCode = item.FacultyCode,
                                DepartmentCode = item.DepartmentCode,
                                CourseCode = item.CourseCode,
                                ProgramCode = item.ProgramCode,
                                LevelCode = item.LevelCode,
                                SessionCode = item.SessionCode,
                                AccountCode = item.AccountCode,
                                EntryMode = item.EntryMode,
                                StudyMode = item.StudyMode,
                                AwardCode = item.AwardCode,
                                TypeCode = item.TypeCode,
                                DateApplied = item.DateApplied,
                                Notes = item.Notes,
                                NoOfSitting = item.NoOfSitting,
                                NoOfCredits = item.NoOfCredits,
                                NoOfPasses = item.NoOfPasses,
                                NoOfDistinctions = item.NoOfDistinctions,
                                NoOfFails = item.NoOfFails,
                                Total = item.Total,
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
                return new List<Exam>();
            }
        }
    }
}
