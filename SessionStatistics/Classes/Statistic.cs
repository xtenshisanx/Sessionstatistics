using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionStatistics.Classes
{
    public class Statistic
    {
        private static String[] CurrencyTypes = new String[] { "Armourers", "Blacksmiths", "Blessed", "Cartographers", "Chaos", "Chromatics", "Divine", "Exalted", "Gemcutters", "Jewellers", "Alchemy", "Alteration", "Augmentation", "Chance", "Fusing", "Regret", "Scouring", "Transmute", "Regal", "Vaal"};
        public DateTime JoinTime { get; set; }
        public Int32 JoinExperience { get; set; }
        public Int32 Kills { get; set; }
        public Int32 Rares { get; set; }
        public Dictionary<String, Int32> Currency { get; set; }
        public Int32 Uniques { get; set; }
        public Int32 Experience { get; set; }

        public Statistic()
        {
            JoinTime = DateTime.Now;
            JoinExperience = (Int32)SessionStatisticsCore.API.GameController.Player.GetComponent<PoeHUD.Poe.Components.Player>().XP;
            Currency = new Dictionary<string, Int32>();
            Init();
        }

        private void Init()
        {
            foreach(String str in CurrencyTypes)
            {
                Currency.Add(str, 0);
            }
        }

        public String GetValuePerHour(Int32 Value)
        {
            if(Value == 0)
            {
                return "0/h";
            }
            TimeSpan _seconds = DateTime.Now - JoinTime;
            Decimal _PerHour = Decimal.Divide(Value, (Decimal)_seconds.TotalHours);
            if (_PerHour > 999999)
            {
                return _PerHour.ToString("#,,M/h", System.Globalization.CultureInfo.InvariantCulture);
            }
            if (_PerHour > 999)
            {
                return _PerHour.ToString("#,K/h", System.Globalization.CultureInfo.InvariantCulture);
            }
            return _PerHour.ToString("#/h", System.Globalization.CultureInfo.InvariantCulture);
        }
        public Double GainedExp()
        {
            return Player.Exp - JoinExperience;
        }
        public String GetPlaytime()
        {
            TimeSpan _diff = DateTime.Now - JoinTime;
            return String.Format("{0:hh\\:mm\\:ss}", _diff);
        }
        public String GetExpPerHour()
        {
            TimeSpan _seconds = DateTime.Now - JoinTime;
            Decimal _PerHour = Decimal.Divide(Experience, (Decimal)_seconds.TotalHours);
            if (_PerHour > 999999)
            {
                return _PerHour.ToString("#,,M/h", System.Globalization.CultureInfo.InvariantCulture);
            }
            if (_PerHour > 999)
            {
                return _PerHour.ToString("#,K/h", System.Globalization.CultureInfo.InvariantCulture);
            }
            return _PerHour.ToString("#/h", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
