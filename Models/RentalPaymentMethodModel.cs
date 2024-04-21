using MySql.Data.MySqlClient;

namespace VEHICLE_RENTAL.Models
{
    public class RentalPaymentMethodModel
    {
        public int Id_RentalPaymentMethod { get; set; }
        public string Name_RentalPaymentMethod { get; set; }

        public List<RentalPaymentMethodModel> GetAllRentalPaymentMethods()
        {
            List<RentalPaymentMethodModel> RentalPaymentMethods = [];
            string SQLQuery = "SELECT " +
                "vehicle_rental.rental_payment_method.Id_RentalPaymentMethod, " +
                "vehicle_rental.rental_payment_method.Name_RentalPaymentMethod " +
                "FROM vehicle_rental.rental_payment_method " +
                "ORDER BY vehicle_rental.rental_payment_method.Id_RentalPaymentMethod ASC";
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
                        RentalPaymentMethodModel RentalPaymentMethod = new()
                        {
                            Id_RentalPaymentMethod = Reader.GetInt32(0),
                            Name_RentalPaymentMethod = Reader.GetString(1),

                        };
                        RentalPaymentMethods.Add(RentalPaymentMethod);
                    }
                }
            }
            catch (Exception) { }
            finally
            {
                ConnectionDB.Close();
            }

            return RentalPaymentMethods;
        }
    }
}
