dotnet publish -c Release
docker build -t economyopedia-server -f Dockerfile .
heroku container:login
heroku container:push web -a economyopediaserver
heroku container:release web -a economyopediaserver