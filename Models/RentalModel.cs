namespace VEHICLE_RENTAL.Models
{
    public class RentalModel
    {
        public int Id_Rental { get; set; }

        public DateTime DateStart_Rental { get; set; }

        public DateTime DateEnd_Rental { get; set; }

        public float Price_Rental { get; set; }

        public bool Washed_Rental { get; set; }

        public TenantModel Tenant_Rental { get; set; }

        public VehicleModel Vehicle_Rental { get; set; }

        public string RentalPlace_Rental { get; set; }

        public string RentalPaymentMethod_Rental { get; set; }

        public string RentalPaymentState_Rental { get; set; }

        public string NameRentalInsurance_Rental { get; set; }

        public float PriceRentalInsurance_Rental { get; set; }

        public float RateRental_Rental { get; set; }

        public string CommentRateRental_Rental { get; set; }

        public string RentalState_Rental { get; set; }
    }
}
