-- DB B1,2,4
CREATE DATABASE TinhToan;


-- DB B3,5,6
CREATE DATABASE QuanLyThuVien;
USE QuanLyThuVien
-- B3
CREATE TABLE Tuasach (
    ma_tuasach INT PRIMARY KEY,
    tuasach NVARCHAR(200),
    tacgia NVARCHAR(100),
    tomtat NVARCHAR(MAX)
);
CREATE TABLE Dausach (
    isbn VARCHAR(20) PRIMARY KEY,
    ma_tuasach INT,
    ngonngu NVARCHAR(50),
    bia NVARCHAR(50),
    trangthai NVARCHAR(10) DEFAULT 'yes',
    FOREIGN KEY (ma_tuasach) REFERENCES Tuasach(ma_tuasach)
);
CREATE TABLE Cuonsach (
    isbn VARCHAR(20),
    ma_cuonsach INT,
    tinhtrang NVARCHAR(10) DEFAULT 'yes', -- 'yes': còn trong thư viện, 'no': đã mượn
    PRIMARY KEY (isbn, ma_cuonsach),
    FOREIGN KEY (isbn) REFERENCES Dausach(isbn)
);

INSERT INTO Tuasach VALUES 
(1, N'Lập trình C# WinForms', N'Nguyễn Văn A', N'Giáo trình xây dựng ứng dụng Windows Form'),
(2, N'Hệ quản trị CSDL SQL Server', N'Trần Thị B', N'Kỹ thuật viết Trigger, Procedure và Function');
INSERT INTO Dausach VALUES 
('ISBN01', 1, N'Tiếng Anh', N'Bìa mềm', 'yes'),
('ISBN02', 2, N'Tiếng Việt', N'Bìa cứng', 'no');
INSERT INTO Cuonsach VALUES 
('ISBN01', 1, 'yes'),
('ISBN01', 2, 'no'), 
('ISBN02', 1, 'no'),  
('ISBN02', 2, 'no');

-- B5
CREATE TABLE DocGia (
    ma_DocGia INT PRIMARY KEY,
    ho NVARCHAR(50),
    tenlot NVARCHAR(50),
    ten NVARCHAR(50),
    ngaysinh DATE
);
CREATE TABLE Nguoilon (
    ma_DocGia INT PRIMARY KEY,
    sonha NVARCHAR(50),
    duong NVARCHAR(100),
    quan NVARCHAR(50),
    dienthoai NVARCHAR(20),
    han_sd DATE,
    FOREIGN KEY (ma_DocGia) REFERENCES DocGia(ma_DocGia)
);
CREATE TABLE Treem (
    ma_DocGia INT PRIMARY KEY,
    ma_DocGia_nguoilon INT NOT NULL,
    FOREIGN KEY (ma_DocGia) REFERENCES DocGia(ma_DocGia),
    FOREIGN KEY (ma_DocGia_nguoilon) REFERENCES Nguoilon(ma_DocGia)
);
CREATE TABLE Muon (
    isbn VARCHAR(20),
    ma_cuonsach INT,
    ma_DocGia INT,
    ngay_muon DATE,
    ngay_hethan DATE,
    PRIMARY KEY (isbn, ma_cuonsach),
    FOREIGN KEY (isbn, ma_cuonsach) REFERENCES Cuonsach(isbn, ma_cuonsach),
    FOREIGN KEY (ma_DocGia) REFERENCES DocGia(ma_DocGia)
);

INSERT INTO DocGia VALUES
(101, N'Nguyễn', N'Văn', N'An', '1985-05-12'),
(102, N'Trần', N'Thị', N'Bình', '1990-10-20'),
(103, N'Lê', N'Hoàng', N'Cường', '1988-02-15'),
(201, N'Nguyễn', N'Văn', N'Tí', '2015-08-01'),
(202, N'Nguyễn', N'Thị', N'Tèo', '2017-03-09');
INSERT INTO Nguoilon VALUES
(101, N'12', N'Lê Lợi', N'Quận 1', '0901234567', '2027-12-31'),
(102, N'45', N'Nguyễn Huệ', N'Quận 1', '0912345678', '2026-10-30'),
(103, N'88', N'Võ Văn Ngân', N'Thủ Đức', '0987654321', '2028-01-01');
INSERT INTO Treem VALUES
(201, 101),
(202, 101);

