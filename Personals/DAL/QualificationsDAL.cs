using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Personals;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Personals.DAL
{
    public static class QualificationsDAL
    {
        public static String Insert(Qualification item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EducationTypeCode))
                return String.Format("EducationTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.QualificationTypeCode))
                return String.Format("QualificationTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromYear))
                return String.Format("FromYear {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ToYear))
                return String.Format("ToYear {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromMonth))
                return String.Format("FromMonth {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ToMonth))
                return String.Format("ToMonth {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Certificate))
                return String.Format("Certificate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AwardingBody))
                return String.Format("AwardingBody {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    context.Qualifications.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Qualification item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EducationTypeCode))
                return String.Format("EducationTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.QualificationTypeCode))
                return String.Format("QualificationTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromYear))
                return String.Format("FromYear {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ToYear))
                return String.Format("ToYear {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromMonth))
                return String.Format("FromMonth {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ToMonth))
                return String.Format("ToMonth {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Certificate))
                return String.Format("Certificate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AwardingBody))
                return String.Format("AwardingBody {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    context.Qualifications.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String DeletePermanently(Int32 Code)
        {
            if (String.IsNullOrEmpty(Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    var del = (from item in context.Qualifications where (item.Code == Code) select item).FirstOrDefault();
                    context.Qualifications.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Qualification item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Personals].[SPQualificationsDelete]" })
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
        public static List<Qualification> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            List<Qualification> objs = new List<Qualification>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(AccountCode) & !String.IsNullOrEmpty(ScreenCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (PersonalEntities context = new PersonalEntities())
                    {
                        var item = context.SPQualificationsSelect(Code, AccountCode, ScreenCode, Deleted).FirstOrDefault();
                        Qualification items = new Qualification
                        {
                            Code = item.Code,
                            AccountCode = item.AccountCode,
                            ScreenCode = item.ScreenCode,
                            EducationTypeCode = item.EducationTypeCode,
                            QualificationTypeCode = item.QualificationTypeCode,
                            FromYear = item.FromYear,
                            ToYear = item.ToYear,
                            FromMonth = item.FromMonth,
                            ToMonth = item.ToMonth,
                            AwardingBody = item.AwardingBody,
                            Certificate = item.Certificate,
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
                    using (PersonalEntities context = new PersonalEntities())
                    {
                        var items = context.SPQualificationsSelect(Code, AccountCode, ScreenCode, Deleted);
                        foreach (Qualification item in items)
                        {
                            Qualification x = new Qualification
                            {
                                Code = item.Code,
                                AccountCode = item.AccountCode,
                                ScreenCode = item.ScreenCode,
                                EducationTypeCode = item.EducationTypeCode,
                                QualificationTypeCode = item.QualificationTypeCode,
                                FromYear = item.FromYear,
                                ToYear = item.ToYear,
                                FromMonth = item.FromMonth,
                                ToMonth = item.ToMonth,
                                AwardingBody = item.AwardingBody,
                                Certificate = item.Certificate,
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
                return new List<Qualification>();
            }
        }
    }
}
