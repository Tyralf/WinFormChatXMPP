using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormChatXMPP.Services;

namespace WinFormChatXMPP
{
    public partial class MainForm : Form
    {
        private XMPPService xmppService;
        private MQTTService mqttService;
        public event EventHandler<bool> ConnectionStatusChanged;

        public MainForm()
        {
            InitializeComponent();

            // Initialiser le service XMPP
            xmppService = new XMPPService();
            xmppService.ConnectionStatusChanged += XmppService_ConnectionStatusChanged;
            xmppService.ErrorOccurred += XmppService_ErrorOccurred;

            // Initialiser le service MQTT
            mqttService = new MQTTService();
            mqttService.ConnectionStatusChanged += MqttService_ConnectionStatusChanged;
            mqttService.ErrorOccurred += MqttService_ErrorOccurred;
            mqttService.MessageReceived += MqttService_MessageReceived;

            // Initialiser le statut
            lblConnexionStatus.Text = "L'utilisateur est non connecté";
            lblConnexionStatus.ForeColor = Color.Red;

            // Utiliser un identifiant unique pour le fichier de log
            string uniqueIdentifier = DateTime.Now.ToString("yyyyMMddHHmmss"); // ou DateTime.Now.ToString("yyyyMMddHHmmss") pour un horodatage
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"app_{uniqueIdentifier}.log");
            FileStream fileStream = new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(fileStream) { AutoFlush = true };
            Console.SetOut(streamWriter);

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
                lblConnexionStatus.Text = $"{txtUsername.Text} est Connecté à XMPP";
                lblConnexionStatus.ForeColor = Color.Orange; // Orange pendant la connexion à MQTT
                btnConnect.Enabled = false;

                // Connecter au broker MQTT maintenant que XMPP est connecté
                ConnectToMqtt();
            }
            else
            {
                lblConnexionStatus.Text = "Non connecté";
                lblConnexionStatus.ForeColor = Color.Red;
                btnConnect.Text = "Se connecter";
                btnConnect.Enabled = true;

                // Déconnecter MQTT si connecté
                if (mqttService.IsConnected)
                {
                    mqttService.Disconnect();
                }
            }
        }

        private async void ConnectToMqtt()
        {
            try
            {
                // Paramètres du broker MQTT
                string mqttServer = "localhost"; // ou l'IP de votre broker MQTT
                int mqttPort = 1883;
                string clientId = txtUsername.Text; // Utiliser le même nom d'utilisateur comme clientId

                Console.WriteLine("Connecting to MQTT broker...");
                Console.WriteLine($"clientId is : {clientId}");
                bool success = await mqttService.Connect(mqttServer, mqttPort, clientId);

                if (success)
                {
                    Console.WriteLine("Connected to MQTT broker.");
                    lblConnexionStatus.Text = $"{txtUsername.Text} est Connecté";
                    lblConnexionStatus.ForeColor = Color.Green;
                    btnConnect.Text = "Déconnecter";
                    btnConnect.Enabled = true;

                    // Activer les contrôles de chat
                    gbxChat.Enabled = true;
                }
                else
                {
                    // Échec de connexion MQTT, déconnecter XMPP aussi
                    xmppService.Disconnect();
                    lblConnexionStatus.Text = "Échec de connexion MQTT";
                    lblConnexionStatus.ForeColor = Color.Red;
                    btnConnect.Text = "Se connecter";
                    btnConnect.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to MQTT: {ex.Message}");
                MessageBox.Show($"Erreur de connexion MQTT: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xmppService.Disconnect();
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
            mqttService.Disconnect();
            xmppService.Disconnect();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = tbxMessage.Text.Trim();

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            try
            {
                if (!xmppService.IsConnected || !mqttService.IsConnected)
                {
                    MessageBox.Show("Vous n'êtes pas connecté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Formater le message avec le nom d'utilisateur
                string formattedMessage = $"{txtUsername.Text} a dit: {message}";

                Console.WriteLine($"Publishing message: {formattedMessage}");

                // Publier le message sur MQTT
                bool sent = await mqttService.PublishMessage("chat/messages", formattedMessage);

                if (sent)
                {
                    // Ne pas ajouter le message à l'historique ici, il sera reçu par l'événement MessageReceived
                    tbxMessage.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error publishing message: {ex.Message}");
                MessageBox.Show($"Erreur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddMessageToHistory(string message)
        {
            // Si vous utilisez une ListBox pour afficher l'historique
            ltbChatHistory.Items.Add(message);

            // Faire défiler vers le bas pour voir le dernier message
            ltbChatHistory.SelectedIndex = ltbChatHistory.Items.Count - 1;
        }

        private void MqttService_ConnectionStatusChanged(object sender, bool connected)
        {
            // S'assurer que nous sommes sur le thread UI
            if (InvokeRequired)
            {
                Invoke(new Action(() => MqttService_ConnectionStatusChanged(sender, connected)));
                return;
            }

            if (!connected && xmppService.IsConnected)
            {
                // Si MQTT se déconnecte mais XMPP est encore connecté, déconnecter XMPP aussi
                xmppService.Disconnect();
            }
        }

        private void MqttService_ErrorOccurred(object sender, string errorMessage)
        {
            // S'assurer que nous sommes sur le thread UI
            if (InvokeRequired)
            {
                Invoke(new Action(() => MqttService_ErrorOccurred(sender, errorMessage)));
                return;
            }

            Console.WriteLine($"MQTT Error: {errorMessage}");
            MessageBox.Show($"Erreur MQTT: {errorMessage}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MqttService_MessageReceived(object sender, string message)
        {
            // S'assurer que nous sommes sur le thread UI
            if (InvokeRequired)
            {
                Invoke(new Action(() => MqttService_MessageReceived(sender, message)));
                return;
            }
            AddMessageToHistory(message);
        }

        public void CheckConnectionStatus()
        {
            if (!xmppService.IsConnected)
            {
                // Déconnecter également MQTT si XMPP est déconnecté
                mqttService.Disconnect();

                // Notifier l'interface utilisateur
                ConnectionStatusChanged?.Invoke(this, false);
            }
        }
    }
}
