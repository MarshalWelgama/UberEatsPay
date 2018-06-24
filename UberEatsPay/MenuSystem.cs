using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace UberEatsPay
{

    class MenuSystem
    {
        private List<LogTime> _logList { get; set; }

        public MenuSystem(List<LogTime> logList)
        {
            _logList = logList;
        }

        public delegate void StatisticHandler(List<LogTime> logList);

        private void _processStatistics(IStatisticsInterface statistics)
        {
            Console.WriteLine(statistics);
        }

        public void Menu1()
        {
            try
            {
                Console.WriteLine("Enter Amount Of Trips: ");
                int tripInput = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Hours Worked (HH:MM:SS): ");
                string hoursInput = Console.ReadLine();
                Console.WriteLine("Enter Total Expenses: ");
                double expensesInput = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Total Earnings: ");
                double earningsInput = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter 'Save' To Confirm");
                string input = Console.ReadLine();
                if (input.ToLower() == "save")
                {
                    Console.Clear();
                    Console.WriteLine("Saved!");
                    _logList.Add(new LogTime(DateTime.Now, tripInput, hoursInput, expensesInput, earningsInput));

                }
                else
                {
                    throw new InvalidConstraintException();
                }

            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Error Occured. Input Has Invalid Format. Log Cancelled");
            }
            catch (InvalidConstraintException)
            {
                Console.Clear();
                Console.WriteLine("Error Occured. Please Enter 'Save' to Confirm. Log Cancelled");
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Error Occured");
                
            }
        }

        public void Menu2()
        {
            Console.WriteLine("ENTER 1 TO VIEW ALL LOGS");
            Console.WriteLine("ENTER 2 TO FOR SPECIFIC DATE");
            Console.WriteLine("ENTER 3 TO VIEW LAST 7 DAYS");
            Console.WriteLine("ENTER 4 TO VIEW MOST RECENT LOG");
            Console.WriteLine("ENTER ANY OTHER KEY TO EXIT");
            var Input2 = Console.ReadLine();
            bool End2 = false;
            while (!End2)
            {
                switch (Input2)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("ALL PREVIOUS LOGS: \n");
                        _logList.AsParallel().ForAll(Console.WriteLine);
                        End2 = true;
                        break;

                    case "2":
                       
                        Console.WriteLine("Please Enter Date: (DD/MM/YYYY)");
                        var dateInput = Console.ReadLine();
                        var resultList = _logList.FindAll(log => log.Date == dateInput);
                        if (resultList.Count <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Error Could Not Find Log. Returning To Menu\n");
                            End2 = true;
                        }
                        else
                        {
                            Console.Write("SEARCH RESULT: \n");
                            resultList.AsParallel().ForAll(Console.WriteLine);
                            Console.WriteLine("DO YOU WANT TO SEARCH AGAIN? Y/N PRESS ANY KET TO EXIT ");
                            var choice = Console.ReadLine();
                            if (choice.ToUpper() != "Y")
                            {
                                Console.Clear();
                                End2 = true;
                            }
                        }
                        
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("LOG ENTRIES FOR PAST 7 DAYS\n");
                        _logList.FindAll(log => DateTime.Parse(log.Date).Day >= (DateTime.Now.Day - 7))
                             .AsParallel()
                             .ForAll(Console.WriteLine);
                        End2 = true;
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("MOST RECENT LOG:\n");
                        Console.WriteLine(_logList[_logList.Count -1]);
                        
                        End2 = true;
                        break;

                    default:
                        Console.Clear();
                        End2 = true;
                        break;
                }
            }
        }

        public void Menu3()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("OVERALL STATISTICS: \n");
                _processStatistics(new TotalTrips(_logList));
                _processStatistics(new TotalHours(_logList));
                _processStatistics(new TotalEarnings(_logList));
                _processStatistics(new TotalExpenses(_logList));
                _processStatistics(new EarningsPerTrip(_logList));
                _processStatistics(new EarningsPerHour(_logList));
                _processStatistics(new MaxEarnings(_logList));
                Console.Write("\n");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("\nsNo Logs Available\n");
                
            }



        }
        public void MainMenu()
        {
            bool End = false;
            while (!End)
            {
                Console.WriteLine("******UBER EATS PAY********");
                Console.WriteLine("ENTER 1 TO LOG WORKING PERIOD");
                Console.WriteLine("ENTER 2 TO VIEW PREVIOUS LOG");
                Console.WriteLine("ENTER 3 TO VIEW TOTAL STATISTICS");
                Console.WriteLine("ENTER ANY OTHER KEY TO TERMINATE PROGRAM AND SAVE DATA");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Menu1();
                        break;
                    case "2":
                        //printing the log
                        Menu2();
                        break;
                    case "3":
                         Menu3();
                        break;
                    default:
                        End = true;
                        break;
                
                }
            }
        }

    }
}
