using System.Net.Mail;
using System.Text.RegularExpressions;

namespace DynamicCrud.Api.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                new MailAddress(email, null);
            }
            catch (Exception)
            {
                return false;
            }

            try
            {
                string pattern = "^((([0-9a-z]((\\.(?!\\.))|[-!#\\$%&\\*\\+/=\\?\\^`\\{\\}\\|\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250.0));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