INSERT INTO Muon VALUES
('ISBN01', 1, 101, DATEADD(day, -30, CAST(GETDATE() AS DATE)), DATEADD(day, -20, CAST(GETDATE() AS DATE)));
INSERT INTO Muon VALUES
('ISBN02', 1, 102, CAST(GETDATE() AS DATE), DATEADD(day, 14, CAST(GETDATE() AS DATE)));
INSERT INTO Muon VALUES
('ISBN02', 2, 201, CAST(GETDATE() AS DATE), DATEADD(day, 14, CAST(GETDATE() AS DATE)));
GO

-- B7,8
CREATE DATABASE DeAn;
USE DeAn;

CREATE TABLE PHONGBAN (
    MaPB INT PRIMARY KEY,
    TenPB NVARCHAR(50),
    TruongPhong VARCHAR(9),
    NgayNhanChuc DATE
);
CREATE TABLE NHANVIEN (
    MaNV VARCHAR(9) PRIMARY KEY,
    HoNV NVARCHAR(20),
    TenLot NVARCHAR(30),
    TenNV NVARCHAR(20),
    NgaySinh DATE,
    Phai NVARCHAR(5),
    DiaChi NVARCHAR(100),
    Luong FLOAT,
    MaPB INT FOREIGN KEY REFERENCES PHONGBAN(MaPB)
);
CREATE TABLE DEAN (
    MaDA INT PRIMARY KEY,
    TenDA NVARCHAR(100),
    DiaDiemDA NVARCHAR(100),
    MaPB INT FOREIGN KEY REFERENCES PHONGBAN(MaPB)
);
CREATE TABLE PHANCONG (
    MaNV VARCHAR(9),
    MaDA INT,
    ThoiGian FLOAT, -- Số giờ tham gia dự án (Time_Total)
    PRIMARY KEY (MaNV, MaDA),
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
    FOREIGN KEY (MaDA) REFERENCES DEAN(MaDA)
);
CREATE TABLE THANNHAN (
    MaNV VARCHAR(9),
    TenTN NVARCHAR(50),
    Phai NVARCHAR(5),
    NgaySinh DATE,
    QuanHe NVARCHAR(30),
    PRIMARY KEY (MaNV, TenTN),
    FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);

INSERT INTO PHONGBAN VALUES 
(1, N'Ban Giám Hiệu', NULL, '2020-01-01'),
(4, N'Điều Hành', NULL, '2021-03-15'),
(5, N'Nghiên Cứu & Phát Triển', NULL, '2019-06-01');
INSERT INTO NHANVIEN VALUES 
('NV01', N'Đinh', N'Bá', N'Tiến', '1985-01-09', N'Nam', N'TP.HCM', 35000, 5),
('NV02', N'Nguyễn', N'Thanh', N'Tùng', '1990-12-08', N'Nam', N'Bình Dương', 40000, 5),
('NV03', N'Trần', N'Thị', N'Hạnh', '1995-05-19', N'Nữ', N'Đồng Nai', 28000, 5),
('NV04', N'Lê', N'Quỳnh', N'Như', '1992-06-20', N'Nữ', N'TP.HCM', 45000, 4),
('NV05', N'Vương', N'Ngọc', N'Quyền', '1988-10-10', N'Nam', N'Hà Nội', 20000, 4);
INSERT INTO DEAN VALUES 
(1, N'Sản phẩm X', N'TP.HCM', 5),
(2, N'Sản phẩm Y', N'Hà Nội', 5),
(3, N'Sản phẩm Z', N'TP.HCM', 5),
(10, N'Tin học hóa', N'Bình Dương', 4),
(20, N'Tái cơ cấu', N'TP.HCM', 1);
INSERT INTO PHANCONG VALUES 
('NV01', 1, 40.0),   
('NV01', 2, 70.0),   
('NV02', 1, 110.0),  
('NV02', 2, 160.0), 
('NV03', 1, 35.0),
('NV04', 10, 50.0),
('NV05', 10, 20.0)
INSERT INTO THANNHAN VALUES 
('NV01', N'Đinh An', N'Nam', '2015-05-05', N'Con trai'),
('NV01', N'Nguyễn Hoa', N'Nữ', '1988-03-03', N'Vợ'),
('NV02', N'Nguyễn Nam', N'Nam', '2018-01-01', N'Con trai'),
('NV03', N'Trần Bình', N'Nam', '2020-07-12', N'Con trai');
GO

