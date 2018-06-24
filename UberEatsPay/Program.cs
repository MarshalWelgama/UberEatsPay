using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UberEatsPay
{
    class Program
    {
        static void LoadData(string fileName, List<LogTime> listOfLogs)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var streamReader = new StreamReader(fileStream);
            int nLogs = Convert.ToInt32(streamReader.ReadLine());
            for (int i = 0; i < nLogs; i++)
            {
                var logTime = new LogTime(streamReader);
                listOfLogs.Add(logTime);
            }
            streamReader.Close();
        }

        static void WriteData(string fileName, List<LogTime> listOfLogs)
        {
            var fileSteam = new FileStream(fileName, FileMode.Open, FileAccess.Write);
            var streamWriter = new StreamWriter(fileSteam);
            streamWriter.WriteLine(listOfLogs.Count);
            foreach (var logs in listOfLogs)
            {
                logs.WriteData(streamWriter);
            }
            streamWriter.Close();
        }

        static void Main(string[] args)
        {
            string fileName = "Logs.txt";
            var listOfLogs = new List<LogTime>();


            LoadData(fileName,listOfLogs);

            new MenuSystem(listOfLogs).MainMenu();


            WriteData(fileName, listOfLogs);



            // SAVE IF THEY EXIT APPLICATION
        }
    }
}
