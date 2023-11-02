<br/>
<p align="center">
  <h3 align="center">FlowerSpot API</h3>
</p>

### Installation

1. Create a database called `FlowerSpotDb` in pgAdmin.

2. Copy the connection string to `FlowerSpotConnectionString` in `appsettings.development.json`.

3. Start the API and the migrations will be applied automatically.


### Usage

1. Create a new user through Swagger with the Register method. Remember your username and password.

2. Login with your username/password with the Login method, and you will receive a JWT token as a response.

3. Click on the Authorize button and paste your JWT token to become authorized.