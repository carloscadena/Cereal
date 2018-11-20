# Mike's Cereal Shack'
## Introduction 
We sell cereal. All the varieties you could want. Some items will only be accessible if you have a specific email or employee id (coming later). 

## Claims
* We capture Email and FullName Claims. We use the full name to display a greeting to a logged in user. We actually to determine if the user is an employee that should get discounts.

## Policy
* We have a role based policy to identify admin users.
* We have a claim based policy to determine if a user's email contains a domain that would indicate that they are an employee. This claim allows a user access to an employee view that displays cereals on discount.

## Deployed Site
https://mikescerealshack.azurewebsites.net/