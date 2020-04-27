using CrystalDecisions.CrystalReports.Engine;
using IbmAdmissions2019.Models;
using IbmAdmissions2019.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IbmAdmissions2019.Controllers
{
    public class StudentAdmissionController : Controller
    {
        public JsonResult getProvinceList()
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            //IEnumerable<GetProducts_Result> res = db.GetProducts();
            int placeLevel = db.Lookups.Where(temp => temp.LookupName.Equals("Province")).FirstOrDefault().LookupId;
            List<City> result = db.Cities.Where(temp => temp.PlaceLevel == placeLevel).ToList();
            return Json(result.Select(x => new
            {
                ID = x.Id,
                Name = x.Name
            }));
        }

        public JsonResult getDistrictList(int itemId)
        {

            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            //IEnumerable<GetProducts_Result> res = db.GetProducts();
            int placeLevel = db.Lookups.Where(temp => temp.LookupName.Equals("District")).FirstOrDefault().LookupId;
            List<City> result = db.Cities.Where(temp => temp.PlaceLevel == placeLevel && temp.ParentId == itemId).ToList();
            return Json(result.Select(x => new
            {
                ID = x.Id,
                Name = x.Name
            }));
        }
        public JsonResult getCityList(int itemId)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            //IEnumerable<GetProducts_Result> res = db.GetProducts();
            int placeLevel = db.Lookups.Where(temp => temp.LookupName.Equals("City")).FirstOrDefault().LookupId;
            List<City> result = db.Cities.Where(temp => temp.PlaceLevel == placeLevel && temp.ParentId == itemId).ToList();
            return Json(result.Select(x => new
            {
                ID = x.Id,
                Name = x.Name
            }));
        }
        public JsonResult getDegreeList()
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            List<Degree> result = db.Degrees.ToList();
            return Json(result.Select(x => new
            {
                ID = x.DegreeId,
                Name = x.DegreeName
            }));
        }
        public JsonResult getProgramList(int itemId)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            List<Program> result = db.Programs.Where(temp => temp.DegreeId == itemId).ToList();
            return Json(result.Select(x => new CheckBoxListItem()
            {
                ID = x.ProgramId,
                Display = x.ProgramName,
                IsChecked = false
            }));
        }
        //public JsonResult getEducationDetailList(int itemId)
        //{
        //    IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
        //    List<EducationDetail> result = db.EducationDetails.Where(temp=>temp.EducationLevel == itemId).ToList();
        //    return Json(result.Select(x => new
        //    {
        //        ID = x.EducationId,
        //        Name = x.EducationName
        //    }));
        //}
        public JsonResult getGenderList()
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            List<Lookup> result = db.Lookups.Where(temp => temp.CategoryName.Equals("Gender")).ToList();
            return Json(result.Select(x => new
            {
                ID = x.LookupId,
                Name = x.LookupName
            }));
        }


        public List<SelectListItem> getGenderSelectList()
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            var result = db.Lookups.Where(temp => temp.CategoryName.Equals("Gender"))
                .Select(v => new SelectListItem() {
                    Text = v.LookupName,
                    Value = v.LookupId + ""
                }).ToList();
            return result;
        }
        public List<SelectListItem> getProvinceSelectList()
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            int placeLevel = db.Lookups.Where(temp => temp.LookupName.Equals("Province")).FirstOrDefault().LookupId;

            var result = db.Cities.Where(temp => temp.PlaceLevel == placeLevel)
                .Select(v => new SelectListItem()
                {
                    Text = v.Name,
                    Value = v.Id + ""
                }).ToList();
            return result;
        }
        public List<SelectListItem> getDistrictSelectList()
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            int placeLevel = db.Lookups.Where(temp => temp.LookupName.Equals("District")).FirstOrDefault().LookupId;

            var result = db.Cities.Where(temp => temp.PlaceLevel == placeLevel)
                .Select(v => new SelectListItem()
                {
                    Text = v.Name,
                    Value = v.Id + ""
                }).ToList();
            return result;
        }
        public List<SelectListItem> getCitySelectList()
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            int placeLevel = db.Lookups.Where(temp => temp.LookupName.Equals("City")).FirstOrDefault().LookupId;

            var result = db.Cities.Where(temp => temp.PlaceLevel == placeLevel)
                .Select(v => new SelectListItem()
                {
                    Text = v.Name,
                    Value = v.Id + ""
                }).ToList();
            return result;
        }
        public List<SelectListItem> getDegreeSelectList()
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            var result = db.Degrees
                .Select(v => new SelectListItem()
                {
                    Text = v.DegreeName,
                    Value = v.DegreeId + ""
                }).ToList();
            return result;
        }
        public List<SelectListItem> getProgramSelectList(int degreeId)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            var result = db.Programs.Where(a => a.DegreeId == degreeId)
                .Select(v => new SelectListItem()
                {
                    Text = v.ProgramName,
                    Value = v.ProgramId + ""
                }).ToList();
            return result;
        }
        public List<SelectListItem> getProgramSelectList(int degreeId, int studentId)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            List<int> StudentProgramIds = db.StudentPrograms.Where(a => a.StudentId == studentId).Select(v => v.ProgramId).ToList();
            List<Program> ProgramList = db.Programs.Where(a => a.DegreeId == degreeId).ToList();
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (Program pr in ProgramList)
            {
                SelectListItem sli = new SelectListItem();
                if (StudentProgramIds.Contains(pr.ProgramId))
                {
                    sli.Selected = true;
                }
                sli.Text = pr.ProgramName;
                sli.Value = pr.ProgramId + "";
                result.Add(sli);
            }

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
                ed.pointType = 0;
                ed.pointTypeList = getPointsType();
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
                ed.pointType = 0;
                ed.pointTypeList = getPointsType();
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


        // GET: StudentAdmission
        public ActionResult Index()
        {
            return View();
        }

        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            ImageConverter imgCon = new ImageConverter();
            return (byte[])imgCon.ConvertTo(imageIn, typeof(byte[]));
            //using (var ms = new MemoryStream())
            //{
            //    imageIn.Save(ms, imageIn.RawFormat);
            //    return ms.ToArray();
            //}
        }
        [Authorize(Roles = "Candidate")]
        // GET: StudentAdmission/Details/5
        public ActionResult PrintChallanForm()
        {
            String cnic = User.Identity.Name;
            String cnt = "";
            String status = DashboardUtility.getInstance().getApplicationStatus(4, cnic, out cnt);
            if (!status.Equals("Current"))
            {
                return RedirectToAction("StudentIndex", "Home");
            }
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

            var student = db.Students.Where(a => a.StudentCnic.Equals(cnic)).FirstOrDefault();
            var stdDetails = db.StudentDetails(student.Id).ToList();
            String chllan = stdDetails.FirstOrDefault().TrackingNumber + "";
            System.Drawing.Image barcode = GenCode128.Code128Rendering.MakeBarcodeImage(chllan, 2, false);
            var imgbyte = ImageToByteArray(barcode);

            DataTable dt = new DataTable();
            dt.Columns.Add("Image", Type.GetType("System.Byte[]"));

            var drow = dt.NewRow();
            drow[0] = imgbyte;
            dt.Rows.Add(drow[0]);
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "EntryTestForm.rpt"));
            rd.SetDataSource(stdDetails);
            rd.Subreports[0].SetDataSource(dt);
            rd.Subreports[1].SetDataSource(dt);
            rd.Subreports[2].SetDataSource(dt);


            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "ChallanForm-" + cnic + ".pdf");

        }

        [Authorize(Roles = "Candidate")]
        public ActionResult PrintAdmitCard()
        {

            String cnic = User.Identity.Name;
            String cnt = "";
            String status = DashboardUtility.getInstance().getApplicationStatus(7, cnic, out cnt);
            if (!status.Equals("Current"))
            {
                return RedirectToAction("StudentIndex", "Home");
            }
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            String path = Server.MapPath("~/ProfileImages");
            var admc = StudentUtility.getInstance().getAdmitCardData(cnic, path);
            List<AdmitCardViewModel> list = new List<AdmitCardViewModel>();
            list.Add(admc);
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "AdmitCardPicture.rpt"));
            rd.SetDataSource(list);



            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "AdmitCard-" + cnic + ".pdf");

        }



        [Authorize(Roles = "Assisstant")]
        public ActionResult PrintAdmitCardAssisstant(String cnic)
        {

        
            String cnt = "";
            String status = DashboardUtility.getInstance().getApplicationStatus(7, cnic, out cnt);
            if (!status.Equals("Current"))
            {
                TempData["AdmitCardError"] = "Record Not Found";
                return RedirectToAction("PrintAdmitCard","Assisstant");
            }
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            String path = Server.MapPath("~/ProfileImages");

            var admc = StudentUtility.getInstance().getAdmitCardData(cnic, path);
          
            List<AdmitCardViewModel> list = new List<AdmitCardViewModel>();
            list.Add(admc);
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "AdmitCardPicture.rpt"));
            rd.SetDataSource(list);



            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "AdmitCard-" + cnic + ".pdf");

        }




        [Authorize(Roles = "Candidate")]
        public ActionResult PrintApplicationForms()
        {
            String cnic = User.Identity.Name;
            String cnt = "";
            String status = DashboardUtility.getInstance().getApplicationStatus(5, cnic, out cnt);
            if (!status.Equals("Current"))
            {
                return RedirectToAction("StudentIndex", "Home");
            }
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            var st = db.Students.Where(a => a.StudentCnic.Equals(cnic)).FirstOrDefault();
            var list = st.StudentPrograms.Select(a => new ProgramsAppliedFor()
            {
                Id = a.ProgramId,
                ProgramName = a.Program.ProgramName
            }).ToList();
            ViewBag.ProgramList = list;
            return View();
        }
        [Authorize(Roles = "Candidate")]
        public ActionResult PrintApplicationForm(int id)
        {

            String cnic = User.Identity.Name;
            String cnt = "";
            String status = DashboardUtility.getInstance().getApplicationStatus(5, cnic, out cnt);
            if (!status.Equals("Current"))
            {
                return RedirectToAction("StudentIndex", "Home");
            }
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
            String path = Server.MapPath("~/ProfileImages");
            var admc = StudentUtility.getInstance().getApplicationData(cnic, path, id);
            var elist = StudentUtility.getInstance().getEducationDetails(cnic);
            //admc.name = "SAMYAN QAYYUM WAHLA";
            List<StudentReportViewModels> list = new List<StudentReportViewModels>();
            list.Add(admc);
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "studentform3.rpt"));
            rd.SetDataSource(list);
            rd.Subreports[1].SetDataSource(elist);
            rd.Subreports[0].SetDataSource(list);


            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "ApplicationForm-" + cnic + ".pdf");

        }

        [Authorize(Roles = "Candidate")]
        // GET: StudentAdmission/Create
        public ActionResult FillApplicationForm()

        {
            String cnt = "";
            string cnic = User.Identity.Name;
            String status = DashboardUtility.getInstance().getApplicationStatus(1, cnic, out cnt);
            if (!status.Equals("Saved") && !status.Equals("Current"))
            {
                return RedirectToAction("StudentIndex", "Home");
            }

            StudentViewModels model = StudentUtility.getInstance().getStudent(cnic);
            //model.finalPointType =  Int32.Parse( getPointsType().Where(a => a.Text.Equals("Marks")).FirstOrDefault().Value); ;
            //model.firstPointType = Int32.Parse(getPointsType().Where(a => a.Text.Equals("Marks")).FirstOrDefault().Value); ;
            //model.finalDegreeCompleted = true;
            //model.firstDegreeCompleted = true;
            ViewBag.GenderList = getGenderSelectList();
            ViewBag.ProvinceList = getProvinceSelectList();
            ViewBag.DistrictList = getDistrictSelectList();
            ViewBag.CityList = getCitySelectList();
            ViewBag.DegreeList = getDegreeSelectList();
            ViewBag.ProgramList = getProgramSelectList(model.degree, model.StudentId);
            //ViewBag.SEducationDetailFirstList = getEducationDetailSelectList(model.educationDetailFirst);
            //ViewBag.EducationDetailFinalList = getEducationDetailSelectList(model.educationDetailFinal);
            //ViewBag.EducationDetailBachList = getEducationDetailSelectList(model.bachEducationDetail);
            //ViewBag.PointTypeList = getPointsType();

            //model.educations = new List<EducationItem>();
            //EducationItem e1 = getInterEducationItem(cnic);
            //EducationItem e2 = getBachEducationItem(cnic);
            //model.educations.Add(e1);
            //model.educations.Add(e2);

            return View(model);
        }
        [Authorize(Roles = "Candidate")]
        // POST: StudentAdmission/Create
        [HttpPost]
        public ActionResult FillApplicationForm(StudentViewModels model)
        {
            // String btn = null;

            string cnic = User.Identity.Name;
            //validation
            try
            {
                //if(model.bachEducationDetail != 0)
                //{
                //    if(model.finalMarks >= model.finalTotal){throw new HttpException(4000, "Obtained greater than Total Exception");}
                //    if (model.bachMarks >= model.bachTotal){throw new HttpException(4000, "Obtained greater than Total Exception");}
                //}
                //else if(model.educationDetailFirst != 0)
                //{
                //    if (model.firstYrMarks >= model.firstYrTotal){throw new HttpException(4000, "Obtained greater than Total Exception");}
                //}
                bool isProgramSelected = false;
                foreach (CheckBoxListItem pr in model.SelectedPrograms)
                {
                    if (pr.IsChecked)
                    {
                        isProgramSelected = true;
                        break;
                    }
                }
                if (!isProgramSelected) throw new HttpException(4001, "No program Selected Exception");

                String cnt = "";
                String status = DashboardUtility.getInstance().getApplicationStatus(1, cnic, out cnt);
                if (!status.Equals("Saved") && !status.Equals("Current"))
                {
                    return RedirectToAction("StudentIndex", "Home");
                }

                StudentUtility.getInstance().AddStudent(model);
                TempData["Message"] = "Your application has been saved successfully";
                return RedirectToAction("StudentIndex", "Home");          

            }
            catch (Exception ex)
            {
                //IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();
                //int postDId = db.Degrees.Where(a => a.DegreeName.Equals("Postgraduate")).FirstOrDefault().DegreeId;
                //int UndDId = db.Degrees.Where(a => a.DegreeName.Equals("Undergraduate")).FirstOrDefault().DegreeId;

                //int BachLevel = db.Lookups.Where(a => a.LookupName.Equals("Bachelor")).FirstOrDefault().LookupId;
                //if (model.degree == postDId && model.bachEducationDetail < 1)
                //{
                //    ModelState.AddModelError("bachEducationDetail", "Bachelor Education Detail Field is Required");
                //}
                //if (model.degree == postDId) {model.degreeDescription = "Postgraduate";}
                //if (model.degree == UndDId) { model.degreeDescription = "Undergraduate"; }

                //model.finalPointType = Int32.Parse(getPointsType().Where(a => a.Text.Equals("Marks")).FirstOrDefault().Value); ;
                //model.firstPointType = Int32.Parse(getPointsType().Where(a => a.Text.Equals("Marks")).FirstOrDefault().Value); ;
                //model.finalDegreeCompleted = true;
                //model.firstDegreeCompleted = true;
                ViewBag.GenderList = getGenderSelectList();
                ViewBag.ProvinceList = getProvinceSelectList();
                ViewBag.DistrictList = getDistrictSelectList();
                ViewBag.CityList = getCitySelectList();
                ViewBag.DegreeList = getDegreeSelectList();
                ViewBag.ProgramList = getProgramSelectList(model.degree);
                //ViewBag.SEducationDetailFirstList = getEducationDetailSelectList(model.educationDetailFirst);
                //ViewBag.EducationDetailFinalList = getEducationDetailSelectList(model.educationDetailFinal);
                //ViewBag.EducationDetailBachList = getEducationDetailSelectListByLvl(BachLevel);
                //ViewBag.PointTypeList = getPointsType();
                ViewBag.ErrorMessage = ex.Message + ex.StackTrace;

                //if (model.bachEducationDetail != 0)
                //{
                //    if (model.finalMarks >= model.finalTotal)
                //    {
                //        ModelState.AddModelError("finalMarks", "Obtained Marks should be less than Total Marks");
                //    }
                //    if (model.bachMarks >= model.bachTotal)
                //    {
                //        ModelState.AddModelError("bachMarks", "Obtained Marks should be less than Total Marks");
                //    }
                //}
                //else if (model.educationDetailFirst != 0)
                //{
                //    if (model.firstYrMarks >= model.firstYrTotal)
                //    {
                //        ModelState.AddModelError("firstYrMarks", "Obtained Marks should be less than Total Marks");
                //    }
                //}
                bool isProgramSelected = false;
                foreach (CheckBoxListItem pr in model.SelectedPrograms)
                {
                    if (pr.IsChecked)
                    {
                        isProgramSelected = true;
                        break;
                    }
                }
                if (!isProgramSelected)
                {
                    ModelState.AddModelError("SelectedPrograms", "Choose atleast one program");
                }

                foreach(EducationItem ei in model.educations)
                {
                    ei.courseList = StudentUtility.getInstance().getEducationDetailSelectList(ei.educationDetail);
                    ei.pointTypeList = StudentUtility.getInstance().getPointsType();
                }

                //model.educations = new List<EducationItem>();
                //EducationItem e1 = getInterEducationItem(cnic);
                //EducationItem e2 = getBachEducationItem(cnic);
                //model.educations.Add(e1);
                //model.educations.Add(e2);

                return View(model);
            }


            //try
            //{


            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        [Authorize(Roles = "Candidate")]
        public ActionResult SubmitApplicationForm()
        {
            string cnic = User.Identity.Name;

            String cnt = "";
            String status = DashboardUtility.getInstance().getApplicationStatus(3, cnic, out cnt);
            if (!status.Equals("Current"))
            {
                return RedirectToAction("StudentIndex", "Home");
            }
            ViewBag.Qualifications = StudentUtility.getInstance().getEducationDetails(cnic);
            return View(StudentUtility.getInstance().GetStudent(cnic));

        }


        [Authorize(Roles = "Assisstant")]
        public ActionResult getSt(int? tno)
        {
            if (tno == null)
            {
                ViewBag.flag = false;
                return View();
            }
            else
            {
                StudentViewModels model = new StudentViewModels();
                model = StudentUtility.getInstance().getStudentDetails((int)tno);
                ViewBag.flag = true;
                ViewBag.TrackingNumber = tno.Value;
                return View(model);
            }
        }
        [Authorize(Roles = "Assisstant")]
        public ActionResult getStudentsDetail(int? tno, String cnic)
        {

            if ((tno == null) && (cnic == null))
            {
                ViewBag.flag = false;
                ViewBag.status = false;
                return View();
            }
            else 
            {
                ViewBag.status = true;
                StudentDetailsViewModel dt = new StudentDetailsViewModel();
                dt = StudentUtility.getInstance().getDetails(tno, cnic);
                if(!String.IsNullOrEmpty(dt.status))
                {
                    ViewBag.status = false;
                    ViewBag.St = dt.status;
                }
                ViewBag.flag = true;
                return View(dt);
            }
        }
        [Authorize(Roles = "Assisstant")]
        public ActionResult ConfirmPayment(int tno)
        {
            IbmAdmissions2019Entities db = new IbmAdmissions2019Entities();

            var sTest = db.StudentTests.Where(a => a.TrackingNumber == tno).FirstOrDefault();
            if (sTest == null)
                throw new Exception("Student Test is Null");
            StudentUtility.getInstance().getRollNumber(sTest.Student.StudentCnic);
            return RedirectToAction("getSt");
        }

        //public ActionResult getStudentDetails(string TrackingNumber)
        //{
        //    return PartialView(StudentUtility.getInstance().getStudentDetails(TrackingNumber));
        //}
        [Authorize(Roles = "Candidate")]
        [HttpPost]
        public ActionResult SubmitApplicationForm(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw (ex);
            }
         }
        [Authorize(Roles = "Candidate")]
        public ActionResult SubmitApplicationFormPost()
        {
            try
            {
                String cnic = User.Identity.Name;
                String cnt = "";
                String status = DashboardUtility.getInstance().getApplicationStatus(3, cnic, out cnt);
                if (!status.Equals("Current"))
                {
                    return RedirectToAction("StudentIndex", "Home");
                }
                // TODO: Add update logic here
                StudentUtility.getInstance().SubmitApplication(User.Identity.Name);
                TempData["Message"] = "Your application has been submitted successfully";
                return RedirectToAction("StudentIndex","Home");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Candidate")]
        // GET: StudentAdmission/Delete/5
        public ActionResult StudentPhotograph()
        {
            String cnic = User.Identity.Name;
            String cnt = "";
            String status = DashboardUtility.getInstance().getApplicationStatus(2, cnic, out cnt);
            if (!status.Equals("Saved") && !status.Equals("Current"))
            {
                return RedirectToAction("StudentIndex", "Home");
            }
            return View();
        }
        [Authorize(Roles = "Candidate")]
        // POST: StudentAdmission/Delete/5
        [HttpPost]
        public ActionResult StudentPhotograph(HttpPostedFileBase file)
        {
           
            String cnic = User.Identity.Name;
            String cnt = "";
            String status = DashboardUtility.getInstance().getApplicationStatus(2, cnic, out cnt);
            if (!status.Equals("Saved") && !status.Equals("Current"))
            {
                return RedirectToAction("StudentIndex", "Home");
            }

            if (file != null)
            {
                if(file.ContentLength > 1024000)
                {
                    ViewBag.PicMessage = "Maximum allowed image size is 1MB.";
                    return View();
                }
                Guid g = Guid.NewGuid();
                string pic = System.IO.Path.GetFileName(file.FileName);
                String[] ext = pic.Split('.');
                String fileName = g + "." + ext[ext.Count() - 1];
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/ProfileImages/"), fileName);
                // file is uploaded
                file.SaveAs(path);
                StudentUtility.getInstance().updatePhotograph(User.Identity.Name, fileName);


                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    file.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}
                // after successfully uploading redirect the user
                TempData["Message"] = "Photograph has been uploaded successfully";
                return RedirectToAction("StudentIndex", "Home");
            }
            else
            {

                ViewBag.PicMessage = "Choose an image before submission";
                return View();
            }
         
            
        }
    }
}
