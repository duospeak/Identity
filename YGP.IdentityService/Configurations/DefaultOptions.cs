using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YGP.IdentityService.Configurations
{
    public class DefaultOptions
    {
        public string LogstashUri { get; set; }
        public string ConnectionString { get; set; }
        public string PasswordHashSalt { get; set; }
    }
}
