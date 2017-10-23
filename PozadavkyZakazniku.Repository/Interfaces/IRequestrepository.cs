using PozadavkyZakazniku.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozadavkyZakazniku.Repository.Interfaces
{
    public interface IRequestRepository
    {
        RequestModel CreateRequest(RequestModel request);
        void DeleteRequest(int ID);
        RequestModel GetRequest(int ID);
        ICollection<RequestModel> GetRequests();
        RequestModel UpdateRequest(RequestModel request);
    }
}
