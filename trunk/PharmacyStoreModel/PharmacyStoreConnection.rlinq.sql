-- add column for field _actflg
ALTER TABLE [LS_CUSTOMER_GROUP] ADD [Actflg] char(1) NULL

go

UPDATE [LS_CUSTOMER_GROUP] SET [Actflg] = ' '

go

ALTER TABLE [LS_CUSTOMER_GROUP] ALTER COLUMN [Actflg] char(1) NOT NULL

go

-- add column for field _actflg
ALTER TABLE [LS_DISEASE] ADD [Actflg] char(1) NULL

go

UPDATE [LS_DISEASE] SET [Actflg] = ' '

go

ALTER TABLE [LS_DISEASE] ALTER COLUMN [Actflg] char(1) NOT NULL

go

-- add column for field _description
ALTER TABLE [LS_DISEASE] ADD [Description] varchar(255) NULL

go

