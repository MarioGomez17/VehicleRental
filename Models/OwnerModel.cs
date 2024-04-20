namespace VEHICLE_RENTAL.Models
{
    public class OwnerModel
    {
        public int Id_Owner { get; set; }

        public string Code_Owner { get; set; }

        public UserModel User_Owner { get; set; }

        public List<RentalModel> RentalHistory_Owner { get; set; }

    }
}
