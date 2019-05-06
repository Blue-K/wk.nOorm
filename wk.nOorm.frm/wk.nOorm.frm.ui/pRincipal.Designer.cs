namespace wk.nOorm.frm.ui
{
    partial class pRincipal
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
            this.tvwTablas = new System.Windows.Forms.TreeView();
            this.rtbConsulta = new System.Windows.Forms.RichTextBox();
            this.btnSeleccionarTodo = new System.Windows.Forms.Button();
            this.btnDeseleccionarTodo = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tvwTablas
            // 
            this.tvwTablas.CheckBoxes = true;
            this.tvwTablas.Location = new System.Drawing.Point(15, 12);
            this.tvwTablas.Name = "tvwTablas";
            this.tvwTablas.Size = new System.Drawing.Size(270, 530);
            this.tvwTablas.TabIndex = 9;
            this.tvwTablas.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwTablas_AfterSelect);
            // 
            // rtbConsulta
            // 
            this.rtbConsulta.Location = new System.Drawing.Point(292, 12);
            this.rtbConsulta.Name = "rtbConsulta";
            this.rtbConsulta.Size = new System.Drawing.Size(565, 530);
            this.rtbConsulta.TabIndex = 10;
            this.rtbConsulta.Text = "";
            // 
            // btnSeleccionarTodo
            // 
            this.btnSeleccionarTodo.Location = new System.Drawing.Point(15, 553);
            this.btnSeleccionarTodo.Name = "btnSeleccionarTodo";
            this.btnSeleccionarTodo.Size = new System.Drawing.Size(131, 20);
            this.btnSeleccionarTodo.TabIndex = 11;
            this.btnSeleccionarTodo.Text = "Seleccionar todo";
            this.btnSeleccionarTodo.UseVisualStyleBackColor = true;
            this.btnSeleccionarTodo.Click += new System.EventHandler(this.btnSeleccionarTodo_Click);
            // 
            // btnDeseleccionarTodo
            // 
            this.btnDeseleccionarTodo.Location = new System.Drawing.Point(154, 553);
            this.btnDeseleccionarTodo.Name = "btnDeseleccionarTodo";
            this.btnDeseleccionarTodo.Size = new System.Drawing.Size(131, 20);
            this.btnDeseleccionarTodo.TabIndex = 12;
            this.btnDeseleccionarTodo.Text = "Quitar selección a todo";
            this.btnDeseleccionarTodo.UseVisualStyleBackColor = true;
            this.btnDeseleccionarTodo.Click += new System.EventHandler(this.btnDeseleccionarTodo_Click);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(779, 553);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(75, 20);
            this.btnEjecutar.TabIndex = 13;
            this.btnEjecutar.Text = "Hacerlo!!!";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // pRincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 585);
            this.Controls.Add(this.btnDeseleccionarTodo);
            this.Controls.Add(this.btnSeleccionarTodo);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.rtbConsulta);
            this.Controls.Add(this.tvwTablas);
            this.Name = "pRincipal";
            this.Text = "pRincipal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.pRincipal_FormClosing);
            this.Load += new System.EventHandler(this.pRincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView tvwTablas;
        private System.Windows.Forms.RichTextBox rtbConsulta;
        private System.Windows.Forms.Button btnSeleccionarTodo;
        private System.Windows.Forms.Button btnDeseleccionarTodo;
        private System.Windows.Forms.Button btnEjecutar;
    }
}