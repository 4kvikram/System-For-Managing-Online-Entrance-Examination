using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEntranceRegistration.Static
{
    public class EmailModel
    {
        public string BCC { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string CC { get; set; }
    }
}