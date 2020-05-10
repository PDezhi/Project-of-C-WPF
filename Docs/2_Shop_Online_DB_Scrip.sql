/* Create Shop_OnLine database
	Script Date: May 08, 2020
	Developed by Dezhi
*/

-- switch to master database
use master
;
go

drop database Shop_OnLine
;
go


-- Create Shop_OnLine database
create database Shop_OnLine
on primary
(
	-- logical rows data file name
	name = 'Shop_OnLine',
	-- rows data path and filename
	filename = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Shop_OnLine.mdf',
	-- rows data file size
	size = 12MB,
	-- rows data file growth
	filegrowth = 2MB,
	-- rows data maximun size
	--maxsize = inlimited
	maxsize = 100MB
)
log on
(
	-- logical log file name
	name = 'Shop_OnLine_log',
	-- log data path and filename
	filename = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Shop_OnLine_log.mdf',
	-- log file size
	size = 3MB,
	-- log file growth
	filegrowth = 10%,
	-- log file maximun size
	--maxsize = inlimited
	maxsize = 25MB
)
;
go

/* Create Shop_OnLine Schemas */
-- switch to Shop_OnLine
use Shop_OnLine
;
go



create schema Members authorization dbo
;
go

create schema Products authorization dbo
;
go




/* Create Shop_OnLine tables */
/***** Create table: Products.Products *****/
if object_ID('Products.Products', 'U') is not null
	drop table Products.Products
;
go

create table Products.Products
(
  id int identity(1, 1) not null,
  title varchar(50) NOT NULL,
  category varchar(40) NOT NULL,
  price decimal(10,0) NOT NULL,
  description nvarchar(100)  NULL,
	constraint pk_ProductsProducts primary key clustered (id asc)
)
;
go


/***** Create table: Members.Customers *****/
if object_ID('Members.Customers', 'U') is not null
	drop table Members.Customers
;
go

create table Members.Customers
(
  id int IDENTITY(1,1) not null,
  name varchar(50) NOT NULL,
  address varchar(50) NOT NULL,
  email varchar(50) NOT NULL,
  zip varchar(10) NOT NULL,
  phone varchar(15) NOT NULL,

	constraint pk_MembersCustomers primary key clustered (id asc)
)
go


/***** Create table: Members.Users *****/
if object_ID('Members.Users', 'U') is not null
	drop table Members.Users
;
go
CREATE TABLE Members.Users (
  id int IDENTITY(1,1) not null,
  userName varchar(10) NOT NULL,
  password varchar(100) NOT NULL,
  customerId int NOT NULL,
  CONSTRAINT pk_Members_Users PRIMARY KEY CLUSTERED (id ASC)
);

/***** Create table: Members.Carts*****/
if object_ID('Members.Carts', 'U') is not null
	drop table Members.Carts
;
go
CREATE TABLE Members.Carts (

  id int IDENTITY(1,1) not null,
  userId int NOT NULL,
  productId int NOT NULL,
  CONSTRAINT pk_Members_Carts PRIMARY KEY CLUSTERED (id ASC)
);


/* Apply data integrity */

/***** Table pk_MembersUsers_Customers *****/
-- Foreign key constraints
/* 1) Between pk_Members.Users and pk_Members.Customers */
alter table Members.Users
	add constraint fk_MembersUsers_Customers foreign key (customerId) references Members.Customers (id)
;
go

/***** Table Members.Carts  *****/
-- Foreign key constraints
alter table Members.Carts
	add constraint fk_MemberCarts_Users foreign key (userId) references Members.Users (id),
	 constraint fk_MemberCarts_Products foreign key (productId) references Products.Products (id)
;
go

