namespace APIGymTEC.Utility
{
    public class ConnectionString
    {
        private static string cName = "Data Source=.; Initial Catalog=StudentManagement;User ID=<ourID>;Password=<OurPassword>";
        public static string CName
        {
            get => cName;
        }
    }
}
