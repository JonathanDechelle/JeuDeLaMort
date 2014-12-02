namespace Jeu
{
    partial class Univers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Univers));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.IPlanete1 = new System.Windows.Forms.PictureBox();
            this.Rotation = new System.Windows.Forms.Timer(this.components);
            this.lbPlanete = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbPlanete2 = new System.Windows.Forms.PictureBox();
            this.RotationP2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPlanete1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Pristina", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(1004, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Retourner au menu";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-249, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(719, 705);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // IPlanete1
            // 
            this.IPlanete1.Image = global::Jeu.Properties.Resources.planete1;
            this.IPlanete1.Location = new System.Drawing.Point(521, 222);
            this.IPlanete1.Name = "IPlanete1";
            this.IPlanete1.Size = new System.Drawing.Size(100, 74);
            this.IPlanete1.TabIndex = 2;
            this.IPlanete1.TabStop = false;
            this.IPlanete1.Click += new System.EventHandler(this.IPlanete1_Click);
            this.IPlanete1.MouseEnter += new System.EventHandler(this.IPlanete1_MouseEnter);
            this.IPlanete1.MouseLeave += new System.EventHandler(this.IPlanete1_MouseLeave);
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
            this.lbPlanete.Location = new System.Drawing.Point(1100, 81);
            this.lbPlanete.Name = "lbPlanete";
            this.lbPlanete.Size = new System.Drawing.Size(0, 25);
            this.lbPlanete.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(1008, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Planete:";
            // 
            // pbPlanete2
            // 
            this.pbPlanete2.Image = global::Jeu.Properties.Resources.planete_2;
            this.pbPlanete2.Location = new System.Drawing.Point(787, 411);
            this.pbPlanete2.Name = "pbPlanete2";
            this.pbPlanete2.Size = new System.Drawing.Size(198, 130);
            this.pbPlanete2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlanete2.TabIndex = 5;
            this.pbPlanete2.TabStop = false;
            this.pbPlanete2.Visible = false;
            this.pbPlanete2.Click += new System.EventHandler(this.pbPlanete2_Click);
            this.pbPlanete2.MouseEnter += new System.EventHandler(this.pbPlanete2_MouseEnter);
            this.pbPlanete2.MouseLeave += new System.EventHandler(this.pbPlanete2_MouseLeave);
            // 
            // RotationP2
            // 
            this.RotationP2.Tick += new System.EventHandler(this.RotationP2_Tick);
            // 
            // Univers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1350, 702);
            this.Controls.Add(this.pbPlanete2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbPlanete);
            this.Controls.Add(this.IPlanete1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "Univers";
            this.Text = "Univers";
            this.Load += new System.EventHandler(this.Univers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPlanete1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanete2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox IPlanete1;
        private System.Windows.Forms.Timer Rotation;
        private System.Windows.Forms.Label lbPlanete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbPlanete2;
        private System.Windows.Forms.Timer RotationP2;
    
     
    }
}