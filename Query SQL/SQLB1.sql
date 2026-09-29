USE TinhToan;
GO

CREATE OR ALTER PROC sp_GiaiPTB1 @a FLOAT, @b FLOAT
AS
BEGIN
	DECLARE @KetQua NVARCHAR(255);
	IF @a = 0
	BEGIN
		IF @b = 0
		BEGIN
			SET @KetQua = N'Phương trình vô số nghiệm';
		END
		ELSE
		BEGIN
			SET @KetQua = N'Phương trình vô nghiệm';
		END
	END
	ELSE
	BEGIN
		DECLARE @x FLOAT = -@b / @a;
		SET @KetQua = N'Phương trình có nghiệm duy nhất x = ' + CAST(ROUND(@x, 2) AS NVARCHAR(50));
	END
	SELECT @KetQua AS [KetQua]
END;
GO

EXEC sp_GiaiPTB1 0,0;
EXEC sp_GiaiPTB1 0, 5;    
EXEC sp_GiaiPTB1 2, -4;