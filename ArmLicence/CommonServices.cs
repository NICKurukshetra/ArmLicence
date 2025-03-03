using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI.WebControls;
using static System.Data.Entity.Infrastructure.Design.Executor;
using static System.Web.Razor.Parser.SyntaxConstants;

namespace ArmLicence
{
    public class CommonServices
    {

        public static string ShowAlert(Alerts obj, string message)
        {
            string alertDiv = null;
            switch (obj)
            {
                case Alerts.Success:
                    alertDiv = "<div class='alert alert-success alert-dismissible fade show' role='alert'> " + message + " <button type ='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button> </div>";
                    break;
                case Alerts.Danger:
                    alertDiv = "<div class='alert alert-danger alert-dismissible fade show' role='alert'> " + message + " <button type ='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button> </div>";
                    break;
                case Alerts.Info:
                    alertDiv = "<div class='alert alert-info alert-dismissible fade show' role='alert'> " + message + " <button type ='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button> </div>";
                    break;
                case Alerts.Warning:
                    alertDiv = "<div class='alert alert-Warning alert-dismissible fade show' role='alert'> " + message + " <button type ='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button> </div>";
                    break;
            }
            return alertDiv;
        }

        public enum Alerts
        { Success, Danger, Info, Warning }









        public static string GenerateTransactionID()
        {
            // Get the current timestamp
            DateTime timestamp = DateTime.Now;

            // Format the timestamp as a string
            string timestampString = timestamp.ToString("yyyyMMddHHmmssfff");

            // Generate a random number (you can adjust the range as needed)
            Random random = new Random();
            int randomNumber = random.Next(100, 999);

            // Combine the timestamp and random number to create the transaction ID
            string transactionID = timestampString + randomNumber.ToString();

            return transactionID;
        }
    







}
}

