using IbmAdmissions2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IbmAdmissions2019.Utilities
{
    public class StudentUtility
    {

        private static StudentUtility _instance;
        private StudentUtility()
        {

        }

        public static StudentUtility getInstance()
        {
            if (_instance == null)
                _instance = new StudentUtility();
            return _instance;
        }

        public int getTrakingnumber(String cnic)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            var tset = db.Settings.Find("TrackingNumber");
            var tnum = tset.SettingValue;
            int num = Int32.Parse(tnum);
            var student = db.Students.Where(c => c.StudentCnic.Equals(cnic)).FirstOrDefault();

            var activeTest = db.EntryTests.Where(c => c.IsActive).FirstOrDefault().TestId;
            var flag = student.StudentTests.Where(a => a.TestId == activeTest).FirstOrDefault();
            if (flag != null)
                return flag.TrackingNumber;
            StudentTest sTest = new StudentTest();
            sTest.TrackingNumber = num;
            sTest.ChallanFormNumber = num;

            sTest.TestId = activeTest;
            sTest.StudentId = student.Id;
            db.StudentTests.Add(sTest);
            num++;
            tset.SettingValue = num + "";
            db.Entry(tset).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return sTest.TrackingNumber;


        }


        private string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public int getRollNumber(String cnic)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

            var bset = db.Settings.Find("CurrentBSRoll");
            var mset = db.Settings.Find("CurrentMSRoll");
            var bnum = bset.SettingValue;
            var mnum = mset.SettingValue;
            int num_bachelor = Int32.Parse(bnum);
            int num_master = Int32.Parse(mnum);
            var student = db.Students.Where(c => c.StudentCnic.Equals(cnic)).FirstOrDefault();
            if (student == null)
            {
                throw new Exception("Student:null");
            }
            var activeTest = db.EntryTests.Where(c => c.IsActive).FirstOrDefault().TestId;
            var sTest = student.StudentTests.Where(a => a.TestId == activeTest).FirstOrDefault();
            var deg = student.StudentPrograms.FirstOrDefault().Program.Degree;
            if (deg == null)
            {
                throw new Exception("Degree:null");
            }
            if (sTest.RollNumber.HasValue)
                return sTest.RollNumber.Value;
            sTest.IsPaid = true;
            if (deg.DegreeName.Equals("Undergraduate"))
            {
                TestCenterSlot slot = db.TestCenterSlots.Where(a => a.RollNumberStart <= num_bachelor && a.RollNumberEnd >= num_bachelor).FirstOrDefault();
                sTest.SlotId = slot.SlotId;
                sTest.RollNumber = num_bachelor;
                sTest.RollNumberGeneratedAt = DateTime.Now;
                sTest.TestUser = student.StudentCnic;
                sTest.TestPassword = RandomString(6);
                db.Entry(sTest).State = System.Data.Entity.EntityState.Modified;
                num_bachelor++;
                bset.SettingValue = num_bachelor + "";
                db.Entry(bset).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                sTest.RollNumber = num_master;
                sTest.RollNumberGeneratedAt = DateTime.Now;
                db.Entry(sTest).State = System.Data.Entity.EntityState.Modified;
                num_master++;
                mset.SettingValue = num_master + "";
                db.Entry(mset).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return sTest.RollNumber.Value;


        }




        public bool SubmitApplication(String cnic)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

            try
            {
                var student = db.Students.Where(c => c.StudentCnic.Equals(cnic)).FirstOrDefault();
                if (student != null)
                {
                    student.IsApplicationConfirmed = true;
                    db.Entry(student).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                    int tracking = getTrakingnumber(cnic);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public String getImagePath(String cnic)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

            String path = "/ProfileImages/dummyImg.jpg";
            var std = db.Students.Where(a => a.StudentCnic.Equals(cnic)).FirstOrDefault();
            if (std != null && std.PhotographPath != null)
            {
                path = "/ProfileImages/" + std.PhotographPath;
            }
            return path;
        }

        bool validateEducationItem(EducationItem obj)
        {
            if (obj.obtained == 0 || obj.total == 0 || obj.pointType == 0 || obj.educationDetail == 0)
                return false;
            else
                return true;
        }
        public bool AddStudent(StudentViewModels model)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

            bool isUpdate = true;
            var st = db.Students.Where(a => a.StudentCnic.Equals(model.cNIC)).FirstOrDefault();
            if (st == null)
            {
                st = new Student();
                isUpdate = false;
            }

            st.Name = model.name;
            st.Gender = model.gender;
            st.StudentCnic = model.cNIC;
            st.DateOfBirth = model.dOB.Value;
            st.FatherName = model.fatherName;
            st.FaherCnic = model.fatherCNIC;
            st.PostalAddress = model.address;
            st.PermanentAddress = model.perAddress;
            st.Religion = model.religion;
            st.ProvinceId = model.province;
            st.DistrictId = model.district;
            st.CityId = model.city;
            st.HomePhoneNo = model.homePhone;
            st.CellNo = model.cellNo;
            st.UserId = db.AspNetUsers.Where(temp => temp.UserName.Equals(model.cNIC)).FirstOrDefault().Id;

            if (model.SameAddressCheck) st.PermanentAddress = model.address;

            var eduHist = st.StudentEducations.ToList();
            foreach (var e in eduHist)
            {
                db.Entry(e).State = System.Data.Entity.EntityState.Deleted;
            }

            //st.StudentEducations.Clear();
            //Add logic to add programs list 
            //programIds contain the list of Ids for selected programs
            List<int> programIds = model.SelectedPrograms.Where(a => a.IsChecked).Select(v => v.ID).ToList();

            var progHist = st.StudentPrograms.ToList();
            foreach (var p in progHist)
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            }

            foreach (int p in programIds)
            {
                StudentProgram pr = new StudentProgram();
                pr.ProgramId = p;
                pr.DateOfApplication = DateTime.Now;
                st.StudentPrograms.Add(pr);
            }


            //StudentProgram sm = new StudentProgram();
            //sm.ProgramId = model.program;
            //sm.DateOfApplication = DateTime.Now;
            //st.StudentPrograms.Add(sm);

            //int uId = db.Degrees.Where(a => a.DegreeName.Equals("Undergraduate")).FirstOrDefault().DegreeId;
            //int pId = db.Degrees.Where(a => a.DegreeName.Equals("Postgraduate")).FirstOrDefault().DegreeId;

            //if(model.degree == uId)
            //{
            //    StudentEducation ste = new StudentEducation();
            //    ste.EducationId = model.educationDetailFirst;
            //    ste.PointsType = model.firstPointType;
            //    ste.Obtained = model.firstYrMarks;
            //    ste.Total = model.firstYrTotal;
            //    ste.IsDegreeCompleted = model.firstDegreeCompleted;
            //    st.StudentEducations.Add(ste);
            //}
            //else if (model.degree == pId)
            //{
            //    StudentEducation ste = new StudentEducation();
            //    ste.EducationId = model.educationDetailFinal;
            //    ste.PointsType = model.finalPointType;
            //    ste.Obtained = model.finalMarks;
            //    ste.Total = model.finalTotal;
            //    ste.IsDegreeCompleted = model.finalDegreeCompleted;
            //    st.StudentEducations.Add(ste);

            //    StudentEducation ste2 = new StudentEducation();
            //    ste2.EducationId = model.bachEducationDetail;
            //    ste2.PointsType = model.bachPointType;
            //    ste2.Obtained = model.bachMarks;
            //    ste2.Total = model.bachTotal;
            //    ste2.IsDegreeCompleted = model.bachDegreeCompleted;
            //    st.StudentEducations.Add(ste2);
            //}

            int uId = db.Degrees.Where(a => a.DegreeName.Equals("Undergraduate")).FirstOrDefault().DegreeId;
            int pId = db.Degrees.Where(a => a.DegreeName.Equals("Postgraduate")).FirstOrDefault().DegreeId;
            if (model.degree == pId)
            {
                foreach (EducationItem ei in model.educations)
                {
                    if (validateEducationItem(ei))
                    {
                        StudentEducation ste = new StudentEducation();
                        ste.EducationId = ei.educationDetail;
                        ste.PointsType = ei.pointType;
                        ste.Obtained = ei.obtained;
                        ste.Total = ei.total;
                        ste.IsDegreeCompleted = ei.degreeCompleted;
                        st.StudentEducations.Add(ste);
                    }
                }
            }
            else
            {
                int inId = db.Lookups.Where(a => a.LookupName.Equals("Intermediate")).FirstOrDefault().LookupId;
                EducationItem ei = model.educations.Where(a => a.EducationLevel == inId).FirstOrDefault();
                StudentEducation ste = new StudentEducation();
                ste.EducationId = ei.educationDetail;
                ste.PointsType = ei.pointType;
                ste.Obtained = ei.obtained;
                ste.Total = ei.total;
                ste.IsDegreeCompleted = ei.degreeCompleted;
                st.StudentEducations.Add(ste);
            }

            if (!isUpdate)
                db.Students.Add(st);
            else
                db.Entry(st).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();

            return true;
        }

        public StudentViewModels getStudent(string cnic)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

            StudentViewModels model = new StudentViewModels();
            var st = db.Students.Where(a => a.StudentCnic.Equals(cnic)).FirstOrDefault();
            if (st == null)
            {
                model.cNIC = cnic;

            }
            //List<StudentEducation> edList = db.StudentEducations.Where(a => a.StudentId == st.Id).ToList();

            //int inId = db.Lookups.Where(a => a.LookupName.Equals("Intermediate")).FirstOrDefault().LookupId;
            //int bachId = db.Lookups.Where(a => a.LookupName.Equals("Bachelor")).FirstOrDefault().LookupId;
            //int[] intIds = db.EducationDetails.Where(a => a.EducationLevel == inId).Select(a => a.EducationId).ToArray();
            //int[] bachIds = db.EducationDetails.Where(a => a.EducationLevel == bachId).Select(a => a.EducationId).ToArray();


            //StudentEducation inter = new StudentEducation();
            //StudentEducation bache = new StudentEducation();

            //foreach (int i in intIds)
            //{
            //    foreach (StudentEducation sed in edList)
            //    {
            //        if (sed.EducationId == i) inter = sed;
            //    }
            //}
            //foreach (int i in bachIds)
            //{
            //    foreach (StudentEducation sed in edList)
            //    {
            //        if (sed.EducationId == i) bache = sed;
            //    }
            //}

            //var inter = edList.Where(a => a.EducationId=).FirstOrDefault();
            //var bache = edList.Where(a => a.EducationDetail.EducationLevel == bachId).FirstOrDefault();
            List<int> idsofEdLevel = new List<int>();
            List<EducationItem> list = new List<EducationItem>();
            if (st != null)
            {
                model.StudentId = st.Id;
                model.name = st.Name.ToUpper();
                model.gender = st.Gender;
                model.cNIC = st.StudentCnic;
                model.dOB = st.DateOfBirth;
                model.fatherName = st.FatherName.ToUpper(); ;
                model.fatherCNIC = st.FaherCnic;
                model.address = st.PostalAddress;
                model.perAddress = st.PermanentAddress;
                model.religion = st.Religion;
                model.province = (int)st.ProvinceId;
                model.district = (int)st.DistrictId;
                model.degree = st.StudentPrograms.First().Program.Degree.DegreeId;
                model.city = (int)st.CityId;
                model.homePhone = st.HomePhoneNo;
                model.cellNo = st.CellNo;
                if (model.address.Equals(model.perAddress)) model.SameAddressCheck = true;

                list = st.StudentEducations.Select(b => new EducationItem()
                {
                    IsRequired = (db.Lookups.Find(b.EducationDetail.EducationLevel).IsActive),
                    Id = b.Id,
                    pointType = (int)b.PointsType,
                    degreeCompleted = b.IsDegreeCompleted,
                    total = b.Total,
                    obtained = b.Obtained,
                    label = db.Lookups.Find(b.EducationDetail.EducationLevel).Description,
                    educationDetail = b.EducationDetail.EducationId,
                    EducationLevel = b.EducationDetail.EducationLevel,
                    EducationOrder = (int)db.Lookups.Find(b.EducationDetail.EducationLevel).SortOrder,
                    pointTypeList = getPointsType(),
                    courseList = getEducationDetailSelectListByLvl(b.EducationDetail.EducationLevel)
                }).ToList();

                idsofEdLevel = list.Select(a => a.EducationLevel).ToList();

            }
            //////////////////////model.program = st.StudentPrograms.FirstOrDefault().ProgramId;

            //if (bache.EducationId != 0)
            //{
            //    int dId = db.Degrees.Where(a => a.DegreeName.Equals("Postgraduate")).FirstOrDefault().DegreeId;
            //    model.degree = dId;

            //    model.educationDetailFinal = inter.EducationId;
            //    model.finalPointType = (int)inter.PointsType;
            //    model.finalMarks = (int)inter.Obtained;
            //    model.finalTotal = (int)inter.Total;
            //    model.finalDegreeCompleted = inter.IsDegreeCompleted;

            //    model.bachEducationDetail = bache.EducationId;
            //    model.bachPointType = (int) bache.PointsType;
            //    model.bachMarks = bache.Obtained;
            //    model.bachTotal = bache.Total;
            //    model.bachDegreeCompleted = bache.IsDegreeCompleted;
            //}
            //else
            //{


            //    model.educationDetailFirst = inter.EducationId;
            //    model.firstPointType = (int)inter.PointsType;
            //    model.firstYrMarks = (int)inter.Obtained;
            //    model.firstYrTotal = (int)inter.Total;
            //    model.firstDegreeCompleted = inter.IsDegreeCompleted;
            //}

            //model.degreeDescription = db.Degrees.Where(a => a.DegreeId == model.degree).FirstOrDefault().DegreeName;

            //if (bache.EducationId != 0)
            //{
            //    int dId = db.Degrees.Where(a => a.DegreeName.Equals("Postgraduate")).FirstOrDefault().DegreeId;
            //    model.degree = dId;
            //}
            //else if(inter.EducationId != 0)
            //{
            //    int dId = db.Degrees.Where(a => a.DegreeName.Equals("Undergraduate")).FirstOrDefault().DegreeId;
            //    model.degree = dId;
            //}

            //model.educations = new List<EducationItem>();
            //EducationItem e1 = getInterEducationItem(cnic);
            //EducationItem e2 = getBachEducationItem(cnic);
            //model.educations.Add(e1);
            //model.educations.Add(e2);


            int[] eduLevelNotInlist = db.Lookups.Where(a => a.CategoryName.Equals("Education Level"))
                .Select(a => a.LookupId).Except(idsofEdLevel).ToArray();

            foreach (var c in eduLevelNotInlist)
            {
                EducationItem obj = new EducationItem();
                obj.degreeCompleted = true;
                obj.IsRequired = (db.Lookups.Find(c).IsActive);
                obj.label = db.Lookups.Find(c).Description;
                obj.EducationLevel = c;
                obj.pointTypeList = getPointsType();
                obj.courseList = getEducationDetailSelectListByLvl(c);
                obj.EducationOrder = (int)db.Lookups.Find(c).SortOrder;
                list.Add(obj);

            }




            list = list.OrderBy(a => a.EducationOrder).ToList();
            model.educations = list;

            return model;
        }

        public EducationItem getBachEducationItem(string cnic)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            var st = db.Students.Where(a => a.StudentCnic.Equals(cnic)).FirstOrDefault();
            if (st == null)
            {
                int bachId = db.Lookups.Where(a => a.LookupName.Equals("Bachelor")).FirstOrDefault().LookupId;
                int[] bachIds = db.EducationDetails.Where(a => a.EducationLevel == bachId).Select(a => a.EducationId).ToArray();

                EducationItem ed = new EducationItem();
                ed.Id = bachId;
                ed.educationDetail = 0;
                ed.obtained = 0;
                ed.total = 0;
                ed.degreeCompleted = false;
                ed.pointTypeList = getPointsType();
                ed.pointType = 0;
                ed.label = "Bachelor/Master (16 year education)";
                ed.courseList = getEducationDetailSelectListByLvl(bachId);

                return ed;
            }
            else
            {
                List<StudentEducation> edList = db.StudentEducations.Where(a => a.StudentId == st.Id).ToList();
                int bachId = db.Lookups.Where(a => a.LookupName.Equals("Bachelor")).FirstOrDefault().LookupId;
                int[] bachIds = db.EducationDetails.Where(a => a.EducationLevel == bachId).Select(a => a.EducationId).ToArray();
                StudentEducation bache = new StudentEducation();
                foreach (int i in bachIds)
                {
                    foreach (StudentEducation sed in edList)
                    {
                        if (sed.EducationId == i) bache = sed;
                    }
                }

                EducationItem ed = new EducationItem();
                ed.Id = bachId;
                ed.educationDetail = bache.EducationId;
                ed.obtained = (int)bache.Obtained;
                ed.total = (int)bache.Total;
                ed.degreeCompleted = bache.IsDegreeCompleted;
                ed.pointTypeList = getPointsType();
                if (bache.PointsType != null) ed.pointType = (int)bache.PointsType;
                else ed.pointType = 0;
                if (bache.EducationId != 0) ed.courseList = getEducationDetailSelectList(bache.EducationId);
                else ed.courseList = getEducationDetailSelectListByLvl(bachId);

                return ed;
            }
        }
        public EducationItem getInterEducationItem(string cnic)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            var st = db.Students.Where(a => a.StudentCnic.Equals(cnic)).FirstOrDefault();
            if (st == null)
            {
                int inId = db.Lookups.Where(a => a.LookupName.Equals("Intermediate")).FirstOrDefault().LookupId;
                int[] bachIds = db.EducationDetails.Where(a => a.EducationLevel == inId).Select(a => a.EducationId).ToArray();

                EducationItem ed = new EducationItem();
                ed.Id = inId;
                ed.educationDetail = 0;
                ed.obtained = 0;
                ed.total = 0;
                ed.degreeCompleted = false;
                ed.pointTypeList = getPointsType();
                ed.pointType = 0;
                ed.label = "Intermediate education";
                ed.courseList = getEducationDetailSelectListByLvl(inId);

                return ed;
            }
            else
            {
                List<StudentEducation> edList = db.StudentEducations.Where(a => a.StudentId == st.Id).ToList();
                int inId = db.Lookups.Where(a => a.LookupName.Equals("Intermediate")).FirstOrDefault().LookupId;
                int[] intIds = db.EducationDetails.Where(a => a.EducationLevel == inId).Select(a => a.EducationId).ToArray();
                StudentEducation inter = new StudentEducation();
                foreach (int i in intIds)
                {
                    foreach (StudentEducation sed in edList)
                    {
                        if (sed.EducationId == i) inter = sed;
                    }
                }
                EducationItem ed = new EducationItem();
                ed.Id = inId;
                ed.educationDetail = inter.EducationId;
                ed.obtained = (int)inter.Obtained;
                ed.total = (int)inter.Total;
                ed.degreeCompleted = inter.IsDegreeCompleted;
                ed.courseList = getEducationDetailSelectList(inter.EducationId);
                ed.pointTypeList = getPointsType();
                if (inter.PointsType != null) ed.pointType = (int)inter.PointsType;
                else ed.pointType = 0;
                if (inter.EducationId != 0) ed.courseList = getEducationDetailSelectList(inter.EducationId);
                else ed.courseList = getEducationDetailSelectListByLvl(inId);

                return ed;
            }
        }
        public List<SelectListItem> getPointsType()
        {

            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            var result = db.Lookups.Where(a => a.CategoryName.Equals("PointsType"))
                .Select(v => new SelectListItem()
                {
                    Text = v.LookupName,
                    Value = v.LookupId + ""
                }).ToList();
            return result;
        }

        public List<SelectListItem> getEducationDetailSelectListByLvl(int educationLevel)
        {

            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

            var result = db.EducationDetails.Where(a => a.EducationLevel == educationLevel)
                .Select(v => new SelectListItem()
                {
                    Text = v.EducationName,
                    Value = v.EducationId + ""
                }).ToList();
            return result;
        }

        public List<SelectListItem> getEducationDetailSelectList(int educationId)
        {

            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            int educationLevel = 0;
            if (educationId > 0) educationLevel = db.EducationDetails.Where(a => a.EducationId == educationId).FirstOrDefault().EducationLevel;
            var result = db.EducationDetails.Where(a => a.EducationLevel == educationLevel)
                .Select(v => new SelectListItem()
                {
                    Text = v.EducationName,
                    Value = v.EducationId + ""
                }).ToList();
            return result;
        }

        public int getDegreeId(string degree)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            return db.Degrees.Where(a => a.DegreeName.Equals(degree)).FirstOrDefault().DegreeId;
        }


        public StudentDetailsViewModel getDetails(int? TrackNo, string cnicNo)
        {
            StudentDetailsViewModel st = new StudentDetailsViewModel();
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            string id;
            if (cnicNo == "")
            {

                var s = db.Students.Where(a => a.StudentTests.FirstOrDefault().TrackingNumber == TrackNo).FirstOrDefault();
                if (s == null)
                {
                    st.status = "Tracking Number not found.";
                    return st;
                }
                st.CNIC = s.StudentCnic;
                //st.Name = s.Name;
                id = s.UserId;
               st.Email= db.AspNetUsers.Find(id).Email;
                //foreach (AspNetUser u in db.AspNetUsers)
                //{
                //    if (u.Id == id)
                //    {
                //        st.Email = u.Email;
                //    }
                //}
                return st;
            }

            var c = db.AspNetUsers.Where(b => b.UserName.Equals(cnicNo)).FirstOrDefault();
            if (c == null)
            {
                st.status = "CNIC number not found.";
                return st;
            }
            id = c.Id;
            st.CNIC = cnicNo;
            st.Email = db.AspNetUsers.Where(b => b.Id == id).FirstOrDefault().Email;
            return st;
        }

        public StudentViewModels getStudentDetails(int TrackNo)
        {
            int id = 0;
            StudentViewModels st = new StudentViewModels();
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

            var s = db.Students.Where(a => a.StudentTests.FirstOrDefault().TrackingNumber == TrackNo).FirstOrDefault();
            if (s == null)
            {
                st.Status = "Tracking Number not found.";
                return st;
            }
            foreach (StudentTest t in db.StudentTests)
            {
                if (t.TrackingNumber == TrackNo)
                {
                    id = t.StudentId;
                }
            }


            st.name = s.Name.ToUpper();
            st.fatherName = s.FatherName.ToUpper();
            st.cNIC = s.StudentCnic;
            st.fatherCNIC = s.FatherName;
            st.dOB = s.DateOfBirth;
            st.religion = s.Religion;
            st.cellNo = s.CellNo;
            st.homePhone = s.HomePhoneNo;
            st.genderName = db.Lookups.Where(b => b.LookupId == s.Gender).FirstOrDefault().LookupName;
            st.cityName = db.Cities.Where(b => b.Id == s.CityId).FirstOrDefault().Name;
            if (s.StudentTests.First().IsPaid == null || s.StudentTests.First().IsPaid == false)
            {
                st.Status = "Payment Not Confirmed";
            }
            else
            {
                st.Status = "Payment Already Confirmed";
            }
            //st.districtName = db.Cities.Where(b => b.Id == s.DistrictId).FirstOrDefault().Name;
            // st.address = s.PostalAddress;



            return st;
        }
        public StudentViewModels GetStudent(string cnic)
        {
            StudentViewModels s = new StudentViewModels();
            //List<StudentViewModels> stdlist = new List<StudentViewModels>();
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            var st = db.Students.Where(a => a.StudentCnic.Equals(cnic)).FirstOrDefault();

            s.name = st.Name.ToUpper();
            s.fatherName = st.FatherName.ToUpper();
            s.fatherCNIC = st.FaherCnic;
            s.dOB = st.DateOfBirth;
            s.cNIC = st.StudentCnic;
            s.address = st.PostalAddress;
            s.perAddress = st.PermanentAddress;
            s.religion = st.Religion;
            s.genderName = db.Lookups.Where(temp => temp.LookupId == st.Gender).FirstOrDefault().LookupName;
            s.cellNo = st.CellNo;
            var dist = db.Cities.Where(temp => temp.Id == st.DistrictId).FirstOrDefault();
            s.districtName = dist.Name;
            s.provinceName = db.Cities.Where(temp => temp.Id == dist.ParentId).FirstOrDefault().Name;
            s.PicturePath = st.PhotographPath;
            s.homePhone = st.HomePhoneNo;
            s.cityName = db.Cities.Where(temp => temp.Id == st.CityId).FirstOrDefault().Name;
            s.DegreeName = st.StudentPrograms.First().Program.Degree.DegreeName;
            s.ProgramName = st.StudentPrograms.First().Program.ProgramName;
            //stdlist.Add(s);



            s.programsList = new List<ProgramsAppliedFor>();
            var progs = st.StudentPrograms.ToList();
            foreach (var p in progs)
            {
                ProgramsAppliedFor ap = new ProgramsAppliedFor();
                ap.ProgramName = p.Program.ProgramName;
                ap.Id = p.ProgramId;
                s.programsList.Add(ap);
            }

            return s;
        }

        public int getEducationLevel(string val)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

            if (db.Lookups.Any(a => a.LookupName.Equals(val))) return db.Lookups.Where(a => a.LookupName.Equals(val)).FirstOrDefault().LookupId;
            else return 0;
        }
        public bool updatePhotograph(String userName, String path)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            var user = db.Students.Where(a => a.StudentCnic.Equals(userName)).FirstOrDefault();
            if (user != null)
            {
                user.PhotographPath = path;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public List<QualificationViewModel> getEducationDetails(String cnic)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

            StudentViewModels obj = new StudentViewModels();
            var student = db.Students.Where(a => a.StudentCnic.Equals(cnic)).FirstOrDefault();
            var edDetails = student.StudentEducations.ToList();
            List<QualificationViewModel> quals = new List<QualificationViewModel>();
            foreach (var c in edDetails)
            {
                QualificationViewModel qobj = new QualificationViewModel();
                qobj.ObtainedMarks = c.Obtained;
                qobj.TotalMarks = c.Total;
                qobj.Order = (int)db.Lookups.Find(c.EducationDetail.EducationLevel).SortOrder;
                qobj.DisplayTotalMarks = qobj.TotalMarks + "";
                if (qobj.TotalMarks % 1 == 0)
                {
                    qobj.DisplayTotalMarks = qobj.DisplayTotalMarks.Replace(".00", "");
                }

                qobj.DisplayObtainedMarks = qobj.ObtainedMarks + "";
                if (qobj.ObtainedMarks % 1 == 0)
                {
                    qobj.DisplayObtainedMarks = qobj.DisplayObtainedMarks.Replace(".00", "");
                }




                qobj.Specialization = db.EducationDetails.Find(c.EducationId).EducationName;
                if (c.IsDegreeCompleted == false)
                    qobj.Specialization = qobj.Specialization + "(Incomplete)";
                int level = db.EducationDetails.Find(c.EducationId).EducationLevel;
                qobj.Degree = db.Lookups.Find(level).LookupName;
                quals.Add(qobj);
            }

            quals = quals.OrderBy(a => a.Order).ToList();

            return quals;
        }


        public StudentReportViewModels getApplicationData(String cnic, String path, int proId)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

            StudentReportViewModels obj = new StudentReportViewModels();
            var student = db.Students.Where(a => a.StudentCnic.Equals(cnic)).FirstOrDefault();
            obj.name = student.Name.ToUpper();
            obj.cNIC = student.StudentCnic;
            obj.fatherName = student.FatherName.ToUpper();
            obj.PicturePath = path + "/" + student.PhotographPath;
            obj.ProgramName = student.StudentPrograms.Where(b => b.ProgramId == proId).First().Program.ProgramName; ;
            obj.DegreeName = student.StudentPrograms.First().Program.Degree.DegreeName;
            //obj.cityName = student.City2.Name;
            obj.address = student.PostalAddress;
            obj.genderName = db.Lookups.Where(b => b.LookupId == student.Gender).FirstOrDefault().LookupName;
            obj.fatherCNIC = student.FaherCnic;
            obj.perAddress = student.PermanentAddress;
            obj.cellNo = student.CellNo;
            obj.homePhone = student.HomePhoneNo;
            var dist = db.Cities.Where(temp => temp.Id == student.DistrictId).FirstOrDefault();
            obj.districtName = dist.Name;
            obj.provinceName = db.Cities.Where(temp => temp.Id == dist.ParentId).FirstOrDefault().Name;

            obj.cityName = db.Cities.Where(b => b.Id == student.CityId).FirstOrDefault().Name;
            obj.TrackingNumber = student.StudentTests.FirstOrDefault().TrackingNumber + "";
            //obj.RollNumber = student.StudentTests.FirstOrDefault().RollNumber + "";
            //if (obj.Degree.Equals("Undergraduate"))
            //{
            //    obj.Block = student.StudentTests.First().TestCenterSlot.TestCenter.Block.BlockName;
            //    obj.TestCenter = student.StudentTests.First().TestCenterSlot.TestCenter.CenterName;
            //    obj.Slot = student.StudentTests.First().TestCenterSlot.TestDateTime;

            //}
            //else
            //{
            //    obj.Block = "IB&M Center";
            //    obj.TestCenter = "First Floor";
            //    obj.Slot = new DateTime(2019, 7, 6);

            //}
            obj.dOB = student.DateOfBirth;



            return obj;

        }

        public AdmitCardViewModel getAdmitCardData(String cnic, String path)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

            AdmitCardViewModel obj = new AdmitCardViewModel();
            var student = db.Students.Where(a => a.StudentCnic.Equals(cnic)).FirstOrDefault();
            obj.Name = student.Name;
            obj.Cnic = student.StudentCnic;
            obj.FatherName = student.FatherName;
            obj.PhotoPath = path + "/" + student.PhotographPath;
            obj.Program = student.StudentPrograms.First().Program.ProgramName;
            obj.Degree = student.StudentPrograms.First().Program.Degree.DegreeName;
            obj.City = student.City2.Name;
            obj.Address = student.PostalAddress;
            obj.TrackingNumber = student.StudentTests.FirstOrDefault().TrackingNumber + "";
            obj.RollNumber = student.StudentTests.FirstOrDefault().RollNumber + "";
            if (obj.Degree.Equals("Undergraduate"))
            {
                obj.Block = student.StudentTests.First().TestCenterSlot.TestCenter.Block.BlockName;
                obj.TestCenter = student.StudentTests.First().TestCenterSlot.TestCenter.CenterName;
                obj.Slot = student.StudentTests.First().TestCenterSlot.TestDateTime;

            }
            else
            {
                obj.Block = "IB&M Center";
                obj.TestCenter = "First Floor";
                obj.Slot = new DateTime(2019, 7, 6, 10, 0, 0);

            }

            return obj;

        }

    }
}
