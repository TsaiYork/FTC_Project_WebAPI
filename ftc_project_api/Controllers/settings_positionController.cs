using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data_Access;
using ftc_project_api.Models;


namespace ftc_project_api.Controllers
{
    public class settings_positionController : ApiController
    {
        [Route("api/settings_position")]
        public IEnumerable<settings_positionModel.Format_Detail> GetAll()
        {
            settings_positionModel model = new settings_positionModel();
            return model.GetAll();
        }
    }
}
