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
    public static class BioDatasDAL
    {
        public static String Insert(BioData item)
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Surname))
                return String.Format("Surname {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.MiddleName))
                return String.Format("MiddleName {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FirstName))
                return String.Format("FirstName {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.GenderCode))
                return String.Format("GenderCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CivilStatus))
                return String.Format("CivilStatus {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DateOfBirth.ToString()))
                return String.Format("DateOfBirth {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CountryCode))
                return String.Format("CountryCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StateCode))
                return String.Format("StateCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LGACode))
                return String.Format("LGACode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PlaceOfBirth))
                return String.Format("PlaceOfBirth {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Height))
                return String.Format("Height {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Weight))
                return String.Format("Weight {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.HealthStatusCode))
                return String.Format("HealthStatusCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PositionInFamily.ToString()))
                return String.Format("PositionInFamily {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfChildren.ToString()))
                return String.Format("NoOfChildren {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TicketCode.ToString()))
                return String.Format("TicketCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PinCode.ToString()))
                return String.Format("PinCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    context.BioDatas.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(BioData item)
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Surname))
                return String.Format("Surname {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.MiddleName))
                return String.Format("MiddleName {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FirstName))
                return String.Format("FirstName {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.GenderCode))
                return String.Format("GenderCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CivilStatus))
                return String.Format("CivilStatus {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DateOfBirth.ToString()))
                return String.Format("DateOfBirth {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CountryCode))
                return String.Format("CountryCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StateCode))
                return String.Format("StateCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LGACode))
                return String.Format("LGACode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PlaceOfBirth))
                return String.Format("PlaceOfBirth {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Height))
                return String.Format("Height {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Weight))
                return String.Format("Weight {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.HealthStatusCode))
                return String.Format("HealthStatusCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PositionInFamily.ToString()))
                return String.Format("PositionInFamily {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfChildren.ToString()))
                return String.Format("NoOfChildren {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TicketCode.ToString()))
                return String.Format("TicketCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.PinCode.ToString()))
                return String.Format("PinCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    context.BioDatas.AddObject(item);
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
            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    var del = (from item in context.BioDatas where (item.Code == Code) select item).FirstOrDefault();
                    context.BioDatas.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(BioData item)
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Personals].[SPBioDatasDelete]" })
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
        public static List<BioData> Retrieve(String Code, String ScreenCode, Boolean Deleted)
        {
            List<BioData> objs = new List<BioData>();
            try
            {
                if (!String.IsNullOrEmpty(Code) & !String.IsNullOrEmpty(ScreenCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (PersonalEntities context = new PersonalEntities())
                    {
                        var item = context.SPBioDatasSelect(Code, ScreenCode, Deleted).FirstOrDefault();
                        BioData items = new BioData
                        {
                            Code = item.Code,
                            ScreenCode = item.ScreenCode,
                            Surname = item.Surname,
                            MiddleName = item.MiddleName,
                            FirstName = item.FirstName,
                            GenderCode = item.GenderCode,
                            CivilStatus = item.CivilStatus,
                            DateOfBirth = item.DateOfBirth,
                            CountryCode = item.CountryCode,
                            StateCode = item.StateCode,
                            LGACode = item.LGACode,
                            PlaceOfBirth = item.PlaceOfBirth,
                            Height = item.Height,
                            Weight = item.Weight,
                            HealthStatusCode = item.HealthStatusCode,
                            PositionInFamily = item.PositionInFamily,
                            NoOfChildren = item.NoOfChildren,
                            TicketCode = item.TicketCode,
                            PinCode = item.PinCode,
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
                        var items = context.SPBioDatasSelect(Code, ScreenCode, Deleted);
                        foreach (BioData item in items)
                        {
                            BioData x = new BioData
                            {
                                Code = item.Code,
                                ScreenCode = item.ScreenCode,
                                Surname = item.Surname,
                                MiddleName = item.MiddleName,
                                FirstName = item.FirstName,
                                GenderCode = item.GenderCode,
                                CivilStatus = item.CivilStatus,
                                DateOfBirth = item.DateOfBirth,
                                CountryCode = item.CountryCode,
                                StateCode = item.StateCode,
                                LGACode = item.LGACode,
                                PlaceOfBirth = item.PlaceOfBirth,
                                Height = item.Height,
                                Weight = item.Weight,
                                HealthStatusCode = item.HealthStatusCode,
                                PositionInFamily = item.PositionInFamily,
                                NoOfChildren = item.NoOfChildren,
                                TicketCode = item.TicketCode,
                                PinCode = item.PinCode,
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
                return new List<BioData>();
            }
        }
    }
}
