# --------
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine as builder

WORKDIR /build/

ENV LC_ALL=C.UTF-8

RUN apk add --no-cache --update alpine-sdk zeromq protobuf protobuf-dev ca-certificates && \
    rm -f /var/cache/apk/*

# Required to do `dotnet restore`
COPY .config ./.config
COPY Makefile paket.dependencies paket.lock ./

# First restore 'paket', then restore the packages/ folder
RUN dotnet tool restore && dotnet paket restore

# Copy the remainder
COPY . .

# Will do `dotnet restore`, too
RUN make version_files && \
    dotnet publish -c release -r linux-musl-x64 src/services/Logary.Services.Rutta -o /app

# Now, copy all targets to Logary Rutta, so they are available
RUN find 'src/targets' -type f \
    \( -name 'Logary.Targets.*.dll' \
       -or -name 'Logary.Targets.*.pdb' \
       -or -name 'Logary.Targets.*.xml' \) \
    -not -path '*/obj/*' \
    -exec cp {} /app/ \;

# -------
FROM mcr.microsoft.com/dotnet/core/runtime:3.1-alpine3.11 as runner

WORKDIR /app

ENV USER=logary
ENV UID=12345
ENV GID=23456

RUN apk update --no-cache && \
    apk add libc6-compat zeromq protobuf protobuf-dev ca-certificates && \
    addgroup -S "$USER" && \
    adduser \
      --disabled-password \
      --gecos "" \
      --home "$(pwd)" \
      --ingroup "$USER" \
      --no-create-home \
      --uid "$UID" \
      "$USER" && \
    rm -f /var/cache/apk/*

COPY --from=builder /app .

ENTRYPOINT ["dotnet", "/app/rutta.dll"]

CMD []
