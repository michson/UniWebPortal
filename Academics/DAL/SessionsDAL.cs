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
    public static class SessionsDAL
    {
        public static String Insert(Session item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StartDate.ToString()))
                return String.Format("StartDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EndDate.ToString()))
                return String.Format("EndDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CurrentYear.ToString()))
                return String.Format("CurrentYear {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NextYear.ToString()))
                return String.Format("NextYear {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionStatus.ToString()))
                return String.Format("SessionStatus {0}", Messages.Warning);
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
                    context.Sessions.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Session item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StartDate.ToString()))
                return String.Format("StartDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EndDate.ToString()))
                return String.Format("EndDate {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CurrentYear.ToString()))
                return String.Format("CurrentYear {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NextYear.ToString()))
                return String.Format("NextYear {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionStatus.ToString()))
                return String.Format("SessionStatus {0}", Messages.Warning);
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
                    context.Sessions.AddObject(item);
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
                    var del = (from item in context.Sessions where (item.Code == Code) select item).FirstOrDefault();
                    context.Sessions.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Session item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Academics].[SPSessionsDelete]" })
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
        public static List<Session> Retrieve(Int64 Code, String UniversityCode, Boolean Deleted)
        {
            List<Session> objs = new List<Session>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (AcademicsEntities context = new AcademicsEntities())
                    {
                        var item = context.SPSessionsSelect(Code, UniversityCode, Deleted).FirstOrDefault();
                        Session items = new Session
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            StartDate = item.StartDate,
                            EndDate = item.EndDate,
                            CurrentYear = item.CurrentYear,
                            NextYear = item.NextYear,
                            SessionStatus = item.SessionStatus,
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
                        var items = context.SPSessionsSelect(Code, UniversityCode, Deleted);
                        foreach (Session item in items)
                        {
                            Session x = new Session
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                StartDate = item.StartDate,
                                EndDate = item.EndDate,
                                CurrentYear = item.CurrentYear,
                                NextYear = item.NextYear,
                                SessionStatus = item.SessionStatus,
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
                return new List<Session>();
            }
        }
    }
}
