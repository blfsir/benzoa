

 alter              PROC sp_Flow_GetDefineQueryDocument  
 @SelectColumns as varchar(3000),  
 @Conditions as varchar(3000),  
 @FlowID int   
AS  
  
DECLARE @SQL NVARCHAR(4000)  
  
SET @SQL =   
'SELECT ' +  
 @SelectColumns + '  
 FROM (SELECT  a.*,Doc_Builder_ID,Doc_Added_date,Doc_Status,step_id,isrunning,obj_id,obj_type,c.[Staff_ID]       
,c.[Staff_Name]    
,c.[Password]      
,c.[RealName]      
,c.[Sex]           
,c.[Email]         
,c.[Status]        
,c.[RegistedDate]  
,c.[Dimission]     
,c.[Phone]         
,c.[Mobile]        
,c.[Birthday]    ,d.*  
  FROM   
   uds_flow_Style_Data a,  
   uds_flow_document b,  
   uds_staff c,  
   uds_flow d  
  WHERE  a.Doc_ID   = b.Doc_ID   
   and b.flow_id   = d.flow_id  
   and b.doc_builder_id  = c.staff_id  
   and b.isrunning = 1    
    and b.flow_id= ' + cast(@FlowID as varchar) + ') T WHERE ' + @Conditions  
print @sql  
EXEC (@SQL)  

go

create table UDS_QuickFlow(
	 	
	StaffName varchar(100)  primary key  ,
	FlowIDs varchar(500) 
)
go

  alter  PROC sp_Desktop_GetQuickFlow        
 @flowids varchar(300)       
AS   
Declare @sql varchar(500)
set @sql =    'select * from uds_flow where flow_id in ( '+@flowids+' )'
print @sql 
exec(@sql)
go