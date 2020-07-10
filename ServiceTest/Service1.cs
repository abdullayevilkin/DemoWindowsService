using System.ServiceProcess;

namespace ServiceTest
{
    public partial class Service1 : ServiceBase
    {
        System.Diagnostics.EventLog eventViewer = new System.Diagnostics.EventLog();
        System.Timers.Timer timer = new System.Timers.Timer();

        EventWriter.EventWriter eventWriter = new EventWriter.EventWriter();

        public Service1()
        {
            InitializeComponent();

            if (System.Diagnostics.EventLog.SourceExists("DemoService1Log"))
            {
                System.Diagnostics.EventLog.Delete("TestLog");
                System.Diagnostics.EventLog.DeleteEventSource("DemoService1Log");
            }

            if (!System.Diagnostics.EventLog.SourceExists("DemoService1Log"))
            {
                System.Diagnostics.EventLog.CreateEventSource("DemoService1Log", "TestLog");
            }
        }

        protected override void OnStart(string[] args)
        {
            timer.Interval = 45 * 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
            eventWriter.WriteLog("Service Stopped !1!11!");
            timer.Stop();
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            eventWriter.WriteLog("service started...");
            //timer.Interval = 45 * 1000; // 1sec = 1000 msec;
        }
    }
}
