/****
Este script SQL fue creado por el cuadro de diálogo Configurar sincronización
de datos. Este script contiene instrucciones que crean las columnas
de seguimiento de cambios, la tabla de elementos eliminados y los
desencadenadores en la base de datos de servidor. Estos objetos de base
de datos son necesarios para que los Servicios de sincronización sincronicen
correctamente los datos entre las bases de datos del cliente y del servidor.
Para obtener más información, vea el tema ‘Cómo configurar un servidor de bases de datos para la sincronización’ en la Ayuda.
****/


IF @@TRANCOUNT > 0
set ANSI_NULLS ON 
set QUOTED_IDENTIFIER ON 

GO
BEGIN TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[tipo_transacciones] 
ADD [LastEditDate] DateTime NULL CONSTRAINT [DF_tipo_transacciones_LastEditDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[tipo_transacciones] 
ADD [CreationDate] DateTime NULL CONSTRAINT [DF_tipo_transacciones_CreationDate] DEFAULT (GETUTCDATE()) WITH VALUES
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipo_transacciones_Tombstone]')) 
BEGIN 
CREATE TABLE [dbo].[tipo_transacciones_Tombstone]( 
    [tipo] VarChar(4) NOT NULL,
    [DeletionDate] DateTime NULL
)END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[tipo_transacciones_Tombstone] ADD CONSTRAINT [PKDEL_tipo_transacciones_Tombstone_tipo]
   PRIMARY KEY CLUSTERED
    ([tipo])
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipo_transacciones_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[tipo_transacciones_DeletionTrigger] 

GO
CREATE TRIGGER [dbo].[tipo_transacciones_DeletionTrigger] 
    ON [tipo_transacciones] 
    AFTER DELETE 
AS 
SET NOCOUNT ON 
UPDATE [dbo].[tipo_transacciones_Tombstone] 
    SET [DeletionDate] = GETUTCDATE() 
    FROM deleted 
    WHERE deleted.[tipo] = [tipo_transacciones_Tombstone].[tipo] 
IF @@ROWCOUNT = 0 
BEGIN 
    INSERT INTO [dbo].[tipo_transacciones_Tombstone] 
    ([tipo], DeletionDate)
    SELECT [tipo], GETUTCDATE()
    FROM deleted 
END 

GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipo_transacciones_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[tipo_transacciones_UpdateTrigger] 

GO
CREATE TRIGGER [dbo].[tipo_transacciones_UpdateTrigger] 
    ON [dbo].[tipo_transacciones] 
    AFTER UPDATE 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[tipo_transacciones] 
    SET [LastEditDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[tipo] = [tipo_transacciones].[tipo] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipo_transacciones_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[tipo_transacciones_InsertTrigger] 

GO
CREATE TRIGGER [dbo].[tipo_transacciones_InsertTrigger] 
    ON [dbo].[tipo_transacciones] 
    AFTER INSERT 
AS 
BEGIN 
    SET NOCOUNT ON 
    UPDATE [dbo].[tipo_transacciones] 
    SET [CreationDate] = GETUTCDATE() 
    FROM inserted 
    WHERE inserted.[tipo] = [tipo_transacciones].[tipo] 
END;
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;
COMMIT TRANSACTION;
