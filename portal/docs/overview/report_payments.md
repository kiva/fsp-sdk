---
sidebar_position: 6
---

# Using the API to report repayments
We recommend that your technical team consults with the Kiva Coordinator at your organization to fully understand Kiva's Repayment Reporting process. To do so, please have your technical team review the following:
* [This video](https://img.youtube.com/vi/KTgcTgjiX5A/0.jpg) provides a thorough explanation of the repayment reporting process.

Given that system performance is paramount to you and all of our partners, we recommend the total number of loans in your repayment report be divided into CSV files with a maximum of 200-300 loans each. Since each CSV is generated by a separate API call, this means each call should contain no more than 200-300 loans. In other words, the report should be split into several calls, each sending a JSON file with 200-300 loans.  

Even if your current portfolio has fewer than 200 or 300 loans, we suggest configuring the API to automatically split future reports into batches of 200-300 loans. This way, as your portfolio grows, you will be prepared to report large volumes without any issues.  

## Process
1. Repayment information sent from MIS to PA2 using the API
2. The person in charge of repayment reporting logs into PA2 where they review and finalize the report

## Additional information

For partners who use the two column format for repayment reporting and journaling, only the Loan ID (loan_id) is needed. For partners that use the three column format, both the Loan ID (loan_ID) and Client ID (client_ID) are needed. *(This can be checked by going to PA2 -> Account -> Profile -> CSV upload format)*

When testing the API connection for repayment reporting, please use information of a real client/borrower that has been posted to Kiva. Do not use the same client information used to post a test loan draft as PA2 will not register this borrower as being in "payingBack" status.
* To find an existing Kiva borrower, click on the “Repayments” tab in PA2 and then the blue number of expected loans. This will take you to a report of all Kiva clients for whom Kiva expects a repayment. Select any of the client and loan IDs for these clients to send via the API: ![repayments_expected.png](@site/static/img/repayments_expected.png)
* The amount reported should match what appears in your organization’s MIS.
* The Kiva Coordinator is still required to log into PA2 to finalize the repayment report.

To check if the JSON format you created is correct, you can use an online JSON validator like this one: https://jsonlint.com/.

## Technical documentation
All of Kiva's technical documentation, including endpoints, can be found here:
* Test environment (Stage): https://partner-api-stage.dk1.kiva.org/swagger-ui/
* Production (to use after testing): https://partner-api.k1.kiva.org/swagger-ui/
