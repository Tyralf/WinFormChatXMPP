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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblConnexionStatus = new System.Windows.Forms.Label();
            this.gbxChat = new System.Windows.Forms.GroupBox();
            this.tbxMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.ltbChatHistory = new System.Windows.Forms.ListBox();
            this.gbxConnexion.SuspendLayout();
            this.gbxChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxConnexion
            // 
            this.gbxConnexion.Controls.Add(this.txtPassword);
            this.gbxConnexion.Controls.Add(this.txtUsername);
            this.gbxConnexion.Controls.Add(this.lblPassword);
            this.gbxConnexion.Controls.Add(this.lblUsername);
            this.gbxConnexion.Controls.Add(this.btnConnect);
            this.gbxConnexion.Location = new System.Drawing.Point(13, 13);
            this.gbxConnexion.Name = "gbxConnexion";
            this.gbxConnexion.Size = new System.Drawing.Size(386, 120);
            this.gbxConnexion.TabIndex = 0;
            this.gbxConnexion.TabStop = false;
            this.gbxConnexion.Text = "Connexion";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(107, 59);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(264, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(107, 26);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(264, 20);
            this.txtUsername.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(14, 62);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(71, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Mot de passe";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(14, 29);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(53, 13);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Identifiant";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(240, 85);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(131, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Se Connecter";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblConnexionStatus
            // 
            this.lblConnexionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConnexionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnexionStatus.ForeColor = System.Drawing.Color.Red;
            this.lblConnexionStatus.Location = new System.Drawing.Point(-1, 136);
            this.lblConnexionStatus.Name = "lblConnexionStatus";
            this.lblConnexionStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblConnexionStatus.Size = new System.Drawing.Size(400, 12);
            this.lblConnexionStatus.TabIndex = 1;
            this.lblConnexionStatus.Text = "Deconnecté";
            this.lblConnexionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbxChat
            // 
            this.gbxChat.Controls.Add(this.tbxMessage);
            this.gbxChat.Controls.Add(this.btnSend);
            this.gbxChat.Controls.Add(this.ltbChatHistory);
            this.gbxChat.Location = new System.Drawing.Point(13, 151);
            this.gbxChat.Name = "gbxChat";
            this.gbxChat.Size = new System.Drawing.Size(386, 329);
            this.gbxChat.TabIndex = 2;
            this.gbxChat.TabStop = false;
            this.gbxChat.Text = "Messagerie";
            // 
            // tbxMessage
            // 
            this.tbxMessage.Location = new System.Drawing.Point(17, 262);
            this.tbxMessage.Multiline = true;
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.Size = new System.Drawing.Size(273, 61);
            this.tbxMessage.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(296, 262);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 62);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Envoyer";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // ltbChatHistory
            // 
            this.ltbChatHistory.BackColor = System.Drawing.SystemColors.InfoText;
            this.ltbChatHistory.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltbChatHistory.ForeColor = System.Drawing.SystemColors.Window;
            this.ltbChatHistory.FormattingEnabled = true;
            this.ltbChatHistory.Location = new System.Drawing.Point(17, 23);
            this.ltbChatHistory.Name = "ltbChatHistory";
            this.ltbChatHistory.Size = new System.Drawing.Size(354, 225);
            this.ltbChatHistory.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 492);
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

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxConnexion;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblConnexionStatus;
        private System.Windows.Forms.GroupBox gbxChat;
        private System.Windows.Forms.ListBox ltbChatHistory;
        private System.Windows.Forms.TextBox tbxMessage;
        private System.Windows.Forms.Button btnSend;
    }
}

