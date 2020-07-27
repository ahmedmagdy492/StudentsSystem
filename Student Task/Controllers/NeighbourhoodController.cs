using Student_Task.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Student_Task.Controllers
{
    public class NeighbourhoodController : Controller
    {
        private readonly INeighborhoodRepository _neighborhood;

        public NeighbourhoodController(INeighborhoodRepository neighborhood)
        {
            _neighborhood = neighborhood;
        }

        // GET: Neighbourhood
        public async Task<ActionResult> Index(int govId)
        {
            var allNeighs = await _neighborhood.GetNeighborhoodsOfGovernrate(govId);
            return PartialView("_GetNeighbourhoods", allNeighs);
        }
    }
}