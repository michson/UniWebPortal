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
    public static class AreasOfSpecializationsDAL
    {
        public static String Insert(AreasOfSpecialization item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DescriptionsCode))
                return String.Format("DescriptionsCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Specialization))
                return String.Format("Specialization {0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.AreasOfSpecializations.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(AreasOfSpecialization item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DescriptionsCode))
                return String.Format("DescriptionsCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Specialization))
                return String.Format("Specialization {0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.AreasOfSpecializations.AddObject(item);
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
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    var del = (from item in context.AreasOfSpecializations where (item.Code == Code) select item).FirstOrDefault();
                    context.AreasOfSpecializations.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static List<AreasOfSpecialization> Retrieve(Int32 Code, String DescriptionsCode)
        {
            List<AreasOfSpecialization> objs = new List<AreasOfSpecialization>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & (!String.IsNullOrEmpty(DescriptionsCode)))
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var item = context.SPAreasOfSpecializationsSelect(Code, DescriptionsCode).FirstOrDefault();
                        AreasOfSpecialization items = new AreasOfSpecialization
                        {
                            Code = item.Code,
                            DescriptionsCode = item.DescriptionsCode,
                            Specialization = item.Specialization
                        };
                        objs.Add(items);
                    }
                }
                else
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var items = context.SPAreasOfSpecializationsSelect(Code, DescriptionsCode);
                        foreach (AreasOfSpecialization item in items)
                        {
                            AreasOfSpecialization x = new AreasOfSpecialization
                            {
                                Code = item.Code,
                                DescriptionsCode = item.DescriptionsCode,
                                Specialization = item.Specialization
                            };
                            objs.Add(x);
                        }
                    }
                }
                return objs;
            }
            catch
            {
                return new List<AreasOfSpecialization>();
            }
        }
    }
}
