CREATE DATABASE TinhToan;
GO



CREATE DATABASE QuanLyThuVien;
GO
USE QuanLyThuVien
GO

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
GO

 INSERT INTO Tuasach (ma_tuasach, tuasach, tacgia, tomtat) VALUES 
(1, N'Lập trình C# WinForms', N'Nguyễn Văn A', N'Giáo trình xây dựng ứng dụng Windows Form'),
(2, N'Hệ quản trị CSDL SQL Server', N'Trần Thị B', N'Kỹ thuật viết Trigger, Procedure và Function'),
(3, N'Cấu trúc dữ liệu và giải thuật', N'Lê Minh C', N'Tối ưu hóa thuật toán và cấu trúc cây, đồ thị'),
(4, N'Trí tuệ nhân tạo căn bản', N'Phạm Hoàng D', N'Nhập môn Machine Learning và Search Algorithms'),
(5, N'Thiết kế kiến trúc phần mềm', N'Đặng Thanh E', N'Mô hình MVC, Microservices và Design Patterns');
GO
INSERT INTO Dausach (isbn, ma_tuasach, ngonngu, bia, trangthai) VALUES 
('ISBN01', 1, N'Tiếng Anh', N'Bìa mềm', 'yes'),
('ISBN02', 2, N'Tiếng Việt', N'Bìa cứng', 'no'),
('ISBN03', 3, N'Tiếng Việt', N'Bìa mềm', 'yes'),
('ISBN04', 4, N'Tiếng Anh', N'Bìa cứng', 'yes'),
('ISBN05', 5, N'Tiếng Việt', N'Bìa mềm', 'no');
GO
INSERT INTO Cuonsach (isbn, ma_cuonsach, tinhtrang) VALUES 
('ISBN01', 1, 'yes'),
('ISBN01', 2, 'no'), 
('ISBN02', 1, 'no'),  
('ISBN02', 2, 'no'),
('ISBN03', 1, 'yes'),
('ISBN03', 2, 'yes'),
('ISBN03', 3, 'no'),
('ISBN04', 1, 'yes'),
('ISBN04', 2, 'no'),
('ISBN05', 1, 'no'),
('ISBN05', 2, 'no');
GO
INSERT INTO DocGia (ma_DocGia, ho, tenlot, ten, ngaysinh) VALUES
(101, N'Nguyễn', N'Văn', N'An', '1985-05-12'),
(102, N'Trần', N'Thị', N'Bình', '1990-10-20'),
(103, N'Lê', N'Hoàng', N'Cường', '1988-02-15'),
(201, N'Nguyễn', N'Văn', N'Tí', '2015-08-01'),
(202, N'Nguyễn', N'Thị', N'Tèo', '2017-03-09'),
(104, N'Phạm', N'Văn', N'Dũng', '1980-11-25'),
(105, N'Vũ', N'Thị', N'Hoa', '1995-07-04'),
(203, N'Lê', N'Hoàng', N'Bảo', '2018-09-12'),
(204, N'Trần', N'Gia', N'Huy', '2016-04-18');
GO
INSERT INTO Nguoilon (ma_DocGia, sonha, duong, quan, dienthoai, han_sd) VALUES
(101, N'12', N'Lê Lợi', N'Quận 1', '0901234567', '2027-12-31'),
(102, N'45', N'Nguyễn Huệ', N'Quận 1', '0912345678', '2026-10-30'),
(103, N'88', N'Võ Văn Ngân', N'Thủ Đức', '0987654321', '2028-01-01'),
(104, N'102', N'Cách Mạng Tháng 8', N'Quận 3', '0933445566', '2027-05-20'),
(105, N'25', N'Hai Bà Trưng', N'Quận 1', '0977889900', '2028-08-15');
GO
INSERT INTO Treem (ma_DocGia, ma_DocGia_nguoilon) VALUES
(201, 101),
(202, 101),
(203, 103),
(204, 104);
GO
INSERT INTO Muon (isbn, ma_cuonsach, ma_DocGia, ngay_muon, ngay_hethan) VALUES
('ISBN01', 1, 101, DATEADD(day, -30, CAST(GETDATE() AS DATE)), DATEADD(day, -20, CAST(GETDATE() AS DATE))),
('ISBN02', 1, 102, CAST(GETDATE() AS DATE), DATEADD(day, 14, CAST(GETDATE() AS DATE))),
('ISBN02', 2, 201, CAST(GETDATE() AS DATE), DATEADD(day, 14, CAST(GETDATE() AS DATE))),
('ISBN01', 2, 103, CAST(GETDATE() AS DATE), DATEADD(day, 14, CAST(GETDATE() AS DATE))),
('ISBN03', 3, 203, CAST(GETDATE() AS DATE), DATEADD(day, 14, CAST(GETDATE() AS DATE))),
('ISBN04', 2, 104, DATEADD(day, -40, CAST(GETDATE() AS DATE)), DATEADD(day, -18, CAST(GETDATE() AS DATE))),
('ISBN05', 1, 102, CAST(GETDATE() AS DATE), DATEADD(day, 7, CAST(GETDATE() AS DATE))),
('ISBN05', 2, 204, CAST(GETDATE() AS DATE), DATEADD(day, 10, CAST(GETDATE() AS DATE)));
GO



