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
    public static class LGAsDAL
    {
        public static String Insert(LGA item) 
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code{0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LgName))
                return String.Format("Code{0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StatesCode))
                return String.Format("Code{0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CountriesCode))
                return String.Format("Code{0}", Messages.Warning);
            using (SetUpEntities context= new SetUpEntities()) 
            {
                try 
                {
                    context.LGAs.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }

        }
        public static String Update(LGA item)
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code{0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LgName))
                return String.Format("Code{0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.StatesCode))
                return String.Format("Code{0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CountriesCode))
                return String.Format("Code{0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.LGAs.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }

        }
        public static String DeletePermanently(String Code, String StatesCode, String CountriesCode) 
        {
            if (String.IsNullOrEmpty(Code))
                return String.Format("Code{0}", Messages.Warning);
            else if (String.IsNullOrEmpty(StatesCode))
                return String.Format("Code{0}", Messages.Warning);
            else if (String.IsNullOrEmpty(CountriesCode))
                return String.Format("Code{0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities()) 
            {
                try 
                {
                    var del = (from item in context.LGAs where ((item.Code == Code) && (item.StatesCode == StatesCode) && (item.CountriesCode == CountriesCode)) select item).FirstOrDefault();
                    context.LGAs.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch(Exception ex) 
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static List<LGA> Retrieve(String Code, String StatesCode, String CountriesCode) 
        {
            List<LGA> objs = new List<LGA>();
            try 
            {
                if(!String.IsNullOrEmpty(Code) & (!String.IsNullOrEmpty(StatesCode)) & !String.IsNullOrEmpty(CountriesCode))
                {
                    using (SetUpEntities context= new SetUpEntities())
                    {
                        var item = context.SPLGAsSelect(Code, StatesCode, CountriesCode).FirstOrDefault();
                        LGA items = new LGA
                        {
                            Code = item.Code,
                            LgName = item.LgName,
                            StatesCode = item.StatesCode,
                            CountriesCode = item.CountriesCode
                        };
                        objs.Add(items);
                    }
                }
                else
                {
                    using(SetUpEntities context= new SetUpEntities())
                    {
                        var items = context.SPLGAsSelect(Code, StatesCode, CountriesCode);
                        foreach(LGA item in items)
                        {
                            LGA x = new LGA
                            {
                                Code = item.Code,
                                LgName = item.LgName,
                                StatesCode = item.StatesCode,
                                CountriesCode = item.CountriesCode
                            };
                            objs.Add(x);
                        }
                    }
                }
                return objs;
            }
            catch 
            {
                return new List<LGA>();
            }
        }
    }
}
