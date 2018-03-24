using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterApp.Enums
{
    public enum Status
    {
        SentIn = 0,
        UnderInvestigation = 1,
        NeedMoreInfo = 2,
        Refused = 3,
        Accepted = 4,
        Cancelled = 5
    }
}
