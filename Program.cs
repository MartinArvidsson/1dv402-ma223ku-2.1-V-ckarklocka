using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVäckarklocka
{
    class Program
    {
        private static string Line = "\n|===================================|";
        static void Main(string[] args)
        {
            Alarmclock test_1 = new Alarmclock();
            WatchTestHeader("\n test_1\nTest av standardkonstruktorn");
            Console.WriteLine(test_1.ToString());

            Alarmclock test_2 = new Alarmclock(9,42);
            WatchTestHeader("\n test_2\nTest av konstruktorn med två parametrar<9,42>");
            Console.WriteLine(test_1.ToString());

            Alarmclock test_3 = new Alarmclock(13,24,7,35);
            WatchTestHeader("\n test_3\nTest av konstruktorn med fyra parametrar <13,24,7,35>");
            Console.WriteLine(test_1.ToString());

            Alarmclock test_4 = new Alarmclock(23,58,7,35);
            WatchTestHeader("\n test_4\nStäller befintiligt Alarmclock-Objekt till 23:58 och låter den gå i 13 min. ");
            Console.WriteLine(test_1.ToString());

            Alarmclock test_5 = new Alarmclock(6,12,6,15);
            WatchTestHeader("\n test_5\nStäller befintligt Alarmclock-Objekt till 6:12 och låter den gå i 6 min.");
            Console.WriteLine(test_1.ToString());

            Alarmclock test_6 = new Alarmclock();
            WatchTestHeader("\n test_6\nTestar egenskaperna så att undantag kastas då tid och alarmtid /nTilldelas felaktiga värden");
            try
            {
                test_6.Hour = 24;
            }
            catch (ArgumentException wrong)
            {
                WatchErrorMessage(wrong.Message);
            }
            try
            {
                test_6.Minute = 60;
            }
            catch (ArgumentException wrong)
            {
                WatchErrorMessage(wrong.Message);
            }
            try
            {
                test_6.AlarmclockHour = 25;
            }
            catch (ArgumentException wrong)
            {
                WatchErrorMessage(wrong.Message);
            }
            try
            {
                test_6.AlarmclockMinute = 60;
            }
            catch (ArgumentException wrong)
            {
                WatchErrorMessage(wrong.Message);
            }
            WatchTestHeader("\n test_7\nTestar konstruktorer så att undantag kastas då tid och alarmtid \ntilldelas felaktiga värden.");
            try
            {
                Alarmclock test_7 = new Alarmclock(24, 0);
            }
            catch (ArgumentException wrong)
            {
                WatchErrorMessage(wrong.Message);
            }
            try
            {
                Alarmclock test_7 = new Alarmclock(0,60);
            }
            catch (ArgumentException wrong)
            {
                WatchErrorMessage(wrong.Message);
            }
            try
            {
                Alarmclock test_7 = new Alarmclock(0,0,24,0);
            }
            catch (ArgumentException wrong)
            {
                WatchErrorMessage(wrong.Message);
            }
            try
            {
                Alarmclock test_7 = new Alarmclock(0,0,0,60);
            }
            catch (ArgumentException wrong)
            {
                WatchErrorMessage(wrong.Message);
            }
        }
        private static void run(Alarmclock test, int minutes)
        {
            for (int i = 0; i < minutes; i++)
            {
                if(test.TickTock())
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("♫♫");
                    Console.WriteLine(test.ToString());
                    Console.WriteLine("Pling Pling Pling Pling");
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(test.ToString());

                }
                Console.ResetColor();
            }
        }
        private static void WatchErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void WatchTestHeader(String header)
        {
            Console.WriteLine(Line);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(header);
            Console.ResetColor();
        }
    }
}
