using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business
{
    public class Menu
    {
        private int idMenu { get; set; }
        private string nameMenu { get; set; }
        private string link { get; set; }
        private int positionOrder { get; set; }

        public Menu(int idMenu, string nameMenu, string link, int positionOrder)
        {
            this.idMenu = idMenu;
            this.nameMenu = nameMenu;
            this.link = link;
            this.positionOrder = positionOrder;
        }
    }
}
