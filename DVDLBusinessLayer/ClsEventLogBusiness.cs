using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLDataAccessLayer;
namespace DVDLBusinessLayer
{
    public class ClsEventLogBusiness
    {
        public static void InformationEventLog(string details)
        {
            ClsEventLog.InformationEventLog(details);
        }
        public static void ErrorEventLog(string details)
        {
            ClsEventLog.ErrorEventLog(details);
        }
        public static void WarningEventLog(string details)
        {
            ClsEventLog.WarningEventLog(details);
        }
    }
}
