---
sidebar_position: 1
---

# Partner API Introduction

Let's discover **Partner API in less than 5 minutes**.

## Getting Started

Most of your work with the API occurs via HTTP requests. What we call the *High Level request flow* is the basis
of every Kiva Partner Integration:

### High Level request flow
Partner request/post to new versioned url

`/partners/v1/id/#command`

### Secure Access
The Kiva Partner API is secure by the greated Marketplace API Gateway. A qualified partner application secret must be 
obtained and provided in order to get a valid API token.

In addition to a valid token. Every request should come with specialized headers. Like partner ID and user ID. 
Requests without these attributes will be ignored by the gateway.
