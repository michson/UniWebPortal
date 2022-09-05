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
    public static class RefundsDAL
    {
        public static String Insert(Refund item)
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
            else if (String.IsNullOrEmpty(item.MatricNo))
                return String.Format("MatricNo {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FeesCode.ToString()))
                return String.Format("FeesCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Amount.ToString()))
                return String.Format("Amount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Refunded.ToString()))
                return String.Format("Refunded {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RefundedOn.ToString()))
                return String.Format("RefundedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RefundedBy))
                return String.Format("RefundedBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Approved.ToString()))
                return String.Format("Approved {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApproveBy))
                return String.Format("ApproveBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApproveOn.ToString()))
                return String.Format("ApproveOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.Refunds.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Refund item)
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
            else if (String.IsNullOrEmpty(item.MatricNo))
                return String.Format("MatricNo {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FeesCode.ToString()))
                return String.Format("FeesCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Amount.ToString()))
                return String.Format("Amount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Refunded.ToString()))
                return String.Format("Refunded {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RefundedOn.ToString()))
                return String.Format("RefundedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RefundedBy))
                return String.Format("RefundedBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Approved.ToString()))
                return String.Format("Approved {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApproveBy))
                return String.Format("ApproveBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApproveOn.ToString()))
                return String.Format("ApproveOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.Refunds.AddObject(item);
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
                    var del = (from item in context.Refunds where (item.Code == Code) select item).FirstOrDefault();
                    context.Refunds.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Refund item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Finance].[SPRefundsDelete]" })
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
        public static List<Refund> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<Refund> objs = new List<Refund>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var item = context.SPRefundsSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        Refund items = new Refund
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
                            MatricNo = item.MatricNo,
                            FeesCode = item.FeesCode,
                            Amount = item.Amount,
                            Refunded = item.Refunded,
                            RefundedOn = item.RefundedOn,
                            RefundedBy = item.RefundedBy,
                            Approved = item.Approved,
                            ApproveBy = item.ApproveBy,
                            ApproveOn = item.ApproveOn,
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
                        var items = context.SPRefundsSelect(Code, UniversityCode, Deleted);
                        foreach (Refund item in items)
                        {
                            Refund x = new Refund
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
                                MatricNo = item.MatricNo,
                                FeesCode = item.FeesCode,
                                Amount = item.Amount,
                                Refunded = item.Refunded,
                                RefundedOn = item.RefundedOn,
                                RefundedBy = item.RefundedBy,
                                Approved = item.Approved,
                                ApproveBy = item.ApproveBy,
                                ApproveOn = item.ApproveOn,
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
                return new List<Refund>();
            }
        }
    }
}
