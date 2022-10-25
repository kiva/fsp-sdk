---
sidebar_position: 3
---

# Using the API to post draft loans

We recommend that your technical team consults with the Kiva Coordinator at your organization to fully understand Kiva's Repayment Reporting process. To do so, please have your technical team review the following:

* This video provides a thorough explanation on how to post an individual loan
* This video provides a thorough explanation on how to post a group loan.
* Visit the New Loans section for more information, specifically 

Step 1: Description - Individual Loans and Step 1: Description - Group Loans
Process
Information for a new loan is sent from MIS to PA2 via the API
A draft profile is automatically created. Drafts can be viewed by clicking the “Drafts” link in the “Loans” box on the PA2 homepage.
Each draft must be reviewed and then published by a person.

### Additional information
Before the loan can be published, PA2 will run all of the same validation checks that it runs on loans posted without the API. All error messages will need to be resolved before the loan can be published.

It is fine if the API sends information for some but not all fields required to post a loan. For example, not all MIS's store Kiva-specific fields such as the borrower description or sector. While these fields are required to publish a loan on PA2, they are not required to be sent via the API. The information for these fields can be added manually after the draft loan has been created in PA2. Note that the more information you can send via the API, the more time savings the Kiva Coordinator will have.
Depending on if you are posting a group or individual loan, certain fields are not required. If the loan you are posting is an individual loan, and you send data that is specific to a group loan, PA2 will give you an error message and you will be unable to publish the loan.

If posting an individual loan, do not include any of the following fields. The following fields are required only when posting a group loan:

*Group_name:* this is the name of the group that will appear on Kiva.org.

*Internal_client_id:* this is the ID of each client represented within the group (for example, if a group has three members, each member might have their own client ID that should be listed here)

*Internal_loan_id:* this is the ID for each individual borrower's loan (for example, a member of the group might be taking out their third loan with the organization, and that loan might have a unique ID. Enter that ID here)

*Not_pictured:* use this field in case any borrower is listed in Step 1: Description does not appear in the photo

The borrower photo can be sent to PA2 as a URL. Repayment Schedules can be sent in several different formats. If you believe a format different from the one in the example below will work better for your organization, please let Kiva know and we will provide more information.

## Validation
To check if the JSON document you created is correct, you can use an online JSON validator like this one:  https://jsonlint.com/.

## Technical documentation
All of Kiva's technical documentation, including endpoints, can be found here:
Test environment (Stage): https://partner-api-stage.dk1.kiva.org/swagger-ui/
Production (to use after testing): https://partner-api.k1.kiva.org/swagger-ui/