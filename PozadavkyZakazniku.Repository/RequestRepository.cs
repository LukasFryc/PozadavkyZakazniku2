using AutoMapper;
using PozadavkyZakazniku.Model;
using PozadavkyZakazniku.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozadavkyZakazniku.Repository
{
    public class RequestRepository : IRequestRepository
    {
            public RequestModel GetRequest(int ID)
            {
                using (DbRequest db = new DbRequest())
                {
                    return Mapper.Map<RequestModel>(db.Requests.Where(r => r.RequestID == ID).Select(r => r).FirstOrDefault());
                }

            }

            public ICollection<RequestModel> GetRequests()
            {
                using (DbRequest db = new DbRequest())
                {
                    return Mapper.Map<ICollection<RequestModel>>(db.Requests.Select(r => r));

                }
            }

            public RequestModel CreateRequest(RequestModel request)
            {
                using (DbRequest db = new DbRequest())
                {
                    var newRequest = db.Requests.Add(Mapper.Map<Request>(request));

                    db.SaveChanges();

                    //user.UserID = newUser.UserID;
                    //return user;

                    return Mapper.Map<RequestModel>(newRequest);

                }

            }


            public void DeleteRequest(int ID)
            {
                using (DbRequest db = new DbRequest())
                {

                    db.Requests.RemoveRange(db.Requests.Where(u => u.RequestID == ID));
                    db.SaveChanges();
                }

            }
            public RequestModel UpdateRequest(RequestModel request)
            {

                using (DbRequest db = new DbRequest())
                {
                    var requestdb = db.Requests.Where(u => u.RequestID == request.RequestID).Select(u => u).FirstOrDefault();

                    requestdb = Mapper.Map<Request>(request);
                    //Mapper.Map(user, userdb); -david
                    // co mapuji do ceho
                    db.SaveChanges();

                }
                return request;
            }


       
    }
}
