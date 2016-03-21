
>>делается один раз за весь проект
enable-migrations -ContextTypeName WebShopMVCContext -MigrationsDirectory Migrations -ProjectName WebShop.Model  



 >>добавить текущая миграция
Add-Migration (имя миграции) -ProjectName WebShop.Model


>> внести изменения в базу 
Update-database -ProjectName WebShop.Model 
    

 >>откатить до указанной миграции миграция
Update-database -ProjectName WebShop.Model -TargetMigration (имя миграции)


___________Список выполненных миграций________________
1. Add-Migration _after_merge -ProjectName WebShop.Model
2. Add-Migration _add_Clients -ProjectName WebShop.Model