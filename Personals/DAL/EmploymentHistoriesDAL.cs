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
    public static class EmploymentHistoriesDAL
    {
        public static String Insert(EmploymentHistory item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TitleCode))
                return String.Format("TitleCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.JobCategoryCode))
                return String.Format("JobCategoryCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.JobDescCode))
                return String.Format("JobDescCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LevelOfXpertiseCode))
                return String.Format("LevelOfXpertiseCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.WorkPercentageCode))
                return String.Format("WorkPercentageCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromYearCode))
                return String.Format("FromYearCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ToYearCode))
                return String.Format("ToYearCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromMonthCode))
                return String.Format("FromMonthCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ToMonthCode))
                return String.Format("ToMonthCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromSAS))
                return String.Format("FromSAS {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromSASCurrencyCode))
                return String.Format("FromSASCurrencyCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromSASTotals.ToString()))
                return String.Format("FromSASTotals {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromEAS))
                return String.Format("FromEAS {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromEASCurrencyCode))
                return String.Format("FromEASCurrencyCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromEASTotals.ToString()))
                return String.Format("FromEASTotals {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Supervisor))
                return String.Format("Supervisor {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SupervisorTitle))
                return String.Format("SupervisorTitle {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Employer))
                return String.Format("Employer {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EmployerAddress))
                return String.Format("EmployerAddress {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EmployerBusinessNatureCode))
                return String.Format("EmployerBusinessNatureCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EmployerURL))
                return String.Format("EmployerURL {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DutiesDescription))
                return String.Format("DutiesDescription {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.KeyAchievements))
                return String.Format("KeyAchievements {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ContactRefrenceCode))
                return String.Format("ContactRefrenceCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfPeopleSupervised.ToString()))
                return String.Format("NoOfPeopleSupervised {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ReasonForLeaving))
                return String.Format("ReasonForLeaving {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedOn.ToString()))
                return String.Format("CreatedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CreatedBy))
                return String.Format("CreatedBy {0}", Messages.Warning);

            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    context.EmploymentHistories.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(EmploymentHistory item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.TitleCode))
                return String.Format("TitleCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.JobCategoryCode))
                return String.Format("JobCategoryCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.JobDescCode))
                return String.Format("JobDescCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LevelOfXpertiseCode))
                return String.Format("LevelOfXpertiseCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.WorkPercentageCode))
                return String.Format("WorkPercentageCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromYearCode))
                return String.Format("FromYearCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ToYearCode))
                return String.Format("ToYearCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromMonthCode))
                return String.Format("FromMonthCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ToMonthCode))
                return String.Format("ToMonthCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromSAS))
                return String.Format("FromSAS {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromSASCurrencyCode))
                return String.Format("FromSASCurrencyCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromSASTotals.ToString()))
                return String.Format("FromSASTotals {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromEAS))
                return String.Format("FromEAS {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromEASCurrencyCode))
                return String.Format("FromEASCurrencyCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FromEASTotals.ToString()))
                return String.Format("FromEASTotals {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Supervisor))
                return String.Format("Supervisor {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SupervisorTitle))
                return String.Format("SupervisorTitle {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Employer))
                return String.Format("Employer {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EmployerAddress))
                return String.Format("EmployerAddress {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EmployerBusinessNatureCode))
                return String.Format("EmployerBusinessNatureCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EmployerURL))
                return String.Format("EmployerURL {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DutiesDescription))
                return String.Format("DutiesDescription {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.KeyAchievements))
                return String.Format("KeyAchievements {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ContactRefrenceCode))
                return String.Format("ContactRefrenceCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.NoOfPeopleSupervised.ToString()))
                return String.Format("NoOfPeopleSupervised {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ReasonForLeaving))
                return String.Format("ReasonForLeaving {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedOn.ToString()))
                return String.Format("ModifiedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ModifiedBy))
                return String.Format("ModifiedBy {0}", Messages.Warning);

            using (PersonalEntities context = new PersonalEntities())
            {
                try
                {
                    context.EmploymentHistories.AddObject(item);
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
                    var del = (from item in context.EmploymentHistories where (item.Code == Code) select item).FirstOrDefault();
                    context.EmploymentHistories.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static String Delete(EmploymentHistory item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code{0}", Messages.Warning);
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = con, CommandType = CommandType.StoredProcedure, CommandText = "[Personals].[SPEmploymentHistoriesDelete]" })
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
        public static List<EmploymentHistory> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            List<EmploymentHistory> objs = new List<EmploymentHistory>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(AccountCode) & !String.IsNullOrEmpty(ScreenCode) & !String.IsNullOrEmpty(Deleted.ToString()))
                {
                    using (PersonalEntities context = new PersonalEntities())
                    {
                        var item = context.SPEmploymentHistoriesSelect(Code, AccountCode, ScreenCode, Deleted).FirstOrDefault();
                        EmploymentHistory items = new EmploymentHistory
                        {
                            Code = item.Code,
                            AccountCode = item.AccountCode,
                            ScreenCode = item.ScreenCode,
                            TitleCode = item.TitleCode,
                            JobCategoryCode = item.JobCategoryCode,
                            JobDescCode = item.JobDescCode,
                            LevelOfXpertiseCode = item.LevelOfXpertiseCode,
                            WorkPercentageCode = item.WorkPercentageCode,
                            FromYearCode = item.FromYearCode,
                            ToYearCode = item.ToYearCode,
                            FromMonthCode = item.FromMonthCode,
                            ToMonthCode = item.ToMonthCode,
                            FromSAS = item.FromSAS,
                            FromSASCurrencyCode = item.FromSASCurrencyCode,
                            FromSASTotals = item.FromSASTotals,
                            FromEAS = item.FromEAS,
                            FromEASCurrencyCode = item.FromEASCurrencyCode,
                            FromEASTotals = item.FromEASTotals,
                            Supervisor = item.Supervisor,
                            SupervisorTitle = item.SupervisorTitle,
                            Employer = item.Employer,
                            EmployerAddress = item.EmployerAddress,
                            EmployerBusinessNatureCode = item.EmployerBusinessNatureCode,
                            EmployerURL = item.EmployerURL,
                            DutiesDescription = item.DutiesDescription,
                            KeyAchievements = item.KeyAchievements,
                            ContactRefrenceCode = item.ContactRefrenceCode,
                            NoOfPeopleSupervised = item.NoOfPeopleSupervised,
                            ReasonForLeaving = item.ReasonForLeaving,
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
                        var items = context.SPEmploymentHistoriesSelect(Code, AccountCode, ScreenCode, Deleted);
                        foreach (EmploymentHistory item in items)
                        {
                            EmploymentHistory x = new EmploymentHistory
                            {
                                Code = item.Code,
                                AccountCode = item.AccountCode,
                                ScreenCode = item.ScreenCode,
                                TitleCode = item.TitleCode,
                                JobCategoryCode = item.JobCategoryCode,
                                JobDescCode = item.JobDescCode,
                                LevelOfXpertiseCode = item.LevelOfXpertiseCode,
                                WorkPercentageCode = item.WorkPercentageCode,
                                FromYearCode = item.FromYearCode,
                                ToYearCode = item.ToYearCode,
                                FromMonthCode = item.FromMonthCode,
                                ToMonthCode = item.ToMonthCode,
                                FromSAS = item.FromSAS,
                                FromSASCurrencyCode = item.FromSASCurrencyCode,
                                FromSASTotals = item.FromSASTotals,
                                FromEAS = item.FromEAS,
                                FromEASCurrencyCode = item.FromEASCurrencyCode,
                                FromEASTotals = item.FromEASTotals,
                                Supervisor = item.Supervisor,
                                SupervisorTitle = item.SupervisorTitle,
                                Employer = item.Employer,
                                EmployerAddress = item.EmployerAddress,
                                EmployerBusinessNatureCode = item.EmployerBusinessNatureCode,
                                EmployerURL = item.EmployerURL,
                                DutiesDescription = item.DutiesDescription,
                                KeyAchievements = item.KeyAchievements,
                                ContactRefrenceCode = item.ContactRefrenceCode,
                                NoOfPeopleSupervised = item.NoOfPeopleSupervised,
                                ReasonForLeaving = item.ReasonForLeaving,
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
                return new List<EmploymentHistory>();
            }
        }
    }
}
