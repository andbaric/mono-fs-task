# mono-fs-task project

## Project setup info
### GitHub repository  
  Is organized by SCRUM principles: SCRUM BOARD = GIT PROJECT BOARD and SCRUM TASK = GIT ISSUE  
    
  * PROJECT BOARD - **[mono-fs-task](https://github.com/andbaric/mono-fs-task/projects/1)**

    * Board column  
    Represents git issue lifecycle status
    1. Status: TO DO - contains all undone and new opend issues
    2. Status: SHORTLIST - contains shortlist of issues filtered for upcoming sprint and reopend issues
    3. Status: DOING - contains all current, working on issues
    4. Status: TESTING - contains all issues that are on testing
    5. Status: CODE REVIEW - contains issues ready for code review

  * ISSUE  
    * **[Labels](https://github.com/andbaric/mono-fs-task/labels)**  

      *Describes issue: priority, project affiliation, implementation type and issue type* 
      > <span style="color:red;">note:</span> *each issue should be labeld with all label types(PRIORITY, PROJECT and TYPE) by convention in their note*
      
      <br />

      * PRIORITY labels - describes project prioriti 1-4:  
        * CRITICAL - 4/4 priority, highly prioritized issue, this task needs to be done in order to implement other features depended on it
        * HIGH - 3/4 priority, this task  needs to be done before medium and low priority tasks
        * MEDIUM - 2/4 priority, this task needs to be done before low priority tasks
        * LOW - 1/4 priority, this task needs to be done after all higher priorities are cleaned up
        > <span style="color:red;">note:</span> *one per issue*

      <br />

      * PROJECT labels - describes project affiliation, this project is devided in 3 parts:  
      documentation, back-end and front-end  
        * BACK-END - referd to issues with back-end tasks (business logic, data manipulation, database communication...)
        * FRONT-END - referd to issues with frontend-end tasks (ui, data presentation...) 
        > <span style="color:red;">note:</span> *one per issue or both for global documentation*

      <br />
      
      * TYPE labels - describes issue type (founded bug or new project feature )
      Only one per issue.
        * DOCUMENTATION - referd to issues with documentation tasks (architecture,models, setup guides...)
        * BUG - issues that are describeing founded bug in project (usually prioritiezed with CRITICAL or HIGH priority labels)
        * FEATURE - referd to issues with back-end tasks (business logic, data manipulation, database communication...)
        > <span style="color:red;">note:</span> *one per issue*

      <br />

      * SPECIAL labels:
        * !STORYTASK - issue needs to be chunked in smaller tasks, issue pieces(commonly used in project planning for ideas or bigger picture, abstraction
        > <span style="color:red;">note:</span> *issue needs to be chunked in smaller pieces*

        *For e.g. : Implement Authentication !STORYTASK -> implement login screen, implement register screen, implement login model, implement register model... )*

      <br />
      
  * [BRANCHES](https://github.com/andbaric/mono-fs-task/branches)  
  
    *There are three main branches(protected) which are describeing aplication version in specific environment:* 

    1. Production(protected)  
      Application version in production

    2. Staging(protected)  
      Application version in similar environment like production used for real environment testing
    
    3. Development(default branch, protected)  
      Application version in development environment, mostly locally tested

      *There are more temporary branches created from **development** for each issue and merged back after pull request is code review*  

    Three types of temporary branches(prefixed by issue type) for e.g. :
      1. documentation/project-setup - for issue type DOCUMENTATION
      2. bug-fix/wrong-error-code-respose - for issue type BUG
      3. feature/admin-screen-view - for issue type FEATURE

      > Temporary branch nameing convention:  
      <span style="color:red;">issue-type/issue-short-description</span> 

    <br />

  * [MILESTONES](https://github.com/andbaric/mono-fs-task/milestones)  
    *Each milestone represents one sprint.  
    During the active sprint each sprint related issue should be in PROJECT COLUMN: 'Status: SHORTLIST'*

    Milestones are mostly weekly sprints created on SPM (Sprint planning meeting)

    <br />


  * WORKFLOW
    
    1. Create sprints(milestones) for the project implementation
    2. Creat issues for implementing milestone planned fetures
    3. Move issues for current sprint to SHORTLIST, assigne, estimate and label issues
    4. Move issue that you working on to DOING
    5. Pull current app version from development 
    6. Create temporary branch for target issue implementation
    7. After implementation refer to issue in commit mesage with convention  

        > git commit -m '#issueNumber (answer on 'this commit will')' 
        e.g. :  
        <code>git commit -m '#2 add git repository documentation'</code> 
    8. Push the changes and create merge reques.
    9. Fix potential code review remarks and push the changes with

       > git commit -m '#pullRequestNumber discussion resolve' 
        e.g. :  
        <code>git commit -m '#3 discussion resolve'</code> 
    10. Remove the temporary branch


### Project implemenation model
Project implementation and git milestones are based on waterfall model
1. **Requirements - Analysis - Environment setup - Design**  
   Project requirements and technologies are predefined, project implementation can start from:  
   * Environment setup: 
      - Git repository setup
      - Development environment setup

    * Design:
      - Software architecture
      - ER (Entity Relationship) model
      - Class diagram
      - UI design, mockups

2. **Coding/Testing**  
   Coding and testing are intertwining each other.  
   Each feature is tested after its code implementation.  
   * Coding/Testing:
      - Database implementation - Code First metologie, EF (Entity Framework) as ORM
      - API implementation -> back-end - RESTfull API - data first metologie
      - UI (User Interface) implementation -> front-end - MVC project


## Software architecture
Layered, N-Tier architectire with:
  1. Data Tier
  2. Logic Tier
  3. Presentation Tier

  *For more details read [software-architecture document](./documentation/software-architecture.md)*
