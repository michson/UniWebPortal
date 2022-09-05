﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Finance
{
    [DataObject]
    public static class Messages
    {
        public static String Warning = " must not be empty.";
        public static String Saved = " Record Successfully Saved.";
        public static String Deleted = " Record Successfully Deleted.";
        public static String NotSaved = " Unable to save/update record.";
        public static String NotDeleted = " Unable to delete record.";
    }
}
