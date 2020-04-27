using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;


namespace DBMS_MiniProject
{
    //Query_Class--------------------------------------------------------------------------
    class Query
    {
        public static string connectionString = "Data Source=(local);Initial Catalog=ProjectB;Integrated Security=True";
        public static int Execute(string query)
        {
            string conString = Query.connectionString;
            int result = 0;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = query;
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteNonQuery();
            }
            con.Close();
            return result;
        }
    }
    //Clo_Class----------------------------------------------------------------------
    class Clo
    {
        //Clo_DataMembers-------------------------------------------------------------
        int id;
        string name;
        DateTime dateCreated;
        DateTime dateUpdated;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                dateUpdated = DateTime.Now;
            }
        }

        public DateTime DateUpdated
        {
            get
            {
                return dateUpdated;
            }
            set
            {
                dateUpdated = value;
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }
            set
            {
                dateCreated = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        //Clo_MemberFunctions-------------------------------------------------------------
        public Clo(string name)
        {
            this.id = -1;
            this.name = name;
            this.dateCreated = DateTime.Now;
            this.dateUpdated = DateTime.Now;
        }
        public static List<Rubric> checkDependancy(int Cloid)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<Rubric> rubricList = new List<Rubric>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Rubric WHERE CloId = '" + Cloid + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    Rubric rubric = new Rubric("Empty", -1);
                    rubric.Id = result.GetInt32(0);
                    rubric.Details = result.GetString(1);
                    rubric.CloId = result.GetInt32(2);

                    rubricList.Add(rubric);
                }
            }
            con.Close();
            return rubricList;
        }
        public static bool deleteCloById(int id)
        {
            List<Rubric> rubricList = Clo.checkDependancy(id);
            foreach(Rubric rb in rubricList)
            {
                Rubric.deleteRubricById(rb.Id);
            }
            if (Query.Execute("DELETE FROM Clo WHERE Id = '" + id + "'") > 0) return true;
            else return false;
        }

        public static Clo getClo(string name)
        {
            string str = name;
            string conString = Query.connectionString;
            SqlDataReader result = null;
            Clo clo = new Clo("Empty");
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Clo WHERE Name = '" + str + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    clo.id = result.GetInt32(0);
                    clo.name = result.GetString(1);
                    clo.dateCreated = result.GetDateTime(2);
                    clo.dateUpdated = result.GetDateTime(3);
                    break;
                }
            }
            con.Close();
            return clo;
        }

        public static Clo getClobyId(int ID)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            Clo clo = new Clo("Empty");
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Clo WHERE Id = '" + ID.ToString() + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    clo.id = result.GetInt32(0);
                    clo.name = result.GetString(1);
                    clo.dateCreated = result.GetDateTime(2);
                    clo.dateUpdated = result.GetDateTime(3);
                    break;
                }
            }
            con.Close();
            return clo;
        }

        public static List<Clo> retrieveClos()
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<Clo> cloList = new List<Clo>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Clo";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    Clo clo = new Clo(result.GetString(1));
                    clo.id = result.GetInt32(0);
                    clo.dateCreated = result.GetDateTime(2);
                    clo.dateUpdated = result.GetDateTime(3);
                    cloList.Add(clo);
                }
            }
            con.Close();
            return cloList;
        }
        public static int addClo(Clo clo)
        {
            int status = 0;
            string conString = Query.connectionString;
            SqlDataReader result = null;
            bool found = false;
            Clo tempClo = new Clo("Empty");
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Clo WHERE Id = '" + clo.id + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    tempClo.id = result.GetInt32(0);
                    tempClo.name = result.GetString(1);
                    tempClo.dateCreated = result.GetDateTime(2);
                    tempClo.dateUpdated = result.GetDateTime(3);

                    found = true;
                    break;
                }
                result.Close();
            }
            if (found)
            {
                if (tempClo.name != clo.name && !(tempClo.name.Equals("Empty")) &&
                   (Clo.getClo(clo.name).id == -1 || Clo.getClo(clo.name).id == tempClo.id))
                {
                    Query.Execute("UPDATE Clo SET Name = '" + clo.name + "', DateUpdated = '" + clo.dateUpdated.ToString(@"yyyy-MM-dd") + "' WHERE Id = '" + clo.id + "'");
                    status = 2;
                }
            }
            else
            {
                bool shouldAdd = true;
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "SELECT * FROM Clo WHERE Name = '" + clo.name + "'";
                    SqlCommand cmd = new SqlCommand(q, con);
                    result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        shouldAdd = false;
                        break;
                    }
                    result.Close();
                }
                if (shouldAdd)
                {
                    Query.Execute("INSERT INTO Clo(Name, DateCreated, DateUpdated) values ('" + clo.name + "', '" + clo.dateCreated.ToString(@"yyyy-MM-dd") + "', '" + clo.dateUpdated.ToString(@"yyyy-MM-dd") + "')");
                    status = 1;
                }
            }
            con.Close();
            return status;
        }
    }
    //Rubric_Class-----------------------------------------------------------------------
    public class Rubric
    {
        //Rubric_DataMembers-------------------------------------------------------------
        static int globalNextId;
        int id;
        string details;
        int cloId;


        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Details
        {
            get
            {
                return details;
            }

            set
            {
                details = value;
            }
        }

        public int CloId
        {
            get
            {
                return cloId;
            }
            set
            {
                cloId = value;
            }
        }
        //Rubric_MemberFunctions----------------------------------------------------
        public static bool updateGlobalId()
        {
            int maxId = 0;
            string conString = Query.connectionString;
            SqlDataReader result = null;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT MAX(Id) FROM Rubric";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    if (!result.IsDBNull(0))
                    {
                        maxId = result.GetInt32(0);
                    }
                    break;
                }
            }
            con.Close();
            if (maxId + 1 == globalNextId)
            {
                return false;
            }
            globalNextId = maxId + 1;
            return true;
        }
        public Rubric(string details, int cloId)
        {
            this.id = -1;
            this.details = details;
            this.cloId = cloId;
        }
        public static bool deleteRubricById(int id)
        {
            List<RubricLevel> rubricLevelList = Rubric.checkRubricLevelDependancy(id);
            foreach (RubricLevel rbl in rubricLevelList)
            {
                RubricLevel.deleteRubricLevelById(rbl.Id);
            }

            List<AssessmentComponent> assessmentComponentList = Rubric.checkAssessmentComponentDependancy(id);
            foreach (AssessmentComponent asc in assessmentComponentList)
            {
                AssessmentComponent.deleteAssessmentComponentById(asc.Id);
            }
            if (Query.Execute("DELETE FROM Rubric WHERE Id = '" + id + "'") > 0) return true;
            else return false;
        }
        public static List<RubricLevel> checkRubricLevelDependancy(int rubricId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<RubricLevel> rubricLevelList = new List<RubricLevel>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM RubricLevel WHERE RubricId = '" + rubricId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    RubricLevel rubricLevel = new RubricLevel(-1, "Empty", -1);
                    rubricLevel.Id = result.GetInt32(0);
                    rubricLevel.RubricId = result.GetInt32(1);
                    rubricLevel.Details = result.GetString(2);
                    rubricLevel.MeasurementLevel = result.GetInt32(3);

                    rubricLevelList.Add(rubricLevel);
                }
            }
            con.Close();
            return rubricLevelList;
        }
        public static List<AssessmentComponent> checkAssessmentComponentDependancy(int rubricId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<AssessmentComponent> assessmentComponentList = new List<AssessmentComponent>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM AssessmentComponent WHERE RubricId = '" + rubricId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    AssessmentComponent assessmentComponent = new AssessmentComponent("Empty", -1, -1, -1);
                    assessmentComponent.Id = result.GetInt32(0);
                    assessmentComponent.Name = result.GetString(1);
                    assessmentComponent.RubricId = result.GetInt32(2);
                    assessmentComponent.TotalMarks = result.GetInt32(3);
                    assessmentComponent.DateCreated = result.GetDateTime(4);
                    assessmentComponent.DateUpdated = result.GetDateTime(5);
                    assessmentComponent.AssessmentId = result.GetInt32(6);
                    assessmentComponentList.Add(assessmentComponent);
                }
            }
            con.Close();
            return assessmentComponentList;
        }
        public static Rubric getRubricById(int id)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            Rubric rubric = new Rubric("Empty", -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Rubric WHERE Id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    rubric.id = result.GetInt32(0);
                    rubric.details = result.GetString(1);
                    rubric.cloId = result.GetInt32(2);
                    break;
                }
            }
            con.Close();
            return rubric;
        }

        public static Rubric getRubric(string details, int cloId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            Rubric rubric = new Rubric("Empty", -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Rubric WHERE Details = '" + details + "' AND CloId = '" + cloId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    rubric.id = result.GetInt32(0);
                    rubric.details = result.GetString(1);
                    rubric.cloId = result.GetInt32(2);
                    break;
                }
            }
            con.Close();
            return rubric;
        }
        public static int addRubric(Rubric rubric)
        {
            if (rubric.cloId == -1 || rubric.details == "Empty") return 0;
            string conString = Query.connectionString;
            SqlDataReader result = null;
            bool found = false;
            Rubric tempRubric = new Rubric("Empty", -1);
            int status = 0;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Rubric WHERE Id = '" + rubric.id + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    tempRubric.id = result.GetInt32(0);
                    tempRubric.details = result.GetString(1);
                    tempRubric.cloId = result.GetInt32(2);

                    found = true;
                    break;
                }
                result.Close();
            }
            if (found)
            {
                if (
                    (!tempRubric.details.Equals("Empty")) &&
                    (
                      (tempRubric.details != rubric.details) ||
                      (tempRubric.cloId != rubric.cloId)
                    )&&
                    (Rubric.getRubric(rubric.details, rubric.cloId).id == -1 || Rubric.getRubric(rubric.details, rubric.cloId).id == tempRubric.id)
                  )
                {
                    Query.Execute("UPDATE Rubric SET Details = '" + rubric.details + "', CloId = '" + rubric.cloId + "' WHERE Id = '" + rubric.id + "'");
                    status = 2;
                }
            }
            else
            {
                bool shouldAdd = true;
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "SELECT * FROM Rubric WHERE Details = '" + rubric.details + "' AND CloId = '" + rubric.cloId + "'";
                    SqlCommand cmd = new SqlCommand(q, con);
                    result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        shouldAdd = false;
                        break;
                    }
                    result.Close();
                }
                if (shouldAdd)
                {
                    Rubric.updateGlobalId();
                    Query.Execute("INSERT INTO Rubric(Id, Details, CloId) VALUES ('" + globalNextId + "', '" + rubric.details + "', '" + rubric.cloId + "')");
                    status = 1;
                }
            }
            con.Close();
            return status;
        }

        public static List<Rubric> retrieveRubricsByCloId(int cloId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<Rubric> rubricList = new List<Rubric>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Rubric WHERE CloId = '" + cloId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    Rubric rubric = new Rubric(result.GetString(1), result.GetInt32(2));
                    rubric.id = result.GetInt32(0);
                    rubricList.Add(rubric);
                }
            }
            con.Close();
            return rubricList;
        }
        public static List<Rubric> retrieveRubrics()
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<Rubric> rubricList = new List<Rubric>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Rubric";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    Rubric rubric = new Rubric(result.GetString(1), result.GetInt32(2));
                    rubric.id = result.GetInt32(0);
                    rubricList.Add(rubric);
                }
            }
            con.Close();
            return rubricList;
        }
    }
    //RubricLevel_Class-------------------------------------------------------------------
    public class RubricLevel
    {
        //RubricLevel_DataMembers----------------------------------------------------
        int id;
        int rubricId;
        string details;
        int measurementLevel;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public int RubricId
        {
            get
            {
                return rubricId;
            }
            set
            {
                rubricId = value;
            }
        }

        public string Details
        {
            get
            {
                return details;
            }

            set
            {
                details = value;
            }
        }

        public int MeasurementLevel
        {
            get
            {
                return measurementLevel;
            }

            set
            {
                measurementLevel = value;
            }
        }
        //RubricLevel_MemberFunctions------------------------------------------------
        public RubricLevel(int rubricId, string details, int measurementLevel)
        {
            this.id = -1;
            this.rubricId = rubricId;
            this.details = details;
            this.measurementLevel = measurementLevel;
        }

        public static RubricLevel getRubricLevel(int rubricId, string details, int measurementLevel)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            RubricLevel rubricLevel = new RubricLevel(-1, "Empty", -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM RubricLevel WHERE RubricId = '" + rubricId + "' AND Details = '" + details + "' AND MeasurementLevel = '" + measurementLevel + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    rubricLevel.id = result.GetInt32(0);
                    rubricLevel.rubricId = result.GetInt32(1);
                    rubricLevel.details = result.GetString(2);
                    rubricLevel.measurementLevel = result.GetInt32(3);
                    break;
                }
            }
            con.Close();
            return rubricLevel;
        }
        public static RubricLevel getRubricLevel(int rubricId, int measurementLevel)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            RubricLevel rubricLevel = new RubricLevel(-1, "Empty", -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM RubricLevel WHERE RubricId = '" + rubricId + "' AND MeasurementLevel = '" + measurementLevel + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    rubricLevel.id = result.GetInt32(0);
                    rubricLevel.rubricId = result.GetInt32(1);
                    rubricLevel.details = result.GetString(2);
                    rubricLevel.measurementLevel = result.GetInt32(3);
                    break;
                }
            }
            con.Close();
            return rubricLevel;
        }
        public static RubricLevel getMaxRubricLevel(int rubricId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            RubricLevel rubricLevel = new RubricLevel(-1, "Empty", -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM RubricLevel WHERE RubricId = '"+ rubricId +"' AND MeasurementLevel = (SELECT MAX(MeasurementLevel) FROM RubricLevel WHERE RubricId = '"+ rubricId + "')";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    rubricLevel.id = result.GetInt32(0);
                    rubricLevel.rubricId = result.GetInt32(1);
                    rubricLevel.details = result.GetString(2);
                    rubricLevel.measurementLevel = result.GetInt32(3);
                    break;
                }
            }
            con.Close();
            return rubricLevel;
        }
        public static RubricLevel getRubricLevelById(int id)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            RubricLevel rubricLevel = new RubricLevel(-1, "Empty", -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM RubricLevel WHERE Id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    rubricLevel.id = result.GetInt32(0);
                    rubricLevel.rubricId = result.GetInt32(1);
                    rubricLevel.details = result.GetString(2);
                    rubricLevel.measurementLevel = result.GetInt32(3);
                    break;
                }
            }
            con.Close();
            return rubricLevel;
        }

        public static int addRubricLevel(RubricLevel rubricLevel)
        {
            if (rubricLevel.rubricId == -1 || rubricLevel.details == "Empty") return 0;
            string conString = Query.connectionString;
            SqlDataReader result = null;
            bool found = false;
            RubricLevel tempRubricLevel = new RubricLevel(-1, "Empty", -1);
            int status = 0;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM RubricLevel WHERE Id = '" + rubricLevel.id + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    tempRubricLevel.id = result.GetInt32(0);
                    tempRubricLevel.rubricId = result.GetInt32(1);
                    tempRubricLevel.details = result.GetString(2);
                    tempRubricLevel.measurementLevel = result.GetInt32(3);

                    found = true;
                    break;
                }
                result.Close();
            }
            if (found)
            {
                if (
                    (!tempRubricLevel.details.Equals("Empty")) &&
                    (
                      (tempRubricLevel.details != rubricLevel.details) ||
                      (tempRubricLevel.rubricId != rubricLevel.rubricId) ||
                      (tempRubricLevel.measurementLevel != rubricLevel.measurementLevel)
                    )&&
                    (RubricLevel.getRubricLevel(rubricLevel.rubricId, rubricLevel.details, rubricLevel.measurementLevel).id == -1 || RubricLevel.getRubricLevel(rubricLevel.rubricId, rubricLevel.details, rubricLevel.measurementLevel).id == tempRubricLevel.id)
                  )
                {
                    Query.Execute("UPDATE RubricLevel SET RubricId = '" + rubricLevel.rubricId + "', Details = '" + rubricLevel.details + "', MeasurementLevel = '" + rubricLevel.measurementLevel + "' WHERE Id = '" + rubricLevel.id + "'");
                    status = 2;
                }
            }
            else
            {
                bool shouldAdd = true;
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "SELECT * FROM RubricLevel WHERE RubricId = '" + rubricLevel.rubricId + "'AND Details = '" + rubricLevel.details + "'";
                    SqlCommand cmd = new SqlCommand(q, con);
                    result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        shouldAdd = false;
                        break;
                    }
                    result.Close();

                    q = "SELECT * FROM RubricLevel WHERE RubricId = '" + rubricLevel.rubricId + "' AND MeasurementLevel = '" + rubricLevel.measurementLevel + "'";
                    cmd = new SqlCommand(q, con);
                    result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        shouldAdd = false;
                        break;
                    }
                    result.Close();
                }
                if (shouldAdd)
                {
                    Query.Execute("INSERT INTO RubricLevel(RubricId, Details, MeasurementLevel) VALUES ('" + rubricLevel.rubricId + "', '" + rubricLevel.details + "', '" + rubricLevel.measurementLevel + "')");
                    status = 1;
                }
            }
            con.Close();
            return status;
        }
        public static List<RubricLevel> retrieveRubricLevels()
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<RubricLevel> rubricLevelList = new List<RubricLevel>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM RubricLevel";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    RubricLevel rubricLevel = new RubricLevel(result.GetInt32(1), result.GetString(2), result.GetInt32(3));
                    rubricLevel.id = result.GetInt32(0);
                    rubricLevelList.Add(rubricLevel);
                }
            }
            con.Close();
            return rubricLevelList;
        }
        public static List<RubricLevel> retrieveRubricLevels(int rubricId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<RubricLevel> rubricLevelList = new List<RubricLevel>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM RubricLevel WHERE RubricId = '" + rubricId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    RubricLevel rubricLevel = new RubricLevel(result.GetInt32(1), result.GetString(2), result.GetInt32(3));
                    rubricLevel.id = result.GetInt32(0);
                    rubricLevelList.Add(rubricLevel);
                }
            }
            con.Close();
            return rubricLevelList;
        }
        public static bool deleteRubricLevelById(int id)
        {
            List<StudentResult> studentResultList = StudentResult.retrieveStudentResultByRubricMeasurementId(id);
            foreach(StudentResult rslt in studentResultList)
            {
                StudentResult.deleteStudentResult(rslt.StudentId, rslt.AssessmentComponentId);
            }

            if (Query.Execute("DELETE FROM RubricLevel WHERE Id = '" + id + "'") > 0) return true;
            else return false;
        }
    }
    //Assessment_Class-------------------------------------------------------------------
    public class Assessment
    {
        //Assessment_DataMembers-------------------------------------------------------------
        int id;
        string title;
        DateTime dateCreated;
        int totalMarks;
        int totalWeightage;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }
            set
            {
                dateCreated = value;
            }
        }

        public int TotalMarks
        {
            get
            {
                return totalMarks;
            }

            set
            {
                totalMarks = value;
            }
        }

        public int TotalWeightage
        {
            get
            {
                return totalWeightage;
            }

            set
            {
                totalWeightage = value;
            }
        }
        //Assessment_MemberFunctions-------------------------------------------------------------
        public Assessment(string title, int totalMarks, int totalWeightage)
        {
            this.id = -1;
            this.title = title;
            this.dateCreated = DateTime.Now;
            this.totalMarks = totalMarks;
            this.totalWeightage = totalWeightage;
        }
        public static Assessment getAssessment(string title)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            Assessment assessment = new Assessment("Empty", -1, -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Assessment WHERE Title = '" + title + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    assessment.id = result.GetInt32(0);
                    assessment.title = result.GetString(1);
                    assessment.dateCreated = result.GetDateTime(2);
                    assessment.totalMarks = result.GetInt32(3);
                    assessment.totalWeightage = result.GetInt32(4);
                    break;
                }
            }
            con.Close();
            return assessment;
        }
        public static bool deleteAssessmentById(int id)
        {
            List<AssessmentComponent> assessmentComponentList = AssessmentComponent.retrieveAssessmentComponents(id);
            foreach(AssessmentComponent ac in assessmentComponentList)
            {
                AssessmentComponent.deleteAssessmentComponentById(ac.Id);
            }
            if (Query.Execute("DELETE FROM Assessment WHERE Id = '" + id + "'") > 0) return true;
            else return false;
        }
        public static Assessment getAssessmentById(int id)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            Assessment assessment = new Assessment("Empty", -1, -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Assessment WHERE Id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    assessment.id = result.GetInt32(0);
                    assessment.title = result.GetString(1);
                    assessment.dateCreated = result.GetDateTime(2);
                    assessment.totalMarks = result.GetInt32(3);
                    assessment.totalWeightage = result.GetInt32(4);
                    break;
                }
            }
            con.Close();
            return assessment;
        }

        public static List<Assessment> retrieveAssessments()
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<Assessment> assessmentList = new List<Assessment>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Assessment";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    Assessment assessment = new Assessment(result.GetString(1), result.GetInt32(3), result.GetInt32(4));
                    assessment.id = result.GetInt32(0);
                    assessment.dateCreated = result.GetDateTime(2);
                    assessmentList.Add(assessment);
                }
            }
            con.Close();
            return assessmentList;
        }

        public static int addAssessment(Assessment assessment)
        {
            int status = 0;
            string conString = Query.connectionString;
            SqlDataReader result = null;
            bool found = false;
            Assessment tempAssessment = new Assessment("Empty", -1, -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Assessment WHERE Id = '" + assessment.id + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    tempAssessment.id = result.GetInt32(0);
                    tempAssessment.title = result.GetString(1);
                    tempAssessment.dateCreated = result.GetDateTime(2);
                    tempAssessment.totalMarks = result.GetInt32(3);
                    tempAssessment.totalWeightage = result.GetInt32(4);

                    found = true;
                    break;
                }
                result.Close();
            }
            if (found)
            {
                if (
                    (!tempAssessment.title.Equals("Empty")) &&
                    (
                      (tempAssessment.title != assessment.title) ||
                      (tempAssessment.totalMarks != assessment.totalMarks) ||
                      (tempAssessment.totalWeightage != assessment.totalWeightage)
                    )&&
                    (Assessment.getAssessment(assessment.title).id == -1 || Assessment.getAssessment(assessment.title).id == tempAssessment.id)
                   )
                {
                    Query.Execute("UPDATE Assessment SET Title = '" + assessment.title + "', TotalMarks = '" + assessment.totalMarks + "', TotalWeightage = '" + assessment.totalWeightage + "' WHERE Id = '" + assessment.id + "'");
                    status = 2;
                }
            }
            else
            {
                bool shouldAdd = true;
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "SELECT * FROM Assessment WHERE Title = '" + assessment.title + "'";
                    SqlCommand cmd = new SqlCommand(q, con);
                    result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        shouldAdd = false;
                        break;
                    }
                    result.Close();
                }
                if (shouldAdd)
                {
                    Query.Execute("INSERT INTO Assessment(Title, DateCreated, TotalMarks, TotalWeightage) values ('" + assessment.title + "', '" + assessment.dateCreated + "', '" + assessment.totalMarks + "', '" + assessment.totalWeightage + "')");
                    status = 1;
                }
            }
            con.Close();
            return status;
        }
    }
    //AssessmentComponent_Class------------------------------------------------------------
    public class AssessmentComponent
    {
        //AssessmentComponent_DataMembers--------------------------------------------------
        int id;
        string name;
        int rubricId;
        int totalMarks;
        DateTime dateCreated;
        DateTime dateUpdated;
        int assessmentId;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                dateUpdated = DateTime.Now;
            }
        }

        public int RubricId
        {
            get
            {
                return rubricId;
            }

            set
            {
                rubricId = value;
                dateUpdated = DateTime.Now;
            }
        }

        public int TotalMarks
        {
            get
            {
                return totalMarks;
            }

            set
            {
                totalMarks = value;
                dateUpdated = DateTime.Now;
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }
            set
            {
                dateCreated = value;
            }
        }

        public DateTime DateUpdated
        {
            get
            {
                return dateUpdated;
            }
            set
            {
                dateUpdated = value;
            }
        }

        public int AssessmentId
        {
            get
            {
                return assessmentId;
            }

            set
            {
                assessmentId = value;
                dateUpdated = DateTime.Now;
            }
        }
        //AssessmentComponent_MemberFunctions--------------------------------------------------
        public AssessmentComponent(string name, int rubricId, int totalMarks, int assessmentId)
        {
            this.id = -1;
            this.name = name;
            this.rubricId = rubricId;
            this.totalMarks = totalMarks;
            this.dateCreated = DateTime.Now;
            this.dateUpdated = DateTime.Now;
            this.assessmentId = assessmentId;
        }

        public static AssessmentComponent getAssessmentComponent(string name, int assessmentId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            AssessmentComponent assessmentComponent = new AssessmentComponent("Empty", -1, -1, -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM AssessmentComponent WHERE Name = '" + name + "' AND AssessmentId = '" + assessmentId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    assessmentComponent.id = result.GetInt32(0);
                    assessmentComponent.name = result.GetString(1);
                    assessmentComponent.rubricId = result.GetInt32(2);
                    assessmentComponent.totalMarks = result.GetInt32(3);
                    assessmentComponent.dateCreated = result.GetDateTime(4);
                    assessmentComponent.dateUpdated = result.GetDateTime(5);
                    assessmentComponent.assessmentId = result.GetInt32(6);
                    break;
                }
            }
            con.Close();
            return assessmentComponent;
        }

        public static AssessmentComponent getAssessmentComponentById(int id)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            AssessmentComponent assessmentComponent = new AssessmentComponent("Empty", -1, -1, -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM AssessmentComponent WHERE Id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    assessmentComponent.id = result.GetInt32(0);
                    assessmentComponent.name = result.GetString(1);
                    assessmentComponent.rubricId = result.GetInt32(2);
                    assessmentComponent.totalMarks = result.GetInt32(3);
                    assessmentComponent.dateCreated = result.GetDateTime(4);
                    assessmentComponent.dateUpdated = result.GetDateTime(5);
                    assessmentComponent.assessmentId = result.GetInt32(6);
                    break;
                }
            }
            con.Close();
            return assessmentComponent;
        }

        public static int addAssessmentComponent(AssessmentComponent assessmentComponent)
        {
            if (assessmentComponent.name == "Empty") return 0;
            string conString = Query.connectionString;
            SqlDataReader result = null;
            bool found = false;
            AssessmentComponent tempAssessmentComponent = new AssessmentComponent("Empty", -1, -1, -1);
            int status = 0;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM AssessmentComponent WHERE Id = '" + assessmentComponent.id + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    tempAssessmentComponent.id = result.GetInt32(0);
                    tempAssessmentComponent.name = result.GetString(1);
                    tempAssessmentComponent.rubricId = result.GetInt32(2);
                    tempAssessmentComponent.totalMarks = result.GetInt32(3);
                    tempAssessmentComponent.dateCreated = result.GetDateTime(4);
                    tempAssessmentComponent.dateUpdated = result.GetDateTime(5);
                    tempAssessmentComponent.assessmentId = result.GetInt32(6);

                    found = true;
                    break;
                }
                result.Close();
            }
            if (found)
            {
                if (
                    (!tempAssessmentComponent.name.Equals("Empty")) &&
                    (
                      (tempAssessmentComponent.name != assessmentComponent.name) ||
                      (tempAssessmentComponent.rubricId != assessmentComponent.rubricId) ||
                      (tempAssessmentComponent.totalMarks != assessmentComponent.totalMarks) ||
                      (tempAssessmentComponent.assessmentId != assessmentComponent.assessmentId)
                    )&&
                    (AssessmentComponent.getAssessmentComponent(assessmentComponent.name, assessmentComponent.assessmentId).id == -1 || AssessmentComponent.getAssessmentComponent(assessmentComponent.name, assessmentComponent.assessmentId).id == tempAssessmentComponent.id)
                  )
                {
                    Query.Execute("UPDATE AssessmentComponent SET Name = '" + assessmentComponent.name + "', RubricId = '" + assessmentComponent.rubricId + "', TotalMarks = '" + assessmentComponent.totalMarks + "', AssessmentId = '" + assessmentComponent.assessmentId + "' WHERE Id = '" + assessmentComponent.id + "'");
                    status = 2;
                }
            }
            else
            {
                bool shouldAdd = true;
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "SELECT * FROM AssessmentComponent WHERE Name = '" + assessmentComponent.name + "'AND RubricId = '" + assessmentComponent.rubricId + "'AND AssessmentId = '" + assessmentComponent.assessmentId + "'";
                    SqlCommand cmd = new SqlCommand(q, con);
                    result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        shouldAdd = false;
                        break;
                    }
                    result.Close();
                }
                if (shouldAdd)
                {
                    Query.Execute("INSERT INTO AssessmentComponent(Name, RubricId, TotalMarks, DateCreated, DateUpdated, AssessmentId) VALUES ('" + assessmentComponent.name + "', '" + assessmentComponent.rubricId + "', '" + assessmentComponent.totalMarks + "', '" + assessmentComponent.DateCreated + "', '" + assessmentComponent.dateUpdated + "', '" + assessmentComponent.assessmentId + "')");
                    status = 1;
                }
            }
            con.Close();
            return status;
        }
        public static List<AssessmentComponent> retrieveAssessmentComponents(int assessmentId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<AssessmentComponent> assessmentComponentList = new List<AssessmentComponent>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM AssessmentComponent WHERE AssessmentId = '" + assessmentId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    AssessmentComponent assessmentComponent = new AssessmentComponent(result.GetString(1), result.GetInt32(2), result.GetInt32(3), result.GetInt32(6));
                    assessmentComponent.id = result.GetInt32(0);
                    assessmentComponent.dateCreated = result.GetDateTime(4);
                    assessmentComponent.dateUpdated = result.GetDateTime(5);
                    assessmentComponentList.Add(assessmentComponent);
                }
            }
            con.Close();
            return assessmentComponentList;
        }
        
        public static List<AssessmentComponent> retrieveAssessmentComponents()
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<AssessmentComponent> assessmentComponentList = new List<AssessmentComponent>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM AssessmentComponent ";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    AssessmentComponent assessmentComponent = new AssessmentComponent(result.GetString(1), result.GetInt32(2), result.GetInt32(3), result.GetInt32(6));
                    assessmentComponent.id = result.GetInt32(0);
                    assessmentComponent.dateCreated = result.GetDateTime(4);
                    assessmentComponent.dateUpdated = result.GetDateTime(5);
                    assessmentComponentList.Add(assessmentComponent);
                }
            }
            con.Close();
            return assessmentComponentList;
        }
        public static bool deleteAssessmentComponentById(int id)
        {
            if (Query.Execute("DELETE FROM AssessmentComponent WHERE Id = '" + id + "'") > 0) return true;
            else return false;
        }
    }
    //ClassAttendance_Class------------------------------------------------------------
    public class ClassAttendance
    {
        //ClassAttendance_DataMembers--------------------------------------------------
        int id;
        DateTime attendanceDate;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public DateTime AttendanceDate
        {
            get
            {
                return attendanceDate;
            }

            set
            {
                attendanceDate = value;
            }
        }
        //ClassAttendance_MemberFunctions----------------------------------------------------
        public ClassAttendance()
        {
            this.id = -1;
            this.attendanceDate = DateTime.Now;
        }

        public static ClassAttendance getClassAttendanceById(int id)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            ClassAttendance classAttendance = new ClassAttendance();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM ClassAttendance WHERE Id = '" + id.ToString() + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    classAttendance.id = result.GetInt32(0);
                    classAttendance.attendanceDate = result.GetDateTime(1);
                    break;
                }
            }
            con.Close();
            return classAttendance;
        }
        public static ClassAttendance getClassAttendanceByDate(DateTime date)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            ClassAttendance classAttendance = new ClassAttendance();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM ClassAttendance WHERE YEAR(AttendanceDate) = '" + date.Year + "' AND MONTH(AttendanceDate) = '" + date.Month + "' AND DAY(AttendanceDate) = '" + date.Day + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    classAttendance.id = result.GetInt32(0);
                    classAttendance.attendanceDate = result.GetDateTime(1);
                    break;
                }
            }
            con.Close();
            return classAttendance;
        }

        public static List<ClassAttendance> retrieveClassAttendance()
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<ClassAttendance> classAttendanceList = new List<ClassAttendance>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM ClassAttendance";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    ClassAttendance classAttendance = new ClassAttendance();
                    classAttendance.id = result.GetInt32(0);
                    classAttendance.attendanceDate = result.GetDateTime(1);
                    classAttendanceList.Add(classAttendance);
                }
            }
            con.Close();
            return classAttendanceList;
        }
        public static int addClassAttendance(ClassAttendance classAttendance)
        {
            int status = 0;
            string conString = Query.connectionString;
            SqlDataReader result = null;
            bool found = false;
            ClassAttendance tempClassAttendance = new ClassAttendance();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM ClassAttendance WHERE Id = '" + classAttendance.id + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    tempClassAttendance.id = result.GetInt32(0);
                    tempClassAttendance.attendanceDate = result.GetDateTime(1);

                    found = true;
                    break;
                }
                result.Close();
            }
            if (found)
            {
                if (
                    tempClassAttendance.attendanceDate.Year != classAttendance.attendanceDate.Year ||
                    tempClassAttendance.attendanceDate.Month != classAttendance.attendanceDate.Month ||
                    tempClassAttendance.attendanceDate.Day != classAttendance.attendanceDate.Day
                    )
                {
                    Query.Execute("UPDATE ClassAttendance SET AttendanceDate = '" + classAttendance.attendanceDate + "' WHERE Id = '"+classAttendance.id+"'");
                    status = 2;
                }
            }
            else
            {
                bool shouldAdd = true;
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "SELECT * FROM ClassAttendance WHERE YEAR(AttendanceDate) = '" + classAttendance.attendanceDate.Year + "'AND MONTH(AttendanceDate) = '" + classAttendance.attendanceDate.Month + "'AND DAY(AttendanceDate) = '" + classAttendance.attendanceDate.Day + "'";
                    SqlCommand cmd = new SqlCommand(q, con);
                    result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        shouldAdd = false;
                        break;
                    }
                    result.Close();
                }
                if (shouldAdd)
                {
                    Query.Execute("INSERT INTO ClassAttendance(AttendanceDate) values ('" + classAttendance.attendanceDate + "')");
                    status = 1;
                }
            }
            con.Close();
            return status;
        }
        public static bool deleteClassAttendanceById(int id)
        {
            List<StudentAttendance> studentAttendanceList = StudentAttendance.retrieveStudentAttendancesByAttendanceId(id);
            foreach(StudentAttendance sta in studentAttendanceList)
            {
                StudentAttendance.deleteStudentAttendance(sta.AttendanceId, sta.StudentId);
            }
            if (Query.Execute("DELETE FROM ClassAttendance WHERE Id = '" + id + "'") > 0) return true;
            else return false;
        }

    }
    //Lookup_Class----------------------------------------------------------------------
    public class Lookup
    {
        //Lookup_DataMembers-------------------------------------------------------------
        int lookupId;
        string name;
        string category;

        public int LookupId
        {
            get
            {
                return lookupId;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
            }
        }

        //Lookup_MemberFunctions-------------------------------------------------------------
        public Lookup(string name, string category)
        {
            this.lookupId = -1;
            this.name = name;
            this.category = category;
        }

        public static Lookup getLookup(string name, string category)
        {
            string str = name;
            string conString = Query.connectionString;
            SqlDataReader result = null;
            Lookup lookup = new Lookup("Empty", "Empty");
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Lookup WHERE Name = '" + name + "' AND Category = '" + category + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    lookup.lookupId = result.GetInt32(0);
                    lookup.name = result.GetString(1);
                    lookup.category = result.GetString(2);
                    break;
                }
            }
            con.Close();
            return lookup;
        }

        public static Lookup getLookupById(int lookupId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            Lookup lookup = new Lookup("Empty", "Empty");
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Lookup WHERE LookupId = '" + lookupId.ToString() + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    lookup.lookupId = result.GetInt32(0);
                    lookup.name = result.GetString(1);
                    lookup.category = result.GetString(2);
                    break;
                }
            }
            con.Close();
            return lookup;
        }

        public static List<Lookup> retrieveLookups()
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<Lookup> lookupList = new List<Lookup>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Lookup";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    Lookup lookup = new Lookup(result.GetString(1), result.GetString(2));
                    lookup.lookupId = result.GetInt32(0);

                    lookupList.Add(lookup);
                }
            }
            con.Close();
            return lookupList;
        }

        public static List<Lookup> retrieveLookupsByName(string name)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<Lookup> lookupList = new List<Lookup>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Lookup WHERE Name = '" + name + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    Lookup lookup = new Lookup(result.GetString(1), result.GetString(2));
                    lookup.lookupId = result.GetInt32(0);

                    lookupList.Add(lookup);
                }
            }
            con.Close();
            return lookupList;
        }
        public static List<Lookup> retrieveLookupsByCategory(string category)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<Lookup> lookupList = new List<Lookup>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Lookup WHERE Category = '" + category + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    Lookup lookup = new Lookup(result.GetString(1), result.GetString(2));
                    lookup.lookupId = result.GetInt32(0);

                    lookupList.Add(lookup);
                }
            }
            con.Close();
            return lookupList;
        }

        public static int addLookup(Lookup lookup)
        {
            int status = 0;
            string conString = Query.connectionString;
            SqlDataReader result = null;
            bool found = false;
            Lookup tempLookup = new Lookup("Empty", "Empty");
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Lookup WHERE LookupId = '" + lookup.lookupId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    tempLookup.lookupId = result.GetInt32(0);
                    tempLookup.name = result.GetString(1);
                    tempLookup.category = result.GetString(2);

                    found = true;
                    break;
                }
                result.Close();
            }
            if (found)
            {
                if (
                    (!tempLookup.Name.Equals("Empty") && !tempLookup.category.Equals("Empty")) &&
                    (
                      (!tempLookup.name.Equals(lookup.name)) ||
                      (!tempLookup.category.Equals(lookup.category))
                    )
                   )
                {
                    Query.Execute("UPDATE Lookup SET Name = '" + lookup.name + "', Category = '" + lookup.category + "' WHERE LookupId = '"+lookup.lookupId+"'");
                    status = 2;
                }
            }
            else
            {
                bool shouldAdd = true;
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "SELECT * FROM Lookup WHERE Name = '" + lookup.name + "' AND Category = '" + lookup.category + "'";
                    SqlCommand cmd = new SqlCommand(q, con);
                    result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        shouldAdd = false;
                        break;
                    }
                    result.Close();
                }
                if (shouldAdd)
                {
                    Query.Execute("INSERT INTO Lookup(Name, Category) values ('" + lookup.name + "', '" + lookup.category + "')");
                    status = 1;
                }
            }
            con.Close();
            return status;
        }
    }
    //Student_Class----------------------------------------------------------------------
    public class Student
    {
        //Student_DataMembers-------------------------------------------------------------
        int id;
        string firstName;
        string lastName;
        string contact;
        string email;
        string registrationNumber;
        int status;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string Contact
        {
            get
            {
                return contact;
            }

            set
            {
                contact = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return registrationNumber;
            }

            set
            {
                registrationNumber = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        //Student_MemberFunctions-------------------------------------------------------------
        public Student(string firstName, string lastName, string contact, string email, string registrationNumber, int status)
        {
            this.id = -1;
            this.firstName = firstName;
            this.lastName = lastName;
            this.contact = contact;
            this.email = email;
            this.registrationNumber = registrationNumber;
            this.status = status;
        }
        public static bool deleteStudentById(int id)
        {
            List<StudentResult> studentResultList = StudentResult.retrieveStudentResultByStudentId(id);
            foreach(StudentResult sr in studentResultList)
            {
                StudentResult.deleteStudentResult(sr.StudentId, sr.AssessmentComponentId);
            }

            List<StudentAttendance> studentAttendanceList = StudentAttendance.retrieveStudentAttendancesByStudentId(id);
            foreach(StudentAttendance sa in studentAttendanceList)
            {
                StudentAttendance.deleteStudentAttendance(sa.AttendanceId, sa.StudentId);
            }

            if (Query.Execute("DELETE FROM Student WHERE Id = '" + id + "'") > 0) return true;
            else return false;
        }
        public static Student getStudent(string contact, string email, string registrationNumber)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            Student student = new Student("Empty", "Empty", "Empty", "Empty", "Empty", -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Student WHERE Contact = '" + contact + "' AND Email = '"+email+"' AND RegistrationNumber = '"+registrationNumber+"'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    student.id = result.GetInt32(0);
                    student.firstName = result.GetString(1);
                    student.lastName = result.GetString(2);
                    student.contact = result.GetString(3);
                    student.email = result.GetString(4);
                    student.registrationNumber = result.GetString(5);
                    student.status = result.GetInt32(6);

                    break;
                }
            }
            con.Close();
            return student;
        }
        public static Student getStudentByContact(string contact)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            Student student = new Student("Empty", "Empty", "Empty", "Empty", "Empty", -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Student WHERE Contact = '" + contact + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    student.id = result.GetInt32(0);
                    student.firstName = result.GetString(1);
                    student.lastName = result.GetString(2);
                    student.contact = result.GetString(3);
                    student.email = result.GetString(4);
                    student.registrationNumber = result.GetString(5);
                    student.status = result.GetInt32(6);

                    break;
                }
            }
            con.Close();
            return student;
        }
        public static Student getStudentByEmail(string email)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            Student student = new Student("Empty", "Empty", "Empty", "Empty", "Empty", -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Student WHERE Email = '" + email + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    student.id = result.GetInt32(0);
                    student.firstName = result.GetString(1);
                    student.lastName = result.GetString(2);
                    student.contact = result.GetString(3);
                    student.email = result.GetString(4);
                    student.registrationNumber = result.GetString(5);
                    student.status = result.GetInt32(6);

                    break;
                }
            }
            con.Close();
            return student;
        }

        public static Student getStudentByRegistrationNumber(string registrationNumber)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            Student student = new Student("Empty", "Empty", "Empty", "Empty", "Empty", -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Student WHERE RegistrationNumber = '" + registrationNumber + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    student.id = result.GetInt32(0);
                    student.firstName = result.GetString(1);
                    student.lastName = result.GetString(2);
                    student.contact = result.GetString(3);
                    student.email = result.GetString(4);
                    student.registrationNumber = result.GetString(5);
                    student.status = result.GetInt32(6);

                    break;
                }
            }
            con.Close();
            return student;
        }
        public static Student getStudentById(int id)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            Student student = new Student("Empty", "Empty", "Empty", "Empty", "Empty", -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Student WHERE Id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    student.id = result.GetInt32(0);
                    student.firstName = result.GetString(1);
                    student.lastName = result.GetString(2);
                    student.contact = result.GetString(3);
                    student.email = result.GetString(4);
                    student.registrationNumber = result.GetString(5);
                    student.status = result.GetInt32(6);

                    break;
                }
            }
            con.Close();
            return student;
        }
        public static List<Student> retrieveStudents()
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<Student> studentList = new List<Student>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Student";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    Student student = new Student(result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4), result.GetString(5), result.GetInt32(6));
                    student.id = result.GetInt32(0);

                    studentList.Add(student);
                }
            }
            con.Close();
            return studentList;
        }
        public static List<Student> retrieveActiveStudents()
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<Student> studentList = new List<Student>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Student WHERE Status = 5";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    Student student = new Student(result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4), result.GetString(5), result.GetInt32(6));
                    student.id = result.GetInt32(0);

                    studentList.Add(student);
                }
            }
            con.Close();
            return studentList;
        }
        public static List<Student> retrieveStudentsByStatus(int status)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<Student> studentList = new List<Student>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Student WHERE Status = '" + status + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    Student student = new Student(result.GetString(1), result.GetString(2), result.GetString(3), result.GetString(4), result.GetString(5), result.GetInt32(6));
                    student.id = result.GetInt32(0);

                    studentList.Add(student);
                }
            }
            con.Close();
            return studentList;
        }

        public static int addStudent(Student student)
        {
            int status = 0;
            string conString = Query.connectionString;
            SqlDataReader result = null;
            bool found = false;
            Student tempStudent = new Student("Empty", "Empty", "Empty", "Empty", "Empty", -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM Student WHERE Id = '" + student.id + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    tempStudent.id = result.GetInt32(0);
                    tempStudent.firstName = result.GetString(1);
                    tempStudent.lastName = result.GetString(2);
                    tempStudent.contact = result.GetString(3);
                    tempStudent.email = result.GetString(4);
                    tempStudent.registrationNumber = result.GetString(5);
                    tempStudent.status = result.GetInt32(6);

                    found = true;
                    break;
                }
                result.Close();
            }
            if (found)
            {
                if (
                    (!tempStudent.firstName.Equals("Empty") && !tempStudent.lastName.Equals("Empty") && !tempStudent.contact.Equals("Empty") && !tempStudent.email.Equals("Empty") && !tempStudent.registrationNumber.Equals("Empty") && !(tempStudent.status == -1)) &&
                    (
                      (!tempStudent.firstName.Equals(student.firstName)) ||
                      (!tempStudent.lastName.Equals(student.lastName)) ||
                      (!tempStudent.contact.Equals(student.contact)) ||
                      (!tempStudent.email.Equals(student.email)) ||
                      (!tempStudent.registrationNumber.Equals(student.registrationNumber)) ||
                      (!(tempStudent.status == student.status))
                    )&&
                    (
                      (
                        Student.getStudentByContact(student.contact).id == -1 ||
                        Student.getStudentByEmail(student.email).id == -1 ||
                        Student.getStudentByRegistrationNumber(student.registrationNumber).id == -1
                      ) ||
                    (Student.getStudent(student.contact, student.email, student.registrationNumber).id == tempStudent.id))
                  )
                {
                    Query.Execute("UPDATE Student SET FirstName = '" + student.firstName + "', LastName = '" + student.lastName + "', Contact = '" + student.contact + "', Email = '" + student.email + "', RegistrationNumber = '" + student.registrationNumber + "', Status = '" + student.status + "' WHERE Id = '"+student.id+"'");
                    status = 2;
                }
            }
            else
            {
                bool shouldAdd = true;
                if (con.State == System.Data.ConnectionState.Open)
                {
                    //string q = "SELECT * FROM Student WHERE FirstName = '" + student.firstName + "' AND  LastName = '" + student.lastName + "' AND Contact = '" + student.contact + "' AND Email = '" + student.email + "' AND RegistrationNumber = '" + student.registrationNumber + "' AND Status = '" + student.status + "'";
                    string q = "SELECT * FROM Student WHERE Contact = '" + student.contact + "' OR Email = '" + student.email + "' OR RegistrationNumber = '" + student.registrationNumber + "'";
                    SqlCommand cmd = new SqlCommand(q, con);
                    result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        shouldAdd = false;
                        break;
                    }
                    result.Close();
                }
                if (shouldAdd)
                {
                    Query.Execute("INSERT INTO Student(FirstName, LastName, Contact, Email, RegistrationNumber, Status) values ('" + student.firstName + "', '" + student.lastName + "', '" + student.contact + "', '" + student.email + "', '" + student.registrationNumber + "', '" + student.status + "')");
                    status = 1;
                }
            }
            con.Close();
            return status;
        }
    }
    //StudentAttendance_Class----------------------------------------------------------------------
    class StudentAttendance
    {
        //StudentAttendance_DataMembers-------------------------------------------------------------
        int attendanceId;
        int studentId;
        int attendanceStatus;

        public int AttendanceId
        {
            get
            {
                return attendanceId;
            }

            set
            {
                attendanceId = value;
            }
        }

        public int StudentId
        {
            get
            {
                return studentId;
            }

            set
            {
                studentId = value;
            }
        }

        public int AttendanceStatus
        {
            get
            {
                return attendanceStatus;
            }

            set
            {
                attendanceStatus = value;
            }
        }
        //StudentAttendance_MemberFunctions-------------------------------------------------------------
        public StudentAttendance(int attendanceId, int studentId, int attendanceStatus)
        {
            this.AttendanceId = attendanceId;
            this.StudentId = studentId;
            this.AttendanceStatus = attendanceStatus;
        }

        public static StudentAttendance getStudentAttendance(int attendanceId, int studentId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            StudentAttendance studentAttendance = new StudentAttendance(-1, -1, -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM StudentAttendance WHERE AttendanceId = '" + attendanceId + "' AND StudentId = '" + studentId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    studentAttendance.attendanceId = result.GetInt32(0);
                    studentAttendance.studentId = result.GetInt32(1);
                    studentAttendance.attendanceStatus = result.GetInt32(2);

                    break;
                }
            }
            con.Close();
            return studentAttendance;
        }
        public static List<StudentAttendance> retrieveStudentAttendances()
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<StudentAttendance> studentAttendanceList = new List<StudentAttendance>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM StudentAttendance ";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    StudentAttendance studentAttendance = new StudentAttendance(result.GetInt32(0), result.GetInt32(1), result.GetInt32(2));

                    studentAttendanceList.Add(studentAttendance);
                }
            }
            con.Close();
            return studentAttendanceList;
        }
        public static List<StudentAttendance> retrieveStudentAttendancesByStudentId(int studentId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<StudentAttendance> studentAttendanceList = new List<StudentAttendance>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM StudentAttendance WHERE StudentId = '"+studentId+"'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    StudentAttendance studentAttendance = new StudentAttendance(result.GetInt32(0), result.GetInt32(1), result.GetInt32(2));
                    
                    studentAttendanceList.Add(studentAttendance);
                }
            }
            con.Close();
            return studentAttendanceList;
        }
        public static List<StudentAttendance> retrieveStudentAttendancesByAttendanceId(int attendanceId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<StudentAttendance> studentAttendanceList = new List<StudentAttendance>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM StudentAttendance WHERE AttendanceId = '" + attendanceId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    StudentAttendance studentAttendance = new StudentAttendance(result.GetInt32(0), result.GetInt32(1), result.GetInt32(2));

                    studentAttendanceList.Add(studentAttendance);
                }
            }
            con.Close();
            return studentAttendanceList;
        }
        
        public static int addStudentAttendance(StudentAttendance studentAttendance, StudentAttendance updatedStudentAttendance)
        {
            int status = 0;
            string conString = Query.connectionString;
            SqlDataReader result = null;
            bool found = false;
            StudentAttendance tempStudentAttendance = new StudentAttendance(-1, -1, -1);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM StudentAttendance WHERE AttendanceId = '" + studentAttendance.attendanceId + "' AND StudentId = '"+studentAttendance.studentId+"'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    tempStudentAttendance.attendanceId = result.GetInt32(0);
                    tempStudentAttendance.studentId = result.GetInt32(1);
                    tempStudentAttendance.attendanceStatus = result.GetInt32(2);
                    
                    found = true;
                    break;
                }
                result.Close();
            }
            if (found)
            {
                if (
                    ((tempStudentAttendance.attendanceId != -1) && (tempStudentAttendance.studentId != -1) && (tempStudentAttendance.attendanceStatus != -1)) &&
                    (
                      (tempStudentAttendance.attendanceStatus != updatedStudentAttendance.attendanceStatus)
                    )
                   )
                {
                    Query.Execute("UPDATE StudentAttendance SET AttendanceStatus = '" + updatedStudentAttendance.attendanceStatus + "' WHERE StudentId = '" + studentAttendance.studentId + "' AND AttendanceId = '" + studentAttendance.attendanceId + "'");
                    status = 2;
                }
            }
            else
            {
                bool shouldAdd = true;
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "SELECT * FROM StudentAttendance WHERE AttendanceId = '" + studentAttendance.attendanceId + "' AND  StudentId = '" + studentAttendance.studentId +"'";
                    SqlCommand cmd = new SqlCommand(q, con);
                    result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        shouldAdd = false;
                        break;
                    }
                    result.Close();
                }
                if (shouldAdd)
                {
                    Query.Execute("INSERT INTO StudentAttendance(AttendanceId, StudentId, AttendanceStatus) values ('" + studentAttendance.attendanceId + "', '" + studentAttendance.StudentId + "', '" + studentAttendance.attendanceStatus + "')");
                    status = 1;
                }
            }
            con.Close();
            return status;
        }
        public static bool deleteStudentAttendance(int attendanceId, int studentId)
        {
            if (Query.Execute("DELETE FROM StudentAttendance WHERE StudentId = '" + studentId + "' AND AttendanceId = '" + attendanceId + "'") > 0) return true;
            else return false;
        }
    }
    //StudentResult_Class----------------------------------------------------------------------
    class StudentResult
    {
        //StudentResult_DataMembers-------------------------------------------------------------
        int studentId;
        int assessmentComponentId;
        int rubricMeasurementId;
        DateTime evaluationDate;

        public int StudentId
        {
            get
            {
                return studentId;
            }

            set
            {
                studentId = value;
            }
        }

        public int AssessmentComponentId
        {
            get
            {
                return assessmentComponentId;
            }

            set
            {
                assessmentComponentId = value;
            }
        }

        public int RubricMeasurementId
        {
            get
            {
                return rubricMeasurementId;
            }

            set
            {
                rubricMeasurementId = value;
            }
        }

        public DateTime EvaluationDate
        {
            get
            {
                return evaluationDate;
            }

            set
            {
                evaluationDate = value;
            }
        }

        //StudentAttendance_MemberFunctions-------------------------------------------------------------
        public StudentResult(int studentId, int assessmentComponentId, int rubricMeasurementId, DateTime evaluationDate)
        {
            this.studentId = studentId;
            this.assessmentComponentId = assessmentComponentId;
            this.rubricMeasurementId = rubricMeasurementId;
            this.evaluationDate = evaluationDate;
        }

        public static StudentResult getStudentResult(int studentId, int assessmentComponentId, int rubricMeasurementId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            StudentResult studentResult = new StudentResult(-1, -1, -1, DateTime.Now);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM StudentResult WHERE StudentId = '" + studentId + "' AND AssessmentComponentId = '" + assessmentComponentId + "' AND RubricMeasurementId = '" + rubricMeasurementId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    studentResult.studentId = result.GetInt32(0);
                    studentResult.assessmentComponentId = result.GetInt32(1);
                    studentResult.rubricMeasurementId = result.GetInt32(2);
                    studentResult.evaluationDate = result.GetDateTime(3);

                    break;
                }
            }
            con.Close();
            return studentResult;
        }
        public static StudentResult getStudentResult(int studentId, int assessmentComponentId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            StudentResult studentResult = new StudentResult(-1, -1, -1, DateTime.Now);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM StudentResult WHERE StudentId = '" + studentId + "' AND AssessmentComponentId = '" + assessmentComponentId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    studentResult.studentId = result.GetInt32(0);
                    studentResult.assessmentComponentId = result.GetInt32(1);
                    studentResult.rubricMeasurementId = result.GetInt32(2);
                    studentResult.evaluationDate = result.GetDateTime(3);

                    break;
                }
            }
            con.Close();
            return studentResult;
        }

        public static List<StudentResult> retrieveStudentResultByStudentId(int studentId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<StudentResult> studentResultList = new List<StudentResult>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM StudentResult WHERE StudentId = '" + studentId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    StudentResult studentResult = new StudentResult(result.GetInt32(0), result.GetInt32(1), result.GetInt32(2), result.GetDateTime(3));

                    studentResultList.Add(studentResult);
                }
            }
            con.Close();
            return studentResultList;
        }
        public static List<StudentResult> retrieveStudentResultByAssessmentComponentId(int assessmentComponentId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<StudentResult> studentResultList = new List<StudentResult>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM StudentResult WHERE AssessmentComponentId = '" + assessmentComponentId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    StudentResult studentResult = new StudentResult(result.GetInt32(0), result.GetInt32(1), result.GetInt32(2), result.GetDateTime(3));

                    studentResultList.Add(studentResult);
                }
            }
            con.Close();
            return studentResultList;
        }
        public static List<StudentResult> retrieveStudentResultByRubricMeasurementId(int rubricMeasurementId)
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<StudentResult> studentResultList = new List<StudentResult>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM StudentResult WHERE RubricMeasurementId = '" + rubricMeasurementId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    StudentResult studentResult = new StudentResult(result.GetInt32(0), result.GetInt32(1), result.GetInt32(2), result.GetDateTime(3));

                    studentResultList.Add(studentResult);
                }
            }
            con.Close();
            return studentResultList;
        }
        public static List<StudentResult> retrieveStudentResults()
        {
            string conString = Query.connectionString;
            SqlDataReader result = null;
            List<StudentResult> studentResultList = new List<StudentResult>();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM StudentResult ";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    StudentResult studentResult = new StudentResult(result.GetInt32(0), result.GetInt32(1), result.GetInt32(2), result.GetDateTime(3));

                    studentResultList.Add(studentResult);
                }
            }
            con.Close();
            return studentResultList;
        }
        public static int addStudentResult(StudentResult studentResult, StudentResult updatedStudentResult)
        {
            int status = 0;
            string conString = Query.connectionString;
            SqlDataReader result = null;
            bool found = false;
            StudentResult tempStudentResult = new StudentResult(-1, -1, -1, DateTime.Now);
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "SELECT * FROM StudentResult WHERE StudentId = '" + studentResult.studentId + "' AND AssessmentComponentId = '" + studentResult.assessmentComponentId + "'";// AND RubricMeasurementId = '" + studentResult.rubricMeasurementId + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                result = cmd.ExecuteReader();
                while (result.Read())
                {
                    tempStudentResult.studentId = result.GetInt32(0);
                    tempStudentResult.assessmentComponentId = result.GetInt32(1);
                    tempStudentResult.rubricMeasurementId = result.GetInt32(2);
                    tempStudentResult.evaluationDate = result.GetDateTime(3);
                    
                    found = true;
                    break;
                }
                result.Close();
            }
            if (found)
            {
                if (
                    ((tempStudentResult.studentId != -1) && (tempStudentResult.assessmentComponentId != -1) && (tempStudentResult.rubricMeasurementId != -1)) &&
                    (
                      (tempStudentResult.rubricMeasurementId != updatedStudentResult.rubricMeasurementId)
                    )
                   )
                {
                    Query.Execute("UPDATE StudentResult SET RubricMeasurementId = '" + updatedStudentResult.rubricMeasurementId + "' WHERE StudentId = '" + studentResult.studentId + "' AND AssessmentComponentId = '" + studentResult.assessmentComponentId + "'");
                    status = 2;
                }
            }
            else
            {
                bool shouldAdd = true;
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = "SELECT * FROM StudentResult WHERE StudentId = '" + studentResult.studentId + "' AND  AssessmentComponentId = '" + studentResult.assessmentComponentId + "'";// AND RubricMeasurementId = '" + studentResult.rubricMeasurementId + "'";
                    SqlCommand cmd = new SqlCommand(q, con);
                    result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        shouldAdd = false;
                        break;
                    }
                    result.Close();
                }
                if (shouldAdd)
                {
                    Query.Execute("INSERT INTO StudentResult(StudentId, AssessmentComponentId, RubricMeasurementId, EvaluationDate) values ('" + studentResult.studentId + "', '" + studentResult.assessmentComponentId + "', '" + studentResult.rubricMeasurementId + "', '"+ studentResult.evaluationDate.ToString(@"yyyy-MM-dd") + "')");
                    status = 1;
                }
            }
            con.Close();
            return status;
        }
        public static bool deleteStudentResult(int studentId, int assessmentComponentId)
        {
            if (Query.Execute("DELETE FROM StudentResult WHERE StudentId = '" + studentId + "' AND AssessmentComponentId = '"+ assessmentComponentId +"'") > 0) return true;
            else return false;
        }
    }
    public class Validation
    {
        public static bool validateName(string str)
        {
            if (!Regex.Match(str, "^[A-Za-z ]+$").Success)
            {
                return false;
            }
            return true;
        }
        public static bool validatePhone(string Phone)
        {
            if (string.IsNullOrEmpty(Phone))
                return false;
            var r = new Regex(@"^\(?([0-9]{4})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$");
            return r.IsMatch(Phone);
        }
        public static bool validateRegistration(string Registration)
        {
            if (string.IsNullOrEmpty(Registration))
                return false;
            var r = new Regex(@"^\(?([1-9]{1})\)?([0-9]{3})[-]([A-Z]{2,3})[-]([0-9]{1,4})$");
            return r.IsMatch(Registration);
        }
        public static bool validateEmail(string Email)
        {
            if (string.IsNullOrEmpty(Email))
                return false;
            var r = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return r.IsMatch(Email);
        }
        public static bool validateTitle(string Title)
        {
            if (string.IsNullOrEmpty(Title))
                return false;
            var r = new Regex(@"^[a-zA-Z0-9 ]+$");
            return r.IsMatch(Title);
        }
        public static bool validateMarks(string Marks)
        {
            if (string.IsNullOrEmpty(Marks))
                return false;
            var r = new Regex(@"^[0-9]+$");
            return r.IsMatch(Marks);
        }

    }
    //Report_Class---------------------------------------------------------------------
    class Report
    {
        public static bool writeAssessmentReport(string path, string fileName)
        {
            string conString = Query.connectionString;
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            string queryStudent = "SELECT Id, RegistrationNumber FROM Student ";
            SqlCommand CommandStudent = new SqlCommand(queryStudent, conn);
            SqlDataReader readerStudent = CommandStudent.ExecuteReader();

            DataTable datatableStudent = new DataTable();
            datatableStudent.Load(readerStudent);

            conn = new SqlConnection(conString);
            conn.Open();
            string queryAssessment = "SELECT Id, Title FROM Assessment ";
            SqlCommand CommandAssessment = new SqlCommand(queryAssessment, conn);
            SqlDataReader readerAssessment = CommandAssessment.ExecuteReader();
            DataTable datatableAssessment = new DataTable();


            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(path + "/" + fileName + ".pdf", FileMode.Create));
            document.Open();

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font contentfont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font headingfont = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);

            Paragraph p = new Paragraph(new Chunk("Class Assessment Report \n", headingfont));
            p.Alignment = Element.ALIGN_CENTER;
            document.Add(p);
            p = new Paragraph(new Chunk("\n", headingfont));
            p.Alignment = Element.ALIGN_CENTER;
            document.Add(p);
            datatableAssessment.Load(readerAssessment);
            PdfPTable Report = new PdfPTable(datatableAssessment.Rows.Count + 1);
            p = new Paragraph(new Chunk("Student Registration Number", font));
            Report.AddCell(p);

            Paragraph p1 = new Paragraph(new Chunk("", font));
            for (int asid = 0; asid < datatableAssessment.Rows.Count; asid++)
            {
                string assessment = Assessment.getAssessmentById(Convert.ToInt32(datatableAssessment.Rows[asid].ItemArray[0])).Title;
                p1 = new Paragraph(new Chunk(assessment, font));
                Report.AddCell(p1);
            }
            for (int students = 0; students < datatableStudent.Rows.Count; students++)
            {
                int studentid = Convert.ToInt32(datatableStudent.Rows[students].ItemArray[0]);
                string studentregisterationnumber = Student.getStudentById(studentid).RegistrationNumber;
                string studentEmail = Student.getStudentById(studentid).Email;
                string studentContact = Student.getStudentById(studentid).Contact;
                int AssessmentId;
                int RubricId;
                int assessmentcomponentid;

                p1 = new Paragraph(new Chunk(studentregisterationnumber, font));
                Report.AddCell(p1);
                
                for (int i = 0; i < datatableAssessment.Rows.Count; i++)
                {
                    AssessmentId = Convert.ToInt32(datatableAssessment.Rows[i].ItemArray[0]);
                    conn = new SqlConnection(conString);
                    conn.Open();
                    string queryAssessmentComponent = "SELECT Id, Name, RubricId FROM AssessmentComponent WHERE AssessmentId = @assessmentid";
                    SqlCommand CommandAssessmentComponent = new SqlCommand(queryAssessmentComponent, conn);
                    CommandAssessmentComponent.Parameters.AddWithValue("@assessmentid", AssessmentId);
                    SqlDataReader readerAssessmentComponent = CommandAssessmentComponent.ExecuteReader();
                    DataTable datatableAssessmentComponent = new DataTable();
                    datatableAssessmentComponent.Load(readerAssessmentComponent);
                    string Assessmentname = Assessment.getAssessmentById(AssessmentId).Title;
                    if (datatableAssessmentComponent.Rows.Count == 0)
                    {
                        p = new Paragraph(new Chunk("Nil", contentfont));
                        Report.AddCell(p);

                    }
                    float totalcomponentmarks = 0;
                    float totalstudentmarks = 0;
                    for (int j = 0; j < datatableAssessmentComponent.Rows.Count; j++)
                    {
                        assessmentcomponentid = Convert.ToInt32(datatableAssessmentComponent.Rows[j].ItemArray[0]);
                        string assessmentcomponentname = AssessmentComponent.getAssessmentComponentById(assessmentcomponentid).Name;
                        RubricId = Convert.ToInt32(datatableAssessmentComponent.Rows[j].ItemArray[2]);
                        conn = new SqlConnection(conString);
                        conn.Open();
                        string querystudentassessment = "SELECT RubricMeasurementId FROM StudentResult WHERE AssessmentComponentId = @rid AND StudentId = @sid";
                        SqlCommand Commandstudentassessment = new SqlCommand(querystudentassessment, conn);
                        Commandstudentassessment.Parameters.AddWithValue("@rid", assessmentcomponentid);
                        Commandstudentassessment.Parameters.AddWithValue("@sid", studentid);
                        SqlDataReader readerstudentassessment = Commandstudentassessment.ExecuteReader();
                        DataTable datatablestudentassessment = new DataTable();
                        datatablestudentassessment.Load(readerstudentassessment);
                        string Rubricname = Rubric.getRubricById(RubricId).Details;


                        for (int k = 0; k < datatablestudentassessment.Rows.Count; k++)
                        {

                            int componentmarks = AssessmentComponent.getAssessmentComponentById(assessmentcomponentid).TotalMarks;
                            totalcomponentmarks = (float)totalcomponentmarks + (float)componentmarks;
                            int studentassignedrubriclevelid = StudentResult.getStudentResult(studentid, assessmentcomponentid).RubricMeasurementId;
                            int studentrubriclevel = RubricLevel.getRubricLevelById(studentassignedrubriclevelid).MeasurementLevel;
                            int maxrubriclevel = RubricLevel.getMaxRubricLevel(RubricId).MeasurementLevel;
                            float obtainedmarks = -1;
                            if (studentrubriclevel == -1 || maxrubriclevel == -1)
                            {
                                totalstudentmarks = totalstudentmarks + 0;
                            }
                            else
                            {
                                obtainedmarks = (float)((((float)studentrubriclevel) / ((float)maxrubriclevel)) * ((float)componentmarks));
                                totalstudentmarks = totalstudentmarks + obtainedmarks;
                            }
                        }

                    }
                    float percentage = (totalstudentmarks / totalcomponentmarks) * 100;
                    if (datatableAssessmentComponent.Rows.Count > 0)
                    {
                        if(percentage.ToString() == "NaN")
                        {
                            p1 = new Paragraph(new Chunk((percentage.ToString()), contentfont));
                            Report.AddCell(p1);
                        }
                        else
                        {
                            p1 = new Paragraph(new Chunk((percentage.ToString()) + "%", contentfont));
                            Report.AddCell(p1);
                        }
                    }

                }
            }
            Report.HorizontalAlignment = 12;
            document.Add(Report);
            document.Close();
            return true;
        }
        public static bool writeCloReport(string path, string fileName)
        {
            string conString = Query.connectionString;
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();

            string queryStudent = "SELECT Id, RegistrationNumber FROM Student ";
            SqlCommand CommandStudent = new SqlCommand(queryStudent, conn);
            SqlDataReader readerStudent = CommandStudent.ExecuteReader();
            DataTable datatableStudent = new DataTable();

            conn = new SqlConnection(conString);
            conn.Open();
            datatableStudent.Load(readerStudent);
            string queryclo = "SELECT Id, Name FROM CLO ";
            SqlCommand Commandclo = new SqlCommand(queryclo, conn);
            SqlDataReader readerClo = Commandclo.ExecuteReader();
            DataTable datatableclo = new DataTable();


            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(path + "/" + fileName + ".pdf", FileMode.Create));
            document.Open();
            datatableclo.Load(readerClo);


            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font contentfont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font headingfont = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);

            Paragraph p = new Paragraph(new Chunk("Class CLO Report \n", headingfont));
            p.Alignment = Element.ALIGN_CENTER;


            Paragraph p5 = new Paragraph(new Chunk(" \n", font));
            document.Add(p);
            document.Add(p5);
            PdfPTable Report = new PdfPTable(datatableclo.Rows.Count + 1);
            Paragraph c1 = new Paragraph(new Chunk("Student Registration Number", font));
            Report.AddCell(c1);
            for (int i = 0; i < datatableclo.Rows.Count; i++)
            {
                string CLOName = Clo.getClobyId(Convert.ToInt32(datatableclo.Rows[i].ItemArray[0])).Name;
                c1 = new Paragraph(new Chunk(CLOName, font));
                Report.AddCell(c1);
            }


            for (int sid = 0; sid < datatableStudent.Rows.Count; sid++)
            {
                int studentid = Convert.ToInt32(datatableStudent.Rows[sid].ItemArray[0]);

                string studentregisterationnumber = Student.getStudentById(studentid).RegistrationNumber;
                string studentEmail = Student.getStudentById(studentid).Email;
                string studentContact = Student.getStudentById(studentid).Contact;
                string studentname = Student.getStudentById(studentid).FirstName + " " + Student.getStudentById(studentid).LastName;
                c1 = new Paragraph(new Chunk(studentregisterationnumber, font));
                Report.AddCell(c1);

                int CLOid;
                int RubricId;
                int assessmentcomponentid;



                for (int i = 0; i < datatableclo.Rows.Count; i++)
                {
                    CLOid = Convert.ToInt32(datatableclo.Rows[i].ItemArray[0]);
                    conn = new SqlConnection(conString);
                    conn.Open();
                    string queryrubric = "SELECT Id, Details FROM Rubric WHERE CloId = @cloid";
                    SqlCommand Commandrubric = new SqlCommand(queryrubric, conn);
                    Commandrubric.Parameters.AddWithValue("@cloid", CLOid);
                    SqlDataReader readerRubric = Commandrubric.ExecuteReader();
                    DataTable datatablerubric = new DataTable();
                    datatablerubric.Load(readerRubric);
                    string cloname = Clo.getClobyId(CLOid).Name;
                    if (datatablerubric.Rows.Count == 0)
                    {

                        p = new Paragraph(new Chunk("Nil", font));
                        Report.AddCell(p);

                    }
                    float totalcomponentmarks = 0;
                    float totalstudentmarks = 0;
                    for (int j = 0; j < datatablerubric.Rows.Count; j++)
                    {
                        RubricId = Convert.ToInt32(datatablerubric.Rows[j].ItemArray[0]);
                        conn = new SqlConnection(conString);
                        conn.Open();
                        string queryassessment = "SELECT Id, Name FROM AssessmentComponent WHERE RubricId = @rid";
                        SqlCommand Commandassessment = new SqlCommand(queryassessment, conn);
                        Commandassessment.Parameters.AddWithValue("@rid", RubricId);
                        SqlDataReader readerassessment = Commandassessment.ExecuteReader();
                        DataTable datatableassessment = new DataTable();
                        datatableassessment.Load(readerassessment);
                        string Rubricname = Rubric.getRubricById(RubricId).Details;

                        for (int k = 0; k < datatableassessment.Rows.Count; k++)
                        {
                            assessmentcomponentid = Convert.ToInt32(datatableassessment.Rows[k].ItemArray[0]);
                            string assessmentname = AssessmentComponent.getAssessmentComponentById(assessmentcomponentid).Name;

                            int componentmarks = AssessmentComponent.getAssessmentComponentById(assessmentcomponentid).TotalMarks;
                            totalcomponentmarks = (float)totalcomponentmarks + (float)componentmarks;
                            int studentrubriclevel = RubricLevel.getRubricLevelById(StudentResult.getStudentResult(studentid, assessmentcomponentid).RubricMeasurementId).MeasurementLevel;
                            int maxrubriclevel = RubricLevel.getMaxRubricLevel(RubricId).MeasurementLevel;
                            float obtainedmarks = -1;
                            if (studentrubriclevel == -1 || maxrubriclevel == -1)
                            {
                                totalstudentmarks = totalstudentmarks + 0;
                            }
                            else
                            {
                                obtainedmarks = (float)((((float)studentrubriclevel) / ((float)maxrubriclevel)) * ((float)componentmarks));
                                totalstudentmarks = totalstudentmarks + obtainedmarks;
                            }
                        }
                    }
                    float percentage = (totalstudentmarks / totalcomponentmarks) * 100;
                    if (datatablerubric.Rows.Count > 0)
                    {
                        c1 = new Paragraph(new Chunk((percentage.ToString()) + "%", contentfont));
                        Report.AddCell(c1);
                    }
                }
            }

            Report.HorizontalAlignment = 12;
            document.Add(Report);
            document.Close();
            return true;
        }
    }
}
