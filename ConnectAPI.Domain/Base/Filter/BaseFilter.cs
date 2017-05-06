using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAPI.Domain.Base.Filter
{
    public class BaseFilter
    {
        public Conditions Condition { get; set; }
        public string Property { get; set; }
        public dynamic Value { get; set; }

    }
}