CREATE DATABASE DeAn;
GO
USE DeAn;
GO

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
GO

INSERT INTO PHONGBAN (MaPB, TenPB, TruongPhong, NgayNhanChuc) VALUES 
(1, N'Ban Giám Hiệu', NULL, '2020-01-01'),
(4, N'Điều Hành', NULL, '2021-03-15'),
(5, N'Nghiên Cứu & Phát Triển', NULL, '2019-06-01'),
(2, N'Tổ Chức Cán Bộ', NULL, '2022-02-01'),
(3, N'Kế Hoạch Tài Chính', NULL, '2021-08-10');
GO
INSERT INTO NHANVIEN (MaNV, HoNV, TenLot, TenNV, NgaySinh, Phai, DiaChi, Luong, MaPB) VALUES 
('NV01', N'Đinh', N'Bá', N'Tiến', '1985-01-09', N'Nam', N'TP.HCM', 35000, 5),
('NV02', N'Nguyễn', N'Thanh', N'Tùng', '1990-12-08', N'Nam', N'Bình Dương', 40000, 5),
('NV03', N'Trần', N'Thị', N'Hạnh', '1995-05-19', N'Nữ', N'Đồng Nai', 28000, 5),
('NV04', N'Lê', N'Quỳnh', N'Như', '1992-06-20', N'Nữ', N'TP.HCM', 45000, 4),
('NV05', N'Vương', N'Ngọc', N'Quyền', '1988-10-10', N'Nam', N'Hà Nội', 20000, 4),
('NV06', N'Lê', N'Văn', N'Hưng', '1987-03-14', N'Nam', N'TP.HCM', 32000, 5),
('NV07', N'Phạm', N'Thị', N'Mai', '1993-09-22', N'Nữ', N'Bình Dương', 22000, 5),
('NV08', N'Trần', N'Văn', N'Giang', '1984-11-05', N'Nam', N'TP.HCM', 38000, 4),
('NV09', N'Ngô', N'Minh', N'Tuấn', '1996-01-17', N'Nam', N'Long An', 26000, 2),
('NV10', N'Đỗ', N'Thị', N'Thảo', '1998-04-30', N'Nữ', N'TP.HCM', 24000, 3);
GO
UPDATE PHONGBAN SET TruongPhong = 'NV04' WHERE MaPB = 4;
UPDATE PHONGBAN SET TruongPhong = 'NV02' WHERE MaPB = 5;
UPDATE PHONGBAN SET TruongPhong = 'NV09' WHERE MaPB = 2;
GO
INSERT INTO DEAN (MaDA, TenDA, DiaDiemDA, MaPB) VALUES 
(1, N'Sản phẩm X', N'TP.HCM', 5),
(2, N'Sản phẩm Y', N'Hà Nội', 5),
(3, N'Sản phẩm Z', N'TP.HCM', 5),
(10, N'Tin học hóa', N'Bình Dương', 4),
(20, N'Tái cơ cấu', N'TP.HCM', 1),
(30, N'Đào tạo nội bộ', N'TP.HCM', 2),
(40, N'Chuyển đổi số kế toán', N'TP.HCM', 3);
GO
INSERT INTO PHANCONG (MaNV, MaDA, ThoiGian) VALUES 
('NV01', 1, 40.0),    
('NV01', 2, 70.0),    
('NV02', 1, 110.0),   
('NV02', 2, 160.0),   
('NV03', 1, 35.0),    
('NV04', 10, 50.0),  
('NV05', 10, 20.0),   
('NV06', 1, 45.0),    
('NV06', 3, 85.0),    
('NV07', 2, 15.0),    
('NV08', 10, 120.0), 
('NV09', 30, 65.0),
('NV10', 40, 25.0);
GO
INSERT INTO THANNHAN (MaNV, TenTN, Phai, NgaySinh, QuanHe) VALUES 
('NV01', N'Đinh An', N'Nam', '2015-05-05', N'Con trai'),
('NV01', N'Nguyễn Hoa', N'Nữ', '1988-03-03', N'Vợ'),
('NV02', N'Nguyễn Nam', N'Nam', '2018-01-01', N'Con trai'),
('NV03', N'Trần Bình', N'Nam', '2020-07-12', N'Con trai'),
('NV04', N'Lê Minh Khang', N'Nam', '2021-02-14', N'Con trai'),
('NV06', N'Lê Thùy Chi', N'Nữ', '2019-10-10', N'Con gái'),
('NV08', N'Trần Thị Mai', N'Nữ', '1986-06-18', N'Vợ');
GO



