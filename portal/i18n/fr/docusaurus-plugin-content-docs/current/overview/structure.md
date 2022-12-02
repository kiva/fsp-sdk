---
sidebar_position: 2
---

# Structure de l'intégration


L'API Kiva est destinée à connecter le SIG d'un partenaire directement à PA2. Il peut être utilisé pour publier automatiquement des prêts ou signaler des remboursements. Les principaux avantages de l'utilisation de l'API sont un gain de temps pour les partenaires et une meilleure précision des informations introduites dans PA2.

Vous trouverez ci-dessous les étapes à effectuer pour intégrer l'API Kiva :
1. Mise à jour du SIG pour envoyer des informations aux points de terminaison Kiva au format JSON. L'API Kiva est configurée comme un point de terminaison qui accepte les données dans un format spécifique utilisant JSON. Pour commencer à utiliser notre API, le partenaire doit configurer son SIG pour envoyer des informations au point de terminaison de Kiva dans ce format.
2. Authentification du SIG sur le client de l'API Kiva. Kiva utilise un token OAuth2 pour l'authentification. Notez que vous devrez créer un système qui demande automatiquement un token à Kiva et s'authentifie toutes les 12 heures.
3. Vérifier la connexion de l'API en envoyant des projets de prêts et des rapports de remboursement à PA2 pour que Kiva les examine.
4. Formation pour le coordinateur Kiva sur l'utilisation de l'API.
5. Une fois que vos tests ont été vérifiés par Kiva, changez vos informations d'identification pour commencer à publier directement sur PA2.

## Options de structuration pour l'intégration
Kiva a créé une API REST. Pour pouvoir utiliser l'API, vous devez développer une intégration capable d'envoyer une requête à une URL spécifique avec des informations au format JSON que nous avons décrit ci-dessous. Il y a de nombreuses façons de structurer ceci en fonction de votre SIG et de la façon dont vous stockez les données de prêt. Voici quelques idées sur la façon dont il pourrait être structuré :
* Si vous avez le contrôle de votre code SIG, vous pouvez le modifier directement et le connecter à l'API.  
* Si votre SIG dispose d'un complément de plug-in, vous pouvez créer un plug-in pour envoyer des données JSON à l'API Kiva.
* Si vous disposez d'un serveur SQL ou d'un autre type de base de données et que vous souhaitez le connecter à l'API Kiva au lieu de votre SIG, vous pouvez créer une application autonome qui envoie les données au format JSON directement à l'API Kiva.
* Si vous disposez d'une base de données Excel, une macro pourrait la traduire au format JSON et envoyer les informations à l'API de Kiva.

Nous voulons fournir à votre équipe technique quelques informations sur les trois processus que l'API automatisera. Vous trouverez des informations sur les rapports de remboursements, le processus de création de projets de prêts individuels et de groupes et l'enregistrement des suivis dans cette section du Centre d'assistance aux partenaires. Nous recommandons également à votre équipe technique de consulter le coordinateur Kiva de votre organisation afin de bien comprendre ces processus Kiva.

