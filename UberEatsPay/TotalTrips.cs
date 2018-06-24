using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEatsPay
{
    class TotalTrips : IStatisticsInterface
    {
        public List<LogTime> LogList { get; }
        public TotalTrips(List<LogTime> logList)
        {
            LogList = logList;
        }

        public override string ToString()
        {
            return string.Format("Total Trips: " + LogList.Sum(log => log.Trips));
        }

       
    }
}
