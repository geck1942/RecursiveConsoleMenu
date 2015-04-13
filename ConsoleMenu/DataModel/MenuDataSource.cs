using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    public sealed class MenuDataSource
    {
        private static MenuDataSource _menuDataSource = new MenuDataSource();
        private Menu _menu = null;

        public Menu Menu
        {
            get { return this._menu; }
        }

        public static Menu GetMenu()
        {
            _menuDataSource.GetMenuData();
            return _menuDataSource._menu;
        }

        private void GetMenuData()
        {
            if (this._menu != null)
                return;
            try
            {
                FileStream menufile = new FileStream("DataModel\\MenuData.json", FileMode.Open);

                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Menu));
                this._menu = (Menu)serializer.ReadObject(menufile);
                menufile.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to read file.", ex);
            }
        }


    }
}
