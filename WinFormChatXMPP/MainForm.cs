using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormChatXMPP
{
    public partial class MainForm : Form
    {
        private XMPPService xmppService;

        public MainForm()
        {
            InitializeComponent();

            // Initialiser le service XMPP
            xmppService = new XMPPService();
            xmppService.ConnectionStatusChanged += XmppService_ConnectionStatusChanged;
            xmppService.ErrorOccurred += XmppService_ErrorOccurred;

            // Initialiser le statut
            lblConnexionStatus.Text = "L'utilisateur est non connecté";
            lblConnexionStatus.ForeColor = Color.Red;
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            // Récupérer les informations de connexion
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Validation basique
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Veuillez entrer un nom d'utilisateur et un mot de passe.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Désactiver le bouton pendant la connexion
            btnConnect.Enabled = false;
            lblConnexionStatus.Text = "Connexion en cours...";
            lblConnexionStatus.ForeColor = Color.Orange;

            // Paramètres du serveur (à ajuster selon votre configuration)
            string server = "localhost"; // ou l'IP de votre serveur Openfire
            int port = 5222;

            // Tentative de connexion
            bool success = await xmppService.Connect(server, port, username, password);

            if (!success)
            {
                // La notification d'erreur est gérée par l'événement ErrorOccurred
                btnConnect.Enabled = true;
                lblConnexionStatus.Text = "Échec de connexion";
                lblConnexionStatus.ForeColor = Color.Red;
            }
        }

        private void XmppService_ConnectionStatusChanged(object sender, bool connected)
        {
            // S'assurer que nous sommes sur le thread UI
            if (InvokeRequired)
            {
                Invoke(new Action(() => XmppService_ConnectionStatusChanged(sender, connected)));
                return;
            }

            if (connected)
            {
                lblConnexionStatus.Text = $"{txtUsername.Text} est Connecté";
                lblConnexionStatus.ForeColor = Color.Green;
                btnConnect.Text = "Déconnecter";
                btnConnect.Enabled = true;

                // Vous pourriez activer d'autres contrôles ici
            }
            else
            {
                lblConnexionStatus.Text = "Non connecté";
                lblConnexionStatus.ForeColor = Color.Red;
                btnConnect.Text = "Se connecter";
                btnConnect.Enabled = true;
            }
        }

        private void XmppService_ErrorOccurred(object sender, string errorMessage)
        {
            // S'assurer que nous sommes sur le thread UI
            if (InvokeRequired)
            {
                Invoke(new Action(() => XmppService_ErrorOccurred(sender, errorMessage)));
                return;
            }

            lblConnexionStatus.Text = "Erreur";
            lblConnexionStatus.ForeColor = Color.Red;
            MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Déconnexion propre à la fermeture
            xmppService.Disconnect();
        }
    }
}
