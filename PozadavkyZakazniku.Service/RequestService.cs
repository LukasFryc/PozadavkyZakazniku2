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
    public class RequestService : IRequestService
    {
        readonly IRequestRepository requestRepository;


        public RequestService(IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public RequestModel GetRequest(int ID)
        {
            return requestRepository.GetRequest(ID);

        }

        public ICollection<RequestModel> GetRequests()
        {

            return requestRepository.GetRequests();

        }

        public RequestModel CreateRequest(RequestModel request)
        {
            return requestRepository.CreateRequest(request);

        }


        public void DeleteRequest(int ID)
        {
            requestRepository.DeleteRequest(ID);

        }

        public RequestModel UpdateRequest(RequestModel request)
        {
            return requestRepository.UpdateRequest(request);
        }

    }
}
