--便签表
create table Diary
(
	ID				int	identity(1,1)	not null,					--ID(自增ID)
	Contents		text		not	null,					--内容
	UserID			int					not null,					--提交人ID
	UserName		varchar(100)					not null,					--提交人ID
	SubmitDate		datetime			null default getdate() 		--提交日期
	 
	unique(ID),
	primary key (ID),
)
go

/*  
CREATE Procedure Proc_GetNoteListByUserID  
(  
  @UserID int,  
  @IsCollect int  
)  
AS  
begin  
 select * from Note where userid=@UserID and IsCollect=@IsCollect and IsDelete=0  
 order by SubmitDate desc  
end  
go


*/

create proc Proc_SearchSubStaff
@userid int 
as
begin  
 
DECLARE @SQL VARCHAR(500)    
DECLARE @PositionID varchar(10)  
select @PositionID=position_id from uds_staff a, uds_staff_in_position b where a.staff_id = b.staff_id and a.staff_id=@userid   
SET @SQL = '     
select staff_id,staff_name from   
 (select p.position_id,s.*  
FROM UDS_STAFF s   
,UDS_Staff_In_Position  p where s.STAFF_ID=p.Staff_ID) a  
 where a.position_id in (select position_id from uds_position where super_position_id= '''+@PositionID+''') order by a.position_id '    
       
print @SQL
exec(@SQL)
end

--Proc_SearchSubStaff 13
--select * from uds_staff

go



alter Procedure Proc_SearchDiary  --'162,163,164,165,166,167,168',null,null,null  
(    
  @UserID varchar(200),    
  @BeginDate varchar(20),    
  @EndDate varchar(20),    
  @Contents varchar(1000)    
)    
AS    
begin    
    
declare @SQL varchar(1000)
set @SQL='select * from Diary where submitdate between '''+@BeginDate+''' and '''+@EndDate+''''
	set @SQL= @SQL+' and userid in (' +@UserID +' )'
if(@Contents <>'')
begin
	set @SQL= @SQL+' and contents like ''%'+@Contents+'%'''
end
   print @SQL 
  exec(@SQL)  
end 
