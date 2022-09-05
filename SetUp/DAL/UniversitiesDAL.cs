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
    public static class UniversitiesDAL
    {
        public static String Insert(University item)
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityTypeCode))
                return String.Format("UniversityTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Description))
                return String.Format("Description {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LgaCode))
                return String.Format("LgaCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StateCode))
                return String.Format("StateCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CountryCode))
                return String.Format("CountryCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Motto))
                return String.Format("Motto {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Url))
                return String.Format("Url {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EstablishedYear.ToString()))
                return String.Format("EstablishedYear {0}", Messages.Warning);

            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Universities.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(University item)
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityTypeCode))
                return String.Format("UniversityTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Description))
                return String.Format("Description {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LgaCode))
                return String.Format("LgaCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StateCode))
                return String.Format("StateCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CountryCode))
                return String.Format("CountryCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Motto))
                return String.Format("Motto {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Url))
                return String.Format("Url {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EstablishedYear.ToString()))
                return String.Format("EstablishedYear {0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Universities.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String DeletePermanently(String Code)
        {
            if (String.IsNullOrEmpty(Code))
                return String.Format("Code {0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    var del = (from item in context.Universities where (item.Code == Code) select item).FirstOrDefault();
                    context.Universities.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(University item) 
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code{0}", Messages.Warning);
            try 
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString)) 
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[SetUp].[SPUniversitiesDelete]" })
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
        public static List<University> Retrieve(String Code, Boolean Deleted)
        {
            List<University> objs = new List<University>();
            try
            {
                if (!String.IsNullOrEmpty(Code) &! String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var item = context.SPUniversitiesSelect(Code,Deleted).FirstOrDefault();
                        University items = new University
                        {
                            Code = item.Code,
                            UniversityTypeCode = item.UniversityTypeCode,
                            Description = item.Description,
                            LgaCode = item.LgaCode,
                            StateCode = item.StateCode,
                            CountryCode = item.CountryCode,
                            Motto = item.Motto,
                            Url = item.Url,
                            EstablishedYear = item.EstablishedYear,
                            CreatedOn=item.CreatedOn,
                            CreatedBy=item.CreatedBy,
                            ModifiedOn=item.ModifiedOn,
                            ModifiedBy=item.ModifiedBy,
                            Deleted=item.Deleted,
                            DeletedOn=item.DeletedOn,
                            DeletedBy=item.DeletedBy
                         
                        };
                        objs.Add(items);
                    }
                }
                else
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var items = context.SPUniversitiesSelect(Code,Deleted);
                        foreach (University item in items)
                        {
                            University x = new University
                            {
                                Code = item.Code,
                                UniversityTypeCode = item.UniversityTypeCode,
                                Description = item.Description,
                                LgaCode = item.LgaCode,
                                StateCode = item.StateCode,
                                CountryCode = item.CountryCode,
                                Motto = item.Motto,
                                Url = item.Url,
                                EstablishedYear = item.EstablishedYear,
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
                return new List<University>();
            }
        }
    }
}
