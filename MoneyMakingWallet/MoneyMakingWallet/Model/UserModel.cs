using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDMONEY.IO.Model
{
    public class UserModel : RealmObject
    {
        [PrimaryKey]
        public long Id { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class UserRequest : BaseRequest
    {

    }
}
