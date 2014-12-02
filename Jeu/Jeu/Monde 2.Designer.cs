namespace Jeu
{
    partial class Monde_2
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
            this.lbMechant = new System.Windows.Forms.Label();
            this.pbMechant = new System.Windows.Forms.PictureBox();
            this.btnAttack = new System.Windows.Forms.Button();
            this.pbArme1 = new System.Windows.Forms.PictureBox();
            this.BarreVieMechant = new System.Windows.Forms.ProgressBar();
            this.lbActionMechant = new System.Windows.Forms.Label();
            this.lbVieMechant = new System.Windows.Forms.Label();
            this.lbViePerso = new System.Windows.Forms.Label();
            this.lbDomMechant = new System.Windows.Forms.Label();
            this.lbDomPerso = new System.Windows.Forms.Label();
            this.lbArgent = new System.Windows.Forms.Label();
            this.Argent = new System.Windows.Forms.Label();
            this.cbRetour = new System.Windows.Forms.ComboBox();
            this.pbArme2 = new System.Windows.Forms.PictureBox();
            this.pbArme4 = new System.Windows.Forms.PictureBox();
            this.pbArme3 = new System.Windows.Forms.PictureBox();
            this.pbArme5 = new System.Windows.Forms.PictureBox();
            this.lbBoss = new System.Windows.Forms.Label();
            this.lbVieMechant2 = new System.Windows.Forms.Label();
            this.lbActionMechant2 = new System.Windows.Forms.Label();
            this.BarreVieMechant2 = new System.Windows.Forms.ProgressBar();
            this.pbMechant2 = new System.Windows.Forms.PictureBox();
            this.lbMechant2 = new System.Windows.Forms.Label();
            this.lbDomMechant2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPerso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMechant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArme1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArme2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArme4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArme3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArme5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMechant2)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPerso
            // 
            this.pbPerso.Location = new System.Drawing.Point(506, 136);
            this.pbPerso.Name = "pbPerso";
            this.pbPerso.Size = new System.Drawing.Size(236, 191);
            this.pbPerso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPerso.TabIndex = 0;
            this.pbPerso.TabStop = false;
            // 
            // BarreVie
            // 
            this.BarreVie.Location = new System.Drawing.Point(601, 333);
            this.BarreVie.Name = "BarreVie";
            this.BarreVie.Size = new System.Drawing.Size(100, 23);
            this.BarreVie.TabIndex = 2;
            // 
            // btnContinue
            // 
            this.btnContinue.Enabled = false;
            this.btnContinue.Location = new System.Drawing.Point(523, 392);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(219, 23);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "Continuer en affrontant un autre monstre";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lbMechant
            // 
            this.lbMechant.AutoSize = true;
            this.lbMechant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbMechant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbMechant.Font = new System.Drawing.Font("Mistral", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbMechant.ForeColor = System.Drawing.Color.White;
            this.lbMechant.Location = new System.Drawing.Point(42, 9);
            this.lbMechant.Name = "lbMechant";
            this.lbMechant.Size = new System.Drawing.Size(92, 44);
            this.lbMechant.TabIndex = 4;
            this.lbMechant.Text = "label1";
            // 
            // pbMechant
            // 
            this.pbMechant.BackColor = System.Drawing.Color.DarkRed;
            this.pbMechant.Location = new System.Drawing.Point(12, 54);
            this.pbMechant.Name = "pbMechant";
            this.pbMechant.Size = new System.Drawing.Size(178, 158);
            this.pbMechant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMechant.TabIndex = 5;
            this.pbMechant.TabStop = false;
            this.pbMechant.Click += new System.EventHandler(this.pbMechant_Click);
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(506, 333);
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
            this.pbArme1.Location = new System.Drawing.Point(506, 109);
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
            this.BarreVieMechant.Location = new System.Drawing.Point(49, 218);
            this.BarreVieMechant.Name = "BarreVieMechant";
            this.BarreVieMechant.Size = new System.Drawing.Size(100, 23);
            this.BarreVieMechant.TabIndex = 8;
            // 
            // lbActionMechant
            // 
            this.lbActionMechant.AutoSize = true;
            this.lbActionMechant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbActionMechant.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbActionMechant.Location = new System.Drawing.Point(219, 156);
            this.lbActionMechant.Name = "lbActionMechant";
            this.lbActionMechant.Size = new System.Drawing.Size(43, 13);
            this.lbActionMechant.TabIndex = 9;
            this.lbActionMechant.Text = "Action";
            this.lbActionMechant.Visible = false;
            // 
            // lbVieMechant
            // 
            this.lbVieMechant.AutoSize = true;
            this.lbVieMechant.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbVieMechant.Location = new System.Drawing.Point(155, 228);
            this.lbVieMechant.Name = "lbVieMechant";
            this.lbVieMechant.Size = new System.Drawing.Size(35, 13);
            this.lbVieMechant.TabIndex = 10;
            this.lbVieMechant.Text = "label1";
            // 
            // lbViePerso
            // 
            this.lbViePerso.AutoSize = true;
            this.lbViePerso.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbViePerso.Location = new System.Drawing.Point(707, 343);
            this.lbViePerso.Name = "lbViePerso";
            this.lbViePerso.Size = new System.Drawing.Size(35, 13);
            this.lbViePerso.TabIndex = 11;
            this.lbViePerso.Text = "label1";
            // 
            // lbDomMechant
            // 
            this.lbDomMechant.AutoSize = true;
            this.lbDomMechant.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbDomMechant.Location = new System.Drawing.Point(75, 244);
            this.lbDomMechant.Name = "lbDomMechant";
            this.lbDomMechant.Size = new System.Drawing.Size(55, 13);
            this.lbDomMechant.TabIndex = 12;
            this.lbDomMechant.Text = "Dommage";
            // 
            // lbDomPerso
            // 
            this.lbDomPerso.AutoSize = true;
            this.lbDomPerso.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbDomPerso.Location = new System.Drawing.Point(629, 359);
            this.lbDomPerso.Name = "lbDomPerso";
            this.lbDomPerso.Size = new System.Drawing.Size(55, 13);
            this.lbDomPerso.TabIndex = 13;
            this.lbDomPerso.Text = "Dommage";
            // 
            // lbArgent
            // 
            this.lbArgent.BackColor = System.Drawing.Color.Peru;
            this.lbArgent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbArgent.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArgent.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbArgent.Location = new System.Drawing.Point(649, 29);
            this.lbArgent.Name = "lbArgent";
            this.lbArgent.Size = new System.Drawing.Size(93, 23);
            this.lbArgent.TabIndex = 17;
            this.lbArgent.Text = "label1";
            this.lbArgent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Argent
            // 
            this.Argent.BackColor = System.Drawing.Color.Peru;
            this.Argent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Argent.Font = new System.Drawing.Font("Papyrus", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Argent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Argent.Location = new System.Drawing.Point(649, 9);
            this.Argent.Name = "Argent";
            this.Argent.Size = new System.Drawing.Size(93, 20);
            this.Argent.TabIndex = 16;
            this.Argent.Text = "ARGENT";
            // 
            // cbRetour
            // 
            this.cbRetour.Font = new System.Drawing.Font("Papyrus", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRetour.FormattingEnabled = true;
            this.cbRetour.Items.AddRange(new object[] {
            "UNIVERS",
            "MENU"});
            this.cbRetour.Location = new System.Drawing.Point(649, 54);
            this.cbRetour.Name = "cbRetour";
            this.cbRetour.Size = new System.Drawing.Size(93, 26);
            this.cbRetour.TabIndex = 18;
            this.cbRetour.Text = "RETOUR";
            this.cbRetour.SelectedIndexChanged += new System.EventHandler(this.cbRetour_SelectedIndexChanged);
            // 
            // pbArme2
            // 
            this.pbArme2.Location = new System.Drawing.Point(536, 109);
            this.pbArme2.Name = "pbArme2";
            this.pbArme2.Size = new System.Drawing.Size(24, 21);
            this.pbArme2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbArme2.TabIndex = 19;
            this.pbArme2.TabStop = false;
            this.pbArme2.Click += new System.EventHandler(this.pbArme2_Click);
            this.pbArme2.MouseEnter += new System.EventHandler(this.pbArme2_MouseEnter);
            this.pbArme2.MouseLeave += new System.EventHandler(this.pbArme2_MouseLeave);
            // 
            // pbArme4
            // 
            this.pbArme4.Location = new System.Drawing.Point(593, 109);
            this.pbArme4.Name = "pbArme4";
            this.pbArme4.Size = new System.Drawing.Size(24, 21);
            this.pbArme4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbArme4.TabIndex = 20;
            this.pbArme4.TabStop = false;
            this.pbArme4.Click += new System.EventHandler(this.pbArme4_Click);
            this.pbArme4.MouseEnter += new System.EventHandler(this.pbArme4_MouseEnter);
            this.pbArme4.MouseLeave += new System.EventHandler(this.pbArme4_MouseLeave);
            // 
            // pbArme3
            // 
            this.pbArme3.Location = new System.Drawing.Point(563, 109);
            this.pbArme3.Name = "pbArme3";
            this.pbArme3.Size = new System.Drawing.Size(24, 21);
            this.pbArme3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbArme3.TabIndex = 21;
            this.pbArme3.TabStop = false;
            this.pbArme3.Click += new System.EventHandler(this.pbArme3_Click);
            this.pbArme3.MouseEnter += new System.EventHandler(this.pbArme3_MouseEnter);
            this.pbArme3.MouseLeave += new System.EventHandler(this.pbArme3_MouseLeave);
            // 
            // pbArme5
            // 
            this.pbArme5.Location = new System.Drawing.Point(623, 109);
            this.pbArme5.Name = "pbArme5";
            this.pbArme5.Size = new System.Drawing.Size(24, 21);
            this.pbArme5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbArme5.TabIndex = 22;
            this.pbArme5.TabStop = false;
            this.pbArme5.Click += new System.EventHandler(this.pbArme5_Click);
            this.pbArme5.MouseEnter += new System.EventHandler(this.pbArme5_MouseEnter);
            this.pbArme5.MouseLeave += new System.EventHandler(this.pbArme5_MouseLeave);
            // 
            // lbBoss
            // 
            this.lbBoss.AutoSize = true;
            this.lbBoss.Location = new System.Drawing.Point(587, 109);
            this.lbBoss.Name = "lbBoss";
            this.lbBoss.Size = new System.Drawing.Size(0, 13);
            this.lbBoss.TabIndex = 23;
            // 
            // lbVieMechant2
            // 
            this.lbVieMechant2.AutoSize = true;
            this.lbVieMechant2.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbVieMechant2.Location = new System.Drawing.Point(155, 517);
            this.lbVieMechant2.Name = "lbVieMechant2";
            this.lbVieMechant2.Size = new System.Drawing.Size(35, 13);
            this.lbVieMechant2.TabIndex = 28;
            this.lbVieMechant2.Text = "label1";
            // 
            // lbActionMechant2
            // 
            this.lbActionMechant2.AutoSize = true;
            this.lbActionMechant2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbActionMechant2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbActionMechant2.Location = new System.Drawing.Point(219, 445);
            this.lbActionMechant2.Name = "lbActionMechant2";
            this.lbActionMechant2.Size = new System.Drawing.Size(43, 13);
            this.lbActionMechant2.TabIndex = 27;
            this.lbActionMechant2.Text = "Action";
            this.lbActionMechant2.Visible = false;
            // 
            // BarreVieMechant2
            // 
            this.BarreVieMechant2.Location = new System.Drawing.Point(49, 507);
            this.BarreVieMechant2.Name = "BarreVieMechant2";
            this.BarreVieMechant2.Size = new System.Drawing.Size(100, 23);
            this.BarreVieMechant2.TabIndex = 26;
            // 
            // pbMechant2
            // 
            this.pbMechant2.Location = new System.Drawing.Point(12, 343);
            this.pbMechant2.Name = "pbMechant2";
            this.pbMechant2.Size = new System.Drawing.Size(178, 158);
            this.pbMechant2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMechant2.TabIndex = 25;
            this.pbMechant2.TabStop = false;
            this.pbMechant2.Click += new System.EventHandler(this.pbMechant2_Click);
            // 
            // lbMechant2
            // 
            this.lbMechant2.AutoSize = true;
            this.lbMechant2.Font = new System.Drawing.Font("Mistral", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbMechant2.ForeColor = System.Drawing.Color.Cyan;
            this.lbMechant2.Location = new System.Drawing.Point(59, 298);
            this.lbMechant2.Name = "lbMechant2";
            this.lbMechant2.Size = new System.Drawing.Size(90, 42);
            this.lbMechant2.TabIndex = 24;
            this.lbMechant2.Text = "label1";
            // 
            // lbDomMechant2
            // 
            this.lbDomMechant2.AutoSize = true;
            this.lbDomMechant2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbDomMechant2.Location = new System.Drawing.Point(77, 533);
            this.lbDomMechant2.Name = "lbDomMechant2";
            this.lbDomMechant2.Size = new System.Drawing.Size(55, 13);
            this.lbDomMechant2.TabIndex = 29;
            this.lbDomMechant2.Text = "Dommage";
            // 
            // Monde_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(754, 565);
            this.Controls.Add(this.lbDomMechant2);
            this.Controls.Add(this.lbVieMechant2);
            this.Controls.Add(this.lbActionMechant2);
            this.Controls.Add(this.BarreVieMechant2);
            this.Controls.Add(this.pbMechant2);
            this.Controls.Add(this.lbMechant2);
            this.Controls.Add(this.lbBoss);
            this.Controls.Add(this.pbArme5);
            this.Controls.Add(this.pbArme3);
            this.Controls.Add(this.pbArme4);
            this.Controls.Add(this.pbArme2);
            this.Controls.Add(this.cbRetour);
            this.Controls.Add(this.lbArgent);
            this.Controls.Add(this.Argent);
            this.Controls.Add(this.lbDomPerso);
            this.Controls.Add(this.lbDomMechant);
            this.Controls.Add(this.lbViePerso);
            this.Controls.Add(this.lbVieMechant);
            this.Controls.Add(this.lbActionMechant);
            this.Controls.Add(this.BarreVieMechant);
            this.Controls.Add(this.pbArme1);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.pbMechant);
            this.Controls.Add(this.lbMechant);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.BarreVie);
            this.Controls.Add(this.pbPerso);
            this.Name = "Monde_2";
            this.Text = "Monde_2";
            ((System.ComponentModel.ISupportInitialize)(this.pbPerso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMechant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArme1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArme2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArme4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArme3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArme5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMechant2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPerso;
        private System.Windows.Forms.ProgressBar BarreVie;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lbMechant;
        private System.Windows.Forms.PictureBox pbMechant;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.PictureBox pbArme1;
        private System.Windows.Forms.ProgressBar BarreVieMechant;
        private System.Windows.Forms.Label lbActionMechant;
        private System.Windows.Forms.Label lbVieMechant;
        private System.Windows.Forms.Label lbViePerso;
        private System.Windows.Forms.Label lbDomMechant;
        private System.Windows.Forms.Label lbDomPerso;
        private System.Windows.Forms.Label lbArgent;
        private System.Windows.Forms.Label Argent;
        private System.Windows.Forms.ComboBox cbRetour;
        private System.Windows.Forms.PictureBox pbArme2;
        private System.Windows.Forms.PictureBox pbArme4;
        private System.Windows.Forms.PictureBox pbArme3;
        private System.Windows.Forms.PictureBox pbArme5;
        private System.Windows.Forms.Label lbBoss;
        private System.Windows.Forms.Label lbVieMechant2;
        private System.Windows.Forms.Label lbActionMechant2;
        private System.Windows.Forms.ProgressBar BarreVieMechant2;
        private System.Windows.Forms.PictureBox pbMechant2;
        private System.Windows.Forms.Label lbMechant2;
        private System.Windows.Forms.Label lbDomMechant2;
    }
}