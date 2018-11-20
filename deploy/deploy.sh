ApiKey=$1
ts=$(date +"%y%m%d%H%M")

echo "Starting pack"
dotnet pack AMOS/AMOS.csproj /p:PackageVersion=1.0.$ts --configuration Release
echo "Starting push"
dotnet nuget push AMOS/bin/Release/*1.0.$ts.nupkg --api-key $ApiKey --source https://api.nuget.org/v3/index.json

