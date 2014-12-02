namespace Jeu
{
    partial class Jeu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnJouer = new System.Windows.Forms.Button();
            this.PanQuitter = new System.Windows.Forms.Panel();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.panJeu = new System.Windows.Forms.Panel();
            this.PanQuitter.SuspendLayout();
            this.panJeu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Ivory;
            this.label1.Location = new System.Drawing.Point(89, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jeu RPG ";
            // 
            // btnJouer
            // 
            this.btnJouer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJouer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnJouer.Image = global::Jeu.Properties.Resources.woodtexture;
            this.btnJouer.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJouer.Location = new System.Drawing.Point(3, 3);
            this.btnJouer.Name = "btnJouer";
            this.btnJouer.Size = new System.Drawing.Size(125, 57);
            this.btnJouer.TabIndex = 89;
            this.btnJouer.Text = "Nouvelle partie";
            this.btnJouer.UseVisualStyleBackColor = true;
            this.btnJouer.Click += new System.EventHandler(this.btnJouer_Click);
            this.btnJouer.MouseEnter += new System.EventHandler(this.btnJouer_MouseEnter);
            this.btnJouer.MouseLeave += new System.EventHandler(this.btnJouer_MouseLeave);
            // 
            // PanQuitter
            // 
            this.PanQuitter.Controls.Add(this.btnQuitter);
            this.PanQuitter.Location = new System.Drawing.Point(183, 150);
            this.PanQuitter.Name = "PanQuitter";
            this.PanQuitter.Size = new System.Drawing.Size(131, 63);
            this.PanQuitter.TabIndex = 6;
            // 
            // btnQuitter
            // 
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnQuitter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnQuitter.Image = global::Jeu.Properties.Resources.woodtexture;
            this.btnQuitter.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuitter.Location = new System.Drawing.Point(4, 4);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(124, 56);
            this.btnQuitter.TabIndex = 0;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            this.btnQuitter.MouseEnter += new System.EventHandler(this.btnQuitter_MouseEnter);
            this.btnQuitter.MouseLeave += new System.EventHandler(this.btnQuitter_MouseLeave);
            // 
            // panJeu
            // 
            this.panJeu.Controls.Add(this.btnJouer);
            this.panJeu.Location = new System.Drawing.Point(13, 150);
            this.panJeu.Name = "panJeu";
            this.panJeu.Size = new System.Drawing.Size(131, 63);
            this.panJeu.TabIndex = 4;
            // 
            // Jeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::Jeu.Properties.Resources.Metal_Texture_thumb02;
            this.ClientSize = new System.Drawing.Size(325, 232);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PanQuitter);
            this.Controls.Add(this.panJeu);
            this.Name = "Jeu";
            this.Text = "RPG";
            this.PanQuitter.ResumeLayout(false);
            this.panJeu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJouer;
        private System.Windows.Forms.Panel PanQuitter;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Panel panJeu;
        private System.Windows.Forms.Label label1;
    }
}

