--��ǩ��  
   
--**************--  
--�洢����  
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
  @exit varchar(12)  output,  --@exit ����ֵ  
  @ID int               
)  
AS  
begin  
 --update diary set IsDelete=1 where ID=@ID --����ɾ����� 
delete diary where ID=@ID 
 if(@@error=0)  
  set  @exit=@ID  
 else   
  set  @exit='0'  
end  