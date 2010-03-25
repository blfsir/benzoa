
alter table UDS_WorkAttendence_Data 
add  fingerprintOnDuty datetime, fingerprintOffDuty datetime 


CREATE proc sp_WA_RecordOnDutyDataFromAtt      
as      
begin      
 declare @id int --staff_id      
 declare @name varchar(100)--staff_name      
--  declare @ondutytime datetime      
-- set @ondutytime=''      
 Declare Cur Cursor For      
 select staff_id,staff_name from uds_staff         
 Open Cur      
 Fetch next From Cur Into @id,@name      
 While @@fetch_status=0      
 Begin       
  declare @ondutytime datetime       
  select top 1 @ondutytime=checktime from [10.10.10.120].[att].dbo.CHECKINOUT       
  where datediff(d,CHECKTIME,getdate())=0       
  and userid in       
   (      
  select a.userid      
  from  [10.10.10.120].[att].dbo.USERINFO a      
   ,uds_staff b where b.staff_name=a.[name]  and b.staff_name=@name)      
  print '@ondutytime'      
  print @ondutytime      
  if(datediff(d,@ondutytime,getdate())=0 )      
  begin      
 --清除今天已经记录的考勤数据    
 if not exists(select * from uds_workattendence_data  where datediff(d,workdate,getdate())=0   and staffid=@id)    
 begin    
  exec sp_WA_RecordOnDutyData @id,@ondutytime,0,''      
 end    
  end      
  set @ondutytime=null      
  Fetch next From Cur Into @id,@name      
 End      
 Close Cur      
 Deallocate Cur        
end      
      