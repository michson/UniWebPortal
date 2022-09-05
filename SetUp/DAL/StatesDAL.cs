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
    public static class StatesDAL
    {
        public static String Insert(State item)
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code{0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Name))
                return String.Format("Name{0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CountriesCode))
                return String.Format("CountriesCode{0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try 
                {
                    context.States.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch(Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(State item)
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code{0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Name))
                return String.Format("Name{0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CountriesCode))
                return String.Format("CountriesCode{0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try 
                {
                    context.States.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String DeletePermanently(String Code, String CountriesCode) 
        {
            if (String.IsNullOrEmpty(Code))
                return String.Format("Code{0}", Messages.Warning);
            else if (String.IsNullOrEmpty(CountriesCode))
                return String.Format("CountriesCode{0}", Messages.Warning);
            using (SetUpEntities context= new SetUpEntities())
            {
                try
                {
                    var del= (from item in context.States where ((item.Code == Code) && (item.CountriesCode == CountriesCode)) select item).FirstOrDefault();
                    context.States.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static List<State> Retrieve(String Code, String CountriesCode) 
        {
            List<State> objs = new List<State>();
            try
            {
                if (!String.IsNullOrEmpty(Code) & !String.IsNullOrEmpty(CountriesCode))
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var item = context.SPStatesSelect(Code, CountriesCode).FirstOrDefault();
                        State items = new State
                        {
                            Code = item.Code,
                            Name = item.Name,
                            CountriesCode = item.CountriesCode
                        };
                        objs.Add(items);
                    }
                }
                else 
                {
                    using(SetUpEntities context= new SetUpEntities())
                    {
                        var items = context.SPStatesSelect(Code, CountriesCode);
                        foreach(State item in items)
                        {
                            State x = new State
                            {
                                Code = item.Code,
                                Name = item.Name,
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
                return new List<State>();
            }
        }

    }
}
