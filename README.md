# Running the Applications

Be sure to be in the root project folder to run any of the commands.

Run the following command to start the apps:
`docker compose up -d --build`

The database will be created if non-existent, and reset with default init data in every start.

Follow the logs of the apps:
`docker compose logs -f`


Run the following command to stop the apps:
`docker compose down`

- The database is stored in 'Database/data' directory.