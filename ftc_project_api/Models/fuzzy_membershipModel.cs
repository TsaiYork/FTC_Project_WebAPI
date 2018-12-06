using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data_Access;

namespace ftc_project_api.Models
{
    public class fuzzy_membershipModel
    {
        public class Format_Detail
        {
            public int Id { get; set; }
            public int AP { get; set; }
            public string Label { get; set; }
            public int Samples { get; set; }
            public int Max { get; set; }
            public int Min { get; set; }
            public double Mean { get; set; }
            public double SD { get; set; }
        }

        public List<Format_Detail> GetAll()
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var L2Enty = from c in entities.fuzzy_membership.AsNoTracking()
                             orderby c.AP
                             select c;

                return L2Enty.Select(s => new Format_Detail()
                {
                    AP = s.AP,
                    Label = s.Label,
                    Max = s.Max,
                    Min = s.Min,
                    Mean = s.Mean,
                    Samples = s.Samples,
                    SD = s.SD
                }).ToList<Format_Detail>();
            }
        }
    }
}