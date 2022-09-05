using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Personals;
using Personals.DAL;
using System.ComponentModel;

namespace Personals.BLL
{
    [DataObject]
    public static class ComputerSkillsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(ComputerSkill item)
        {
            return ComputerSkillsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(ComputerSkill item)
        {
            return ComputerSkillsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int32 Code)
        {
            return ComputerSkillsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(ComputerSkill item)
        {
            return ComputerSkillsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<ComputerSkill> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            return ComputerSkillsDAL.Retrieve(Code, AccountCode, ScreenCode, Deleted);
        }
    }
}
