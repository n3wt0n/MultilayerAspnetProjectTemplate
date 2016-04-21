using $saferootprojectname$.Log;
using System;

namespace $safeprojectname$.Log
{
    public class FakeLogger : ILogger
    {
        public void Info(string message) { }

        public void Warn(string message) { }

        public void Debug(string message) { }

        public void Error(string message) { }

        public void Error(string message, Exception x) { }

        public void Error(Exception x) { }

        public void Fatal(string message) { }

        public void Fatal(Exception x) { }                          
    }
}
