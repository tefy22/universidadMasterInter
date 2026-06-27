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

# Roles
postman request 'https://localhost:7154/api/roles'
postman request POST 'https://localhost:7154/api/roles' \
  --header 'Content-Type: application/json' \
  --body '{
  "description": "Theacher"
}'
postman request 'https://localhost:7154/api/roles/9d5c100a-8d26-4374-8376-c0386ac82dfe'
postman request DELETE 'https://localhost:7154/api/roles/368a2d03-6891-4688-a14b-ebce79f10c4a'

# Teachers
postman request 'https://localhost:7154/api/teachers'
postman request POST 'https://localhost:7154/api/teachers' \
  --header 'Content-Type: application/json' \
  --body '{
  "dni": 1090456630,
  "name": "Enrique",
  "lastname": "Ortega",
  "email": "enriqueortega19@gmail.com",
  "phoneNumber": "3132656396"
}'
postman request 'https://localhost:7154/api/teachers/dccb2f39-965b-433a-9168-2846e7584154'
postman request 'https://localhost:7154/api/teachers/1090456638'
postman request 'https://localhost:7154/api/teachers/ie.afanador19@gmail.com'
postman request PUT 'https://localhost:7154/api/teachers/dccb2f39-965b-433a-9168-2846e7584154' \
  --header 'Content-Type: application/json' \
  --body '{
    "id": "dccb2f39-965b-433a-9168-2846e7584154",
    "dni": 1090456638,
    "name": "pepito",
    "lastname": "perez",
    "email": "ie.afanador190@gmail.com",
    "phoneNumber": "3132656396"
}'
postman request DELETE 'https://localhost:7154/api/teachers/dccb2f39-965b-433a-9168-2846e7584154' \
  --header 'Content-Type: text/plain' \
  --body '{
  "dni": 1090456630,
  "name": "Enrique",
  "lastname": "Ortega",
  "email": "enriqueortega19@gmail.com",
  "phoneNumber": "3132656396"
}'
