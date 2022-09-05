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
    public static class StaffsDAL
    {
        public static String Insert(Staff item)
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FacultyCode.ToString()))
                return String.Format("FacultyCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DepartmentCode.ToString()))
                return String.Format("DepartmentCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StaffType))
                return String.Format("StaffType {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ContractType))
                return String.Format("ContractType {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ComDate.ToString()))
                return String.Format("ComDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CessDate.ToString()))
                return String.Format("CessDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StatusCode))
                return String.Format("StatusCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StatusReason))
                return String.Format("StatusReason {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Staffs.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Staff item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FacultyCode.ToString()))
                return String.Format("FacultyCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DepartmentCode.ToString()))
                return String.Format("DepartmentCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StaffType))
                return String.Format("StaffType {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ContractType))
                return String.Format("ContractType {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ComDate.ToString()))
                return String.Format("ComDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CessDate.ToString()))
                return String.Format("CessDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StatusCode))
                return String.Format("StatusCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StatusReason))
                return String.Format("StatusReason {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Staffs.AddObject(item);
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
                    var del = (from item in context.Staffs where (item.Code == Code) select item).FirstOrDefault();
                    context.Staffs.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Staff item)
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[SetUp].[SPStaffDelete]" })
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
        public static List<Staff> Retrieve(String Code, String UniversityCode, Boolean Deleted)
        {
            List<Staff> objs = new List<Staff>();
            try
            {
                if (!String.IsNullOrEmpty(Code) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var item = context.SPStaffSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        Staff items = new Staff
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            FacultyCode = item.FacultyCode,
                            DepartmentCode = item.DepartmentCode,
                            AccountCode = item.AccountCode,
                            StaffType = item.StaffType,
                            ContractType = item.ContractType,
                            ComDate = item.ComDate,
                            CessDate = item.CessDate,
                            StatusCode = item.StatusCode,
                            StatusReason = item.StatusReason,
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
                        var items = context.SPStaffSelect(Code, UniversityCode, Deleted);
                        foreach (Staff item in items)
                        {
                            Staff x = new Staff
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                FacultyCode = item.FacultyCode,
                                DepartmentCode = item.DepartmentCode,
                                AccountCode = item.AccountCode,
                                StaffType = item.StaffType,
                                ContractType = item.ContractType,
                                ComDate = item.ComDate,
                                CessDate = item.CessDate,
                                StatusCode = item.StatusCode,
                                StatusReason = item.StatusReason,
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
                return new List<Staff>();
            }
        }
    }
}
