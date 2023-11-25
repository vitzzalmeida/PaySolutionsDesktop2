namespace PaySolutionsDesktop.Telas
{
    partial class TelaPrincipal
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
            btnFunc = new Button();
            btnHol = new Button();
            btnContrato = new Button();
            btnRel = new Button();
            btnSup = new Button();
            SuspendLayout();
            // 
            // btnFunc
            // 
            btnFunc.BackColor = SystemColors.Control;
            btnFunc.Cursor = Cursors.Hand;
            btnFunc.FlatAppearance.BorderColor = Color.Silver;
            btnFunc.FlatStyle = FlatStyle.Flat;
            btnFunc.Location = new Point(124, 49);
            btnFunc.Name = "btnFunc";
            btnFunc.Size = new Size(150, 56);
            btnFunc.TabIndex = 0;
            btnFunc.Text = "Gerenciar Funcionários";
            btnFunc.UseVisualStyleBackColor = false;
            btnFunc.Click += btnFunc_Click;
            btnFunc.Paint += btnFunc_Paint;
            // 
            // btnHol
            // 
            btnHol.BackColor = SystemColors.Control;
            btnHol.Cursor = Cursors.Hand;
            btnHol.FlatAppearance.BorderColor = Color.Silver;
            btnHol.FlatStyle = FlatStyle.Flat;
            btnHol.Location = new Point(124, 133);
            btnHol.Name = "btnHol";
            btnHol.Size = new Size(150, 56);
            btnHol.TabIndex = 1;
            btnHol.Text = "Gerar Holerite";
            btnHol.UseVisualStyleBackColor = false;
            btnHol.Click += btnHol_Click;
            btnHol.Paint += btnHol_Paint;
            // 
            // btnContrato
            // 
            btnContrato.BackColor = SystemColors.Control;
            btnContrato.Cursor = Cursors.Hand;
            btnContrato.FlatAppearance.BorderColor = Color.Silver;
            btnContrato.FlatStyle = FlatStyle.Flat;
            btnContrato.Location = new Point(124, 216);
            btnContrato.Name = "btnContrato";
            btnContrato.Size = new Size(150, 56);
            btnContrato.TabIndex = 2;
            btnContrato.Text = "Gerar Contrato";
            btnContrato.UseVisualStyleBackColor = false;
            btnContrato.Paint += btnContrato_Paint;
            // 
            // btnRel
            // 
            btnRel.BackColor = SystemColors.Control;
            btnRel.Cursor = Cursors.Hand;
            btnRel.FlatAppearance.BorderColor = Color.Silver;
            btnRel.FlatStyle = FlatStyle.Flat;
            btnRel.Location = new Point(124, 298);
            btnRel.Name = "btnRel";
            btnRel.Size = new Size(150, 56);
            btnRel.TabIndex = 3;
            btnRel.Text = "Gerar Relatório";
            btnRel.UseVisualStyleBackColor = false;
            btnRel.Paint += btnRel_Paint;
            // 
            // btnSup
            // 
            btnSup.BackColor = SystemColors.Control;
            btnSup.Cursor = Cursors.Hand;
            btnSup.FlatAppearance.BorderColor = Color.Silver;
            btnSup.FlatStyle = FlatStyle.Flat;
            btnSup.Location = new Point(124, 383);
            btnSup.Name = "btnSup";
            btnSup.Size = new Size(150, 56);
            btnSup.TabIndex = 4;
            btnSup.Text = "Suporte";
            btnSup.UseVisualStyleBackColor = false;
            btnSup.Paint += btnSup_Paint;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(932, 503);
            Controls.Add(btnSup);
            Controls.Add(btnRel);
            Controls.Add(btnContrato);
            Controls.Add(btnHol);
            Controls.Add(btnFunc);
            Name = "TelaPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pay Solutions";
            ResumeLayout(false);
        }

        #endregion

        private Button btnFunc;
        private Button btnHol;
        private Button btnContrato;
        private Button btnRel;
        private Button btnSup;
    }
}