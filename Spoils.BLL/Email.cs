using System;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

namespace Spoils.BLL
{
    public class Email
    {
        public void SendEmail_Outlook(FileInfo fi, bool newMailing, int recordCount)
        {
            try
            {
                string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                string[] result = userName.Split('\\');

                string to = "DigitalGrp@khprint.com";
                //string to = "jelder@khprint.com";
                string from = result[1] + "@khprint.com";

                MailMessage message = new MailMessage(from, to);

                message.CC.Add("MailRoomGrp@khprint.com");
                string server = "mail.khprint.com";
                SmtpClient client = new SmtpClient(server);

                if (newMailing)
                {
                    //Subject Line
                    message.Subject = $"NEW MAILING for: {fi.Name} is ready for processing";
                    message.To.Add("DPGroup@khprint.com");
                    message.Body = $"Please process file: {fi.Name}\n\nRecord Count: {recordCount}\n\nAs a NEW MAILING\n\nLocated at: {fi.Directory}";
                }
                else
                {
                    message.Subject = $"REPRINT: {fi.Name} is ready for processing";
                    message.Body = $"Please process file: {fi.Name}\n\nRecord Count: {recordCount}\n\nFor REPRINTING\n\nLocated at: {fi.Directory}";
                }

                client.UseDefaultCredentials = true;
                client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
