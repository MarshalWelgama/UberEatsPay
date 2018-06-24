using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEatsPay
{
    class EarningsPerTrip : IStatisticsInterface
    {
        public List<LogTime> LogList { get; }

        public EarningsPerTrip(List<LogTime> logList)
        {
            LogList = logList;
        }

        public override string ToString()
        {
            var earnings = LogList.Sum(log => log.NetEarnings);
            var trips = LogList.Sum(log => log.Trips);
            return string.Format("Total Earnings Per Trip: $" + Math.Round((earnings / trips), 2));
        }
    }
}
