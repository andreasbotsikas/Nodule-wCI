// Initial code from http://stackoverflow.com/questions/473687/restrict-access-to-a-specific-controller-by-ip-address-in-asp-net-mvc-beta
// Extended to support mask level ip/masklevel
//Example usage:

//1. Directly specifying the IPs in the code
//    [FilterIP(
//         AllowedSingleIPs="10.2.5.55,192.168.2.2",
//         AllowedMaskedIPs="10.2.0.0;255.255.0.0,192.168.2.0;255.255.255.0"
//    )]
//    public class HomeController {
//      // Some code here
//    }

//2. Or, Loading the configuration from the Web.config
//    [FilterIP(
//         ConfigurationKeyAllowedSingleIPs="AllowedAdminSingleIPs",
//         ConfigurationKeyAllowedMaskedIPs="AllowedAdminMaskedIPs",
//         ConfigurationKeyDeniedSingleIPs="DeniedAdminSingleIPs",
//         ConfigurationKeyDeniedMaskedIPs="DeniedAdminMaskedIPs"
//    )]
//    public class HomeController {
//      // Some code here
//    }


//<configuration>
//<appSettings>
//    <add key="AllowedAdminSingleIPs" value="localhost,127.0.0.1"/> <!-- Example "10.2.80.21,192.168.2.2" -->
//    <add key="AllowedAdminMaskedIPs" value="10.2.0.0;255.255.0.0"/> <!-- Example "10.2.0.0;255.255.0.0,192.168.2.0;255.255.255.0" -->
//    <add key="DeniedAdminSingleIPs" value=""/>    <!-- Example "10.2.80.21,192.168.2.2" -->
//    <add key="DeniedAdminMaskedIPs" value=""/>    <!-- Example "10.2.0.0;255.255.0.0,192.168.2.0;255.255.255.0" -->
//</appSettings>
//</configuration>


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using System.Configuration;
using IPNumbers;

namespace Miscellaneous.Attributes.Controller
{

    /// <summary>
    /// Filter by IP address
    /// </summary>
    public class FilterIPAttribute : AuthorizeAttribute
    {

        #region Allowed
        /// <summary>
        /// Comma seperated string of allowable IPs. Example "10.2.5.41,192.168.0.22"
        /// </summary>
        /// <value></value>
        public string AllowedSingleIPs { get; set; }

        /// <summary>
        /// Comma seperated string of allowable IPs with masks. Example "10.2.0.0;255.255.0.0,10.3.0.0;255.255.0.0"
        /// </summary>
        /// <value>The masked IPs.</value>
        public string AllowedMaskedIPs { get; set; }


        /// <summary>
        /// Comma seperated string of allowable IPs with mask level. Example "10.2.0.0/24,10.3.0.0/27"
        /// </summary>
        /// <value>The masked IPs.</value>
        public string AllowedMaskLevelIPs { get; set; }

        /// <summary>
        /// Gets or sets the configuration key for allowed single IPs
        /// </summary>
        /// <value>The configuration key single IPs.</value>
        public string ConfigurationKeyAllowedSingleIPs { get; set; }

        /// <summary>
        /// Gets or sets the configuration key allowed masked IPs
        /// </summary>
        /// <value>The configuration key masked IPs.</value>
        public string ConfigurationKeyAllowedMaskedIPs { get; set; }

        /// <summary>
        /// Gets or sets the configuration key allowed masked using level IPs
        /// </summary>
        /// <value>The configuration key masked IPs.</value>
        public string ConfigurationKeyAllowedMaskLevelIPs { get; set; }

        /// <summary>
        /// List of allowed IPs
        /// </summary>
        IPList allowedIPListToCheck = new IPList();
        #endregion

        #region Denied
        /// <summary>
        /// Comma seperated string of denied IPs. Example "10.2.5.41,192.168.0.22"
        /// </summary>
        /// <value></value>
        public string DeniedSingleIPs { get; set; }

        /// <summary>
        /// Comma seperated string of denied IPs with masks. Example "10.2.0.0;255.255.0.0,10.3.0.0;255.255.0.0"
        /// </summary>
        /// <value>The masked IPs.</value>
        public string DeniedMaskedIPs { get; set; }


