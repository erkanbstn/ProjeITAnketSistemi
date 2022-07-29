using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnketSistem.Models
{
    public class SoruOpsiyonViewModel
    {
        public IEnumerable<TSoru> Sorular { get; set; }
        public IEnumerable<TOpsiyon> Opsiyonlar{ get; set; }
    }
}