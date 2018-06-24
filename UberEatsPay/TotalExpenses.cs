using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEatsPay
{
    class TotalExpenses : IStatisticsInterface
    {
        public List<LogTime> LogList { get; }

        public TotalExpenses(List<LogTime> logList)
        {
            LogList = logList;
        }

        public override string ToString()
        {
            var sumExpenses = LogList.Sum(log => log.Expenses);
            return string.Format("Total Expenses: $" + sumExpenses);
        }
    }
}
