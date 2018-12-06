using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ftc_project_api.Models;

namespace ftc_project_api.Controllers
{
    public class fuzzy_labelController : ApiController
    {
        [Route("api/fuzzy_label")]
        public IEnumerable<fuzzy_labelModel.Format_Detail> Get()
        {
            fuzzy_labelModel model = new fuzzy_labelModel();
            return model.GetAll();
        }
    }
}
