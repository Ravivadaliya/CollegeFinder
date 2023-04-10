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
    }
}
