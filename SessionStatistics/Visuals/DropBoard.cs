using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;
using SessionStatistics.Classes;

namespace SessionStatistics.Visuals
{
    class DropBoard : DrawTable
    {
        #region Instance-Specific
        private static DropBoard _instance;
        public static DropBoard Instance { get { return _instance ?? (_instance = new DropBoard(Color.Black)); } }
        #endregion
        public Boolean ShouldBeShown;
        private static String[] CurrencyTypes = new String[] { "Armourers", "Blacksmiths", "Blessed", "Cartographers", "Chaos", "Chromatics", "Divine", "Exalted", "Gemcutters", "Jewellers", "Alchemy", "Alteration", "Augmentation", "Chance", "Fusing", "Regret", "Scouring", "Transmute", "Regal", "Vaal" };
        public DropBoard(Color backgroundColor) : base(backgroundColor)
        {
            ShouldBeShown = false;
        }

        public override void Draw(Vector2 position)
        {
            /*
             *   Currency       AREA       Session
             * #######################################
             * ####       ###          ###         ###
             * ####  PIC  ###   AREA   ### SESSION ###
             * ####       ###          ###         ###
             * #######################################
             */
            foreach(String row in CurrencyTypes)
            {
                position.Y += DrawRow(position, row, row);
            }
        }

        private Int32 DrawRow(Vector2 position, String rowName, String picturePath)
        {
            Int32 rowHeight = 48;
            Int32 rowWidth = 60;
            float neededWidth = 170;

            String areaDrops = Session.Instance.AreaStatistic.Currency[rowName].ToString();
            String sessionDrops = Session.Instance.SessionStatistic.Currency[rowName].ToString();

            //Currency-Picture
            String picPath = String.Format("{0}\\{1}", SessionStatisticsCore.WorkingDirectory, String.Format("{0}.png",picturePath));
            RectangleF picRect = new RectangleF(position.X, position.Y, rowHeight, rowHeight);

            //Area-Value
            Size2 areaValueSize = GraphicsController.MeasureText(areaDrops, 18);
            Vector2 areaValuePosition = new Vector2(picRect.Right, (picRect.Center.Y - areaValueSize.Height / 2));
            RectangleF areaValueFrame = new RectangleF(picRect.Right, position.Y, rowWidth, rowHeight);
            areaValuePosition.X += 5;

            //Session-Value
            Size2 sessionValueSize = GraphicsController.MeasureText(sessionDrops, 18);
            Vector2 sessionValuePosition = new Vector2(areaValueFrame.Right, (picRect.Center.Y - sessionValueSize.Height / 2));
            sessionValuePosition.X += 5;
            RectangleF sessionValueFrame = new RectangleF(areaValueFrame.Right, position.Y, rowWidth, rowHeight);

            //Draw
            GraphicsController.DrawBox(new RectangleF(position.X, position.Y, neededWidth, rowHeight), Color.Black);
            GraphicsController.DrawPluginImage(picPath, picRect);
            GraphicsController.DrawText(areaDrops, 18, areaValuePosition);
            GraphicsController.DrawText(sessionDrops, 18, sessionValuePosition);
            GraphicsController.DrawFrame(picRect, 1.0f,Color.Wheat);
            GraphicsController.DrawFrame(areaValueFrame, 1.0f, Color.Wheat);
            GraphicsController.DrawFrame(sessionValueFrame, 1.0f, Color.Wheat);
            return rowHeight;
        }
    }
}
