
>>делается один раз за весь проект
enable-migrations -ContextTypeName WebShopMVCContext -MigrationsDirectory Migrations -ProjectName WebShop.Model  



 >>добавить текущая миграция
Add-Migration (имя миграции) -ProjectName WebShop.Model


>> внести изменения в базу 
Update-database -ProjectName WebShop.Model 
    

 >>откатить до указанной миграции миграция
Update-database -ProjectName WebShop.Model -TargetMigration (имя миграции)