-- B9
CREATE DATABASE QuanLyGara;
USE QuanLyGara;

CREATE TABLE KHACHHANG (
    MaKH VARCHAR(10) PRIMARY KEY,
    TenKH NVARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(100),
    DienThoai VARCHAR(15)
);
CREATE TABLE THO (
    MaTho VARCHAR(10) PRIMARY KEY,
    TenTho NVARCHAR(50) NOT NULL,
    Nhom INT NOT NULL,
    NhomTruong VARCHAR(10),
    FOREIGN KEY (NhomTruong) REFERENCES THO(MaTho)
);
CREATE TABLE CONGVIEC (
    MaCV VARCHAR(10) PRIMARY KEY,
    NoiDungCV NVARCHAR(200) NOT NULL
);
CREATE TABLE HOPDONG (
    SoHD VARCHAR(10) PRIMARY KEY,
    NgayHD DATE NOT NULL,
    MaKH VARCHAR(10) NOT NULL,
    SoXe VARCHAR(20) NOT NULL,
    TriGiaHD DECIMAL(18,2) DEFAULT 0,
    NgayGiaoDK DATE,
    NgayNgThu DATE,
    FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH),
    CONSTRAINT UQ_Xe_NgayHD UNIQUE (SoXe, NgayHD)
);
CREATE TABLE CHITIET_HD (
    SoHD VARCHAR(10),
    MaCV VARCHAR(10),
    TriGiaCV DECIMAL(18,2) NOT NULL,
    MaTho VARCHAR(10) NOT NULL,
    KhoanTHo DECIMAL(18,2),
    PRIMARY KEY (SoHD, MaCV),
    FOREIGN KEY (SoHD) REFERENCES HOPDONG(SoHD),
    FOREIGN KEY (MaCV) REFERENCES CONGVIEC(MaCV),
    FOREIGN KEY (MaTho) REFERENCES THO(MaTho)
);
CREATE TABLE PHIEUTHU (
    SoPT VARCHAR(10) PRIMARY KEY,
    NgaylapPT DATE NOT NULL,
    SoHD VARCHAR(10) NOT NULL,
    MaKH VARCHAR(10) NOT NULL,
    HoTen NVARCHAR(50),
    SoTienThu DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (SoHD) REFERENCES HOPDONG(SoHD),
    FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH)
);
GO

INSERT INTO KHACHHANG VALUES
('KH01', N'Nguyễn Văn A', N'12 Lê Lợi, Q1', '0901234567'),
('KH02', N'Trần Thị B', N'34 Nguyễn Huệ, Q1', '0912345678'),
('KH03', N'Lê Văn C', N'56 Võ Văn Ngân, Thủ Đức', '0987654321');
INSERT INTO THO (MaTho, TenTho, Nhom, NhomTruong) VALUES
('T01', N'Trần Văn Thợ 1', 1, NULL),
('T02', N'Nguyễn Văn Thợ 2', 1, 'T01'),
('T03', N'Lê Văn Thợ 3', 2, NULL),
('T04', N'Phạm Văn Thợ 4', 2, 'T03'); 
UPDATE THO SET NhomTruong = 'T01' WHERE MaTho = 'T01';
UPDATE THO SET NhomTruong = 'T03' WHERE MaTho = 'T03';
INSERT INTO CONGVIEC VALUES
('CV01', N'Sơn lại toàn bộ thân xe'),
('CV02', N'Thay nhớt và lọc gió'),
('CV03', N'Sửa hệ thống phanh ABS'),
('CV04', N'Đại tu động cơ');
INSERT INTO HOPDONG VALUES
('HD01', '2026-01-10', 'KH01', '51A-12345', 5000000, '2026-01-15', '2026-01-16'),
('HD02', '2026-02-01', 'KH02', '51B-67890', 2000000, '2026-02-05', NULL),
('HD03', '2002-10-01', 'KH03', '52C-99999', 8000000, '2002-11-01', '2002-11-05');
INSERT INTO CHITIET_HD VALUES
('HD01', 'CV01', 3000000, 'T01', 1000000),
('HD01', 'CV02', 2000000, 'T02', 500000),
('HD02', 'CV03', 2000000, 'T01', 700000),
('HD03', 'CV04', 8000000, 'T01', 3000000);
INSERT INTO PHIEUTHU VALUES
('PT01', '2026-01-12', 'HD01', 'KH01', N'Nguyễn Văn A', 3000000),
('PT02', '2002-11-05', 'HD03', 'KH03', N'Lê Văn C', 8000000);
GO

