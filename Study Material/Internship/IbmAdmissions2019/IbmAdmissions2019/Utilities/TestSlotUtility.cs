using IbmAdmissions2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbmAdmissions2019.Utilities
{
    public class TestSlotUtility
    {
        private IbmAdmissions2019Entities db;
        private static TestSlotUtility _instance;

        private TestSlotUtility()
        {
            db = new IbmAdmissions2019Entities();
        }
        public static TestSlotUtility getInstance()
        {
            if (_instance == null)
                _instance = new TestSlotUtility();
            return _instance;
        }

        public List<TestSlotViewModel> getList(int testCenterId)
        {
            var list = db.TestCenterSlots.Where(c => c.CenterId == testCenterId).Select(b => new TestSlotViewModel()
            {
                CenterId = b.CenterId,
                CenterName = b.TestCenter.CenterName,
                SlotId = b.SlotId,
                TestDateTime = b.TestDateTime,
                RollNumberEnd = b.RollNumberEnd == null ? 0 : b.RollNumberEnd.Value,
                RollNumberStart = b.RollNumberStart == null ? 0 : b.RollNumberStart.Value,
            }).ToList();
            return list;
        }


        public  TestSlotViewModel EditTestSlot(int id)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            TestSlotViewModel t = new TestSlotViewModel();
           // TestCenterViewModel t = new TestCenterViewModel();
            foreach(TestCenterSlot tst in db.TestCenterSlots)
            {
                if(tst.SlotId == id)
                {
                    t.CenterId = tst.CenterId;
                    t.TestDateTime = tst.TestDateTime;
                    //t.RollNumberStart = (int)tst.RollNumberStart;
                    //t.RollNumberEnd =(int) tst.RollNumberEnd;
                    break;
                }
            }
            return t;
        }
        public bool addTestSlot(TestSlotViewModel obj)
        {
            try
            {
                TestCenterSlot dbObj = new TestCenterSlot();
                dbObj.CenterId = obj.CenterId;
                dbObj.TestDateTime = obj.TestDateTime;
                db.TestCenterSlots.Add(dbObj);
                db.SaveChanges();
                return true;
            }catch
            {
                return false;
            }
        }

        public bool DeleteTestSlots(int id, TestSlotViewModel obj)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            foreach(TestCenterSlot s in db.TestCenterSlots)
            {
                if(s.SlotId== id)
                {
                    db.TestCenterSlots.Remove(s);
                }
            }
            db.SaveChanges();
            return true;
        }

        public bool CreateRollNumberSlots(int testId)
        {

            var blocks = db.Blocks.Where(a => a.TestId == testId).ToList();
            var slotsTimeList = db.Blocks.Join(db.TestCenters, a => a.BlockId, b => b.BlockId,(a,b)=>new { a, b })
                .Join(db.TestCenterSlots,c=>c.b.CenterId,d=>d.CenterId,(c,d)=> new { c,d})
                .GroupBy(r=>r.d.TestDateTime).Select(n=>new TestSlotAssignmentModel()
                {
                    SlotDateTime = n.Key,
                    totalCapacity = n.Sum(x=>x.c.b.Capacity)
                }).ToList();
            int startRollNumber = 3299986;
            //int current = 0;
            int slotRollNumberCurrent=0;
            foreach (var ss in slotsTimeList)
            {
                ss.RollNumberStart = startRollNumber + slotRollNumberCurrent;
                ss.CurrentRollNumber = startRollNumber + slotRollNumberCurrent;
                slotRollNumberCurrent = slotRollNumberCurrent + ss.totalCapacity;
            }


            
            foreach (var b in blocks)
            {
               var centers= b.TestCenters.ToList() ;
            
                foreach (var c in centers)
                {
                 
                    var slots = c.TestCenterSlots.ToList();
                    foreach (var s in slots)
                    {
                       var currSlot= slotsTimeList.Where(a => a.SlotDateTime.Equals(s.TestDateTime)).First();

                        s.RollNumberStart = currSlot.CurrentRollNumber;
                        s.RollNumberEnd = currSlot.CurrentRollNumber+c.Capacity-1;
                        currSlot.CurrentRollNumber = currSlot.CurrentRollNumber + c.Capacity;
                        currSlot.usedCapacity = currSlot.usedCapacity + c.Capacity;
                        db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                }

            }
            return true;
        }

    }
}