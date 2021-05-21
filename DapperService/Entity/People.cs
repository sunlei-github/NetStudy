using System;
using System.Collections.Generic;
using System.Text;

namespace DapperService.Entity
{
    public class People
    {

        public int Id { set; get; }

        public int Old { set; get; }

        public DateTime? Birthday { set; get; }

        public string Name { set; get; }
    }
}
