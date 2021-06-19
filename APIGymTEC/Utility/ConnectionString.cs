namespace APIGymTEC.Utility
{
    public class ConnectionString
    {
        private static string cName = "Data Source=.; Initial Catalog=GymTEC;User ID=sa;Password=contraseña";
        public static string CName
        {
            get => cName;
        }
    }
}
