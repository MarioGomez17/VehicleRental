using MySql.Data.MySqlClient;

namespace VEHICLE_RENTAL.Models
{
    public class UserModel
    {
        public int Id_User { get; set; }

        public string Name_User { get; set; }

        public string LastName_User { get; set; }

        public string IdentificationType_User { get; set; }

        public string SymbolIdentificationType_User { get; set; }

        public string IdentificationNumber_User { get; set; }

        public string Phone_User { get; set; }

        public string Email_User { get; set; }

        public string Password_User { get; set; }

        public string UserState_User { get; set; }

        public UserModel GetUser(string UserEmail, string UserPassword)
        {
            UserModel UserModel = new();

            string SQLQuery = "SELECT " +
                "vehicle_rental.user.Id_User, " +
                "vehicle_rental.user.Name_User, " +
                "vehicle_rental.user.LastName_User, " +
                "vehicle_rental.user_identification_type.Name_UserIdentificationType, " +
                "vehicle_rental.user_identification_type.Symbol_UserIdentificationType, " +
                "vehicle_rental.user.IdentificationNumber_User, " + 
                "vehicle_rental.user.Phone_User, " +
                "vehicle_rental.user.Email_User, " +
                "vehicle_rental.user.Password_User, " +
                "vehicle_rental.user_state.Name_UserState " +
                "FROM vehicle_rental.user " +
                "INNER JOIN vehicle_rental.user_identification_type " +
                "ON vehicle_rental.user.Id_UserIdentificationType_User = vehicle_rental.user_identification_type.Id_UserIdentificationType " +
                "INNER JOIN vehicle_rental.user_state " +
                "ON vehicle_rental.user. Id_UserState_User = vehicle_rental.user_state.Id_UserState " +
                "WHERE vehicle_rental.user.Email_User = '" + UserEmail + "' " +
                "AND vehicle_rental.user.Password_User =SHA('" + UserPassword + "') ";
            MySqlConnection ConnectionDB = ConnectionModel.Conect();
            try
            {
                ConnectionDB.Open();
                MySqlCommand Comando = new(SQLQuery, ConnectionDB);
                MySqlDataReader Reader = Comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        UserModel = new()
                        {
                            Id_User = Reader.GetInt32(0),
                            Name_User = Reader.GetString(1),
                            LastName_User = Reader.GetString(2),
                            IdentificationType_User = Reader.GetString(3),
                            SymbolIdentificationType_User = Reader.GetString(4),
                            IdentificationNumber_User = Reader.GetString(5),
                            Phone_User = Reader.GetString(6),
                            Email_User = Reader.GetString(7),
                            Password_User = Reader.GetString(8),
                            UserState_User = Reader.GetString(9),
                        };
                    }
                }
            }
            catch (Exception) { }
            finally
            {
                ConnectionDB.Close();
            }
            return UserModel;
        }
    }
}
