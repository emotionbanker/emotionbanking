using System.IO;
using System.Linq;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;

namespace Compucare.Enquire.Common.Tools.Logging
{
    public class LogHelper
    {
        private const string CONFIGURATION = @"
        <log4net>
  
          <appender name='RollingFile' type='log4net.Appender.RollingFileAppender'>
    
            <file value='logs/Enquire.log' />
            <appendToFile value='true' />
            <maximumFileSize value='5MB' />
            <maxSizeRollBackups value='5' />

            <layout type='log4net.Layout.PatternLayout'>
              <conversionPattern value='%date [%thread] %level - %message%newline' />
            </layout>
    
          </appender>

          <root>
            <level value='DEBUG' />
            <appender-ref ref='RollingFile' />
          </root>
  
        </log4net>";

        private static bool _configured;

        public static ILog GetLogger()
        {
            if (!_configured)
            {
                Configure();
            }

            return LogManager.GetLogger(typeof (LogHelper));
        }

        public static string GetLogfilePath()
        {
            if (!_configured)
            {
                Configure();
            }

            var rootAppender = ((Hierarchy)LogManager.GetRepository()).Root.Appenders.OfType<RollingFileAppender>().FirstOrDefault();
            return  rootAppender != null ? rootAppender.File : string.Empty;
        }

        private static void Configure()
        {
            using (Stream s = GenerateStreamFromString(CONFIGURATION))
            {
                XmlConfigurator.Configure(s);    
            }
            
            _configured = true;
        }

        public static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
