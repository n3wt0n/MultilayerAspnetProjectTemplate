namespace $safeprojectname$.Managers
{
    public class ConfigManager
    {
        private static string defaultCulture = "it-IT";

        public static string ThousandsSeparator
            => new System.Globalization.CultureInfo(defaultCulture).NumberFormat.CurrencyGroupSeparator;
    }
}
