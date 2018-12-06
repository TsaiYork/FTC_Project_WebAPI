using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ftc_project_api.Models
{
    public class data_position_infoModel
    {
        public class Format_Detail
        {
            public int Id { get; set; }
            public System.DateTime TimeStamp { get; set; }
            public int UserId { get; set; }
            public int Position { get; set; }
        }

        public class Create_Detail
        {
            public int UserId { get; set; }
            public int Position { get; set; }
        }

        public List<Format_Detail> GetAll()
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var L2Enty = from c in entities.data_position_info.AsNoTracking()
                             orderby c.TimeStamp
                             select c;

                return L2Enty.Select(s => new Format_Detail()
                {
                    Id = s.Id,
                    TimeStamp = s.TimeStamp,
                    Position = s.Position,
                    UserId = s.UserId
                }).ToList<Format_Detail>();
            }
        }

        public List<Format_Detail> GetById(int id)
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var L2Enty = from c in entities.data_position_info.AsNoTracking()
                             where c.UserId == id
                             orderby c.TimeStamp
                             select c;

                return L2Enty.Select(s => new Format_Detail()
                {
                    Id = s.Id,
                    TimeStamp = s.TimeStamp,
                    Position = s.Position,
                    UserId = s.UserId
                }).ToList<Format_Detail>();
            }
        }
    }
}