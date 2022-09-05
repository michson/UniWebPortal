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
    public static class ApprovalsDAL
    {
        public static String Insert(Approval item)
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
            else if (String.IsNullOrEmpty(item.ModuleCode))
                return String.Format("ModuleCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LevelCode.ToString()))
                return String.Format("LevelCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RoleCode.ToString()))
                return String.Format("RoleCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EntityCode))
                return String.Format("EntityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApprovalType))
                return String.Format("ApprovalType {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Order.ToString()))
                return String.Format("Order {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Approved.ToString()))
                return String.Format("Approved {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApprovedOn.ToString()))
                return String.Format("ApprovedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApprovedBy))
                return String.Format("ApprovedBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApprovedNotes))
                return String.Format("ApprovedNotes {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Requested.ToString()))
                return String.Format("Requested {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RequestedOn.ToString()))
                return String.Format("RequestedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RequestedBy))
                return String.Format("RequestedBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RequestedNotes))
                return String.Format("RequestedNotes {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Rejected.ToString()))
                return String.Format("Rejected {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RejectedOn.ToString()))
                return String.Format("RejectedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RejectedBy))
                return String.Format("RejectedBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RejectedNotes))
                return String.Format("RejectedNotes {0}", Messages.Warning);

            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Approvals.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String Update(Approval item)
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
            else if (String.IsNullOrEmpty(item.ModuleCode))
                return String.Format("ModuleCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ScreenCode))
                return String.Format("ScreenCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.LevelCode.ToString()))
                return String.Format("LevelCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RoleCode.ToString()))
                return String.Format("RoleCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.EntityCode))
                return String.Format("EntityCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.AccountCode))
                return String.Format("AccountCode {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApprovalType))
                return String.Format("ApprovalType {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Order.ToString()))
                return String.Format("Order {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Approved.ToString()))
                return String.Format("Approved {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApprovedOn.ToString()))
                return String.Format("ApprovedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApprovedBy))
                return String.Format("ApprovedBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.ApprovedNotes))
                return String.Format("ApprovedNotes {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Requested.ToString()))
                return String.Format("Requested {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RequestedOn.ToString()))
                return String.Format("RequestedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RequestedBy))
                return String.Format("RequestedBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RequestedNotes))
                return String.Format("RequestedNotes {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.Rejected.ToString()))
                return String.Format("Rejected {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RejectedOn.ToString()))
                return String.Format("RejectedOn {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RejectedBy))
                return String.Format("RejectedBy {0}", Messages.Warning);
            else if (String.IsNullOrEmpty(item.RejectedNotes))
                return String.Format("RejectedNotes {0}", Messages.Warning);

            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    context.Approvals.AddObject(item);
                    context.SaveChanges();
                    return Messages.Saved;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotSaved);
                }
            }
        }
        public static String DeletePermanently(Guid Code)
        {
            if (String.IsNullOrEmpty(Code.ToString()))
                return String.Format("Code {0}", Messages.Warning);
            using (SetUpEntities context = new SetUpEntities())
            {
                try
                {
                    var del = (from item in context.Approvals where (item.Code == Code) select item).FirstOrDefault();
                    context.Approvals.DeleteObject(del);
                    context.SaveChanges();
                    return Messages.Deleted;
                }
                catch (Exception ex)
                {
                    return String.Format("{0}:\n{1}", ex.Message, Messages.NotDeleted);
                }
            }
        }
        public static List<Approval> Retrieve(Guid Code, String UniversityCode, String ScreenCode)
        {
            List<Approval> objs = new List<Approval>();
            try
            {
                if (!String.IsNullOrEmpty(Code.ToString()) & !String.IsNullOrEmpty(UniversityCode) & !String.IsNullOrEmpty(ScreenCode))
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var item = context.SPApprovalsSelect(Code, UniversityCode, ScreenCode).FirstOrDefault();
                        Approval items = new Approval
                        {
                            Code = item.Code,
                            UniversityCode = item.UniversityCode,
                            FacultyCode = item.FacultyCode,
                            DepartmentCode = item.DepartmentCode,
                            CourseCode = item.CourseCode,
                            ProgramCode = item.ProgramCode,
                            SessionCode = item.SessionCode,
                            ModuleCode = item.ModuleCode,
                            ScreenCode = item.ScreenCode,
                            SemesterCode = item.SemesterCode,
                            LevelCode = item.LevelCode,
                            RoleCode = item.RoleCode,
                            AccountCode = item.AccountCode,
                            EntityCode = item.EntityCode,
                            ApprovalType = item.ApprovalType,
                            Order = item.Order,
                            Approved = item.Approved,
                            ApprovedOn = item.ApprovedOn,
                            ApprovedBy = item.ApprovedBy,
                            ApprovedNotes = item.ApprovedNotes,
                            Requested = item.Requested,
                            RequestedOn = item.RequestedOn,
                            RequestedBy = item.RequestedBy,
                            RequestedNotes = item.RequestedNotes,
                            Rejected = item.Rejected,
                            RejectedOn = item.RejectedOn,
                            RejectedBy = item.RejectedBy,
                            RejectedNotes = item.RejectedNotes

                        };
                        objs.Add(items);
                    }
                }
                else
                {
                    using (SetUpEntities context = new SetUpEntities())
                    {
                        var items = context.SPApprovalsSelect(Code, UniversityCode , ScreenCode);
                        foreach (Approval item in items)
                        {
                            Approval x = new Approval
                            {
                                Code = item.Code,
                                UniversityCode = item.UniversityCode,
                                FacultyCode = item.FacultyCode,
                                DepartmentCode = item.DepartmentCode,
                                CourseCode = item.CourseCode,
                                ProgramCode = item.ProgramCode,
                                SessionCode = item.SessionCode,
                                ModuleCode = item.ModuleCode,
                                ScreenCode = item.ScreenCode,
                                SemesterCode = item.SemesterCode,
                                LevelCode = item.LevelCode,
                                RoleCode = item.RoleCode,
                                AccountCode = item.AccountCode,
                                EntityCode = item.EntityCode,
                                ApprovalType = item.ApprovalType,
                                Order = item.Order,
                                Approved = item.Approved,
                                ApprovedOn = item.ApprovedOn,
                                ApprovedBy = item.ApprovedBy,
                                ApprovedNotes = item.ApprovedNotes,
                                Requested = item.Requested,
                                RequestedOn = item.RequestedOn,
                                RequestedBy = item.RequestedBy,
                                RequestedNotes = item.RequestedNotes,
                                Rejected = item.Rejected,
                                RejectedOn = item.RejectedOn,
                                RejectedBy = item.RejectedBy,
                                RejectedNotes = item.RejectedNotes
                            };
                            objs.Add(x);
                        }
                    }
                }
                return objs;
            }
            catch
            {
                return new List<Approval>();
            }
        }
    }
}
