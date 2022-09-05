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
    public static class ReligionsDAL
    {
        public static String Insert(Religion item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.BioDataCode))
                return String.Format("BioDataCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ReligionCode))
                return String.Format("ReligionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Clergy))
                return String.Format("Clergy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PlaceOfWorship))
                return String.Format("PlaceOfWorship {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PlaceOfWorshipAddress))
                return String.Format("PlaceOfWorshipAddress {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ClergyPhoneNumber))
                return String.Format("ClergyPhoneNumber {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ClergyEmail))
                return String.Format("ClergyEmail {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PlaceOfWorshipPhoneNumber))
                return String.Format("PlaceOfWorshipPhoneNumber {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PlaceOfWorshipEmail))
                return String.Format("PlaceOfWorshipEmail {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    context.Religions.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Religion item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ReligionCode))
                return String.Format("ReligionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Clergy))
                return String.Format("Clergy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PlaceOfWorship))
                return String.Format("PlaceOfWorship {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PlaceOfWorshipAddress))
                return String.Format("PlaceOfWorshipAddress {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ClergyPhoneNumber))
                return String.Format("ClergyPhoneNumber {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ClergyEmail))
                return String.Format("ClergyEmail {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PlaceOfWorshipPhoneNumber))
                return String.Format("PlaceOfWorshipPhoneNumber {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PlaceOfWorshipEmail))
                return String.Format("PlaceOfWorshipEmail {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    context.Religions.AddObject(item);
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
                    var del = (from item in context.Religions where (item.Code == Code) select item).FirstOrDefault();
                    context.Religions.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Religion item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Personals].[SPReligionsDelete]" })
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
        public static List<Religion> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            List<Religion> objs = new List<Religion>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(AccountCode) & !String.IsNullOrEmpty(ScreenCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (PersonalEntities context = new PersonalEntities())
                    {
                        var item = context.SPReligionsSelect(Code, AccountCode, ScreenCode, Deleted).FirstOrDefault();
                        Religion items = new Religion
                        {
                            Code = item.Code,
                            AccountCode = item.AccountCode,
                            ScreenCode = item.ScreenCode,
                            BioDataCode = item.BioDataCode,
                            ReligionCode = item.ReligionCode,
                            Clergy = item.Clergy,
                            PlaceOfWorship = item.PlaceOfWorship,
                            PlaceOfWorshipAddress = item.PlaceOfWorshipAddress,
                            ClergyPhoneNumber = item.ClergyPhoneNumber,
                            ClergyEmail = item.ClergyEmail,
                            PlaceOfWorshipPhoneNumber = item.PlaceOfWorshipPhoneNumber,
                            PlaceOfWorshipEmail = item.PlaceOfWorshipEmail,
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
                        var items = context.SPReligionsSelect(Code, AccountCode, ScreenCode, Deleted);
                        foreach (Religion item in items)
                        {
                            Religion x = new Religion
                            {
                                Code = item.Code,
                                AccountCode = item.AccountCode,
                                ScreenCode = item.ScreenCode,
                                BioDataCode = item.BioDataCode,
                                ReligionCode = item.ReligionCode,
                                Clergy = item.Clergy,
                                PlaceOfWorship = item.PlaceOfWorship,
                                PlaceOfWorshipAddress = item.PlaceOfWorshipAddress,
                                ClergyPhoneNumber = item.ClergyPhoneNumber,
                                ClergyEmail = item.ClergyEmail,
                                PlaceOfWorshipPhoneNumber = item.PlaceOfWorshipPhoneNumber,
                                PlaceOfWorshipEmail = item.PlaceOfWorshipEmail,
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
                return new List<Religion>();
            }
        }
    }
}
