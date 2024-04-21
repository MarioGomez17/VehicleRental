using MySql.Data.MySqlClient;

namespace VEHICLE_RENTAL.Models
{
    public class RentalPlaceModel
    {
        public int Id_RentalPlace { get; set; }
        public string Name_RentalPlace { get; set; }

        public List<RentalPlaceModel> GetAllRentalPaymentMethods()
        {
            List<RentalPlaceModel> RentalPlaces = [];
            string SQLQuery = "SELECT " +
                "vehicle_rental.rental_place.Id_RentalPlace, " +
                "vehicle_rental.rental_place.Name_RentalPlace " +
                "FROM vehicle_rental.rental_place " +
                "ORDER BY vehicle_rental.rental_place.Id_RentalPlace ASC";
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
                        RentalPlaceModel RentalPlace = new()
                        {
                            Id_RentalPlace = Reader.GetInt32(0),
                            Name_RentalPlace = Reader.GetString(1),

                        };
                        RentalPlaces.Add(RentalPlace);
                    }
                }
            }
            catch (Exception) { }
            finally
            {
                ConnectionDB.Close();
            }

            return RentalPlaces;
        }
    }
}
