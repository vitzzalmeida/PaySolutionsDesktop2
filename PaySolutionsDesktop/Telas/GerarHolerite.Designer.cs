namespace PaySolutionsDesktop.Telas
{
    partial class GerarHolerite
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
            label3 = new Label();
            comboBox1 = new ComboBox();
            btnGerHol = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(316, 158);
            label3.Name = "label3";
            label3.Size = new Size(186, 21);
            label3.TabIndex = 27;
            label3.Text = "Nome do Funcionário:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(244, 192);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(329, 28);
            comboBox1.TabIndex = 28;
            // 
            // btnGerHol
            // 
            btnGerHol.BackColor = SystemColors.Control;
            btnGerHol.Cursor = Cursors.Hand;
            btnGerHol.FlatAppearance.BorderColor = Color.Silver;
            btnGerHol.FlatStyle = FlatStyle.Flat;
            btnGerHol.Location = new Point(631, 373);
            btnGerHol.Name = "btnGerHol";
            btnGerHol.Size = new Size(137, 46);
            btnGerHol.TabIndex = 29;
            btnGerHol.Text = "Gerar Holerite";
            btnGerHol.UseVisualStyleBackColor = false;
            btnGerHol.Click += btnGerHol_Click;
            btnGerHol.Paint += btnGerHol_Paint;
            // 
            // GerarHolerite
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGerHol);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            ForeColor = SystemColors.ControlText;
            Name = "GerarHolerite";
            Text = "GerarHolerite";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private ComboBox comboBox1;
        private Button btnGerHol;
    }
}