ApiKey=$1
ts=$(date +"%Y.%m.%d.%H%M")

echo "Starting pack"
dotnet pack AMOS/AMOS.csproj /p:PackageVersion=$ts --configuration Release
echo "Starting push"
dotnet nuget push AMOS/bin/Release/*.nupkg --source https://api.nuget.org/v3/index.json --api-key $ApiKey

