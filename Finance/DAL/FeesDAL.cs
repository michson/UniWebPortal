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
    public static class FeesDAL
    {
        public static String Insert(Fee item)
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
            else if (String.IsNullOrEmpty(item.AccountTitle))
                return String.Format("AccountTitle {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountNo))
                return String.Format("AccountNo {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.BankCode))
                return String.Format("BankCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.BankBranch))
                return String.Format("BankBranch {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PaymentMode))
                return String.Format("PaymentMode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DateX.ToString()))
                return String.Format("DateX {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Amount.ToString()))
                return String.Format("Amount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Balance.ToString()))
                return String.Format("Balance {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PaymentStatus))
                return String.Format("PaymentStatus {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.Fees.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Fee item)
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
            else if (String.IsNullOrEmpty(item.AccountTitle))
                return String.Format("AccountTitle {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountNo))
                return String.Format("AccountNo {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.BankCode))
                return String.Format("BankCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.BankBranch))
                return String.Format("BankBranch {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PaymentMode))
                return String.Format("PaymentMode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DateX.ToString()))
                return String.Format("DateX {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Amount.ToString()))
                return String.Format("Amount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Balance.ToString()))
                return String.Format("Balance {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PaymentStatus))
                return String.Format("PaymentStatus {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.Fees.AddObject(item);
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
                    var del = (from item in context.Fees where (item.Code == Code) select item).FirstOrDefault();
                    context.Fees.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Fee item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Finance].[SPFeesDelete]" })
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
        public static List<Fee> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<Fee> objs = new List<Fee>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var item = context.SPFeesSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        Fee items = new Fee
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
                            AccountTitle = item.AccountTitle,
                            AccountNo = item.AccountNo,
                            BankCode = item.BankCode,
                            BankBranch = item.BankBranch,
                            PaymentMode = item.PaymentMode,
                            DateX = item.DateX,
                            Amount = item.Amount,
                            Balance = item.Balance,
                            PaymentStatus = item.PaymentStatus,
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
                        var items = context.SPFeesSelect(Code, UniversityCode, Deleted);
                        foreach (Fee item in items)
                        {
                            Fee x = new Fee
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
                                AccountTitle = item.AccountTitle,
                                AccountNo = item.AccountNo,
                                BankCode = item.BankCode,
                                BankBranch = item.BankBranch,
                                PaymentMode = item.PaymentMode,
                                DateX = item.DateX,
                                Amount = item.Amount,
                                Balance = item.Balance,
                                PaymentStatus = item.PaymentStatus,
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
                return new List<Fee>();
            }
        }
    }
}
