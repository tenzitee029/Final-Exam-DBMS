USE QuanLyThuVien;
GO

CREATE OR ALTER PROC sp_ThongtinDausach 
    @isbn VARCHAR(20)
AS
BEGIN
    SELECT ds.isbn, ts.tuasach, ts.tacgia, ts.tomtat, ds.ngonngu, ds.bia, ds.trangthai, COUNT(cs.ma_cuonsach) AS SoLuongChuaMuon
    FROM Dausach ds 
    JOIN Tuasach ts ON ds.ma_tuasach = ts.ma_tuasach
    JOIN Cuonsach cs ON ds.isbn = cs.isbn
    WHERE ds.isbn = @isbn AND cs.tinhtrang = 'yes'
    GROUP BY ds.isbn, ts.tuasach, ts.tacgia, ts.tomtat, ds.ngonngu, ds.bia, ds.trangthai;
END;
GO

EXEC sp_ThongtinDausach @isbn = 'ISBN01';
EXEC sp_ThongtinDausach @isbn = 'ISBN02';