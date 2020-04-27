using IbmAdmissions2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbmAdmissions2019.Utilities
{
    public class AssisstantUtility
    {
        private static AssisstantUtility _instance;
        public static AssisstantUtility getInstance()
        {
            if (_instance == null)
                _instance = new AssisstantUtility();
            return _instance;
        }
        public List<ApplicationListViewModel> getAppplicantList(int? id)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            List<ApplicationListViewModel> lst = new List<ApplicationListViewModel>();
            var s = db.Students.Where(a => a.StudentPrograms.FirstOrDefault().Program.Degree.DegreeId == id);
            foreach(Student st in s)
            {
                ApplicationListViewModel obj = new ApplicationListViewModel();
                if(st.IsApplicationConfirmed)
                {
                    //int t = db.StudentTests.Where(b => b.StudentId == s.FirstOrDefault().Id).FirstOrDefault().TestId;
                    string t = Convert.ToString(db.StudentTests.Where(b => b.StudentId == st.Id).FirstOrDefault().IsPaid);
                    if (string.IsNullOrEmpty(t))
                    {
                        obj.PaymentStatus = "Not Confirmed";
                    }
                    else
                    {
                        obj.PaymentStatus = "Confirmed";
                    }
                   
                    obj.CNIC = st.StudentCnic;
                    obj.Name = st.Name;
                    obj.TrackingNumber = db.StudentTests.Where(b => b.StudentId == st.Id).FirstOrDefault().TrackingNumber;
                    lst.Add(obj);
                }  
         }
            return lst;    
        }

        
    }
}
