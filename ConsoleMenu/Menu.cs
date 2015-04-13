using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    [DataContract]
    public class Menu
    {
        [DataMember(Name = "selector")]
        public string Selector { get; set; }
        [DataMember(Name = "backselector")]
        public string BackSelector { get; set; }
        [DataMember(Name = "caption")]
        public string Caption { get; set; }
        [DataMember(Name = "uid")]
        public string Uid { get; set; }
        [DataMember(Name = "items")]
        public List<Menu> Items { get; set; }

        public string PickUID()
        {
            string selecteduid = null;
            _pick(ref selecteduid);
            return selecteduid;
        }
        private void _pick(ref string selecteduid)
        {
            this.Draw();
            string _selected = Console.ReadLine();
            //selected item.
            var subMenu = this.Items.FirstOrDefault(i => i.Selector == _selected);
            // pickedItem found in Menu has sub elements. We need to go deeper!
            if (subMenu != null && subMenu.Items != null && subMenu.Items.Count > 0)
            {
                subMenu._pick(ref selecteduid);
                // user selected 'back' from child menu
                if (selecteduid == null)
                    // redo the selection
                    _pick(ref selecteduid);
            }
            // we're done here. There is no sub element. User chose the deepest item.
            else if (subMenu != null)
                selecteduid = subMenu.Uid;
            // selection means back.
            else if (_selected == this.BackSelector)
                selecteduid = null;
            // selection do not match any element. Try again.
            else
                this._pick(ref selecteduid);
        }

        private void Draw()
        {
            Console.Clear();
            Console.WriteLine("===== " + this.Caption + " =====");
            // displays all items in the Menu object.
            // uses the 'Caption' property and '...' is added if the menu item contains sub elements.
            foreach (Menu item in this.Items)
                Console.WriteLine("[" + item.Selector + "]" +
                                    " " + item.Caption +
                                    (item.Items != null && item.Items.Any() ? "..." : ""));
            // displays the 'Back' item if the 'BackSelector' property has been set.
            if (!string.IsNullOrEmpty(BackSelector)) 
                Console.WriteLine("\n[" + BackSelector + "] Back");
            Console.WriteLine("");
            Console.Write("> ");

        }

    }
}
