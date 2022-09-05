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
    public static class DescriptionsDAL
    {
        public static String Insert(Description item)
        {
            if (String.IsNullOrEmpty(item.ParametersCode))
                return String.Format("ParametersCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Name))
                return String.Format("Name {0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Descriptions.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Description item)
        {
            if (String.IsNullOrEmpty(item.ID.ToString()))
                return String.Format("ID {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ParametersCode))
                return String.Format("ParametersCode {0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Descriptions.AddObject(item);
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
                    var del = (from item in context.Descriptions where (item.Code == Code) select item).FirstOrDefault();
                    context.Descriptions.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static List<Description> Retrieve(String Code, String ParametersCode)
        {
            List<Description> objs = new List<Description>();
            try
            {
                if (!String.IsNullOrEmpty(Code) &! String.IsNullOrEmpty(ParametersCode))
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var item = context.SPDescriptionsSelect(Code, ParametersCode).FirstOrDefault();
                        Description items = new Description
                        {
                            ID = item.ID,
                            Notes = item.Notes,
                            Code = item.Code,
                            ParametersCode = item.ParametersCode,
                            Name = item.Name
                        };
                        objs.Add(items);
                    }
                }
                else
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var items = context.SPDescriptionsSelect(Code, ParametersCode);
                        foreach (Description item in items)
                        {
                            Description x = new Description
                            {
                                ID = item.ID,
                                Notes = item.Notes,
                                Code = item.Code,
                                ParametersCode = item.ParametersCode,
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
                return new List<Description>();
            }
        }
    }
}
