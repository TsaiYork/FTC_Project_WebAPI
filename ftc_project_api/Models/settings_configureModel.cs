using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data_Access;

namespace ftc_project_api.Models
{
    public class settings_configureModel
    {
        public class Format_Detail
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public List<Format_Detail> GetAll()
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var L2Enty = from c in entities.settings_configure.AsNoTracking()
                             orderby c.Id
                             select c;

                return L2Enty.Select(s => new Format_Detail()
                {
                    Id = s.Id,
                    Type = s.Type,
                    Name = s.Name,
                    Value = s.Value
                }).ToList<Format_Detail>();
            }
        }
    }
}