namespace VEHICLE_RENTAL.Models
{
    public class MakeRentalModel
    {
        public VehicleModel Vehicle {  get; set; }

        public List<RentalPlaceModel> Places { get; set; }

        public List<RentalInsuranceModel> Insurances { get; set;}

        public List<RentalPaymentMethodModel> PaymentMethods { get; set; }

        public MakeRentalModel(int Id_Vehicle) 
        { 
            VehicleModel VehicleModel = new ();
            RentalPlaceModel RentalPlaceModel = new();
            RentalInsuranceModel RentalInsuranceModel = new();
            RentalPaymentMethodModel RentalPaymentMethodModel = new();
            this.Vehicle = VehicleModel.GetVehicle(Id_Vehicle);
            this.Places = RentalPlaceModel.GetAllRentalPaymentMethods();
            this.Insurances = RentalInsuranceModel.GetRentalInsurances();
            this.PaymentMethods = RentalPaymentMethodModel.GetAllRentalPaymentMethods();
        }
    }
}
