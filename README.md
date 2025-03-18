###Heading

```mermaid
graph TD;
    A[Client Application] -->|Queries| B[Discover Database];
    A -->|Queries| C[Staging Database];
    A -->|Queries| D[FNO Database];

    B -->|ETL Process| C;
    C -->|Data Processing| D;
```
