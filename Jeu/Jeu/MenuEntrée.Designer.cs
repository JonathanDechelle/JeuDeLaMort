namespace Jeu
{
    partial class MenuEntrée
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuEntrée));
            this.btnStats = new System.Windows.Forms.Button();
            this.btnPerso = new System.Windows.Forms.Button();
            this.ImagePerso = new System.Windows.Forms.PictureBox();
            this.ImageArme = new System.Windows.Forms.PictureBox();
            this.btnMagasin = new System.Windows.Forms.Button();
            this.btnJouer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbArgent = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePerso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageArme)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStats
            // 
            this.btnStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStats.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStats.Image = global::Jeu.Properties.Resources.wood7;
            this.btnStats.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStats.Location = new System.Drawing.Point(13, 100);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(187, 23);
            this.btnStats.TabIndex = 0;
            this.btnStats.Text = "Statistiques des Armes";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            this.btnStats.MouseEnter += new System.EventHandler(this.btnStats_MouseEnter);
            this.btnStats.MouseLeave += new System.EventHandler(this.btnStats_MouseLeave);
            // 
            // btnPerso
            // 
            this.btnPerso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnPerso.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPerso.Image = global::Jeu.Properties.Resources.wood7;
            this.btnPerso.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPerso.Location = new System.Drawing.Point(12, 44);
            this.btnPerso.Name = "btnPerso";
            this.btnPerso.Size = new System.Drawing.Size(187, 23);
            this.btnPerso.TabIndex = 1;
            this.btnPerso.Text = "Choix du Personnage";
            this.btnPerso.UseVisualStyleBackColor = true;
            this.btnPerso.Click += new System.EventHandler(this.btnPerso_Click);
            this.btnPerso.MouseEnter += new System.EventHandler(this.btnPerso_MouseEnter);
            this.btnPerso.MouseLeave += new System.EventHandler(this.btnPerso_MouseLeave);
            // 
            // ImagePerso
            // 
            this.ImagePerso.BackColor = System.Drawing.Color.BurlyWood;
            this.ImagePerso.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ImagePerso.BackgroundImage")));
            this.ImagePerso.Location = new System.Drawing.Point(205, 12);
            this.ImagePerso.Name = "ImagePerso";
            this.ImagePerso.Size = new System.Drawing.Size(177, 238);
            this.ImagePerso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagePerso.TabIndex = 2;
            this.ImagePerso.TabStop = false;
            // 
            // ImageArme
            // 
            this.ImageArme.BackColor = System.Drawing.Color.BurlyWood;
            this.ImageArme.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ImageArme.BackgroundImage")));
            this.ImageArme.Location = new System.Drawing.Point(12, 129);
            this.ImageArme.Name = "ImageArme";
            this.ImageArme.Size = new System.Drawing.Size(187, 121);
            this.ImageArme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageArme.TabIndex = 3;
            this.ImageArme.TabStop = false;
            // 
            // btnMagasin
            // 
            this.btnMagasin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnMagasin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMagasin.Image = global::Jeu.Properties.Resources.wood7;
            this.btnMagasin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMagasin.Location = new System.Drawing.Point(13, 71);
            this.btnMagasin.Name = "btnMagasin";
            this.btnMagasin.Size = new System.Drawing.Size(187, 23);
            this.btnMagasin.TabIndex = 4;
            this.btnMagasin.Text = "Magasin d\'Arme";
            this.btnMagasin.UseVisualStyleBackColor = true;
            this.btnMagasin.Click += new System.EventHandler(this.btnMagasin_Click);
            this.btnMagasin.MouseEnter += new System.EventHandler(this.btnMagasin_MouseEnter);
            this.btnMagasin.MouseLeave += new System.EventHandler(this.btnMagasin_MouseLeave);
            // 
            // btnJouer
            // 
            this.btnJouer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnJouer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnJouer.Image = global::Jeu.Properties.Resources.wood7;
            this.btnJouer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnJouer.Location = new System.Drawing.Point(12, 13);
            this.btnJouer.Name = "btnJouer";
            this.btnJouer.Size = new System.Drawing.Size(187, 23);
            this.btnJouer.TabIndex = 5;
            this.btnJouer.Text = "Jouer";
            this.btnJouer.UseVisualStyleBackColor = true;
            this.btnJouer.Click += new System.EventHandler(this.btnJouer_Click);
            this.btnJouer.MouseEnter += new System.EventHandler(this.btnJouer_MouseEnter);
            this.btnJouer.MouseLeave += new System.EventHandler(this.btnJouer_MouseLeave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Peru;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Papyrus", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(387, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "ARGENT";
            // 
            // lbArgent
            // 
            this.lbArgent.BackColor = System.Drawing.Color.Peru;
            this.lbArgent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbArgent.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArgent.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbArgent.Location = new System.Drawing.Point(388, 30);
            this.lbArgent.Name = "lbArgent";
            this.lbArgent.Size = new System.Drawing.Size(89, 23);
            this.lbArgent.TabIndex = 7;
            this.lbArgent.Text = "label1";
            this.lbArgent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(390, 58);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Sauvegarde";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.Location = new System.Drawing.Point(389, 87);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(88, 23);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Charger";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            this.btnLoad.MouseEnter += new System.EventHandler(this.btnLoad_MouseEnter);
            this.btnLoad.MouseLeave += new System.EventHandler(this.btnLoad_MouseLeave);
            // 
            // MenuEntrée
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Jeu.Properties.Resources.Paper_Textures_331;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbArgent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnJouer);
            this.Controls.Add(this.btnMagasin);
            this.Controls.Add(this.ImageArme);
            this.Controls.Add(this.ImagePerso);
            this.Controls.Add(this.btnPerso);
            this.Controls.Add(this.btnStats);
            this.Name = "MenuEntrée";
            this.Text = "MenuEntrée";
            ((System.ComponentModel.ISupportInitialize)(this.ImagePerso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageArme)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button btnPerso;
        private System.Windows.Forms.PictureBox ImagePerso;
        private System.Windows.Forms.PictureBox ImageArme;
        private System.Windows.Forms.Button btnMagasin;
        private System.Windows.Forms.Button btnJouer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbArgent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
    }
}