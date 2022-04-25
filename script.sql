CREATE TABLE Users(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL UNIQUE,
	[Password] [varchar](255) NULL,
	[Role] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

create table Transactions(
	Id int identity(1,1) not null,
	UserId int Foreign key references Users(Id) not null,
	FromCurrency varchar(3) not null,
	FromValue decimal not null,
	ToCurrency varchar(3) not null,
	ConversionRate decimal not null,
	UTCTransactionDateTime datetime not null
)
