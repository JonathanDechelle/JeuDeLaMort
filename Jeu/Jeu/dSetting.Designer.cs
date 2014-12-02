namespace Jeu
{
    partial class dSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dSetting));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cboChoixArmes = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRetour = new System.Windows.Forms.Button();
            this.lbDegat = new System.Windows.Forms.Label();
            this.lbPrecision = new System.Windows.Forms.Label();
            this.lbChargeur = new System.Windows.Forms.Label();
            this.lbRecharge = new System.Windows.Forms.Label();
            this.lbNiveauArme = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNomArme = new System.Windows.Forms.Label();
            this.BoiteImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoiteImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cboChoixArmes);
            this.panel1.Location = new System.Drawing.Point(12, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 129);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Choix de l\'Arme";
            // 
            // cboChoixArmes
            // 
            this.cboChoixArmes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChoixArmes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboChoixArmes.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChoixArmes.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cboChoixArmes.FormattingEnabled = true;
            this.cboChoixArmes.IntegralHeight = false;
            this.cboChoixArmes.Items.AddRange(new object[] {
            "Zat",
            "PlasmaGun",
            "Klarix",
            "Catagan",
            "TwisterGun",
            " Desintegrateur"});
            this.cboChoixArmes.Location = new System.Drawing.Point(3, 20);
            this.cboChoixArmes.MaxDropDownItems = 10;
            this.cboChoixArmes.Name = "cboChoixArmes";
            this.cboChoixArmes.Size = new System.Drawing.Size(121, 24);
            this.cboChoixArmes.TabIndex = 0;
            this.cboChoixArmes.SelectedIndexChanged += new System.EventHandler(this.cboChoixArmes_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Orange;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnRetour);
            this.panel2.Controls.Add(this.lbDegat);
            this.panel2.Controls.Add(this.lbPrecision);
            this.panel2.Controls.Add(this.lbChargeur);
            this.panel2.Controls.Add(this.lbRecharge);
            this.panel2.Controls.Add(this.lbNiveauArme);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(324, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 338);
            this.panel2.TabIndex = 1;
            // 
            // btnRetour
            // 
            this.btnRetour.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetour.ForeColor = System.Drawing.Color.Blue;
            this.btnRetour.Location = new System.Drawing.Point(40, 266);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(209, 33);
            this.btnRetour.TabIndex = 10;
            this.btnRetour.Text = "Retour au Menu";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // lbDegat
            // 
            this.lbDegat.AutoSize = true;
            this.lbDegat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDegat.Location = new System.Drawing.Point(214, 17);
            this.lbDegat.Name = "lbDegat";
            this.lbDegat.Size = new System.Drawing.Size(0, 18);
            this.lbDegat.TabIndex = 9;
            // 
            // lbPrecision
            // 
            this.lbPrecision.AutoSize = true;
            this.lbPrecision.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrecision.Location = new System.Drawing.Point(214, 52);
            this.lbPrecision.Name = "lbPrecision";
            this.lbPrecision.Size = new System.Drawing.Size(0, 18);
            this.lbPrecision.TabIndex = 8;
            // 
            // lbChargeur
            // 
            this.lbChargeur.AutoSize = true;
            this.lbChargeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChargeur.Location = new System.Drawing.Point(214, 90);
            this.lbChargeur.Name = "lbChargeur";
            this.lbChargeur.Size = new System.Drawing.Size(0, 18);
            this.lbChargeur.TabIndex = 7;
            // 
            // lbRecharge
            // 
            this.lbRecharge.AutoSize = true;
            this.lbRecharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecharge.Location = new System.Drawing.Point(214, 129);
            this.lbRecharge.Name = "lbRecharge";
            this.lbRecharge.Size = new System.Drawing.Size(0, 18);
            this.lbRecharge.TabIndex = 6;
            // 
            // lbNiveauArme
            // 
            this.lbNiveauArme.AutoSize = true;
            this.lbNiveauArme.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNiveauArme.Location = new System.Drawing.Point(214, 189);
            this.lbNiveauArme.Name = "lbNiveauArme";
            this.lbNiveauArme.Size = new System.Drawing.Size(0, 18);
            this.lbNiveauArme.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Niveau Actuelle de l\'arme";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Temps de recharge";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Chargeur ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Précision";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Dégats";
            // 
            // lbNomArme
            // 
            this.lbNomArme.AutoSize = true;
            this.lbNomArme.BackColor = System.Drawing.Color.Orange;
            this.lbNomArme.Font = new System.Drawing.Font("Mistral", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomArme.Location = new System.Drawing.Point(23, 9);
            this.lbNomArme.Name = "lbNomArme";
            this.lbNomArme.Size = new System.Drawing.Size(0, 42);
            this.lbNomArme.TabIndex = 3;
            // 
            // BoiteImage
            // 
            this.BoiteImage.BackColor = System.Drawing.Color.Silver;
            this.BoiteImage.Location = new System.Drawing.Point(12, 56);
            this.BoiteImage.Name = "BoiteImage";
            this.BoiteImage.Size = new System.Drawing.Size(306, 202);
            this.BoiteImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BoiteImage.TabIndex = 2;
            this.BoiteImage.TabStop = false;
            // 
            // dSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(648, 403);
            this.ControlBox = false;
            this.Controls.Add(this.BoiteImage);
            this.Controls.Add(this.lbNomArme);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "dSetting";
            this.Text = "statistique des armes de combat";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoiteImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox BoiteImage;
        private System.Windows.Forms.Label lbNomArme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbDegat;
        private System.Windows.Forms.Label lbPrecision;
        private System.Windows.Forms.Label lbChargeur;
        private System.Windows.Forms.Label lbRecharge;
        private System.Windows.Forms.Label lbNiveauArme;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboChoixArmes;
        private System.Windows.Forms.Button btnRetour;
    }
}