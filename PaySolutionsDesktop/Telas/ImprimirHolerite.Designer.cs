namespace PaySolutionsDesktop.Telas
{
    partial class ImprimirHolerite
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
            btnImpHol = new Button();
            SuspendLayout();
            // 
            // btnImpHol
            // 
            btnImpHol.BackColor = SystemColors.Control;
            btnImpHol.Cursor = Cursors.Hand;
            btnImpHol.FlatAppearance.BorderColor = Color.Silver;
            btnImpHol.FlatStyle = FlatStyle.Flat;
            btnImpHol.Location = new Point(631, 373);
            btnImpHol.Name = "btnImpHol";
            btnImpHol.Size = new Size(137, 46);
            btnImpHol.TabIndex = 30;
            btnImpHol.Text = "Imprimir Holerite";
            btnImpHol.UseVisualStyleBackColor = false;
            btnImpHol.Paint += btnImpHol_Paint;
            // 
            // ImprimirHolerite
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(800, 450);
            Controls.Add(btnImpHol);
            Name = "ImprimirHolerite";
            Text = "ImprimirHolerite";
            ResumeLayout(false);
        }

        #endregion

        private Button btnImpHol;
    }
}