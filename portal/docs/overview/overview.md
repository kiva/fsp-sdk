---
sidebar_position: 1
---

# Overview of Kiva's API

## What does Kiva’s API do?
Kiva’s API is a tool that can connect a Field Partner’s MIS directly to PA2. It can be used to automatically either post loans or report repayments.

* **Posting Loans**: An MIS typically stores the borrower’s name, gender, client ID, loan ID, loan amount, disbursement date, and repayment schedule. To post a new loan on Kiva, you need to enter all of this same information in PA2. Using the API, the MIS can send this information directly to PA2 and create a new loan draft. Instead of manually entering all the information for a new loan, someone now only needs to review the draft and publish it.
* **Reporting Repayments**: Actual repayment information for each borrower is stored in the MIS. With the API, this information can get sent directly to PA2 each month, which eliminates the needs to manually create and upload a CSV report. Then the Field Partner must review and finalize their report as they usually would.
* **Posting Journals**: Information for a new journal or any update that is stored within a partner’s MIS can be sent directly to PA2 via the API, instead of manually uploading each journal. The partner will need to review and confirm all journals sent from their internal system.
Benefits of Using Kiva’s API

## Benefits of Using Kiva's API

* **Saving Field Partners time**. Since the Kiva API reduces the amount of information that needs to be manually entered in PA2, the time previously spent doing this will be saved.
* **Improving the accuracy of the information entered in PA2**. Manual data entry is prone to human error. With the API, the information in PA2 can exactly match the information in the Field Partner’s MIS.

## Field Partner Testimonial

Kiva piloted the API with Milaap, one of our Field Partners working in India, with very positive results. They reduced the amount of time it takes to post one profile from 10-12 minutes to only 4 minutes. It took Milaap about two weeks to set up and test the API. Here’s what they had to say in their own words: 

> “Setting up the API has significantly reduced the time and effort put into uploading of profiles… This has allowed us to raise more funds in lesser amount of time. In addition to this, internal resources also get freed up and this time can be used for other activities.”

## How do I start using Kiva’s API?
Kiva’s API is set up as an endpoint that accepts data in a specific format using JSON. To begin using our API, the Field Partner needs to set up their MIS to send information to Kiva’s endpoint in this format.

If you are interested in integrating with the API, please complete this [form](https://kiva.tfaforms.net/107 "form").

