using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PoeHUD.Models;
using PoeHUD.Poe;
using PoeHUD.Controllers;

namespace SessionStatistics.Classes
{
    class Item
    {
        public static Boolean IsCurrency(Entity entity)
        {
            if (entity.ToString().Contains("Currency"))
            {
                return true;
            }
            return false;
        }
    }
}
