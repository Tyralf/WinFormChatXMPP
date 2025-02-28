using System;
using System.Threading.Tasks;
using nsoftware.IPWorks;

public class XMPPService
{
    private XMPP xmppClient;

    // Événements
    public event EventHandler<bool> ConnectionStatusChanged;
    public event EventHandler<string> ErrorOccurred;
    public event EventHandler<MessageReceivedEventArgs> MessageReceived;
    public bool IsConnected => xmppClient.Connected;

    public class MessageReceivedEventArgs : EventArgs
    {
        public string From { get; set; }
        public string Message { get; set; }
    }

    public XMPPService()
    {
        xmppClient = new XMPP();

        // Ajouter la licence d'essai
        xmppClient.RuntimeLicense = "31504E4A415A30323236323533305745425452314131004D4B4543485045524155554C4E484B57003030303030303030000057575241435342444B574B450000#IPWORKS#EXPIRING_TRIAL#20250328";

        // Configurer les handlers d'événements
        xmppClient.OnConnectionStatus += XmppClient_OnConnectionStatus;
        xmppClient.OnError += XmppClient_OnError;
        xmppClient.OnMessageIn += XmppClient_OnMessageIn;
    }

    public async Task<bool> Connect(string server, int port, string username, string password)
    {
        try
        {
            // Configurer les paramètres de connexion
            xmppClient.IMServer = server;
            xmppClient.IMPort = port;
            xmppClient.User = username;
            xmppClient.Password = password;

            // Connexion asynchrone
            await Task.Run(() => xmppClient.Connect());

            // Si on arrive ici, c'est que la connexion a réussi
            ConnectionStatusChanged?.Invoke(this, true);
            return true;
        }
        catch (Exception ex)
        {
            // Notifier l'erreur
            ErrorOccurred?.Invoke(this, $"Erreur de connexion : {ex.Message}");
            ConnectionStatusChanged?.Invoke(this, false);
            return false;
        }
    }

    public void Disconnect()
    {
        if (xmppClient.Connected)
        {
            xmppClient.Disconnect();
            ConnectionStatusChanged?.Invoke(this, false);
        }
    }

    // Méthode pour envoyer un message
    public async Task<bool> SendMessage(string jabberId, string message)
    {
        try
        {
            // Utiliser SendMessage avec le bon format
            await Task.Run(() => {
                // Préparer le message XMPP avec JabberId et contenu
                string formattedJabberId = jabberId;

                // Vérifier si le JabberId contient déjà un domaine
                if (!formattedJabberId.Contains("@"))
                {
                    // Ajouter le domaine du serveur XMPP
                    formattedJabberId = $"{formattedJabberId}@{xmppClient.IMServer}";
                }

                // Utiliser la méthode SendMessage avec le JabberId complet
                xmppClient.SendMessage(formattedJabberId);

                // Définir le contenu du message via une propriété
                xmppClient.MessageText = message;
            });
            return true;
        }
        catch (Exception ex)
        {
            ErrorOccurred?.Invoke(this, $"Erreur d'envoi : {ex.Message}");
            return false;
        }
    }

    private void XmppClient_OnConnectionStatus(object sender, EventArgs e)
    {
        bool isConnected = xmppClient.Connected;
        ConnectionStatusChanged?.Invoke(this, isConnected);
    }

    private void XmppClient_OnError(object sender, EventArgs e)
    {
        string errorMessage = "Une erreur s'est produite avec la connexion XMPP";

        if (e is XMPPErrorEventArgs xmppError)
        {
            errorMessage = $"Erreur XMPP : {xmppError.Description}";
        }

        ErrorOccurred?.Invoke(this, errorMessage);
    }

    private void XmppClient_OnMessageIn(object sender, XMPPMessageInEventArgs e)
    {
        try
        {
            // Utiliser messageText au lieu de Message
            var args = new MessageReceivedEventArgs
            {
                From = e.From,
                Message = e.MessageText  // Utiliser messageText comme indiqué
            };

            MessageReceived?.Invoke(this, args);
        }
        catch (Exception ex)
        {
            ErrorOccurred?.Invoke(this, $"Erreur lors du traitement du message entrant : {ex.Message}");
        }
    }
}