USE DeAn;
GO

-- 8.1
CREATE OR ALTER FUNCTION fn_DuAn_Tren2NV ()
RETURNS TABLE
AS
RETURN (
    SELECT 
        da.MaDA,
        da.TenDA,
        COUNT(pc.MaNV) AS SoLuongNV
    FROM DEAN da
    JOIN PHANCONG pc ON da.MaDA = pc.MaDA
    GROUP BY da.MaDA, da.TenDA
    HAVING COUNT(pc.MaNV) > 2
);
GO

SELECT * FROM dbo.fn_DuAn_Tren2NV();
GO

-- 8.2
CREATE OR ALTER FUNCTION fn_Phong_Tren2NV_LuongTren25000 ()
RETURNS TABLE
AS
RETURN (
    SELECT 
        pb.MaPB,
        COUNT(CASE WHEN nv.Luong > 25000 THEN 1 END) AS SoLuongNV_LuongTren25k
    FROM PHONGBAN pb
    JOIN NHANVIEN nv ON pb.MaPB = nv.MaPB
    GROUP BY pb.MaPB
    HAVING COUNT(nv.MaNV) > 2
);
GO

SELECT * FROM dbo.fn_Phong_Tren2NV_LuongTren25000();
GO

-- 8.3
CREATE OR ALTER FUNCTION fn_Phong_LuongTB_Tren30000 ()
RETURNS TABLE
AS
RETURN (
    SELECT 
        pb.MaPB,
        pb.TenPB,
        COUNT(nv.MaNV) AS SoLuongNV
    FROM PHONGBAN pb
    JOIN NHANVIEN nv ON pb.MaPB = nv.MaPB
    GROUP BY pb.MaPB, pb.TenPB
    HAVING AVG(nv.Luong) > 30000
);
GO

SELECT * FROM dbo.fn_Phong_LuongTB_Tren30000();
GO

-- 8.4
CREATE OR ALTER FUNCTION fn_Phong_LuongTB_Tren30000_NVNam ()
RETURNS TABLE
AS
RETURN (
    SELECT 
        pb.MaPB,
        pb.TenPB,
        COUNT(CASE WHEN nv.Phai = N'Nam' THEN 1 END) AS SoLuongNVNam
    FROM PHONGBAN pb
    JOIN NHANVIEN nv ON pb.MaPB = nv.MaPB
    GROUP BY pb.MaPB, pb.TenPB
    HAVING AVG(nv.Luong) > 30000
);
GO

SELECT * FROM dbo.fn_Phong_LuongTB_Tren30000_NVNam();
GO

-- 8.5
CREATE OR ALTER FUNCTION fn_DuAn_SoLuongNV_Phong5 ()
RETURNS TABLE
AS
RETURN (
    SELECT 
        da.MaDA,
        da.TenDA,
        COUNT(pc.MaNV) AS SoLuongNV_Phong5
    FROM DEAN da
    JOIN PHANCONG pc ON da.MaDA = pc.MaDA
    JOIN NHANVIEN nv ON pc.MaNV = nv.MaNV
    WHERE nv.MaPB = 5
    GROUP BY da.MaDA, da.TenDA
);
GO

SELECT * FROM dbo.fn_DuAn_SoLuongNV_Phong5();
GO