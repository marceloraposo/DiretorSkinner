namespace DiretorSkinner.Servico
{
    partial class FormIniciar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIniciar));
            this.bntIniciar = new System.Windows.Forms.Button();
            this.btnParar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bntIniciar
            // 
            this.bntIniciar.Location = new System.Drawing.Point(53, 50);
            this.bntIniciar.Name = "bntIniciar";
            this.bntIniciar.Size = new System.Drawing.Size(158, 50);
            this.bntIniciar.TabIndex = 0;
            this.bntIniciar.Text = "Iniciar";
            this.bntIniciar.UseVisualStyleBackColor = true;
            this.bntIniciar.Click += new System.EventHandler(this.bntIniciar_Click);
            // 
            // btnParar
            // 
            this.btnParar.Location = new System.Drawing.Point(53, 140);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(158, 50);
            this.btnParar.TabIndex = 1;
            this.btnParar.Text = "Parar";
            this.btnParar.UseVisualStyleBackColor = true;
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // FormIniciar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnParar);
            this.Controls.Add(this.bntIniciar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormIniciar";
            this.Text = "Serviço DiretorSkinner";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bntIniciar;
        private System.Windows.Forms.Button btnParar;
    }
}