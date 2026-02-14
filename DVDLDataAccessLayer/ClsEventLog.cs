using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLDataAccessLayer
{
    public class ClsEventLog
    {
        public static void InformationEventLog(string details)
        {
            // Specify the source name for the event log
            string sourceName = "DVLD";

            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            // Log an information event
            EventLog.WriteEntry(sourceName, details, EventLogEntryType.Information);
        }
        public static void ErrorEventLog(string details)
        {
            // Specify the source name for the event log
            string sourceName = "DVLD";

            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            // Log an information event
            EventLog.WriteEntry(sourceName, details, EventLogEntryType.Error);
        }
        public static void WarningEventLog(string details)
        {
            // Specify the source name for the event log
            string sourceName = "DVLD";

            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            // Log an information event
            EventLog.WriteEntry(sourceName, details, EventLogEntryType.Warning);
        }
    }
}
