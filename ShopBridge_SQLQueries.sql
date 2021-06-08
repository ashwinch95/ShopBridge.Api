/****** Object:  Table [Product].[ProductCategory]    Script Date: 08-06-2021 21:51:05 ******/

CREATE TABLE [Product].[ProductCategory](
	[iProductCategoryID] [int] NOT NULL,
	[vchProductCategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[iProductCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [Product].[Products]    Script Date: 08-06-2021 21:51:37 ******/

CREATE TABLE [Product].[Products](
	[iProductID] [int] IDENTITY(1,1) NOT NULL,
	[vchProductName] [varchar](50) NOT NULL,
	[vchDescription] [varchar](100) NULL,
	[dPrice] [decimal](18, 0) NOT NULL,
	[bIsAvailable] [bit] NOT NULL,
	[iProductCategoryID] [int] NOT NULL,
	[vchBrand] [varchar](20) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[iProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Product].[Products]  WITH CHECK ADD FOREIGN KEY([iProductCategoryID])
REFERENCES [Product].[ProductCategory] ([iProductCategoryID])
GO



/****** Inserting records into ProductCategory table ******/

INSERT INTO Product.ProductCategory VALUES(1,	'Electronics')
INSERT INTO Product.ProductCategory VALUES(2,	'Kitchen')
INSERT INTO Product.ProductCategory VALUES(3,	'Sports')
INSERT INTO Product.ProductCategory VALUES(4,	'Furniture')
INSERT INTO Product.ProductCategory VALUES(5,	'Games')
INSERT INTO Product.ProductCategory VALUES(6,	'Books')