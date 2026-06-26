# universidadMasterInter
dotnet ef migrations add InitialMigration --project .\Infrastructure\Infrastructure.csproj --startup-project .\UniversityMaster\UniversityMaster.csproj --verbose

# Consumir servicios desde postman CURL
# Student
postman request 'https://localhost:7154/api/Students'
postman request POST 'https://localhost:7154/api/Students' \
  --header 'Content-Type: application/json' \
  --body '{
  "dni": 1094267610,
  "name": "ismael",
  "lastname": "afanador",
  "email": "ie.ortega@gmail.com",
  "phoneNumber": "3132656399"
}'
postman request 'https://localhost:7154/api/Students/fa1d8078-f210-45e5-939d-0a7a4f8b68bf'
postman request 'https://localhost:7154/api/Students/1094267608'
postman request 'https://localhost:7154/api/Students/sa.ortega19@gmail.com'
postman request DELETE 'https://localhost:7154/api/Students/fa1d8078-f210-45e5-939d-0a7a4f8b68bf'
postman request PUT 'https://localhost:7154/api/Students/cadab4ce-40f8-4ec2-88ce-927e2522b3e2' \
  --header 'Content-Type: application/json' \
  --body '{
    "id":"cadab4ce-40f8-4ec2-88ce-927e2522b3e2",
  "dni": 1094267608,
  "name": "stefania maria",
  "lastname": "afanador",
  "email": "sa.ortega19@gmail.com",
  "phoneNumber": "3132656399"
}'
