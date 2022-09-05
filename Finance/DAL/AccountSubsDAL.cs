using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Finance.DAL
{
    public static class AccountSubsDAL
    {
        public static String Insert(AccountSub item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Description))
                return String.Format("Description {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DescriptionCode))
                return String.Format("DescriptionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ParameterCode))
                return String.Format("ParameterCode {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.AccountSubs.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(AccountSub item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Description))
                return String.Format("Description {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DescriptionCode))
                return String.Format("DescriptionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ParameterCode))
                return String.Format("ParameterCode {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.AccountSubs.AddObject(item);
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
            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    var del = (from item in context.AccountSubs where (item.Code == Code) select item).FirstOrDefault();
                    context.AccountSubs.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static List<AccountSub> Retrieve(Int32 Code, String UniversityCode)
        {
            List<AccountSub> objs = new List<AccountSub>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode))
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var item = context.SPAccountSubSelect(Code, UniversityCode).FirstOrDefault();
                        AccountSub items = new AccountSub
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            Description = item.Description,
                            DescriptionCode = item.DescriptionCode,
                            ParameterCode = item.ParameterCode
                        };
                        objs.Add(items);
                    }
                }
                else
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var items = context.SPAccountSubSelect(Code, UniversityCode);
                        foreach (AccountSub item in items)
                        {
                            AccountSub x = new AccountSub
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                Description = item.Description,
                                DescriptionCode = item.DescriptionCode,
                                ParameterCode = item.ParameterCode
                            };
                            objs.Add(x);
                        }
                    }
                }
                return objs;
            }
            catch
            {
                return new List<AccountSub>();
            }
        }
    }
}