        /// <summary>
        /// Gets or sets the configuration key for denied single IPs
        /// </summary>
        /// <value>The configuration key single IPs.</value>
        public string ConfigurationKeyDeniedSingleIPs { get; set; }

        /// <summary>
        /// Gets or sets the configuration key for denied masked IPs
        /// </summary>
        /// <value>The configuration key masked IPs.</value>
        public string ConfigurationKeyDeniedMaskedIPs { get; set; }

        /// <summary>
        /// List of denied IPs
        /// </summary>
        IPList deniedIPListToCheck = new IPList();
        #endregion


        /// <summary>
        /// Determines whether access to the core framework is authorized.
        /// </summary>
        /// <param name="httpContext">The HTTP context, which encapsulates all HTTP-specific information about an individual HTTP request.</param>
        /// <returns>
        /// true if access is authorized; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="httpContext"/> parameter is null.</exception>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            string userIpAddress = httpContext.Request.UserHostAddress;

            try
            {
                // Check that the IP is allowed to access
                bool ipAllowed = CheckAllowedIPs(userIpAddress);

                // Check that the IP is not denied to access
                bool ipDenied = CheckDeniedIPs(userIpAddress);

                // Only allowed if allowed and not denied
                bool finallyAllowed = ipAllowed && !ipDenied;

                return finallyAllowed;
            }
            catch (Exception e)
            {
                // Log the exception, probably something wrong with the configuration
            }

            return true; // if there was an exception, then we return true
        }

        /// <summary>
        /// Checks the allowed IPs.
        /// </summary>
        /// <param name="userIpAddress">The user ip address.</param>
        /// <returns></returns>
        private bool CheckAllowedIPs(string userIpAddress)
        {
            // Populate the IPList with the Single IPs
            if (!string.IsNullOrEmpty(AllowedSingleIPs))
            {
                SplitAndAddSingleIPs(AllowedSingleIPs, allowedIPListToCheck);
            }

            // Populate the IPList with the Masked IPs
            if (!string.IsNullOrEmpty(AllowedMaskedIPs))
            {
                SplitAndAddMaskedIPs(AllowedMaskedIPs, allowedIPListToCheck);
            }

            // Populate the IPList using th masked by level IPs
            if (!string.IsNullOrEmpty(AllowedMaskLevelIPs))
            {
                SplitAndAddMaskLevelIPs(AllowedMaskLevelIPs, allowedIPListToCheck);
            }

            // Check if there are more settings from the configuration (Web.config)
            if (!string.IsNullOrEmpty(ConfigurationKeyAllowedSingleIPs))
            {
                string configurationAllowedAdminSingleIPs = ConfigurationManager.AppSettings[ConfigurationKeyAllowedSingleIPs];
                if (!string.IsNullOrEmpty(configurationAllowedAdminSingleIPs))
                {
                    SplitAndAddSingleIPs(configurationAllowedAdminSingleIPs, allowedIPListToCheck);
                }
            }

            if (!string.IsNullOrEmpty(ConfigurationKeyAllowedMaskedIPs))
            {
                string configurationAllowedAdminMaskedIPs = ConfigurationManager.AppSettings[ConfigurationKeyAllowedMaskedIPs];
                if (!string.IsNullOrEmpty(configurationAllowedAdminMaskedIPs))
                {
                    SplitAndAddMaskedIPs(configurationAllowedAdminMaskedIPs, allowedIPListToCheck);
                }
            }

            if (!string.IsNullOrEmpty(ConfigurationKeyAllowedMaskLevelIPs))
            {
                string configurationAllowedAdminMaskLevelIPs = ConfigurationManager.AppSettings[ConfigurationKeyAllowedMaskLevelIPs];
                if (!string.IsNullOrEmpty(configurationAllowedAdminMaskLevelIPs))
                {
                    SplitAndAddMaskLevelIPs(configurationAllowedAdminMaskLevelIPs, allowedIPListToCheck);
                }
            }

            return allowedIPListToCheck.CheckNumber(userIpAddress);
        }

