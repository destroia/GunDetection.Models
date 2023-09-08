using System;
using System.Collections.Generic;
using System.Text;

namespace GunDetection.Data.Helpers.Mails
{
    public static class Login
    {
        public static string ValidarAcuenta(string nombre , string url )
        {
           return "<p style = 'text-align: center; font-size: 30px;' > Welcome to Gun Detector </p>" +
                   "<p style = 'text-align: center; font-size: 20px;' > Hi " + nombre + ", We hope you are very well, Click on the button to validate your account&nbsp;</p>" +
                   "<p style = 'text-align: center; font-size: 20px;' > &nbsp;</p>" +
                   "<p style = 'text-align: center; font-size: 0px; ' >" +
                   "<a  href ='" + url + "'>"+
                   "<div align='center'>"+
                   "<button style = 'font-size: 20px;  border-radius:5px; Background:Highlight;' target = '_blank' > Validate Account</button>" +
                   "</div>"+
                   "</a></p>" +
                   "<Br/>"+
                   "<p style = 'text-align: center; font-size: 20px;' ><a href='" + url + "'>"+ url + "</a></p>";
        }

        public static string RestorePassword(string nombre, string url)
        {
            return "<p style = 'text-align: center; font-size: 30px;' > Welcome to Gun Detector </p>" +
                    "<p style = 'text-align: center; font-size: 20px;' > Hi " + nombre + ", We hope you are very well, then click on the button to restore your password&nbsp;</p>" +
                    "<p style = 'text-align: center; font-size: 20px;' > &nbsp;</p>" +
                    "<p style = 'text-align: center; font-size: 0px; ' >" +
                    "<a  href ='" + url + "'>" +
                     "<div align='center'>" +
                    "<button style = 'font-size: 20px;  border-radius:5px; Background:Highlight;' target = '_blank' > Restore Password </button>" +
                    "</div>" + 
                    "</a></p>" +
                    "<Br/>" +
                    "<p style = 'text-align: center; font-size: 20px;' ><a href='" + url + "'>" + url + "</a></p>";
        }

        public static string SuscripcionAlarm(string nombre)
        {
            return "<p style = 'text-align: center; font-size: 30px;' > Welcome to Gun Detector </p>" +
                    "<p style = 'text-align: center; font-size: 20px;' > Hi " + nombre + ", You have been subscribed to Alert Messages.&nbsp;</p>" +
                    "<p style = 'text-align: center; font-size: 20px;' > From now on you will receive an alert message each time an alert occurs.&nbsp;</p>"; 
        }

        public static string AlertAlarm(string nombre,string url)
        {
            return "<p style = 'text-align: center; font-size: 30px;' > Event Detected Alert </p>" +
                    "<p style = 'text-align: center; font-size: 20px;' > Hi " + nombre + "An event has been detected, click to see the alert. &nbsp;</p>"+
                    "<br>"+
                    "<a  href ='" + url + "'>" +
                     "<div align='center'>" +
                    "<button style = 'font-size: 20px;  border-radius:5px; Background:Highlight;' target = '_blank' > Show Alert</button>" +
                    "</div>" + 
                    "</a></p>" +
                    "<Br/>" +
                    "<p style = 'text-align: center; font-size: 20px;' ><a href='" + url + "'>" + url + "</a></p>";
        }
    }
}
