#!/bin/bash
echo "⏳ Esperando que SQL Server esté listo..."
sleep 25

/opt/mssql-tools18/bin/sqlcmd \
  -S localhost \
  -U sa \
  -P "Admin1234!" \
  -i /docker-entrypoint-initdb.d/01_init.sql \
  -No -C

echo "✅ Base de datos importada correctamente"