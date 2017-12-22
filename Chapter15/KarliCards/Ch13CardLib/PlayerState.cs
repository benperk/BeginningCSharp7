using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13CardLib
{
    [Serializable]
    public enum PlayerState
    {
        Inactive,
        Active,
        MustDiscard,
        Winner,
        Loser
    }

}
