using MySql.Data.MySqlClient;
using System.Data;

namespace VEHICLE_RENTAL.Models
{
    public class VehicleModel
    {
        public int Id_Vehicle { get; set; }

        public string VehicleType_Vehicle { get; set; }

        public string VehicleClassification_Vehicle { get; set; }

        public string LicensePlate_Vehicle { get; set; }

        public int Model_Vehicle { get; set; }

        public int CylinderCapacity_Vehicle { get; set; }

        public string Color_Vehicle { get; set; }

        public int PassengerCapacity_Vehicle { get; set; }

        public string InsuranceNumber_vehicle { get; set; }

        public string CertificateNumberCDA_Vehicle { get; set; }

        public float RentalPriceDay_Vehicle { get; set; }

        public string PhotoRoute_Vehicle { get; set; }

        public string VehicleCity_Vehicle { get; set; }

        public string VehicleBrand_Vehicle { get; set; }

        public string VehicleOutline_Vehicle { get; set; }

        public string VehicleFuelType_Vehicle { get; set; }

        public string VehicleState_Vehicle { get; set; }

        public int Owner_Vehicle { get; set; }

        public List<VehicleModel> GetAllVehicles()
        {
            List<VehicleModel> VehiclesList = [];
            string SQLQuery = "SELECT " +
                "vehicle_rental.vehicle.Id_Vehicle, " +
                "vehicle_rental.vehicle_type.Name_VehicleType, " +
                "vehicle_rental.vehicle_classification.Name_VehicleClassification, " +
                "vehicle_rental.vehicle.LicensePlate_Vehicle, " +
                "vehicle_rental.vehicle.Model_Vehicle, " +
                "vehicle_rental.vehicle.CylinderCapacity_Vehicle, " +
                "vehicle_rental.vehicle.Color_Vehicle, " +
                "vehicle_rental.vehicle.PassengerCapacity_Vehicle, " +
                "vehicle_rental.vehicle.InsuranceNumber_vehicle, " +
                "vehicle_rental.vehicle.CertificateNumberCDA_Vehicle, " +
                "vehicle_rental.vehicle.RentalPriceDay_Vehicle, " +
                "vehicle_rental.vehicle.PhotoRoute_Vehicle, " +
                "vehicle_rental.vehicle_city.Name_VehicleCity, " +
                "vehicle_rental.vehicle_brand.Name_VehicleBrand, " +
                "vehicle_rental.vehicle_outline.Name_VehicleOutline, " +
                "vehicle_rental.vehicle_fuel_type.Name_VehicleFuelType, " +
                "vehicle_rental.vehicle_state.Name_VehicleState, " +
                "vehicle_rental.vehicle.Owner_Vehicle " +
                "FROM vehicle_rental.vehicle " +
                "INNER JOIN vehicle_rental.vehicle_classification " +
                "ON vehicle_rental.vehicle.VehicleClassification_Vehicle = vehicle_rental.vehicle_classification.Id_VehicleClassification " +
                "INNER JOIN vehicle_rental.vehicle_city " +
                "ON vehicle_rental.vehicle_city.Id_VehicleCity = vehicle_rental.vehicle.VehicleCity_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_fuel_type " +
                "ON vehicle_rental.vehicle_fuel_type.Id_VehicleFuelType = vehicle_rental.vehicle.VehicleFuelType_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_state " +
                "ON vehicle_rental.vehicle_state.Id_VehicleState = vehicle_rental.vehicle.VehicleState_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_outline " +
                "ON vehicle_rental.vehicle_outline.Id_VehicleOutline = vehicle_rental.vehicle.VehicleOutline_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_brand " +
                "ON vehicle_rental.vehicle_brand.Id_VehicleBrand = vehicle_rental.vehicle_outline.VehicleBrand_VehicleOutline " +
                "INNER JOIN vehicle_rental.vehicle_type " +
                "ON vehicle_rental.vehicle_type.Id_VehicleType = vehicle_rental.vehicle_brand.VehicleType_VehicleBrand " +
                "ORDER BY vehicle_rental.vehicle.Id_Vehicle ASC";
            MySqlConnection ConnectionBD = ConnectionModel.Conect();
            try
            {
                ConnectionBD.Open();
                MySqlCommand Command = new(SQLQuery, ConnectionBD);
                MySqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        VehicleModel Vehicle = new()
                        {
                            Id_Vehicle = Reader.GetInt32(0),
                            VehicleType_Vehicle = Reader.GetString(1),
                            VehicleClassification_Vehicle = Reader.GetString(2),
                            LicensePlate_Vehicle = Reader.GetString(3),
                            Model_Vehicle = Reader.GetInt32(4),
                            CylinderCapacity_Vehicle = Reader.GetInt32(5),
                            Color_Vehicle = Reader.GetString(6),
                            PassengerCapacity_Vehicle = Reader.GetInt32(7),
                            InsuranceNumber_vehicle = Reader.GetString(8),
                            CertificateNumberCDA_Vehicle = Reader.GetString(9),
                            RentalPriceDay_Vehicle = Reader.GetFloat(10),
                            PhotoRoute_Vehicle = Reader.GetString(11),
                            VehicleCity_Vehicle = Reader.GetString(12),
                            VehicleBrand_Vehicle = Reader.GetString(13),
                            VehicleOutline_Vehicle = Reader.GetString(14),
                            VehicleFuelType_Vehicle = Reader.GetString(15),
                            VehicleState_Vehicle = Reader.GetString(16),
                            Owner_Vehicle = Reader.GetInt32(17),
                        };
                        VehiclesList.Add(Vehicle);
                    }
                }
            }
            catch (Exception) { }
            finally
            {
                ConnectionBD.Close();
            }
            foreach (var Vehicle in VehiclesList)
            {
                if (Vehicle.VehicleState_Vehicle != "Activo")
                {
                    VehiclesList.Remove(Vehicle);
                }
            }
            return VehiclesList;
        }

        public List<VehicleModel> GetAllVehicles(string City)
        {
            List<VehicleModel> VehiclesList = [];
            string SQLQuery = "SELECT " +
                "vehicle_rental.vehicle.Id_Vehicle, " +
                "vehicle_rental.vehicle_type.Name_VehicleType, " +
                "vehicle_rental.vehicle_classification.Name_VehicleClassification, " +
                "vehicle_rental.vehicle.LicensePlate_Vehicle, " +
                "vehicle_rental.vehicle.Model_Vehicle, " +
                "vehicle_rental.vehicle.CylinderCapacity_Vehicle, " +
                "vehicle_rental.vehicle.Color_Vehicle, " +
                "vehicle_rental.vehicle.PassengerCapacity_Vehicle, " +
                "vehicle_rental.vehicle.InsuranceNumber_vehicle, " +
                "vehicle_rental.vehicle.CertificateNumberCDA_Vehicle, " +
                "vehicle_rental.vehicle.RentalPriceDay_Vehicle, " +
                "vehicle_rental.vehicle.PhotoRoute_Vehicle, " +
                "vehicle_rental.vehicle_city.Name_VehicleCity, " +
                "vehicle_rental.vehicle_brand.Name_VehicleBrand, " +
                "vehicle_rental.vehicle_outline.Name_VehicleOutline, " +
                "vehicle_rental.vehicle_fuel_type.Name_VehicleFuelType, " +
                "vehicle_rental.vehicle_state.Name_VehicleState, " +
                "vehicle_rental.vehicle.Owner_Vehicle " +
                "FROM vehicle_rental.vehicle " +
                "INNER JOIN vehicle_rental.vehicle_classification " +
                "ON vehicle_rental.vehicle.VehicleClassification_Vehicle = vehicle_rental.vehicle_classification.Id_VehicleClassification " +
                "INNER JOIN vehicle_rental.vehicle_city " +
                "ON vehicle_rental.vehicle_city.Id_VehicleCity = vehicle_rental.vehicle.VehicleCity_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_fuel_type " +
                "ON vehicle_rental.vehicle_fuel_type.Id_VehicleFuelType = vehicle_rental.vehicle.VehicleFuelType_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_state " +
                "ON vehicle_rental.vehicle_state.Id_VehicleState = vehicle_rental.vehicle.VehicleState_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_outline " +
                "ON vehicle_rental.vehicle_outline.Id_VehicleOutline = vehicle_rental.vehicle.VehicleOutline_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_brand " +
                "ON vehicle_rental.vehicle_brand.Id_VehicleBrand = vehicle_rental.vehicle_outline.VehicleBrand_VehicleOutline " +
                "INNER JOIN vehicle_rental.vehicle_type " +
                "ON vehicle_rental.vehicle_type.Id_VehicleType = vehicle_rental.vehicle_brand.VehicleType_VehicleBrand " +
                "WHERE vehicle_rental.vehicle_city.Name_VehicleCity = '" + City + "' " +
                "ORDER BY vehicle_rental.vehicle.Id_Vehicle ASC";
            MySqlConnection ConnectionBD = ConnectionModel.Conect();
            try
            {
                ConnectionBD.Open();
                MySqlCommand Command = new(SQLQuery, ConnectionBD);
                MySqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        VehicleModel VehicleModel = new()
                        {
                            Id_Vehicle = Reader.GetInt32(0),
                            VehicleType_Vehicle = Reader.GetString(1),
                            VehicleClassification_Vehicle = Reader.GetString(2),
                            LicensePlate_Vehicle = Reader.GetString(3),
                            Model_Vehicle = Reader.GetInt32(4),
                            CylinderCapacity_Vehicle = Reader.GetInt32(5),
                            Color_Vehicle = Reader.GetString(6),
                            PassengerCapacity_Vehicle = Reader.GetInt32(7),
                            InsuranceNumber_vehicle = Reader.GetString(8),
                            CertificateNumberCDA_Vehicle = Reader.GetString(9),
                            RentalPriceDay_Vehicle = Reader.GetFloat(10),
                            PhotoRoute_Vehicle = Reader.GetString(11),
                            VehicleCity_Vehicle = Reader.GetString(12),
                            VehicleBrand_Vehicle = Reader.GetString(13),
                            VehicleOutline_Vehicle = Reader.GetString(14),
                            VehicleFuelType_Vehicle = Reader.GetString(15),
                            VehicleState_Vehicle = Reader.GetString(16),
                            Owner_Vehicle = Reader.GetInt32(17),
                        };
                        VehiclesList.Add(VehicleModel);
                    }
                }
            }
            catch (Exception) { }
            finally
            {
                ConnectionBD.Close();
            }
            foreach (var Vehicle in VehiclesList)
            {
                if (Vehicle.VehicleState_Vehicle != "Activo")
                {
                    VehiclesList.Remove(Vehicle);
                }
            }
            return VehiclesList;
        }

        public List<VehicleModel> GetAllVehiclesUser(int Owner_Vehicle)
        {
            List<VehicleModel> VehiclesList = [];
            string SQLQuery = "SELECT " +
                "vehicle_rental.vehicle.Id_Vehicle, " +
                "vehicle_rental.vehicle_type.Name_VehicleType, " +
                "vehicle_rental.vehicle_classification.Name_VehicleClassification, " +
                "vehicle_rental.vehicle.LicensePlate_Vehicle, " +
                "vehicle_rental.vehicle.Model_Vehicle, " +
                "vehicle_rental.vehicle.CylinderCapacity_Vehicle, " +
                "vehicle_rental.vehicle.Color_Vehicle, " +
                "vehicle_rental.vehicle.PassengerCapacity_Vehicle, " +
                "vehicle_rental.vehicle.InsuranceNumber_vehicle, " +
                "vehicle_rental.vehicle.CertificateNumberCDA_Vehicle, " +
                "vehicle_rental.vehicle.RentalPriceDay_Vehicle, " +
                "vehicle_rental.vehicle.PhotoRoute_Vehicle, " +
                "vehicle_rental.vehicle_city.Name_VehicleCity, " +
                "vehicle_rental.vehicle_brand.Name_VehicleBrand, " +
                "vehicle_rental.vehicle_outline.Name_VehicleOutline, " +
                "vehicle_rental.vehicle_fuel_type.Name_VehicleFuelType, " +
                "vehicle_rental.vehicle_state.Name_VehicleState, " +
                "vehicle_rental.vehicle.Owner_Vehicle " +
                "FROM vehicle_rental.vehicle " +
                "INNER JOIN vehicle_rental.vehicle_classification " +
                "ON vehicle_rental.vehicle.VehicleClassification_Vehicle = vehicle_rental.vehicle_classification.Id_VehicleClassification " +
                "INNER JOIN vehicle_rental.vehicle_city " +
                "ON vehicle_rental.vehicle_city.Id_VehicleCity = vehicle_rental.vehicle.VehicleCity_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_fuel_type " +
                "ON vehicle_rental.vehicle_fuel_type.Id_VehicleFuelType = vehicle_rental.vehicle.VehicleFuelType_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_state " +
                "ON vehicle_rental.vehicle_state.Id_VehicleState = vehicle_rental.vehicle.VehicleState_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_outline " +
                "ON vehicle_rental.vehicle_outline.Id_VehicleOutline = vehicle_rental.vehicle.VehicleOutline_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_brand " +
                "ON vehicle_rental.vehicle_brand.Id_VehicleBrand = vehicle_rental.vehicle_outline.VehicleBrand_VehicleOutline " +
                "INNER JOIN vehicle_rental.vehicle_type " +
                "ON vehicle_rental.vehicle_type.Id_VehicleType = vehicle_rental.vehicle_brand.VehicleType_VehicleBrand " +
                "WHERE vehicle_rental.vehicle.Owner_Vehicle = '" + Owner_Vehicle + "' " +
                "ORDER BY vehicle_rental.vehicle.Id_Vehicle ASC";
            MySqlConnection ConnectionBD = ConnectionModel.Conect();
            try
            {
                ConnectionBD.Open();
                MySqlCommand Command = new(SQLQuery, ConnectionBD);
                MySqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        VehicleModel Vehicle = new()
                        {
                            Id_Vehicle = Reader.GetInt32(0),
                            VehicleType_Vehicle = Reader.GetString(1),
                            VehicleClassification_Vehicle = Reader.GetString(2),
                            LicensePlate_Vehicle = Reader.GetString(3),
                            Model_Vehicle = Reader.GetInt32(4),
                            CylinderCapacity_Vehicle = Reader.GetInt32(5),
                            Color_Vehicle = Reader.GetString(6),
                            PassengerCapacity_Vehicle = Reader.GetInt32(7),
                            InsuranceNumber_vehicle = Reader.GetString(8),
                            CertificateNumberCDA_Vehicle = Reader.GetString(9),
                            RentalPriceDay_Vehicle = Reader.GetFloat(10),
                            PhotoRoute_Vehicle = Reader.GetString(11),
                            VehicleCity_Vehicle = Reader.GetString(12),
                            VehicleBrand_Vehicle = Reader.GetString(13),
                            VehicleOutline_Vehicle = Reader.GetString(14),
                            VehicleFuelType_Vehicle = Reader.GetString(15),
                            VehicleState_Vehicle = Reader.GetString(16),
                            Owner_Vehicle = Reader.GetInt32(17),
                        };
                        VehiclesList.Add(Vehicle);
                    }
                }
            }
            catch (Exception) { }
            finally
            {
                ConnectionBD.Close();
            }
            foreach (var Vehicle in VehiclesList)
            {
                if (Vehicle.VehicleState_Vehicle != "Activo")
                {
                    VehiclesList.Remove(Vehicle);
                }
            }
            return VehiclesList;
        }

        public VehicleModel GetVehicle(int Id_Vehicle)
        {
            VehicleModel Vehicle = new();
            string SQLQuery = "SELECT " +
                "vehicle_rental.vehicle.Id_Vehicle, " +
                "vehicle_rental.vehicle_type.Name_VehicleType, " +
                "vehicle_rental.vehicle_classification.Name_VehicleClassification, " +
                "vehicle_rental.vehicle.LicensePlate_Vehicle, " +
                "vehicle_rental.vehicle.Model_Vehicle, " +
                "vehicle_rental.vehicle.CylinderCapacity_Vehicle, " +
                "vehicle_rental.vehicle.Color_Vehicle, " +
                "vehicle_rental.vehicle.PassengerCapacity_Vehicle, " +
                "vehicle_rental.vehicle.InsuranceNumber_vehicle, " +
                "vehicle_rental.vehicle.CertificateNumberCDA_Vehicle, " +
                "vehicle_rental.vehicle.RentalPriceDay_Vehicle, " +
                "vehicle_rental.vehicle.PhotoRoute_Vehicle, " +
                "vehicle_rental.vehicle_city.Name_VehicleCity, " +
                "vehicle_rental.vehicle_brand.Name_VehicleBrand, " +
                "vehicle_rental.vehicle_outline.Name_VehicleOutline, " +
                "vehicle_rental.vehicle_fuel_type.Name_VehicleFuelType, " +
                "vehicle_rental.vehicle_state.Name_VehicleState, " +
                "vehicle_rental.vehicle.Owner_Vehicle " +
                "FROM vehicle_rental.vehicle " +
                "INNER JOIN vehicle_rental.vehicle_classification " +
                "ON vehicle_rental.vehicle.VehicleClassification_Vehicle = vehicle_rental.vehicle_classification.Id_VehicleClassification " +
                "INNER JOIN vehicle_rental.vehicle_city " +
                "ON vehicle_rental.vehicle_city.Id_VehicleCity = vehicle_rental.vehicle.VehicleCity_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_fuel_type " +
                "ON vehicle_rental.vehicle_fuel_type.Id_VehicleFuelType = vehicle_rental.vehicle.VehicleFuelType_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_state " +
                "ON vehicle_rental.vehicle_state.Id_VehicleState = vehicle_rental.vehicle.VehicleState_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_outline " +
                "ON vehicle_rental.vehicle_outline.Id_VehicleOutline = vehicle_rental.vehicle.VehicleOutline_Vehicle " +
                "INNER JOIN vehicle_rental.vehicle_brand " +
                "ON vehicle_rental.vehicle_brand.Id_VehicleBrand = vehicle_rental.vehicle_outline.VehicleBrand_VehicleOutline " +
                "INNER JOIN vehicle_rental.vehicle_type " +
                "ON vehicle_rental.vehicle_type.Id_VehicleType = vehicle_rental.vehicle_brand.VehicleType_VehicleBrand " +
                "WHERE vehicle_rental.vehicle.Id_Vehicle = '" + Id_Vehicle + "' " +
                "ORDER BY vehicle_rental.vehicle.Id_Vehicle ASC";
            MySqlConnection ConnectionBD = ConnectionModel.Conect();
            try
            {
                ConnectionBD.Open();
                MySqlCommand Command = new(SQLQuery, ConnectionBD);
                MySqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Vehicle = new()
                        {
                            Id_Vehicle = Reader.GetInt32(0),
                            VehicleType_Vehicle = Reader.GetString(1),
                            VehicleClassification_Vehicle = Reader.GetString(2),
                            LicensePlate_Vehicle = Reader.GetString(3),
                            Model_Vehicle = Reader.GetInt32(4),
                            CylinderCapacity_Vehicle = Reader.GetInt32(5),
                            Color_Vehicle = Reader.GetString(6),
                            PassengerCapacity_Vehicle = Reader.GetInt32(7),
                            InsuranceNumber_vehicle = Reader.GetString(8),
                            CertificateNumberCDA_Vehicle = Reader.GetString(9),
                            RentalPriceDay_Vehicle = Reader.GetFloat(10),
                            PhotoRoute_Vehicle = Reader.GetString(11),
                            VehicleCity_Vehicle = Reader.GetString(12),
                            VehicleBrand_Vehicle = Reader.GetString(13),
                            VehicleOutline_Vehicle = Reader.GetString(14),
                            VehicleFuelType_Vehicle = Reader.GetString(15),
                            VehicleState_Vehicle = Reader.GetString(16),
                            Owner_Vehicle = Reader.GetInt32(17),
                        };
                    }
                }
            }
            catch (Exception) { }
            finally
            {
                ConnectionBD.Close();
            }
            return Vehicle;
        }
    }
}
