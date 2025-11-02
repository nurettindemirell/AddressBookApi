# SE4458 Assignment 2 — Address Book API

**Framework:** .NET 9 Web API  
**Swagger:** Swashbuckle.AspNetCore (9.0.6) — Swagger UI is served at the root (`/`)

## How to run (local)

```bash
cd AdressBookApi_Nurettin
dotnet restore
dotnet build
dotnet run
```

Open: **http://localhost:5149**

> If the port differs, check your terminal output and use the shown port.

## Endpoints

- `GET /api/Address` — listw all
- `GET /api/Address/{id}` — gets by id
- `POST /api/Address` — creates
- `PUT /api/Address/{id}` — update
- `DELETE /api/Address/{id}` — delete
- `GET /api/Address/search?q=ali` — search by name/city/email/phone



 Sample POST body
```json
{
  "name": "Nurettin Demirel",
  "city": "Mersin",
  "email": "nurettindemirel361@gmail.com",
  "phone": "5055054433"
}
```

 Notes

- In-memory storage only (data resets on restart).
- HTTPS redirection is disabled to avoid port confusion in local dev.
- You can deploy to Render/Azure; remember to expose the correct port and ensure `ASPNETCORE_URLS` is set by the platform.
