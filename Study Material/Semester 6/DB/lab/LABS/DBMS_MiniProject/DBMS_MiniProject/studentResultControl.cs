using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_MiniProject
{
    public partial class studentResultControl : UserControl
    {
        private Rubric currentRubric = null;
        private AssessmentComponent currentAssessmentComponent = null;
        private Student currentStudent = null;

        public AssessmentComponent getAssessmentComponent()
        {
            return currentAssessmentComponent;
        }
        public studentResultControl(AssessmentComponent assessmentComponent, Rubric rubric, Student student)
        {
            InitializeComponent();

            currentAssessmentComponent = assessmentComponent;
            currentRubric = rubric;
            currentStudent = student;

            lbl_AssessmentComponent.Text = currentAssessmentComponent.Name;
            lbl_Rubric.Text = currentRubric.Details;
            List<RubricLevel> rubricLevelList = RubricLevel.retrieveRubricLevels(currentRubric.Id);
            foreach(RubricLevel rl in rubricLevelList)
            {
                cb_MeasurementLevel.Items.Add(rl.MeasurementLevel);
            }
            cb_MeasurementLevel.Sorted = true;
            if (cb_MeasurementLevel.Items.Count > 0)
            {
                cb_MeasurementLevel.SelectedItem = cb_MeasurementLevel.Items[0];
                lbl_RubricLevelDetails.Text = RubricLevel.getRubricLevel(currentRubric.Id, Int32.Parse(cb_MeasurementLevel.Text)).Details;
            }
        }

        public int Confirm()
        {
            StudentResult rslt = new StudentResult(-1, -1, -1, DateTime.Now);

            rslt.StudentId = currentStudent.Id;
            rslt.AssessmentComponentId = currentAssessmentComponent.Id;
            rslt.RubricMeasurementId = RubricLevel.getRubricLevel(currentRubric.Id, Int32.Parse(cb_MeasurementLevel.Text)).Id;

            int result = StudentResult.addStudentResult(rslt, rslt);
            return result;
        }
        
        private void cb_MeasurementLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_MeasurementLevel.Text.Length == 0)
            {
                cb_MeasurementLevel.SelectedItem = cb_MeasurementLevel.Items[0];
            }
            lbl_RubricLevelDetails.Text = RubricLevel.getRubricLevel(currentRubric.Id, Int32.Parse(cb_MeasurementLevel.Text)).Details;

        }
    }
}
