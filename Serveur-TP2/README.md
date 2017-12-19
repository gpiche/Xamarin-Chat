## Solutions VS2017
Deux solutions: Clients et Services

Inspiré du tutoriel https://identityserver4.readthedocs.io/en/release/quickstarts/1_client_credentials.html
### Clients
* Mobile: application mobile (communique avec les conteneurs dockers).
### Services
* IdentityServer
* Api: permet de tester l'autorisation qui se fait avec un token
 
## Configuration
#### Émulateur/Sans émulateur
L'application mobile (client) doit communiquer avec le serveur. 
* Si l'application s'exécute dans l'émulateur, il n'y a pas de configuration particulière à mettre en place: l'émulateur à un accès à l'IP sur lequel il est exécuté. 
* Si l'application s'exécute sur un appareil mobile branché (usb ou wifi), alors il faut configurer l'environnement pour que ce périphérique puisse communiquer avec le serveur. 
 
 
#### Utilisation en localhost (sans Docker)
L'application mobile ne peut se connecter à localhost. Elle est programmer pour se connecter aux dockers (192.168.99.100).

Pour déboguer les projets "servcies", utiliser l'application console ou faire des requêtes avec postman.
 
## Docker
#### Pour compiler les dockers:
```
$ docker-compose -f docker-compose.build.yml up
```
 
docker-compose.build.yml: Compile les projets (création de Dlls). Les Dlls sont ensuite utilisés pour la création des images dockers (voir les Dockerfiles)
 
#### Pour démarrer les dockers:
 
```
$ docker-compose build
$ docker-compose up
```
 
Build est nécessaire seulement si le contenu des Dockerfiles a changé.
 
#### Pour tester le docker de IdentityServer
http://192.168.99.100:5000/.well-known/openid-configuration
 