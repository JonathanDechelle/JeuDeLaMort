namespace Jeu
{
    partial class dCredits
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dCredits));
            this.lbCredits1 = new System.Windows.Forms.Label();
            this.lbCredits2 = new System.Windows.Forms.Label();
            this.TimerDeplacementTexte = new System.Windows.Forms.Timer(this.components);
            this.btnCommencer = new System.Windows.Forms.Button();
            this.TimerStart = new System.Windows.Forms.Timer(this.components);
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.pbNuke = new System.Windows.Forms.PictureBox();
            this.lbNuke = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNuke)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCredits1
            // 
            this.lbCredits1.AutoSize = true;
            this.lbCredits1.BackColor = System.Drawing.Color.Transparent;
            this.lbCredits1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCredits1.Font = new System.Drawing.Font("Papyrus", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCredits1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbCredits1.Location = new System.Drawing.Point(55, 78);
            this.lbCredits1.Name = "lbCredits1";
            this.lbCredits1.Size = new System.Drawing.Size(0, 30);
            this.lbCredits1.TabIndex = 0;
            // 
            // lbCredits2
            // 
            this.lbCredits2.AutoSize = true;
            this.lbCredits2.BackColor = System.Drawing.Color.Transparent;
            this.lbCredits2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCredits2.Font = new System.Drawing.Font("Papyrus", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCredits2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbCredits2.Location = new System.Drawing.Point(55, 32);
            this.lbCredits2.Name = "lbCredits2";
            this.lbCredits2.Size = new System.Drawing.Size(132, 30);
            this.lbCredits2.TabIndex = 1;
            this.lbCredits2.Text = "CRÉDITS";
            // 
            // TimerDeplacementTexte
            // 
            this.TimerDeplacementTexte.Tick += new System.EventHandler(this.TimerDeplacementTexte_Tick);
            // 
            // btnCommencer
            // 
            this.btnCommencer.Location = new System.Drawing.Point(519, 183);
            this.btnCommencer.Name = "btnCommencer";
            this.btnCommencer.Size = new System.Drawing.Size(75, 23);
            this.btnCommencer.TabIndex = 2;
            this.btnCommencer.Text = "Debut";
            this.btnCommencer.UseVisualStyleBackColor = true;
            this.btnCommencer.Visible = false;
            this.btnCommencer.Click += new System.EventHandler(this.btnCommencer_Click);
            // 
            // TimerStart
            // 
            this.TimerStart.Interval = 7000;
            this.TimerStart.Tick += new System.EventHandler(this.TimerStart_Tick);
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Transparent;
            this.pbImage.Image = ((System.Drawing.Image)(resources.GetObject("pbImage.Image")));
            this.pbImage.Location = new System.Drawing.Point(539, 12);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(49, 50);
            this.pbImage.TabIndex = 3;
            this.pbImage.TabStop = false;
            // 
            // pbNuke
            // 
            this.pbNuke.Image = ((System.Drawing.Image)(resources.GetObject("pbNuke.Image")));
            this.pbNuke.Location = new System.Drawing.Point(363, 145);
            this.pbNuke.Name = "pbNuke";
            this.pbNuke.Size = new System.Drawing.Size(120, 134);
            this.pbNuke.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNuke.TabIndex = 4;
            this.pbNuke.TabStop = false;
            this.pbNuke.Visible = false;
            // 
            // lbNuke
            // 
            this.lbNuke.AutoSize = true;
            this.lbNuke.Location = new System.Drawing.Point(363, 286);
            this.lbNuke.Name = "lbNuke";
            this.lbNuke.Size = new System.Drawing.Size(163, 13);
            this.lbNuke.TabIndex = 5;
            this.lbNuke.Text = "Bombe Nucléaire ((NUKE)) Dispo";
            this.lbNuke.Visible = false;
            // 
            // dCredits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 344);
            this.Controls.Add(this.lbNuke);
            this.Controls.Add(this.pbNuke);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnCommencer);
            this.Controls.Add(this.lbCredits2);
            this.Controls.Add(this.lbCredits1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "dCredits";
            this.Text = "////////////Merci d\'avoir joué à mon jeu\\\\\\\\\\\\\\\\\\\\\\\\\\\\";
            this.Load += new System.EventHandler(this.dCredits_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNuke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCredits1;
        private System.Windows.Forms.Label lbCredits2;
        private System.Windows.Forms.Timer TimerDeplacementTexte;
        private System.Windows.Forms.Button btnCommencer;
        private System.Windows.Forms.Timer TimerStart;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.PictureBox pbNuke;
        private System.Windows.Forms.Label lbNuke;



    }
}