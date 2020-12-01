using DAL_AmigoProcess.BOL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Web;

namespace AmigoProcessManagement.Utility
{
    public static class Mail
    {
        public static bool sendMail(string toAddress, string CC, string subject, string template, Dictionary<string, string> map)
        {
            try
            {
                //get mail config
                MailConfig config = GetMailConfig();

                if (config.Auth)
                {
                    //Create Smtp Client
                    SmtpClient SmtpServer = new SmtpClient(config.Host);
                    SmtpServer.Credentials = new System.Net.NetworkCredential(map["${aventailUserName}"], map["${aventailPassword}"]);

                    //create mail
                    MailMessage mail = CreateMiMeMail(config.From, CC, toAddress, subject, template, map);

                    SmtpServer.Send(mail);


                }
                else
                {
                    //Create Smtp Client
                    SmtpClient SmtpServer = new SmtpClient(config.Host);

                    //create mail
                    MailMessage mail = CreateMiMeMail(config.From, CC, toAddress, subject, template, map);

                    //smtp cred -will remove
                    SmtpServer.Credentials = new System.Net.NetworkCredential(config.User, config.Password);

                    SmtpServer.Send(mail);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool sendMail(string toAddress, string CC, string subject, string template, Dictionary<string, string> map, string[] filePaths)
        {
            try
            {
                //get mail config
                MailConfig config = GetMailConfig();

                if (config.Auth)
                {
                    //Create Smtp Client
                    SmtpClient SmtpServer = new SmtpClient(config.Host);
                    SmtpServer.Credentials = new System.Net.NetworkCredential(map["${aventailUserName}"], map["${aventailPassword}"]);

                    //create mail
                    MailMessage mail = CreateMiMeMail(config.From, CC, toAddress, subject, template, map, filePaths);

                    SmtpServer.Send(mail);


                }
                else
                {
                    //Create Smtp Client
                    SmtpClient SmtpServer = new SmtpClient(config.Host);

                    //create mail
                    MailMessage mail = CreateMiMeMail(config.From, CC, toAddress, subject, template, map, filePaths);

                    //smtp cred 
                    SmtpServer.Credentials = new System.Net.NetworkCredential(config.User, config.Password);


                    SmtpServer.Send(mail);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static string MapMailPlaceHolders(string template, Dictionary<String, String> map)
        {

            foreach (var item in map)
            {
                //replace placeholders with 
                template = template.Replace(item.Key, item.Value);
            }
            return template;
        }

        private static MailMessage CreateMiMeMail(string from, string cc, string to, string subject, string template, Dictionary<String, String> map)
        {

            MailMessage mail = new MailMessage();


            mail.From = new MailAddress(from);

            //mail to
            string[] toList = to.Split(',');
            foreach (string address in toList)
            {
                mail.To.Add(address.Trim());
            }

            //mail cc
            string[] CcList = cc.Split(',');
            foreach (string address in CcList)
            {
                mail.CC.Add(address.Trim());
            }

            mail.Subject = subject;
            //map placeholders with values
            mail.Body = MapMailPlaceHolders(template, map);

            return mail;

        }

        private static MailMessage CreateMiMeMail(string from, string cc, string to, string subject, string template, Dictionary<String, String> map, string[] filePaths)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(from);

            //mail to
            string[] toList = to.Split(',');
            foreach (string address in toList)
            {
                mail.To.Add(address.Trim());
            }

            //mail cc
            string[] CcList = cc.Split(',');
            foreach (string address in CcList)
            {
                mail.CC.Add(address.Trim());
            }

            for (int i = 0; i < filePaths.Length; i++)
            {

                string path = HttpContext.Current.Server.MapPath("~/" +filePaths[i]);

                try
                {
                    foreach (string file in Directory.GetFiles(path))
                    {
                        mail.Attachments.Add(new Attachment(file, System.Net.Mime.MediaTypeNames.Application.Octet));
                    }
                }
                catch (Exception)
                {
                    try
                    {
                        mail.Attachments.Add(new Attachment(path, System.Net.Mime.MediaTypeNames.Application.Octet));
                    }
                    catch (Exception)
                    {
                    }
                }

            }
            mail.Subject = subject;
            //map placeholders with values
            mail.Body = MapMailPlaceHolders(template, map);

            return mail;

        }

        private static MailMessage CreateMail(string from, string to, string cc, string subject, string template, Dictionary<String, String> map)
        {
            MailMessage mail = new MailMessage();


            mail.From = new MailAddress(from);

            //mail to
            string[] toList = to.Split(',');
            foreach (string address in toList)
            {
                mail.To.Add(address.Trim());
            }

            //mail cc
            string[] CcList = cc.Split(',');
            foreach (string address in CcList)
            {
                mail.CC.Add(address.Trim());
            }

            mail.Subject = subject;
            //map placeholders with values
            mail.Body = MapMailPlaceHolders(template, map);

            return mail;

        }

        private static MailConfig GetMailConfig()
        {
            BOL_CONFIG oCONFIG = new BOL_CONFIG("SYSTEM", Properties.Settings.Default.MyConnection);
            MailConfig config = new MailConfig();
            config.From = oCONFIG.getStringValue("email.from");
            config.ReplyTo = oCONFIG.getStringValue("email.reply-to");
            config.Host = oCONFIG.getStringValue("email.smtp.host");
            try
            {
                config.Port = int.Parse(oCONFIG.getStringValue("email.smtp.port"));
            }
            catch (Exception)
            {
                config.Port = 25;
            }
            try
            {
                config.StartTLS = bool.Parse(oCONFIG.getStringValue("email.smtp.starttls"));
            }
            catch (Exception)
            {
                config.StartTLS = false;
            }

            try
            {
                config.Auth = bool.Parse(oCONFIG.getStringValue("email.smtp.auth"));
            }
            catch (Exception)
            {
                config.Auth = false;
            }

            config.User = oCONFIG.getStringValue("email.smtp.user");
            config.Password = oCONFIG.getStringValue("email.smtp.password");
            config.SSLTrust = oCONFIG.getStringValue("email.ssl.trust");

            return config;
        }

        public class MailConfig
        {
            public string From { get; set; }

            public string ReplyTo { get; set; }

            public string Host { get; set; }

            public int Port { get; set; }

            public bool StartTLS { get; set; }

            public bool Auth { get; set; }

            public string User { get; set; }

            public string Password { get; set; }

            public string SSLTrust { get; set; }

        }

    }
}