using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ftc_project_api.Models;

namespace ftc_project_api.Controllers
{
    public class fuzzy_membershipController : ApiController
    {
        [Route("api/fuzzy_membership")]
        public IEnumerable<fuzzy_membershipModel.Format_Detail> GetAll()
        {
            fuzzy_membershipModel model = new fuzzy_membershipModel();
            return model.GetAll();
        }
    }
}
