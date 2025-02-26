using System;
using System.Threading.Tasks;
using nsoftware.IPWorks;

public class XMPPService
{
    private XMPP xmppClient;

    // Événements
    public event EventHandler<bool> ConnectionStatusChanged;
    public event EventHandler<string> ErrorOccurred;

    public XMPPService()
    {
        xmppClient = new XMPP();

        // Ajouter la licence d'essai
        xmppClient.RuntimeLicense = "31504E4A415A30323236323533305745425452314131004D4B4543485045524155554C4E484B57003030303030303030000057575241435342444B574B450000#IPWORKS#EXPIRING_TRIAL#20250328";

        // Configurer les handlers d'événements
        xmppClient.OnConnectionStatus += XmppClient_OnConnectionStatus;
        xmppClient.OnError += XmppClient_OnError;
    }

    public async Task<bool> Connect(string server, int port, string username, string password)
    {
        try
        {
            // Configurer les paramètres de connexion avec les noms corrects
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

    // Version générique des gestionnaires d'événements
    private void XmppClient_OnConnectionStatus(object sender, EventArgs e)
    {
        // Une version simple qui fonctionne avec n'importe quelle version
        Console.WriteLine("Statut de connexion changé");

        // Détermine si nous sommes connectés en vérifiant directement la propriété
        bool isConnected = xmppClient.Connected;
        ConnectionStatusChanged?.Invoke(this, isConnected);
    }

    private void XmppClient_OnError(object sender, EventArgs e)
    {
        // Version générique qui capturera toutes les erreurs
        // Nous essayons d'extraire le message d'erreur s'il y a une propriété pour cela
        string errorMessage = "Une erreur s'est produite avec la connexion XMPP";

        // Tentative d'obtenir le message d'erreur détaillé si disponible
        if (e is XMPPErrorEventArgs xmppError)
        {
            errorMessage = $"Erreur XMPP : {xmppError.Description}";
        }

        ErrorOccurred?.Invoke(this, errorMessage);
    }
}