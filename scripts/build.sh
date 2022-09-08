#!/bin/sh
solution=smashup-crash-automation.sln
platform='linux-x64'
pkgdir=src/CLI/bin/Release/net6.0/$platform/publish
pkgname=smashup

dotnet publish \
  -c Release \
  --self-contained false \
  -r $platform \
  -p:PublishSingleFile=true \
  -p:PlublishTrimmed=true \
  -p:IncludeNativeLibrariesForSelfExtract=true \
  src/CLI/CLI.csproj && \
dotnet ef --startup-project src/CLI database update && \
rm -rf ~/bin/$pkgname && \
ln src/CLI/bin/Release/net6.0/$platform/publish/$pkgname ~/bin/$pkgname 