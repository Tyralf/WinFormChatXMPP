# Chat multi-instances avec XMPP et MQTT

Une application Windows Forms simple permettant de créer un chat en temps réel entre plusieurs utilisateurs, combinant XMPP pour l'authentification et MQTT pour la diffusion des messages.

## Fonctionnalités

- Authentification des utilisateurs via XMPP (Openfire)
- Diffusion des messages via MQTT (Mosquitto)
- Interface utilisateur intuitive avec historique des messages
- Support de multiples instances connectées simultanément

## Prérequis

- Docker Desktop pour les serveurs XMPP et MQTT
- .NET Framework
- Licences d'essai pour IPWorks et IPWorksIoT

## Configuration

### Configuration d'Openfire (XMPP)

```bash
docker run -d --name openfire -p 9090:9090 -p 5222:5222 -p 5269:5269 quantumobject/openfire
```

Accédez à l'interface d'administration (http://localhost:9090) et créez des utilisateurs pour les tests.

### Configuration de Mosquitto (MQTT)
Créez un fichier mosquitto.conf contenant :
```bash
listener 1883
allow_anonymous true
```

Puis lancez le conteneur :

```bash
docker run -d --name mosquitto -p 1883:1883 -v /chemin/vers/mosquitto.conf:/mosquitto/config/mosquitto.conf eclipse-mosquitto
```

## Utilisation

- Lancez plusieurs instances de l'application
- Connectez-vous avec différents comptes utilisateurs
- Commencez à échanger des messages en temps réel

## Architecture

L'application utilise une architecture à deux couches :

- XMPP gère l'authentification et la vérification des identifiants
- MQTT gère la diffusion efficace des messages entre les instances

Cette architecture reflète les pratiques utilisées dans des systèmes industriels.

## Dépendances

- IPWorks pour la communication XMPP
- IPWorksIoT pour la communication MQTT
