using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Compucare.Frontends.Common.Forms
{
    public class ExceptionVisualiser
    {
        private readonly ExceptionVisualisationForm _form;
        private readonly Exception _ex;

        private ExceptionVisualiser(ExceptionVisualisationForm form, Exception ex)
        {
            _form = form;
            _ex = ex;

            _form._messageBox.Text = ex.Message;
            _form._stacktraceBox.Text = ex.Message + "\r\n" + ex.StackTrace;

            _form._okButton.Click += delegate { _form.Close(); };
            _form._sendMail.Click += new EventHandler(_sendMail_Click);
        }

        void _sendMail_Click(object sender, EventArgs e)
        {
            ExceptionMailForm mailForm = new ExceptionMailForm();

            mailForm._subjectBox.Text = "Exception: " + _ex.Message;

            mailForm._cancelButton.Click += delegate
                                                {
                                                    mailForm.DialogResult = DialogResult.Cancel;
                                                    mailForm.Close();
                                                };

            mailForm._sendButton.Click += delegate
            {
                mailForm.DialogResult = DialogResult.OK;
                mailForm.Close();
            };

            if (mailForm.ShowDialog() == DialogResult.OK)
            {
                try
                {


                    SmtpClient client = new SmtpClient("smtp.compucare.at");

                    NetworkCredential cred =
                        new NetworkCredential("lukas.maczejka@compucare.at", "siemeinen");
                    client.UseDefaultCredentials = false;
                    client.Credentials = cred;

                    String subject = mailForm._subjectBox.Text;

                    String message =
                        String.Format("{0}{1}{1}{1}{1}{3}{1}{4}{1}{2}", mailForm.textBox1.Text, Environment.NewLine,
                                      _form._stacktraceBox.Text, DateTime.Now,
                                      Environment.UserName + " on " + Environment.MachineName);

                    if (String.IsNullOrWhiteSpace(subject)) subject = "Exception";
                    client.Send("lukas.maczejka@compucare.at", "lukas.maczejka@compucare.at; Samet.celik@emotion-banking.at",
                                subject,
                                message);

                    MessageBox.Show("Mail has been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to send mail. Please copy and paste the exception text and send the mail manually.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }

        public static void Show(Exception ex)
        {
            ExceptionVisualiser vis = new ExceptionVisualiser(new ExceptionVisualisationForm(), ex);
            vis._form.ShowDialog();
        }
    }
}
