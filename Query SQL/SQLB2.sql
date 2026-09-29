USE TinhToan;
GO

-- BT2
CREATE OR ALTER FUNCTION fn_GiaiPTB2 (@a FLOAT, @b FLOAT, @c FLOAT)
RETURNS NVARCHAR(255)
AS
BEGIN
    DECLARE @KetQua NVARCHAR(255);
    IF @a = 0
    BEGIN
        IF @b = 0
        BEGIN
            IF @c = 0
                SET @KetQua = N'Phương trình vô số nghiệm';
            ELSE
                SET @KetQua = N'Phương trình vô nghiệm';
        END
        ELSE
        BEGIN
            DECLARE @xB1 FLOAT = -@c / @b;
            SET @KetQua = N'Phương trình là bậc 1, có nghiệm x = ' + CAST(ROUND(@xB1, 2) AS NVARCHAR(50));
        END
    END
    ELSE
    BEGIN
        DECLARE @delta FLOAT;
        SET @delta = (@b * @b) - 4 * (@a * @c);
        IF @delta < 0
        BEGIN
            SET @KetQua = N'Phương trình vô nghiệm';
        END
        ELSE IF @delta = 0
        BEGIN
            DECLARE @xKep FLOAT = -@b / (2 * @a);
            SET @KetQua = N'Phương trình có nghiệm kép x = ' + CAST(ROUND(@xKep, 2) AS NVARCHAR(50));
        END
        ELSE
        BEGIN
            DECLARE @x1 FLOAT = (-@b + SQRT(@delta)) / (2 * @a);
            DECLARE @x2 FLOAT = (-@b - SQRT(@delta)) / (2 * @a);
            SET @KetQua = N'Phương trình có 2 nghiệm x1 = ' + CAST(ROUND(@x1, 2) AS NVARCHAR(50)) 
                        + N' x2 = ' + CAST(ROUND(@x2, 2) AS NVARCHAR(50));
        END
    END
    RETURN @KetQua;
END;
GO

SELECT dbo.fn_GiaiPTB2(0,0,0) AS [KetQua];
SELECT dbo.fn_GiaiPTB2(0, 0, 5) AS [KetQua];
SELECT dbo.fn_GiaiPTB2(0, 2, -4) AS [KetQua];
SELECT dbo.fn_GiaiPTB2(1, 1, 1) AS [KetQua];
SELECT dbo.fn_GiaiPTB2(1, -4, 4) AS [KetQua];
SELECT dbo.fn_GiaiPTB2(1, -3, 2) AS [KetQua];