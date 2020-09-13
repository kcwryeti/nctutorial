using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nctutorial 
{ 

    public class Logger : ILogger
    {
        public string m { get; set; }
        public string guid { get; set; }
        public Logger() 
        {
            m = "Empty";
            
        }
        public Logger(string x ) 
        {
            guid = System.Guid.NewGuid().ToString("N");
            m = x;
        }
        public string message() 
        {
            return "dupa";
        }
    }
}
