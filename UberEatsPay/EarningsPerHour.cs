using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEatsPay
{
    class EarningsPerHour : IStatisticsInterface
    {
        public List<LogTime> LogList { get; }

        public EarningsPerHour(List<LogTime> logList)
        {
            LogList = logList;
        }

       public override string ToString()
        {
            var sumEarnings = LogList.Sum(log => log.NetEarnings);
            var sumHours = LogList.Sum(log => log.Hours.TotalHours);
           
            return string.Format("Total Earnings Per Hour: $" + Math.Round((sumEarnings / sumHours), 2));
        }
    }
}
