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
    public static class AccountTypesDAL
    {
        public static String Insert(AccountType item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Description))
                return String.Format("Description {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DescriptionCode))
                return String.Format("DescriptionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountSubCode))
                return String.Format("AccountSubCode {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.AccountTypes.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(AccountType item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Description))
                return String.Format("Description {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DescriptionCode))
                return String.Format("DescriptionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountSubCode))
                return String.Format("AccountSubCode {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.AccountTypes.AddObject(item);
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
            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    var del = (from item in context.AccountTypes where (item.Code == Code) select item).FirstOrDefault();
                    context.AccountTypes.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static List<AccountType> Retrieve(Decimal Code, String UniversityCode)
        {
            List<AccountType> objs = new List<AccountType>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode))
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var item = context.SPAccountTypesSelect(Code, UniversityCode).FirstOrDefault();
                        AccountType items = new AccountType
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            Description = item.Description,
                            DescriptionCode = item.DescriptionCode,
                            AccountSubCode = item.AccountSubCode
                        };
                        objs.Add(items);
                    }
                }
                else
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var items = context.SPAccountTypesSelect(Code, UniversityCode);
                        foreach (AccountType item in items)
                        {
                            AccountType x = new AccountType
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                Description = item.Description,
                                DescriptionCode = item.DescriptionCode,
                                AccountSubCode = item.AccountSubCode
                            };
                            objs.Add(x);
                        }
                    }
                }
                return objs;
            }
            catch
            {
                return new List<AccountType>();
            }
        }
    }
}
