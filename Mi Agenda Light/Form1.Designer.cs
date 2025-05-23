namespace Mi_Agenda_Light
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TextBoxcomentarioSesion = new System.Windows.Forms.TextBox();
            this.labelShowCronometroDecimasDeSegundo = new System.Windows.Forms.Label();
            this.buttonFinalizarTarea = new System.Windows.Forms.Button();
            this.labelShowCronometro = new System.Windows.Forms.Label();
            this.buttonIniciarCronómetro = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelShowTiempoCiclos = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelShowTiempoTotalIndexSelect = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxShowDescripcionItemSelec = new System.Windows.Forms.TextBox();
            this.labelInfoEventoSeleccionado = new System.Windows.Forms.Label();
            this.checkedListBoxEventos = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStripListaTareas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cargarTareasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarTareaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelShowCiclosTotales = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelShowTiempoTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelShowUltimoConteo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBoxAgregarTareaPrioridad = new System.Windows.Forms.ComboBox();
            this.buttonAgregarTareaNueva = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxAgregarTareaDescrip = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAgregarTareaTitulo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxSaltoLinea = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMensajes = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirAplicaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerCronometro = new System.Windows.Forms.Timer(this.components);
            this.TimerDecimasDeSegundo = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStripListaTareas.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(649, 395);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(641, 369);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tareas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.TextBoxcomentarioSesion);
            this.groupBox2.Controls.Add(this.labelShowCronometroDecimasDeSegundo);
            this.groupBox2.Controls.Add(this.buttonFinalizarTarea);
            this.groupBox2.Controls.Add(this.labelShowCronometro);
            this.groupBox2.Controls.Add(this.buttonIniciarCronómetro);
            this.groupBox2.Location = new System.Drawing.Point(484, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 336);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "A Trabajar";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Comentario de la sesión:";
            // 
            // TextBoxcomentarioSesion
            // 
            this.TextBoxcomentarioSesion.Location = new System.Drawing.Point(11, 136);
            this.TextBoxcomentarioSesion.Multiline = true;
            this.TextBoxcomentarioSesion.Name = "TextBoxcomentarioSesion";
            this.TextBoxcomentarioSesion.Size = new System.Drawing.Size(129, 82);
            this.TextBoxcomentarioSesion.TabIndex = 4;
            // 
            // labelShowCronometroDecimasDeSegundo
            // 
            this.labelShowCronometroDecimasDeSegundo.AutoSize = true;
            this.labelShowCronometroDecimasDeSegundo.Location = new System.Drawing.Point(126, 12);
            this.labelShowCronometroDecimasDeSegundo.Name = "labelShowCronometroDecimasDeSegundo";
            this.labelShowCronometroDecimasDeSegundo.Size = new System.Drawing.Size(13, 13);
            this.labelShowCronometroDecimasDeSegundo.TabIndex = 3;
            this.labelShowCronometroDecimasDeSegundo.Text = "0";
            // 
            // buttonFinalizarTarea
            // 
            this.buttonFinalizarTarea.Location = new System.Drawing.Point(11, 81);
            this.buttonFinalizarTarea.Name = "buttonFinalizarTarea";
            this.buttonFinalizarTarea.Size = new System.Drawing.Size(129, 30);
            this.buttonFinalizarTarea.TabIndex = 2;
            this.buttonFinalizarTarea.Text = "Finalizar";
            this.buttonFinalizarTarea.UseVisualStyleBackColor = true;
            this.buttonFinalizarTarea.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelShowCronometro
            // 
            this.labelShowCronometro.AutoSize = true;
            this.labelShowCronometro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShowCronometro.Location = new System.Drawing.Point(32, 19);
            this.labelShowCronometro.Name = "labelShowCronometro";
            this.labelShowCronometro.Size = new System.Drawing.Size(102, 25);
            this.labelShowCronometro.TabIndex = 1;
            this.labelShowCronometro.Text = "00:00:00 ";
            // 
            // buttonIniciarCronómetro
            // 
            this.buttonIniciarCronómetro.Location = new System.Drawing.Point(11, 48);
            this.buttonIniciarCronómetro.Name = "buttonIniciarCronómetro";
            this.buttonIniciarCronómetro.Size = new System.Drawing.Size(129, 30);
            this.buttonIniciarCronómetro.TabIndex = 0;
            this.buttonIniciarCronómetro.Text = "Empezar";
            this.buttonIniciarCronómetro.UseVisualStyleBackColor = true;
            this.buttonIniciarCronómetro.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelShowTiempoCiclos);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labelShowTiempoTotalIndexSelect);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxShowDescripcionItemSelec);
            this.groupBox1.Controls.Add(this.labelInfoEventoSeleccionado);
            this.groupBox1.Controls.Add(this.checkedListBoxEventos);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 336);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tareas";
            // 
            // labelShowTiempoCiclos
            // 
            this.labelShowTiempoCiclos.AutoSize = true;
            this.labelShowTiempoCiclos.Location = new System.Drawing.Point(412, 309);
            this.labelShowTiempoCiclos.Name = "labelShowTiempoCiclos";
            this.labelShowTiempoCiclos.Size = new System.Drawing.Size(61, 13);
            this.labelShowTiempoCiclos.TabIndex = 6;
            this.labelShowTiempoCiclos.Text = "999999999";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(412, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ciclos:";
            // 
            // labelShowTiempoTotalIndexSelect
            // 
            this.labelShowTiempoTotalIndexSelect.AutoSize = true;
            this.labelShowTiempoTotalIndexSelect.Location = new System.Drawing.Point(412, 270);
            this.labelShowTiempoTotalIndexSelect.Name = "labelShowTiempoTotalIndexSelect";
            this.labelShowTiempoTotalIndexSelect.Size = new System.Drawing.Size(55, 13);
            this.labelShowTiempoTotalIndexSelect.TabIndex = 4;
            this.labelShowTiempoTotalIndexSelect.Text = "999:59:59";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tiempo:";
            // 
            // textBoxShowDescripcionItemSelec
            // 
            this.textBoxShowDescripcionItemSelec.Location = new System.Drawing.Point(6, 250);
            this.textBoxShowDescripcionItemSelec.Multiline = true;
            this.textBoxShowDescripcionItemSelec.Name = "textBoxShowDescripcionItemSelec";
            this.textBoxShowDescripcionItemSelec.ReadOnly = true;
            this.textBoxShowDescripcionItemSelec.Size = new System.Drawing.Size(400, 78);
            this.textBoxShowDescripcionItemSelec.TabIndex = 2;
            this.textBoxShowDescripcionItemSelec.Text = "Esta es la descripcion de la tarea seleccionada u/o en la que se esta trabajando";
            // 
            // labelInfoEventoSeleccionado
            // 
            this.labelInfoEventoSeleccionado.AutoSize = true;
            this.labelInfoEventoSeleccionado.Location = new System.Drawing.Point(5, 230);
            this.labelInfoEventoSeleccionado.Name = "labelInfoEventoSeleccionado";
            this.labelInfoEventoSeleccionado.Size = new System.Drawing.Size(117, 13);
            this.labelInfoEventoSeleccionado.TabIndex = 1;
            this.labelInfoEventoSeleccionado.Text = "Seleccione una tarea...";
            // 
            // checkedListBoxEventos
            // 
            this.checkedListBoxEventos.ContextMenuStrip = this.contextMenuStripListaTareas;
            this.checkedListBoxEventos.FormattingEnabled = true;
            this.checkedListBoxEventos.Items.AddRange(new object[] {
            "Tarea 1",
            "Tarea 2"});
            this.checkedListBoxEventos.Location = new System.Drawing.Point(6, 19);
            this.checkedListBoxEventos.Name = "checkedListBoxEventos";
            this.checkedListBoxEventos.Size = new System.Drawing.Size(465, 199);
            this.checkedListBoxEventos.TabIndex = 0;
            this.checkedListBoxEventos.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxEventos_SelectedIndexChanged);
            // 
            // contextMenuStripListaTareas
            // 
            this.contextMenuStripListaTareas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarTareasToolStripMenuItem,
            this.eliminarTareaToolStripMenuItem});
            this.contextMenuStripListaTareas.Name = "contextMenuStripListaTareas";
            this.contextMenuStripListaTareas.Size = new System.Drawing.Size(148, 48);
            // 
            // cargarTareasToolStripMenuItem
            // 
            this.cargarTareasToolStripMenuItem.Name = "cargarTareasToolStripMenuItem";
            this.cargarTareasToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.cargarTareasToolStripMenuItem.Text = "Cargar Tareas";
            this.cargarTareasToolStripMenuItem.Click += new System.EventHandler(this.cargarTareasToolStripMenuItem_Click);
            // 
            // eliminarTareaToolStripMenuItem
            // 
            this.eliminarTareaToolStripMenuItem.Name = "eliminarTareaToolStripMenuItem";
            this.eliminarTareaToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.eliminarTareaToolStripMenuItem.Text = "Eliminar Tarea";
            this.eliminarTareaToolStripMenuItem.Click += new System.EventHandler(this.eliminarTareaToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(641, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuración";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.labelShowCiclosTotales);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.labelShowTiempoTotal);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.labelShowUltimoConteo);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(325, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 185);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reportes de la Sesión";
            // 
            // labelShowCiclosTotales
            // 
            this.labelShowCiclosTotales.AutoSize = true;
            this.labelShowCiclosTotales.Location = new System.Drawing.Point(6, 113);
            this.labelShowCiclosTotales.Name = "labelShowCiclosTotales";
            this.labelShowCiclosTotales.Size = new System.Drawing.Size(49, 13);
            this.labelShowCiclosTotales.TabIndex = 11;
            this.labelShowCiclosTotales.Text = "0000000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Ciclos totales:";
            // 
            // labelShowTiempoTotal
            // 
            this.labelShowTiempoTotal.AutoSize = true;
            this.labelShowTiempoTotal.Location = new System.Drawing.Point(6, 74);
            this.labelShowTiempoTotal.Name = "labelShowTiempoTotal";
            this.labelShowTiempoTotal.Size = new System.Drawing.Size(49, 13);
            this.labelShowTiempoTotal.TabIndex = 9;
            this.labelShowTiempoTotal.Text = "00:00:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tiempo total:";
            // 
            // labelShowUltimoConteo
            // 
            this.labelShowUltimoConteo.AutoSize = true;
            this.labelShowUltimoConteo.Location = new System.Drawing.Point(6, 35);
            this.labelShowUltimoConteo.Name = "labelShowUltimoConteo";
            this.labelShowUltimoConteo.Size = new System.Drawing.Size(49, 13);
            this.labelShowUltimoConteo.TabIndex = 7;
            this.labelShowUltimoConteo.Text = "00:00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Último conteo:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBoxAgregarTareaPrioridad);
            this.groupBox4.Controls.Add(this.buttonAgregarTareaNueva);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.textBoxAgregarTareaDescrip);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.textBoxAgregarTareaTitulo);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(5, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(314, 185);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Agregar Tareas";
            // 
            // comboBoxAgregarTareaPrioridad
            // 
            this.comboBoxAgregarTareaPrioridad.FormattingEnabled = true;
            this.comboBoxAgregarTareaPrioridad.Items.AddRange(new object[] {
            "Normal",
            "Alta"});
            this.comboBoxAgregarTareaPrioridad.Location = new System.Drawing.Point(8, 155);
            this.comboBoxAgregarTareaPrioridad.Name = "comboBoxAgregarTareaPrioridad";
            this.comboBoxAgregarTareaPrioridad.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAgregarTareaPrioridad.TabIndex = 3;
            this.comboBoxAgregarTareaPrioridad.Text = "Normal";
            // 
            // buttonAgregarTareaNueva
            // 
            this.buttonAgregarTareaNueva.Location = new System.Drawing.Point(213, 146);
            this.buttonAgregarTareaNueva.Name = "buttonAgregarTareaNueva";
            this.buttonAgregarTareaNueva.Size = new System.Drawing.Size(92, 30);
            this.buttonAgregarTareaNueva.TabIndex = 6;
            this.buttonAgregarTareaNueva.Text = "Agregar";
            this.buttonAgregarTareaNueva.UseVisualStyleBackColor = true;
            this.buttonAgregarTareaNueva.Click += new System.EventHandler(this.buttonAgregarTareaNueva_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Prioridad:";
            // 
            // textBoxAgregarTareaDescrip
            // 
            this.textBoxAgregarTareaDescrip.Location = new System.Drawing.Point(8, 76);
            this.textBoxAgregarTareaDescrip.Multiline = true;
            this.textBoxAgregarTareaDescrip.Name = "textBoxAgregarTareaDescrip";
            this.textBoxAgregarTareaDescrip.Size = new System.Drawing.Size(297, 60);
            this.textBoxAgregarTareaDescrip.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Descripción:";
            // 
            // textBoxAgregarTareaTitulo
            // 
            this.textBoxAgregarTareaTitulo.Location = new System.Drawing.Point(8, 37);
            this.textBoxAgregarTareaTitulo.Name = "textBoxAgregarTareaTitulo";
            this.textBoxAgregarTareaTitulo.Size = new System.Drawing.Size(297, 20);
            this.textBoxAgregarTareaTitulo.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nombre de la tarea:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(641, 369);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Reporte";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBoxSaltoLinea);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.richTextBox1);
            this.groupBox5.Location = new System.Drawing.Point(5, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(628, 337);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Impresión:";
            // 
            // checkBoxSaltoLinea
            // 
            this.checkBoxSaltoLinea.AutoSize = true;
            this.checkBoxSaltoLinea.Location = new System.Drawing.Point(326, 312);
            this.checkBoxSaltoLinea.Name = "checkBoxSaltoLinea";
            this.checkBoxSaltoLinea.Size = new System.Drawing.Size(153, 17);
            this.checkBoxSaltoLinea.TabIndex = 2;
            this.checkBoxSaltoLinea.Text = "Reporte con salto de linea.";
            this.checkBoxSaltoLinea.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(485, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(616, 283);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMensajes});
            this.statusStrip1.Location = new System.Drawing.Point(0, 365);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(649, 30);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelMensajes
            // 
            this.toolStripStatusLabelMensajes.AutoSize = false;
            this.toolStripStatusLabelMensajes.Name = "toolStripStatusLabelMensajes";
            this.toolStripStatusLabelMensajes.Size = new System.Drawing.Size(380, 25);
            this.toolStripStatusLabelMensajes.Text = "Hoy va a ser un día muy efectivo...";
            this.toolStripStatusLabelMensajes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirAplicaciónToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 26);
            // 
            // abrirAplicaciónToolStripMenuItem
            // 
            this.abrirAplicaciónToolStripMenuItem.Name = "abrirAplicaciónToolStripMenuItem";
            this.abrirAplicaciónToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.abrirAplicaciónToolStripMenuItem.Text = "Mostrar aplicación";
            this.abrirAplicaciónToolStripMenuItem.Click += new System.EventHandler(this.abrirAplicaciónToolStripMenuItem_Click);
            // 
            // timerCronometro
            // 
            this.timerCronometro.Interval = 1000;
            this.timerCronometro.Tick += new System.EventHandler(this.timerMessageZar_Tick);
            // 
            // TimerDecimasDeSegundo
            // 
            this.TimerDecimasDeSegundo.Tick += new System.EventHandler(this.TimerDecimasDeSegundo_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Sesión de mas duración:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "00:00:00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(145, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Ejemplo de un nombre de tarea";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(145, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Ejemplo de un nombre de tarea";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(145, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "00:00:00";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(145, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(135, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "Sesión de menos duración:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 395);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStripListaTareas.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonFinalizarTarea;
        private System.Windows.Forms.Label labelShowCronometro;
        private System.Windows.Forms.Button buttonIniciarCronómetro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelInfoEventoSeleccionado;
        private System.Windows.Forms.CheckedListBox checkedListBoxEventos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxShowDescripcionItemSelec;
        private System.Windows.Forms.Label labelShowTiempoTotalIndexSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelShowTiempoCiclos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxAgregarTareaPrioridad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxAgregarTareaTitulo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAgregarTareaDescrip;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonAgregarTareaNueva;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirAplicaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMensajes;
        private System.Windows.Forms.Timer timerCronometro;
        private System.Windows.Forms.Timer TimerDecimasDeSegundo;
        private System.Windows.Forms.Label labelShowCronometroDecimasDeSegundo;
        private System.Windows.Forms.Label labelShowUltimoConteo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListaTareas;
        private System.Windows.Forms.ToolStripMenuItem cargarTareasToolStripMenuItem;
        private System.Windows.Forms.Label labelShowCiclosTotales;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelShowTiempoTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox TextBoxcomentarioSesion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem eliminarTareaToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxSaltoLinea;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
    }
}

