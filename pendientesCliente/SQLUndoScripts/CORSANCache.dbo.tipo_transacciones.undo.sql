/****
PRECAUCIÓN
  Para evitar posibles problemas de pérdida de datos, revise este
  script en detalle antes de ejecutarlo.

Este script SQL se generó con el cuadro de diálogo Configurar
sincronización de datos. Complementa el script que se puede usar para crear
los objetos de base de datos requeridos para el seguimiento de cambios.
Este script contiene instrucciones para quitar estos cambios.

Para obtener más información, vea el tema de la Ayuda sobre cómo configurar un servidor de bases de datos para la sincronización.
****/


IF @@TRANCOUNT > 0
set ANSI_NULLS ON 
set QUOTED_IDENTIFIER ON 

GO
BEGIN TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[tipo_transacciones] DROP CONSTRAINT [DF_tipo_transacciones_LastEditDate]
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[tipo_transacciones] DROP COLUMN [LastEditDate]
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[tipo_transacciones] DROP CONSTRAINT [DF_tipo_transacciones_CreationDate]
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
ALTER TABLE [dbo].[tipo_transacciones] DROP COLUMN [CreationDate]
GO
IF @@ERROR <> 0 
     ROLLBACK TRANSACTION;


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipo_transacciones_Tombstone]') and TYPE = N'U') 
   DROP TABLE [dbo].[tipo_transacciones_Tombstone];


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipo_transacciones_DeletionTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[tipo_transacciones_DeletionTrigger] 

GO


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipo_transacciones_UpdateTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[tipo_transacciones_UpdateTrigger] 

GO


IF @@TRANCOUNT > 0
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipo_transacciones_InsertTrigger]') AND type = 'TR') 
   DROP TRIGGER [dbo].[tipo_transacciones_InsertTrigger] 

GO
COMMIT TRANSACTION;
