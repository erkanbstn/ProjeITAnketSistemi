using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OpsiyonManager : IOpsiyonService
    {
        IOpsiyonDal _OpsiyonDal;
        public OpsiyonManager(IOpsiyonDal OpsiyonDal)
        {
            _OpsiyonDal = OpsiyonDal;
        }

        public List<TOpsiyon> GenelListele()
        {
            return _OpsiyonDal.TList();
        }

        public TOpsiyon NesneBul(int id)
        {
            return _OpsiyonDal.TGetID(b => b.OpsiyonID == id);
        }

        public void NesneDuzenle(TOpsiyon t)
        {
            _OpsiyonDal.TUpdate(t);
        }

        public void NesneEkle(TOpsiyon t)
        {
            _OpsiyonDal.TAdd(t);
        }

        public List<TOpsiyon> NesneListele(int id)
        {
            return _OpsiyonDal.TIDList(b => b.OpsiyonID == id);
        }

        public void NesneSil(TOpsiyon t)
        {
            _OpsiyonDal.TDelete(t);
        }

        public List<TOpsiyon> SoruOpsiyonListele(int id)
        {
           return _OpsiyonDal.SoruOpsiyonListele(id);
        }
    }
}
