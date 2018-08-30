using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business
{
    public class SubModule
    {
        private int idSubModule { get; set; }
        private string nameSubModule { get; set; }
        private string iconSubModule { get; set; }
        private string linkSubModule { get; set; }
        private int positionSubModule { get; set; }
        private List<Menu> listMenus { get; set; }

        public SubModule(int idSubModule, string nameSubModule, string iconSubModule, string linkSubModule, int positionSubModule, List<Menu> listMenus)
        {
            this.idSubModule = idSubModule;
            this.nameSubModule = nameSubModule;
            this.iconSubModule = iconSubModule;
            this.linkSubModule = linkSubModule;
            this.positionSubModule = positionSubModule;
            this.listMenus = listMenus;
        }
    }
}
