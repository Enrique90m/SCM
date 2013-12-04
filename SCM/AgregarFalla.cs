using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;

namespace SCM
{
    public partial class AgregarFalla : Form
    {
        public AgregarFalla()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumEqui.Text)  ||  string.IsNullOrWhiteSpace(txtDescripFalla.Text))
            {
                MessageBox.Show("Debe capturar el numero de equipo, descripcion y categoria","Falta de datos", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (txtNumEqui.Text.Length > 10 || txtDescripFalla.Text.Length > 110)
            {
                MessageBox.Show("Sobrepaso el maximo total de caracteres que permite la descripcion de la falla", "Sobre carga de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Falla objetoFalla = new Falla();
            FallasDAL dl = new FallasDAL();
            objetoFalla.numFalla = dl.obtieneTotalDeFallas() + 1;
            objetoFalla.NumComputadora = txtNumEqui.Text;
            objetoFalla.descripcionFalla = txtDescripFalla.Text;
            objetoFalla.fechaAlta = DateTime.Now;
            EquiposDAL.DesabilitaEquipo(objetoFalla.NumComputadora);


            if (radioButton1.Checked)
                objetoFalla.categoria = radioButton1.Text;
            else
                objetoFalla.categoria = radioButton2.Text;
          
             dl.AgregaFalla(objetoFalla);

             DialogResult respuesta = MessageBox.Show("Desea enviar el correo electronico? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

             if (respuesta.Equals(DialogResult.No))
                 return;

            //envia correo    
             MailMessage mail = new MailMessage();
             SmtpClient SmtpServer = new SmtpClient();
             SmtpServer.Credentials = new System.Net.NetworkCredential("enrique.19m@gmail.com", "elkike_9");
             SmtpServer.Port = 587;
             SmtpServer.Host = "smtp.gmail.com";
             SmtpServer.EnableSsl = true;

             try
             {
                 mail.From = new MailAddress("enrique.19m@gmail.com", "SCRF - Registro de falla: "+ objetoFalla.numFalla , System.Text.Encoding.UTF8);
                 mail.To.Add("enrique_90m@hotmail.com");
                 mail.Subject = "Notificacion de falla";
                 mail.Body = " <div align=\"center\" style=\"border:2px solid blue\"><h2>Nueva falla registrada en el sistema</h2></div></br></br>";
                 mail.Body += "<div aling=\"left\"> <h3><b> Numero de falla: </b> "+ objetoFalla.numFalla + "</h3></div></br>";
                 mail.Body += "<div aling=\"left\"> <h3><b> Numero de equipo: </b>" + objetoFalla.NumComputadora + "</h3></div></br>";
                 mail.Body += "<div aling=\"left\"> <h3><b> Descripcion de la falla: </b> " + objetoFalla.descripcionFalla + "</h3></div></br>";
                 mail.Body += "<div aling=\"left\"> <h3><b> Categoria: </b> " + objetoFalla.categoria + "</h3></div></br>";
                   //if (textBox2.Text != "")
                 //{
                 //    LinkedResource logo = new LinkedResource(textBox2.Text);
                 //    logo.ContentId = "Logo";
                 //    string htmlview;
                 //    htmlview = "<html><body><table border=2><tr width=100%><td><img src=cid:Logo alt=companyname /></td><td></td></tr></table><hr/></body></html>";
                 //    AlternateView alternateView1 = AlternateView.CreateAlternateViewFromString(htmlview + "", null, MediaTypeNames.Text.Html);
                 //    alternateView1.LinkedResources.Add(logo);
                 //    mail.AlternateViews.Add(alternateView1);
                 //}
                 mail.IsBodyHtml = true;
                 mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                 //mail.ReplyTo = new MailAddress(TextBox1.Text);
                 // SmtpServer.Send(mail);
                 //mail.ReplyTo = new MailAddress(TextBox1.Text);
                 SmtpServer.Send(mail);
             }
             catch (Exception ex)
             {
                 MessageBox.Show("No se pudo enviar correo electronico , le presentamos algunas sugerencias y probables motivos de falla :\n \n-Verifique que tenga conexion a internet \n-Actualize el certificado de la pagina ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
             }

             MessageBox.Show("Correo enviado correctamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Fallas fl = new Fallas();
            fl.Show();
            this.Dispose();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtNumEqui_Leave(object sender, EventArgs e)
        {
            //Verifics que no sea vacio
            if (string.IsNullOrWhiteSpace(txtNumEqui.Text))
                return;

            //No esta vacio, procede a buscar el equipo por el NumEquipo proporcionado
            Equipos equipo = EquiposDAL.BuscaDatosEquipo(txtNumEqui.Text);

            if (string.IsNullOrWhiteSpace(equipo.Marca))
            {
                txtNumEqui.Focus();
                return;
            }

            marcaTextBox.Text = equipo.Marca;
            numSerieTextBox.Text = equipo.NumSerie;
            salaTextBox.Text = equipo.sala;
            txtDescripFalla.Focus();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtDescripFalla.Text = null;
            txtNumEqui.Text = null;
            salaTextBox.Text = null;
            marcaTextBox.Text = null;
            numSerieTextBox.Text = null;
            txtNumEqui.Focus();
        }

      
       
        
    }
}
