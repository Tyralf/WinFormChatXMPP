namespace WinFormChatXMPP
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gbxConnexion = new System.Windows.Forms.GroupBox();
            this.tbxServer = new System.Windows.Forms.TextBox();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblConnexionStatus = new System.Windows.Forms.Label();
            this.gbxChat = new System.Windows.Forms.GroupBox();
            this.ltbChatHistory = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbxMessage = new System.Windows.Forms.TextBox();
            this.gbxConnexion.SuspendLayout();
            this.gbxChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxConnexion
            // 
            this.gbxConnexion.Controls.Add(this.textBox2);
            this.gbxConnexion.Controls.Add(this.textBox1);
            this.gbxConnexion.Controls.Add(this.lblPassword);
            this.gbxConnexion.Controls.Add(this.lblUsername);
            this.gbxConnexion.Controls.Add(this.lblServer);
            this.gbxConnexion.Controls.Add(this.tbxServer);
            this.gbxConnexion.Controls.Add(this.btnConnexion);
            this.gbxConnexion.Location = new System.Drawing.Point(13, 13);
            this.gbxConnexion.Name = "gbxConnexion";
            this.gbxConnexion.Size = new System.Drawing.Size(386, 151);
            this.gbxConnexion.TabIndex = 0;
            this.gbxConnexion.TabStop = false;
            this.gbxConnexion.Text = "Connexion";
            // 
            // tbxServer
            // 
            this.tbxServer.ForeColor = System.Drawing.SystemColors.InfoText;
            this.tbxServer.Location = new System.Drawing.Point(107, 30);
            this.tbxServer.Name = "tbxServer";
            this.tbxServer.Size = new System.Drawing.Size(264, 20);
            this.tbxServer.TabIndex = 1;
            // 
            // btnConnexion
            // 
            this.btnConnexion.Location = new System.Drawing.Point(249, 122);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(131, 23);
            this.btnConnexion.TabIndex = 0;
            this.btnConnexion.Text = "Se Connecter";
            this.btnConnexion.UseVisualStyleBackColor = true;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(14, 33);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(87, 13);
            this.lblServer.TabIndex = 2;
            this.lblServer.Text = "Serveur Openfire";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(14, 64);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(53, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Identifiant";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(14, 97);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(71, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Mot de passe";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(264, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(107, 94);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(264, 20);
            this.textBox2.TabIndex = 6;
            // 
            // lblConnexionStatus
            // 
            this.lblConnexionStatus.AutoSize = true;
            this.lblConnexionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnexionStatus.ForeColor = System.Drawing.Color.Red;
            this.lblConnexionStatus.Location = new System.Drawing.Point(344, 167);
            this.lblConnexionStatus.Name = "lblConnexionStatus";
            this.lblConnexionStatus.Size = new System.Drawing.Size(55, 12);
            this.lblConnexionStatus.TabIndex = 1;
            this.lblConnexionStatus.Text = "Deconnecté";
            // 
            // gbxChat
            // 
            this.gbxChat.Controls.Add(this.tbxMessage);
            this.gbxChat.Controls.Add(this.btnSend);
            this.gbxChat.Controls.Add(this.ltbChatHistory);
            this.gbxChat.Location = new System.Drawing.Point(13, 193);
            this.gbxChat.Name = "gbxChat";
            this.gbxChat.Size = new System.Drawing.Size(386, 270);
            this.gbxChat.TabIndex = 2;
            this.gbxChat.TabStop = false;
            this.gbxChat.Text = "Messagerie";
            // 
            // ltbChatHistory
            // 
            this.ltbChatHistory.BackColor = System.Drawing.SystemColors.InfoText;
            this.ltbChatHistory.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltbChatHistory.ForeColor = System.Drawing.SystemColors.Window;
            this.ltbChatHistory.FormattingEnabled = true;
            this.ltbChatHistory.Location = new System.Drawing.Point(17, 23);
            this.ltbChatHistory.Name = "ltbChatHistory";
            this.ltbChatHistory.Size = new System.Drawing.Size(354, 173);
            this.ltbChatHistory.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(296, 202);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 62);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Envoyer";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // tbxMessage
            // 
            this.tbxMessage.Location = new System.Drawing.Point(17, 203);
            this.tbxMessage.Multiline = true;
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.Size = new System.Drawing.Size(273, 61);
            this.tbxMessage.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 475);
            this.Controls.Add(this.gbxChat);
            this.Controls.Add(this.lblConnexionStatus);
            this.Controls.Add(this.gbxConnexion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Chat XMPP";
            this.gbxConnexion.ResumeLayout(false);
            this.gbxConnexion.PerformLayout();
            this.gbxChat.ResumeLayout(false);
            this.gbxChat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxConnexion;
        private System.Windows.Forms.Button btnConnexion;
        private System.Windows.Forms.TextBox tbxServer;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblConnexionStatus;
        private System.Windows.Forms.GroupBox gbxChat;
        private System.Windows.Forms.ListBox ltbChatHistory;
        private System.Windows.Forms.TextBox tbxMessage;
        private System.Windows.Forms.Button btnSend;
    }
}

