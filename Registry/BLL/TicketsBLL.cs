using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Registry;
using Registry.DAL;
using System.ComponentModel;

namespace Registry.BLL
{
    [DataObject]
    public static class TicketsBLL
    {
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static String Insert(Ticket item)
        {
            return TicketsDAL.Insert(item);
        }
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static String Update(Ticket item)
        {
            return TicketsDAL.Update(item);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static String DeletePermanently(Decimal Code)
        {
            return TicketsDAL.DeletePermanently(Code);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public static String Delete(Ticket item)
        {
            return TicketsDAL.Delete(item);
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<Ticket> Retrieve(Decimal Code, String UniversityCode, Decimal PinCode, Boolean Deleted)
        {
            return TicketsDAL.Retrieve(Code, UniversityCode, PinCode, Deleted);
        }
    }
}
