using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozadavkyZakazniku.Model;
using PozadavkyZakazniku.Repository.Interfaces;
using PozadavkyZakazniku.Service.Interfaces;

namespace PozadavkyZakazniku.Service
{
    public class ModuleService : IModuleService
    {
        readonly IModuleRepository moduleRepository;


        public ModuleService(IModuleRepository moduleRepository)
        {
            this.moduleRepository = moduleRepository;
        }

        public ModuleModel GetModule(int ID)
        {
            return moduleRepository.GetModule(ID);

        }

        public ICollection<ModuleModel> GetModules()
        {

            return moduleRepository.GetModules();

        }

        public ModuleModel CreateModule(ModuleModel module)
        {
            return moduleRepository.CreateModule(module);

        }


        public void DeleteModule(int ID)
        {
            moduleRepository.DeleteModule(ID);

        }

        public ModuleModel UpdateModule(ModuleModel module)
        {
            return moduleRepository.UpdateModule(module);
        }

    }
}
