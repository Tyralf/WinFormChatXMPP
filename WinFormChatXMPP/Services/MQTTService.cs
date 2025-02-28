using System;
using System.Threading.Tasks;
using nsoftware.IPWorksIoT;

namespace WinFormChatXMPP.Services
{
    public class MQTTService
    {
        private readonly MQTT mqttClient;
        private string lastReceivedMessage = "";

        // Événements pour notifier l'UI
        public event EventHandler<string> MessageReceived;
        public event EventHandler<bool> ConnectionStatusChanged;
        public event EventHandler<string> ErrorOccurred;

        public bool IsConnected => mqttClient?.Connected ?? false;

        public MQTTService()
        {
            mqttClient = new MQTT();

            // Ajout de la licence d'essai
            mqttClient.RuntimeLicense = "31304E4A415A30323237323533305745425452314131004F414F4F424D5257514142544A46494D003030303030303030000037574A58463043334358344E0000#IPWORKSIOT#EXPIRING_TRIAL#20250329";

            // Association des événements
            mqttClient.OnMessageIn += MqttClient_OnMessageIn;
            mqttClient.OnConnected += MqttClient_OnConnected;
            mqttClient.OnDisconnected += MqttClient_OnDisconnected;
            mqttClient.OnError += MqttClient_OnError;
        }

        public async Task<bool> Connect(string server, int port, string clientId)
        {
            try
            {
                if (IsConnected)
                {
                    ErrorOccurred?.Invoke(this, "Déjà connecté au serveur MQTT.");
                    return false;
                }

                mqttClient.ClientId = clientId;
                mqttClient.RemoteHost = server;
                mqttClient.RemotePort = port;

                Console.WriteLine($"Connecting to MQTT broker at {server}:{port}...");
                await Task.Run(() => mqttClient.Connect());

                if (IsConnected)
                {
                    Console.WriteLine("Connected to MQTT broker.");
                    await SubscribeToTopic("chat/messages", 1); // QoS 1 pour assurer la réception
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to MQTT: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Erreur de connexion MQTT: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SubscribeToTopic(string topic, int qosLevel = 0)
        {
            try
            {
                if (!IsConnected)
                {
                    ErrorOccurred?.Invoke(this, "Impossible de s'abonner: Non connecté.");
                    return false;
                }

                Console.WriteLine($"Subscribing to topic: {topic}");
                await Task.Run(() => mqttClient.Subscribe(topic, qosLevel));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error subscribing to topic: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Erreur d'abonnement: {ex.Message}");
                return false;
            }
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
                mqttClient.Disconnect();
                ConnectionStatusChanged?.Invoke(this, false);
            }
        }

        public async Task<bool> PublishMessage(string topic, string message, int qosLevel = 1)
        {
            try
            {
                if (!IsConnected)
                {
                    ErrorOccurred?.Invoke(this, "Impossible de publier: Non connecté.");
                    return false;
                }

                Console.WriteLine($"Publishing message to topic {topic}: {message}");
                await Task.Run(() => mqttClient.PublishMessage(topic, qosLevel, message));

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error publishing message: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Erreur de publication: {ex.Message}");
                return false;
            }
        }

        private void MqttClient_OnMessageIn(object sender, EventArgs e)
        {
            try
            {
                // Convertir EventArgs en type spécifique à MQTT
                dynamic mqttEventArgs = e;

                // Accéder aux propriétés documentées
                string topic = mqttEventArgs.Topic;
                string message = mqttEventArgs.Message;

                Console.WriteLine($"Received message from topic '{topic}':");
                Console.WriteLine(message);

                // Déclencher l'événement avec le message reçu
                if (!string.IsNullOrEmpty(message))
                {
                    MessageReceived?.Invoke(this, message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in OnMessageIn: {ex.Message}");
                ErrorOccurred?.Invoke(this, $"Erreur lors de la réception: {ex.Message}");
            }
        }

        private void MqttClient_OnConnected(object sender, EventArgs e)
        {
            Console.WriteLine("Connected to MQTT broker.");
            ConnectionStatusChanged?.Invoke(this, true);
        }

        private void MqttClient_OnDisconnected(object sender, EventArgs e)
        {
            Console.WriteLine("Disconnected from MQTT broker.");
            ConnectionStatusChanged?.Invoke(this, false);
        }

        private void MqttClient_OnError(object sender, EventArgs e)
        {
            Console.WriteLine("MQTT error occurred.");
            ErrorOccurred?.Invoke(this, "Une erreur s'est produite avec la connexion MQTT.");
        }
    }
}
