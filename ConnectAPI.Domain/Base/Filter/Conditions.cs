using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectAPI.Domain.Base.Filter
{
    public enum Conditions
    {
        Equals = 0,
        Contains = 1,
        NotContains = 2,
        GreaterThanOrEqual = 3,
        GreaterThan = 4,
        LessThanOrEqual = 5,
        LessThan = 6,
        StartsWith = 7,
        EndsWith = 8,
        NotEquals = 9,
        IsNull = 10,
        IsNotNull = 11
    }
}
