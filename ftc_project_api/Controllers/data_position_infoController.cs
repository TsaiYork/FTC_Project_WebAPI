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
    public class data_position_infoController : ApiController
    {
        [Route("api/data_position_info")]
        public IEnumerable<data_position_infoModel.Format_Detail> GetAll()
        {
            data_position_infoModel model = new data_position_infoModel();
            return model.GetAll();
        }

        [Route("api/data_position_info/{id}")]
        public IEnumerable<data_position_infoModel.Format_Detail> GetById(int id)
        {
            data_position_infoModel model = new data_position_infoModel();
            return model.GetById(id);
        }

        [Route("api/data_position_info")]
        public HttpResponseMessage Post([FromBody] data_position_infoModel.Create_Detail dataModel)
        {
            try
            {
                using (ftc_projectEntities entities = new ftc_projectEntities())
                {
                    data_position_info newModel = new data_position_info();
                    newModel.UserId = dataModel.UserId;
                    newModel.Position = dataModel.Position;
                    newModel.TimeStamp = DateTime.Now;
                    entities.data_position_info.Add(newModel);
                    entities.SaveChanges();

                    var msg = Request.CreateResponse(HttpStatusCode.Created, newModel);
                    return msg;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
