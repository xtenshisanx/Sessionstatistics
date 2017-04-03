using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PoeHUD.Hud.UI;
using SharpDX;

namespace SessionStatistics.Classes
{
    class DropBox
    {
        public String Title;
        public String Picture;
        public String LineOne;
        public String LineTwo;
        public Vector2 Size;
        private Graphics GraphicsController;

        private Vector2 PicturePosition;
        private Vector2 LineOnePosition;

        public DropBox(String title, String picture, Vector2 size)
        {
            GraphicsController = SessionStatisticsCore.API.Graphics;
            Title = title;
            Picture = String.Format("{0}\\{1}", SessionStatisticsCore.WorkingDirectory,picture);
            Size = size;
        }
        public void Update()
        {

        }
        public void Update(String[] newText)
        {
            LineOne = newText[0];
            LineTwo = newText[1];
        }

        public void Draw(Vector2 Position)
        {
            var _BoxCenter = Position.X + (Size.X / 2);
            PicturePosition = new Vector2(Position.X + (Size.X / 2) - ((Size.X / 3) /2 ), Position.Y + 5);
            LineOnePosition = new Vector2(_BoxCenter - (GraphicsController.MeasureText(LineOne,16).Width), PicturePosition.Y + 30);
            GraphicsController.DrawBox(new RectangleF(Position.X, Position.Y, Size.X, Size.Y), Color.Black);
            GraphicsController.DrawPluginImage(Picture, new RectangleF(PicturePosition.X,PicturePosition.Y, Size.X / 3, Size.Y / 3));
            GraphicsController.DrawText("Area: 0", 16, LineOnePosition);
            GraphicsController.DrawFrame(new RectangleF(Position.X, Position.Y, Size.X, Size.Y),1.0f,Color.LightGray);
        }
    }
}
