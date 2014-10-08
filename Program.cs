using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVäckarklocka
{
    class Program
    {
        private static string Line = "\n|============================================================================|";
        static void Main(string[] args)
        {
            Alarmclock test_1 = new Alarmclock();
            WatchTestHeader("\n test_1\nTest av standardkonstruktorn"); //Testar konstruktorn
            Console.WriteLine(test_1.ToString());

            Alarmclock test_2 = new Alarmclock( 9, 42);
            WatchTestHeader("\n test_2\nTest av konstruktorn med två parametrar< 9, 42>"); //Testar konstruktorn med 2 parametrar
            Console.WriteLine(test_2.ToString());

            Alarmclock test_3 = new Alarmclock( 13 ,24, 7,  35);
            WatchTestHeader("\n test_3\nTest av konstruktorn med fyra parametrar < 13, 24, 7, 35>"); //Testar konstruktorn med 4 parametrar
            Console.WriteLine(test_3.ToString());

            Alarmclock test_4 = new Alarmclock( 23, 58, 7, 35);
            WatchTestHeader("\n test_4\nStäller befintiligt Alarmclock-Objekt till 23:58 och låter den gå i 13 min. ");
            run(test_4, 13);

            Alarmclock test_5 = new Alarmclock( 6, 12, 6, 15);
            WatchTestHeader("\n test_5\nStäller befintligt Alarmclock-Objekt till 6:12 och låter den gå i 6 min.");
            run(test_5, 6);

            Alarmclock test_6 = new Alarmclock();
            WatchTestHeader("\n test_6\nTestar egenskaperna så att undantag kastas då tid och alarmtid Tilldelas felaktiga värden");
            try
                {
                    test_6.Hour = 24; //Kollar om värdet är 24 och fångar det isåfall, annars går den till nästa "try "
                }
            catch (ArgumentException wrong)
                {
                    WatchErrorMessage(wrong.Message); //fångar felet och visar felmeddelandet som är kodat längre ner.
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
            WatchTestHeader("\n test_7\nTestar konstruktorer så att undantag kastas då tid och alarmtid ntilldelas felaktiga värden."); 
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
        private static void run(Alarmclock test, int minutes) //räknar minuter tills den når "alarm-värdet" skriver sedan ut koden på rad 106-112.
        {
            for (int i = 0; i < minutes; i++)
            {
                if(test.TickTock())
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write("♫");
                    Console.Write(test.ToString());
                    Console.Write("Pling! Pling! Pling! Pling!");
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(test.ToString());

                }
                Console.ResetColor();
            }
        }
        private static void WatchErrorMessage(string message) //Felmeddeande som sätter färgen röd och skriver ut meddelandet.
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void WatchTestHeader(String header) 
        {
            Console.WriteLine(Line);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(header);
            Console.ResetColor();
        }
    }
}
