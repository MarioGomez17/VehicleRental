using MySql.Data.MySqlClient;

namespace VEHICLE_RENTAL.Models
{
    public class ConnectionModel
    {

        public static MySqlConnection Conect()
        {
            String Server = "localhost";
            String DataBase = "vehicle_rental";
            String User = "root";
            String Password = "M@rio1002960089";
            String ConnectionString = "database = " + DataBase + "; Data Source = " + Server + "; User Id = " + User + "; Password = " + Password;

            try
            {
                MySqlConnection ConecctionBD = new(ConnectionString);
                return ConecctionBD;
            }
            catch (MySqlException)
            {
                return null;
            }
        }

        public static Boolean ExecuteNonQuerySentence(String SQLQuery)
        {
            Boolean Flag = false;
            MySqlConnection ConecctionBD = Conect();
            ConecctionBD.Open();
            try
            {
                MySqlCommand Command = new(SQLQuery, ConecctionBD);
                Command.ExecuteNonQuery();
                Flag = true;
            }
            catch (MySqlException)
            {
                Flag = false;
            }
            finally
            {
                ConecctionBD.Close();
            }
            return Flag;
        }

    }
}
