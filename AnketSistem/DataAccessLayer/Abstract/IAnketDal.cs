﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAnketDal : IRepositoryDal<TAnket>
    {
        List<TAnket> SirketAnketListe(int id);
        List<TAnket> SirketAnketSonListe(int id);
        int ToplamAnket(int id);

    }
}
