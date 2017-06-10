--Roles Creation
dbo.aspnet_Roles_CreateRole 'PriceManager', 'Administrator'
dbo.aspnet_Roles_CreateRole 'PriceManager', 'User'
dbo.aspnet_Roles_CreateRole 'PriceManager', 'ROUser'

--Role assignement to Users
--Admin
declare @admin varchar(50)
set @admin='ccanasco'
--
select UserName into #temp from dbo.aspnet_Users Users inner join dbo.aspnet_Applications Applications on Users.ApplicationId = Applications.ApplicationId where UserName != @admin and Applications.ApplicationName = 'PriceManager'
declare @cadena varchar(400)
set @cadena=''
select @cadena=@cadena+','+convert(varchar(20),UserName) from #temp

DECLARE	@return_value int

EXEC	@return_value = [dbo].[aspnet_UsersInRoles_AddUsersToRoles]
		@ApplicationName = N'PriceManager',
		@UserNames = @cadena,
		@RoleNames = N'ROUser',
		@CurrentTimeUtc = '20090602'

SELECT	'Return Value' = @return_value

GO
-- Administrator assigment
DECLARE	@return_value int

EXEC	@return_value = [dbo].[aspnet_UsersInRoles_AddUsersToRoles]
		@ApplicationName = N'PriceManager',
		@UserNames = N'ccanasco',
		@RoleNames = N'Administrator',
		@CurrentTimeUtc = '20090602'

SELECT	'Return Value' = @return_value

GO
