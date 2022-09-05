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
    public static class VouchersDAL
    {
        public static String Insert(Voucher item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountGroupCode))
                return String.Format("AccountGroupCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountSubCode.ToString()))
                return String.Format("AccountSubCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountTypeCode.ToString()))
                return String.Format("AccountTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode.ToString()))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.VoucherTypeCode))
                return String.Format("VoucherTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TransactionTypeCode))
                return String.Format("TransactionTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EntityTypeCode))
                return String.Format("EntityTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ParticularsCode))
                return String.Format("ParticularsCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DateX.ToString()))
                return String.Format("DateX {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DebitAmount.ToString()))
                return String.Format("DebitAmount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreditAmount.ToString()))
                return String.Format("CreditAmount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Narration))
                return String.Format("Narration {0}", Messages.Warning);
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
                    context.Vouchers.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Voucher item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountGroupCode))
                return String.Format("AccountGroupCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountSubCode.ToString()))
                return String.Format("AccountSubCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountTypeCode.ToString()))
                return String.Format("AccountTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode.ToString()))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.VoucherTypeCode))
                return String.Format("VoucherTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TransactionTypeCode))
                return String.Format("TransactionTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EntityTypeCode))
                return String.Format("EntityTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ParticularsCode))
                return String.Format("ParticularsCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DateX.ToString()))
                return String.Format("DateX {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DebitAmount.ToString()))
                return String.Format("DebitAmount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreditAmount.ToString()))
                return String.Format("CreditAmount {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Narration))
                return String.Format("Narration {0}", Messages.Warning);
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
                    context.Vouchers.AddObject(item);
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
                    var del = (from item in context.Vouchers where (item.Code == Code) select item).FirstOrDefault();
                    context.Vouchers.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Voucher item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Finance].[SPVouchersDelete]" })
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
        public static List<Voucher> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<Voucher> objs = new List<Voucher>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var item = context.SPVouchersSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        Voucher items = new Voucher
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            SessionCode = item.SessionCode,
                            SemesterCode = item.SemesterCode,
                            AccountGroupCode = item.AccountGroupCode,
                            AccountSubCode = item.AccountSubCode,
                            AccountTypeCode = item.AccountTypeCode,
                            AccountCode = item.AccountCode,
                            VoucherTypeCode = item.VoucherTypeCode,
                            TransactionTypeCode = item.TransactionTypeCode,
                            EntityTypeCode = item.EntityTypeCode,
                            ParticularsCode = item.ParticularsCode,
                            DateX = item.DateX,
                            DebitAmount = item.DebitAmount,
                            CreditAmount = item.CreditAmount,
                            Narration = item.Narration,
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
                        var items = context.SPVouchersSelect(Code, UniversityCode, Deleted);
                        foreach (Voucher item in items)
                        {
                            Voucher x = new Voucher
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                SessionCode = item.SessionCode,
                                SemesterCode = item.SemesterCode,
                                AccountGroupCode = item.AccountGroupCode,
                                AccountSubCode = item.AccountSubCode,
                                AccountTypeCode = item.AccountTypeCode,
                                AccountCode = item.AccountCode,
                                VoucherTypeCode = item.VoucherTypeCode,
                                TransactionTypeCode = item.TransactionTypeCode,
                                EntityTypeCode = item.EntityTypeCode,
                                ParticularsCode = item.ParticularsCode,
                                DateX = item.DateX,
                                DebitAmount = item.DebitAmount,
                                CreditAmount = item.CreditAmount,
                                Narration = item.Narration,
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
                return new List<Voucher>();
            }
        }
    }
}
