#!/bin/bash
dotnet ef dbcontext scaffold "Server=localhost;Port=3306;Database=utilidades;Uid=mckatoo;Pwd=12345;SslMode=none;" MySql.Data.EntityFrameworkCore --context-dir ../../Infrastructure/Utilidades.Infrastructure/Data/Context/ -o ../../ApplicationCore/Utilidades.ApplicationCore/Entity -s src/Infrastructure/Utilidades.Infrastructure/Utilidades.Infrastructure.csproj