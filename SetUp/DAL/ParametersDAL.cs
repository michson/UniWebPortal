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
    public static class ParametersDAL
    {
        public static String Insert(Parameter item)
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Description))
                return String.Format("Description {0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Parameters.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Parameter item)
        {
            if (String.IsNullOrEmpty(item.Code))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Description))
                return String.Format("Description {0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Parameters.AddObject(item);
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
                    var del = (from item in context.Parameters where (item.Code == Code) select item).FirstOrDefault();
                    context.Parameters.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static List<Parameter> Retrieve(String Code) 
        {
            List<Parameter> objs = new List<Parameter>();
            try 
            {
                if (!String.IsNullOrEmpty(Code))
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var item = context.SPParametersSelect(Code).FirstOrDefault();
                        Parameter items = new Parameter
                        {
                            Code = item.Code,
                            Description = item.Description
                        };
                        objs.Add(item);
                    }
                }
                else 
                {
                    using (SetUpEntities context = new SetUpEntities()) 
                    {
                        var items = context.SPParametersSelect(Code);
                        foreach (Parameter item in items) 
                        {
                            Parameter x = new Parameter
                            {
                                Code = item.Code,
                                Description = item.Description
                            };
                            objs.Add(x);
                        }
                    }
                }
                return objs;
            }
            catch 
            {
                return new List<Parameter>();
            }
        }
    }
}
