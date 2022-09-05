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
    public static class LanguageSkillsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(LanguageSkill item)
        {
            return LanguageSkillsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(LanguageSkill item)
        {
            return LanguageSkillsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Int32 Code)
        {
            return LanguageSkillsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(LanguageSkill item)
        {
            return LanguageSkillsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<LanguageSkill> Retrieve(Int32 Code, String AccountCode, String ScreenCode, Boolean Deleted)
        {
            return LanguageSkillsDAL.Retrieve(Code, AccountCode, ScreenCode, Deleted);
        }
    }
}
