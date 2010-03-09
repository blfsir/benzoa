
insert into uds_class values('�豸����','�豸����',60,371,'admin',getdate(),0)

update uds_class set classparentid=(select classid from uds_class where classname='�豸����') where classname='�豸����'

insert into uds_proc_type values(1,60)

go


create table uds_asset
(
	ID											int	identity(1,1)	not null,					--ID(����ID)
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
	IsDelete		int					null default(0),			--�Ƿ�ɾ��(0:δɾ����1����ɾ��)
	unique(ID),
	primary key (ID),					
)
go



--����ͺ�
create table AssetType
(
	ID			int	identity(1,1)	not null,				--ID(����ID)
	AssetTypeName		varchar(100)		null,					--����ͺ�
	AssetTypeRemark		varchar(500)		null,					--��ע
	unique(ID),
	primary key (ID),
)
go



--�ִ�ŵص�
create table AssetCurrentLocation
(
	ID			int	identity(1,1)	not null,				--ID(����ID)
	AssetCurrentLocationName		varchar(100)		null,					--�ִ�ŵص�
	AssetCurrentLocationRemark		varchar(500)		null,					--��ע
	unique(ID),
	primary key (ID),
)
go



--��ʹ��״��
create table AssetCurrentUseState
(
	ID			int	identity(1,1)	not null,				--ID(����ID)
	AssetCurrentUseStateName		varchar(100)		null,					--��ʹ��״��
	AssetCurrentUseStateRemark		varchar(500)		null,					--��ע
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