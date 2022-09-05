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
    public static class AdmissionsDAL
    {
        public static String Insert(Admission item)
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
            else if (String.IsNullOrEmpty(item.Score.ToString()))
                return String.Format("Score {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.JambScore.ToString()))
                return String.Format("JambScore {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CutOffMax.ToString()))
                return String.Format("CutOffMax {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AdmissionStatus))
                return String.Format("AdmissionStatus {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StatusReason))
                return String.Format("StatusReason {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TotalScore.ToString()))
                return String.Format("TotalScore {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (RegistryEntities context = new RegistryEntities())
            {
                try
                {
                    context.Admissions.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Admission item)
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
            else if (String.IsNullOrEmpty(item.Score.ToString()))
                return String.Format("Score {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.JambScore.ToString()))
                return String.Format("JambScore {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CutOffMax.ToString()))
                return String.Format("CutOffMax {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AdmissionStatus))
                return String.Format("AdmissionStatus {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StatusReason))
                return String.Format("StatusReason {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TotalScore.ToString()))
                return String.Format("TotalScore {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (RegistryEntities context = new RegistryEntities())
            {
                try
                {
                    context.Admissions.AddObject(item);
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
                    var del = (from item in context.Admissions where (item.Code == Code) select item).FirstOrDefault();
                    context.Admissions.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Admission item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Registry].[SPAdmissionsSelect]" })
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
        public static List<Admission> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<Admission> objs = new List<Admission>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (RegistryEntities context = new RegistryEntities())
                    {
                        var item = context.SPAdmissionsSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        Admission items = new Admission
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
                            Score = item.Score,
                            JambScore = item.JambScore,
                            CutOffMax = item.CutOffMax,
                            AdmissionStatus = item.AdmissionStatus,
                            StatusReason = item.StatusReason,
                            TotalScore = item.TotalScore,
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
                        var items = context.SPAdmissionsSelect(Code, UniversityCode, Deleted);
                        foreach (Admission item in items)
                        {
                            Admission x = new Admission
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
                                Score = item.Score,
                                JambScore = item.JambScore,
                                CutOffMax = item.CutOffMax,
                                AdmissionStatus = item.AdmissionStatus,
                                StatusReason = item.StatusReason,
                                TotalScore = item.TotalScore,
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
                return new List<Admission>();
            }
        }
    }
}
