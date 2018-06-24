using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEatsPay
{
    class MaxEarnings : IStatisticsInterface
    {
        public List<LogTime> LogList { get; }

        public MaxEarnings(List<LogTime> logList)
        {
            LogList = logList;
        }

        public override string ToString()
        {
            var result = LogList.Max(log => log.NetEarnings);
            return string.Format("Max Net Earnings: $" + result);
        }
    }
}
