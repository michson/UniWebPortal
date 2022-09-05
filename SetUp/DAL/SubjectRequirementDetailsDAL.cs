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
    public static class SubjectRequirementDetailsDAL
    {
        public static String Insert(SubjectRequirementDetail item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SubjectRequirementCode.ToString()))
                return String.Format("SubjectRequirementCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.GradeCode))
                return String.Format("GradeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.SubjectRequirementDetails.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(SubjectRequirementDetail item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SubjectRequirementCode.ToString()))
                return String.Format("SubjectRequirementCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.GradeCode))
                return String.Format("GradeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.SubjectRequirementDetails.AddObject(item);
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
                    var del = (from item in context.SubjectRequirementDetails where (item.Code == Code) select item).FirstOrDefault();
                    context.SubjectRequirementDetails.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(SubjectRequirementDetail item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[SetUp].[SPSubjectRequirementDetailsDelete]" })
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
        public static List<SubjectRequirementDetail> Retrieve(Int64 Code, Boolean Deleted)
        {
            List<SubjectRequirementDetail> objs = new List<SubjectRequirementDetail>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var item = context.SPSubjectRequirementDetailsSelect(Code, Deleted).FirstOrDefault();
                        SubjectRequirementDetail items = new SubjectRequirementDetail
                        {
                            Code = item.Code,
                            SubjectRequirementCode = item.SubjectRequirementCode,
                            GradeCode = item.GradeCode,
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
                        var items = context.SPSubjectRequirementDetailsSelect(Code, Deleted);
                        foreach (SubjectRequirementDetail item in items)
                        {
                            SubjectRequirementDetail x = new SubjectRequirementDetail
                            {
                                Code = item.Code,
                                SubjectRequirementCode = item.SubjectRequirementCode,
                                GradeCode = item.GradeCode,
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
                return new List<SubjectRequirementDetail>();
            }
        }
    }
}
