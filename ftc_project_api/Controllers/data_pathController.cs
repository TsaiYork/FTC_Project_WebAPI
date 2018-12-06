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
    public class data_pathController : ApiController
    {
        //select type, position from data_path where type=-2
        [Route("api/data_path/GetTypeEqualM2")]
        public IEnumerable<data_pathModel.Format_Detail> GetTypeEqualM2()
        {
            data_pathModel model = new data_pathModel();
            return model.GetTypeEqualM2();
        }

        //select position from data_path where type>=0
        //select type, position from data_path where type>=0 order by type 
        [Route("api/data_path/GetTypeLargeThan0")]
        public IEnumerable<data_pathModel.Format_Detail> GetTypeLargeThan0()
        {
            data_pathModel model = new data_pathModel();
            return model.GetTypeLargeThan0();
        }

        //"UPDATE data_path SET position=" + SP.Text + " WHERE type=0 "
        [Route("api/data_path/UpdateWhereType0")]
        public HttpResponseMessage PutWhereType0([FromBody]int position)
        {
            try
            {
                using (ftc_projectEntities entities = new ftc_projectEntities())
                {

                    var entity = entities.data_path.FirstOrDefault(e => e.Type == 0);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Type 0 Not Gound");
                    }
                    else
                    {
                        entity.Position = position;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //UPDATE data_path SET position=" + EP.Text + " WHERE type=-1
        [Route("api/data_path/UpdateWhereTypeM1")]
        public HttpResponseMessage PutWhereTypeM1([FromBody]int position)
        {
            try
            {
                using (ftc_projectEntities entities = new ftc_projectEntities())
                {

                    var entity = entities.data_path.FirstOrDefault(e => e.Type == -1);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Type 0 Not Gound");
                    }
                    else
                    {
                        entity.Position = position;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //UPDATE data_path SET position=" + 1 + " WHERE type=-2
        [Route("api/data_path/UpdateWhereTypeM2")]
        public HttpResponseMessage PutWhereTypeM2([FromBody]int position)
        {
            try
            {
                using (ftc_projectEntities entities = new ftc_projectEntities())
                {

                    var entity = entities.data_path.FirstOrDefault(e => e.Type == -2);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Type 0 Not Gound");
                    }
                    else
                    {
                        entity.Position = position;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
