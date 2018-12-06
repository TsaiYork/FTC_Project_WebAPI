using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ftc_project_api.Models;

namespace ftc_project_api.Controllers
{
    public class settings_configureController : ApiController
    {
        [Route("api/settings_configure")]
        public IEnumerable<settings_configureModel.Format_Detail> GetAll()
        {
            settings_configureModel model = new settings_configureModel();
            return model.GetAll();
        }
    }
}
