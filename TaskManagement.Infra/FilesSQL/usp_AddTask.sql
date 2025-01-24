CREATE PROCEDURE usp_AddTask
    @Title NVARCHAR(100),
    @Description NVARCHAR(500),
    @IsCompleted BIT
AS
BEGIN
    INSERT INTO Tasks (Title, Description, IsCompleted)
    VALUES (@Title, @Description, @IsCompleted);
    
    SELECT SCOPE_IDENTITY() AS Id;
END;
