    
       CREATE    proc UDS_StaffSearchPlan  --UDS_StaffSearchPlan  '个人计划','周计划','t','徐宁'   
    
@PlanObjectType  varchar(200),  
@PlanPeriodType  varchar(200),   
@PlanContent  varchar(200),  
@PlanCreator   varchar(200)  
   
AS      
      
DECLARE @SQL VARCHAR(500)      
DECLARE @SQL1 VARCHAR(1500)   
DECLARE @SQL2 VARCHAR(1500)   
DECLARE @SQL3 VARCHAR(3000)  
DECLARE @HAVECONDITION BIT    
  
DECLARE @PositionID varchar(10)  
--select * from uds_position    
--select * from uds_staff_in_position  
  
select @PositionID=position_id from uds_staff a, uds_staff_in_position b where a.staff_id = b.staff_id and a.staff_name=+''+@PlanCreator+''  
       
 SET @SQL = 'select id,plancreatedate,plancreator+planyear+''年''+case planperiodtype when ''季计划'' then planperiod+''季度'' when ''月计划'' then planperiod+''月'' when ''周计划'' then planperiod+''周'' when ''年计划'' then ''度'' end +planobjecttype   as planname  from 
uds_plan where 1=1 '      
     
SET @HAVECONDITION = 0      
 IF (@PlanObjectType<>'')      
 BEGIN      
  SET @SQL = @SQL + ' and ( PlanObjectType LIKE ''%'+@PlanObjectType+'%'')'      
  SET @HAVECONDITION = 1      
 END      
     
  
 IF (@PlanPeriodType<>'')        
 BEGIN        
  IF(@HAVECONDITION=0)        
  BEGIN        
   SET @SQL = @SQL + ' and (PlanPeriodType LIKE ''%'+@PlanPeriodType+'%'')'        
   SET @HAVECONDITION = 1        
  END        
  ELSE        
   SET @SQL = @SQL + ' AND (PlanPeriodType LIKE ''%'+@PlanPeriodType+'%'')'        
 END        
  
  
 IF (@PlanContent<>'')        
 BEGIN        
  IF(@HAVECONDITION=0)        
  BEGIN        
   SET @SQL = @SQL + ' and (PlanContent LIKE ''%'+@PlanContent+'%'')'        
   SET @HAVECONDITION = 1        
  END        
  ELSE        
   SET @SQL = @SQL + ' AND (PlanContent LIKE ''%'+@PlanContent+'%'')'        
 END     
  
     
 SET @SQL1 = @SQL + ' AND (plancreator = '''+@PlanCreator+''') '    
  
SET @SQL2 = @SQL + ' AND ( plancreator in (   
select staff_name from   
 (select p.position_id,s.*  
FROM UDS_STAFF s   
,UDS_Staff_In_Position  p where s.STAFF_ID=p.Staff_ID) a  
 where a.position_id in (select position_id from uds_position where super_position_id= '''+@PositionID+'''))) order by plancreatedate desc  '    
       
set @SQL3 = @SQL1 +' union all '+@SQL2  
 PRINT @SQL3      
  EXECUTE  (@SQL3)  --UDS_StaffSearchPlan  '个人计划','年计划','','徐宁' 