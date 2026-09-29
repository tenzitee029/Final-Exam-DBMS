USE QuanLyGara;
GO

-- 9.1
CREATE OR ALTER FUNCTION fn_DanhSachTho_KhongThamGiaHD ()
RETURNS TABLE
AS
RETURN (
    SELECT 
        t.MaTho,
        t.TenTho,
        t.Nhom,
        t.NhomTruong
    FROM THO t
    WHERE NOT EXISTS (
        SELECT 1 
        FROM CHITIET_HD ct 
        WHERE ct.MaTho = t.MaTho
    )
);
GO

SELECT * FROM dbo.fn_DanhSachTho_KhongThamGiaHD();
GO

-- 9.2
CREATE OR ALTER FUNCTION fn_HopDong_ThanhLyChuaTraDu ()
RETURNS TABLE
AS
RETURN (
    SELECT 
        hd.SoHD,
        hd.NgayHD,
        hd.SoXe,
        hd.TriGiaHD,
        hd.NgayNgThu,
        ISNULL(SUM(pt.SoTienThu), 0) AS TongDaThu,
        (hd.TriGiaHD - ISNULL(SUM(pt.SoTienThu), 0)) AS SoTienConThieu
    FROM HOPDONG hd
    LEFT JOIN PHIEUTHU pt ON hd.SoHD = pt.SoHD
    WHERE hd.NgayNgThu IS NOT NULL
    GROUP BY hd.SoHD, hd.NgayHD, hd.SoXe, hd.TriGiaHD, hd.NgayNgThu
    HAVING ISNULL(SUM(pt.SoTienThu), 0) < hd.TriGiaHD
);
GO

SELECT * FROM dbo.fn_HopDong_ThanhLyChuaTraDu();
GO

-- 9.3
CREATE OR ALTER FUNCTION fn_HopDong_TruocNgay31122002 ()
RETURNS TABLE
AS
RETURN (
    SELECT 
        hd.SoHD,
        hd.NgayHD,
        hd.MaKH,
        hd.SoXe,
        hd.TriGiaHD,
        hd.NgayGiaoDK,
        hd.NgayNgThu
    FROM HOPDONG hd
    WHERE hd.NgayGiaoDK < '2002-12-31' 
       OR (hd.NgayNgThu IS NOT NULL AND hd.NgayNgThu < '2002-12-31')
);
GO

SELECT * FROM dbo.fn_HopDong_TruocNgay31122002();
GO

-- 9.4
CREATE OR ALTER FUNCTION fn_Tho_LamViecNhieuNhat ()
RETURNS TABLE
AS
RETURN (
    SELECT TOP 1 WITH TIES
        t.MaTho,
        t.TenTho,
        t.Nhom,
        COUNT(ct.MaCV) AS SoLuongCongViec
    FROM THO t
    JOIN CHITIET_HD ct ON t.MaTho = ct.MaTho
    GROUP BY t.MaTho, t.TenTho, t.Nhom
    ORDER BY COUNT(ct.MaCV) DESC
);
GO

SELECT * FROM dbo.fn_Tho_LamViecNhieuNhat();
GO

-- 9.5
CREATE OR ALTER FUNCTION fn_Tho_TongTriGiaCaoNhat ()
RETURNS TABLE
AS
RETURN (
    SELECT TOP 1 WITH TIES
        t.MaTho,
        t.TenTho,
        t.Nhom,
        SUM(ct.TriGiaCV) AS TongTriGiaCongViec
    FROM THO t
    JOIN CHITIET_HD ct ON t.MaTho = ct.MaTho
    GROUP BY t.MaTho, t.TenTho, t.Nhom
    ORDER BY SUM(ct.TriGiaCV) DESC
);
GO

SELECT * FROM dbo.fn_Tho_TongTriGiaCaoNhat();
GO