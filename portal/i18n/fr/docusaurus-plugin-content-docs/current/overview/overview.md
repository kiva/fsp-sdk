---
sidebar_position: 1
---

# Que fait l'API de Kiva ?
L'API Kiva est un outil qui permet de connecter le SIG d'un partenaire directement à PA2. Il peut être utilisé pour publier automatiquement des prêts ou rapporter des remboursements.
* **Publication des prêts** :  Un SIG contient généralement le nom de l'emprunteur, son sexe, l'ID du client, l'ID du prêt, le montant du prêt, la date de décaissement et le calendrier de remboursement. Pour publier un nouveau prêt dans Kiva, vous devez introduire manuellement toutes ces mêmes informations dans PA2. Grâce à l'API, le SIG peut envoyer ces informations directement à PA2 et créer un nouveau projet de prêt. Au lieu de devoir introduire manuellement toutes les informations relatives à un nouveau prêt, il ne vous restera plus qu'à réviser le projet et à le publier.
* **Rapport de remboursements** : Les informations de remboursements actualisées pour chaque emprunteur sont stockées dans le SIG. Grâce à l'API, ces informations peuvent être envoyées directement à PA2 chaque mois, ce qui élimine la nécessité de créer et de télécharger manuellement un fichier CSV. Le partenaire peut ensuite examiner et finaliser son rapport comme il le ferait normalement.
* **Publication des suivis** : Les nouvelles informations de suivi ou les mises à jour qui sont enregistrées dans le SIG d'un partenaire peuvent être envoyées directement à PA2 via l'API au lieu d'être téléchargées manuellement. Le partenaire devra examiner et confirmer toutes informations de suivi envoyées de son système interne.

## Avantages de l'utilisation de l'API de Kiva
Les principaux avantages de l'utilisation de l'API sont les suivants :
* **Économie de temps pour les partenaires**. L'API de Kiva réduisant la quantité d'informations à introduire manuellement dans PA2, le temps consacré précédemment à cette tâche se trouvera économisé.
* **Amélioration de la précision des informations** enregistrées dans PA2. La transmission manuelle des données est sujette à un risque d'erreur humaine. Grâce à l'API, les informations de PA2 peuvent coïncider exactement avec celles du SIG du partenaire.

## Témoignages de partenaires
Kiva a testé l'API avec Milaap, l'un de nos partenaires opérant en Inde, avec des résultats très positifs. Ils ont réduit le temps nécessaire à la publication d'un profil de 10-12 minutes à seulement 4 minutes. Milaap a utilisé environ deux semaines pour mettre en place et tester l'API. Voici ce qu'ils ont dit dans leurs propres mots : "La création de l'API a considérablement réduit le temps et les efforts que nous consacrons au téléchargement des profils..... Cela nous a permis de collecter plus de fonds en moins de temps. Elle libère également certaines ressources humaines, qui peuvent maintenant être utilisées pour d'autres activités.

## Comment puis-je commencer à utiliser l'API  de Kiva ?

L'API de Kiva est configurée comme un point de terminaison qui accepte les données dans un format spécifique utilisant JSON. Pour commencer à utiliser notre API, le partenaire doit configurer son SIG pour envoyer des informations au point de terminaison Kiva dans ce format.

Si vous êtes intéressé à rejoindre le projet API, veuillez remplir ce formulaire.

