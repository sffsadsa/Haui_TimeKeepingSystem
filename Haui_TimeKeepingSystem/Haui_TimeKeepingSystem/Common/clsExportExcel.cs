using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Haui_TimeKeepingSystem.Common
{
    public class clsExportExcel
    {
        public void SendEmail(string SendFrom, string PassWord, string subject, string content, string FileAttachments, DataTable dtRecevier)
        {
            try
            {
                string fileExcelPath = "D:\\Report\\Weekly Report_" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx";
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
                string MailBody = "";
                mail.From = new MailAddress(SendFrom);
                for (int i = 0; i < dtRecevier.Rows.Count; i++)
                {
                    //string sendto = "trananh260697@gmail.com";
                    mail.To.Add("chienqtqqwppw@gmail.com");
                    mail.To.Add("kysu.ngoctuan.haui@gmail.com");
                    mail.To.Add("nguyenduc120501@gmail.com");
                    mail.To.Add(dtRecevier.Rows[i]["Email"].ToString());
                }


                if (File.Exists(FileAttachments))
                {
                    Attachment dinhkem = new Attachment(FileAttachments);
                    mail.Attachments.Add(dinhkem);
                }
                if (File.Exists(fileExcelPath))
                {
                    Attachment dinhkem = new Attachment(fileExcelPath);
                    mail.Attachments.Add(dinhkem);
                }

                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = content + MailBody;
                mail.Priority = MailPriority.High;

                SmtpServer.Credentials = new System.Net.NetworkCredential(SendFrom, PassWord);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch
            {

            }

        }
    }

    public class clsEmployee
    {
        public string FingerID { get; set; }
        public string Name { get; set; }
        public string EmployeeCode { get; set; }
        public string Department { get; set; }
    }
}
