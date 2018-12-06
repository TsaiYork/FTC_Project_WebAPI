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
    public class fuzzy_membershipController : ApiController
    {
        [Route("api/fuzzy_membership")]
        public IEnumerable<fuzzy_membershipModel.Format_Detail> GetAll()
        {
            fuzzy_membershipModel model = new fuzzy_membershipModel();
            return model.GetAll();
        }

        [Route("api/fuzzy_membership")]
        public HttpResponseMessage Post([FromBody] fuzzy_membershipModel.Create_Detail dataModel)
        {
            try
            {
                using (ftc_projectEntities entities = new ftc_projectEntities())
                {
                    fuzzy_membership newModel = new fuzzy_membership();
                    newModel.BeaconMinor = dataModel.BeaconMinor;
                    newModel.Label = dataModel.Label;
                    newModel.Samples = dataModel.Samples;
                    newModel.Max = dataModel.Max;
                    newModel.Min = dataModel.Min;                
                    newModel.Mean = dataModel.Mean;
                    newModel.SD = dataModel.SD;
                    entities.fuzzy_membership.Add(newModel);
                    entities.SaveChanges();

                    var msg = Request.CreateResponse(HttpStatusCode.Created, newModel);
                    return msg;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
