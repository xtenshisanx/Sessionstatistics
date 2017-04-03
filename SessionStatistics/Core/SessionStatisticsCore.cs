using System;
using System.Collections.Generic;
using System.Linq;

using PoeHUD.Plugins;
using PoeHUD.Models;
using PoeHUD.Poe.Components;
using PoeHUD.Framework;
using PoeHUD.Framework.InputHooks;

using SessionStatistics.Classes;

namespace SessionStatistics
{
    public class SessionStatisticsCore : BaseSettingsPlugin<Core.SessionStatisticsSettings>
    {
        //Booleans
        private Boolean _isHoldingKey = false;

        public static Core.SessionStatisticsSettings SettingsInstance;
        public static String WorkingDirectory;
        public static Session Session;

        public override void Initialise()
        {
            SettingsInstance = Settings;
            PluginName = "Sessionstatistics";
            GameController.Area.OnAreaChange += Event_OnAreaChange;
            WorkingDirectory = LocalPluginDirectory;
            Session = Session.Instance;
        }

        private void Event_OnAreaChange(PoeHUD.Controllers.AreaController obj)
        {
            Session.Instance.ResetArea();
        }

        public override void Render()
        {
            if (!_isHoldingKey && WinApi.IsKeyDown(System.Windows.Forms.Keys.NumPad1))
            {
                _isHoldingKey = true;
                if (Visuals.DropBoard.Instance.ShouldBeShown)
                {
                    Visuals.DropBoard.Instance.ShouldBeShown = false;
                }
                else
                {
                    Visuals.DropBoard.Instance.ShouldBeShown = true;
                }
            }
            if(_isHoldingKey && !WinApi.IsKeyDown(System.Windows.Forms.Keys.NumPad1))
            {
                _isHoldingKey = false;
            }
            if (this.GameController.InGame)
            {
                if (Visuals.DropBoard.Instance.ShouldBeShown)
                {
                    Visuals.DropBoard.Instance.Draw(new SharpDX.Vector2(100,100));
                }
                if (Settings.EnableTopBar)
                {
                    Visuals.TopBar.Instance.Draw();
                }
                if (Settings.EnableSessionBoard)
                {
                    Visuals.SessionBoard.Instance.Draw();
                }
                if (!this.GameController.Area.CurrentArea.IsHideout && !this.GameController.Area.CurrentArea.IsTown)
                {
                    Session.Instance.CurrentArea.Update();
                }
            }
            base.Render();
        }
        public override void EntityAdded(EntityWrapper _Entity)
        {
            if(_Entity.HasComponent<Monster>() && _Entity.IsAlive)
            {
                Session.Instance.CurrentArea.Monsters.Add(_Entity);
            }
            else if(_Entity.HasComponent<WorldItem>() || _Entity.GetComponent<WorldItem>().ItemEntity.HasComponent<Mods>())
            {
                Session.Instance.CurrentArea.Items.Add(_Entity);
            }
            /*if ((_Entity.HasComponent<Monster>() && _Entity.IsAlive) || (_Entity.GetComponent<WorldItem>().ItemEntity.HasComponent<Mods>() || _Entity.HasComponent<WorldItem>()))
            {
                Session.Instance.CurrentArea.UsefullEntities.Add(_Entity);
            }*/
        }
        public override void EntityRemoved(EntityWrapper entityWrapper)
        {
            if (entityWrapper.HasComponent <Monster>())
            {
                Session.Instance.CurrentArea.Monsters.Remove(entityWrapper);
            }
            else if (entityWrapper.HasComponent<WorldItem>() || entityWrapper.GetComponent<WorldItem>().ItemEntity.HasComponent<Mods>())
            {
                Session.Instance.CurrentArea.Items.Remove(entityWrapper);
            }
            /*if(Session.Instance.CurrentArea.UsefullEntities.Contains(entityWrapper))
            {
                Session.Instance.CurrentArea.UsefullEntities.Remove(entityWrapper);
            }*/
        }
    }
}
