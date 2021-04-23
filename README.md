# Dotnet Calculator

## Installation

1. Clone the Repo

2. Generate Kestrel Cert
    Go to the ```DotnetCal``` directory, generate the cert

    ```
    dotnet dev-certs https -ep \https\aspnetapp.pfx -p {password of your choice}
    ```
    
    Password default to ```secret```, change it as you please. But remember to change it on ```docker-compose``` as well 

    However, for the sake of quick demo of this application, https redirection has been commented out. Use ```http://localhost:5000``` for the dotnet server API call. 

3. Simply run the setup script
    ```
      ./setup.sh
    ```
    The setup script will spin up a docker container for the Dotnet core WebApi services and npm serve the vue frontend. 

4. Login with ```username: artem; p: secret2``` to use the dummy arithmetic tool. 

