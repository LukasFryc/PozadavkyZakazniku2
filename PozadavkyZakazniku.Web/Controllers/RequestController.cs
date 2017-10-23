using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PozadavkyZakazniku.Service.Interfaces;
using PozadavkyZakazniku.Model;

namespace PozadavkyZakazniku.Web.Controllers
{
    public class RequestController : Controller
    {
        readonly IRequestService requestService;

        public RequestController(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        // GET: Request
        public ActionResult Index()
        {
            ICollection<RequestModel> pozadavky = requestService.GetRequests();
            return View(pozadavky);
        }

        public ActionResult Detail(int ID)
        {
            RequestModel pozadavek = requestService.GetRequest(ID);
            return View(pozadavek);
        }

        [HttpPost]
        public ActionResult Create(RequestModel request)
        {
            RequestModel pozadavek = requestService.CreateRequest(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        public ActionResult Delete(int ID)
        {
            requestService.DeleteRequest(ID);
            return RedirectToAction("Index");
        }
    }
}