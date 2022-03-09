using System;
using OpenIDConnect.Federation.DynamicDiscovery.Interfaces;
using OpenIDConnect.Federation.DynamicDiscovery.Models;

namespace OpenIDConnect.Federation.DynamicDiscovery
{
    public class EmailIdentifierNormalizer: IEmailIdentifierNormalizer
    {
        public NormalizedIdentifier NormalizeIdentifier(string email)
        {
            if (!IsValidEmail(email))
            {
                throw new Exception("Invalid email format");
            }

            var emailAddress = new System.Net.Mail.MailAddress(email);

            return new NormalizedIdentifier(emailAddress.User, emailAddress.Host);

        }

        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
