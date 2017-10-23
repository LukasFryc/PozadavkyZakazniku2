using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozadavkyZakazniku.Model;
using AutoMapper;
using PozadavkyZakazniku.Repository.Interfaces;

namespace PozadavkyZakazniku.Repository
{
   public  class StatusRepository : IStatusRepository
    {

        public StatusModel GetStatus(int ID)
        {
            using (DbRequest db = new DbRequest())
            {
                return Mapper.Map<StatusModel>(db.Statuses.Where(u => u.StatusID == ID).Select(u => u).FirstOrDefault());
            }

        }

        public ICollection<StatusModel> GetStatuses()
        {
            using (DbRequest db = new DbRequest())
            {
                return Mapper.Map<ICollection<StatusModel>>(db.Statuses.Select(u => u));

            }
        }

        public StatusModel CreateStatus(StatusModel status)
        {
            using (DbRequest db = new DbRequest())
            {
                var newStatus = db.Statuses.Add(Mapper.Map<Status>(status));

                db.SaveChanges();

                //status.StatusID = newStatus.StatusID;
                //return status;

                return Mapper.Map<StatusModel>(newStatus);

            }

        }


        public void DeleteStatus(int ID)
        {
            using (DbRequest db = new DbRequest())
            {

                db.Statuses.RemoveRange(db.Statuses.Where(u => u.StatusID == ID));
                db.SaveChanges();
            }

        }

        public StatusModel UpdateStatus(StatusModel status)
        {
            using (DbRequest db = new DbRequest())
            {
                var statusdb = db.Statuses.Where(u => u.StatusID == status.StatusID).Select(u => u).FirstOrDefault();

                statusdb = Mapper.Map<Status>(status);
                //Mapper.Map(status, statusdb); -david
                // co mapuji do ceho
                db.SaveChanges();

            }
            return status;
        }
    }
}
