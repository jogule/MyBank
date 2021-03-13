# MyBank
MyBank CLI: simple console toy app to teach information technologies aimed to Banking Industry, 
specially CxOs. MyBank is key to desmitify IT for non-technical people using domain specific concepts (i.e. Financial language).

MyBank is an example on how DX can disrupt traditional Banking based on following assumptions:
- Macrotrends:
  - R&D + Marketing $ over Production + Distribution $ 
  - Demand Aggregation over Offer Aggregation
- Company Imperatives:
  - Customer Experience (CX) over Any Else
  - Data + Internet over Physical
  - Trust + Agility over Control
  - Culture + People over Processes + Machines

## MyBank v1.0.0
### Services:
    OpenAccount(<email>) : creates a new Account 
    { 
      Id: <guid>, //[auto-generated]
      Balance: 0, //Default
      Status: Active, //Default
      UserId: <email>, //[given]
      UserKey: <secret> //[auto-generated]
    }
    ShowAccount(<accountId>, <secret>) : gets Account's details
    { 
      Id: <accountId>, 
      Balance: 0, 
      Status: Active, 
      UserId: <email>
    }
    DepositToAccount(<accountId>, <ammount>, <secret>, <token>): credits Account's balance by given ammount
    { 
      Id: <accountId>, 
      Balance: <currentBalance> + <ammount>
    }
    WithdrawFromAccount(<accountId>, <ammount>, <secret>): debits Account's balance by given ammount
    { 
      Id: <accountId>, 
      Balance: <currentBalance> - <ammount>
      Token: <token>
    }
    CloseAccount(<accountId>, <secret>) : deactivate an existing Account
    { 
      Id: <accountId>, 
      Status: Inactive //set Status to Inactive
    }
    
### Concepts:
    - Account:
      - Id: <guid>
      - Balance : 0 (default) | <number> > 0
      - Status : Active (default) | Inactive
      - UserId : <guid> | <email>
      - UserKey : <secret>
    - Token: Unique authenticable value representation (i.e. Bank Check)

### Business Critical Assumptions:
    - MyBank is able to authenticate all user's request using a secret
      - The secret is known exclusively by the User
    - Cannot withdraw > Balance
    - Deposit requires a valid Token representing the Credited ammount
    - Withdraw returns a valid Token representing the Debited ammount
    - Tokens are Payable and Receivable goods for MyBank
    - Tokens are unique and cannot be duplicated