CREATE DATABASE QuanLyGara;
GO
USE QuanLyGara;
GO

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

INSERT INTO KHACHHANG (MaKH, TenKH, DiaChi, DienThoai) VALUES
('KH01', N'Nguyễn Văn A', N'12 Lê Lợi, Q1', '0901234567'),
('KH02', N'Trần Thị B', N'34 Nguyễn Huệ, Q1', '0912345678'),
('KH03', N'Lê Văn C', N'56 Võ Văn Ngân, Thủ Đức', '0987654321'),
('KH04', N'Phạm Quang D', N'78 Hoàng Văn Thụ, Phú Nhuận', '0911223344'),
('KH05', N'Hoàng Thị E', N'90 Pasteur, Q3', '0988776655');
GO
INSERT INTO THO (MaTho, TenTho, Nhom, NhomTruong) VALUES
('T01', N'Trần Văn Thợ 1', 1, NULL),
('T02', N'Nguyễn Văn Thợ 2', 1, NULL),
('T03', N'Lê Văn Thợ 3', 2, NULL),
('T04', N'Phạm Văn Thợ 4', 2, NULL),
('T05', N'Hoàng Văn Thợ 5', 3, NULL),
('T06', N'Đỗ Văn Thợ 6 (Rảnh rỗi)', 3, NULL);
GO
UPDATE THO SET NhomTruong = 'T01' WHERE MaTho IN ('T01', 'T02');
UPDATE THO SET NhomTruong = 'T03' WHERE MaTho IN ('T03', 'T04');
UPDATE THO SET NhomTruong = 'T05' WHERE MaTho IN ('T05', 'T06');
GO
INSERT INTO CONGVIEC (MaCV, NoiDungCV) VALUES
('CV01', N'Sơn lại toàn bộ thân xe'),
('CV02', N'Thay nhớt và lọc gió'),
('CV03', N'Sửa hệ thống phanh ABS'),
('CV04', N'Đại tu động cơ'),
('CV05', N'Cân chỉnh thước lái và góc đặt bánh'),
('CV06', N'Bảo dưỡng hệ thống điều hòa');
GO
INSERT INTO HOPDONG (SoHD, NgayHD, MaKH, SoXe, TriGiaHD, NgayGiaoDK, NgayNgThu) VALUES
('HD01', '2026-01-10', 'KH01', '51A-12345', 5000000, '2026-01-15', '2026-01-16'),
('HD02', '2026-02-01', 'KH02', '51B-67890', 2000000, '2026-02-05', NULL),
('HD03', '2002-10-01', 'KH03', '52C-99999', 8000000, '2002-11-01', '2002-11-05'),
('HD04', '2002-05-15', 'KH04', '50D-11111', 4500000, '2002-05-20', '2002-05-25'),
('HD05', '2026-03-01', 'KH05', '51E-33333', 10000000, '2026-03-10', '2026-03-12');
GO
INSERT INTO CHITIET_HD (SoHD, MaCV, TriGiaCV, MaTho, KhoanTHo) VALUES
('HD01', 'CV01', 3000000, 'T01', 1000000),
('HD01', 'CV02', 2000000, 'T02', 500000),
('HD02', 'CV03', 2000000, 'T01', 700000),
('HD03', 'CV04', 8000000, 'T01', 3000000),
('HD04', 'CV02', 1500000, 'T03', 400000),
('HD04', 'CV05', 3000000, 'T04', 900000),
('HD05', 'CV04', 6000000, 'T01', 2500000),
('HD05', 'CV06', 4000000, 'T05', 1200000);
GO
INSERT INTO PHIEUTHU (SoPT, NgaylapPT, SoHD, MaKH, HoTen, SoTienThu) VALUES
('PT01', '2026-01-12', 'HD01', 'KH01', N'Nguyễn Văn A', 3000000),
('PT02', '2002-11-05', 'HD03', 'KH03', N'Lê Văn C', 8000000),
('PT03', '2002-05-25', 'HD04', 'KH04', N'Phạm Quang D', 4500000),
('PT04', '2026-03-10', 'HD05', 'KH05', N'Hoàng Thị E', 6000000);
GO



