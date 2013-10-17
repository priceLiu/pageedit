using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clay
{
    public class Context
    {
       

        private System.Collections.Hashtable mProperties = new System.Collections.Hashtable();

        private static System.Collections.Hashtable mLogers = new System.Collections.Hashtable();

        public object this[object key]
        {
            get
            {
                return mProperties[key];
            }
            set
            {
                mProperties[key] = value;
            }
        }

        [ThreadStatic]
        private static Context mCurrent;
        public static Context Current
        {
            get
            {
                return mCurrent;
            }
            set
            {
                mCurrent = value;
            }
        }

        static Context()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public log4net.ILog GetLog<T>()
        {
            return GetLog_s<T>();
        }

        public static log4net.ILog GetLog_s<T>()
        {
            log4net.ILog log = (log4net.ILog)mLogers[typeof(T)];
            if (log == null)
            {
                log = log4net.LogManager.GetLogger(typeof(T));
                mLogers[typeof(T)] = log;
            }
            return log;
        }

       
    }
}
