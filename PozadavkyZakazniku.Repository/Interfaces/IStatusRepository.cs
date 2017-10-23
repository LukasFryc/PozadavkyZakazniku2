using System;
using System.Collections.Generic;
using PozadavkyZakazniku.Model;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozadavkyZakazniku.Repository.Interfaces  
{
    public interface IStatusRepository
    {
        StatusModel CreateStatus(StatusModel status);
        void DeleteStatus(int ID);
        StatusModel GetStatus(int ID);
        ICollection<StatusModel> GetStatuses();
        StatusModel UpdateStatus(StatusModel status);
    }
}
