using PozadavkyZakazniku.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PozadavkyZakazniku.Repository.Interfaces
{
    public interface IModuleRepository
    {
        ModuleModel CreateModule(ModuleModel module);
        void DeleteModule(int ID);
        ModuleModel GetModule(int ID);
        ICollection<ModuleModel> GetModules();
        ModuleModel UpdateModule(ModuleModel module);
    }
}
