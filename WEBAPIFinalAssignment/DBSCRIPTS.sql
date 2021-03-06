USE [hotelManagement]
GO
/****** Object:  Table [dbo].[booking]    Script Date: 13-Jan-21 7:06:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booking](
	[bookingId] [int] IDENTITY(1,1) NOT NULL,
	[Room_Id] [int] NOT NULL,
	[bookingDate] [datetime] NOT NULL,
	[statusOfBooking] [varchar](50) NOT NULL,
 CONSTRAINT [PK_booking] PRIMARY KEY CLUSTERED 
(
	[bookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hotel]    Script Date: 13-Jan-21 7:06:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hotel](
	[Hotel_Id] [int] IDENTITY(1,1) NOT NULL,
	[Hotel_name] [varchar](50) NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[pinCode] [int] NOT NULL,
	[contactNumber] [varchar](10) NULL,
	[contactPerson] [varchar](50) NULL,
	[website] [nvarchar](50) NULL,
	[faceBook] [varchar](50) NULL,
	[twitter] [varchar](50) NULL,
	[isActive] [bit] NULL,
	[createdDate] [datetime] NULL,
	[createdBy] [varchar](50) NULL,
	[updateDate] [datetime] NULL,
	[updatedBy] [varchar](50) NULL,
 CONSTRAINT [PK_hotel] PRIMARY KEY CLUSTERED 
(
	[Hotel_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 13-Jan-21 7:06:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Hotels_Id] [int] NOT NULL,
	[Room_Id] [int] IDENTITY(1,1) NOT NULL,
	[Room_Name] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
	[Price] [int] NULL,
	[isActive] [bit] NULL,
	[createdBy] [varchar](50) NULL,
	[createdDate] [datetime] NULL,
	[updatedBy] [varchar](50) NULL,
	[updatedDate] [datetime] NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Room_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[hotel] ADD  CONSTRAINT [DF_hotel_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_isActive]  DEFAULT ((1)) FOR [isActive]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Hotel] FOREIGN KEY([Hotels_Id])
REFERENCES [dbo].[hotel] ([Hotel_Id])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Hotel]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [CHK_CATEGORY] CHECK  (([CATEGORY]='large' OR [CATEGORY]='medium' OR [CATEGORY]='small'))
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [CHK_CATEGORY]
GO
/****** Object:  StoredProcedure [dbo].[ins_hotel]    Script Date: 13-Jan-21 7:06:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ins_hotel] 	
@Hotel_name varchar(50), @address varchar(max), @city varchar(50),@pinCode int,@number varchar(10),@person varchar(10),@website nvarchar(50),@fb nvarchar(50),@twitter varchar(50), @isActive bit,@createdBy varchar(50),@updatedBy varchar(50)
AS
BEGIN
SET  NOCOUNT ON;
insert into hotel(Hotel_name,Address,City,pinCode,contactNumber,contactPerson,website,faceBook,twitter,isActive,createdDate,createdBy,updateDate,updatedBy) values (@Hotel_name,@address,@city,@pinCode,@number,@person,@website,@fb,@twitter,@isActive,GETDATE(),@createdBy,GETDATE(),@updatedBy)
END

GO
/****** Object:  StoredProcedure [dbo].[ins_room]    Script Date: 13-Jan-21 7:06:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ins_room]
@hotelId int, @Roomname varchar(50), @category varchar(50),@price int, @isActive bit,@createdBy varchar(50),@updatedBy varchar(50)
AS
BEGIN
SET  NOCOUNT ON;
insert into Room(Room_Name,Hotels_Id,Category,Price,isActive,createdBy,createdDate,updatedBy,updatedDate) values (@Roomname,@hotelId,@category,@price,@isActive,@createdBy, GETDATE(),@updatedBy,GETDATE())
END

GO
/****** Object:  StoredProcedure [dbo].[selectHotel]    Script Date: 13-Jan-21 7:06:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[selectHotel]
	
AS
BEGIN
	select * from hotel ORDER BY Hotel_name ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[selectHotelwithRoom]    Script Date: 13-Jan-21 7:06:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Hetvi>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[selectHotelwithRoom]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
SELECT * from Room where Hotel_Id = @id order by Price DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[selectRoom]    Script Date: 13-Jan-21 7:06:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[selectRoom]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select * from Room ORDER BY Price ASC
END
GO
/****** Object:  StoredProcedure [dbo].[selectRoomByCity]    Script Date: 13-Jan-21 7:06:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[selectRoomByCity]
@city varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select Room.Room_Name,Room.Category,Room.Price,Room.createdBy,hotel.Hotel_name,hotel.City from Room,hotel
	where Room.Hotels_Id = hotel.Hotel_Id
	AND hotel.City = @city
   
END
GO
/****** Object:  StoredProcedure [dbo].[selectRoomByPincode]    Script Date: 13-Jan-21 7:06:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[selectRoomByPincode] 
	-- Add the parameters for the stored procedure here
	@pincode int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
select Room.Room_Name,Room.Category,Room.Price,Room.createdBy,hotel.Hotel_name,hotel.City,hotel.pinCode from Room,hotel
	where Room.Hotels_Id = hotel.Hotel_Id
	AND hotel.pinCode = @pincode
END
GO
