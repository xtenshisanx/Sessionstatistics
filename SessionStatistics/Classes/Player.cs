using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PoeHUD.Models;
using PoeHUD.Poe.Components;
namespace SessionStatistics.Classes
{
    class Player
    {
        public static Int32[] LevelCurve = { 525, 1235, 2021, 3403, 5002, 7138, 10053, 13804, 18512, 24297, 31516, 39878, 50352, 62261, 76465, 92806, 112027, 133876, 158538, 187025, 218895, 255366, 295852, 341805, 39247, 449555, 512121, 583857, 662181, 747411, 844146, 949053, 1064952, 1192712, 1333241, 1487491, 1656447, 1841143, 2046202, 2265837, 2508528, 2776124, 3061734, 3379914, 3723676, 4099570, 4504444, 4951099, 5430907, 5957868, 6528910, 7153414, 7827968, 8555414, 9353933, 10212541, 11142646, 12157041, 13252160, 14441758, 15731508, 17127265, 18635053, 20271765, 22044909, 23950783, 26019833, 28261412, 30672515, 33287878, 36118904, 39163425, 42460810, 46024718, 49853964, 54008554, 58473753, 63314495, 68516464, 74132190, 80182477, 86725730, 93748717, 10135210, 10952490, 11833506, 12781314, 13803382, 14903282, 16089060, 17364879, 18737217, 20215373, 21804190, 23516339, 25354786, 27335853, 29463183, 31751591 };
        public static EntityWrapper Entity { get { return SessionStatisticsCore.API.GameController.Player; } }
        public static Int32 Exp { get { return (Int32)Entity.GetComponent<PoeHUD.Poe.Components.Player>().XP; } }
        public static Int32 Level { get { return (Int32)Entity.GetComponent<PoeHUD.Poe.Components.Player>().Level; } }
        public static String Name { get { return Entity.GetComponent<PoeHUD.Poe.Components.Player>().PlayerName; } }

        public static AreaInstance Area {  get { return SessionStatisticsCore.API.GameController.Area.CurrentArea; } }

        public static TimeSpan TimeToLevel(Int32 Level)
        {
            Int32 _NextLevelXP = (Int32)PoeHUD.Models.Constants.PlayerXpLevels[Level];

            TimeSpan _seconds = DateTime.Now - Session.Instance.AreaStatistic.JoinTime;
            Decimal _PerHour = Decimal.Divide((Player.Exp - Session.Instance.AreaStatistic.JoinExperience), (Decimal)_seconds.TotalHours);
            if(_PerHour == 0)
            {
                return TimeSpan.Zero;
            }
            Decimal _asd = Decimal.Divide((_NextLevelXP - Exp), _PerHour);
            return TimeSpan.FromHours((Double)_asd);
        }
        public static Decimal RunsToLevel(Int32 Level)
        {
            Int32 _ExpNeededToLevel = (Int32)PoeHUD.Models.Constants.PlayerXpLevels[Level];
            Int32 _PlayerExp = (Int32)Exp;
            Decimal _AreaXP = (Decimal)(Session.Instance.AreaStatistic.GainedExp());
            Decimal _RunsNeeded = 0.0M;
            if (_AreaXP != 0)
            {
                _RunsNeeded = Decimal.Divide((_ExpNeededToLevel - _PlayerExp), _AreaXP);
            }
            return Math.Round(_RunsNeeded,3);
        }
    }
}
