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
    public class fuzzy_labelController : ApiController
    {
        [Route("api/fuzzy_label")]
        public IEnumerable<fuzzy_labelModel.Format_Detail> Get()
        {
            fuzzy_labelModel model = new fuzzy_labelModel();
            return model.GetAll();
        }

        [Route("api/fuzzy_label")]
        public HttpResponseMessage Post([FromBody] fuzzy_labelModel.Create_Detail dataModel)
        {
            try
            {
                using (ftc_projectEntities entities = new ftc_projectEntities())
                {
                    fuzzy_label newModel = new fuzzy_label();
                    newModel.Position= dataModel.Position;
                    newModel.BeaconMinor = dataModel.BeaconMinor;
                    newModel.Position = dataModel.Position;
                    newModel.Label = dataModel.Label;
                    entities.fuzzy_label.Add(newModel);
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

        [Route("api/fuzzy_label_N")]
        public IEnumerable<fuzzy_labelModel.Format_Detail> Getfuzzy_label_N(int BeaconMinor)
        {
            fuzzy_labelModel model = new fuzzy_labelModel();
            return model.GetByIdandLabel_N(BeaconMinor);
        }

        [Route("api/fuzzy_label_M")]
        public IEnumerable<fuzzy_labelModel.Format_Detail> Getfuzzy_label_M(int BeaconMinor)
        {
            fuzzy_labelModel model = new fuzzy_labelModel();
            return model.GetByIdandLabel_M(BeaconMinor);
        }

        [Route("api/fuzzy_label_F")]
        public IEnumerable<fuzzy_labelModel.Format_Detail> Getfuzzy_label_F(int BeaconMinor)
        {
            fuzzy_labelModel model = new fuzzy_labelModel();
            return model.GetByIdandLabel_F(BeaconMinor);
        }
    }
}
