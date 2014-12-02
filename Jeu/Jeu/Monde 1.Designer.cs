namespace Jeu
{
    partial class Monde_1
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
            this.pbPerso = new System.Windows.Forms.PictureBox();
            this.BarreVie = new System.Windows.Forms.ProgressBar();
            this.btnContinue = new System.Windows.Forms.Button();
            this.LbMechant = new System.Windows.Forms.Label();
            this.pbMechant = new System.Windows.Forms.PictureBox();
            this.btnAttack = new System.Windows.Forms.Button();
            this.pbArme1 = new System.Windows.Forms.PictureBox();
            this.BarreVieMechant = new System.Windows.Forms.ProgressBar();
            this.lbActionMechant = new System.Windows.Forms.Label();
            this.LbVieMechant = new System.Windows.Forms.Label();
            this.lbViePerso = new System.Windows.Forms.Label();
            this.lbDomMechant = new System.Windows.Forms.Label();
            this.lbDomPerso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMechant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArme1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPerso
            // 
            this.pbPerso.Location = new System.Drawing.Point(256, 54);
            this.pbPerso.Name = "pbPerso";
            this.pbPerso.Size = new System.Drawing.Size(236, 191);
            this.pbPerso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPerso.TabIndex = 0;
            this.pbPerso.TabStop = false;
            // 
            // BarreVie
            // 
            this.BarreVie.Location = new System.Drawing.Point(325, 265);
            this.BarreVie.Name = "BarreVie";
            this.BarreVie.Size = new System.Drawing.Size(100, 23);
            this.BarreVie.TabIndex = 2;
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(19, 328);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(219, 23);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "Continuer en affrontant un autre monstre";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // LbMechant
            // 
            this.LbMechant.AutoSize = true;
            this.LbMechant.Font = new System.Drawing.Font("Mistral", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.LbMechant.Location = new System.Drawing.Point(12, 9);
            this.LbMechant.Name = "LbMechant";
            this.LbMechant.Size = new System.Drawing.Size(90, 42);
            this.LbMechant.TabIndex = 4;
            this.LbMechant.Text = "label1";
            // 
            // pbMechant
            // 
            this.pbMechant.Location = new System.Drawing.Point(12, 54);
            this.pbMechant.Name = "pbMechant";
            this.pbMechant.Size = new System.Drawing.Size(236, 191);
            this.pbMechant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMechant.TabIndex = 5;
            this.pbMechant.TabStop = false;
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(256, 328);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(71, 23);
            this.btnAttack.TabIndex = 6;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // pbArme1
            // 
            this.pbArme1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbArme1.Location = new System.Drawing.Point(412, 27);
            this.pbArme1.Name = "pbArme1";
            this.pbArme1.Size = new System.Drawing.Size(24, 21);
            this.pbArme1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbArme1.TabIndex = 7;
            this.pbArme1.TabStop = false;
            this.pbArme1.Click += new System.EventHandler(this.pbArme1_Click);
            this.pbArme1.MouseEnter += new System.EventHandler(this.pbArme1_MouseEnter);
            this.pbArme1.MouseLeave += new System.EventHandler(this.pbArme1_MouseLeave);
            // 
            // BarreVieMechant
            // 
            this.BarreVieMechant.Location = new System.Drawing.Point(59, 265);
            this.BarreVieMechant.Name = "BarreVieMechant";
            this.BarreVieMechant.Size = new System.Drawing.Size(100, 23);
            this.BarreVieMechant.TabIndex = 8;
            // 
            // lbActionMechant
            // 
            this.lbActionMechant.AutoSize = true;
            this.lbActionMechant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbActionMechant.Location = new System.Drawing.Point(166, 34);
            this.lbActionMechant.Name = "lbActionMechant";
            this.lbActionMechant.Size = new System.Drawing.Size(43, 13);
            this.lbActionMechant.TabIndex = 9;
            this.lbActionMechant.Text = "Action";
            this.lbActionMechant.Visible = false;
            // 
            // LbVieMechant
            // 
            this.LbVieMechant.AutoSize = true;
            this.LbVieMechant.ForeColor = System.Drawing.Color.ForestGreen;
            this.LbVieMechant.Location = new System.Drawing.Point(165, 275);
            this.LbVieMechant.Name = "LbVieMechant";
            this.LbVieMechant.Size = new System.Drawing.Size(35, 13);
            this.LbVieMechant.TabIndex = 10;
            this.LbVieMechant.Text = "label1";
            // 
            // lbViePerso
            // 
            this.lbViePerso.AutoSize = true;
            this.lbViePerso.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbViePerso.Location = new System.Drawing.Point(431, 275);
            this.lbViePerso.Name = "lbViePerso";
            this.lbViePerso.Size = new System.Drawing.Size(35, 13);
            this.lbViePerso.TabIndex = 11;
            this.lbViePerso.Text = "label1";
            // 
            // lbDomMechant
            // 
            this.lbDomMechant.AutoSize = true;
            this.lbDomMechant.ForeColor = System.Drawing.Color.Firebrick;
            this.lbDomMechant.Location = new System.Drawing.Point(84, 291);
            this.lbDomMechant.Name = "lbDomMechant";
            this.lbDomMechant.Size = new System.Drawing.Size(55, 13);
            this.lbDomMechant.TabIndex = 12;
            this.lbDomMechant.Text = "Dommage";
            // 
            // lbDomPerso
            // 
            this.lbDomPerso.AutoSize = true;
            this.lbDomPerso.ForeColor = System.Drawing.Color.Firebrick;
            this.lbDomPerso.Location = new System.Drawing.Point(352, 291);
            this.lbDomPerso.Name = "lbDomPerso";
            this.lbDomPerso.Size = new System.Drawing.Size(55, 13);
            this.lbDomPerso.TabIndex = 13;
            this.lbDomPerso.Text = "Dommage";
            // 
            // Monde_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(573, 382);
            this.Controls.Add(this.lbDomPerso);
            this.Controls.Add(this.lbDomMechant);
            this.Controls.Add(this.lbViePerso);
            this.Controls.Add(this.LbVieMechant);
            this.Controls.Add(this.lbActionMechant);
            this.Controls.Add(this.BarreVieMechant);
            this.Controls.Add(this.pbArme1);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.pbMechant);
            this.Controls.Add(this.LbMechant);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.BarreVie);
            this.Controls.Add(this.pbPerso);
            this.Name = "Monde_1";
            this.Text = "Monde_1";
            ((System.ComponentModel.ISupportInitialize)(this.pbPerso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMechant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArme1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPerso;
        private System.Windows.Forms.ProgressBar BarreVie;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label LbMechant;
        private System.Windows.Forms.PictureBox pbMechant;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.PictureBox pbArme1;
        private System.Windows.Forms.ProgressBar BarreVieMechant;
        private System.Windows.Forms.Label lbActionMechant;
        private System.Windows.Forms.Label LbVieMechant;
        private System.Windows.Forms.Label lbViePerso;
        private System.Windows.Forms.Label lbDomMechant;
        private System.Windows.Forms.Label lbDomPerso;
    }
}