DECLARE @i int
SET @i = 0 
WHILE(@i < 100)
	 
BEGIN 

DECLARE @intfield INT
SELECT @intfield = CAST(RAND() * 100 as INT)


DECLARE @datefield DATETIME
SET @datefield = GETDATE() -+ (365 * 2 * RAND() - 365)


DECLARE @stringfield VARCHAR(64)
DECLARE @length INT
SELECT @stringfield = ''
SET @length = CAST(RAND() * 64 as INT)
WHILE @length <> 0
    BEGIN
    SELECT @stringfield = @stringfield + CHAR(CAST(RAND() * 96 + 32 as INT))
    SET @length = @length - 1
    END


INSERT INTO TestTable1 
VALUES(NEWID(),@intfield,@datefield,@stringfield)
SET @i = @i + 1
   
END

