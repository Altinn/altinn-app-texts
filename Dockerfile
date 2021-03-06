FROM mcr.microsoft.com/dotnet/sdk:6.0.300-alpine3.15 AS build
WORKDIR /workspace/

COPY src .

RUN dotnet publish Altinn.AppTexts/Altinn.AppTexts.csproj -c Release -o /app_output

FROM mcr.microsoft.com/dotnet/aspnet:6.0.5-alpine3.15 AS final
EXPOSE 5090
WORKDIR /app
COPY --from=build /app_output .
# setup the user and group
# the user will have no password, using shell /bin/false and using the group dotnet
RUN addgroup -g 3000 dotnet && adduser -u 1000 -G dotnet -D -s /bin/false dotnet
# update permissions of files if neccessary before becoming dotnet user
USER dotnet
RUN mkdir /tmp/logtelemetry

ENTRYPOINT ["dotnet", "Altinn.AppTexts.dll"]
