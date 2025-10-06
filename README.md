<div align="center">

#  PSYCHOSSS-API
### Веб-сервис на ASP.NET Core

</div>






![image alt](https://github.com/TRUEPSYCHOSSSRANK/PSYCHOSSS-API/blob/1fba8579ca4b3941dfa28b9fa762a5e9a9ed19d9/images/swaggerSSS.jpg)


##  О проекте

**PSYCHOSSS-API** —  веб-API, созданный на ASP.NET Core. 

- ⚡ **Управляй** списком имен через RESTful API
- 📊 **Тестируй** эндпоинты через Swagger UI  
- 📡 **Обрабатывай** ошибки как профессионал

## ⚙️ Возможности API

| Метод | Путь | Что делает |
|-------|------|------------|
| 🟢 **GET** | `/api/names` | Получить все имена |
| 🟡 **GET** | `/api/names/{id}` | Найти имя по ID |
| 🔵 **GET** | `/api/names/count/{name}` | Посчитать имена |
| 🟠 **POST** | `/api/names` | Добавить новое имя |
| 🟣 **PUT** | `/api/names/{id}` | Изменить имя |
| 🔴 **DELETE** | `/api/names/{id}` | Удалить имя |

### Получить все имена
GET [https://localhost:7178/api/names](https://localhost:7178/swagger/index.html)

### Добавить новое имя
POST https://localhost:7178/api/names
Content-Type: application/json

"Psychosss" 

🛠️ Технологии
ASP.NET Core 8.0 - фреймворк для веб-API

Swagger/OpenAPI - документация и тестирование

C#  - язык программирования

## READY

```bash
# Клонируй репозиторий
git clone https://github.com/TRUEPSYCHOSSSRANK/PSYCHOSSS-API.git

# Откройте проект в Visual Studio
cd PSYCHOSSS-API/src
# Запустите проект (F5)
