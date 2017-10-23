using System.Collections.Generic;
using PozadavkyZakazniku.Model;


namespace PozadavkyZakazniku.Service.Interfaces
{
    public interface IModuleService
    {

        ModuleModel CreateModule(ModuleModel module);
        void DeleteModule(int ID);
        ModuleModel GetModule(int ID);
        ICollection<ModuleModel> GetModules();
        ModuleModel UpdateModule(ModuleModel module);
    }
}
