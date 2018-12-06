using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data_Access;

namespace ftc_project_api.Models
{
    public class settings_positionModel
    {
        public class Format_Detail
        {
            public int Id { get; set; }
            public int Position { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Area { get; set; }
        }

        public List<Format_Detail> GetAll()
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var L2Enty = from c in entities.settings_position.AsNoTracking()
                             orderby c.Id
                             select c;

                return L2Enty.Select(s => new Format_Detail()
                {
                    Id = s.Id,
                    Position = s.Position,
                    X = s.X,
                    Y = s.Y,
                    Area = s.Area
                }).ToList<Format_Detail>();
            }
        }
    }
}