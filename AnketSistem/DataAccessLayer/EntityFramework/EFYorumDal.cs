﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFYorumDal : GenericRepository<TYorum>, IYorumDal
    {
        public List<TYorum> AnketYorum(int id)
        {
            using (var c = new Context())
            {
                return c.Yorums.Where(b => b.AnketID == id).ToList();
            }
        }

        public int ToplamYorum(int id)
        {
            using (var c = new Context())
            {
                return c.Yorums.Where(b => b.Personel.SirketID == id).Count();
            }
        }
    }
}