-- B10
CREATE DATABASE QLThi;
GO
USE QLThi;
GO

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
('MH03', N'TIẾNG ANH', 45),
('MH04', N'VẬT LÝ', 30),
('MH05', N'TIN HỌC ĐẠI CƯƠNG', 60);
GO
INSERT INTO GV (MAGV, TENGV, MAMH) VALUES 
('GV01', N'Nguyễn Văn A', 'MH01'), 
('GV02', N'Trần Thị B', 'MH02'),  
('GV03', N'Lê Hoàng C', NULL),     
('GV04', N'Phạm Thu D', NULL),    
('GV05', N'Hoàng Minh E', 'MH01'), 
('GV06', N'Đỗ Thanh F', 'MH04'),   
('GV07', N'Vũ Quốc G', 'MH05'),    
('GV08', N'Bùi Mai H', NULL);      
GO
INSERT INTO BUOITHI (HKY, NGAY, GIO, PHG, MAMH, TGTHI) VALUES 
(1, '2026-12-10', '07:30:00', 'P101', 'MH01', 150),
(1, '2026-12-11', '07:30:00', 'P102', 'MH02', 120), 
(1, '2026-12-12', '07:30:00', 'P103', 'MH03', 150), 
(2, '2027-05-15', '07:30:00', 'P101', 'MH01', 150),
(1, '2026-12-13', '08:00:00', 'P104', 'MH04', 120), 
(1, '2026-12-14', '08:00:00', 'P105', 'MH05', 150), 
(1, '2026-12-15', '07:30:00', 'P106', 'MH01', 150), 
(2, '2027-05-16', '08:00:00', 'P102', 'MH02', 120); 
GO
INSERT INTO PC_COI_THI (MAGV, HK, NGAY, GIO, PHG) VALUES 
('GV02', 1, '2026-12-10', '07:30:00', 'P101'),
('GV03', 1, '2026-12-10', '07:30:00', 'P101'),
('GV01', 1, '2026-12-11', '07:30:00', 'P102'), 
('GV01', 1, '2026-12-12', '07:30:00', 'P103'),
('GV05', 1, '2026-12-11', '07:30:00', 'P102'), 
('GV06', 1, '2026-12-14', '08:00:00', 'P105'), 
('GV07', 1, '2026-12-13', '08:00:00', 'P104'), 
('GV04', 2, '2027-05-15', '07:30:00', 'P101'); 
GO