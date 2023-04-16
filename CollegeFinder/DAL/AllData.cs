using CollegeFinder.Areas.User.Models;
using CollegeFinder.Areas.College.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace CollegeFinder.DAL
{
    public class AllData
    {


        public DataTable Contact_Send_SelectAll(string conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[Contact_Send_selectlectall]");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool? ContactSend_Delete(string conn, int? ContactId)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("Contact_Send_delete");
                sqlDB.AddInParameter(dbCMD, "ContactId", SqlDbType.Int, ContactId);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public DataTable Student_SelectAll(string conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[studentselectall]");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool? studentdelete(string conn, int? studentid)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("studentdelete");
                sqlDB.AddInParameter(dbCMD, "studentid", SqlDbType.Int, studentid);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        #region college

        public DataTable College_selectall(string conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[first50college]");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }   
        public bool? College_Delete(string conn, int? Collegeid)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[collegedelete]");
                sqlDB.AddInParameter(dbCMD, "Collegeid", SqlDbType.Int, Collegeid);                           
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e) 
            {
                return null;
            }
        }

        public DataTable College_SelectByPk(string conn, int? Collegeid)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("CollegeSelectByPk");
                sqlDB.AddInParameter(dbCMD, "Collegeid", SqlDbType.Int, Collegeid);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool? College_Insert(string con , CollegeModel ForCollege)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(con);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[collegeinsert]");
                sqlDB.AddInParameter(dbCMD, "college_Name", SqlDbType.NVarChar,ForCollege.College_Name);
                sqlDB.AddInParameter(dbCMD, "Gender_Accepted", SqlDbType.NVarChar,ForCollege.Genders_Accepted);
                sqlDB.AddInParameter(dbCMD, "Campus_Size", SqlDbType.NVarChar,ForCollege.Campus_Size);
                sqlDB.AddInParameter(dbCMD, "Total_Student_Enrollments", SqlDbType.NVarChar,ForCollege.Total_Student_Enrollments);
                sqlDB.AddInParameter(dbCMD, "Total_Faculty", SqlDbType.NVarChar,ForCollege.Total_Faculty);
                sqlDB.AddInParameter(dbCMD, "Establish_Year", SqlDbType.NVarChar,ForCollege.Established_Year);
                sqlDB.AddInParameter(dbCMD, "Rating", SqlDbType.NVarChar,ForCollege.Rating);
                sqlDB.AddInParameter(dbCMD, "university", SqlDbType.NVarChar,ForCollege.University);
                sqlDB.AddInParameter(dbCMD, "Courses", SqlDbType.NVarChar,ForCollege.Courses);
                sqlDB.AddInParameter(dbCMD, "Facilites", SqlDbType.NVarChar,ForCollege.Facilities);
                sqlDB.AddInParameter(dbCMD, "city", SqlDbType.NVarChar,ForCollege.City);
                sqlDB.AddInParameter(dbCMD, "state", SqlDbType.NVarChar,ForCollege.State);
                sqlDB.AddInParameter(dbCMD, "country", SqlDbType.NVarChar,ForCollege.Country);
                sqlDB.AddInParameter(dbCMD, "college_Type", SqlDbType.NVarChar,ForCollege.College_Type);
                sqlDB.AddInParameter(dbCMD, "Average_Fees", SqlDbType.NVarChar,ForCollege.Average_Fees);
                sqlDB.AddInParameter(dbCMD, "Placement", SqlDbType.Int,ForCollege.Placement);
                sqlDB.AddInParameter(dbCMD, "college_area", SqlDbType.Int,ForCollege.College_area);
                sqlDB.AddInParameter(dbCMD, "Totalseat", SqlDbType.Int,ForCollege.Totalseat);
                sqlDB.AddInParameter(dbCMD, "latitude", SqlDbType.NVarChar,ForCollege.latitude);
                sqlDB.AddInParameter(dbCMD, "longitude", SqlDbType.NVarChar,ForCollege.longitude);
                sqlDB.AddInParameter(dbCMD, "College_image", SqlDbType.NVarChar, ForCollege.College_image);
                sqlDB.AddInParameter(dbCMD, "College_Website", SqlDbType.NVarChar, ForCollege.College_Website);
                sqlDB.AddInParameter(dbCMD, "College_Number", SqlDbType.NVarChar, ForCollege.College_Number);
                sqlDB.AddInParameter(dbCMD, "iframemap", SqlDbType.NVarChar, ForCollege.iframemap);
                sqlDB.AddInParameter(dbCMD, "iframeheight", SqlDbType.NVarChar, ForCollege.iframeheight);
                sqlDB.AddInParameter(dbCMD, "iframewidth", SqlDbType.NVarChar, ForCollege.iframewidth);
                sqlDB.AddInParameter(dbCMD, "Imagepath", SqlDbType.NVarChar, ForCollege.Imagepath);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool? College_Update(string con, CollegeModel ForCollege)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(con);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[collegeupdate]");
                sqlDB.AddInParameter(dbCMD, "Collegeid", SqlDbType.Int, ForCollege.Collegeid);
                sqlDB.AddInParameter(dbCMD, "college_Name", SqlDbType.NVarChar, ForCollege.College_Name);
                sqlDB.AddInParameter(dbCMD, "Gender_Accepted", SqlDbType.NVarChar, ForCollege.Genders_Accepted);
                sqlDB.AddInParameter(dbCMD, "Campus_Size", SqlDbType.NVarChar, ForCollege.Campus_Size);
                sqlDB.AddInParameter(dbCMD, "Total_Student_Enrollments", SqlDbType.NVarChar, ForCollege.Total_Student_Enrollments);
                sqlDB.AddInParameter(dbCMD, "Total_Faculty", SqlDbType.NVarChar, ForCollege.Total_Faculty);
                sqlDB.AddInParameter(dbCMD, "Establish_Year", SqlDbType.NVarChar, ForCollege.Established_Year);
                sqlDB.AddInParameter(dbCMD, "Rating", SqlDbType.NVarChar, ForCollege.Rating);
                sqlDB.AddInParameter(dbCMD, "university", SqlDbType.NVarChar, ForCollege.University);
                sqlDB.AddInParameter(dbCMD, "Courses", SqlDbType.NVarChar, ForCollege.Courses);
                sqlDB.AddInParameter(dbCMD, "Facilites", SqlDbType.NVarChar, ForCollege.Facilities);
                sqlDB.AddInParameter(dbCMD, "city", SqlDbType.NVarChar, ForCollege.City);
                sqlDB.AddInParameter(dbCMD, "state", SqlDbType.NVarChar, ForCollege.State);
                sqlDB.AddInParameter(dbCMD, "country", SqlDbType.NVarChar, ForCollege.Country);
                sqlDB.AddInParameter(dbCMD, "college_Type", SqlDbType.NVarChar, ForCollege.College_Type);
                sqlDB.AddInParameter(dbCMD, "Average_Fees", SqlDbType.NVarChar, ForCollege.Average_Fees);
                sqlDB.AddInParameter(dbCMD, "Placement", SqlDbType.Int, ForCollege.Placement);
                sqlDB.AddInParameter(dbCMD, "college_area", SqlDbType.Int, ForCollege.College_area);
                sqlDB.AddInParameter(dbCMD, "Totalseat", SqlDbType.Int, ForCollege.Totalseat);
                sqlDB.AddInParameter(dbCMD, "latitude", SqlDbType.NVarChar, ForCollege.latitude);
                sqlDB.AddInParameter(dbCMD, "longitude", SqlDbType.NVarChar, ForCollege.longitude);
                sqlDB.AddInParameter(dbCMD, "College_image", SqlDbType.NVarChar, ForCollege.College_image);
                sqlDB.AddInParameter(dbCMD, "College_Website", SqlDbType.NVarChar, ForCollege.College_Website);
                sqlDB.AddInParameter(dbCMD, "College_Number", SqlDbType.NVarChar, ForCollege.College_Number);
                sqlDB.AddInParameter(dbCMD, "iframemap", SqlDbType.NVarChar, ForCollege.iframemap);
                sqlDB.AddInParameter(dbCMD, "iframeheight", SqlDbType.NVarChar, ForCollege.iframeheight);
                sqlDB.AddInParameter(dbCMD, "iframewidth", SqlDbType.NVarChar, ForCollege.iframewidth);
                sqlDB.AddInParameter(dbCMD, "Imagepath", SqlDbType.NVarChar, ForCollege.Imagepath);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion



    }
}
