namespace Jeu
{
    partial class dUnivers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dUnivers));
            this.label1 = new System.Windows.Forms.Label();
            this.pbSoleil = new System.Windows.Forms.PictureBox();
            this.pbPlanete1 = new System.Windows.Forms.PictureBox();
            this.Rotation = new System.Windows.Forms.Timer(this.components);
            this.lbPlanete = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbPlanete2 = new System.Windows.Forms.PictureBox();
            this.RotationP2 = new System.Windows.Forms.Timer(this.components);
            this.lbrefGrille = new System.Windows.Forms.Label();
            this.pbPlanete3 = new System.Windows.Forms.PictureBox();
            this.RotationP3 = new System.Windows.Forms.Timer(this.components);
            this.RotationPlaneteFinale = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbSoleil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Pristina", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(1042, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Retourner au menu";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // pbSoleil
            // 
            this.pbSoleil.Image = ((System.Drawing.Image)(resources.GetObject("pbSoleil.Image")));
            this.pbSoleil.Location = new System.Drawing.Point(-249, -2);
            this.pbSoleil.Name = "pbSoleil";
            this.pbSoleil.Size = new System.Drawing.Size(719, 705);
            this.pbSoleil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSoleil.TabIndex = 1;
            this.pbSoleil.TabStop = false;
            this.pbSoleil.Click += new System.EventHandler(this.pbSoleil_Click);
            this.pbSoleil.MouseEnter += new System.EventHandler(this.pbSoleil_MouseEnter);
            // 
            // pbPlanete1
            // 
            this.pbPlanete1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbPlanete1.BackgroundImage")));
            this.pbPlanete1.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.pbPlanete1.Location = new System.Drawing.Point(521, 222);
            this.pbPlanete1.Name = "pbPlanete1";
            this.pbPlanete1.Size = new System.Drawing.Size(100, 74);
            this.pbPlanete1.TabIndex = 2;
            this.pbPlanete1.TabStop = false;
            this.pbPlanete1.Click += new System.EventHandler(this.IPlanete1_Click);
            this.pbPlanete1.MouseEnter += new System.EventHandler(this.IPlanete1_MouseEnter);
            // 
            // Rotation
            // 
            this.Rotation.Interval = 70;
            this.Rotation.Tick += new System.EventHandler(this.Rotation_Tick);
            // 
            // lbPlanete
            // 
            this.lbPlanete.AutoSize = true;
            this.lbPlanete.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlanete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbPlanete.Location = new System.Drawing.Point(1129, 70);
            this.lbPlanete.Name = "lbPlanete";
            this.lbPlanete.Size = new System.Drawing.Size(0, 25);
            this.lbPlanete.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(1046, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Planete:";
            // 
            // pbPlanete2
            // 
            this.pbPlanete2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbPlanete2.BackgroundImage")));
            this.pbPlanete2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPlanete2.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.pbPlanete2.Location = new System.Drawing.Point(854, 406);
            this.pbPlanete2.Name = "pbPlanete2";
            this.pbPlanete2.Size = new System.Drawing.Size(198, 130);
            this.pbPlanete2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlanete2.TabIndex = 5;
            this.pbPlanete2.TabStop = false;
            this.pbPlanete2.Visible = false;
            this.pbPlanete2.Click += new System.EventHandler(this.pbPlanete2_Click);
            this.pbPlanete2.MouseEnter += new System.EventHandler(this.pbPlanete2_MouseEnter);
            // 
            // RotationP2
            // 
            this.RotationP2.Tick += new System.EventHandler(this.RotationP2_Tick);
            // 
            // lbrefGrille
            // 
            this.lbrefGrille.AutoSize = true;
            this.lbrefGrille.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbrefGrille.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbrefGrille.Location = new System.Drawing.Point(1264, 70);
            this.lbrefGrille.Name = "lbrefGrille";
            this.lbrefGrille.Size = new System.Drawing.Size(94, 15);
            this.lbrefGrille.TabIndex = 6;
            this.lbrefGrille.Text = "ref.Grille Niveau";
            this.lbrefGrille.Click += new System.EventHandler(this.lbrefGrille_Click);
            this.lbrefGrille.MouseEnter += new System.EventHandler(this.lbrefGrille_MouseEnter);
            this.lbrefGrille.MouseLeave += new System.EventHandler(this.lbrefGrille_MouseLeave);
            // 
            // pbPlanete3
            // 
            this.pbPlanete3.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.pbPlanete3.Image = ((System.Drawing.Image)(resources.GetObject("pbPlanete3.Image")));
            this.pbPlanete3.Location = new System.Drawing.Point(659, 300);
            this.pbPlanete3.Name = "pbPlanete3";
            this.pbPlanete3.Size = new System.Drawing.Size(174, 171);
            this.pbPlanete3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlanete3.TabIndex = 7;
            this.pbPlanete3.TabStop = false;
            this.pbPlanete3.Visible = false;
            this.pbPlanete3.Click += new System.EventHandler(this.pbPlanete3_Click);
            this.pbPlanete3.MouseEnter += new System.EventHandler(this.pbPlanete3_MouseEnter);
            // 
            // RotationP3
            // 
            this.RotationP3.Interval = 120;
            this.RotationP3.Tick += new System.EventHandler(this.RotationP3_Tick);
            // 
            // RotationPlaneteFinale
            // 
            this.RotationPlaneteFinale.Tick += new System.EventHandler(this.RotationPlaneteFinale_Tick);
            // 
            // dUnivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1370, 702);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.Controls.Add(this.pbPlanete3);
            this.Controls.Add(this.lbrefGrille);
            this.Controls.Add(this.pbPlanete2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbPlanete);
            this.Controls.Add(this.pbPlanete1);
            this.Controls.Add(this.pbSoleil);
            this.Controls.Add(this.label1);
            this.Name = "dUnivers";
            this.Text = "Univers";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dUnivers_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pbSoleil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbSoleil;
        private System.Windows.Forms.PictureBox pbPlanete1;
        private System.Windows.Forms.Timer Rotation;
        private System.Windows.Forms.Label lbPlanete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbPlanete2;
        private System.Windows.Forms.Timer RotationP2;
        private System.Windows.Forms.Label lbrefGrille;
        private System.Windows.Forms.PictureBox pbPlanete3;
        private System.Windows.Forms.Timer RotationP3;
        private System.Windows.Forms.Timer RotationPlaneteFinale;
    
     
    }
}