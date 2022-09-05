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
    public static class AccountsDAL
    {
        public static String Insert(Account item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Description))
                return String.Format("Description {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountTypeCode.ToString()))
                return String.Format("AccountTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountSubCode.ToString()))
                return String.Format("AccountSubCode {0}", Messages.Warning);
            
            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.Accounts.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Account item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Description))
                return String.Format("Description {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountTypeCode.ToString()))
                return String.Format("AccountTypeCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountSubCode.ToString()))
                return String.Format("AccountSubCode {0}", Messages.Warning);

            using (FinanceEntities context = new FinanceEntities())
            {
                try
                {
                    context.Accounts.AddObject(item);
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
                    var del = (from item in context.Accounts where (item.Code == Code) select item).FirstOrDefault();
                    context.Accounts.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static List<Account> Retrieve(Decimal Code, String UniversityCode)
        {
            List<Account> objs = new List<Account>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode))
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var item = context.SPAccountsSelect(Code, UniversityCode).FirstOrDefault();
                        Account items = new Account
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            Description = item.Description,
                            AccountTypeCode = item.AccountTypeCode,
                            AccountSubCode = item.AccountSubCode
                        };
                        objs.Add(items);
                    }
                }
                else
                {
                    using (FinanceEntities context = new FinanceEntities())
                    {
                        var items = context.SPAccountsSelect(Code, UniversityCode);
                        foreach (Account item in items)
                        {
                            Account x = new Account
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                Description = item.Description,
                                AccountTypeCode = item.AccountTypeCode,
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
                return new List<Account>();
            }
        }
    }
}
