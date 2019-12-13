using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace VishalPatel
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string toemail = "vishal@vishalpatel.in";
            string toname = "Vishal Patel";
            string fromemail = txtemail.Text.Trim();
            string fromname = txtname.Text.Trim();
            StringBuilder body = new StringBuilder();
            body.Append("<table cellpadding='5' cellspacing='5' width='70%'>");
            body.Append("<tr>");
            body.Append("<td style='width:20%'><b>Name:</b></td><td style='width:80%'>" + txtname.Text.Trim() + "</td>");
            body.Append("</tr><tr>");
            body.Append("<td><b>Email:</b></td><td>" + txtemail.Text.Trim() + "</td>");
            body.Append("</tr><tr>");
            body.Append("<td><b>Subject:</b></td><td>" + txtsubject.Text.Trim() + "</td>");
            body.Append("</tr><tr>");
            body.Append("<td><b>Body:</b></td><td>" + txtbody.Text.Trim() + "</td>");
            body.Append("</tr></table>");
            string sub = "Email from your website visit - " + txtsubject.Text.Trim();
            var result = SendMail(fromemail, fromname, toemail, toname, body.ToString(), sub, string.Empty, string.Empty, true);
            if (result)
            {
                form1.Visible = false;
                pMsg.Visible = true;
            }
            else
            {
                form1.Visible = true;
                pMsg.Visible = false;
            }
        }

        public bool SendMail(string FromEmail, string FromName, string ToEmails, string toname, string MailBody, string Subject, string CcEmails, string BccEmails, bool IsBodyHtml)
        {
            try
            {
                System.Net.Mail.MailMessage objMail = new System.Net.Mail.MailMessage();

                //Mail From Field
                //if (!String.IsNullOrEmpty(FromName))
                //{
                //    objMail.From = new MailAddress(FromEmail, FromName);
                //    objMail.Sender = new MailAddress(FromEmail, FromName);
                //}
                //else
                //{
                objMail.From = new MailAddress(FromEmail);
                objMail.Sender = new MailAddress(FromEmail);
                //}

                //Mail To Field
                if (!String.IsNullOrEmpty(ToEmails))
                {
                    objMail.To.Add(ToEmails);
                }
                //Mail Cc Field
                if (!String.IsNullOrEmpty(CcEmails))
                {
                    objMail.CC.Add(CcEmails);
                }

                //Mail Bcc Field
                if (!String.IsNullOrEmpty(BccEmails))
                {
                    objMail.Bcc.Add(BccEmails);
                }

                //Mail Subject Field
                objMail.Subject = Subject;

                //Mail Body Field
                objMail.Body = MailBody;
                objMail.IsBodyHtml = IsBodyHtml;

                try
                {
                    SmtpClient smtp1 = new SmtpClient();
                    smtp1.Send(objMail);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}