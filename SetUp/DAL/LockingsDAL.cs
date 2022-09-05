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
    public static class LockingsDAL
    {
        public static String Insert(Locking item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FacultyCode.ToString()))
                return String.Format("FacultyCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DepartmentCode.ToString()))
                return String.Format("DepartmentCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CourseCode.ToString()))
                return String.Format("CourseCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ProgramCode.ToString()))
                return String.Format("ProgramCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LevelCode.ToString()))
                return String.Format("LevelCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EntityCode))
                return String.Format("EntityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Locked.ToString()))
                return String.Format("Locked {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LockedOn.ToString()))
                return String.Format("LockedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LockedBy))
                return String.Format("LockedBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UnlockedOn.ToString()))
                return String.Format("UnlockedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UnlockedBy))
                return String.Format("UnlockedBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LastLockedOn.ToString()))
                return String.Format("LastLockedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LastLockedBy))
                return String.Format("LastLockedBy {0}", Messages.Warning);
            
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Lockings.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Locking item)
        {
            if (String.IsNullOrEmpty(item.Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UniversityCode))
                return String.Format("UniversityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.FacultyCode.ToString()))
                return String.Format("FacultyCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.DepartmentCode.ToString()))
                return String.Format("DepartmentCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.CourseCode.ToString()))
                return String.Format("CourseCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ProgramCode.ToString()))
                return String.Format("ProgramCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SessionCode))
                return String.Format("SessionCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.SemesterCode))
                return String.Format("SemesterCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LevelCode.ToString()))
                return String.Format("LevelCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EntityCode))
                return String.Format("EntityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Locked.ToString()))
                return String.Format("Locked {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LockedOn.ToString()))
                return String.Format("LockedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LockedBy))
                return String.Format("LockedBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UnlockedOn.ToString()))
                return String.Format("UnlockedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.UnlockedBy))
                return String.Format("UnlockedBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LastLockedOn.ToString()))
                return String.Format("LastLockedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LastLockedBy))
                return String.Format("LastLockedBy {0}", Messages.Warning);

            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Lockings.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String DeletePermanently(Int64 Code)
        {
            if (String.IsNullOrEmpty(Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    var del = (from item in context.Lockings where (item.Code == Code) select item).FirstOrDefault();
                    context.Lockings.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static List<Locking> Retrieve(Int64 Code, String UniversityCode, String ScreenCode)
        {
            List<Locking> objs = new List<Locking>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode))
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var item = context.SPLockingsSelect(Code, UniversityCode).FirstOrDefault();
                        Locking items = new Locking
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            FacultyCode = item.FacultyCode,
                            DepartmentCode = item.DepartmentCode,
                            CourseCode = item.CourseCode,
                            ProgramCode = item.ProgramCode,
                            SessionCode = item.SessionCode,
                            SemesterCode = item.SemesterCode,
                            LevelCode = item.LevelCode,
                            AccountCode = item.AccountCode,
                            EntityCode = item.EntityCode,
                            Locked = item.Locked,
                            LockedOn = item.LockedOn,
                            LockedBy = item.LockedBy,
                            UnlockedOn = item.UnlockedOn,
                            UnlockedBy = item.UnlockedBy,
                            LastLockedOn = item.LastLockedOn,
                            LastLockedBy = item.LastLockedBy
                            
                        };
                        objs.Add(items);
                    }
                }
                else
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var items = context.SPLockingsSelect(Code, UniversityCode);
                        foreach (Locking item in items)
                        {
                            Locking x = new Locking
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                FacultyCode = item.FacultyCode,
                                DepartmentCode = item.DepartmentCode,
                                CourseCode = item.CourseCode,
                                ProgramCode = item.ProgramCode,
                                SessionCode = item.SessionCode,
                                SemesterCode = item.SemesterCode,
                                LevelCode = item.LevelCode,
                                AccountCode = item.AccountCode,
                                EntityCode = item.EntityCode,
                                Locked = item.Locked,
                                LockedOn = item.LockedOn,
                                LockedBy = item.LockedBy,
                                UnlockedOn = item.UnlockedOn,
                                UnlockedBy = item.UnlockedBy,
                                LastLockedOn = item.LastLockedOn,
                                LastLockedBy = item.LastLockedBy
                            };
                            objs.Add(x);
                        }
                    }
                }
                return objs;
            }
            catch
            {
                return new List<Locking>();
            }
        }
    }
}
