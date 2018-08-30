using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apHaylliSeguridad.Business
{
    public class Module
    {
        private int idModule { get; set; }
        private string nameModule { get; set; }
        private string iconModule { get; set; }
        private bool child { get; set; }
        private int position { get; set; }
        private List<SubModule> submodules = new List<SubModule>();

        public Module(int idModule, string nameModule, string iconModule, bool child, int position,List<SubModule> submodules)
        {
            this.idModule = idModule;
            this.nameModule = nameModule;
            this.iconModule = iconModule;
            this.child = child;
            this.position = position;
            this.submodules = submodules;
        }
    }
}
