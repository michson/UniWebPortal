using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Finance.DAL
{
    public static class FeeAllotmentsDAL
    {
        public static String Insert(FeeAllotment item)
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
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EntryMode))
                return String.Format("EntryMode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StudyMode))
                return String.Format("StudyMode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FeeDefinitionCode))
                return String.Format("FeeDefinitionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Amount.ToString()))
                return String.Format("Amount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DiscountPercentage.ToString()))
                return String.Format("DiscountPercentage {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Approved.ToString()))
                return String.Format("Approved {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApproveBy))
                return String.Format("ApproveBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApproveOn.ToString()))
                return String.Format("ApproveOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Notes))
                return String.Format("Notes {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.FeeAllotments.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(FeeAllotment item)
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
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EntryMode))
                return String.Format("EntryMode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StudyMode))
                return String.Format("StudyMode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FeeDefinitionCode))
                return String.Format("FeeDefinitionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Amount.ToString()))
                return String.Format("Amount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DiscountPercentage.ToString()))
                return String.Format("DiscountPercentage {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Approved.ToString()))
                return String.Format("Approved {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApproveBy))
                return String.Format("ApproveBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApproveOn.ToString()))
                return String.Format("ApproveOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Notes))
                return String.Format("Notes {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.FeeAllotments.AddObject(item);
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
            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    var del = (from item in context.FeeAllotments where (item.Code == Code) select item).FirstOrDefault();
                    context.FeeAllotments.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(FeeAllotment item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Finance].[SPFeeAllotmentDelete]" })
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
        public static List<FeeAllotment> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<FeeAllotment> objs = new List<FeeAllotment>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var item = context.SPFeeAllotmentSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        FeeAllotment items = new FeeAllotment
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
                            EntryMode = item.EntryMode,
                            StudyMode = item.StudyMode,
                            FeeDefinitionCode = item.FeeDefinitionCode,
                            Amount = item.Amount,
                            DiscountPercentage = item.DiscountPercentage,
                            Approved = item.Approved,
                            ApproveBy = item.ApproveBy,
                            ApproveOn = item.ApproveOn,
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
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var items = context.SPFeeAllotmentSelect(Code, UniversityCode, Deleted);
                        foreach (FeeAllotment item in items)
                        {
                            FeeAllotment x = new FeeAllotment
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
                                EntryMode = item.EntryMode,
                                StudyMode = item.StudyMode,
                                FeeDefinitionCode = item.FeeDefinitionCode,
                                Amount = item.Amount,
                                DiscountPercentage = item.DiscountPercentage,
                                Approved = item.Approved,
                                ApproveBy = item.ApproveBy,
                                ApproveOn = item.ApproveOn,
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
                return new List<FeeAllotment>();
            }
        }
    }
}
