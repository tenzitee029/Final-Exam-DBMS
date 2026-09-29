USE TinhToan
GO

CREATE OR ALTER FUNCTION fn_TinhTuoi (@Namsinh INT)
RETURNS INT
AS
BEGIN
	DECLARE	@NamHientai INT;
	SET @NamHientai = YEAR(GETDATE());
	DECLARE @Tuoi INT;
	SET @Tuoi = @NamHientai - @Namsinh;
	IF @Tuoi < 0 OR @Namsinh <= 0
	BEGIN
		SET @Tuoi = 0;
	END
	RETURN @Tuoi;
END;
GO

SELECT dbo.fn_TinhTuoi(2004) AS [Tuoi];
SELECT dbo.fn_TinhTuoi(1985) AS [Tuoi];
SELECT dbo.fn_TinhTuoi(YEAR(GETDATE())) AS [Tuoi];
SELECT dbo.fn_TinhTuoi(2030) AS [Tuoi];