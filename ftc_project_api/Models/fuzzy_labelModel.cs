using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data_Access;

namespace ftc_project_api.Models
{
    public class fuzzy_labelModel
    {
        public class Format_Detail
        {
            public int Id { get; set; }
            public int BeaconMinor { get; set; }
            public int Position { get; set; }
            public string Label { get; set; }
        }

        public class Create_Detail
        {
            public int BeaconMinor { get; set; }
            public int Position { get; set; }
            public string Label { get; set; }
        }
        public List<Format_Detail> GetAll()
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var L2Enty = from c in entities.fuzzy_label.AsNoTracking()
                             orderby c.BeaconMinor ascending
                             select c;

                return L2Enty.Select(s => new Format_Detail()
                {
                    BeaconMinor = s.BeaconMinor,
                    Position = s.Position,
                    Label = s.Label
                }).ToList<Format_Detail>();
            }
        }

        public List<Format_Detail> GetByIdandLabel_N(int selectBeaconMinor)
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var L2Enty = from c in entities.fuzzy_label.AsNoTracking()
                             where c.BeaconMinor == selectBeaconMinor && c.Label.Contains("N") 
                             select c;

                return L2Enty.Select(s => new Format_Detail()
                {
                    BeaconMinor = s.BeaconMinor,
                    Position = s.Position,
                    Label = s.Label
                }).ToList<Format_Detail>();
            }
        }

        public List<Format_Detail> GetByIdandLabel_M(int selectBeaconMinor)
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var L2Enty = from c in entities.fuzzy_label.AsNoTracking()
                             where c.BeaconMinor == selectBeaconMinor && c.Label.Contains("M")
                             select c;

                return L2Enty.Select(s => new Format_Detail()
                {
                    BeaconMinor = s.BeaconMinor,
                    Position = s.Position,
                    Label = s.Label
                }).ToList<Format_Detail>();
            }
        }

        public List<Format_Detail> GetByIdandLabel_F(int selectBeaconMinor)
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var L2Enty = from c in entities.fuzzy_label.AsNoTracking()
                             where c.BeaconMinor == selectBeaconMinor && c.Label.Contains("F")
                             select c;

                return L2Enty.Select(s => new Format_Detail()
                {
                    BeaconMinor = s.BeaconMinor,
                    Position = s.Position,
                    Label = s.Label
                }).ToList<Format_Detail>();
            }
        }
    }
}