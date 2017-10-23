using System.Collections.Generic;
using PozadavkyZakazniku.Model;


namespace PozadavkyZakazniku.Service.Interfaces
{
    public interface IRequestService
    { 
    RequestModel CreateRequest(RequestModel request);
    void DeleteRequest(int ID);
    RequestModel GetRequest(int ID);
    ICollection<RequestModel> GetRequests();
    RequestModel UpdateRequest(RequestModel request);
    
    }
}
