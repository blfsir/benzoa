
insert into uds_class values('设备管理','设备管理',60,371,'admin',getdate(),0)

update uds_class set classparentid=(select classid from uds_class where classname='设备管理') where classname='设备管理'

insert into uds_proc_type values(1,60)

go


create table uds_asset
(
	ID											int	identity(1,1)	not null,					--ID(自增ID)
	AssetCode						varchar(50) not null,
	AssetName       				varchar(300) not null,
	AssetTypeID     				int not null,
	AssetNumber     				int null default(1),
	AssetPreviousUserID 		int null,
	AssetPreviousUserDept 	int null,
	AssetCurrentUserID 			int null,
	AssetCurrentUserDept  	int null,
	AssetCurrentLocation  	int null,
	AssetCurrentUseState 	int null,
	AssetBuyUserID 					int null,
	AssetBuyDate 						Datetime null,
	AssetMoveDate 					Datetime null,
	AssetWarrantyPeriod   	varchar(50) null,
	AssetAttachFile 				varchar(100) null,
	AssetRemark 						varchar(200) null,
	AssetCreateDate				datetime not null,
	AssetCreateUserID			int not null,
	IsDelete		int					null default(0),			--是否删除(0:未删除；1：已删除)
	unique(ID),
	primary key (ID),					
)
go



--规格及型号
create table AssetType
(
	ID			int	identity(1,1)	not null,				--ID(自增ID)
	AssetTypeName		varchar(100)		null,					--规格及型号
	AssetTypeRemark		varchar(500)		null,					--备注
	unique(ID),
	primary key (ID),
)
go



--现存放地点
create table AssetCurrentLocation
(
	ID			int	identity(1,1)	not null,				--ID(自增ID)
	AssetCurrentLocationName		varchar(100)		null,					--现存放地点
	AssetCurrentLocationRemark		varchar(500)		null,					--备注
	unique(ID),
	primary key (ID),
)
go



--现使用状况
create table AssetCurrentUseState
(
	ID			int	identity(1,1)	not null,				--ID(自增ID)
	AssetCurrentUseStateName		varchar(100)		null,					--现使用状况
	AssetCurrentUseStateRemark		varchar(500)		null,					--备注
	unique(ID),
	primary key (ID),
)
go

create table AssetHistory
(
	ID int identity(1,1) not null,
	AssetID int not null,
	AssetName varchar(300) not null,
	UserID int not null,
	UserName varchar(300) not null,
	CreateDate datetime default(getdate()),
	AssetHistoryRemark varchar(300),
)
go