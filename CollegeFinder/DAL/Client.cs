using CollegeFinder.Areas.College.Models;
using CollegeFinder.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace CollegeFinder.DAL
{
    public class Client
    {

        public bool? Contact_Send_Insert(string con, Contact_SendModel ForContact)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(con);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[Contact_Send_insert]");
                sqlDB.AddInParameter(dbCMD, "Name", SqlDbType.NVarChar, ForContact.Name);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, ForContact.Email);
                sqlDB.AddInParameter(dbCMD, "City", SqlDbType.NVarChar, ForContact.City);
                sqlDB.AddInParameter(dbCMD, "Country", SqlDbType.NVarChar, ForContact.Country);
                sqlDB.AddInParameter(dbCMD, "Message", SqlDbType.NVarChar, ForContact.Message);
                sqlDB.AddInParameter(dbCMD, "Creationdate", SqlDbType.DateTime, ForContact.Creationdate);


                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }
        }



        public DataTable College_SelectAll(string conn)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[collegeselectall]");

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



        public DataTable College_SelectByPk(string conn,int? Collegeid)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(conn);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[CollegeSelectByPk]");
                sqlDB.AddInParameter(dbCMD,"Collegeid",SqlDbType.Int,Collegeid);
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



        public DataTable ContactUs_Selectall(string conn)
        {
            SqlDatabase sqlDB = new SqlDatabase(conn);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("[ContactUs_Selectall]");

            DataTable dt = new DataTable();
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                dt.Load(dr);
            }
            return dt;
        }

        public bool? Student_Insert(string con,AdmissionModel admission)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(con);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[studentinsert]");
                sqlDB.AddInParameter(dbCMD, "studentname", SqlDbType.NVarChar, admission.Studentname);
                sqlDB.AddInParameter(dbCMD, "collegeid", SqlDbType.NVarChar, admission.Collegeid);
                sqlDB.AddInParameter(dbCMD, "studentmobile", SqlDbType.NVarChar, admission.Studentmobile);
                sqlDB.AddInParameter(dbCMD, "studentmailid", SqlDbType.NVarChar, admission.StudentEmail);
                sqlDB.AddInParameter(dbCMD, "city", SqlDbType.NVarChar, admission.City);
                sqlDB.AddInParameter(dbCMD, "state", SqlDbType.NVarChar, admission.State);
                sqlDB.AddInParameter(dbCMD, "creationdate", SqlDbType.NVarChar, admission.Creationdate);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        //public string Collegename_SelectByPk(string conn)
        //{
        //    try
        //    {
        //        SqlDatabase sqlDB = new SqlDatabase(conn);
        //        DbCommand dbCMD = sqlDB.GetStoredProcCommand("[SelectCollegeByPk]");
        //        string s  = sqlDB.ExecuteReader(dbCMD);
        //        return dt;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

    }
}
