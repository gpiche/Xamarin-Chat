## Solutions VS2017
Deux solutions: Clients et Services

Inspir� du tutoriel https://identityserver4.readthedocs.io/en/release/quickstarts/1_client_credentials.html
### Clients
* Mobile: application mobile (communique avec les conteneurs dockers).
### Services
* IdentityServer
* Api: permet de tester l'autorisation qui se fait avec un token
 
## Configuration
#### �mulateur/Sans �mulateur
L'application mobile (client) doit communiquer avec le serveur. 
* Si l'application s'ex�cute dans l'�mulateur, il n'y a pas de configuration particuli�re � mettre en place: l'�mulateur � un acc�s � l'IP sur lequel il est ex�cut�. 
* Si l'application s'ex�cute sur un appareil mobile branch� (usb ou wifi), alors il faut configurer l'environnement pour que ce p�riph�rique puisse communiquer avec le serveur. 
 
 
#### Utilisation en localhost (sans Docker)
L'application mobile ne peut se connecter � localhost. Elle est programmer pour se connecter aux dockers (192.168.99.100).

Pour d�boguer les projets "servcies", utiliser l'application console ou faire des requ�tes avec postman.
 
## Docker
#### Pour compiler les dockers:
```
$ docker-compose -f docker-compose.build.yml up
```
 
docker-compose.build.yml: Compile les projets (cr�ation de Dlls). Les Dlls sont ensuite utilis�s pour la cr�ation des images dockers (voir les Dockerfiles)
 
#### Pour d�marrer les dockers:
 
```
$ docker-compose build
$ docker-compose up
```
 
Build est n�cessaire seulement si le contenu des Dockerfiles a chang�.
 
#### Pour tester le docker de IdentityServer
http://192.168.99.100:5000/.well-known/openid-configuration
 