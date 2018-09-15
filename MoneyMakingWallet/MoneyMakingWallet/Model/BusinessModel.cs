using System;
using System.Collections.Generic;
using System.Text;

namespace IDMONEY.IO.Model
{
    public class BusinessModel : Business
    {

    }

    public class Business
    {
        public string Image { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }
    }
}
