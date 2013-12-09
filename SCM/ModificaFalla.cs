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
    public partial class ModificaFalla : Form
    {
        DataGridViewRow row = new DataGridViewRow();
        public string respnumequipo;

        public ModificaFalla(DataGridViewRow row1)
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            row = row1;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(numComputadoraTextBox.Text) || string.IsNullOrEmpty(descripcionFallaTextBox.Text))
            {
                MessageBox.Show("Debe de capturar el numero de computadora y descripcion antes de actualizar", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numComputadoraTextBox.Text.Length > 4 || descripcionFallaTextBox.Text.Length > 110)
            {
                MessageBox.Show("Sobrepaso el maximo total de caracteres que permite la descripcion de la falla o el numero de computadora", "Sobre carga de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!EquiposDAL.existe(numComputadoraTextBox.Text))
            {
                MessageBox.Show("El numero de equipo " + numComputadoraTextBox.Text + " no existe en los registros actuales, debe asignar la falla a un numero de equipo valido", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Falla falla = new Falla();
            falla.NumComputadora = numComputadoraTextBox.Text;
            falla.descripcionFalla = descripcionFallaTextBox.Text;
            falla.numFalla = int.Parse(numFallaTextBox.Text);

            if (solucionadaCheckBox.Checked == true)
            {                
                falla.Solucionada = "Si";
                falla.fechaBaja = DateTime.Now;
            }
            else
            {
                falla.fechaBaja = DateTime.MinValue;
                falla.Solucionada = "No";
                EquiposDAL.DesabilitaEquipo(respnumequipo);
            }

            if (radioButton1.Checked == true)
                falla.categoria = "Hardware";
            else
                falla.categoria = "Software";


            FallasDAL.ActualizaInformacion(falla);

            if (solucionadaCheckBox.Checked == true)
            {
                bool existeOtraFalla = false;
                existeOtraFalla = FallasDAL.VerificaSiExisteOtraFalla(respnumequipo);

                if (existeOtraFalla == false)
                    EquiposDAL.HabilitaEquipo(respnumequipo);
            }

        }       
       

        private void ModificaFalla_Load(object sender, EventArgs e)
        {
            //Pone datos de la falla en textbox
            numFallaTextBox.Text = row.Cells[0].Value.ToString();
            numComputadoraTextBox.Text = row.Cells[1].Value.ToString();
            respnumequipo = numComputadoraTextBox.Text;
            descripcionFallaTextBox.Text = row.Cells[2].Value.ToString();
            fechaAltaTextbx.Text = row.Cells[3].Value.ToString();

            //Verifica si esta activa la falla
            if (string.IsNullOrEmpty(row.Cells[4].Value.ToString()))
            {
                FechaBajaTextBox.Text = "Falla activa";
                FechaBajaTextBox.BackColor = Color.ForestGreen;
            }
            else
                FechaBajaTextBox.Text = row.Cells[4].Value.ToString();

            //Verifica si esta solucionada
            if (row.Cells[5].Value.ToString() == "Si")
                solucionadaCheckBox.Checked = true;
            else
                solucionadaCheckBox.Checked = false;

            //Verifica la categoria, si es hardware hace el check al radio button correspondiente
            if (row.Cells[6].Value.ToString() == "Hardware")
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TodasFallas tf = new TodasFallas();
            tf.Show();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numComputadoraTextBox.Text = null;
            descripcionFallaTextBox.Text = null;
            solucionadaCheckBox.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Valida que tenga datos minimos
            if (string.IsNullOrEmpty(numComputadoraTextBox.Text) || string.IsNullOrEmpty(descripcionFallaTextBox.Text))
            {
                MessageBox.Show("Debe de capturar el numero de computadora y descripcion antes de enviar el correo", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //envia correo    
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Credentials = new System.Net.NetworkCredential("enrique.19m@gmail.com", "elkike_9");
            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.EnableSsl = true;

            try
            {
                mail.From = new MailAddress("enrique.19m@gmail.com", "SCRF - Actualizacion de falla: " + numFallaTextBox.Text, System.Text.Encoding.UTF8);
                mail.To.Add("enrique_90m@hotmail.com");
                mail.Subject = "Notificacion de actualizacion de falla";
                mail.Body = " <div align=\"center\" style=\"border:2px solid blue\"><h2>Actualizacion de falla en el sistema</h2></div></br></br>";
                mail.Body += "<div aling=\"left\"> <h3><b> Numero de falla: </b> " + numFallaTextBox.Text + "</h3></div></br>";
                mail.Body += "<div aling=\"left\"> <h3><b> Numero de equipo: </b>" + numComputadoraTextBox.Text + "</h3></div></br>";
                mail.Body += "<div aling=\"left\"> <h3><b> Descripcion de la falla: </b> " + descripcionFallaTextBox.Text + "</h3></div></br>";

                if(radioButton1.Checked == true)
                 mail.Body += "<div aling=\"left\"> <h3><b> Categoria: Hardware</b> </h3></div></br>";
                else
                    mail.Body += "<div aling=\"left\"> <h3><b> Categoria: Software</b> </h3></div></br>"; 
              
                mail.IsBodyHtml = true;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;               
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo enviar correo electronico , le presentamos algunas sugerencias y probables motivos de falla :\n \n-Verifique que tenga conexion a internet \n-Actualize el certificado de la pagina ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Correo enviado correctamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Esta seguro de que desea eliminar la falla?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            bool existeOtraFalla = false;

            if (respuesta.Equals(DialogResult.No))
                return;

            FallasDAL.EliminaFalla(long.Parse(numFallaTextBox.Text));
            existeOtraFalla = FallasDAL.VerificaSiExisteOtraFalla(respnumequipo);

            if(existeOtraFalla == false)           
            EquiposDAL.HabilitaEquipo(respnumequipo);

            TodasFallas td = new TodasFallas();
            td.Show();
            this.Dispose();
        }
    }
}
