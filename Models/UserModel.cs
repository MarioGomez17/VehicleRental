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
            return null;
        }
    }
}
