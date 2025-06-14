#!/usr/bin/env bash
# source environment variables
if [ -f .env ];then
  source .env
fi
if [ -f $(basename $PWD/.env) ]; then
  source $(basename $PWD)/.env
fi
if [ -z $CONFIG ];then
  CONFIG=Debug
fi
# build plugin
dotnet build --configuration $CONFIG
# upload to pterodactyl server
if [ $? == 0 ] && [ -n $PUSH ]; then
  scp ./$(basename $PWD)/bin/$CONFIG/net4.8/$(basename $PWD).dll "scp://$ENDPOINT_SSH/.config/SCP Secret Laboratory/LabAPI/plugins/7777"
  curl "https://$ENDPOINT/api/client/servers/$SERVER_ID/power" \
  -H 'Accept: application/json' \
  -H 'Content-Type: application/json' \
  -H "Authorization: Bearer $TOKEN" \
  -X POST \
  -d '{
        "signal": "restart"
      }'
fi
