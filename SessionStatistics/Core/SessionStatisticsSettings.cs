using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PoeHUD.Plugins;
using PoeHUD.Hud.Settings;

namespace SessionStatistics.Core
{
    public class SessionStatisticsSettings : SettingsBase
    {
        #region Currency-Menu
        [Menu("Currency",1)]
        public ToggleNode CountCurrency { get; set; }
        [Menu("Armourer`s Scrap",20, 1)]
        public ToggleNode CountArmourer { get; set; }
        [Menu("Exalted Orb", 21, 1)]
        public ToggleNode CountEx { get; set; }
        [Menu("Blacksmith's Whetstone", 2, 1)]
        public ToggleNode CountBlacksmith { get; set; }
        [Menu("Blessed Orb", 3, 1)]
        public ToggleNode CountBlessed { get; set; }
        [Menu("Cartographer's Chisel", 4, 1)]
        public ToggleNode CountChisels { get; set; }
        [Menu("Chaos Orb", 5, 1)]
        public ToggleNode CountChaos { get; set; }
        [Menu("Chromatic Orb", 6, 1)]
        public ToggleNode CountChromatic { get; set; }
        [Menu("Divine Orb", 7, 1)]
        public ToggleNode CountDivine { get; set; }
        [Menu("Gemcutter's Prism", 8, 1)]
        public ToggleNode CountGemcutter { get; set; }
        [Menu("Jeweller's Orb", 9, 1)]
        public ToggleNode CountJeweller { get; set; }
        [Menu("Orb of Alchemy", 10, 1)]
        public ToggleNode CountAlch { get; set; }
        [Menu("Orb of Alteration", 11, 1)]
        public ToggleNode CountAlt { get; set; }
        [Menu("Orb of Augmentation", 12, 1)]
        public ToggleNode CountAug { get; set; }
        [Menu("Orb of Chance", 13, 1)]
        public ToggleNode CountChance { get; set; }
        [Menu("Orb of Fusing", 14, 1)]
        public ToggleNode CountFusing { get; set; }
        [Menu("Orb of Regret", 15, 1)]
        public ToggleNode CountRegret { get; set; }
        [Menu("Orb of Scouring", 16, 1)]
        public ToggleNode CountScouring { get; set; }
        [Menu("Orb of Transmutation", 17, 1)]
        public ToggleNode CountTrans { get; set; }
        [Menu("Regal Orb", 18, 1)]
        public ToggleNode CountRegal { get; set; }
        [Menu("Vaal Orb", 19, 1)]
        public ToggleNode CountVaal { get; set; }
        #endregion

        #region Settings-Menu
        [Menu("Settings",200)]
        public EmptyNode SettingsMenuNode { get; set; }
        [Menu("Textsize", 201, 200)]
        public RangeNode<Int32> TextSize { get; set; }
        [Menu("TopBar",202,200)]
        public ToggleNode EnableTopBar { get; set; }

        [Menu("X-Position", 300, 202)]
        public RangeNode<float> TopBarXPos { get; set; }
        [Menu("SessionBoard", 203, 200)]
        public ToggleNode EnableSessionBoard { get; set; }

        [Menu("X-Position", 400, 203)]
        public RangeNode<float> SessionBoardXPos { get; set; }

        [Menu("Y-Position", 401, 203)]
        public RangeNode<float> SessionBoardYPos { get; set; }
        #endregion
        public SessionStatisticsSettings()
        {
            Enable = true;

            CountCurrency = new ToggleNode(true);
            CountAlch = new ToggleNode(true);
            CountAlt = new ToggleNode(true);
            CountArmourer = new ToggleNode(true);
            CountAug = new ToggleNode(true);
            CountBlacksmith = new ToggleNode(true);
            CountBlessed = new ToggleNode(true);
            CountChance = new ToggleNode(true);
            CountChaos = new ToggleNode(true);
            CountChisels = new ToggleNode(true);
            CountChromatic = new ToggleNode(true);
            CountDivine = new ToggleNode(true);
            CountFusing = new ToggleNode(true);
            CountGemcutter = new ToggleNode(true);
            CountJeweller = new ToggleNode(true);
            CountRegal = new ToggleNode(true);
            CountRegret = new ToggleNode(true);
            CountScouring = new ToggleNode(true);
            CountTrans = new ToggleNode(true);
            CountVaal = new ToggleNode(true);
            CountEx = new ToggleNode(true);

            SettingsMenuNode = new EmptyNode();
            TextSize = new RangeNode<int>(18, 12, 36);
            EnableTopBar = new ToggleNode(true);
            TopBarXPos = new RangeNode<float>(0,0, SessionStatisticsCore.API.GameController.Window.GetWindowRectangle().BottomRight.X);
            EnableSessionBoard = new ToggleNode(true);
            SessionBoardXPos = new RangeNode<float>(0, 0, SessionStatisticsCore.API.GameController.Window.GetWindowRectangle().BottomRight.X);
            SessionBoardYPos = new RangeNode<float>(0, 0, SessionStatisticsCore.API.GameController.Window.GetWindowRectangle().BottomRight.Y);

        }
    }
}
