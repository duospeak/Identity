using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YGP.IdentityService.Configurations
{
    public class ClientOptions
    {
        public Client Mall { get; set; }

        public Client Erp { get; set; }

        public Client Mes { get; set; }

        public Client Wms { get; set; }

        public class Client
        {
            public string ClientId { get; set; }

            public string ClientSecrets { get; set; }
        }
    }
}
