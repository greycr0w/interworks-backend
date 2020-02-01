using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Interworks.API.Helpers
{
    public class Smtp {
        
        public string server { get; set; }
        
        public string user { get; set; }
        
        public string port { get; set; }
        
        public string pass { get; set; }
        
        public string from { get; set; }
    }
    public class AppSettings {
        public string secret { get; set; }

        public string database { get; set; }
         
        public Smtp smtp { get; set; }
    }
}