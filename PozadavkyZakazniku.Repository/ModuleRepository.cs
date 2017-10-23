using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozadavkyZakazniku.Model;
using AutoMapper;
using PozadavkyZakazniku.Repository.Interfaces;
namespace PozadavkyZakazniku.Repository
{
   public class ModuleRepository : IModuleRepository
    {

        public ModuleModel GetModule(int ID)
        {
            using (DbRequest db = new DbRequest())
            {
                return Mapper.Map<ModuleModel>(db.Modules.Where(u => u.ModuleID == ID).Select(u => u).FirstOrDefault());
            }

        }

        public ICollection<ModuleModel> GetModules()
        {
            using (DbRequest db = new DbRequest())
            {
                return Mapper.Map<ICollection<ModuleModel>>(db.Modules.Select(u => u));

            }
        }

        public ModuleModel CreateModule(ModuleModel module)
        {
            using (DbRequest db = new DbRequest())
            {
                var newModule = db.Modules.Add(Mapper.Map<Module>(module));

                db.SaveChanges();

                //module.ID = new.ID;
                //return module;

                return Mapper.Map<ModuleModel>(newModule);

            }

        }


        public void DeleteModule(int ID)
        {
            using (DbRequest db = new DbRequest())
            {

                db.Modules.RemoveRange(db.Modules.Where(u => u.ModuleID == ID));
                db.SaveChanges();
            }

        }

        public ModuleModel UpdateModule(ModuleModel module)
        {
            using (DbRequest db = new DbRequest())
            {
                var moduledb = db.Modules.Where(u => u.ModuleID == module.ModuleID).Select(u => u).FirstOrDefault();

                moduledb = Mapper.Map<Module>(module);
                //Mapper.Map(module, moduledb); -david
                // co mapuji do ceho
                db.SaveChanges();

            }
            return module;
        }
    }
}
