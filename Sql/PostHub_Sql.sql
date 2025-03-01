USE [PostHub]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/21/2024 9:09:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/21/2024 9:09:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/21/2024 9:09:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/21/2024 9:09:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/21/2024 9:09:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/21/2024 9:09:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/21/2024 9:09:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[DateOfBirth] [nvarchar](max) NULL,
	[ProfileImage] [nvarchar](max) NULL,
	[IsActive] [int] NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/21/2024 9:09:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/21/2024 9:09:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[State] [int] NOT NULL,
	[CategoryTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryTypes]    Script Date: 12/21/2024 9:09:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[State] [int] NOT NULL,
 CONSTRAINT [PK_CategoryTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 12/21/2024 9:09:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[PostId] [int] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 12/21/2024 9:09:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[StateRes] [int] NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 12/21/2024 9:09:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Slug] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[View] [int] NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[State] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscribes]    Script Date: 12/21/2024 9:09:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscribes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_Subscribes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241127234649_NewInit', N'8.0.11')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'458681b0-5dbb-4992-b341-726eeee3964a', N'user', N'USER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e324407a-3db3-4154-b30a-47dd8bd38fc7', N'admin', N'ADMIN', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b288fef2-594b-4c51-9f5b-30f6ba88ff50', N'458681b0-5dbb-4992-b341-726eeee3964a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b33dfaa8-86a3-4037-b3d0-e365468938fb', N'458681b0-5dbb-4992-b341-726eeee3964a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e3e0c458-bb79-4721-a86a-4f802f662dc2', N'458681b0-5dbb-4992-b341-726eeee3964a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8f9df925-ee05-4076-a5b0-7146f9f2ee5a', N'e324407a-3db3-4154-b30a-47dd8bd38fc7')
