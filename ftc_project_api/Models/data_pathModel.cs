using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data_Access;

namespace ftc_project_api.Models
{
    public class data_pathModel
    {
        public class Format_Detail
        {
            public int Id { get; set; }
            public int Type { get; set; }
            public int Position { get; set; }
        }

        //select type, position from data_path where type=-2 
        public List<Format_Detail> GetTypeEqualM2()
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var L2Enty = from c in entities.data_path.AsNoTracking()
                             where c.Type == -2
                             select c;

                return L2Enty.Select(s => new Format_Detail()
                {
                    Type = s.Type,
                    Position = s.Position,
                }).ToList<Format_Detail>();
            }
        }

        //select position from data_path where type>=0
        //select type, position from data_path where type>=0 order by type 
        public List<Format_Detail> GetTypeLargeThan0()
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var L2Enty = from c in entities.data_path.AsNoTracking()
                             where c.Type >= 0
                             orderby c.Type
                             select c;

                return L2Enty.Select(s => new Format_Detail()
                {
                    Type = s.Type,
                    Position = s.Position,
                }).ToList<Format_Detail>();
            }
        }

        public void UpdateWhereType0(int position)
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var existingEntities = from c in entities.data_path.AsNoTracking()
                                     where c.Type == 0
                                     select c;
                var existingEntity = existingEntities.Where(e => e.Type == 0).FirstOrDefault();
                existingEntity.Position = position;
                entities.SaveChanges();
            }
        }

        public void UpdateWhereTypem1(int position)
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var existingEntities = from c in entities.data_path.AsNoTracking()
                                       where c.Type == -1
                                       select c;
                var existingEntity = existingEntities.Where(e => e.Type == -1).FirstOrDefault();
                existingEntity.Position = position;
                entities.SaveChanges();
            }
        }

        public void UpdateWhereTypem2()
        {
            using (ftc_projectEntities entities = new ftc_projectEntities())
            {
                var existingEntities = from c in entities.data_path.AsNoTracking()
                                       where c.Type == -2
                                       select c;
                var existingEntity = existingEntities.Where(e => e.Type == -2).FirstOrDefault();
                existingEntity.Position = 1;
                entities.SaveChanges();
            }
        }
    }
}