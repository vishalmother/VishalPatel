using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            string body = txtbody.Text.Trim();
            string sub = "Email from your website visit - " + txtsubject.Text.Trim();
            var result = SendMail(fromemail, fromname, toemail, toname, body, sub, string.Empty, string.Empty, false);
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
                if (!String.IsNullOrEmpty(FromName))
                {
                    objMail.From = new MailAddress(FromEmail, FromName);
                    objMail.Sender = new MailAddress(FromEmail, FromName);
                }
                else
                {
                    objMail.From = new MailAddress(FromEmail);
                    objMail.Sender = new MailAddress(FromEmail);
                }

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