# TempDeepLomeBackendRepo
Временный репозиторий (невременный) для работы с бекендом на .net 6 и OpenApi

# Scaffold db
scaffold-dbcontext "DataSource=C:\Users\Kirul\Desktop\DeepLome\DeepLome\DeepLome\TrashFinders.db" Microsoft.EntityFrameworkCore.Sqlite -OutputDir DatabaseModels

# Ngrok
ngrok http http://localhost:5094  -host-header=localhost:5094 -region eu

Тут нужно обязательно чтобы было http, а не https
Пока что убрал httpsRedirections
