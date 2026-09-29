USE QuanLyThuVien;
GO

-- 6.1
CREATE OR ALTER TRIGGER tg_delMuon ON Muon
AFTER DELETE
AS
BEGIN
	UPDATE Cuonsach
	SET tinhtrang = 'yes'
	FROM Cuonsach cs
	JOIN deleted d ON cs.isbn = d.isbn AND cs.ma_cuonsach = d.ma_cuonsach;
END;
GO

BEGIN TRAN;
	SELECT isbn, ma_cuonsach, tinhtrang 
	FROM Cuonsach 
	WHERE isbn = 'ISBN02' AND ma_cuonsach = 1;

	DELETE FROM Muon WHERE isbn = 'ISBN02' AND ma_cuonsach = 1;
	
	SELECT isbn, ma_cuonsach,tinhtrang
	FROM Cuonsach
	WHERE isbn = 'ISBN02' AND ma_cuonsach = 1;
ROLLBACK TRAN;
GO

-- 6.2
CREATE OR ALTER TRIGGER tg_insMuon ON Muon
AFTER INSERT
AS
BEGIN
	UPDATE Cuonsach
	SET tinhtrang = 'no'
	FROM Cuonsach cs
	JOIN inserted i ON cs.isbn = i.isbn AND cs.ma_cuonsach = i.ma_cuonsach
END;
GO

BEGIN TRAN;
	UPDATE Cuonsach SET tinhtrang = 'yes' WHERE isbn = 'ISBN01' AND ma_cuonsach = 1;
	INSERT INTO Muon (isbn, ma_cuonsach, ma_DocGia, ngay_muon, ngay_hethan)
	VALUES ('ISBN01', 1, 102, CAST(GETDATE() AS DATE), DATEADD(day, 14, CAST(GETDATE() AS DATE)));
	SELECT isbn, ma_cuonsach, tinhtrang FROM Cuonsach WHERE isbn = 'ISBN01' AND ma_cuonsach = 1;
ROLLBACK TRAN;
GO

-- 6.3
CREATE OR ALTER TRIGGER tg_updCuonSach ON Cuonsach
AFTER UPDATE
AS
BEGIN
	IF UPDATE(tinhtrang)
    BEGIN
		UPDATE Dausach
        SET trangthai = CASE 
            WHEN EXISTS 
			(
                SELECT 1 
                FROM Cuonsach cs 
                WHERE cs.isbn = Dausach.isbn AND cs.tinhtrang = 'yes'
            ) 
			THEN 'yes'
            ELSE 'no'
        END
        WHERE isbn IN (SELECT DISTINCT isbn FROM inserted);
    END
END;
GO

BEGIN TRAN;
	UPDATE Cuonsach SET tinhtrang = 'no' WHERE isbn = 'ISBN01';
	SELECT isbn, trangthai AS [TrangThai_DauSach] FROM Dausach WHERE isbn = 'ISBN01';

	UPDATE Cuonsach SET tinhtrang = 'yes' WHERE isbn = 'ISBN01' AND ma_cuonsach = 1;
    SELECT isbn, trangthai AS [TrangThai_DauSach] FROM Dausach WHERE isbn = 'ISBN01';
ROLLBACK TRAN;
GO

-- 6.4
CREATE OR ALTER TRIGGER tg_InfThongbao ON Tuasach
AFTER INSERT, UPDATE
AS
BEGIN
	IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        PRINT N'Đã thêm mới tựa sách';
    END
	ELSE IF UPDATE(tacgia) OR UPDATE(tuasach)
    BEGIN
        PRINT N'Đã cập nhật thông tin tựa sách';
    END
END;
GO

BEGIN TRAN;
	INSERT INTO Tuasach (ma_tuasach, tuasach, tacgia, tomtat)
    VALUES (99, N'Học SQL Server Nâng Cao', N'Phạm Văn C', N'Tài liệu thực hành Trigger');
	
	UPDATE Tuasach 
    SET tacgia = N'Phạm Văn C (Đã hiệu đính)' 
    WHERE ma_tuasach = 99;
ROLLBACK TRAN;
GO