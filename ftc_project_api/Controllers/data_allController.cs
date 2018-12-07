using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data_Access;
using System.Data.Entity;
using ftc_project_api.Models;

namespace ftc_project_api.Controllers
{
    public class data_allController : ApiController
    {
        [Route("api/data_all")]
        public IEnumerable<data_allModel.Format_Detail> GetAll()
        {
            data_allModel model = new data_allModel();
            return model.GetAll();
        }

        [Route("api/data_all/{id}")]
        public IEnumerable<data_allModel.Format_Detail> GetById(int id)
        {
            data_allModel model = new data_allModel();
            return model.GetById(id);
        }

        [Route("api/data_all")]
        public IEnumerable<data_allModel.Format_Detail> GetByPositionAndMinor(int Position, int BeaconMinor)
        {
            data_allModel model = new data_allModel();
            return model.GetByPostionAndMinor(Position,BeaconMinor);
        }

        [Route("api/data_all")]
        public HttpResponseMessage Post([FromBody] data_allModel.Create_Detail dataModel)
        {
            try
            {
                using (ftc_projectEntities entities = new ftc_projectEntities())
                {
                    data_all newModel = new data_all();
                    newModel.Position = dataModel.Position;
                    newModel.BeaconMinor = dataModel.BeaconMinor;
                    newModel.RSS = dataModel.RSS;
                    newModel.TimeStamp = DateTime.Now;
                    entities.data_all.Add(newModel);
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
