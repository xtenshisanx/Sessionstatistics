using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PoeHUD.Poe.Components;
using PoeHUD.Models;
using PoeHUD.Controllers;
using PoeHUD.Poe;

using SharpDX;

namespace SessionStatistics.Classes
{
    public class Area
    {
        #region Variables
        public HashSet<EntityWrapper> Monsters;
        public HashSet<EntityWrapper> Items;
        private GameController Controller;
        private HashSet<KeyValuePair<String, Vector3>> BlacklistedItems;
        #endregion

        public Area()
        {
            Controller = SessionStatisticsCore.API.GameController;
            BlacklistedItems = new HashSet<KeyValuePair<string, Vector3>>();
            Monsters = new HashSet<EntityWrapper>();
            Items = new HashSet<EntityWrapper>();
        }

        public void Update()
        {
            #region KillCount

            List<EntityWrapper> DeadMonsters = Monsters.Where(monster => !monster.IsAlive && monster.IsHostile).ToList();
            foreach (EntityWrapper monster in DeadMonsters)
            {
                Session.Instance.AreaStatistic.Kills++;
                Session.Instance.SessionStatistic.Kills++;
                Monsters.Remove(monster);
            }
            #endregion

            #region ItemCount

            List<EntityWrapper> itemsOnGround = Items.Where(item => !BlacklistedItems.Contains(new KeyValuePair<string, Vector3>(item.Path, item.Pos))).ToList();
            foreach(EntityWrapper itementity in itemsOnGround)
            {
                WorldItem worldItem = itementity.GetComponent<WorldItem>();
                Entity item = worldItem.ItemEntity;
                if (item.HasComponent<Mods>())
                {
                    //Rare
                    if (!Item.IsCurrency(item) && item.GetComponent<Mods>().ItemRarity == PoeHUD.Models.Enums.ItemRarity.Rare)
                    {
                        Session.Instance.AreaStatistic.Rares++;
                        Session.Instance.SessionStatistic.Rares++;
                    }
                    //Unique
                    if (!Item.IsCurrency(item) && item.GetComponent<Mods>().ItemRarity == PoeHUD.Models.Enums.ItemRarity.Unique)
                    {
                        Session.Instance.AreaStatistic.Uniques++;
                        Session.Instance.SessionStatistic.Uniques++;
                    }
                }
                else if(Item.IsCurrency(item))
                {
                    if (item.ToString().Contains("AddModToMagic") && SessionStatisticsCore.SettingsInstance.CountAug)
                    {
                        Session.Instance.AreaStatistic.Currency["Augmentation"]++;
                        Session.Instance.SessionStatistic.Currency["Augmentation"]++;
                    }
                    else if (item.ToString().Contains("AddModToRare") && SessionStatisticsCore.SettingsInstance.CountEx)
                    {
                        Session.Instance.AreaStatistic.Currency["Exalted"]++;
                        Session.Instance.SessionStatistic.Currency["Exalted"]++;
                    }
                    else if (item.ToString().Contains("ArmourQuality") && SessionStatisticsCore.SettingsInstance.CountArmourer)
                    {
                        Session.Instance.AreaStatistic.Currency["Armourers"]++;
                        Session.Instance.SessionStatistic.Currency["Armourers"]++;
                    }
                    else if (item.ToString().Contains("WeaponQuality") && SessionStatisticsCore.SettingsInstance.CountBlacksmith)
                    {
                        Session.Instance.AreaStatistic.Currency["Blacksmiths"]++;
                        Session.Instance.SessionStatistic.Currency["Blacksmiths"]++;
                    }
                    else if (item.ToString().Contains("ConvertToNormal") && SessionStatisticsCore.SettingsInstance.CountScouring)
                    {
                        Session.Instance.AreaStatistic.Currency["Scouring"]++;
                        Session.Instance.SessionStatistic.Currency["Scouring"]++;
                    }
                    else if (item.ToString().Contains("PassiveSkillRefund") && SessionStatisticsCore.SettingsInstance.CountRegret)
                    {
                        Session.Instance.AreaStatistic.Currency["Regret"]++;
                        Session.Instance.SessionStatistic.Currency["Regret"]++;
                    }
                    else if (item.ToString().Contains("RerollMagic") && SessionStatisticsCore.SettingsInstance.CountAlt)
                    {
                        Session.Instance.AreaStatistic.Currency["Alteration"]++;
                        Session.Instance.SessionStatistic.Currency["Alteration"]++;
                    }
                    else if (item.ToString().Contains("UpgradeToMagic") && SessionStatisticsCore.SettingsInstance.CountTrans)
                    {
                        Session.Instance.AreaStatistic.Currency["Transmute"]++;
                        Session.Instance.SessionStatistic.Currency["Transmute"]++;
                    }
                    else if (item.ToString().Contains("UpgradeToRare") && SessionStatisticsCore.SettingsInstance.CountAlch)
                    {
                        Session.Instance.AreaStatistic.Currency["Alchemy"]++;
                        Session.Instance.SessionStatistic.Currency["Alchemy"]++;
                    }
                    else if (item.ToString().Contains("GemQuality") && SessionStatisticsCore.SettingsInstance.CountGemcutter)
                    {
                        Session.Instance.AreaStatistic.Currency["Gemcutters"]++;
                        Session.Instance.SessionStatistic.Currency["Gemcutters"]++;
                    }
                    else if (item.ToString().Contains("ImplicitMod") && SessionStatisticsCore.SettingsInstance.CountBlessed)
                    {
                        Session.Instance.AreaStatistic.Currency["Blessed"]++;
                        Session.Instance.SessionStatistic.Currency["Blessed"]++;
                    }
                    else if (item.ToString().Contains("MapQuality") && SessionStatisticsCore.SettingsInstance.CountChisels)
                    {
                        Session.Instance.AreaStatistic.Currency["Cartographers"]++;
                        Session.Instance.SessionStatistic.Currency["Cartographers"]++;
                    }
                    else if (item.ToString().Contains("ModValues") && SessionStatisticsCore.SettingsInstance.CountDivine)
                    {
                        Session.Instance.AreaStatistic.Currency["Divine"]++;
                        Session.Instance.SessionStatistic.Currency["Divine"]++;
                    }
                    else if (item.ToString().Contains("RerollSocketColours") && SessionStatisticsCore.SettingsInstance.CountChromatic)
                    {
                        Session.Instance.AreaStatistic.Currency["Chromatics"]++;
                        Session.Instance.SessionStatistic.Currency["Chromatics"]++;
                    }
                    else if (item.ToString().Contains("RerollSocketLinks") && SessionStatisticsCore.SettingsInstance.CountFusing)
                    {
                        Session.Instance.AreaStatistic.Currency["Fusing"]++;
                        Session.Instance.SessionStatistic.Currency["Fusing"]++;
                    }
                    else if (item.ToString().Contains("RerollSocketNumbers") && SessionStatisticsCore.SettingsInstance.CountJeweller)
                    {
                        Session.Instance.AreaStatistic.Currency["Jewellers"]++;
                        Session.Instance.SessionStatistic.Currency["Jewellers"]++;
                    }
                    else if (item.ToString().Contains("UpgradeMagicToRare") && SessionStatisticsCore.SettingsInstance.CountRegal)
                    {
                        Session.Instance.AreaStatistic.Currency["Regal"]++;
                        Session.Instance.SessionStatistic.Currency["Regal"]++;
                    }
                    else if (item.ToString().Contains("CurrencyCorrupt") && SessionStatisticsCore.SettingsInstance.CountVaal)
                    {
                        Session.Instance.AreaStatistic.Currency["Vaal"]++;
                        Session.Instance.SessionStatistic.Currency["Vaal"]++;
                    }
                    else if (item.ToString().Contains("RerollRare") && SessionStatisticsCore.SettingsInstance.CountChaos)
                    {
                        Session.Instance.AreaStatistic.Currency["Chaos"]++;
                        Session.Instance.SessionStatistic.Currency["Chaos"]++;
                    }
                    else if (item.ToString().Contains("UpgradeRandomly") && SessionStatisticsCore.SettingsInstance.CountChance)
                    {
                        Session.Instance.AreaStatistic.Currency["Chance"]++;
                        Session.Instance.SessionStatistic.Currency["Chance"]++;
                    }
                }
                BlacklistedItems.Add(new KeyValuePair<string, Vector3>(itementity.Path, itementity.Pos));
                Items.Remove(itementity);
            }
            #endregion
        }
    }
}
