using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
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
            var rnd = new Random();

            /* ---------- Mensaje motivacional ---------- */
            if (messagesMotiv.Count > 0)
            {
                int idxMot = rnd.Next(messagesMotiv.Count);   // nunca se llama con 0
                toolStripStatusLabelMensajes.Text = messagesMotiv[idxMot];
            }
            else
            {
                toolStripStatusLabelMensajes.Text = "Añade frases a frases.txt";
            }

            /* ---------- Mensaje “Recuerda …” ---------- */
            if (listaTareasUrgentes.Count > 0 && rnd.Next(2) == 0)  // 50 % de las veces
            {
                int idxRec = rnd.Next(listaTareasUrgentes.Count);
                toolStripStatusLabelMensajes.Text = "Recuerda: " +
                                                    listaTareasUrgentes[idxRec];
            }

            /* ---------- Cambiar intervalo aleatorio ---------- */
            timer.Interval = rnd.Next(10_000, 30_000);   // entre 10 s y 30 s
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
                File.WriteAllText(rutaArchivo, "");   // crea el archivo
                return;                               // deja la lista tal cual
            }

            var lineas = File.ReadAllLines(rutaArchivo)
                             .Select(l => l.Trim())
                             .Where(l => l.Length > 0)   // descarta líneas vacías
                             .ToList();

            if (lineas.Count == 0) return;              // no borres los mensajes default

            listaDestino.Clear();
            listaDestino.AddRange(lineas);
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
                cargarTareasToolStripMenuItem_Click(null, null);
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

            
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                  "richtext.rft");

            if (!File.Exists(rutaArchivo))
            {
                // Crear un RTF mínimo válido
                File.WriteAllText(rutaArchivo, @"{\rtf1\ansi\pard\par}");
            }

            richTextBox1.LoadFile(rutaArchivo, RichTextBoxStreamType.RichText);

        }

        bool PrimeraFecha = false;

        private void AddTableToRichTextBox(bool addNewLine)
        {
            int columnWidth1 = 4000;
            int columnWidth2 = 4000;

            string cell1Data = MostrarDetallesDelItem(0);
            string cell2Data = "Observación";
            string cell3Data = @"Inicio: " + horaDeInicioDeTarea + @"\line Final: " + horaDeFinalDeTarea + @"\line Tiempo: " + labelShowUltimoConteo.Text;
            string cell4Data = !string.IsNullOrWhiteSpace(TextBoxcomentarioSesion.Text)
                                ? TextBoxcomentarioSesion.Text
                                : MostrarDetallesDelItem(1);

            string rtfTable = @"\trowd\trgaph108" +
                              @"\cellx" + columnWidth1 +
                              @"\cellx" + (columnWidth1 + columnWidth2) +
                              @"\intbl\plain\f0\fs24\cf0 " + cell1Data + @"\cell" +
                              @"\intbl\plain\f0\fs24\cf0 " + cell2Data + @"\cell" +
                              @"\row" +
                              @"\trowd\trgaph108" +
                              @"\cellx" + columnWidth1 +
                              @"\cellx" + (columnWidth1 + columnWidth2) +
                              @"\intbl\plain\f0\fs24\cf0 " + cell3Data + @"\cell" +
                              @"\intbl\plain\f0\fs24\cf0 " + cell4Data + @"\cell" +
                              @"\row";

            string currentRtf = richTextBox1.Rtf;
            int lastBrace = currentRtf.LastIndexOf('}');
            if (lastBrace == -1) return;

            string before = currentRtf.Substring(0, lastBrace);
            string tail = before.Length >= 100 ? before.Substring(before.Length - 100) : before;
            string head = before.Substring(0, before.Length - tail.Length);

            if (!PrimeraFecha)
            {
                // Forzar un salto la primera vez
                tail = Regex.Replace(tail, @"(\\par|\\line)+\s*$", "", RegexOptions.Multiline);
                currentRtf = head + tail + @"\par " + rtfTable + "}";
                PrimeraFecha = true;
            }
            else
            {
                if (!addNewLine)
                {
                    tail = Regex.Replace(tail, @"(\\par|\\line)+\s*$", "", RegexOptions.Multiline);
                    currentRtf = head + tail + rtfTable + "}";
                }
                else
                {
                    tail = Regex.Replace(tail, @"(\\par|\\line)+\s*$", "", RegexOptions.Multiline);
                    currentRtf = head + tail + @"\par " + rtfTable + "}";
                }
            }

            richTextBox1.Rtf = currentRtf;
        }

        private void RegistrarSesion(bool saltoLinea)
        {
            // 1) Asegura cabecera de fecha del día
            VerificarFechaEnRichText(richTextBox1);

            // 2) Inserta la tabla (sin salto = false ⇒ misma línea)
            AddTableToRichTextBox(saltoLinea);

            // 3) Guarda como RTF válido
            string rutaRtf = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "richtext.rft");
            richTextBox1.SaveFile(rutaRtf, RichTextBoxStreamType.RichText);
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
            if (checkBoxSaltoLinea.Checked == true)
            {
                RegistrarSesion(true);
            } else
            {
                RegistrarSesion(false);
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

        public class Tarea
        {
            public DateTime Fecha { get; set; }
            public string Nombre { get; set; }
            public string Observacion { get; set; }
            public TimeSpan Tiempo { get; set; }
        }

        public List<Tarea> ExtraerTareas(string texto)
        {
            var tareas = new List<Tarea>();
            var lineas = texto.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            var rxFecha = new Regex(@"^\w+ \d{1,2} de \w+ del \d{4}$", RegexOptions.IgnoreCase);
            var rxTiempo = new Regex(@"Tiempo:\s*(\d{2}:\d{2}:\d{2})", RegexOptions.IgnoreCase);

            DateTime fechaActual = DateTime.MinValue;
            string nombrePend = null;   // nombre de la tarea en cabecera
            string obsPend = "";     // observación de cabecera (si hubiera)

            foreach (var raw in lineas)
            {
                string l = raw.Trim();

                //------------------------------------------------------------------
                // 1)  DETECTAR FECHA (cambia contexto)
                //------------------------------------------------------------------
                if (rxFecha.IsMatch(l))
                {
                    DateTime.TryParseExact(
                        l,
                        "dddd d 'de' MMMM 'del' yyyy",
                        new CultureInfo("es-ES"),
                        DateTimeStyles.None,
                        out fechaActual);

                    // descartar bloque incompleto anterior
                    nombrePend = null;
                    obsPend = "";
                    continue;
                }

                //------------------------------------------------------------------
                // 2)  CABECERA DE TAREA  (fila 1 / celda 1)
                //------------------------------------------------------------------
                bool esCabecera = (l.Contains('\t') || l.Contains('/')) &&
                                  !l.StartsWith("Inicio:", StringComparison.OrdinalIgnoreCase) &&
                                  !l.StartsWith("Tiempo:", StringComparison.OrdinalIgnoreCase);

                if (esCabecera)
                {
                    string[] partes = l.Contains('\t')
                                      ? l.Split('\t')
                                      : l.Split('/');

                    string candidato = partes[0].Trim();

                    // ignorar si el “nombre” es vacío o literalmente "Observacion"
                    if (!string.IsNullOrWhiteSpace(candidato) &&
                        candidato.IndexOf("Observacion", StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        nombrePend = candidato;
                        obsPend = partes.Length > 1 ? partes[1].Trim() : "";
                    }
                    continue;
                }

                //------------------------------------------------------------------
                // 3)  LÍNEA “Tiempo: hh:mm:ss”  (fila 2 / celda 1)
                //------------------------------------------------------------------
                var m = rxTiempo.Match(l);
                if (m.Success && nombrePend != null)
                {
                    if (TimeSpan.TryParse(m.Groups[1].Value, out var ts) &&
                        ts > TimeSpan.Zero &&
                        fechaActual != DateTime.MinValue)
                    {
                        // ¿observación real a la derecha de la línea Tiempo?  (celda 2)
                        string obsFinal = obsPend;                // valor por defecto

                        if (raw.Contains('\t'))
                        {
                            var partes2 = raw.Split('\t');
                            if (partes2.Length > 1)
                                obsFinal = partes2[1].Trim();
                        }
                        else
                        {
                            var partes2 = Regex.Split(raw, @"\s{2,}");
                            if (partes2.Length > 1)
                                obsFinal = partes2[1].Trim();
                        }

                        tareas.Add(new Tarea
                        {
                            Fecha = fechaActual,
                            Nombre = nombrePend,
                            Observacion = obsFinal,
                            Tiempo = ts
                        });
                    }

                    // limpiar para la próxima tarea
                    nombrePend = null;
                    obsPend = "";
                }
            }

            return tareas;
        }


        /// Imprime el resumen dentro del mismo RichTextBox.
        /// Si “desde” y/o “hasta” son null se toma todo el documento.
        public void ImprimirResumen(RichTextBox rtb, RichTextBox rtbPrint,
                                    DateTime? desde = null,
                                    DateTime? hasta = null)
        {
            var todas = ExtraerTareas(rtb.Text);

            // ---- Filtrado por rango (inclusive) -----------------
            var tareas = todas
                .Where(t =>
                    (!desde.HasValue || t.Fecha.Date >= desde.Value.Date) &&
                    (!hasta.HasValue || t.Fecha.Date <= hasta.Value.Date))
                .ToList();

            if (tareas.Count == 0)
            {
                MessageBox.Show("No se encontraron tareas en el rango solicitado.");
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine("\n=== RESUMEN DE TAREAS ===\n");

            foreach (var g in tareas.GroupBy(t => t.Fecha).OrderBy(g => g.Key))
            {
                sb.AppendLine(g.Key.ToString("dddd d 'de' MMMM 'del' yyyy",
                                             new CultureInfo("es-ES")));

                foreach (var t in g)
                {
                    string obsTxt = string.IsNullOrWhiteSpace(t.Observacion)
                                    ? ""
                                    : $" ({t.Observacion})";
                    sb.AppendLine($"· {t.Nombre}: {t.Tiempo}{obsTxt}");
                }

                var totDia = new TimeSpan(g.Sum(t => t.Tiempo.Ticks));
                sb.AppendLine($"⌛ Total día: {totDia}\n");
            }

            var totGen = new TimeSpan(tareas.Sum(t => t.Tiempo.Ticks));
            sb.AppendLine($"🧮 Total acumulado: {totGen}");

            //rtb.AppendText(sb.ToString());
            rtbPrint.AppendText( sb.ToString() );
        }

        public void ImprimirEstadisticas(RichTextBox rtb, RichTextBox rtbPrint,
                                 DateTime? desde = null,
                                 DateTime? hasta = null, bool estadisticasTarea = true, bool tiempoTotalDeTareas = true)
        {
            // 1) Obtener todas las tareas (usa tu función existente)
            var todas = ExtraerTareas(rtb.Text);

            // 2) Filtrar por rango, si se especifica
            var tareas = todas
                .Where(t =>
                    (!desde.HasValue || t.Fecha.Date >= desde.Value.Date) &&
                    (!hasta.HasValue || t.Fecha.Date <= hasta.Value.Date))
                .ToList();

            if (!tareas.Any())
            {
                MessageBox.Show("No hay tareas en el rango indicado.");
                return;
            }

            // 3) Acumular tiempo total y conteo por nombre de tarea
            var porTarea = tareas
                .GroupBy(t => t.Nombre)
                .Select(g => new
                {
                    Nombre = g.Key,
                    Total = new TimeSpan(g.Sum(x => x.Tiempo.Ticks)),
                    Veces = g.Count()
                })
                .OrderByDescending(x => x.Total)
                .ToList();

            // Máximo y mínimo
            var maxTiempo = porTarea.First().Total;
            var minTiempo = porTarea.Last().Total;

            var masRealizadas = porTarea.Where(x => x.Total == maxTiempo)
                                        .Select(x => x.Nombre)
                                        .ToList();

            var menosRealizadas = porTarea.Where(x => x.Total == minTiempo)
                                          .Select(x => x.Nombre)
                                          .ToList();

            // 4) Tiempo total por día
            var porDia = tareas
                .GroupBy(t => t.Fecha.Date)
                .Select(g => new
                {
                    Dia = g.Key,
                    Total = new TimeSpan(g.Sum(x => x.Tiempo.Ticks))
                })
                .OrderByDescending(x => x.Total)
                .ToList();

            string diaMax = string.Empty;
            string diaMin = string.Empty;

            if (porDia.Count > 1)
            {
                var maxDiaTotal = porDia.First().Total;
                var minDiaTotal = porDia.Last().Total;

                diaMax = porDia.First(x => x.Total == maxDiaTotal)
                             .Dia.ToString("dddd d 'de' MMMM 'del' yyyy",
                                           new CultureInfo("es-ES"));

                diaMin = porDia.First(x => x.Total == minDiaTotal)
                             .Dia.ToString("dddd d 'de' MMMM 'del' yyyy",
                                           new CultureInfo("es-ES"));
            }

            // 5) Construir salida
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("=== ESTADÍSTICAS DE TAREAS ===");
            sb.AppendLine();

            if (estadisticasTarea == true) { 
                sb.AppendLine($"Tarea(s) con MÁS tiempo : {string.Join("; ", masRealizadas)}  ({maxTiempo})");
                sb.AppendLine($"Tarea(s) con MENOS tiempo: {string.Join("; ", menosRealizadas)}  ({minTiempo})");

                if (!string.IsNullOrEmpty(diaMax))
                {
                    sb.AppendLine();
                    sb.AppendLine($"Día con MÁS tiempo total  : {diaMax}  ({porDia.First().Total})");
                    sb.AppendLine($"Día con MENOS tiempo total: {diaMin}  ({porDia.Last().Total})");
                }
            }

            if (tiempoTotalDeTareas == true) { 
                sb.AppendLine();
                sb.AppendLine("Tiempo total por tarea:");
                foreach (var t in porTarea)
                    sb.AppendLine($"· {t.Nombre} ({t.Veces}): {t.Total}");

                // 6) Añadir al RichTextBox
                //rtb.AppendText(sb.ToString());
                
            }

            rtbPrint.AppendText(sb.ToString());
        }

            private void button1_Click_1(object sender, EventArgs e)
        {

            

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonImprimirEstadisticas_Click(object sender, EventArgs e)
        {

            if (radioButtonEstadDatosDia.Checked == true)
            {
                DateTime hoy = DateTime.Today;
                if (checkBoxEstadResumenDia.Checked == true) { ImprimirResumen(richTextBox1, richTextBox2, desde: hoy); }
              
                ImprimirEstadisticas(richTextBox1, richTextBox2, desde: hoy,null,checkBoxEstadEstadTareas.Checked,checkBoxEstadTiempoTotalTareas.Checked);

            } else
            
            {
                if (radioButtonEstadTodo.Checked == true)
                {
                    DateTime hoy = DateTime.Today;
                    if (checkBoxEstadResumenDia.Checked == true) { ImprimirResumen(richTextBox1, richTextBox2); }

                    ImprimirEstadisticas(richTextBox1, richTextBox2, null, null, checkBoxEstadEstadTareas.Checked, checkBoxEstadTiempoTotalTareas.Checked);

                } 
                
                if (radioButtonEstadRangoFechas.Checked == true)

                {

                    if (checkBoxEstadResumenDia.Checked == true) { ImprimirResumen(richTextBox1, richTextBox2, dateTimePickerEstadFechaInicio.Value.Date, dateTimePickerEstadFechaFinal.Value.Date); }

                    ImprimirEstadisticas(richTextBox1, richTextBox2, dateTimePickerEstadFechaInicio.Value.Date, dateTimePickerEstadFechaFinal.Value.Date, checkBoxEstadEstadTareas.Checked, checkBoxEstadTiempoTotalTareas.Checked);


                }
                
            }

            //SOLO FALTA AGREGARLE IMPRIMIR DESDE, O HASTA


            /*    //Imprimir de todas las fechas
                ImprimirResumen(richTextBox1,richTextBox2);
                ImprimirEstadisticas(richTextBox1,richTextBox2);
            */
            /*

                //Imprimir entre dos fechas
                 ImprimirResumen(
                     richTextBox1, richTextBox2,
                     new DateTime(2025, 6, 5),
                     new DateTime(2025, 6, 6));

                ImprimirEstadisticas(
                     richTextBox1, richTextBox2,
                     new DateTime(2025, 6, 5),
                     new DateTime(2025, 6, 6));
            */

            

            // Imprimir desde:
            //ImprimirResumen(richTextBox1, richTextBox2, desde: dateTimePickerEstadFechaInicio.Value.Date);
            //ImprimirEstadisticas(richTextBox1, richTextBox2, desde: dateTimePickerEstadFechaInicio.Value.Date);

            // ImprimirResumen(richTextBox1, richTextBox2, desde: new DateTime(2025, 6, 6));
            // ImprimirEstadisticas(richTextBox1, richTextBox2, desde: new DateTime(2025, 6, 6));



            // ImprimirResumen(richTextBox1, hasta: new DateTime(2025, 6, 6));
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }



}


