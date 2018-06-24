using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEatsPay
{
    class TotalEarnings : IStatisticsInterface
    {
        public List<LogTime> LogList { get; }

        public TotalEarnings(List<LogTime> logList)
        {
            LogList = logList;
        }

        public override string ToString()
        {
            var SumEarnings = LogList.Sum(log => log.NetEarnings);
            return string.Format("Total Earnings: $" + SumEarnings);
        }
    }
}
