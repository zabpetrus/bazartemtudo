USE [BazarDB];
GO

IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'Orders' 
    AND constraint_name = 'FK_OR_CLI'
)
BEGIN
    ALTER TABLE Orders
    DROP CONSTRAINT FK_OR_CLI;
END;



IF EXISTS (
    SELECT 1
    FROM information_schema.table_constraints
    WHERE table_name = 'Internal_Storage' 
    AND constraint_name = 'FK_IS_PROD'
)
BEGIN
    ALTER TABLE Internal_Storage
    DROP CONSTRAINT FK_IS_PROD;
END;


IF EXISTS (
	SELECT 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
	WHERE TABLE_NAME = 'OrderItems'
	AND CONSTRAINT_NAME = 'FK_OI_ORD'
)
BEGIN
	ALTER TABLE OrderItems DROP CONSTRAINT FK_OI_ORD;
END
