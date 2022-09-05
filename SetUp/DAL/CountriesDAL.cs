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
    public static class CountriesDAL
    {
        public static String Insert(Country item)
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Name))
                return String.Format("Name {0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try 
                {
                    context.Countries.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch(Exception ex) 
                {
                    return String.Format("{0}:\n{1}",ex.Message,Messages.NotSaved);
                }
            }
        }
        public static String Update(Country item)
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Name))
                return String.Format("Name {0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Countries.AddObject(item);
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
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    var del = (from item in context.Countries where (item.Code == Code) select item).FirstOrDefault();
                    context.Countries.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static List<Country> Retrieve(String Code) 
        {
            List<Country> objs = new List<Country>();
            try 
            {
                if (!String.IsNullOrEmpty(Code))
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var item = context.SPCountriesSelect(Code).FirstOrDefault();
                        Country items = new Country 
                        {
                            Code=item.Code,
                            Name=item.Name
                        };
                        objs.Add(items);
                    }
                }
                else
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var items = context.SPCountriesSelect(Code);
                        foreach(Country item in items)
                        {
                            Country x = new Country
                            {
                                Code = item.Code,
                                Name = item.Name
                            };
                            objs.Add(x);
                        }
                    }
                }
                return objs;
            }
            catch 
            {
                return new List<Country>();
            }
        }
    }
}
