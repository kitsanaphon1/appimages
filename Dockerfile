FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# คัดลอกไฟล์โปรเจกต์ก่อนเพื่อให้ dotnet restore แคชได้
COPY WebAppProject.csproj . 
RUN dotnet restore WebAppProject.csproj

# คัดลอกไฟล์ที่เหลือทั้งหมด
COPY . .

# build โดยระบุ project
RUN dotnet publish WebAppProject.csproj -c Release -o out

# Runtime stage (optional)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "WebAppProject.dll"]
