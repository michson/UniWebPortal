using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academics;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Academics.DAL
{
    public static class SigningHierarchyDAL
    {
        public static String Insert(SigningHierarchy item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DesignationCode))
                return String.Format("DesignationCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.OrderCode))
                return String.Format("OrderCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Applicable.ToString()))
                return String.Format("Applicable {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (AcademicsEntities context = new AcademicsEntities())
            {
                try
                {
                    context.SigningHierarchies.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(SigningHierarchy item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DesignationCode))
                return String.Format("DesignationCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.OrderCode))
                return String.Format("OrderCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Applicable.ToString()))
                return String.Format("Applicable {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (AcademicsEntities context = new AcademicsEntities())
            {
                try
                {
                    context.SigningHierarchies.AddObject(item);
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
            using (AcademicsEntities context = new AcademicsEntities())
            {
                try
                {
                    var del = (from item in context.SigningHierarchies where (item.Code == Code) select item).FirstOrDefault();
                    context.SigningHierarchies.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(SigningHierarchy item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Academics].[SPSigningHierarchyDelete]" })
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
        public static List<SigningHierarchy> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<SigningHierarchy> objs = new List<SigningHierarchy>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (AcademicsEntities context = new AcademicsEntities())
                    {
                        var item = context.SPSigningHierarchySelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        SigningHierarchy items = new SigningHierarchy
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            DesignationCode = item.DesignationCode,
                            OrderCode = item.OrderCode,
                            SessionCode = item.SessionCode,
                            Applicable = item.Applicable,
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
                    using (AcademicsEntities context = new AcademicsEntities())
                    {
                        var items = context.SPSigningHierarchySelect(Code, UniversityCode, Deleted);
                        foreach (SigningHierarchy item in items)
                        {
                            SigningHierarchy x = new SigningHierarchy
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                DesignationCode = item.DesignationCode,
                                OrderCode = item.OrderCode,
                                SessionCode = item.SessionCode,
                                Applicable = item.Applicable,
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
                return new List<SigningHierarchy>();
            }
        }
    }
}
