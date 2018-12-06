using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ftc_project_api.Models
{
    public class data_allModel
    {
        public class Format_Detail
        {
            public int Id { get; set; }
            public System.DateTime TimeStamp { get; set; }
            public int Position { get; set; }
            public int BeaconMinor { get; set; }
            public double RSS { get; set; }
        }

        public class Create_Detail
        {
            public int Position { get; set; }
            public int BeaconMinor { get; set; }
            public double RSS { get; set; }
        }

        public List<Format_Detail> GetAll()
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var L2Enty = from c in entities.data_all.AsNoTracking()
                             orderby c.Id
                             select c;

                return L2Enty.Select(s => new Format_Detail()
                {
                    Id = s.Id,
                    TimeStamp = s.TimeStamp,
                    Position = s.Position,
                    BeaconMinor = s.BeaconMinor,
                    RSS = s.RSS
                }).ToList<Format_Detail>();
            }
        }

        public List<Format_Detail> GetById(int id)
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var L2Enty = from c in entities.data_all.AsNoTracking()
                             where c.Id == id
                             orderby c.TimeStamp
                             select c;

                return L2Enty.Select(s => new Format_Detail()
                {
                    Id = s.Id,
                    TimeStamp = s.TimeStamp,
                    Position = s.Position,
                    BeaconMinor = s.BeaconMinor,
                    RSS = s.RSS
                }).ToList<Format_Detail>();
            }
        }
    }
}