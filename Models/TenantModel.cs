namespace VEHICLE_RENTAL.Models
{
    public class TenantModel
    {
        public int Id_Tenant { get; set; }

        public string Code_Tenant { get; set; }

        public UserModel User_Tenant { get; set; }

        public List<RentalModel> RentalHistory_Tenant { get; set; }
    }
}
