namespace PaySolutionsDesktop.Telas
{
    partial class GerenciarFuncionario
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
            txtBuscar = new TextBox();
            lvlFunc = new ListView();
            clhId = new ColumnHeader();
            clhNome = new ColumnHeader();
            clhCpf = new ColumnHeader();
            btnAddFunc = new Button();
            btnConsFunc = new Button();
            btnEditFunc = new Button();
            btnDelFunc = new Button();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(285, 61);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(380, 27);
            txtBuscar.TabIndex = 0;
            txtBuscar.Text = "buscar funcionário";
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lvlFunc
            // 
            lvlFunc.Columns.AddRange(new ColumnHeader[] { clhId, clhNome, clhCpf });
            lvlFunc.Location = new Point(92, 115);
            lvlFunc.Name = "lvlFunc";
            lvlFunc.Size = new Size(765, 279);
            lvlFunc.TabIndex = 1;
            lvlFunc.UseCompatibleStateImageBehavior = false;
            lvlFunc.View = View.Details;
            // 
            // clhId
            // 
            clhId.Text = "ID";
            // 
            // clhNome
            // 
            clhNome.Text = "Nome";
            clhNome.Width = 450;
            // 
            // clhCpf
            // 
            clhCpf.Text = "CPF";
            clhCpf.Width = 250;
            // 
            // btnAddFunc
            // 
            btnAddFunc.BackColor = SystemColors.Control;
            btnAddFunc.Cursor = Cursors.Hand;
            btnAddFunc.FlatAppearance.BorderColor = Color.Silver;
            btnAddFunc.FlatStyle = FlatStyle.Flat;
            btnAddFunc.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddFunc.Location = new Point(92, 426);
            btnAddFunc.Name = "btnAddFunc";
            btnAddFunc.Size = new Size(170, 43);
            btnAddFunc.TabIndex = 2;
            btnAddFunc.Text = "Add Funcionário";
            btnAddFunc.UseVisualStyleBackColor = false;
            btnAddFunc.Click += btnAddFunc_Click;
            // 
            // btnConsFunc
            // 
            btnConsFunc.BackColor = SystemColors.Control;
            btnConsFunc.Cursor = Cursors.Hand;
            btnConsFunc.FlatAppearance.BorderColor = Color.Silver;
            btnConsFunc.FlatStyle = FlatStyle.Flat;
            btnConsFunc.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnConsFunc.Location = new Point(293, 426);
            btnConsFunc.Name = "btnConsFunc";
            btnConsFunc.Size = new Size(170, 43);
            btnConsFunc.TabIndex = 3;
            btnConsFunc.Text = "Consultar Funcionário";
            btnConsFunc.UseVisualStyleBackColor = false;
            btnConsFunc.Click += btnConsFunc_Click;
            btnConsFunc.Paint += btnConsFunc_Paint;
            // 
            // btnEditFunc
            // 
            btnEditFunc.BackColor = SystemColors.Control;
            btnEditFunc.Cursor = Cursors.Hand;
            btnEditFunc.FlatAppearance.BorderColor = Color.Silver;
            btnEditFunc.FlatStyle = FlatStyle.Flat;
            btnEditFunc.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditFunc.Location = new Point(490, 426);
            btnEditFunc.Name = "btnEditFunc";
            btnEditFunc.Size = new Size(170, 43);
            btnEditFunc.TabIndex = 4;
            btnEditFunc.Text = "Editar Funcionário";
            btnEditFunc.UseVisualStyleBackColor = false;
            btnEditFunc.Click += btnEditFunc_Click;
            btnEditFunc.Paint += btnEditFunc_Paint;
            // 
            // btnDelFunc
            // 
            btnDelFunc.BackColor = SystemColors.Control;
            btnDelFunc.Cursor = Cursors.Hand;
            btnDelFunc.FlatAppearance.BorderColor = Color.Silver;
            btnDelFunc.FlatStyle = FlatStyle.Flat;
            btnDelFunc.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelFunc.Location = new Point(687, 426);
            btnDelFunc.Name = "btnDelFunc";
            btnDelFunc.Size = new Size(170, 43);
            btnDelFunc.TabIndex = 5;
            btnDelFunc.Text = "Remover Funcionário";
            btnDelFunc.UseVisualStyleBackColor = false;
            btnDelFunc.Click += btnDelFunc_Click;
            btnDelFunc.Paint += btnDelFunc_Paint;
            // 
            // GerenciarFuncionario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(932, 503);
            Controls.Add(btnDelFunc);
            Controls.Add(btnEditFunc);
            Controls.Add(btnConsFunc);
            Controls.Add(btnAddFunc);
            Controls.Add(lvlFunc);
            Controls.Add(txtBuscar);
            Name = "GerenciarFuncionario";
            Text = "GerenciarFuncionario";
            Load += GerenciarFuncionario_Load;
            Paint += GerenciarFuncionario_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBuscar;
        private ListView lvlFunc;
        private ColumnHeader clhNome;
        private ColumnHeader clhCpf;
        private Button btnAddFunc;
        private Button btnConsFunc;
        private Button btnEditFunc;
        private Button btnDelFunc;
        private ColumnHeader clhId;
    }
}