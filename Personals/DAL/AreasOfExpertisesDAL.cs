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
    public static class AreasOfExpertisesDAL
    {
        public static String Insert(AreasOfExpertis item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.JobCategoryCode))
                return String.Format("JobCategoryCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AOSCode))
                return String.Format("AOSCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.YearOfExperience))
                return String.Format("YearOfExperience {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LeveOfExperience))
                return String.Format("LeveOfExperience {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    context.AreasOfExpertises.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(AreasOfExpertis item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.JobCategoryCode))
                return String.Format("JobCategoryCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AOSCode))
                return String.Format("AOSCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.YearOfExperience))
                return String.Format("YearOfExperience {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LeveOfExperience))
                return String.Format("LeveOfExperience {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    context.AreasOfExpertises.AddObject(item);
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
                    var del = (from item in context.AreasOfExpertises where (item.Code == Code) select item).FirstOrDefault();
                    context.AreasOfExpertises.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(AreasOfExpertis item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Personals].[SPAreasOfExpertisesDelete]" })
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
        public static List<AreasOfExpertis> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            List<AreasOfExpertis> objs = new List<AreasOfExpertis>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(AccountCode) & !String.IsNullOrEmpty(ScreenCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (PersonalEntities context = new PersonalEntities())
                    {
                        var item = context.SPAreasOfExpertisesSelect(Code, AccountCode, ScreenCode, Deleted).FirstOrDefault();
                        AreasOfExpertis items = new AreasOfExpertis
                        {
                            Code = item.Code,
                            AccountCode = item.AccountCode,
                            ScreenCode = item.ScreenCode,
                            JobCategoryCode = item.JobCategoryCode,
                            AOSCode = item.AOSCode,
                            YearOfExperience = item.YearOfExperience,
                            LeveOfExperience = item.LeveOfExperience,
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
                        var items = context.SPAreasOfExpertisesSelect(Code, AccountCode, ScreenCode, Deleted);
                        foreach (AreasOfExpertis item in items)
                        {
                            AreasOfExpertis x = new AreasOfExpertis
                            {
                                Code = item.Code,
                                AccountCode = item.AccountCode,
                                ScreenCode = item.ScreenCode,
                                JobCategoryCode = item.JobCategoryCode,
                                AOSCode = item.AOSCode,
                                YearOfExperience = item.YearOfExperience,
                                LeveOfExperience = item.LeveOfExperience,
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
                return new List<AreasOfExpertis>();
            }
        }
    }
}
