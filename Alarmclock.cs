using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalVäckarklocka
{
    class Alarmclock
    {
        private int _alarmclockHour;  //Sätter variablar som kan vara nummer (int)
        private int _alarmclockMinute;
        private int _hour;
        private int _minute;


        public int AlarmclockHour  // Anger talet för variablen AlarmclockHour värdet ska motsvara Alarmets timmar. "get" läser in värdet "set" Sätter ett värde.
        {                          // när jag skickar värden används altså set och när jag vill ha ett värde anges get.
            get
            {
                return _alarmclockHour;
            }
            set
            {
                if (value <0 || value > 23)
                {
                    throw new ArgumentException("ange korrekt timme mellan kl 0-23");
                }
                _alarmclockHour = value;
            }
        }
        public int AlarmclockMinute //Anger talet för AlarmclockMinute, Värdet blir Alarmets minuter.
        {
            get
            {
                return _alarmclockMinute;
            }
            set
            {
                if (value <0 || value>59)
                {
                    throw new ArgumentException("Ange korrekt minuttal inom 0 - 59");
                }
                _alarmclockMinute = value;
            }
        }
        public int Hour // Anger talet för Hour, Hour motsvarar KLOCKANS timmar
        {
            get
            {
                return _hour;
            }
            set
            {
                if (value <0 || value>23)
                {
                    throw new ArgumentException("Klockans timmar måste vara mellan 0 - 23");
                }
                _hour = value;
            }
        }
        public int Minute // Anger talet för Minute, Minute motsvarar KLOCKANS minuter.
        {
            get
            {
                return _minute;
            }
            set
            {
                if (value <0 || value>59)
                {
                    throw new ArgumentException("Klockans minuttal måste vara inom 0 - 59");
                }
                _minute = value;
            }
        }
        // här så ser konstruktorerna till så att objekten initieras på ett korrekt sätt.
        public Alarmclock(): this(0,0) // Här anropas konstruktorn som har 2 parametrar.
        {
            // citerar instruktionerna : Ingen tilldelning får 
            //ske i konstruktorns kropp, som måste vara tom. Denna konstruktor måste därför anropa den 
            //konstruktor i klassen som har två parametrar
        }
        public Alarmclock(int hour, int minute):this (hour,minute,0,0)
        {
            // citerar instruktionerna : Ingen tilldelning får 
            //ske i konstruktorns kropp, som måste vara tom. Denna konstruktor måste därför anropa den 
            //konstruktor i klassen som har fyra parametrar
        }
        public Alarmclock(int hour, int minute, int alarmclockHour, int alarmclockMinute) //Här tilldelas fälten värden enligt instruktionerna eftersom detta är den enda konstruktorn som fick innehålla kod.
        {
            Hour = hour;
            Minute = minute;
            AlarmclockHour = alarmclockHour;
            AlarmclockMinute = alarmclockMinute;
        }
        public bool TickTock() //när TickTock anropas ökar minuten med +1 om antal minuter blir större än 59 sätts det till 0 och ökar hour med +1 om hour är större än 23
        {                      // sätts Hour till 0. Efter det testas det om klockans timme + minut stämmer mot alarmets timme + minut.

            if (Minute < 59)
            {
                Minute++;
            }
            else
            {
                Minute = 0;

                if (Hour < 23)
                {
                    Hour++;
                }
                else
                {
                    Hour = 0;
                }
            }
            if (Hour == AlarmclockHour && AlarmclockMinute == Minute)
            {
                return true;
            }

            return false;
        }

            
        public override string ToString() //Skriver ut vad klockan är och vad alarmet är ställt till.
        {
            StringBuilder time = new StringBuilder(); // stringbuilder är en sträng som kan modifieras, lägga till text istället för att skicka tillbaka nya objekt kan man skicka
            time.AppendFormat("{0,4}:", _hour);        // tillbaka samma objekt fast redigerat.
            if(_minute< 10)
            {
                time.AppendFormat("0{0}:", _minute); //AppendFormat redigerar Stringbuider strängen som vi använder för att utnyttja D.R.Y
            }
            else
            {
                time.AppendFormat("{0}", _minute); 
            }

            time.AppendFormat("<{0}:", _alarmclockHour);
            
            if(_alarmclockMinute<10)
            { 
                time.AppendFormat("0{0}>", _alarmclockMinute);
            }
            else
            {
                time.AppendFormat("{0}>", _alarmclockMinute);
            }                                
            return time.ToString();         //Skickar tillbaka det nya värdet som stringbuilder har fått genom ovanstående kod.               
        
         }
   }
}
