namespace PruebaTecnica.Formularios
{
    partial class frmIniciarSesion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblContra = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.rbComercio = new System.Windows.Forms.RadioButton();
            this.rbPagador = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblContra);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.btnIniciar);
            this.panel1.Controls.Add(this.btnRegistrar);
            this.panel1.Controls.Add(this.txtContra);
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Controls.Add(this.rbComercio);
            this.panel1.Controls.Add(this.rbPagador);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // lblContra
            // 
            this.lblContra.AutoSize = true;
            this.lblContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContra.Location = new System.Drawing.Point(242, 139);
            this.lblContra.Name = "lblContra";
            this.lblContra.Size = new System.Drawing.Size(71, 13);
            this.lblContra.TabIndex = 7;
            this.lblContra.Text = "Contraseña";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(242, 102);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(41, 13);
            this.lblUser.TabIndex = 6;
            this.lblUser.Text = "label1";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.Location = new System.Drawing.Point(323, 171);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(164, 37);
            this.btnIniciar.TabIndex = 5;
            this.btnIniciar.Text = "Iniciar sesión";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(323, 229);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(164, 37);
            this.btnRegistrar.TabIndex = 4;
            this.btnRegistrar.Text = "Registrarse";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // txtContra
            // 
            this.txtContra.Location = new System.Drawing.Point(330, 132);
            this.txtContra.Name = "txtContra";
            this.txtContra.PasswordChar = '*';
            this.txtContra.Size = new System.Drawing.Size(133, 20);
            this.txtContra.TabIndex = 2;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(330, 95);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(133, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // rbComercio
            // 
            this.rbComercio.AutoSize = true;
            this.rbComercio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbComercio.Location = new System.Drawing.Point(410, 43);
            this.rbComercio.Name = "rbComercio";
            this.rbComercio.Size = new System.Drawing.Size(77, 17);
            this.rbComercio.TabIndex = 13;
            this.rbComercio.TabStop = true;
            this.rbComercio.Text = "Comercio";
            this.rbComercio.UseVisualStyleBackColor = true;
            this.rbComercio.CheckedChanged += new System.EventHandler(this.rbComercio_CheckedChanged);
            // 
            // rbPagador
            // 
            this.rbPagador.AutoSize = true;
            this.rbPagador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPagador.Location = new System.Drawing.Point(277, 43);
            this.rbPagador.Name = "rbPagador";
            this.rbPagador.Size = new System.Drawing.Size(72, 17);
            this.rbPagador.TabIndex = 22;
            this.rbPagador.TabStop = true;
            this.rbPagador.Text = "Pagador";
            this.rbPagador.UseVisualStyleBackColor = true;
            this.rbPagador.CheckedChanged += new System.EventHandler(this.rbPagador_CheckedChanged);
            // 
            // frmIniciarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIniciarSesion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.Load += new System.EventHandler(this.frmIniciarSesion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.RadioButton rbComercio;
        private System.Windows.Forms.RadioButton rbPagador;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblContra;
    }
}