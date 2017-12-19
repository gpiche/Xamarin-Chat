# TP2
TP2-Xamarin.Android-CI.json: "Build definition" à importer dans VSTS pour l'intégration continue.

#Connexion
Les deux utilisateurs valide sont a et b (le mot de passe est le nom d'utilisateur)

#Envoie des messages
Si le message est envoyé et recu depuis le même appareil il apparait en double... Je n'ai pas eu le temps de trouver une solution. Mais de deux appareil différent il agit de la bonne facons.

#UI Test
Le test d'interface qui vérifie que le message envoyé est accessible pour lui qui le recois peut ne pas fonctionner si il y a une liste de message en attente (qui aurais été envoyé avant de lancer le test et qui n'aurais pas été recus).
