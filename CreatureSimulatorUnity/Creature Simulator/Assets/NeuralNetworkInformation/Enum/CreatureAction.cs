using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkInformation.Enum
{
    public enum CreatureAction
    {
        // POSITIVE ON Y AXIS
        MOVE_FORWARD,

        // NEGATIVE ON Y AXIS
        MOVE_BACKWARD,

        // NEGATIVE ON X AXIS
        MOVE_LEFT,

        // POSITIVE ON X AXIS
        MOVE_RIGHT,

        NONE
    }
}
