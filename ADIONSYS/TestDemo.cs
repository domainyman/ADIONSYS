namespace ADIONSYS
{
    internal class TestDemo
    {
        public void CleanSetting()
        {
            ApplicationSetting.Default.DataBaseAddress = string.Empty;
            ApplicationSetting.Default.Host = string.Empty;
            ApplicationSetting.Default.Port = string.Empty;
            ApplicationSetting.Default.Username = string.Empty;
            ApplicationSetting.Default.Password = string.Empty;
            ApplicationSetting.Default.Database = string.Empty;
            ApplicationSetting.Default.ConnectionState = false;
            ApplicationSetting.Default.Admin_User = "admin";
            ApplicationSetting.Default.Admain_Password = "admin";
            ApplicationSetting.Default.Save();
        }
    }
}
