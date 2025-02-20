namespace AppRegistroMultas
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btConsulta = new System.Windows.Forms.Button();
            this.btCadastroMulta = new System.Windows.Forms.Button();
            this.btCadastroVeiculo = new System.Windows.Forms.Button();
            this.AtualizarMultas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btConsulta
            // 
            this.btConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConsulta.Location = new System.Drawing.Point(34, 128);
            this.btConsulta.Name = "btConsulta";
            this.btConsulta.Size = new System.Drawing.Size(471, 29);
            this.btConsulta.TabIndex = 32;
            this.btConsulta.Text = "CONSULTA DE MULTAS";
            this.btConsulta.UseVisualStyleBackColor = true;
            this.btConsulta.Click += new System.EventHandler(this.btConsulta_Click);
            // 
            // btCadastroMulta
            // 
            this.btCadastroMulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCadastroMulta.Location = new System.Drawing.Point(34, 85);
            this.btCadastroMulta.Name = "btCadastroMulta";
            this.btCadastroMulta.Size = new System.Drawing.Size(471, 29);
            this.btCadastroMulta.TabIndex = 31;
            this.btCadastroMulta.Text = "CADASTRO DE MULTAS";
            this.btCadastroMulta.UseVisualStyleBackColor = true;
            this.btCadastroMulta.Click += new System.EventHandler(this.btCadastroMulta_Click);
            // 
            // btCadastroVeiculo
            // 
            this.btCadastroVeiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCadastroVeiculo.Location = new System.Drawing.Point(34, 39);
            this.btCadastroVeiculo.Name = "btCadastroVeiculo";
            this.btCadastroVeiculo.Size = new System.Drawing.Size(471, 29);
            this.btCadastroVeiculo.TabIndex = 30;
            this.btCadastroVeiculo.Text = "CADASTRAR VEÍCULOS";
            this.btCadastroVeiculo.UseVisualStyleBackColor = true;
            this.btCadastroVeiculo.Click += new System.EventHandler(this.btCadastroVeiculo_Click);
            // 
            // AtualizarMultas
            // 
            this.AtualizarMultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AtualizarMultas.Location = new System.Drawing.Point(34, 163);
            this.AtualizarMultas.Name = "AtualizarMultas";
            this.AtualizarMultas.Size = new System.Drawing.Size(471, 29);
            this.AtualizarMultas.TabIndex = 33;
            this.AtualizarMultas.Text = "ATUALIZAR  MULTAS";
            this.AtualizarMultas.UseVisualStyleBackColor = true;
            this.AtualizarMultas.Click += new System.EventHandler(this.AtualizarMultas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 204);
            this.Controls.Add(this.AtualizarMultas);
            this.Controls.Add(this.btConsulta);
            this.Controls.Add(this.btCadastroMulta);
            this.Controls.Add(this.btCadastroVeiculo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btConsulta;
        private System.Windows.Forms.Button btCadastroMulta;
        private System.Windows.Forms.Button btCadastroVeiculo;
        private System.Windows.Forms.Button AtualizarMultas;
    }
}

