using System.Text;

namespace MVCTestEFCore.Data
{
    public static class LocalConnectionString
    {
        public static string ConnectionString => CreateLocalConnectionString();

        private static string CreateLocalConnectionString()
        {
            var sb = new StringBuilder();
            sb.Append(@"Server=(localdb)\mssqllocaldb;");
            sb.Append("Database=mvcefcoreDb;");
            sb.Append("MultipleActiveResultSets=True;");
            return sb.ToString();
        }
    }
}
