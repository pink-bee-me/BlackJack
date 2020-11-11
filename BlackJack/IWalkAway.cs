using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    interface IWalkAway // .Net supports inheritance of multiple interfaces
    {
        void WalkAway(Player player);//any class that inherits the IWalkAway interface must implement some form of the method WalkAway()
    }
}
