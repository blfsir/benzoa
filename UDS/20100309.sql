--便签表  
   
--**************--  
--存储过程  
--**************--  
--Insert   
--xy.zhao  
--2010.2.1   
  
--Update  
--xy.zhao  
--2010.2.1  
   
  
--Delete  
--xy.zhao  select * from diary
--2010.2.1  
CREATE Procedure Proc_DeleteDiary  
(  
  @exit varchar(12)  output,  --@exit 返回值  
  @ID int               
)  
AS  
begin  
 --update diary set IsDelete=1 where ID=@ID --设置删除标记 
delete diary where ID=@ID 
 if(@@error=0)  
  set  @exit=@ID  
 else   
  set  @exit='0'  
end  