USE DeAn;
GO

-- 7.1
CREATE OR ALTER FUNCTION fn_LuongTrungBinh_PhongBan (@MaPB INT)
RETURNS FLOAT
AS
BEGIN
    DECLARE @LuongTB FLOAT;
    SELECT @LuongTB = AVG(nv.Luong + dbo.fn_TinhTienThuong(ISNULL(pc.TongGio, 0)))
    FROM NHANVIEN nv
    LEFT JOIN (
        SELECT MaNV, SUM(ThoiGian) AS TongGio 
        FROM PHANCONG 
        GROUP BY MaNV
    ) pc ON nv.MaNV = pc.MaNV
    WHERE nv.MaPB = @MaPB;
    RETURN @LuongTB;
END;
GO

SELECT dbo.fn_LuongTrungBinh_PhongBan(5) AS [LuongTB_PB5];
SELECT dbo.fn_LuongTrungBinh_PhongBan(1) AS [LuongTB_PB1];
GO

-- 7.2
CREATE OR ALTER FUNCTION fn_TongLuongNV_TheoDuAn (@MaNV VARCHAR(9), @MaDA INT)
RETURNS FLOAT
AS
BEGIN
    DECLARE @TongLuong FLOAT;
    SELECT @TongLuong = (nv.Luong / 160.0) * pc.ThoiGian + dbo.fn_TinhTienThuong(pc.ThoiGian)
    FROM NHANVIEN nv
    JOIN PHANCONG pc ON nv.MaNV = pc.MaNV
    WHERE nv.MaNV = @MaNV AND pc.MaDA = @MaDA;   
    RETURN @TongLuong;
END;
GO

SELECT dbo.fn_TongLuongNV_TheoDuAn('NV01', 1) AS [Luong_NV01_DA1];
SELECT dbo.fn_TongLuongNV_TheoDuAn('NV01', 99) AS [KhongCoPhanCong];
GO

-- 7.3
CREATE OR ALTER FUNCTION fn_LuongTrungBinh_CacPhongBan ()
RETURNS TABLE
AS
RETURN 
(
    SELECT 
        pb.MaPB,
        pb.TenPB,
        dbo.fn_LuongTrungBinh_PhongBan(pb.MaPB) AS LuongTrungBinh
    FROM PHONGBAN pb
);
GO

SELECT * FROM dbo.fn_LuongTrungBinh_CacPhongBan();
GO

-- 7.4
CREATE OR ALTER FUNCTION fn_TinhTienThuong (@Time_Total FLOAT)
RETURNS INT
AS
BEGIN
    DECLARE @TienThuong INT = 0;
    IF @Time_Total >= 30 AND @Time_Total <= 60
        SET @TienThuong = 500;
    ELSE IF @Time_Total > 60 AND @Time_Total < 100
        SET @TienThuong = 1000;
    ELSE IF @Time_Total >= 100 AND @Time_Total < 150
        SET @TienThuong = 1200;
    ELSE IF @Time_Total >= 150
        SET @TienThuong = 1600;
    ELSE
        SET @TienThuong = 0;
    RETURN @TienThuong;
END;
GO

SELECT dbo.fn_TinhTienThuong(45) AS [Thuong_45h];  
SELECT dbo.fn_TinhTienThuong(75) AS [Thuong_75h];   
SELECT dbo.fn_TinhTienThuong(120) AS [Thuong_120h]; 
SELECT dbo.fn_TinhTienThuong(180) AS [Thuong_180h]; 
SELECT dbo.fn_TinhTienThuong(10) AS [Thuong_10h];  
GO

-- 7.5
CREATE OR ALTER FUNCTION fn_TongSoDuAn_MoiPhongBan ()
RETURNS TABLE
AS
RETURN 
(
    SELECT 
        pb.MaPB,
        pb.TenPB,
        COUNT(da.MaDA) AS TongSoDuAn
    FROM PHONGBAN pb
    JOIN DEAN da ON pb.MaPB = da.MaPB
    GROUP BY pb.MaPB, pb.TenPB
);
GO

SELECT * FROM dbo.fn_TongSoDuAn_MoiPhongBan();
GO

-- 7.6
-- CÁCH 1: Inline Table-Valued Function
CREATE OR ALTER FUNCTION fn_ThongTinNhanVien_Inline ()
RETURNS TABLE
AS
RETURN 
(
    SELECT 
        nv.MaNV,
        (nv.HoNV + ' ' + nv.TenLot + ' ' + nv.TenNV) AS HoTen,
        nv.NgaySinh,
        nv.Luong AS LuongCoBan,
        dbo.fn_TinhTienThuong((SELECT SUM(ThoiGian) FROM PHANCONG WHERE MaNV = nv.MaNV)) AS LuongThuong,
        (nv.Luong + dbo.fn_TinhTienThuong((SELECT SUM(ThoiGian) FROM PHANCONG WHERE MaNV = nv.MaNV))) AS TongLuongNhan,
        tn.TenTN AS NguoiThan,
        dbo.fn_LuongTrungBinh_PhongBan(nv.MaPB) AS TongLuongTB
    FROM NHANVIEN nv
    LEFT JOIN THANNHAN tn ON nv.MaNV = tn.MaNV
);
GO

SELECT * FROM dbo.fn_ThongTinNhanVien_Inline();
GO

-- CÁCH 2: Multi-statement Table-Valued Function
CREATE OR ALTER FUNCTION fn_ThongTinNhanVien_MultiStatement ()
RETURNS @BangKetQua TABLE 
(
    MaNV VARCHAR(9),
    HoTen NVARCHAR(70),
    NgaySinh DATE,
    LuongCoBan FLOAT,
    LuongThuong INT,
    TongLuongNhan FLOAT,
    NguoiThan NVARCHAR(50),
    TongLuongTB FLOAT
)
AS
BEGIN
    INSERT INTO @BangKetQua
    SELECT 
        nv.MaNV,
        (nv.HoNV + ' ' + nv.TenLot + ' ' + nv.TenNV) AS HoTen,
        nv.NgaySinh,
        nv.Luong AS LuongCoBan,
        dbo.fn_TinhTienThuong((SELECT SUM(ThoiGian) FROM PHANCONG WHERE MaNV = nv.MaNV)) AS LuongThuong,
        (nv.Luong + dbo.fn_TinhTienThuong((SELECT SUM(ThoiGian) FROM PHANCONG WHERE MaNV = nv.MaNV))) AS TongLuongNhan,
        tn.TenTN AS NguoiThan,
        dbo.fn_LuongTrungBinh_PhongBan(nv.MaPB) AS TongLuongTB
    FROM NHANVIEN nv
    LEFT JOIN THANNHAN tn ON nv.MaNV = tn.MaNV;

    RETURN;
END;
GO

SELECT * FROM dbo.fn_ThongTinNhanVien_MultiStatement();
GO