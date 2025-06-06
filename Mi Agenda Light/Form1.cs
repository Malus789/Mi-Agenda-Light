using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mi_Agenda_Light
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            SetupTimer();
        }

        private List<string> messagesMotiv = new List<string>
        {
            "La duda es más honesta que la certeza.",
            "El pasado nunca muere del todo.",
            "Somos espejos de lo que miramos.",
            "Habitar el presente es un arte.",
            "Nada crece sin paciencia.",
        };

        private void SetupTimer()
        {
            timer.Interval = 10000; // 60 segundos = 1 minuto
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();

            Random randomAltMensaje = new Random();
            int[] opcionesAltMensaje = { 1, 2 };
            int elegido = opcionesAltMensaje[randomAltMensaje.Next(opcionesAltMensaje.Length)];

            int index = rnd.Next(messagesMotiv.Count);
            toolStripStatusLabelMensajes.Text = messagesMotiv[index]; // 

            if (listaTareasUrgentes.Count >= 1)
            {
                if (elegido == 1)
                {

                    Random rndRecuerda = new Random();
                    int indexRecuerda = rndRecuerda.Next(listaTareasUrgentes.Count);

                    toolStripStatusLabelMensajes.Text = "Recuerda: " + listaTareasUrgentes[indexRecuerda];
                }
            }
            else
            {
                //toolStripStatusLabelRecuerda.Text = "No hay tareas urgentes.";

            }

            //timer.Interval = rnd.Next(30000, 600000); // Cambia el intervalo aleatoriamente entre 30 segundos y 10 minutos (60000, 600000)
            timer.Interval = rnd.Next(10000, 30000);
        }

        private string horaOfechaActual(string datoPedir)
        {
            DateTime now = DateTime.Now;
            // Formatear la hora actual como string en formato HH:mm:ss
            string formattedTime = now.ToString("HH:mm:ss");
            // Formatear la fecha actual como string en formato "dd/MM/yyyy"
            string formattedDate = now.ToString("dd/MM/yyyy");
            // Imprimir la hora formateada

            if (datoPedir == "time")
            {
                return formattedTime;
            }
            else
            if (datoPedir == "date")
            {
                return formattedDate;
            }

            return null;
        }
        private void GuardarDatos(string titulo, string descripcion, string urgenteTexto, string hora, string fechaCreacion, string minutosTrabajados, string ciclosTrab, string ultimoComentario)
        {
            //defino la variable rutaArchivo con la ubicacion del directorio + el archivo.txt
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "archivo.txt");

            if (!File.Exists(rutaArchivo))
            {
                File.Create(rutaArchivo).Close(); // Crea y cierra el archivo para liberar el recurso
            }

            //Aqui transformo los saltos de linea en // para que no afecte la manera de guardar
            string descripcionModificada = descripcion.Replace(Environment.NewLine, "\\n");

            string linea = $"{titulo}|{descripcionModificada}|{hora}|{urgenteTexto}|{fechaCreacion}|{minutosTrabajados}|{ciclosTrab}|{ultimoComentario}";

            File.AppendAllText(rutaArchivo, linea + Environment.NewLine);
        }

        private List<string> CargarDatos()
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "archivo.txt");
            List<string> lineas = new List<string>();
            // Verificar si el archivo existe
            if (File.Exists(rutaArchivo))
            {
                // Leer todas las líneas del archivo
                lineas = File.ReadAllLines(rutaArchivo).ToList();
            }

            return lineas;
        }

        private List<string> listaCompletaDatos = new List<string>();
        private List<string> listaTareasUrgentes = new List<string>();
        private void CargarTitulosEnCheckedListBox()
        {
            List<string> datosGuardados = CargarDatos();
            checkedListBoxEventos.Items.Clear();
            listaCompletaDatos.Clear();

            foreach (string linea in datosGuardados)
            {
                var partes = linea.Split('|');
                if (partes.Length > 3)
                {
                    if (partes[3].Trim().Equals("Alta", StringComparison.OrdinalIgnoreCase))
                        listaTareasUrgentes.Add(partes[0]);
                }
            }

            foreach (string dato in datosGuardados)
            {
                var partes = dato.Split('|');
                if (partes.Length > 0)
                {
                    checkedListBoxEventos.Items.Add(partes[0]); // Añade solo el título
                    listaCompletaDatos.Add(dato); // Almacena la línea completa
                }
            }
        }

        private void CargarDesdeArchivoaLista(List<string> listaDestino)
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "frases.txt");

            if (!File.Exists(rutaArchivo))
            {
                // Crear archivo vacío si no existe
                File.WriteAllText(rutaArchivo, "");
                return; // No hace nada más
            }

            // Limpiar la lista antes de llenar
            listaDestino.Clear();

            // Leer línea por línea y agregar a la lista
            foreach (string linea in File.ReadLines(rutaArchivo))
            {
                listaDestino.Add(linea);
            }
        }

        private void EliminarItemCheckedListBox(int indiceLinea)
        {
            int indiceSeleccionado = indiceLinea;
            if (indiceSeleccionado != -1)
            {
                checkedListBoxEventos.Items.RemoveAt(indiceSeleccionado);
                EliminarLineaArchivo(indiceSeleccionado);
            }
        }

        private void EliminarLineaArchivo(int indiceLinea)
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "archivo.txt");
            List<string> lineas = File.ReadAllLines(rutaArchivo).ToList();

            if (indiceLinea >= 0 && indiceLinea < lineas.Count)
            {
                lineas.RemoveAt(indiceLinea);
                File.WriteAllLines(rutaArchivo, lineas);
            }
        }

        private int FormatoDeTextoASegundos(string tiempoEnString)
        {

            string[] partes = tiempoEnString.Split(':');

            if (partes.Length == 3)
            {
                int horas = int.Parse(partes[0]);
                int minutos = int.Parse(partes[1]);
                int segundos = int.Parse(partes[2]);

                int segundosTotales = horas * 3600 + minutos * 60 + segundos;

                return segundosTotales;
                // Usar segundosTotales según sea necesario
            }
            else
            {
                // Manejar error: el formato del tiempo no es correcto
                throw new FormatException("El formato del tiempo no es correcto");
            }

        }

        private string DeSegundosARelog(int segundosTotal)
        {

            int horas = segundosTotal / 3600;
            int minutos = (segundosTotal / 60) % 60;
            int segundos = segundosTotal % 60;

            return string.Format("{0:D2}:{1:D2}:{2:D2}", horas, minutos, segundos);
        }

        private void ModificarLineaEnArchivo(int indiceLinea, int parteAcambiar, string nuevoArgumento = null, string sumar = null, int totalASumar = 0)
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "archivo.txt");
            List<string> lineas = File.ReadAllLines(rutaArchivo).ToList();

            if (indiceLinea >= 0 && indiceLinea < lineas.Count)
            {
                var partes = lineas[indiceLinea].Split('|');


                if (sumar == "si")
                {
                    string datoASumar = MostrarDetallesDelItem(parteAcambiar);
                    int sumaTotal = int.Parse(datoASumar) + totalASumar;

                    partes[parteAcambiar] = sumaTotal.ToString();

                }
                else
                {
                    partes[parteAcambiar] = nuevoArgumento;
                }
                // Modificar el título


                // Reconstruir la línea modificada y actualizarla en la lista
                lineas[indiceLinea] = string.Join("|", partes);

                // Reescribir todas las líneas en el archivo
                File.WriteAllLines(rutaArchivo, lineas);
            }
        }

        private string ObtenerDescripcion(string descripcionModificada)
        {
            // Revertir el reemplazo de los saltos de línea
            return descripcionModificada.Replace("\\n", Environment.NewLine);
        }

        private string MostrarDetallesDelItem(int detallePedido = -1)
        {
            if (checkedListBoxEventos.SelectedIndex != -1)
            {
                string lineaCompleta = listaCompletaDatos[checkedListBoxEventos.SelectedIndex];
                var partes = lineaCompleta.Split('|');
                if (partes.Length > 1)
                {
                    string tituloEvento = partes[0];
                    string descripcion = ObtenerDescripcion(partes[1]);
                    string horaCreacion = partes[2];
                    string nivelUrgencia = partes[3];
                    string fechaDeCreacion = partes[4];
                    string minutosInvertidos = partes[5];
                    string ciclosTrabajados = partes[6];
                    string ultimoComentario = partes[7];

                    string[] DetallesItems = { tituloEvento, descripcion, horaCreacion, nivelUrgencia, fechaDeCreacion, minutosInvertidos, ciclosTrabajados, ultimoComentario };

                    if (detallePedido >= 0 && detallePedido < DetallesItems.Length)
                    {
                        return DetallesItems[detallePedido];
                    }
                }
            }
            return null;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;


                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void abrirAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void buttonAgregarTareaNueva_Click(object sender, EventArgs e)
        {
            if (textBoxAgregarTareaTitulo.Text == "")
            {
                MessageBox.Show("ERROR: La tarea debe tener un nombre para continuar.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string titulo = textBoxAgregarTareaTitulo.Text;
                string descripcion = textBoxAgregarTareaDescrip.Text;
                string prioridad = comboBoxAgregarTareaPrioridad.Text;
                string hora = DateTime.Now.ToString("HH:mm:ss");
                string fechaCreacion = DateTime.Today.ToString("yyyy-MM-dd");
                string minutosTrabajados = "0";
                string ciclostrabajados = "0";
                string ultimoComentario = "";
                GuardarDatos(titulo, descripcion, prioridad, hora, fechaCreacion, minutosTrabajados, ciclostrabajados, ultimoComentario);
                toolStripStatusLabelMensajes.Text = "Tarea agregada satisfactoriamente.";
                timer.Interval = 3000;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Configurar Progress Bar Dia
            progressBarDia.Minimum = 0;
            progressBarDia.Maximum = 1440; // Total de minutos del día
            timerDia.Start();
            ActualizarBarraDelDia();

            //
            comboBoxAgregarTareaPrioridad.SelectedIndex = 0;
            checkedListBoxEventos.DrawMode = DrawMode.OwnerDrawFixed;
            CargarTitulosEnCheckedListBox();
            CargarDesdeArchivoaLista(messagesMotiv);

            buttonIniciarCronómetro.Enabled = false;
            buttonFinalizarTarea.Enabled = false;

            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "richtext.rft");

            if (!File.Exists(rutaArchivo))
            {
                // Crear archivo vacío si no existe
                File.WriteAllText(rutaArchivo, "");
                return; // No hace nada más
            }
            else
            {
                richTextBox1.LoadFile("richtext.rft");
            }

        }

        bool PrimeraFecha = false;
        private void AddTableToRichTextBox(bool addNewLine)
        {
            int columnWidth1 = 4000;  // Ancho de la primera columna en twips
            int columnWidth2 = 4000; // Ancho de la segunda columna en twips

            // Datos para las celdas
            string cell1Data = textBoxShowDescripcionItemSelec.Text = MostrarDetallesDelItem(0);
            string cell2Data = "Observacion";
            string cell3Data = @"Inicio: " + horaDeInicioDeTarea + @"\line Final: " + horaDeFinalDeTarea + @"\line Tiempo: " + labelShowUltimoConteo.Text;
            string cell4Data;
            if (TextBoxcomentarioSesion.Text != "")
            {
                cell4Data = TextBoxcomentarioSesion.Text;
            }
            else
            {
                cell4Data = textBoxShowDescripcionItemSelec.Text = MostrarDetallesDelItem(1);
            }


            // Preparar la inserción de la tabla
            string rtfTable = @"\trowd\trgaph108"; // Iniciar la definición de fila

            rtfTable += @"\cellx" + columnWidth1.ToString();   // Final de la primera celda
            rtfTable += @"\cellx" + (columnWidth1 + columnWidth2).ToString();  // Final de la segunda celda

            // Primera fila con dos celdas
            rtfTable += @"\intbl \f0\fs24 " + cell1Data + @"\cell";  // Datos de la primera celda
            rtfTable += @"\intbl \f0\fs24 " + cell2Data + @"\cell";  // Datos de la segunda celda
            rtfTable += @"\row";  // Finalizar la fila

            // Segunda fila también con dos celdas
            rtfTable += @"\trowd\trgaph108"; // Reiniciar definición de fila para la segunda fila
            rtfTable += @"\cellx" + columnWidth1.ToString();   // Final de la primera celda en la segunda fila
            rtfTable += @"\cellx" + (columnWidth1 + columnWidth2).ToString();  // Final de la segunda celda en la segunda fila
            rtfTable += @"\intbl \f0\fs24 " + cell3Data + @"\cell";  // Datos de la primera celda en la segunda fila
            rtfTable += @"\intbl \f0\fs24 " + cell4Data + @"\cell";  // Datos de la segunda celda en la segunda fila
            rtfTable += @"\row";  // Finalizar la fila

            if (addNewLine == false)
            {
                if (PrimeraFecha == false)
                {
                    string currentRtf = richTextBox1.Rtf;
                    int lastIndex = currentRtf.LastIndexOf('}');
                    if (lastIndex != -1)
                    {
                        currentRtf = currentRtf.Substring(0, lastIndex);
                    }

                    currentRtf += rtfTable + @"\pard}";
                    richTextBox1.Rtf = currentRtf;

                    PrimeraFecha = true;

                }
                else
                {
                    string currentRtf = richTextBox1.Rtf;
                    int lastIndex = currentRtf.LastIndexOf(@"\pard");
                    if (lastIndex != -1)
                    {
                        currentRtf = currentRtf.Substring(0, lastIndex); // Eliminar el "\pard" al final
                    }

                    // Añadir la nueva tabla y cerrar con "\pard" solo al final
                    currentRtf += rtfTable + @"\pard";
                    richTextBox1.Rtf = currentRtf;
                }
            }
            else
            {
                string currentRtf = richTextBox1.Rtf;
                int lastIndex = currentRtf.LastIndexOf('}');
                if (lastIndex != -1)
                {
                    currentRtf = currentRtf.Substring(0, lastIndex);
                }

                currentRtf += rtfTable + @"\pard}";
                richTextBox1.Rtf = currentRtf;
            }

        }



        private void VerificarFechaEnRichText(RichTextBox richTextBox)
        {
            // Obtener la fecha actual con formato personalizado
            string fechaHoy = DateTime.Now.ToString("dddd d 'de' MMMM 'del' yyyy",
                new System.Globalization.CultureInfo("es-ES"));

            // Capitalizar primera letra
            fechaHoy = char.ToUpper(fechaHoy[0]) + fechaHoy.Substring(1);

            // Verificar si ya está en el texto
            if (!richTextBox.Text.Contains(fechaHoy))
            {
                // Mover el cursor al final
                richTextBox.SelectionStart = richTextBox.TextLength;
                richTextBox.SelectionLength = 0;

                // Aplicar estilos
                richTextBox.SelectionFont = new Font("Segoe UI", 12, FontStyle.Bold);
                richTextBox.SelectionColor = Color.DarkSlateBlue;

                // Insertar la fecha con estilo
                richTextBox.AppendText(Environment.NewLine + fechaHoy + Environment.NewLine);
                

                // Opcional: resetear estilo a negro y normal
                richTextBox.SelectionFont = richTextBox.Font;
                richTextBox.SelectionColor = richTextBox.ForeColor;
            }

        }

        private void checkedListBoxEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxShowDescripcionItemSelec.Text = MostrarDetallesDelItem(1) + "\r\n" +"\r\nÚltimo reporte: " + "\r\n" + MostrarDetallesDelItem(7) ;

            //solucionar error de DeSegundosAReloj lo que pasa despues de que se eliminar una tarea

            if (checkedListBoxEventos.SelectedIndex == -1)
            {

            } else {
                labelShowTiempoTotalIndexSelect.Text = DeSegundosARelog(int.Parse(MostrarDetallesDelItem(5)));

                labelShowTiempoCiclos.Text = MostrarDetallesDelItem(6);

                //Limitando longitud para mostrar solo una parte en un label
                string textoCompleto = labelInfoEventoSeleccionado.Text = MostrarDetallesDelItem(0);
                int longitudMaxima = 80;

                if (textoCompleto == null) { }
                else
                    if (textoCompleto.Length > longitudMaxima)
                {
                    labelInfoEventoSeleccionado.Text = textoCompleto.Substring(0, longitudMaxima) + "...";
                }
                else
                {
                    labelInfoEventoSeleccionado.Text = textoCompleto;
                }
            }
            

            buttonIniciarCronómetro.Enabled = true;
            buttonFinalizarTarea.Enabled = true;
        }

        private int totalSegundos = 0;
        private int totalsegundosDecimas = 0;
        private void timerMessageZar_Tick(object sender, EventArgs e)
        {
            totalSegundos++;
            int horas = totalSegundos / 3600;
            int minutos = (totalSegundos / 60) % 60;
            int segundos = totalSegundos % 60;

            labelShowCronometro.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", horas, minutos, segundos);

            totalsegundosDecimas = 0;
        }

        string EstadoConteo = "Inactivo";
        string horaDeInicioDeTarea = "";
        string horaDeFinalDeTarea = "";
        string comentarioDeLaSesion = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (!timerCronometro.Enabled)
            {
                timerCronometro.Start();
                TimerDecimasDeSegundo.Start();
                buttonIniciarCronómetro.Text = "Pausar";
                EstadoConteo = "activo";
                checkedListBoxEventos.Enabled = false;                
                tabControl1.TabPages[1].Enabled = false;
                tabControl1.TabPages[2].Enabled = false;

                horaDeInicioDeTarea = horaOfechaActual("time");
            }
            else

            {
                timerCronometro.Stop();
                TimerDecimasDeSegundo.Stop();
                buttonIniciarCronómetro.Text = "Continuar";
                if (EstadoConteo == "activo")
                {
                    labelShowUltimoConteo.Text = labelShowCronometro.Text;
                    comentarioDeLaSesion = TextBoxcomentarioSesion.Text;
                }

            }
        }

        private void TimerDecimasDeSegundo_Tick(object sender, EventArgs e)
        {
            totalsegundosDecimas++;
            if (totalsegundosDecimas >= 10)
            {
                totalsegundosDecimas = 0;
            }
            int decimas = totalsegundosDecimas % 10;
            labelShowCronometroDecimasDeSegundo.Text = string.Format("{0:D1}", decimas);
        }

        int ShowTiempoConteo = 0;
        int ShowCiclosTotales = 0;
        string NombreTareaMasDuracion = "";
        int TareaMayorDuracionSegundos = 0;

        string NombreTareaMenosDuracion = "";
        int TareaMenosDuracionSegundos = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (EstadoConteo == "activo")
            {

                
                int indiceSeleccionado = checkedListBoxEventos.SelectedIndex;
                horaDeFinalDeTarea = horaOfechaActual("time");
                comentarioDeLaSesion = TextBoxcomentarioSesion.Text;
                ModificarLineaEnArchivo(indiceSeleccionado, 5, "", "si", FormatoDeTextoASegundos(labelShowCronometro.Text));
                ModificarLineaEnArchivo(indiceSeleccionado, 6, "", "si", 1);

                if (comentarioDeLaSesion != "") {
                ModificarLineaEnArchivo(indiceSeleccionado, 7, comentarioDeLaSesion, "no", 0);
                }

                //Actualizando reportes de la sesion con los datos de la sesion
                labelShowUltimoConteo.Text = labelShowCronometro.Text;
                ShowTiempoConteo = ShowTiempoConteo + FormatoDeTextoASegundos(labelShowCronometro.Text);
                labelShowTiempoTotal.Text = DeSegundosARelog(ShowTiempoConteo);
                
                ShowCiclosTotales = ShowCiclosTotales + 1;
                labelShowCiclosTotales.Text = (ShowCiclosTotales).ToString();

                //Actualizando reportes de Tareas Ranking 1

                if (labelTareamasduracion.Text == "Sin sesiones" && labelTareaMenosduracion.Text == "Sin sesiones")
                {
                    labelTareamasduracion.Text = labelInfoEventoSeleccionado.Text;
                    labelTareaMenosduracion.Text = labelInfoEventoSeleccionado.Text;

                    labelTiempoTareaMasDuracion.Text = labelShowCronometro.Text;
                    labelTiempoTareaMenosDuracion.Text = labelShowCronometro.Text;


                } else
                    { 
                    
                    if (FormatoDeTextoASegundos(labelShowCronometro.Text) > FormatoDeTextoASegundos(labelTiempoTareaMasDuracion.Text))
                    {
                        labelTareamasduracion.Text = labelInfoEventoSeleccionado.Text;
                        labelTiempoTareaMasDuracion.Text = labelShowCronometro.Text;
                    }

                    if (FormatoDeTextoASegundos(labelShowCronometro.Text) < FormatoDeTextoASegundos(labelTiempoTareaMenosDuracion.Text))
                    {
                        labelTareaMenosduracion.Text = labelInfoEventoSeleccionado.Text;
                        labelTiempoTareaMenosDuracion.Text = labelShowCronometro.Text;
                    }

                }


                totalSegundos = 0;
                totalsegundosDecimas = 0;

                labelShowCronometro.Text = "00:00:00";
                labelShowCronometroDecimasDeSegundo.Text = "0";
                timerCronometro.Stop();
                TimerDecimasDeSegundo.Stop();
                buttonIniciarCronómetro.Text = "Iniciar";
                checkedListBoxEventos.Enabled = true;
                tabControl1.TabPages[1].Enabled = true;
                tabControl1.TabPages[2].Enabled = true;

                EstadoConteo = "Inactivo";

                if (checkBoxLogAutomatico.Checked == true)
                {
                    button1_Click_2(null, EventArgs.Empty);
                }

                cargarTareasToolStripMenuItem_Click(null, EventArgs.Empty);

                checkedListBoxEventos.SelectedIndex = indiceSeleccionado;
            }
            
        }

        private void ActualizarBarraDelDia()
        {
            int minutosActuales = DateTime.Now.Hour * 60 + DateTime.Now.Minute;
            progressBarDia.Value = Math.Min(minutosActuales, progressBarDia.Maximum); // Seguridad por si algo falla
        }

        private void cargarTareasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarTitulosEnCheckedListBox();
        }



        private void button1_Click_2(object sender, EventArgs e)
        {

            VerificarFechaEnRichText(richTextBox1);

            if (checkBoxSaltoLinea.Checked == false)
            {              
                AddTableToRichTextBox(false);
                richTextBox1.SaveFile("richtext.rft");

            } else
            {
                AddTableToRichTextBox(true);
                richTextBox1.SaveFile("richtext.rft");
            }
            

        }

        private void eliminarTareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = checkedListBoxEventos.SelectedIndex;
            if (indiceSeleccionado != -1)
            {
                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este evento de la lista permanentemente?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    checkedListBoxEventos.SelectedIndex = 0;
                    EliminarItemCheckedListBox(indiceSeleccionado);
                }
            }
        }

        private void buttonInsertarATexto_Click(object sender, EventArgs e)
        {
            
        }

        private void timerDia_Tick(object sender, EventArgs e)
        {
            ActualizarBarraDelDia();
        }
    }

    

}


