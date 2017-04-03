using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PoeHUD.Hud.UI;
using SharpDX;

using SessionStatistics.Classes;

namespace SessionStatistics.Visuals
{
    class SessionBoard
    {
        private static SessionBoard _instance;
        public static SessionBoard Instance { get { return _instance ?? (_instance = new SessionBoard()); } }
        private SharpDX.RectangleF WindowRect { get { return SessionStatisticsCore.API.GameController.Window.GetWindowRectangle(); } }

        private List<ContentBox> AreaBoxes, SessionBoxes, Legend;
        private Graphics Graphics;
        public SessionBoard()
        {
            Graphics = SessionStatisticsCore.API.Graphics;

            AreaBoxes = new List<ContentBox>();
            AreaBoxes.Add(new ContentBox());
            AreaBoxes.Add(new ContentBox(Color.Black));
            AreaBoxes.Add(new ContentBox(Color.Black));
            AreaBoxes.Add(new ContentBox());
            AreaBoxes.Add(new ContentBox());
            
            SessionBoxes = new List<ContentBox>();
            SessionBoxes.Add(new ContentBox());
            SessionBoxes.Add(new ContentBox(Color.Black));
            SessionBoxes.Add(new ContentBox(Color.Black));
            SessionBoxes.Add(new ContentBox());
            SessionBoxes.Add(new ContentBox());

            Legend = new List<ContentBox>();
            Legend.Add(new ContentBox());
            Legend.Add(new ContentBox());
            Legend.Add(new ContentBox());
            Legend.Add(new ContentBox());
            Legend.Add(new ContentBox());
            Legend.Add(new ContentBox());
            Legend.Add(new ContentBox());
        }
        public void Update()
        {
            //Legend-Left
            Legend[0].TextToDraw = "Area";
            Legend[1].TextToDraw = "Session";
            //Legend-Top
            Legend[2].TextToDraw = "Playtime";
            Legend[3].TextToDraw = "Kills";
            Legend[4].TextToDraw = "Rares";
            Legend[5].TextToDraw = "Uniques";
            Legend[6].TextToDraw = "Exp";
            //Area
            AreaBoxes[0].TextToDraw = Session.Instance.AreaStatistic.GetPlaytime();
            AreaBoxes[0].BoxColor = new SharpDX.ColorBGRA(77, 77, 77, 180);
            AreaBoxes[1].TextToDraw = Session.Instance.AreaStatistic.GetValuePerHour(Session.Instance.AreaStatistic.Kills);
            AreaBoxes[1].BoxColor = new SharpDX.ColorBGRA(211, 211, 211, 180);
            AreaBoxes[2].TextToDraw = Session.Instance.AreaStatistic.GetValuePerHour(Session.Instance.AreaStatistic.Rares);
            AreaBoxes[2].BoxColor = new SharpDX.ColorBGRA(224, 224, 40, 180);
            AreaBoxes[3].TextToDraw = Session.Instance.AreaStatistic.GetValuePerHour(Session.Instance.AreaStatistic.Uniques);
            AreaBoxes[3].BoxColor = new SharpDX.ColorBGRA(227, 137, 32, 180);
            AreaBoxes[4].TextToDraw = Session.Instance.AreaStatistic.GetValuePerHour(Player.Exp - Session.Instance.AreaStatistic.JoinExperience);
            AreaBoxes[4].BoxColor = new SharpDX.ColorBGRA(65, 115, 225, 180);
            //Session
            SessionBoxes[0].TextToDraw = Session.Instance.SessionStatistic.GetPlaytime();
            SessionBoxes[0].BoxColor = new SharpDX.ColorBGRA(77, 77, 77, 180);
            SessionBoxes[1].TextToDraw = Session.Instance.SessionStatistic.GetValuePerHour(Session.Instance.SessionStatistic.Kills);
            SessionBoxes[1].BoxColor = new SharpDX.ColorBGRA(211, 211, 211, 180);
            SessionBoxes[2].TextToDraw = Session.Instance.SessionStatistic.GetValuePerHour(Session.Instance.SessionStatistic.Rares);
            SessionBoxes[2].BoxColor = new SharpDX.ColorBGRA(224, 224, 40, 180);
            SessionBoxes[3].TextToDraw = Session.Instance.SessionStatistic.GetValuePerHour(Session.Instance.SessionStatistic.Uniques);
            SessionBoxes[3].BoxColor = new SharpDX.ColorBGRA(227, 137, 32, 180);
            SessionBoxes[4].TextToDraw = Session.Instance.SessionStatistic.GetValuePerHour(Player.Exp - Session.Instance.SessionStatistic.JoinExperience);
            SessionBoxes[4].BoxColor = new SharpDX.ColorBGRA(65, 115, 225, 180);

            AreaBoxes.ForEach(Box => Box.Update());
            SessionBoxes.ForEach(Box => Box.Update());
            Legend.ForEach(Box => Box.Update());
            AreaBoxes.ForEach(Box => Box.BoxSize.Width = 100);
            SessionBoxes.ForEach(Box => Box.BoxSize.Width = 100);

            var _positionX = SessionStatisticsCore.SettingsInstance.SessionBoardXPos;
            var _positionY = SessionStatisticsCore.SettingsInstance.SessionBoardYPos;
            for (int i = 0; i != 5; i++)
            {
                if (i == 0)
                {
                    AreaBoxes[i].BoxPositon.X = _positionX.Value;
                    AreaBoxes[i].BoxPositon.Y = _positionY.Value;
                    SessionBoxes[i].BoxPositon.X = _positionX.Value;
                    SessionBoxes[i].BoxPositon.Y = _positionY.Value + AreaBoxes[i].BoxSize.Height + 5;
                }
                else
                {
                    AreaBoxes[i].BoxPositon.X = AreaBoxes[i - 1].BoxPositon.X + AreaBoxes[i - 1].BoxSize.Width + 5;
                    AreaBoxes[i].BoxPositon.Y = _positionY.Value;
                    SessionBoxes[i].BoxPositon.X = SessionBoxes[i - 1].BoxPositon.X + SessionBoxes[i - 1].BoxSize.Width + 5;
                    SessionBoxes[i].BoxPositon.Y = SessionBoxes[i - 1].BoxPositon.Y;
                }
            }
            Legend[0].BoxPositon.X = _positionX.Value - Legend[0].BoxSize.Width - 5;
            Legend[0].BoxPositon.Y = _positionY.Value;
            Legend[1].BoxPositon.X = _positionX.Value - Legend[1].BoxSize.Width - 5;
            Legend[1].BoxPositon.Y = _positionY.Value + Legend[0].BoxSize.Height + 5;
            Legend[2].BoxPositon.X = AreaBoxes[0].BoxPositon.X;
            Legend[2].BoxPositon.Y = AreaBoxes[0].BoxPositon.Y - AreaBoxes[0].BoxSize.Height - 5;
            Legend[3].BoxPositon.X = AreaBoxes[1].BoxPositon.X;
            Legend[3].BoxPositon.Y = AreaBoxes[1].BoxPositon.Y - AreaBoxes[1].BoxSize.Height - 5;
            Legend[4].BoxPositon.X = AreaBoxes[2].BoxPositon.X;
            Legend[4].BoxPositon.Y = AreaBoxes[2].BoxPositon.Y - AreaBoxes[2].BoxSize.Height - 5;
            Legend[5].BoxPositon.X = AreaBoxes[3].BoxPositon.X;
            Legend[5].BoxPositon.Y = AreaBoxes[3].BoxPositon.Y - AreaBoxes[3].BoxSize.Height - 5;
            Legend[6].BoxPositon.X = AreaBoxes[4].BoxPositon.X;
            Legend[6].BoxPositon.Y = AreaBoxes[4].BoxPositon.Y - AreaBoxes[4].BoxSize.Height - 5;
        }

        public void Draw()
        {
            Update();
            AreaBoxes.ForEach(Box => Box.Draw());
            SessionBoxes.ForEach(Box => Box.Draw());
            Legend.ForEach(Box => Box.Draw());
        }
    }
}
