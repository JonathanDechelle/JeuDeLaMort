namespace Jeu
{
    partial class Choix_du_personage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Choix_du_personage));
            this.cboPerso = new System.Windows.Forms.ComboBox();
            this.PersoBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PersoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPerso
            // 
            this.cboPerso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cboPerso.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboPerso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboPerso.DropDownWidth = 208;
            this.cboPerso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPerso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPerso.ForeColor = System.Drawing.Color.Black;
            this.cboPerso.FormattingEnabled = true;
            this.cboPerso.ItemHeight = 16;
            this.cboPerso.Items.AddRange(new object[] {
            "Alien Armure Legerte",
            "Alien Armure Lourde",
            "Alien Ingenieur",
            "Alien Secouriste",
            "Alien Éclaireur",
            "Alien Samourail"});
            this.cboPerso.Location = new System.Drawing.Point(0, 0);
            this.cboPerso.Name = "cboPerso";
            this.cboPerso.Size = new System.Drawing.Size(177, 247);
            this.cboPerso.TabIndex = 0;
            this.cboPerso.Text = "Choix de votre personnage";
            this.cboPerso.SelectedIndexChanged += new System.EventHandler(this.cboPerso_SelectedIndexChanged);
            this.cboPerso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboPerso_KeyPress);
            // 
            // PersoBox
            // 
            this.PersoBox.BackColor = System.Drawing.Color.DarkGray;
            this.PersoBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PersoBox.Location = new System.Drawing.Point(214, 4);
            this.PersoBox.Name = "PersoBox";
            this.PersoBox.Size = new System.Drawing.Size(177, 238);
            this.PersoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PersoBox.TabIndex = 1;
            this.PersoBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(-3, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 117);
            this.label1.TabIndex = 2;
            this.label1.Text = "   Appuyer sur ENTER \r\n   lorsque votre choix \r\n   est fait !!!!";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(34, 212);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 3;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // Choix_du_personage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(402, 247);
            this.ControlBox = false;
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PersoBox);
            this.Controls.Add(this.cboPerso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Choix_du_personage";
            this.Text = "Choix_du_personage";
            ((System.ComponentModel.ISupportInitialize)(this.PersoBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPerso;
        private System.Windows.Forms.PictureBox PersoBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnnuler;

    }
}