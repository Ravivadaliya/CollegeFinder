using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using CollegeFinder.Areas.Admin.Models;

namespace CollegeFinder.DAL
{
    public class Admindal
    {
        public DataTable Admin_SelectAll(string ConnStr)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[Adminselectall]");
                
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

        public DataTable Admin_SelectByPk(string ConnStr, int? Adminid)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[Admin_selectbypk]");
                sqlDB.AddInParameter(dbCMD, "Adminid", SqlDbType.Int, Adminid);

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
         public DataTable AdminNameSelectByEmail(string ConnStr, String? Adminemail)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[adminnameusingemail]");
                sqlDB.AddInParameter(dbCMD, "AdminEmail", SqlDbType.VarChar, Adminemail);

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

        public DataTable Admin_SelectBy_Email_Pass(string ConnStr, string AdminEmail, string Adminpassword)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("Admin_selectBy_EmailPassword");
                sqlDB.AddInParameter(dbCMD, "AdminEmail", SqlDbType.VarChar, AdminEmail);
                sqlDB.AddInParameter(dbCMD, "Adminpassword", SqlDbType.VarChar, Adminpassword);

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


        public bool? Admin_Insert(string con, AdminModel Foradmin)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(con);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[Admininsert]");
                sqlDB.AddInParameter(dbCMD, "Adminname", SqlDbType.NVarChar, Foradmin.Adminname);
                sqlDB.AddInParameter(dbCMD, "AdminEmail", SqlDbType.NVarChar, Foradmin.AdminEmail);
                sqlDB.AddInParameter(dbCMD, "Adminpassword", SqlDbType.NVarChar, Foradmin.Adminpassword);
                sqlDB.AddInParameter(dbCMD, "AdminMobil", SqlDbType.NVarChar, Foradmin.AdminMobil);
                sqlDB.AddInParameter(dbCMD, "AdminCity", SqlDbType.NVarChar, Foradmin.AdminCity);
                sqlDB.AddInParameter(dbCMD, "AdminState", SqlDbType.NVarChar, Foradmin.AdminState);
                sqlDB.AddInParameter(dbCMD, "AdminCountry", SqlDbType.NVarChar, Foradmin.AdminCountry);
                sqlDB.AddInParameter(dbCMD, "AdminCreationdate", SqlDbType.DateTime, Foradmin.AdminCreationdate);
                sqlDB.AddInParameter(dbCMD, "AdminModificationdate", SqlDbType.DateTime, Foradmin.AdminModificationdate);


                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool? Admin_Update(string con, AdminModel Foradmin)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(con);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[Adminupdate]");
                sqlDB.AddInParameter(dbCMD, "Adminid", SqlDbType.NVarChar, Foradmin.Adminid);
                sqlDB.AddInParameter(dbCMD, "Adminname", SqlDbType.NVarChar, Foradmin.Adminname);
                sqlDB.AddInParameter(dbCMD, "AdminEmail", SqlDbType.NVarChar, Foradmin.AdminEmail);
                sqlDB.AddInParameter(dbCMD, "Adminpassword", SqlDbType.NVarChar, Foradmin.Adminpassword);
                sqlDB.AddInParameter(dbCMD, "AdminMobil", SqlDbType.NVarChar, Foradmin.AdminMobil);
                sqlDB.AddInParameter(dbCMD, "AdminCity", SqlDbType.NVarChar, Foradmin.AdminCity);
                sqlDB.AddInParameter(dbCMD, "AdminState", SqlDbType.NVarChar, Foradmin.AdminState);
                sqlDB.AddInParameter(dbCMD, "AdminCountry", SqlDbType.NVarChar, Foradmin.AdminCountry);
                sqlDB.AddInParameter(dbCMD, "AdminModificationdate", SqlDbType.DateTime, Foradmin.AdminModificationdate);


                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool? Admin_delete(string con, int Adminid)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(con);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("[Admindelete]");
                sqlDB.AddInParameter(dbCMD, "Adminid", SqlDbType.Int, Adminid);
              
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}
