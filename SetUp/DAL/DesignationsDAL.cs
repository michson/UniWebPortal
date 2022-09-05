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
    public static class DesignationsDAL
    {
        public static String Insert(Designation item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StaffCode))
                return String.Format("StaffCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ComDate.ToString()))
                return String.Format("ComDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CessDate.ToString()))
                return String.Format("CessDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DesignationCode))
                return String.Format("DesignationCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TypeCode))
                return String.Format("TypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Designations.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Designation item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StaffCode))
                return String.Format("StaffCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ComDate.ToString()))
                return String.Format("ComDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CessDate.ToString()))
                return String.Format("CessDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DesignationCode))
                return String.Format("DesignationCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TypeCode))
                return String.Format("TypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Designations.AddObject(item);
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
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    var del = (from item in context.Designations where (item.Code == Code) select item).FirstOrDefault();
                    context.Designations.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Designation item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[SetUp].[SPDesignationsDelete]" })
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
        public static List<Designation> Retrieve(Int64 Code, String StaffCode, Boolean Deleted)
        {
            List<Designation> objs = new List<Designation>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(StaffCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var item = context.SPDesignationsSelect(Code, StaffCode, Deleted).FirstOrDefault();
                        Designation items = new Designation
                        {
                            Code = item.Code,
                            StaffCode = item.StaffCode,
                            ComDate = item.ComDate,
                            CessDate = item.CessDate,
                            DesignationCode = item.DesignationCode,
                            TypeCode = item.TypeCode,
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
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var items = context.SPDesignationsSelect(Code, StaffCode, Deleted);
                        foreach (Designation item in items)
                        {
                            Designation x = new Designation
                            {
                                Code = item.Code,
                                StaffCode = item.StaffCode,
                                ComDate = item.ComDate,
                                CessDate = item.CessDate,
                                DesignationCode = item.DesignationCode,
                                TypeCode = item.TypeCode,
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
                return new List<Designation>();
            }
        }
    }
}
