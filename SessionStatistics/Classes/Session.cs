using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;

namespace SessionStatistics.Classes
{
    public class Session
    {
        #region Instance-Specific
        private static Session _instance;
        public static Session Instance
        {
            get { return _instance ?? (_instance = new Session());}
        }
        #endregion

        //Variables
        public Dictionary<Int32, HashSet<long>> BlacklistedIds;
        private Dictionary<Int32, Area> Areas;

        //Instances
        public Statistic SessionStatistic, AreaStatistic;
        public Area CurrentArea;
        public Session()
        {
            Areas = new Dictionary<int, Area>();
            BlacklistedIds = new Dictionary<int, HashSet<long>>();
            SessionStatistic = new Statistic();
            AreaStatistic = new Statistic();
            CurrentArea = new Area();
        }

        public void ResetArea()
        {
            Area newArea;
            AreaStatistic = new Statistic();
            if (!Areas.TryGetValue(Player.Area.Hash, out newArea))
            {
                newArea = new Area();
                Areas.Add(Player.Area.Hash, newArea);

            }
            CurrentArea = newArea;
        }
    }
}
