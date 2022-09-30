using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ADIONSYS.ConvertFunction
{
    internal class ConvertType
    {
        public string Databasetype(string name, string value)
        {
            string data = name + "=" + value + ";";
            return data;
        }

        public string ConnString(string hostop,string portop, string usernameop, string passwordop, string databaseop)
        {
            string host = Databasetype("Host", hostop);
            string port = Databasetype("Port", portop);
            string username = Databasetype("Username", usernameop);
            string password = Databasetype("Password", passwordop);
            string database = Databasetype("Database", databaseop);
            string databaseaddress = host + port + username + password + database;
            return databaseaddress;
        }

        public void CleanSetting()
        {
            ApplicationSetting.Default.DataBaseAddress = string.Empty;
            ApplicationSetting.Default.Host = string.Empty;
            ApplicationSetting.Default.Port = string.Empty;
            ApplicationSetting.Default.Username = string.Empty;
            ApplicationSetting.Default.Password = string.Empty;
            ApplicationSetting.Default.Database = string.Empty;
            ApplicationSetting.Default.ConnectionState = false;
            ApplicationSetting.Default.Save();
        }

        public static string GetTimeStamp()
        {
            DateTime myDate = DateTime.Now;
            string myDateString = myDate.ToString("yyyy-MM-dd HH:mm:ss");
            return myDateString;
        }

        public static List<string> Hash(int pcs, int length)
        {
            Random Random = new Random();
            List<string> List = new List<string>();
            const string chars = "ABCDEFGHIJKLMNPQRSTUVWXYZabcdefghijklmnpqrstuvwxyz";
            Guid gid = Guid.NewGuid();
            for (int i = 0; i < pcs; i++)
            {
                string sn = new string(Enumerable.Repeat(chars, length).Select(s => s[Random.Next(chars.Length)]).ToArray());
                string hash = sn + Guid.NewGuid().ToString("N");
                List.Add(hash);
            }
            return List;
        }

        public static string Hashsingle()
        {
            Random Random = new Random();
            const string chars = "abcdefghijklmnpqrstuvwxyz";
            Guid gid = Guid.NewGuid();
            string sn = new string(Enumerable.Repeat(chars, 5).Select(s => s[Random.Next(chars.Length)]).ToArray());
            string hash = sn + Guid.NewGuid().ToString("N");
        return hash;
        }



    }
}
