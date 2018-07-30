using Newtonsoft.Json;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IDMONEY.IO.Model
{
    public class UserModel : RealmObject
    {
        [PrimaryKey]
        public long Id { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        [Ignored]
        public string Address { get; set; }

        [Ignored]
        public string Privatekey { get; set; }

        [Ignored]
        public decimal AvailableBalance { get; set; }

        [Ignored]
        public decimal BlockedBalance { get; set; }
    }
}
