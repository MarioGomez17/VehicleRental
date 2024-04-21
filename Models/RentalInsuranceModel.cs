using MySql.Data.MySqlClient;

namespace VEHICLE_RENTAL.Models
{
    public class RentalInsuranceModel
    {
        public int Id_RentalInsurance { get; set; }
        public string Name_RentalInsurance { get; set; }
        public float Price_RentalInsurance { get; set; }

        public List<RentalInsuranceModel> GetRentalInsurances()
        {
            List<RentalInsuranceModel> RentalInsurances = [];
            string SQLQuery = "SELECT " +
                "vehicle_rental.rental_insurance.Id_RentalInsurance, " +
                "vehicle_rental.rental_insurance.Name_RentalInsurance, " +
                "vehicle_rental.rental_insurance.Price_RentalInsurance " +
                "FROM vehicle_rental.rental_insurance " +
                "ORDER BY vehicle_rental.rental_insurance.Id_RentalInsurance ASC";
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
                        RentalInsuranceModel RentalInsurance = new()
                        {
                            Id_RentalInsurance = Reader.GetInt32(0),
                            Name_RentalInsurance = Reader.GetString(1),
                            Price_RentalInsurance = Reader.GetFloat(2)
                            
                        };
                        RentalInsurances.Add(RentalInsurance);
                    }
                }
            }
            catch (Exception) { }
            finally
            {
                ConnectionDB.Close();
            }
            
            return RentalInsurances;
        }
    }
}
