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
            public int AP { get; set; }
            public int RP { get; set; }
            public string Label { get; set; }
        }

        public List<Format_Detail> GetAll()
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var L2Enty = from c in entities.fuzzy_label.AsNoTracking()
                             orderby c.AP ascending
                             select c;

                return L2Enty.Select(s => new Format_Detail()
                {
                    AP = s.AP,
                    RP = s.RP,
                    Label = s.Label
                }).ToList<Format_Detail>();
            }
        }
    }
}