-- B10
CREATE DATABASE QLThi;
USE QLThi;

CREATE TABLE MHOC (
    MAMH VARCHAR(10) PRIMARY KEY,
    TENMH NVARCHAR(100) NOT NULL,
    SOTIET INT NOT NULL
);
CREATE TABLE GV (
    MAGV VARCHAR(10) PRIMARY KEY,
    TENGV NVARCHAR(50) NOT NULL,
    MAMH VARCHAR(10) NULL,
    FOREIGN KEY (MAMH) REFERENCES MHOC(MAMH)
);
CREATE TABLE BUOITHI (
    HKY INT NOT NULL,
    NGAY DATE NOT NULL,
    GIO TIME NOT NULL,
    PHG VARCHAR(10) NOT NULL,
    MAMH VARCHAR(10) NOT NULL,
    TGTHI INT NOT NULL, 
    PRIMARY KEY (HKY, NGAY, GIO, PHG),
    FOREIGN KEY (MAMH) REFERENCES MHOC(MAMH)
);
CREATE TABLE PC_COI_THI (
    MAGV VARCHAR(10) NOT NULL,
    HK INT NOT NULL,
    NGAY DATE NOT NULL,
    GIO TIME NOT NULL,
    PHG VARCHAR(10) NOT NULL,
    PRIMARY KEY (MAGV, HK, NGAY, GIO, PHG),
    FOREIGN KEY (MAGV) REFERENCES GV(MAGV),
    FOREIGN KEY (HK, NGAY, GIO, PHG) REFERENCES BUOITHI(HKY, NGAY, GIO, PHG)
);
GO

INSERT INTO MHOC (MAMH, TENMH, SOTIET) VALUES 
('MH01', N'VĂN HỌC', 45),
('MH02', N'TOÁN HỌC', 30),
('MH03', N'TIẾNG ANH', 45);
INSERT INTO GV (MAGV, TENGV, MAMH) VALUES 
('GV01', N'Nguyễn Văn A', 'MH01'),
('GV02', N'Trần Thị B', 'MH02'),
('GV03', N'Lê Hoàng C', NULL),
('GV04', N'Phạm Thu D', NULL);
INSERT INTO BUOITHI (HKY, NGAY, GIO, PHG, MAMH, TGTHI) VALUES 
(1, '2026-12-10', '07:30:00', 'P101', 'MH01', 150), -- Thi Văn (HK1)
(1, '2026-12-11', '07:30:00', 'P102', 'MH02', 120), -- Thi Toán (HK1)
(1, '2026-12-12', '07:30:00', 'P103', 'MH03', 150), -- Thi Anh (HK1)
(2, '2027-05-15', '07:30:00', 'P101', 'MH01', 150); -- Thi Văn (HK2)
INSERT INTO PC_COI_THI (MAGV, HK, NGAY, GIO, PHG) VALUES 
('GV02', 1, '2026-12-10', '07:30:00', 'P101'),
('GV03', 1, '2026-12-10', '07:30:00', 'P101'),
('GV01', 1, '2026-12-11', '07:30:00', 'P102'),
('GV01', 1, '2026-12-12', '07:30:00', 'P103');
GO