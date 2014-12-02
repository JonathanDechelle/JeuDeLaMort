namespace Jeu
{
    partial class dMagasinRunes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dMagasinRunes));
            this.pbVendeurRune = new System.Windows.Forms.PictureBox();
            this.btnAcheter = new System.Windows.Forms.Button();
            this.pbAchat = new System.Windows.Forms.PictureBox();
            this.pbRune1 = new System.Windows.Forms.PictureBox();
            this.lbRune1 = new System.Windows.Forms.Label();
            this.lbDesRune1 = new System.Windows.Forms.Label();
            this.lbExperience = new System.Windows.Forms.Label();
            this.lbDesRune2 = new System.Windows.Forms.Label();
            this.lbRune2 = new System.Windows.Forms.Label();
            this.pbRune2 = new System.Windows.Forms.PictureBox();
            this.btnRetour = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbVendeurRune)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAchat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRune1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRune2)).BeginInit();
            this.SuspendLayout();
            // 
            // pbVendeurRune
            // 
            this.pbVendeurRune.Image = ((System.Drawing.Image)(resources.GetObject("pbVendeurRune.Image")));
            this.pbVendeurRune.Location = new System.Drawing.Point(402, 172);
            this.pbVendeurRune.Name = "pbVendeurRune";
            this.pbVendeurRune.Size = new System.Drawing.Size(181, 191);
            this.pbVendeurRune.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVendeurRune.TabIndex = 0;
            this.pbVendeurRune.TabStop = false;
            // 
            // btnAcheter
            // 
            this.btnAcheter.BackColor = System.Drawing.Color.DimGray;
            this.btnAcheter.Enabled = false;
            this.btnAcheter.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcheter.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAcheter.Location = new System.Drawing.Point(402, 138);
            this.btnAcheter.Name = "btnAcheter";
            this.btnAcheter.Size = new System.Drawing.Size(181, 28);
            this.btnAcheter.TabIndex = 1;
            this.btnAcheter.Text = "ACHETER";
            this.btnAcheter.UseVisualStyleBackColor = false;
            this.btnAcheter.Click += new System.EventHandler(this.btnAcheter_Click);
            // 
            // pbAchat
            // 
            this.pbAchat.Location = new System.Drawing.Point(428, 24);
            this.pbAchat.Name = "pbAchat";
            this.pbAchat.Size = new System.Drawing.Size(117, 108);
            this.pbAchat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAchat.TabIndex = 2;
            this.pbAchat.TabStop = false;
            // 
            // pbRune1
            // 
            this.pbRune1.AccessibleDescription = "";
            this.pbRune1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbRune1.BackgroundImage")));
            this.pbRune1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRune1.Location = new System.Drawing.Point(12, 9);
            this.pbRune1.Name = "pbRune1";
            this.pbRune1.Size = new System.Drawing.Size(100, 106);
            this.pbRune1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRune1.TabIndex = 3;
            this.pbRune1.TabStop = false;
            this.pbRune1.Click += new System.EventHandler(this.pbRune1_Click);
            this.pbRune1.MouseEnter += new System.EventHandler(this.pbRune1_MouseEnter);
            this.pbRune1.MouseLeave += new System.EventHandler(this.pbRune1_MouseLeave);
            // 
            // lbRune1
            // 
            this.lbRune1.AutoSize = true;
            this.lbRune1.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRune1.ForeColor = System.Drawing.Color.White;
            this.lbRune1.Location = new System.Drawing.Point(12, 127);
            this.lbRune1.Name = "lbRune1";
            this.lbRune1.Size = new System.Drawing.Size(156, 17);
            this.lbRune1.TabIndex = 4;
            this.lbRune1.Text = "Rune De Soin    Prix  : ";
            // 
            // lbDesRune1
            // 
            this.lbDesRune1.BackColor = System.Drawing.Color.MidnightBlue;
            this.lbDesRune1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDesRune1.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesRune1.ForeColor = System.Drawing.Color.White;
            this.lbDesRune1.Location = new System.Drawing.Point(118, 9);
            this.lbDesRune1.Name = "lbDesRune1";
            this.lbDesRune1.Size = new System.Drawing.Size(267, 106);
            this.lbDesRune1.TabIndex = 6;
            this.lbDesRune1.Text = "Apres un nombre particulier de coup le bouton de magie de soin s\'active";
            // 
            // lbExperience
            // 
            this.lbExperience.AutoSize = true;
            this.lbExperience.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExperience.ForeColor = System.Drawing.Color.White;
            this.lbExperience.Location = new System.Drawing.Point(18, 327);
            this.lbExperience.Name = "lbExperience";
            this.lbExperience.Size = new System.Drawing.Size(65, 17);
            this.lbExperience.TabIndex = 8;
            this.lbExperience.Text = " Argent :";
            // 
            // lbDesRune2
            // 
            this.lbDesRune2.BackColor = System.Drawing.Color.MidnightBlue;
            this.lbDesRune2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDesRune2.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDesRune2.ForeColor = System.Drawing.Color.White;
            this.lbDesRune2.Location = new System.Drawing.Point(121, 160);
            this.lbDesRune2.Name = "lbDesRune2";
            this.lbDesRune2.Size = new System.Drawing.Size(264, 106);
            this.lbDesRune2.TabIndex = 11;
            this.lbDesRune2.Text = " Apres 3 combat dans la meme bataille la rune s\'active et rend l\' ennemi paralysé" +
                "e\r\n";
            // 
            // lbRune2
            // 
            this.lbRune2.AutoSize = true;
            this.lbRune2.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRune2.ForeColor = System.Drawing.Color.White;
            this.lbRune2.Location = new System.Drawing.Point(12, 280);
            this.lbRune2.Name = "lbRune2";
            this.lbRune2.Size = new System.Drawing.Size(187, 17);
            this.lbRune2.TabIndex = 10;
            this.lbRune2.Text = "Rune De Paralysie    Prix  : ";
            // 
            // pbRune2
            // 
            this.pbRune2.AccessibleDescription = "";
            this.pbRune2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbRune2.BackgroundImage")));
            this.pbRune2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbRune2.Location = new System.Drawing.Point(15, 160);
            this.pbRune2.Name = "pbRune2";
            this.pbRune2.Size = new System.Drawing.Size(100, 106);
            this.pbRune2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRune2.TabIndex = 9;
            this.pbRune2.TabStop = false;
            this.pbRune2.Click += new System.EventHandler(this.pbRune2_Click);
            this.pbRune2.MouseEnter += new System.EventHandler(this.pbRune2_MouseEnter);
            this.pbRune2.MouseLeave += new System.EventHandler(this.pbRune2_MouseLeave);
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.DimGray;
            this.btnRetour.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetour.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnRetour.Location = new System.Drawing.Point(21, 347);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(178, 28);
            this.btnRetour.TabIndex = 12;
            this.btnRetour.Text = "Retour au menu";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // dMagasinRunes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(602, 399);
            this.ControlBox = false;
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.lbDesRune2);
            this.Controls.Add(this.lbRune2);
            this.Controls.Add(this.pbRune2);
            this.Controls.Add(this.lbExperience);
            this.Controls.Add(this.lbDesRune1);
            this.Controls.Add(this.lbRune1);
            this.Controls.Add(this.pbRune1);
            this.Controls.Add(this.pbAchat);
            this.Controls.Add(this.btnAcheter);
            this.Controls.Add(this.pbVendeurRune);
            this.Name = "dMagasinRunes";
            this.Text = "MagasinRunes";
            ((System.ComponentModel.ISupportInitialize)(this.pbVendeurRune)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAchat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRune1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRune2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbVendeurRune;
        private System.Windows.Forms.Button btnAcheter;
        private System.Windows.Forms.PictureBox pbAchat;
        private System.Windows.Forms.PictureBox pbRune1;
        private System.Windows.Forms.Label lbRune1;
        private System.Windows.Forms.Label lbDesRune1;
        private System.Windows.Forms.Label lbExperience;
        private System.Windows.Forms.Label lbDesRune2;
        private System.Windows.Forms.Label lbRune2;
        private System.Windows.Forms.PictureBox pbRune2;
        private System.Windows.Forms.Button btnRetour;
    }
}