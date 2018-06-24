using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEatsPay
{
    class TotalHours : IStatisticsInterface
    {
        public List<LogTime> LogList { get; }

        public TotalHours(List<LogTime> logList)
        {
            LogList = logList;
        }

        
        public override string ToString()
        {
        
            var totalSpan = new TimeSpan(LogList.Sum(log => log.Hours.Ticks));
            return string.Format("Total Hours Worked: {0}:{1}:{2} " , Math.Round(totalSpan.TotalHours), totalSpan.Minutes.ToString("D2"), totalSpan.Seconds.ToString("D2"));
        }

    }

}
