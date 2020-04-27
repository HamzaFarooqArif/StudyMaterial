using IbmAdmissions2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbmAdmissions2019.Utilities
{
    public class TestCenterUtility
    {
        private IbmAdmissions2019Entities db;
        private static TestCenterUtility _instance;

        private TestCenterUtility()
        {
            db = new IbmAdmissions2019Entities();
        }
        public static TestCenterUtility getInstance()
        {
            if (_instance == null)
                _instance = new TestCenterUtility();
            return _instance;
        }

        public List<TestCenterViewModel> getList(int blockId)
        {
            var list = db.TestCenters.Where(a => a.BlockId == blockId).Select(b => new TestCenterViewModel()
            {
                BlockId = b.BlockId,
                CenterName  = b.CenterName,
                Directions = b.Directions,
                Capacity = b.Capacity,
                CenterId = b.CenterId
            }).ToList();
            return list;
        }

        public bool addTestCenter(TestCenterViewModel obj)
        {
            try
            {
                TestCenter dbObj = new TestCenter();
                dbObj.CenterName = obj.CenterName;
                dbObj.Directions = obj.Directions;
                dbObj.Capacity = obj.Capacity;
                dbObj.BlockId = obj.BlockId;

                db.TestCenters.Add(dbObj);
                db.SaveChanges();

                return true;
            }catch(Exception ex)
            {

                throw (ex);
            }
        }
        public bool deleteTestCenter(int id, TestCenterViewModel obj)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            foreach(TestCenter t in db.TestCenters)
            {
                if(t.CenterId == id)
                {
                    foreach(TestCenterSlot st in db.TestCenterSlots)
                    {
                        if(st.CenterId == id)
                        {
                            db.TestCenterSlots.Remove(st);
                        }
                    }
                    db.TestCenters.Remove(t);
                }
            }

            db.SaveChanges();
            return true;
        }
        public TestCenterViewModel EditTestCenter(int id)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            TestCenterViewModel tst = new TestCenterViewModel();
            foreach(TestCenter t in db.TestCenters)
            {
                if(t.CenterId == id)
                {
                    tst.Capacity = t.Capacity;
                    tst.CenterName = t.CenterName;
                    tst.Directions = t.Directions;
                    tst.BlockId = t.BlockId;
                    break;
                }
            }
            return tst;
        }

        public bool updateTestCenter(int id, TestCenterViewModel obj)
        {
            if (!db.TestCenters.Any(b => b.CenterId == id)) return false;
            db.TestCenters.Where(tmp => tmp.CenterId == id).FirstOrDefault().CenterName = obj.CenterName;
            db.TestCenters.Where(tmp => tmp.CenterId == id).FirstOrDefault().Directions = obj.Directions;
            db.TestCenters.Where(tmp => tmp.CenterId == id).FirstOrDefault().Capacity = obj.Capacity;
            db.TestCenters.Where(tmp => tmp.CenterId == id).FirstOrDefault().BlockId = obj.BlockId;

            db.SaveChanges();
            return true;
        }
    }

}