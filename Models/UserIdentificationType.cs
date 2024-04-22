using MySql.Data.MySqlClient;

namespace VEHICLE_RENTAL.Models
{
    public class UserIdentificationType
    {
        public int Id_UserIdentificationType { get; set; } 
        
        public string Name_UserIdentificationType { get; set; }

        public string Symbol_UserIdentificationType { get; set; }

        public List<UserIdentificationType> GetAllUserIdentificationTypes()
        {
            List<UserIdentificationType> UserIdentificationTypes = [];
            string SQLQuery = "SELECT " +
                "vehicle_rental.user_identification_type.Id_UserIdentificationType, " +
                "vehicle_rental.user_identification_type.Name_UserIdentificationType, " +
                "vehicle_rental.user_identification_type.Symbol_UserIdentificationType " +
                "FROM vehicle_rental.user_identification_type " +
                "ORDER BY vehicle_rental.user_identification_type.Id_UserIdentificationType ASC";
            MySqlConnection ConnectionDB = ConnectionModel.Conect();
            try
            {
                ConnectionDB.Open();
                MySqlCommand Command = new(SQLQuery, ConnectionDB);
                MySqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        UserIdentificationType UserIdentificationType = new()
                        {
                            Id_UserIdentificationType = Reader.GetInt32(0),
                            Name_UserIdentificationType = Reader.GetString(1),
                            Symbol_UserIdentificationType = Reader.GetString(2),

                        };
                        UserIdentificationTypes.Add(UserIdentificationType);
                    }
                }
            }
            catch (Exception) { }
            finally
            {
                ConnectionDB.Close();
            }

            return UserIdentificationTypes;
        }
    }
}
