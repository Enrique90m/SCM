using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;


namespace SCM
{
    public partial class FormularioPrincipal : Form
    {
        string RespNumEquipo;
        public DataTable dt = new DataTable();
        DataView dataView = new DataView();

        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void usarElSistemaComoAdministradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
            numEquipoTextBox.Focus();
            toolStripLabel1.Text = "SCRF - Agregar equipo";
        }


        private void inventarioDeEquiposYModificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "SCRF - Inventario de equipos";
            dt = new DataTable();
            dt = EquiposDAL.MostrarTodosLosEquipos(dt);
            DataView dv = dt.DefaultView;
            tabControl1.SelectTab(1);
            dataGridView1.DataSource = dv;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "Habilitado")
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.ForestGreen;
                else
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkSalmon;

            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            datoABuscar.Focus();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void regresarAlMenuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {           
        }
        
        private void dataGridView1_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {       
            //Pone los datos en los txtbox
            numEquipoTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            marcaTextBox1.Text =  dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            numSerieTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            salaTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
          
            //Si en dado caso, quiere cambiar el NumEquipo, se respalda en esta variable para poder encontrarlo
            //ya que si no se respalda, nunca lo encontrara al momento de actualizarlo
            RespNumEquipo = numEquipoTextBox1.Text;

            //Cambia de tab
            tabControl1.SelectTab(3);
            numEquipoTextBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numEquipoTextBox.Text = null;
            salaTextBox.Text = null;
            marcaTextBox.Text = null;
            numSerieTextBox.Text = null;
        }

        private void ActualizarTextbox_Click_1(object sender, EventArgs e)
        {
            //Valida que halla capturado lo basico: NumEquipo y Sala
            if (string.IsNullOrWhiteSpace(numEquipoTextBox1.Text) || string.IsNullOrWhiteSpace(salaTextBox1.Text))
            {
                MessageBox.Show("Falta capturar datos basicos, minimo se tiene que capturar:\n\n -Numero de equipo \n -Sala", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Si cambio el numEquipo original, verifica si el nuevo que ingreso ya existe, si es asi, tiene que cambiar el actual
            if (numEquipoTextBox1.Text != RespNumEquipo)
            {
                bool existe = EquiposDAL.existe(numEquipoTextBox1.Text);
                if (existe == true)
                {
                    MessageBox.Show("El Numero de equipo: " + numEquipoTextBox1.Text + " ya esta registrado en el sistema, modifiquelo e intentelo de nuevo","Error de duplicado",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }

            //Valida que solo sean numeros el numero de serie
            try
            {
                int.Parse(numSerieTextBox1.Text);
            }
            catch (Exception q)
            {
                MessageBox.Show("El numero de serie solo debe de contener numeros, porfavor verifique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numSerieTextBox.Focus();
                return;
            }

            //VALIDA QUE NO SEA DEMACIADO LARGO LOS DATOS
            if (numEquipoTextBox1.Text.Length > 3)
            {
                MessageBox.Show("Sobrepaso el limite de caracteres posibles en el NUMERO DE EQUIPO,recuerde lo siguiente: \n\n -El numero de equipo contiene numeros y/o letras \n -No debe ser mayor a 6 caracteres", "Eror de ingreso de carcateres", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (marcaTextBox1.Text.Length > 10)
            {
                MessageBox.Show("Sobrepaso el limite de caracteres en la MARCA del equipo, porfavor verifique, recuerde lo siguiente: \n\n -La marca contiene numeros y/o letras \n -No debe ser mayor a 15", "Eror de ingreso de carcateres", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (numSerieTextBox1.Text.Length > 15)
            {
                MessageBox.Show("Sobrepaso el limite de caracteres en el numero de serie, porfavor verifique, recuerde lo siguiente: \n\n -El numero de serie contiene solo numeros \n -No debe ser mayor a 30", "Eror de ingreso de carcateres", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (salaTextBox1.Text.Length > 2)
            {
                MessageBox.Show("Sobrepaso el limite de caracteres en la sala,recuerde lo siguiente: \n\n -La sala del equipo contiene solo letras \n -No debe ser mayor a 2 ", "Eror de ingreso de carcateres", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            Equipos oEquipo = new Equipos();
            oEquipo.NumEquipo = numEquipoTextBox1.Text;
            oEquipo.sala = salaTextBox1.Text;
            oEquipo.NumSerie = numSerieTextBox1.Text;
            oEquipo.Marca = marcaTextBox1.Text;
            int error = EquiposDAL.ActualizarInfoDeEquipo(oEquipo, RespNumEquipo);

            if (error > 0)
            {
                MessageBox.Show("Actualizacion correcta de los datos", "Finalizacion de proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al actualizar los datos del equipo: " + numEquipoTextBox1.Text, "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataTable dt = new DataTable();
            dataGridView1.DataSource = EquiposDAL.MostrarTodosLosEquipos(dt);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "Habilitado")
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.ForestGreen;
                else
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkSalmon;
            datoABuscar.Text = null;
            tabControl1.SelectTab(1);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Valida que halla capturado lo basico: NumEquipo y Sala
            if (string.IsNullOrWhiteSpace(numEquipoTextBox.Text) || string.IsNullOrWhiteSpace(salaTextBox.Text))
            {
                MessageBox.Show("Falta capturar datos basicos, minimo se tiene que capturar:\n\n -Numero de equipo \n -Sala", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //Valida que solo sean numeros el numero de serie
            try
            {
                long.Parse(numSerieTextBox.Text);
            }
            catch (Exception q)
            {
                MessageBox.Show("El numero de serie solo debe de contener numeros, porfavor verifique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numSerieTextBox.Focus();
                return;
            }


            //Ya capturo datos minimos, ahora valida que no halla capturado un NumEquipo que ya exista
            if (EquiposDAL.existe(numEquipoTextBox.Text))
            {
                MessageBox.Show("El Numero de equipo: " + numEquipoTextBox.Text + " ya esta registrado anteriormente y debe ser unico, porfavor verifique sus datos", "Eror de duplicacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            
            //VALIDA QUE NO SEA DEMACIADO LARGO LOS DATOS
            if(numEquipoTextBox.Text.Length>6)                
            {
                MessageBox.Show("Sobrepaso el limite de caracteres posibles en el NUMERO DE EQUIPO,recuerde lo siguiente: \n\n -El numero de equipo contiene numeros y/o letras \n -No debe ser mayor a 6 caracteres", "Eror de ingreso de carcateres", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            
            if(marcaTextBox.Text.Length>15)
            {
                MessageBox.Show("Sobrepaso el limite de caracteres en la MARCA del equipo, porfavor verifique, recuerde lo siguiente: \n\n -La marca contiene numeros y/o letras \n -No debe ser mayor a 15", "Eror de ingreso de carcateres", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            
            if(numSerieTextBox.Text.Length >30)
            {                
                MessageBox.Show("Sobrepaso el limite de caracteres en el numero de serie, porfavor verifique, recuerde lo siguiente: \n\n -El numero de serie contiene solo numeros \n -No debe ser mayor a 30", "Eror de ingreso de carcateres", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            
            if(salaTextBox.Text.Length>2)
            {
                MessageBox.Show("Sobrepaso el limite de caracteres en la sala,recuerde lo siguiente: \n\n -La sala del equipo contiene solo letras \n -No debe ser mayor a 2 ", "Eror de ingreso de carcateres", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //Ya se valido que capture todo y no exista duplicado, ahora llena los campos y lo agrega
            Equipos Equipo = new Equipos();
            Equipo.NumEquipo = numEquipoTextBox.Text;
            Equipo.Marca = marcaTextBox.Text;
            Equipo.NumSerie = numSerieTextBox.Text;
            Equipo.sala = salaTextBox.Text;
            Equipo.estado = "Habilitado";

            int resultado = EquiposDAL.AgregarEquipo(Equipo);
            if (resultado > 0)
            {
                MessageBox.Show("Equipo " + numEquipoTextBox.Text + " guardado correctamente", "Equipo registrado", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("Hubo un error al guardar el registro", "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            numEquipoTextBox.Text = null;
            marcaTextBox.Text = null;
            salaTextBox.Text = null;
            numSerieTextBox.Text = null;
            numEquipoTextBox.Focus();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            numEquipoTextBox.Text = null;
            marcaTextBox.Text = null;
            salaTextBox.Text = null;
            numSerieTextBox.Text = null;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            numEquipoTextBox1.Text = null;
            marcaTextBox1.Text = null;
            salaTextBox1.Text = null;
            numSerieTextBox1.Text = null;
        }        

        private void Regresar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void Eiminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Esta seguro de que desea eliminar el equipo numero " +  RespNumEquipo+"?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (respuesta.Equals(DialogResult.No))
                return;

            EquiposDAL.EliminaEquipo(RespNumEquipo);
            DataTable dt = new DataTable();
            dt = EquiposDAL.MostrarTodosLosEquipos(dt);
            tabControl1.SelectTab(1);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Valida que tenga datos minimos
            if (string.IsNullOrEmpty(numEquipoTextBox1.Text) || string.IsNullOrEmpty(salaTextBox1.Text))
            {
                MessageBox.Show("Debe de capturar el numero de computadora y sala antes de enviar el correo", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                mail.From = new MailAddress("enrique.19m@gmail.com", "SCRF - Registro de equipo " + numEquipoTextBox1.Text, System.Text.Encoding.UTF8);
                mail.To.Add("enrique_90m@hotmail.com");
                mail.Subject = "Notificacion de actualizacion de falla";
                mail.Body = " <div align=\"center\" style=\"border:2px solid blue\"><h2>Nuevo equipo en el sistema</h2></div></br></br>";
                mail.Body += "<div aling=\"left\"> <h3><b> Numero de equipo: </b> " + numEquipoTextBox1.Text + "</h3></div></br>";
                mail.Body += "<div aling=\"left\"> <h3><b> Numero de sala: </b>" + salaTextBox1.Text + "</h3></div></br>";
               
                if(!string.IsNullOrWhiteSpace(numSerieTextBox.Text))
                mail.Body += "<div aling=\"left\"> <h3><b> Numero de serie: </b> " + numSerieTextBox1.Text + "</h3></div></br>";

                if (!string.IsNullOrWhiteSpace(marcaTextBox1.Text))
                    mail.Body += "<div aling=\"left\"> <h3><b> Marca: </b> " +marcaTextBox1.Text + "</h3></div></br>";               

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

        private void regresarButtom_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void contactenosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe ab = new AcercaDe();
            ab.Show();
        }

        private void datoABuscar_KeyUp(object sender, KeyEventArgs e)
        {
            DataView dataView = dt.DefaultView;
            if (NumEquipo_Radiobtn.Checked)
            {
                dataView.RowFilter = string.Format("NumEquipo LIKE '{0}%'", datoABuscar.Text);
                dataGridView1.DataSource = dataView;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "Habilitado")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.ForestGreen;
                    else
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkSalmon;
            }
            else
            {
                dataView.RowFilter = string.Format("Sala LIKE '{0}%'", datoABuscar.Text);
                dataGridView1.DataSource = dataView;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "Habilitado")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.ForestGreen;
                    else
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkSalmon;
            }

            return;
        }


        private void registrarFallaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(7);
            toolStripLabel1.Text = "SCRF - Agregar falla";
            txtNumEqui.Focus();
        }

        private void inventarioDeFallasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(5);
            toolStripLabel1.Text = "SCRF - Inventario de fallas";
            /*
             Obtiene todos los registros de fallas y los pone en el datagrid, ademas, prepara un dataview para hacer las busquedas, y por cada
             columna que tiene el datagridview, le quita al usuario el poder organizar las celdas con el ultimo ciclo
             */
            dt = new DataTable();
            textBox4.Text = null;
            solucionadaCheckBox.Checked = false;
            EliminadasCheckbox.Checked = false;
            FallasDAL lb = new FallasDAL();
            lb.obtieneTodasLasFallas(dt);
            dataGridView2.DataSource = dt;
            dataView = dt.DefaultView;
            dataGridView2.ForeColor = Color.Black;
            textBox4.Focus();
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void desarrollarReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(6);
            toolStripLabel1.Text = "SCRF - Reportes";
            fechasGroupBox.Enabled = false;
            RepAnualgroupBox.Enabled = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            txtDescripFalla.Text = null;
            txtNumEqui.Text = null;
            t1.Text = null;
            t2.Text = null;
            t3.Text = null;
            txtNumEqui.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumEqui.Text) || string.IsNullOrWhiteSpace(txtDescripFalla.Text))
            {
                MessageBox.Show("Debe capturar el numero de equipo, descripcion y categoria", "Falta de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                mail.From = new MailAddress("enrique.19m@gmail.com", "SCRF - Registro de falla: " + objetoFalla.numFalla, System.Text.Encoding.UTF8);
                mail.To.Add("enrique_90m@hotmail.com");
                mail.Subject = "Notificacion de falla";
                mail.Body = " <div align=\"center\" style=\"border:2px solid blue\"><h2>Nueva falla registrada en el sistema</h2></div></br></br>";
                mail.Body += "<div aling=\"left\"> <h3><b> Numero de falla: </b> " + objetoFalla.numFalla + "</h3></div></br>";
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

            t1.Text = equipo.Marca;
            t2.Text = equipo.NumSerie;
            t3.Text = equipo.sala;
            txtDescripFalla.Focus();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (NumFalla_Radiobtn.Checked)
            {

                if (EliminadasCheckbox.Checked == true && solucionadasCheckbox.Checked == true)
                {
                    dataView.RowFilter = "Convert(idFalla, 'System.String')LIKE '" + textBox4.Text + "%'";
                    dataGridView2.DataSource = dataView;
                    dataGridView2.Sort(dataGridView2.Columns[3], ListSortDirection.Descending);

                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "Si" && dataGridView2.Rows[i].Cells[5].Value.ToString() == "Si")
                            dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    else
                        if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "Si")
                            dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                        else
                            if (dataGridView2.Rows[i].Cells[5].Value.ToString() == "Si")
                                dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.ForestGreen;
                }
                else
                    if (solucionadasCheckbox.Checked == true)
                    {
                        dataView.RowFilter = "Convert(idFalla, 'System.String')LIKE '" + textBox4.Text + "%'";
                        dataGridView2.DataSource = dataView;
                        dataGridView2.Sort(dataGridView2.Columns[3], ListSortDirection.Descending);

                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                            if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "Si")
                                dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                    }
                    else
                    {
                        dataView.RowFilter = "Convert(idFalla, 'System.String')LIKE '" + textBox4.Text + "%'";
                        dataGridView2.DataSource = dataView;
                        dataGridView2.Sort(dataGridView2.Columns[3], ListSortDirection.Descending);
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                            if (dataGridView2.Rows[i].Cells[5].Value.ToString() == "Si")
                                dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.ForestGreen;
                    }
            }
            else
            {
                if (EliminadasCheckbox.Checked == true && solucionadasCheckbox.Checked == true)
                {
                    dataView.RowFilter = "Convert(NumComputadora, 'System.String')LIKE '" + textBox4.Text + "%'";
                    dataGridView2.DataSource = dataView;
                    dataGridView2.Sort(dataGridView2.Columns[3], ListSortDirection.Descending);
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "Si" && dataGridView2.Rows[i].Cells[5].Value.ToString() == "Si")
                            dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        else
                        if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "Si")
                            dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                        else
                            if (dataGridView2.Rows[i].Cells[5].Value.ToString() == "Si")
                                dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.ForestGreen;
                }
                else
                    if (solucionadasCheckbox.Checked == true)
                    {
                        dataView.RowFilter = "Convert(NumComputadora, 'System.String')LIKE '" + textBox4.Text + "%'";
                        dataGridView2.DataSource = dataView;
                        dataGridView2.Sort(dataGridView2.Columns[3], ListSortDirection.Descending);
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                            if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "Si")
                                dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                    }
                    else
                    {
                        dataView.RowFilter = "Convert(NumComputadora, 'System.String')LIKE '" + textBox4.Text + "%'";
                        dataGridView2.DataSource = dataView;
                        dataGridView2.Sort(dataGridView2.Columns[3], ListSortDirection.Descending);
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                            if (dataGridView2.Rows[i].Cells[5].Value.ToString() == "Si")
                                dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.ForestGreen;
                    }
            }
        }

        private void solucionadasCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //si los 2 estan check, pone todos los datos
            if (EliminadasCheckbox.Checked == true && solucionadasCheckbox.Checked == true)
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS");
                dataGridView2.DataSource = dt;
                dataView = dt.DefaultView;
                dataGridView2.Sort(dataGridView2.Columns[3], ListSortDirection.Descending);
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "Si" && dataGridView2.Rows[i].Cells[5].Value.ToString() == "Si")
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    else
                        if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "Si")
                            dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                        else
                            if (dataGridView2.Rows[i].Cells[5].Value.ToString() == "Si")
                                dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
                return;
            }

            if (solucionadasCheckbox.Checked == false && EliminadasCheckbox.Checked == true)
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE Eliminada = 'No'");
                dataGridView2.DataSource = dt;
                dataView = dt.DefaultView;
                dataGridView2.Sort(dataGridView2.Columns[3], ListSortDirection.Descending);
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    if (dataGridView2.Rows[i].Cells[5].Value.ToString() == "Si")
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
                return;
            }

            if (solucionadasCheckbox.Checked == true)
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE Solucionada = 'No'");
                dataGridView2.DataSource = dt;
                dataView = dt.DefaultView;
                dataGridView2.Sort(dataGridView2.Columns[3], ListSortDirection.Descending);
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "Si")
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                return;
            }
            else
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE Solucionada = 'No' AND Eliminada = 'No'");
                dataGridView2.DataSource = dt;
                dataView = dt.DefaultView;
                dataGridView2.Sort(dataGridView2.Columns[3], ListSortDirection.Descending);
            }
        }

        private void EliminadasCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //si los 2 estan check, pone todos los datos
            if (EliminadasCheckbox.Checked == true && solucionadasCheckbox.Checked == true)
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS");
                dataGridView2.DataSource = dt;
                dataView = dt.DefaultView;
                dataGridView2.Sort(dataGridView2.Columns[3], ListSortDirection.Descending);
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "Si" && dataGridView2.Rows[i].Cells[5].Value.ToString() == "Si")
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    else
                        if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "Si")
                            dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                        else
                            if (dataGridView2.Rows[i].Cells[5].Value.ToString() == "Si")
                                dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
                return;
            }

            if (solucionadasCheckbox.Checked == false && EliminadasCheckbox.Checked == true)
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE Eliminada = 'No'");
                dataGridView2.DataSource = dt;
                dataView = dt.DefaultView;
                dataGridView2.Sort(dataGridView2.Columns[3], ListSortDirection.Descending);
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    if (dataGridView2.Rows[i].Cells[5].Value.ToString() == "Si")
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
                return;
            }

            if (solucionadasCheckbox.Checked == true)
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE Solucionada = 'No'");
                dataGridView2.DataSource = dt;
                dataView = dt.DefaultView;
                dataGridView2.Sort(dataGridView2.Columns[3], ListSortDirection.Descending);
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    if (dataGridView2.Rows[i].Cells[7].Value.ToString() == "Si")
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                return;
            }
            else
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE Solucionada = 'No' AND Eliminada = 'No'");
                dataGridView2.DataSource = dt;
                dataView = dt.DefaultView;
                dataGridView2.Sort(dataGridView2.Columns[3], ListSortDirection.Descending);
            }

        }

        private void dataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tabControl1.SelectTab(4);
            toolStripLabel1.Text = "SCRF - Modificacion de falla";
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

            //Pone datos de la falla en textbox
            numFallaTextBox.Text = row.Cells[0].Value.ToString();
            numComputadoraTextBox.Text = row.Cells[1].Value.ToString();
            RespNumEquipo = numComputadoraTextBox.Text;
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
                radioButton7.Checked = true;
            else
                radioButton6.Checked = true;

            //Si esta eliminada
            if (row.Cells[7].Value.ToString() == "Si")
            {
                solucionadaCheckBox.Enabled = false;
                radioButton6.Enabled = false;
                radioButton7.Enabled = false;
                groupBox18.Enabled = false;
                ActualizarTextbox.Enabled = false;
                LimpiarDatos_button.Enabled = false;
                ActualizarInfo_button.Enabled = false;
                EliminarFalla_button.Enabled = false;
                ReenviarCorreo_button.Enabled = false;
                return;
            }

            RecuperarFalla_button.Enabled = false;
        }

        private void ActualizarInfo_button_Click(object sender, EventArgs e)
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
                EquiposDAL.DesabilitaEquipo(RespNumEquipo);
            }

            if (radioButton7.Checked == true)
                falla.categoria = "Hardware";
            else
                falla.categoria = "Software";


            FallasDAL.ActualizaInformacion(falla);

            if (solucionadaCheckBox.Checked == true)
            {
                bool existeOtraFalla = false;
                existeOtraFalla = FallasDAL.VerificaSiExisteOtraFalla(RespNumEquipo);

                if (existeOtraFalla == false)
                    EquiposDAL.HabilitaEquipo(RespNumEquipo);
            }

            tabControl1.SelectTab(5);
            toolStripLabel1.Text = "SCRF - Inventario de fallas";
            /*
             Obtiene todos los registros de fallas y los pone en el datagrid, ademas, prepara un dataview para hacer las busquedas, y por cada
             columna que tiene el datagridview, le quita al usuario el poder organizar las celdas con el ultimo ciclo
             */
            textBox4.Text = null;
            solucionadaCheckBox.Checked = false;
            EliminadasCheckbox.Checked = false;
            FallasDAL lb = new FallasDAL();
            dt = new DataTable();
            lb.obtieneTodasLasFallas(dt);
            dataGridView2.DataSource = dt;
            dataView = dt.DefaultView;
            dataGridView2.ForeColor = Color.Black;
            textBox4.Focus();
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void EliminarFalla_button_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Esta seguro de que desea eliminar la falla?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            bool existeOtraFalla = false;

            if (respuesta.Equals(DialogResult.No))
                return;


            FallasDAL.EliminaFalla(long.Parse(numFallaTextBox.Text), DateTime.Now);
            existeOtraFalla = FallasDAL.VerificaSiExisteOtraFalla(RespNumEquipo);

            if (existeOtraFalla == false)
                EquiposDAL.HabilitaEquipo(RespNumEquipo);

        }

        private void LimpiarDatos_button_Click(object sender, EventArgs e)
        {
            numComputadoraTextBox.Text = null;
            descripcionFallaTextBox.Text = null;
            solucionadaCheckBox.Checked = false;
        }

        private void RecuperarFalla_button_Click(object sender, EventArgs e)
        {
            FallasDAL.RecuperaFalla(long.Parse(numFallaTextBox.Text));
        }

        private void ReenviarCorreo_button_Click(object sender, EventArgs e)
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

                if (radioButton1.Checked == true)
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

        private void Regresar_button_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(5);
            toolStripLabel1.Text = "SCRF - Inventario de fallas";
            /*
             Obtiene todos los registros de fallas y los pone en el datagrid, ademas, prepara un dataview para hacer las busquedas, y por cada
             columna que tiene el datagridview, le quita al usuario el poder organizar las celdas con el ultimo ciclo
             */
            textBox4.Text = null;
            solucionadaCheckBox.Checked = false;
            EliminadasCheckbox.Checked = false;
            FallasDAL lb = new FallasDAL();
            dt = new DataTable();
            lb.obtieneTodasLasFallas(dt);
            dataGridView2.DataSource = dt;
            dataView = dt.DefaultView;
            dataGridView2.ForeColor = Color.Black;
            textBox4.Focus();
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            mensualGroupBox.Enabled = true;
            fechasGroupBox.Enabled = false;
            RepAnualgroupBox.Enabled = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            mensualGroupBox.Enabled = false;
            fechasGroupBox.Enabled = true;
            RepAnualgroupBox.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RepAnualgroupBox.Enabled = true;
            mensualGroupBox.Enabled = false;
            fechasGroupBox.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mensualGroupBox.Enabled)
            {
                DateTime mesAnetior;

                 //NO INCLUYE NI ELIMINADAS NI SOLUCIONADAS
                if (checkBox1.Checked == false &&  checkBox2.Checked == false)
                {
                    mesAnetior = dateTimePicker4.Value.AddDays(-30);
                    ReporteFecha rp2 = new ReporteFecha(mesAnetior, dateTimePicker4.Value, 1);
                    rp2.bandera = "0";
                    rp2.Show();
                }
                //INCLUYE ELIMINADAS Y SOLUCIONADAS
                else if (checkBox1.Checked == true && checkBox2.Checked == true)
                {
                    mesAnetior = dateTimePicker4.Value.AddDays(-30);
                    ReporteFecha rp2 = new ReporteFecha(mesAnetior, dateTimePicker4.Value, 1);
                    rp2.bandera = "3";
                    rp2.Show();
                }             
                //INCLUYE ELIMINADAS Y NO SOLUCIONADAS
                else if (checkBox1.Checked == true)
                {
                    mesAnetior = dateTimePicker4.Value.AddDays(-30);
                    ReporteFecha rp = new ReporteFecha(mesAnetior, dateTimePicker4.Value, 1);
                    rp.bandera = "1";
                    rp.Show();                
                }
                //INCLUYE SOLUCIONADAS Y NO ELIMINADAS
                else if (checkBox2.Checked == true)
                {                                  
                    mesAnetior = dateTimePicker4.Value.AddDays(-30);
                    ReporteFecha rp2 = new ReporteFecha(mesAnetior, dateTimePicker4.Value, 1);
                    rp2.bandera = "2";
                    rp2.Show();
                }               
            }
            else
                if (fechasGroupBox.Enabled)
                {

                    //NO INCLUYE NI ELIMINADAS NI SOLUCIONADAS
                    if (checkBox1.Checked == false && checkBox2.Checked == false)
                    {
                        ReporteFecha rp = new ReporteFecha(dateTimePicker1.Value, dateTimePicker2.Value, 0);
                        rp.bandera = "0";
                        rp.Show();
                    }
                    //INCLUYE ELIMINADAS Y SOLUCIONADAS
                    else if (checkBox1.Checked == true && checkBox2.Checked == true)
                    {
                        ReporteFecha rp = new ReporteFecha(dateTimePicker1.Value, dateTimePicker2.Value, 0);
                        rp.bandera = "3";
                        rp.Show();
                    }
                    //INCLUYE ELIMINADAS Y NO SOLUCIONADAS
                    else if (checkBox1.Checked == true)
                    {
                        ReporteFecha rp = new ReporteFecha(dateTimePicker1.Value, dateTimePicker2.Value, 0);
                        rp.bandera = "1";
                        rp.Show();
                    }
                    //INCLUYE SOLUCIONADAS Y NO ELIMINADAS
                    else if (checkBox2.Checked == true)
                    {
                        ReporteFecha rp = new ReporteFecha(dateTimePicker1.Value, dateTimePicker2.Value, 0);
                        rp.bandera = "2";
                        rp.Show();
                    }
                }
                else
                {
                    DateTime AnoAnterior;
                    AnoAnterior = dateTimePicker4.Value.AddDays(-365);

                    //NO INCLUYE NI ELIMINADAS NI SOLUCIONADAS
                    if (checkBox1.Checked == false && checkBox2.Checked == false)
                    {                        
                        ReporteFecha rp2 = new ReporteFecha(AnoAnterior, dateTimePicker4.Value, 1);
                        rp2.bandera = "0";
                        rp2.Show();
                    }
                    //INCLUYE ELIMINADAS Y SOLUCIONADAS
                    else if (checkBox1.Checked == true && checkBox2.Checked == true)
                    {
                        ReporteFecha rp2 = new ReporteFecha(AnoAnterior, dateTimePicker4.Value, 1);
                        rp2.bandera = "3";
                        rp2.Show();
                    }
                    //INCLUYE ELIMINADAS Y NO SOLUCIONADAS
                    else if (checkBox1.Checked == true)
                    {
                        ReporteFecha rp = new ReporteFecha(AnoAnterior, dateTimePicker4.Value, 1);
                        rp.bandera = "1";
                        rp.Show();
                    }
                    //INCLUYE SOLUCIONADAS Y NO ELIMINADAS
                    else if (checkBox2.Checked == true)
                    {
                        ReporteFecha rp2 = new ReporteFecha(AnoAnterior, dateTimePicker4.Value, 1);
                        rp2.bandera = "2";
                        rp2.Show();
                    }               
                }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumComp_Radiobtn.Checked)
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                    e.Handled = true;
            }
            else
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                    e.Handled = true;
        }

        private void numEquipoTextBox_Leave(object sender, EventArgs e)
        {
        }

    }
}
