using Microsoft.EntityFrameworkCore;

namespace DotnetWebApiUnitTesting.Helpers
{
    public static class GlobalAttributesHelper
    {
        public static MySqlConfiguration mySqlConfiguration = new MySqlConfiguration();
    }


    public class MySqlConfiguration
    {
        public string? connectionString { get; set; }
        public ServerVersion? serverVersion { get; set; }
    }
}
