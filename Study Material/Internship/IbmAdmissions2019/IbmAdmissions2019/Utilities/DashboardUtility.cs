using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbmAdmissions2019.Utilities
{
    public class DashboardUtility
    {
        private IbmAdmissions2019Entities db;
        private static DashboardUtility _instance;

        private DashboardUtility()
        {
            db = new IbmAdmissions2019Entities();
        }
        public static DashboardUtility getInstance()
        {
            if (_instance == null)
                _instance = new DashboardUtility();
            return _instance;
        }

        public String getIcon(String Status)
        {
            if (Status.Equals("Current"))
            {
                return "fa fa-lock-open";
            }
            else if (Status.Equals("Saved"))
            {
                return "fa fa-save";
            }
            else if (Status.Equals("Locked"))
            {
                return "fa fa-lock";
            }
            else //completed
            {
                return "fa fa-check";
            }
        }
        public String getApplicationStatus(int id,String cnic, out String Content)
        {

            db = new IbmAdmissions2019Entities();
            String status = "";
            String cont = "";
            var student = db.Students.Where(b => b.StudentCnic.Equals(cnic)).FirstOrDefault();
            var user = db.AspNetUsers.Where(b => b.UserName.Equals(cnic)).FirstOrDefault();
            switch(id)
            {
                case 1: //Fill application Form
                    if (user != null && student == null)
                    {
                        status = "Current";
                        cont = "Fill the application form along with your perosnal details and educational details to get started";
                    }
                    else if (user != null && student != null && student.IsApplicationConfirmed == false)
                    {
                        status = "Saved";
                        cont = "Click to edit the applicaiton form including personal details and educational details";
                    }
                    else if (user != null && student != null && student.IsApplicationConfirmed == true)
                    {
                        status = "Completed";
                        cont = "You have submitted the application form. After submission, no changes can be made in the applicaiton form.";
                    }
                        break;
                 case 2: //Upload Photograph
                    if (user != null && student == null)
                    {
                        status = "Locked";
                        cont = "Photograph will be uploaded after filling the applicaiton form";
                    }
                    else if (user != null && student != null && student.IsApplicationConfirmed == false && student.PhotographPath == null)
                    {
                        status = "Current";
                        cont = "Upload your passport size recent photograph. This photograph will be used to verify your identity in the test center";
                    }
                    else if (user != null && student != null && (student.IsApplicationConfirmed == false ) && student.PhotographPath != null)
                    {
                        status = "Saved";
                        cont = "You have uploaded photograph. If you want to change the photograph, click here";
                    }
                    else if (user != null && student != null  && student.PhotographPath != null && student.IsApplicationConfirmed == true )
                    {
                        status = "Completed";
                        cont = "You have submitted the application form. After submission, no changes can be made in the photograph.";
                    }
                        break;
                case 3: //Submit Application
                    if (user != null && student == null)
                    {
                        status = "Locked";
                        cont = "Fill the application form and upload photograph to submit the application";
                    }
                    else if (user != null && student != null && student.IsApplicationConfirmed == false && student.PhotographPath == null)
                    {
                        status = "Locked";
                        cont = "Fill the application form and upload photograph to submit the application";
                    }
                    else if (user != null && student != null && student.IsApplicationConfirmed == false && student.PhotographPath != null)
                    {
                        status = "Current";
                        cont = "Click here to review your application form. Once submitted the applicaiton form, no changes can be made.";
                    }
                    else if (user != null && student != null && student.IsApplicationConfirmed == true)
                    {
                        status = "Completed";
                        cont = "Application form has been submitted. Print the challan form and get your Admit Card.";
                    }
                        break;
                case 4: //print Challan Form
                    if (user != null && student == null)
                    {
                        status = "Locked";
                        cont = "Submit the application to print the challan form";
                    }
                    else if (user != null && student != null && student.IsApplicationConfirmed == false)
                    {
                        status = "Locked";
                        cont = "Submit the application to print the challan form";
                    }
                    else if (user != null && student != null && student.IsApplicationConfirmed == true)
                    {
                        status = "Current";
                        cont = "Print the challan form and submit the dues in HBL, UET Branch";
                        var test = db.EntryTests.Where(a => a.IsActive).FirstOrDefault();
                        var studentTest = student.StudentTests.Where(b => b.TestId == test.TestId).FirstOrDefault();
                        if (studentTest != null && studentTest.IsPaid.HasValue && studentTest.IsPaid.Value)
                        {
                            status = "Completed";
                            cont = "Your payment has been confirmed";
                        }
                    }
                    break;
                case 5://print Application Form
                    if (user != null && student == null)
                    {
                        status = "Locked";
                        cont = "Submit the application to print the application form";
                    }
                    else if (user != null && student != null && student.IsApplicationConfirmed == false)
                    {
                        cont = "Submit the application to print the applicaiton form";
                        status = "Locked";
                    }
                    else if (user != null && student != null && student.IsApplicationConfirmed == true)
                    {
                        status = "Current";
                        cont = "Print the application form and submit to the IB&M admission office along with the required documents";
                        var test = db.EntryTests.Where(a => a.IsActive).FirstOrDefault();
                        var studentTest = student.StudentTests.Where(b => b.TestId == test.TestId).FirstOrDefault();
                        if (studentTest != null && studentTest.IsPaid.HasValue && studentTest.IsPaid.Value)
                        {
                            status = "Completed";
                            cont = "Your application has been received. Get your admit card";
                        }
                    }
                    break;
                case 6: //Payment Confirmation
                    if (user != null && student == null)
                    {
                        status = "Locked";
                        cont = "Submit hard copy of application form along with the required documents in IB&M before July 4, 2019";
                    }
                    else if (user != null && student != null && student.IsApplicationConfirmed == false)
                    {
                        status = "Locked";
                        cont = "Submit hard copy of application form along with the required documents in IB&M before July 4, 2019";
                    }
            
                    else if (user != null && student != null && student.IsApplicationConfirmed == true)
                    {
                        status = "Current";
                        cont = "Submit hard copy of application form along with the required documents in IB&M before July 4, 2019";

                        var test = db.EntryTests.Where(a => a.IsActive).FirstOrDefault();
                        var studentTest = student.StudentTests.Where(b => b.TestId == test.TestId).FirstOrDefault();
                        if (studentTest != null && studentTest.IsPaid.HasValue && studentTest.IsPaid.Value)
                        {
                            status = "Completed";
                            cont = "Your payment has been confirmed. Get your admit card";
                        }
                    }
                    
                    break;
                case 7: //Print Admit Card
                    if (user != null && student == null)
                    {
                        status = "Locked";
                        cont = "Submit the challan form and application form to get the admit card";
                    }
            
                    else if (user != null && student != null && student.IsApplicationConfirmed == false)
                    {
                        status = "Locked";
                        cont = "Submit the challan form and application form to get the admit card";
                    }
                    else if (user != null && student != null && student.IsApplicationConfirmed == true)
                    {
                        status = "Locked";
                        cont = "Submit the challan form and application form to get the admit card";
                        var test = db.EntryTests.Where(a => a.IsActive).FirstOrDefault();
                        var studentTest = student.StudentTests.Where(b => b.TestId == test.TestId).FirstOrDefault();
                        if (studentTest != null && studentTest.IsPaid.HasValue && studentTest.IsPaid.Value)
                        {
                            status = "Current";
                            cont = "Click here to print the admit card and bring it to test center with your photo identity";
                        }
                    }
                    break;

            }
            Content = cont;
            return status;
        }


    }
}