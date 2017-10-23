using System.Collections.Generic;
using PozadavkyZakazniku.Model;


namespace PozadavkyZakazniku.Service.Interfaces
{
    public interface IStatusService
    {

        StatusModel CreateStatus(StatusModel status);
        void DeleteStatus(int ID);
        StatusModel GetStatus(int ID);
        ICollection<StatusModel> GetStatuses();
        StatusModel UpdateStatus(StatusModel status);
    }
}
