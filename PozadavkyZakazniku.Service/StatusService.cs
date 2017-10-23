using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PozadavkyZakazniku.Model;
using PozadavkyZakazniku.Repository.Interfaces;
using PozadavkyZakazniku.Service.Interfaces;
using PozadavkyZakazniku.Repository;

namespace PozadavkyZakazniku.Service
{
    public class StatusService : IStatusService
    {
        readonly IStatusRepository statusRepository;


        public StatusService(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }

        public StatusModel GetStatus(int ID)
        {
            return statusRepository.GetStatus(ID);

        }

        public ICollection<StatusModel> GetStatuses()
        {

            return statusRepository.GetStatuses();

        }

        public StatusModel CreateStatus(StatusModel status)
        {
            return statusRepository.CreateStatus(status);

        }


        public void DeleteStatus(int ID)
        {
            statusRepository.DeleteStatus(ID);

        }

        public StatusModel UpdateStatus(StatusModel status)
        {
            return statusRepository.UpdateStatus(status);
        }
    }
}
