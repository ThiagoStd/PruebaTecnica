namespace PruebaTecnica.Formularios
{
    partial class frmComercioPago
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
            this.dgvTrans = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblnit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbldireccion = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.cbMetodo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrans)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTrans
            // 
            this.dgvTrans.AllowUserToAddRows = false;
            this.dgvTrans.AllowUserToDeleteRows = false;
            this.dgvTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrans.Location = new System.Drawing.Point(12, 225);
            this.dgvTrans.MultiSelect = false;
            this.dgvTrans.Name = "dgvTrans";
            this.dgvTrans.ReadOnly = true;
            this.dgvTrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrans.Size = new System.Drawing.Size(881, 180);
            this.dgvTrans.TabIndex = 0;
            this.dgvTrans.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrans_RowEnter);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTitulo.Location = new System.Drawing.Point(131, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(112, 18);
            this.lblTitulo.TabIndex = 62;
            this.lblTitulo.Text = "Nombre Comer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(33, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 63;
            this.label2.Text = "Comercio: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(33, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 18);
            this.label3.TabIndex = 65;
            this.label3.Text = "NIT:";
            // 
            // lblnit
            // 
            this.lblnit.AutoSize = true;
            this.lblnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblnit.Location = new System.Drawing.Point(131, 61);
            this.lblnit.Name = "lblnit";
            this.lblnit.Size = new System.Drawing.Size(73, 18);
            this.lblnit.TabIndex = 64;
            this.lblnit.Text = "Nit comer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(285, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 18);
            this.label5.TabIndex = 67;
            this.label5.Text = "Dirección:";
            // 
            // lbldireccion
            // 
            this.lbldireccion.AutoSize = true;
            this.lbldireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldireccion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbldireccion.Location = new System.Drawing.Point(376, 61);
            this.lbldireccion.Name = "lbldireccion";
            this.lbldireccion.Size = new System.Drawing.Size(110, 18);
            this.lbldireccion.TabIndex = 66;
            this.lbldireccion.Text = "Direcion comer";
            // 
            // txtValor
            // 
            this.txtValor.Enabled = false;
            this.txtValor.Location = new System.Drawing.Point(134, 168);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(134, 20);
            this.txtValor.TabIndex = 68;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(33, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 69;
            this.label1.Text = "Valor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(438, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 70;
            this.label4.Text = "Estado:";
            // 
            // cbEstado
            // 
            this.cbEstado.Enabled = false;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(558, 93);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(133, 21);
            this.cbEstado.TabIndex = 72;
            // 
            // cbMetodo
            // 
            this.cbMetodo.Enabled = false;
            this.cbMetodo.FormattingEnabled = true;
            this.cbMetodo.Location = new System.Drawing.Point(558, 130);
            this.cbMetodo.Name = "cbMetodo";
            this.cbMetodo.Size = new System.Drawing.Size(133, 21);
            this.cbMetodo.TabIndex = 71;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(438, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 18);
            this.label6.TabIndex = 73;
            this.label6.Text = "Metodo Pago:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(33, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 18);
            this.label7.TabIndex = 75;
            this.label7.Text = "Usuario:";
            // 
            // cbUsuario
            // 
            this.cbUsuario.Enabled = false;
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(134, 89);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(265, 21);
            this.cbUsuario.TabIndex = 74;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnActualizar.Location = new System.Drawing.Point(419, 168);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(182, 35);
            this.btnActualizar.TabIndex = 76;
            this.btnActualizar.Text = "Actualizar Pago";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(33, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 18);
            this.label8.TabIndex = 78;
            this.label8.Text = "Concepto:";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Enabled = false;
            this.txtConcepto.Location = new System.Drawing.Point(134, 129);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(265, 20);
            this.txtConcepto.TabIndex = 77;
            // 
            // frmComercioPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbUsuario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.cbMetodo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbldireccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblnit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.dgvTrans);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmComercioPago";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comercios Pagos";
            this.Load += new System.EventHandler(this.frmComercioPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTrans;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbldireccion;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.ComboBox cbMetodo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtConcepto;
    }
}