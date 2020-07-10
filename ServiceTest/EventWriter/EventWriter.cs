namespace ServiceTest.EventWriter
{
    class EventWriter
    {
        public bool WriteLog(string logMessage)
        {

            System.Diagnostics.EventLog eventViewer = new System.Diagnostics.EventLog();


            if (!System.Diagnostics.EventLog.SourceExists("DemoService1Log"))
            {
                System.Diagnostics.EventLog.CreateEventSource("DemoService1Log", "TestLog");
            }

            eventViewer.Source = "DemoService1Log";
            eventViewer.Log = "TestLog";

            eventViewer.WriteEntry(logMessage);

            return true;
        }
    }
}









