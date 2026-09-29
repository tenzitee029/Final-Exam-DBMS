USE QLThi;
GO

-- 10.1a
CREATE OR ALTER TRIGGER tg_KiemTra_PC_CoiThi
ON PC_COI_THI
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN GV gv ON i.MAGV = gv.MAGV
        JOIN BUOITHI bt ON i.HK = bt.HKY 
                       AND i.NGAY = bt.NGAY 
                       AND i.GIO = bt.GIO 
                       AND i.PHG = bt.PHG
        WHERE gv.MAMH IS NOT NULL AND gv.MAMH = bt.MAMH
    )
    BEGIN
        RAISERROR(N'Lỗi quy định: Giáo viên không được phân công gác thi môn mình chủ nhiệm!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

BEGIN TRAN;
    INSERT INTO PC_COI_THI (MAGV, HK, NGAY, GIO, PHG)
    VALUES ('GV01', 1, '2026-12-10', '07:30:00', 'P101');
ROLLBACK TRAN;
GO

-- 10.1b
CREATE OR ALTER TRIGGER tg_KiemTra_TGThi_30Tiet
ON BUOITHI
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN MHOC mh ON i.MAMH = mh.MAMH
        WHERE mh.SOTIET = 30 AND i.TGTHI <> 120
    )
    BEGIN
        RAISERROR(N'Lỗi quy định: Môn học 30 tiết thì thời gian thi phải là 120 phút!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

BEGIN TRAN;
    INSERT INTO BUOITHI (HKY, NGAY, GIO, PHG, MAMH, TGTHI)
    VALUES (1, '2026-12-25', '08:00:00', 'P201', 'MH02', 90);
ROLLBACK TRAN;
GO

-- 10.1c
CREATE OR ALTER TRIGGER tg_KiemTra_TGThi_Tren45Tiet
ON BUOITHI
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN MHOC mh ON i.MAMH = mh.MAMH
        WHERE mh.SOTIET >= 45 AND i.TGTHI <> 150
    )
    BEGIN
        RAISERROR(N'Lỗi quy định: Môn học từ 45 tiết trở lên thì thời gian thi phải là 150 phút!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

BEGIN TRAN;
    INSERT INTO BUOITHI (HKY, NGAY, GIO, PHG, MAMH, TGTHI)
    VALUES (1, '2026-12-26', '08:00:00', 'P202', 'MH01', 100);
ROLLBACK TRAN;
GO

-- 10.2a
CREATE OR ALTER FUNCTION fn_DanhSachGV_DayMon_Tren45Tiet ()
RETURNS TABLE
AS
RETURN (
    SELECT 
        gv.MAGV,
        gv.TENGV,
        mh.MAMH,
        mh.TENMH,
        mh.SOTIET
    FROM GV gv
    JOIN MHOC mh ON gv.MAMH = mh.MAMH
    WHERE mh.SOTIET >= 45
);
GO

-- 10.2a
CREATE OR ALTER FUNCTION fn_DanhSachGV_DayMon_Tren45Tiet ()
RETURNS TABLE
AS
RETURN (
    SELECT 
        gv.MAGV,
        gv.TENGV,
        mh.MAMH,
        mh.TENMH,
        mh.SOTIET
    FROM GV gv
    JOIN MHOC mh ON gv.MAMH = mh.MAMH
    WHERE mh.SOTIET >= 45
);
GO

SELECT * FROM dbo.fn_DanhSachGV_DayMon_Tren45Tiet();
GO

-- 10.2b
CREATE OR ALTER FUNCTION fn_DanhSachGV_GacThi_HK1 ()
RETURNS TABLE
AS
RETURN (
    SELECT DISTINCT
        gv.MAGV,
        gv.TENGV,
        gv.MAMH
    FROM GV gv
    JOIN PC_COI_THI pc ON gv.MAGV = pc.MAGV
    WHERE pc.HK = 1
);
GO

SELECT * FROM dbo.fn_DanhSachGV_GacThi_HK1();
GO

-- 10.2c
CREATE OR ALTER FUNCTION fn_DanhSachGV_KhongGacThi_HK1 ()
RETURNS TABLE
AS
RETURN (
    SELECT 
        gv.MAGV,
        gv.TENGV,
        gv.MAMH
    FROM GV gv
    WHERE NOT EXISTS (
        SELECT 1 
        FROM PC_COI_THI pc 
        WHERE pc.MAGV = gv.MAGV 
          AND pc.HK = 1
    )
);
GO

SELECT * FROM dbo.fn_DanhSachGV_KhongGacThi_HK1();
GO

-- 10.2d
CREATE OR ALTER FUNCTION fn_LichThi_MonVan ()
RETURNS TABLE
AS
RETURN (
    SELECT 
        bt.HKY,
        bt.NGAY,
        bt.GIO,
        bt.PHG,
        mh.MAMH,
        mh.TENMH,
        bt.TGTHI
    FROM BUOITHI bt
    JOIN MHOC mh ON bt.MAMH = mh.MAMH
    WHERE mh.TENMH = N'VĂN HỌC'
);
GO

SELECT * FROM dbo.fn_LichThi_MonVan();
GO

-- 10.2e
CREATE OR ALTER FUNCTION fn_BuoiGacThi_GV_ChuNhiemMonVan ()
RETURNS TABLE
AS
RETURN (
    SELECT 
        pc.MAGV,
        gv.TENGV,
        pc.HK,
        pc.NGAY,
        pc.GIO,
        pc.PHG,
        bt.MAMH AS MaMonThi,
        mh_thi.TENMH AS TenMonThi
    FROM PC_COI_THI pc
    JOIN GV gv ON pc.MAGV = gv.MAGV
    JOIN MHOC mh_cn ON gv.MAMH = mh_cn.MAMH
    JOIN BUOITHI bt ON pc.HK = bt.HKY 
                   AND pc.NGAY = bt.NGAY 
                   AND pc.GIO = bt.GIO 
                   AND pc.PHG = bt.PHG
    JOIN MHOC mh_thi ON bt.MAMH = mh_thi.MAMH
    WHERE mh_cn.TENMH = N'VĂN HỌC'
);
GO

SELECT * FROM dbo.fn_BuoiGacThi_GV_ChuNhiemMonVan();
GO