        /// <summary>
        /// Checks the denied IPs.
        /// </summary>
        /// <param name="userIpAddress">The user ip address.</param>
        /// <returns></returns>
        private bool CheckDeniedIPs(string userIpAddress)
        {
            // Populate the IPList with the Single IPs
            if (!string.IsNullOrEmpty(DeniedSingleIPs))
            {
                SplitAndAddSingleIPs(DeniedSingleIPs, deniedIPListToCheck);
            }

            // Populate the IPList with the Masked IPs
            if (!string.IsNullOrEmpty(DeniedMaskedIPs))
            {
                SplitAndAddMaskedIPs(DeniedMaskedIPs, deniedIPListToCheck);
            }

            // Check if there are more settings from the configuration (Web.config)
            if (!string.IsNullOrEmpty(ConfigurationKeyDeniedSingleIPs))
            {
                string configurationDeniedAdminSingleIPs = ConfigurationManager.AppSettings[ConfigurationKeyDeniedSingleIPs];
                if (!string.IsNullOrEmpty(configurationDeniedAdminSingleIPs))
                {
                    SplitAndAddSingleIPs(configurationDeniedAdminSingleIPs, deniedIPListToCheck);
                }
            }

            if (!string.IsNullOrEmpty(ConfigurationKeyDeniedMaskedIPs))
            {
                string configurationDeniedAdminMaskedIPs = ConfigurationManager.AppSettings[ConfigurationKeyDeniedMaskedIPs];
                if (!string.IsNullOrEmpty(configurationDeniedAdminMaskedIPs))
                {
                    SplitAndAddMaskedIPs(configurationDeniedAdminMaskedIPs, deniedIPListToCheck);
                }
            }

            return deniedIPListToCheck.CheckNumber(userIpAddress);
        }

        /// <summary>
        /// Splits the incoming ip string of the format "IP,IP" example "10.2.0.0,10.3.0.0" and adds the result to the IPList
        /// </summary>
        /// <param name="ips">The ips.</param>
        /// <param name="list">The list.</param>
        private void SplitAndAddSingleIPs(string ips, IPList list)
        {
            var splitSingleIPs = ips.Split(',');
            foreach (string ip in splitSingleIPs)
                list.Add(ip);
        }

        /// <summary>
        /// Splits the incoming ip string of the format "IP;MASK,IP;MASK" example "10.2.0.0;255.255.0.0,10.3.0.0;255.255.0.0" and adds the result to the IPList
        /// </summary>
        /// <param name="ips">The ips.</param>
        /// <param name="list">The list.</param>
        private void SplitAndAddMaskedIPs(string ips, IPList list)
        {
            var splitMaskedIPs = ips.Split(',');
            foreach (string maskedIp in splitMaskedIPs)
            {
                var ipAndMask = maskedIp.Split(';');
                list.Add(ipAndMask[0], ipAndMask[1]); // IP;MASK
            }
        }
        /// <summary>
        /// Splits the incoming ip string of the format "IP/MASKLevel,IP/MASKLevel" example "10.2.0.0/24,10.3.0.0/27" and adds the result to the IPList
        /// </summary>
        /// <param name="ips">The ips.</param>
        /// <param name="list">The list.</param>
        private void SplitAndAddMaskLevelIPs(string ips, IPList list)
        {
            var splitMaskedIPs = ips.Split(',');
            foreach (string maskedIp in splitMaskedIPs)
            {
                var ipAndMask = maskedIp.Split('/');
                if (ipAndMask.Length != 2)
                    throw new ApplicationException(String.Format("Given masked ip is not in the ip/mask format!. Error parsing: {0}",maskedIp));
                int MaskLevel;
                if (int.TryParse(ipAndMask[1], out MaskLevel))
                {
                    list.Add(ipAndMask[0], MaskLevel); // IP;MASK
                }
                else
                {
                    throw new ApplicationException(String.Format("Mask level {0} is not numeric!", ipAndMask[1]));
                }
            }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
    }
}