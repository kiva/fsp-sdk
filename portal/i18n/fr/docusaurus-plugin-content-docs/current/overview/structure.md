---
sidebar_position: 2
---

# Integration Structure

Kiva’s API is designed to connect a Field Partner’s MIS directly to PA2. It can be used to automatically either post loans or report repayments. The main benefits of using the API are __saving Field Partners time and improving the accuracy of the information entered in PA2__.



Here is the basic outline of what needs to be completed in order to integrate with Kiva’s API:

1. __Update__ your MIS to send information to Kiva’s endpoints in a JSON format. Kiva’s API is set up as an endpoint that accepts data in a specific format using JSON. To begin using our API, the Field Partner needs to set up their MIS to send information to Kiva’s endpoint in this format.
2. __Authenticate__ your MIS to Kiva’s API client. Kiva uses an OAuth2 token to authenticate. Note you will need to build a system that automatically requests a token from Kiva and authenticates on a 12 hour cadence
3. __Test__ the API connection by sending draft loans and repayments to PA2 for Kiva to review.
4. __Train__ your Kiva Coordinator on how to use the API
5. After your tests are verified by Kiva, __switch your credentials__ to begin posting directly to PA2!

## Options for structuring the integration
Kiva has set up a REST API. For you to use the API, you need to build an integration that can send a post request to a specific URL with information in the JSON format we’ve noted below. There are many different ways to structure this depending on your MIS and how you store loan data. Here are some ideas on how this could be structured:

* If you have control over the code of your MIS, you can edit your MIS’s code directly and connect it to the API.
* If your MIS has a plug-in feature, you can build a plug-in to send the JSON data to Kiva’s API.
* If you have a SQL server or another type of database and would like to connect it to Kiva’s API instead of your MIS, you can create a separate application that sends the data in JSON format directly to Kiva’s API.
* If you have an Excel database, a macro could translate it to JSON format and send the information to Kiva’s API.

We want to provide your technical team with some background information on the three processes that the API will automate. You can find information about repayment reporting, the process of creating individual and group loan drafts and journaling in this section of the Partner Help Center. We also recommend that your technical team consults with the Kiva Coordinator at your organization to fully understand these two Kiva processes.