GO
INSERT [dbo].[AspNetUsers] ([Id], [DateOfBirth], [ProfileImage], [IsActive], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8f9df925-ee05-4076-a5b0-7146f9f2ee5a', N'', N'imagesuongmu_20240214_000212.jpg', 1, N'Thuận', N'vana@gmail.com', N'VANA@GMAIL.COM', N'vana@gmail.com', N'VANA@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEG2I/pyOZx2CXr8yohanK5RRSdmPole6ksyzqlnkY0bi94VxGmh14v0x3MgemTRL4A==', N'VL2MZTV2JGONLMCZHGYC6OJ2BJ5TMUND', N'6c1f61af-999e-402e-8366-f63d100f308a', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [DateOfBirth], [ProfileImage], [IsActive], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b288fef2-594b-4c51-9f5b-30f6ba88ff50', N'12/11/2024', N'', 1, N'Thị C', N'vanc@gmail.com', N'VANC@GMAIL.COM', N'vanc@gmail.com', N'VANC@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEMnY/L8CbC6YCFQQe9r3DliISuWFbjBAV7/U0XwjvdBmIQf9u+39qylmMhveK245GQ==', N'6UWJZMUCVNPPSN4EN5SG7WXNPLNS7Z6O', N'4492d22e-3200-4df5-801b-f2a359e3a71e', N'0553217546', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [DateOfBirth], [ProfileImage], [IsActive], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b33dfaa8-86a3-4037-b3d0-e365468938fb', N'', N'', 1, N'văn d', N'vand@gmail.com', N'VAND@GMAIL.COM', N'vand@gmail.com', N'VAND@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEJUcG5YSBrdQoXnkf/tZzgROTT/cXJr+TX4cE7ez6bSPTnnGMRhYa9nOAiWpvGuS2w==', N'PY5RHLCGMJBBF4U7IDW54TY3RECNYXHL', N'bd66aa06-67be-4f39-9923-5267ca6a4492', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [DateOfBirth], [ProfileImage], [IsActive], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e3e0c458-bb79-4721-a86a-4f802f662dc2', N'', N'imagesuongmu_20241212_194802.jpg', 1, N'Văn B', N'vanb@gmail.com', N'VANB@GMAIL.COM', N'vanb@gmail.com', N'VANB@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAECHphpZf68G2J4+iikmsRjHYInviDaEDLgZUMKU01TYgXHSB5EFJXXFLsXy2ZQF2DQ==', N'VTOFBK75WSPTUTLCRBVSEL2ANG6A7AOA', N'61c174b9-149b-4a6c-aaaa-91369affe77f', N'0833545881', 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [State], [CategoryTypeId]) VALUES (1, N'Chính trị', 1, 1)
INSERT [dbo].[Categories] ([Id], [Name], [State], [CategoryTypeId]) VALUES (2, N'text', 0, 1)
INSERT [dbo].[Categories] ([Id], [Name], [State], [CategoryTypeId]) VALUES (3, N'testthethao1', 0, 1)
INSERT [dbo].[Categories] ([Id], [Name], [State], [CategoryTypeId]) VALUES (4, N'Dân sinh', 1, 1)
INSERT [dbo].[Categories] ([Id], [Name], [State], [CategoryTypeId]) VALUES (5, N'Lao động việc làm', 1, 1)
INSERT [dbo].[Categories] ([Id], [Name], [State], [CategoryTypeId]) VALUES (7, N'Giao thông', 1, 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[CategoryTypes] ON 

INSERT [dbo].[CategoryTypes] ([Id], [Name], [State]) VALUES (1, N'Thời sự', 1)
INSERT [dbo].[CategoryTypes] ([Id], [Name], [State]) VALUES (2, N'Thể thao', 1)
INSERT [dbo].[CategoryTypes] ([Id], [Name], [State]) VALUES (4, N'test', 0)
INSERT [dbo].[CategoryTypes] ([Id], [Name], [State]) VALUES (5, N'Giáo dục', 1)
INSERT [dbo].[CategoryTypes] ([Id], [Name], [State]) VALUES (6, N'Khoa học', 1)
SET IDENTITY_INSERT [dbo].[CategoryTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [Content], [CreatedAt], [UserId], [PostId]) VALUES (1, N'tại sao vậy?', CAST(N'2024-12-11T13:56:27.6790136' AS DateTime2), N'e3e0c458-bb79-4721-a86a-4f802f662dc2', 1)
INSERT [dbo].[Comments] ([Id], [Content], [CreatedAt], [UserId], [PostId]) VALUES (2, N'tuyệt vời thế nhỉ', CAST(N'2024-12-11T13:58:09.5425801' AS DateTime2), N'e3e0c458-bb79-4721-a86a-4f802f662dc2', 1)
INSERT [dbo].[Comments] ([Id], [Content], [CreatedAt], [UserId], [PostId]) VALUES (3, N'quá là hay luôn.', CAST(N'2024-12-11T14:17:48.0365375' AS DateTime2), N'b288fef2-594b-4c51-9f5b-30f6ba88ff50', 1)
INSERT [dbo].[Comments] ([Id], [Content], [CreatedAt], [UserId], [PostId]) VALUES (4, N'Anh ấy cũng đưa ra quyết định tự tin nhỉ trong khi công việc đang ổn định tại hà hội.', CAST(N'2024-12-11T14:38:49.2656615' AS DateTime2), N'8f9df925-ee05-4076-a5b0-7146f9f2ee5a', 1)
INSERT [dbo].[Comments] ([Id], [Content], [CreatedAt], [UserId], [PostId]) VALUES (5, N'quá là hay luôn.', CAST(N'2024-12-11T14:39:50.7258675' AS DateTime2), N'e3e0c458-bb79-4721-a86a-4f802f662dc2', 1)
INSERT [dbo].[Comments] ([Id], [Content], [CreatedAt], [UserId], [PostId]) VALUES (6, N'tuyệt vời thế nhỉ', CAST(N'2024-12-11T14:39:56.7961727' AS DateTime2), N'e3e0c458-bb79-4721-a86a-4f802f662dc2', 1)
INSERT [dbo].[Comments] ([Id], [Content], [CreatedAt], [UserId], [PostId]) VALUES (7, N'tuyệt vời thế nhỉ', CAST(N'2024-12-12T20:11:59.5480616' AS DateTime2), N'e3e0c458-bb79-4721-a86a-4f802f662dc2', 6)
INSERT [dbo].[Comments] ([Id], [Content], [CreatedAt], [UserId], [PostId]) VALUES (8, N'tuyệt vời thế nhỉ', CAST(N'2024-12-12T20:14:27.1058922' AS DateTime2), N'e3e0c458-bb79-4721-a86a-4f802f662dc2', 3)
INSERT [dbo].[Comments] ([Id], [Content], [CreatedAt], [UserId], [PostId]) VALUES (9, N'tại sao vậy?', CAST(N'2024-12-12T20:16:10.2539759' AS DateTime2), N'e3e0c458-bb79-4721-a86a-4f802f662dc2', 3)
INSERT [dbo].[Comments] ([Id], [Content], [CreatedAt], [UserId], [PostId]) VALUES (11, N'Nhìn xót xa quá.', CAST(N'2024-12-12T20:20:00.1239729' AS DateTime2), N'e3e0c458-bb79-4721-a86a-4f802f662dc2', 4)
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([Id], [Email], [Content], [CreatedAt], [StateRes]) VALUES (3, N'vanb@gmail.com', N'lỗi phông chữ rồi', CAST(N'2024-11-28T15:06:12.3410312' AS DateTime2), 0)
INSERT [dbo].[Contacts] ([Id], [Email], [Content], [CreatedAt], [StateRes]) VALUES (5, N'vanc@gmail.com', N'sao tôi bình luận không được.', CAST(N'2024-11-28T15:07:18.6217935' AS DateTime2), 1)
INSERT [dbo].[Contacts] ([Id], [Email], [Content], [CreatedAt], [StateRes]) VALUES (6, N'vanb@gmail.com', N'Bị lỗi khi nhấn vào bài viết', CAST(N'2024-12-12T15:30:15.2129983' AS DateTime2), 0)
INSERT [dbo].[Contacts] ([Id], [Email], [Content], [CreatedAt], [StateRes]) VALUES (7, N'vanb@gmail.com', N'Bị lỗi khi nhấn vào bài viết', CAST(N'2024-12-13T21:23:21.0228084' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (1, N'Kỹ sư dệt may bỏ phố về quê trồng hương thảo', N'Đang có công việc ổn định ở Hà Nội, anh Nguyễn Văn Thắng bất ngờ xin nghỉ về quê Thái Bình trồng hương thảo làm tinh dầu, trở thành nông dân xuất sắc 2024.', N'ky-su-det-may-bo-pho-ve-que-trong-huong-thao', N'kysudetmay_20241209_152524.jpg', 10, CAST(N'2024-11-29T06:49:41.2545660' AS DateTime2), 1, 4)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (2, N'Sục bùn thu hoạch củ sen', N'Củ sen nằm sâu dưới lớp bùn 30-50 cm, để thu hoạch thợ phải dùng máy bơm áp lực cao sục xuống làm loãng bùn, lộ diện củ.', N'suc-bun-thu-hoach-cu-sen', N'_20241129_090446.jpg', 0, CAST(N'2024-11-29T09:04:46.6273567' AS DateTime2), 1, 4)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (3, N'Ngâm mình cắt cỏ năn trên cánh đồng miền Tây', N'Nhóm lao động ngâm mình nhiều giờ dưới nước để cắt năn - loại cỏ mọc tự nhiên trên các cánh đồng trũng phèn ở huyện Tháp Mười, thu nhập 300.000 đồng mỗi ngày.', N'ngam-minh-cat-co-nan-tren-canh-ong-mien-tay', N'imagecatco_20241129_090734.jpg', 6, CAST(N'2024-11-29T09:07:34.1887390' AS DateTime2), 1, 4)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (4, N'Làng đào cổ thụ mất Tết', N'80% cây đào cảnh ở xã Đặng Cương, huyện An Dương phải vứt bỏ sau bão Yagi khiến người dân thiệt hại hàng trăm tỷ đồng.  Đứng giữa vườn trồng 40 cây đào cổ thụ đang chết khô, ông Nguyễn Xuân Ninh, 62 tuổi, ở xã Đặng Cương, cho biết từ bé đến giờ mới thấy làng mình thiệt hại thảm khốc đến thế. Cơn bão Yagi với sức gió mạnh nhất cấp 13, giật cấp 16 đã nhổ tung những gốc đào chắc chắn nhất, tuốt trụi lá. Sau bão, dân làng đổ ra đồng dựng lại cây nhưng gặp mưa lớn, ngập lụt kéo dài cả tuần.', N'lang-ao-co-thu-mat-tet', N'imagecothu_20241129_090854.jpg', 4, CAST(N'2024-11-29T09:08:54.0189306' AS DateTime2), 1, 4)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (5, N'Thủ phủ hoa giấy miền Bắc', N'Ban đầu chỉ vài nhà trồng hoa giấy bán, sau 30 năm xã Phù Đổng, huyện Gia Lâm có hơn 450 hộ trồng đủ các loại hoa trong nước và nhập ngoại.  Xã Phù Đổng cách trung tâm Hà Nội khoảng 20 km về phía đông bắc. Không chỉ nổi tiếng với khu di tích quốc gia đặc biệt đền Phù Đổng và lễ hội Gióng - di sản văn hóa phi vật thể đã được UNESCO công nhận, xã còn được biết đến là thủ phủ hoa giấy miền Bắc với diện tích gần 150 hecta.', N'thu-phu-hoa-giay-mien-bac', N'imagehoagiay_20241129_091001.jpg', 0, CAST(N'2024-11-29T09:10:01.7779587' AS DateTime2), 1, 1)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (6, N'Làm giàu từ cánh đồng mẫu lớn', N'Thấy dân làng bỏ ruộng, bà Hoàng Thị Gái thuê lại, rồi dồn điền đổi thửa để thành cánh đồng rộng lớn, canh tác giống lúa chất lượng cao.  Bà Hoàng Thị Gái, 53 tuổi, sinh ra trong gia đình thuần nông ở làng Mân, xã An Hòa, huyện Vĩnh Bảo. Không có điều kiện học lên cao, bà sớm lấy chồng rồi làm nghề cấy thuê mưu sinh.  Năm 1997, mong muốn có thu nhập tốt hơn để lo cho con cái, bà Gái bàn với chồng mở đại lý thu mua thóc gạo. "Công việc khá thuận lợi, tôi có nhiều mối làm ăn khắp cả nước, thu nhập tốt lắm", bà Gái nhớ lại.', N'lam-giau-tu-canh-ong-mau-lon', N'imagecanhdong_20241129_091046.jpg', 4, CAST(N'2024-11-29T09:10:46.7150881' AS DateTime2), 1, 4)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (8, N' Thế giớiThứ ba, 3/12/2024, 19:42 (GMT+7) Chủ tịch Quốc hội đến Tokyo, bắt đầu thăm Nhật Bản', N'Chủ tịch Quốc hội Trần Thanh Mẫn đến thủ đô Tokyo tối 3/12, bắt đầu thăm chính thức Nhật Bản đến ngày 7/12.  Chuyên cơ chở ông Trần Thanh Mẫn và phu nhân Nguyễn Thị Thanh Nga hạ cánh tại sân bay quốc tế Haneda, Tokyo tối nay. Lễ đón đoàn tại sân bay có Chủ tịch Uỷ ban điều hành Thượng viện Makino, Tổng vụ trưởng Đối ngoại Thượng viện Nhật Bản.', N'-the-gioithu-ba-3122024-1942-gmt7-chu-tich-quoc-hoi-en-tokyo-bat-au-tham-nhat-ban', N'imagequochoi_20241204_154509.jpg', 1, CAST(N'2024-12-04T15:45:09.9904426' AS DateTime2), 1, 1)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (9, N'Đề xuất lập Cục Phòng, chống lãng phí thuộc Bộ Tài chính', N'Bộ Tài chính đề xuất thành lập một đơn vị chuyên trách cấp Cục để thống nhất tham mưu và quản lý công tác phòng, chống lãng phí trên phạm vi toàn quốc.  Đề xuất này được Bộ đưa ra khi xây dựng dự thảo Luật Tiết kiệm, chống lãng phí. Dự thảo đang được Bộ Tư pháp thẩm định.  Hồ sơ nêu 7 nhóm chính sách lớn, trong đó có việc thành lập Cục Phòng, chống lãng phí. Cục này sẽ có nhiệm vụ xây dựng và hoàn thiện chế độ, chính sách; triển khai, ban hành các chương trình tổng thể về tiết kiệm, chống lãng phí; hướng dẫn các Bộ, ngành và địa phương thực hiện quy định của Luật.', N'e-xuat-lap-cuc-phong-chong-lang-phi-thuoc-bo-tai-chinh', N'imagetaichinh_20241204_154630.jpg', 1, CAST(N'2024-12-04T15:46:30.7419636' AS DateTime2), 1, 1)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (10, N'TP HCM mù mịt sương', N'Sương mù dày đặc bao phủ nhiều toà nhà, công trình ở thành phố từ sáng đến trưa, hạn chế tầm nhìn người đi đường, ngày 3/12.', N'tp-hcm-mu-mit-suong', N'imagesuongmu_20241204_154753.jpg', 0, CAST(N'2024-12-04T15:47:53.0492018' AS DateTime2), 1, 4)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (11, N'Xóa nhà tạm, nhà dột nát giúp người nghèo an cư', N'Cà MauĐể thay thế các nhà tạm, nhà đột nát của dân nghèo, huyện U Minh xây mới hoặc sửa chữa 75 căn nhà trong năm 2024.  U Minh là một trong những huyện còn tỷ lệ hộ nghèo, cận nghèo cao trong tỉnh Cà Mau. Thời gian qua, đơn vị triển khai nhiều giải pháp thực hiện chương trình mục tiêu quốc gia về giảm nghèo bền vững, trong đó có việc xây nhà mới thay thế nhà tạm, nhà dột nát cho người dân. Huyện đã thành lập Ban chỉ đạo xóa nhà tạm, nhà dột nát trên địa bàn gồm 30 thành viên, do Bí thư huyện ủy, Chủ tịch HĐND huyện làm trưởng ban.', N'xoa-nha-tam-nha-dot-nat-giup-nguoi-ngheo-an-cu', N'dansinh_xoadoi_20241204_154848.jpg', 0, CAST(N'2024-12-04T15:48:48.9031523' AS DateTime2), 1, 4)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (12, N'Bình Định tái định cư cho người dân vùng núi lở', N'Tỉnh sẽ xây khu tái định cư cho 78 hộ dân ở huyện miền núi An Lão, di dời người dân khỏi vùng núi lở.  Ngày 2/12, UBND Bình Định phê duyệt chủ trương đầu tư dự án khu tái định cư vùng thiên tai thôn Trà Cong, xã An Hòa, huyện An Lão nhằm di dời các hộ nằm trong khu vực bị sạt lở đất do thiên tai, ổn định đời sống người dân.', N'binh-inh-tai-inh-cu-cho-nguoi-dan-vung-nui-lo', N'dansinh_xaclo_20241204_154946.jpg', 1, CAST(N'2024-12-04T15:49:46.9681946' AS DateTime2), 1, 4)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (13, N'Đề xuất nuôi thủy sản ở vùng đệm vịnh Hạ Long', N'Quảng Ninh vừa trình Bộ Văn hóa Thể thao và Du lịch kế hoạch nuôi trồng thủy sản tại vùng đệm vịnh Hạ Long nhằm kết hợp phát triển du lịch, tạo sản phẩm trải nghiệm mới cho du khách.  Đề xuất nhằm cụ thể hóa mục tiêu phát triển nuôi biển bền vững theo chỉ đạo của Thủ tướng, đồng thời mang lại sinh kế ổn định cho người dân địa phương. UBND tỉnh Quảng Ninh cho biết dự án sẽ kết hợp các khu vực nuôi trồng thủy sản với khu trình diễn phục vụ du lịch, qua đó tạo điểm nhấn mới, tăng sức hấp dẫn cho du lịch Hạ Long.', N'e-xuat-nuoi-thuy-san-o-vung-em-vinh-ha-long', N'dansinh_vinhhalong_20241204_155200.jpg', 0, CAST(N'2024-12-04T15:52:00.6647339' AS DateTime2), 1, 4)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (14, N'Bãi nuôi hàu trái phép bủa vây sông', N'Nghệ AnLòng sông, cửa biển ở thị xã Hoàng Mai, huyện Quỳnh Lưu bị bủa vây bởi hàng nghìn cọc tre, bè mảng nuôi hàu khiến dòng chảy thay đổi, cản trở tàu thuyền.  Sông Mai Giang (hay còn gọi là Hoàng Mai) dài 18 km, chảy qua phường Mai Hùng, Quỳnh Dị, Quỳnh Thiện, Quỳnh Liên, xã Quỳnh Lập... của thị xã Hoàng Mai. Hàng chục năm qua, người dân nơi đây thường làm bè mảng rộng 10-20 m2, đóng cọc tre dài 2-3 m neo lại, sau đó mua dây và vỏ hàu về buộc vào bè thả xuống sông để hàu làm tổ sinh trưởng, đến kỳ thu hoạch bán.', N'bai-nuoi-hau-trai-phep-bua-vay-song', N'dansinh_baihao_20241204_155253.jpg', 0, CAST(N'2024-12-04T15:52:54.0079429' AS DateTime2), 1, 4)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (15, N'Biến vỏ ốc thành tranh', N'Những ngày giữa tháng 12, quán cà phê vắng khách là lúc anh Võ Cao Đỉnh, 39 tuổi, ở xã Tam Tiến, huyện Núi Thành dành thời gian hoàn thành bộ sưu tập vỏ sò điệp rộng gần một m2. Hơn 100 vỏ sò nhiều màu sắc được anh lắp ghép tạo thành bức tranh. "Sản phẩm này được khách đặt giá 1,6 triệu đồng, làm hai ngày mới xong",', N'bien-vo-oc-thanh-tranh', N'imagenghethuatlamoc_20243514_103539.jpg', 0, CAST(N'2024-12-14T10:35:39.7209341' AS DateTime2), 1, 4)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (16, N'test1', N'<p><strong>test header 1</strong></p>

<p><em>test nghiên 1</em></p>

<p>test body 1 test lần 2</p>

<p>&nbsp;</p>
', N'test', N'imagehoagiay_20244114_164130.jpg', 1, CAST(N'2024-12-14T11:10:45.3315275' AS DateTime2), 0, 1)
INSERT [dbo].[Posts] ([Id], [Title], [Content], [Slug], [Image], [View], [CreateAt], [State], [CategoryId]) VALUES (18, N'test1', N'<p>tst</p>
', N'test1', N'imagenghethuatlamoc_20240514_170540.jpg', 0, CAST(N'2024-12-14T17:05:40.2712780' AS DateTime2), 0, 1)
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
SET IDENTITY_INSERT [dbo].[Subscribes] ON 

INSERT [dbo].[Subscribes] ([Id], [Email]) VALUES (1, N'vanb@gmail.com')
INSERT [dbo].[Subscribes] ([Id], [Email]) VALUES (2, N'vanc@gmail.com')
INSERT [dbo].[Subscribes] ([Id], [Email]) VALUES (3, N'vana@gmail.com')
SET IDENTITY_INSERT [dbo].[Subscribes] OFF
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_CategoryTypes_CategoryTypeId] FOREIGN KEY([CategoryTypeId])
REFERENCES [dbo].[CategoryTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_CategoryTypes_CategoryTypeId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Posts_PostId] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Posts_PostId]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Categories_CategoryId]
GO
