using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEatsPay
{
    interface IStatisticsInterface
    {
        List<LogTime> LogList
        {
            get;
        }

    }
}
