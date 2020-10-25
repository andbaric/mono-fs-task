# Project MVC routes
Based on ASP.NET Core API (Project.MVC/Controllers)  
**API routes:**  
  *Route structure logic: {apiPrefix}/{controller}*
  

* Public:  

  ## **AdministrationController routes**:  
  route base: **api/administration**  

  ### 1. **Makes**  
     *  Create  
        method: **POST**   
        route: 
        > api/administration/makes  

        <u>**request**</u>: Body: JSON object
        ```
        {
          "name": string,
          "abrv": string,
          "id"?: int
        }
        ```

        <u>**response**</u>: Status: 200 OK, data type: JSON created object
        ```
        {
          "name": string,
          "abrv": string,
          "id": int
        }
        ```  

    * Read  
      * One make  
        method: **GET**  
        route: 
          > api/administration/{makeId}

          <u>**request**</u>:
          ```
          api/administration/{makeId}
          ```

          <u>**response**</u>: Status: 200 OK, JSON object
          ```
          {
            name: string,
            abrv: string,
            id: {makeID} int
          }
          ```

      *  All makes  
          method: **GET**  
          route:
            > api/administration/makes

            <u>**request**</u>: 
            ```
            api/administration/makes
            ``` 
            <u>**response**</u>:  
            * Status: 200 OK, data type: JSON object array
              ```
              [
                {
                  "name": string,
                  "abrv": string,
                  "id": int
                }, ...
              ]
              ```

    * Update  
      method: **PATCH**  
      route: 
        > api/administration/makes/{makeId}

        <u>**request**</u>: JSON obj ('value" and "path" required, op - option(add, replace...) optional)
        ```
        [
          {
            "value": "{newValue}" string,
            "path": "/{attrToChange} string"
          }
        ]
        ```
        <u>**response**</u>: 200 OK, new JSON object
        ```
        {
          "name": string,
          "abrv": string,
          "id": int
        }
        ```
          

    * Delete make  
      method: **DELETE**  
      route: 
        > api/administration/makes/{makeId}

      <u>**request**</u>: 
      ```
      api/administration/makes/{makeId}
       ```

      <u>**response**</u>: deleted JSON object
      ```
      {
        "name": string,
        "abrv": string,
        "id": int
      }
      ```
    ---
    Allowed url queryes (Through the OData)
    * Sort  
      *Sorted makes list, allowed sort by properties: Name and Abrv*  
      * Sort by Name  
        method: **GET**  
        params: key = $orderby value = name  
        route:
        > api/administration/makes?$orderby=name

          <u>**request**</u>: 
          ```
          api/administration/makes?$orderby=name
          ```

          <u>**response**</u>:  
          * Status: 200 OK, data type: JSON object array sorted by name

          ```
          [
            {
              "name": string,
              "abrv": string,
              "id": int
            }, ...
          ]
          ```
      * Sort by Abrv  
        method: **GET**  
        params: key = $orderby value = abrv  
        route:
        > api/administration/makes?$orderby=abrv

          <u>**request**</u>: 
          ```
          api/administration/makes?$orderby=abrv
          ```

          <u>**response**</u>:  
          * Status: 200 OK, data type: JSON object array sorted by abrv

          ```
          [
            {
              "name": string,
              "abrv": string,
              "id": int
            }, ...
          ]
          ```  


  

---
### 2. **Models**  
  * Create  
    method: **POST**   
    route: 
    > api/administration/models  

    <u>**request**</u>: Body: JSON object
    ```
    {
      "name": string,
      "abrv": string,
      "id"?: int
    }
    ```

    <u>**response**</u>: Status: 200 OK, data type: JSON created object
    ```
    {
      "name": string,
      "abrv": string,
      "makeId": {makeId} int,
      "id": {modelId} int
    }
    ```  

    * Read  
      * One model  
        method: **GET**  
        route: 
          > api/administration/{modelId}

          <u>**request**</u>:
          ```
          api/administration/{modelId}
          ```

          <u>**response**</u>: Status: 200 OK, JSON object
          ```
          {
            "name": string,
            "abrv": string,
            "makeId": {makeId} int,
            "id": {modelId} int
          }
          ```

      *  All models  
          method: **GET**  
          route:
            > api/administration/models

            <u>**request**</u>: 
            ```
            api/administration/models
            ``` 
            <u>**response**</u>:  
            * Status: 200 OK, data type: JSON object array
              ```
              [
                {
                  "name": string,
                  "abrv": string,
                  "makeId": {makeId} int,
                  "id": {modelId} int
                }, ...
              ]
              ```

    * Update  
      method: **PATCH**  
      route: 
        > api/administration/models/{modelId}

        <u>**request**</u>: JSON obj ('value" and "path" required, op - option(add, replace...) optional)
        ```
        [
          {
            "value": "{newValue}" string,
            "path": "/{attrToChange} string"
          }
        ]
        ```
        <u>**response**</u>: new JSON object
        ```
        {
          "name": string,
          "abrv": string,
          "makeId": {makeId} int,
          "id": {modelId} int
        }
        ```
          

    * Delete  
      method: **DELETE**  
      route:  
        > api/administration/models/{modelId}

      <u>**request**</u>: 
      ```
      api/administration/models/{modelId}
      ```
      <u>**response**</u>: deleted JSON object
      ```
      {
        "name": string,
        "abrv": string,
        "makeId": {makeId} int,
        "id": {modelId} int
      }
      ```
    ---
    Allowed url queryes (Through the OData)
    * Sorted makes list, allowed sort by properties: Name and Abrv  
      * Sort by Name  
        method: **GET**  
        params: key = $orderby value = name  
        route:
        > api/administration/makes?$orderby=name

          <u>**request**</u>: 
          ```
          api/administration/makes?$orderby=name
          ```

          <u>**response**</u>:  
          * Status: 200 OK, data type: JSON object array sorted by name

          ```
          [
            {
              "name": string,
              "abrv": string,
              "makeId": {makeId} int,
              "id": {modelId} int
            }, ...
          ]
          ```
      * Sort by Abrv  
        method: **GET**  
        params: key = $orderby value = abrv  
        route:
        > api/administration/makes?$orderby=abrv

          <u>**request**</u>: 
          ```
          api/administration/makes?$orderby=abrv
          ```

          <u>**response**</u>:  
          * Status: 200 OK, data type: JSON object array sorted by abrv

          ```
          [
            {
              name: string,
              abrv: string,
              id: int
            }, ...
          ]
          ```          
        * Sorted makes list, allowed sort by properties: Name and Abrv  
      * Sort by Name  
        method: **GET**  
        params: key = $orderby value = name  
        route:
        > api/administration/makes?$orderby=name

          <u>**request**</u>: 
          ```
          api/administration/makes?$orderby=name
          ```

          <u>**response**</u>:  
          * Status: 200 OK, data type: JSON object array sorted by name

          ```
          [
            {
              name: string,
              abrv: string,
              id: int
            }, ...
          ]
          ```
      * Sort by Abrv  
        method: **GET**  
        params: key = $orderby value = abrv  
        route:
        > api/administration/makes?$orderby=abrv

          <u>**request**</u>: 
          ```
          api/administration/makes?$orderby=abrv
          ```

          <u>**response**</u>:  
          * Status: 200 OK, data type: JSON object array sorted by abrv

          ```
          [
            {
              name: string,
              abrv: string,
              id: int
            }, ...
          ]
          ```
