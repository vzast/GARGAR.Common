using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.Settings
{
    public struct EmailSettings
    {
        public string Smtp { get; set; }
        public string SmtpPort { get; set; }
        public string SmtpDomain { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
        public string ReciverEmail { get; set; }
    }
}
