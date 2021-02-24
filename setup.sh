#!/bin/sh

# Docker compose
docker-compose up -d --build dotnetcal

cd dotnet-cal-client
npm install
npm run serve