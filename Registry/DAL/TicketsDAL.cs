using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Registry;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Registry.DAL
{
    public static class TicketsDAL
    {
        public static String Insert(Ticket item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PinCode.ToString()))
                return String.Format("PinCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DateX.ToString()))
                return String.Format("DateX {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StatusCode))
                return String.Format("StatusCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfUse.ToString()))
                return String.Format("NoOfUse {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.MaxNoUse.ToString()))
                return String.Format("MaxNoUse {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ExpiryDate.ToString()))
                return String.Format("MaxNoUse {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (RegistryEntities context = new RegistryEntities())
            {
                try
                {
                    context.Tickets.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Ticket item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode.ToString()))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PinCode.ToString()))
                return String.Format("PinCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DateX.ToString()))
                return String.Format("DateX {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StatusCode))
                return String.Format("StatusCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfUse.ToString()))
                return String.Format("NoOfUse {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.MaxNoUse.ToString()))
                return String.Format("MaxNoUse {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ExpiryDate.ToString()))
                return String.Format("MaxNoUse {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (RegistryEntities context = new RegistryEntities())
            {
                try
                {
                    context.Tickets.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String DeletePermanently(Decimal Code)
        {
            if (String.IsNullOrEmpty(Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            using (RegistryEntities context = new RegistryEntities())
            {
                try
                {
                    var del = (from item in context.Tickets where (item.Code == Code) select item).FirstOrDefault();
                    context.Tickets.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(Ticket item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Registry].[SPTicketsSelect]" })
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
        public static List<Ticket> Retrieve(Decimal Code, String UniversityCode, Decimal PinCode, Boolean Deleted)
        {
            List<Ticket> objs = new List<Ticket>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(PinCode.ToString()) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (RegistryEntities context = new RegistryEntities())
                    {
                        var item = context.SPTicketsSelect(Code, UniversityCode, PinCode, Deleted).FirstOrDefault();
                        Ticket items = new Ticket
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            ScreenCode = item.ScreenCode,
                            SessionCode = item.SessionCode,
                            SemesterCode = item.SemesterCode,
                            PinCode = item.PinCode,
                            DateX = item.DateX,
                            StatusCode = item.StatusCode,
                            NoOfUse = item.NoOfUse,
                            MaxNoUse = item.MaxNoUse,
                            ExpiryDate = item.ExpiryDate,
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
                    using (RegistryEntities context = new RegistryEntities())
                    {
                        var items = context.SPTicketsSelect(Code, UniversityCode, PinCode, Deleted);
                        foreach (Ticket item in items)
                        {
                            Ticket x = new Ticket
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                ScreenCode = item.ScreenCode,
                                SessionCode = item.SessionCode,
                                SemesterCode = item.SemesterCode,
                                PinCode = item.PinCode,
                                DateX = item.DateX,
                                StatusCode = item.StatusCode,
                                NoOfUse = item.NoOfUse,
                                MaxNoUse = item.MaxNoUse,
                                ExpiryDate = item.ExpiryDate,
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
                return new List<Ticket>();
            }
        }
    }
}
