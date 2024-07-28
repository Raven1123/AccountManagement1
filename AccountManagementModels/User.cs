namespace AccountManagementModels
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public UserProfile profile { get; set; }
        public DateTime dateUpdated { get; set; }
        public DateTime dateVerified { get; set; }
        public int status { get; set; } // 1 for Active, 2 for Inactive
    }
}




