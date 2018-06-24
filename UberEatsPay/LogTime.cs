using System;
using System.Globalization;
using System.IO;

namespace UberEatsPay
{
    public class LogTime
    {

        public TimeSpan Hours { get; set; }
        public double Expenses { get; set; }
        public double NetEarnings { get; set; }
        public int Trips { get; set; }
        private double _earnings { get;}
        public string Date { get; }
        private double _perHour { get; }

        public LogTime(DateTime date, int trips, string hours, double expenses, double earnings)
        {
            Date = date.ToShortDateString(); //DateTime has a time. So to bypass had to make it string
            Trips = trips;
            Hours = TimeSpan.ParseExact(hours, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            _earnings = earnings;
            Expenses = expenses;
            NetEarnings = _earnings - Expenses;
            _perHour = NetEarnings / Hours.TotalHours;
        }

        public LogTime(StreamReader sr)
        {
            Date = sr.ReadLine();
            Trips = Convert.ToInt32(sr.ReadLine());
            Hours = TimeSpan.ParseExact(sr.ReadLine(), "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            Expenses = Convert.ToDouble(sr.ReadLine());
            NetEarnings = Convert.ToDouble(sr.ReadLine());
            
        }

        public void WriteData(StreamWriter sw)
        {
            sw.WriteLine(Date);
            sw.WriteLine(Trips);
            sw.WriteLine(Hours);
            sw.WriteLine(Expenses);
            sw.WriteLine(NetEarnings);
        }
        public override string ToString()
        {
            return string.Format(
                "Date: {0}\nAmount of trips: {1}\nHours Worked: {2}\nTotal Expenses: ${3}\nAmount Earned: ${4}\nAmount Per Hour: ${5}\n", Date,
                Trips, Hours, Expenses, NetEarnings, _perHour);
        }
    }
}