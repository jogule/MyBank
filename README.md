# MyBank
MyBank: simple toy app to teach through a hands-on experience modern cloud information technologies to CxOs (specifically in the Banking Industry)
MyBank is key to desmitify IT for non-technical people using domain specific language (i.e. Financial/Business Terminology).
MyBank focus on learning (experience) the essentials modern IT concepts from the perspective of a brand new agile team in charge to develop and operate an innovative portfolio of digital data-driven products/services for a potential DX-disrupted company.

MyBank embrace Digital Transformation (DX) factors (trends, assumptions) with high odds to disrupt traditional Banking incumbents:
  - Macrotrends:
    - (R&D + Marketing) $ over (Production + Distribution) $ 
    - Demand Aggregation over Offer Aggregation
    - Huge subserved (CX) users from Traditional Banking 
  - Team Imperatives:
    - Customer Experience (CX) as Ultimate Competitive Advantange (profitable niche demand aggregation)
    - Data + Internet over Physical
    - Trust + Agility over Control
    - Culture + People over Processes + Machines

## MyBank v1.0.0: Quick PoC to replicate existing service

### Essential Services (Functions):
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
    
### Essential Concepts (Data):
    - Account:
      - Id: <guid>
      - Balance : 0 (default) | <number> > 0
      - Status : Active (default) | Inactive
      - UserId : <guid> | <email>
      - UserKey : <secret>
    - Token: Unique authenticable value representation (i.e. Bank Check)

### Business Critical Success Factors (Assumptions/Warranties):
    - MyBank is able to authenticate all user's request using a secret
      - The secret is known exclusively by the User
    - Cannot withdraw > Balance
    - Deposit requires a valid Token representing the Credited ammount
    - Withdraw returns a valid Token representing the Debited ammount
    - Tokens are Payable and Receivable goods for MyBank
    - Tokens are unique and cannot be duplicated

### Project Status
    - Current Iteration: v1.0.0 Quick PoC/Pilot/Prototype to replicate existing service
      - TODO: Process: Finish to implement a DevOps CI/CD pipeline based on containers
      - TODO: Functional: (UserStory) ShowAccount
      - TODO: Functional: Persist State (Define storage)
      - TODO: Non-Functional: (SW Architecture/Manteanability) Separation of Concerns (stateless from stateful) /Refactoring
      - TODO: QA: Bugs fixes
    - Roadmap (Backlog)
      - TODO: Process: Improve DevOps Velocity + Trust
      - TODO: Functional: UserStories: Deposit, Withdraw, CloseAccount
      - TODO: Non-Functional: Scalability; Availabilit, Costs, Reliability, Security, Performance, Operational Excellence
      - TODO: QA: Hot/Bug fixes

### MyBank Product Team principles
  - Re-design the banking Customer Experience (CX) from scratch leveraging all the potential of modern cloud tech, challenging all current assumptions
  - Leverage all current assets
  - Be agile to learn and adapt quick
  - Leverage CX data from the service usage to continously improve the same CX
  - First Simple Then Complex
  - Bias for Open Source
  - Bias for Enterprise vendors
    - integrated, interoperable, back-compatible, LTS, category-leader, hybrid, multi-cloud, secure/trusted
  - Bias for action
  - Modern Team qualities:
    - Individual
      - Purposefulnes/Intentionality/Proactivity/Leadership (Clarity, Energy, Results)
      - Creative/Openess/Growth Mindset/Range/Able to has two apparent contradictory ideas at the same time and sintetize something innovative
      - Generosity as ultimate purpose of a social individual
      - Commited/Accountable (your key individual accomplisments that contribute to team, business and customer results)
      - Trusted
    - Team
      - Distributed
      - Multidiciplinary/Diverse/Inclusive
      - Collaborative (how you contibute to success of others, your results that builds on the work or ideas of others)
      - Interdependency-based Trust (over Dependency-based Trust)
      - Shared-Leadership 
      - Organic/Flexible/Self 
