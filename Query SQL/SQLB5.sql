USE QuanLyThuVien;
GO

-- 5a
CREATE OR ALTER PROC sp_ThongtinDocGia 
	@ma_DocGia INT
AS
BEGIN
	IF EXISTS (SELECT @ma_DocGia FROM Nguoilon WHERE ma_DocGia = @ma_DocGia)
	BEGIN
		SELECT 
			dg.ma_DocGia, dg.ho, dg.tenlot, dg.ten, dg.ngaysinh,
            N'Người lớn' AS LoaiDocGia,
            nl.sonha, nl.duong, nl.quan, nl.dienthoai, nl.han_sd
		FROM DocGia dg 
		JOIN Nguoilon nl ON dg.ma_DocGia = nl.ma_DocGia
		WHERE dg.ma_DocGia = @ma_DocGia
    END
    ELSE IF EXISTS (SELECT @ma_DocGia FROM Treem WHERE ma_DocGia = @ma_DocGia)
    BEGIN
        SELECT
            dg.ma_DocGia, dg.ho, dg.tenlot, dg.ten, dg.ngaysinh,
            N'Trẻ em' AS LoaiDocGia,
            te.ma_DocGia_nguoilon
        FROM DocGia dg
        JOIN Treem te ON dg.ma_DocGia = te.ma_DocGia
        WHERE dg.ma_DocGia = @ma_DocGia;
    END
    ELSE
    BEGIN
        RAISERROR(N'Mã độc giả không tồn tại trong hệ thống', 16, 1);
    END
END;
GO

EXEC sp_ThongtinDocGia @ma_DocGia = 101;
EXEC sp_ThongtinDocGia @ma_DocGia = 201;
EXEC sp_ThongtinDocGia @ma_DocGia = 999;
GO

-- 5b
CREATE OR ALTER PROC sp_Thongtin_DauSach
    @isbn VARCHAR(20)
AS
BEGIN
    IF NOT EXISTS (SELECT isbn FROM Dausach WHERE isbn = @isbn)
    BEGIN
        RAISERROR (N'Mã đầu sách không tồn tại',16, 1);
        RETURN;
    END
    SELECT ds.isbn, ts.tuasach, ts.tacgia, ts.tomtat, ds.ngonngu, ds.bia, ds.trangthai,
           (SELECT COUNT(*) FROM Cuonsach cs WHERE cs.isbn = ds.isbn AND cs.tinhtrang = 'yes')
           AS SoLuongChuaMuon
    FROM Dausach ds
    JOIN Tuasach ts ON ds.ma_tuasach = ts.ma_tuasach
    WHERE ds.isbn = @isbn;
END;
GO

EXEC sp_ThongtinDauSach @isbn = 'ISBN01';
EXEC sp_ThongtinDausach @isbn = 'ISBN02';
EXEC sp_ThongtinDausach @isbn = 'ISBN99';
GO

-- 5c
CREATE OR ALTER PROC sp_ThongtinNguoilonDangmuon
AS
BEGIN
    SELECT
        dg.ma_DocGia,
        dg.ho + ' ' + dg.tenlot + ' ' + dg.ten AS HoTen,
        dg.ngaysinh,
        nl.dienthoai,
        nl.sonha + ', ' + nl.duong + ', ' + nl.quan AS DiaChi,
        m.isbn,
        m.ma_cuonsach,
        m.ngay_muon,
        m.ngay_hethan
    FROM DocGia dg
    JOIN Nguoilon nl ON dg.ma_DocGia = nl.ma_DocGia
    JOIN Muon m ON dg.ma_DocGia = m.ma_DocGia;
END;
GO

EXEC sp_ThongtinNguoilonDangmuon;
GO

-- 5d
CREATE OR ALTER PROC sp_ThongtinNguoilonQuahan
AS
BEGIN
    SELECT
        dg.ma_DocGia,
        dg.ho + ' ' + dg.tenlot + ' ' + dg.ten AS HoTen,
        dg.ngaysinh,
        nl.dienthoai,
        nl.sonha + ', ' + nl.duong + ', ' + nl.quan AS DiaChi,
        m.isbn,
        m.ma_cuonsach,
        m.ngay_muon,
        m.ngay_hethan,
        DATEDIFF(day, m.ngay_hethan, CAST(GETDATE() AS DATE)) AS SoNgayQuaHan
    FROM DocGia dg
    JOIN Nguoilon nl ON dg.ma_DocGia = nl.ma_DocGia
    JOIN Muon m ON dg.ma_DocGia = m.ma_DocGia
    WHERE DATEDIFF(day, m.ngay_hethan, CAST(GETDATE() AS DATE)) > 14;
END;
GO

EXEC sp_ThongtinNguoilonQuahan;
GO

-- 5e
CREATE OR ALTER PROC sp_DocGiaCoTreEmMuon
AS
BEGIN
    SELECT
        dg.ma_DocGia,
        dg.ho + ' ' + dg.tenlot + ' ' + dg.ten AS HoTen,
        dg.ngaysinh,
        nl.dienthoai,
        nl.sonha + ', ' + nl.duong + ', ' + nl.quan AS DiaChi
    FROM DocGia dg
    JOIN Nguoilon nl ON dg.ma_DocGia = nl.ma_DocGia
    WHERE EXISTS (
        SELECT m.ma_DocGia 
        FROM Muon m 
        WHERE m.ma_DocGia = nl.ma_DocGia
    )
    AND EXISTS (
        SELECT te.ma_DocGia 
        FROM Treem te JOIN Muon m_te ON te.ma_DocGia = m_te.ma_DocGia
        WHERE te.ma_DocGia_nguoilon = nl.ma_DocGia
    );
END;
GO

EXEC sp_DocGiaCoTreEmMuon;
GO