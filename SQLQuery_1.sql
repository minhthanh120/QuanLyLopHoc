CREATE DATABASE SubjectClass;
go

-- Create a new table called '[UserClass]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[UserClass]', 'U') IS NOT NULL
DROP TABLE [dbo].[UserClass]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[UserClass]
(
[Id] CHAR(32) PRIMARY KEY, -- Primary Key column tạo UUID
[FirstName] NVARCHAR(20) NOT NULL,
[LastName] NVARCHAR(20) NOT NULL,
[City] NVARCHAR(20),
[BirthDay] DATETIME,
[Gender] BINARY,
[School] NVARCHAR(100),
[Class] NVARCHAR(100), -- Lớp chủ nhiệm
[Avatar] CHAR(255),
[About] NVARCHAR(255), -- Mô tả bản thâm
[Email] CHAR(320) UNIQUE -- Không đc trùng email
-- Specify more columns here
);
GO

-- Create a new table called '[Message]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Message]', 'U') IS NOT NULL
DROP TABLE [dbo].[Message]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Message]
(
[Id] CHAR(32) PRIMARY KEY, -- Primary Key column
[Sender] NVARCHAR(50) NOT NULL, -- Người gửi
[Addressee] NVARCHAR(50) NOT NULL, -- Người nhận
[SendTime] DATETIME NOT NULL, -- -- Thời gian gửi
[Content] NTEXT NOT NULL, -- Nội dung
FOREIGN KEY ([Sender]) REFERENCES UserClass([Id]), 
FOREIGN KEY ([Addressee]) REFERENCES UserClass([Id]), 

);
GO

-- Create a new table called '[SubjectClass]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[SubjectClass]', 'U') IS NOT NULL
DROP TABLE [dbo].[SubjectClass]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[SubjectClass]
(
[Id] CHAR(32) PRIMARY KEY, -- Primary Key column UUID
[SubjectName] NVARCHAR(50) NOT NULL, --Tên lớp
[Description] NTEXT -- Mô tả lưu code html
-- Specify more columns here
);
GO

-- Create a new table called '[PostType]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[PostType]', 'U') IS NOT NULL
DROP TABLE [dbo].[PostType]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[PostType] -- Loại POST
(
[Id] INT PRIMARY KEY, -- Primary Key column
[TypeName] NVARCHAR(50) NOT NULL -- Tên loại
-- Specify more columns here
);
GO

-- Create a new table called '[Post]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Post]', 'U') IS NOT NULL
DROP TABLE [dbo].[Post]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Post]
(
[Id] CHAR(32) PRIMARY KEY, -- Primary Key column UUID
[UserId] CHAR(32) NOT NULL, -- Primary Key column
[Title] NVARCHAR(255),
[Content] NTEXT NOT NULL, -- nội dung hiển thị, lưu trên sql bằng đoạn code html
[PostTime] DATETIME NOT NULL,
FOREIGN KEY ([UserId]) REFERENCES UserClass([Id])
);
GO

-- Create a new table called '[Transcript]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Transcript]', 'U') IS NOT NULL
DROP TABLE [dbo].[Transcript]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Transcript] -- bảng điểm
(
[Id] CHAR(32) PRIMARY KEY, -- Primary Key column
[SubjectId] CHAR(32) NOT NULL,
);
GO

-- Create a new table called '[DetailTranscript]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[DetailTranscript]', 'U') IS NOT NULL
DROP TABLE [dbo].[DetailTranscript]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[DetailTranscript]
(
[UserId] CHAR(32) PRIMARY KEY, -- Primary Key column
[TranscriptId] CHAR(32) PRIMARY KEY, -- Primary Key column
[DiemCC] FLOAT, -- Điểm chuyên cần
[DiemTX] FLOAT, -- Điểm thường xuyên
[DiemCK] FLOAT -- Điểm cuối kỳ
FOREIGN KEY ([UserId]) REFERENCES UserClass([Id]), 
FOREIGN KEY ([TranscriptId]) REFERENCES TRANSCRIPT([Id])

);
GO

-- Create a new table called '[TeacherTranscript]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[TeacherTranscript]', 'U') IS NOT NULL
DROP TABLE [dbo].[TeacherTranscript]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[TeacherTranscript] --Giáo viên phụ trách
(
[UserId] CHAR(32) PRIMARY KEY, -- Primary Key column id Người dùng
[TranscriptId] CHAR(32) PRIMARY KEY -- Primary Key column Id bảng điểm
FOREIGN KEY ([UserId]) REFERENCES UserClass([Id]), 
FOREIGN KEY ([TranscriptId]) REFERENCES TRANSCRIPT([Id])
);
GO

-- Create a new table called '[TeacherSubject]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[TeacherSubject]', 'U') IS NOT NULL
DROP TABLE [dbo].[TeacherSubject]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[TeacherSubject] -- Giáo viên lớp
(
[UserId] CHAR(32) PRIMARY KEY, -- Primary Key column id giáo viên
[SubjectId] CHAR(32) PRIMARY KEY, -- Primary Key column id môn học
FOREIGN KEY ([UserId]) REFERENCES UserClass([Id]),
FOREIGN KEY ([SubjectId]) REFERENCES SubjectClass([Id])
);
GO

-- Create a new table called '[StudentSubject]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[StudentSubject]', 'U') IS NOT NULL
DROP TABLE [dbo].[StudentSubject]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[StudentSubject]
(
[UserId] CHAR(32) PRIMARY KEY, -- Primary Key column id học sinh
[SubjectId] CHAR(32) PRIMARY KEY, -- Primary Key column id môn học
FOREIGN KEY ([UserId]) REFERENCES UserClass([Id]),
FOREIGN KEY ([SubjectId]) REFERENCES SubjectClass([Id])
);
GO