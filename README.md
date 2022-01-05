# Process Times

A NET WPF program to store and pull data from a local SQLite database.

Scenario: a shop makes two types of products, A and B. The user wants to:
1. Keep track of process times by entering how long each part takes to make (process time (float, < 10000) and product type (list item, A or B).
2. View past history with basic statistics: total count and average for each A, B and combined.
3. View each entry in a table as All Data.
4. (Testing feature) Generate Data Set to test app functionality - generates random combination of entries based on user inputs (number of entries to generate (int, < 10000), min and max (float, < 10000) for each A and B).

Key functionality (sample workflow):

1. UI responds to user inputs and communicates to App Manager (a single instance class serving as the main hub).
2. App Manager calls Data Validation to ensure user inputs are valid.
3. App Manager then calls DB Manager class to execute requested commands or returns to UI if invalid.
4. DB Manager writes or reads from the database and returns to App Manager.
5. Appmanager issues notification (success/fail) through Notifications class.