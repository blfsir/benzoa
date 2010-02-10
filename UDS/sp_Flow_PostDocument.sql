       alter                            PROC sp_Flow_PostDocument          
 @StaffName varchar(300),          
 @DocID int,           
 @ProjectID int =0           
AS          
          
SET NOCOUNT ON          
DECLARE @FlowRule int          
DECLARE @Position_ID int          
DECLARE @Super_Position_ID int          
          
DECLARE @Project_ID INT          
DECLARE @Parent_Project_ID int          
DECLARE @PassNum int          
DECLARE @StaffID int          
          
DECLARE @Flow_ID int      
DECLARE @Flow_Name varchar(300)        
DECLARE @Step_ID int          
          
DECLARE @Local_Alert int          
DECLARE @msgid int          
          
DECLARE @SQL  VARCHAR(3000)          
          
SET @Project_ID  = @ProjectID          
SET @PassNum   = 0          
SET @Local_Alert = 0          
SET @SQL   = ''          
SET @Flow_Name=''    
          
          
          
--=======================================================================          
--ID          
SELECT  @Position_ID = Position_id,          
 @StaffID = Staff_id          
 FROM            
  v_UDS_Staff_In_Position          
 WHERE            
  staff_name  = @StaffName           
          
          
--ID          
SELECT  @Super_Position_ID  = Super_Position_ID          
 FROM           
  uds_Position          
 WHERE Position_id  = @Position_ID          
          
--ID          
SELECT  @Parent_Project_ID  = ClassParentID           
 FROM           
  uds_class          
 WHERE  classid  = @Project_ID           
  and classid<>classparentid          
          
--IDID          
SELECT  @Flow_ID  = Flow_ID,          
 @Step_ID = Step_ID          
 FROM           
  uds_flow_document          
 WHERE  Doc_ID = @DocID       
    
--FLOW_NAME    
select @Flow_Name =Flow_Name    
from uds_flow uf    
where  uf.Flow_ID=@Flow_ID    
          
          
--=======================================================================          
          
          
--          
IF EXISTS(SELECT 1 FROM uds_flow_step WHERE flow_id = @flow_id and step_id = @step_id)          
BEGIN          
 --          
 SELECT  @FlowRule = Flow_Rule,          
  @PassNum = PassNum,           
  @Local_Alert = LocalAlert          
  FROM           
   uds_flow_step          
  WHERE  flow_id  = @flow_id           
   and step_id  = @step_id          
   --  print '@FlowRule = Flow_Rule'   
  --print @FlowRule  
  --print 'flowid'  
  --print @flow_id  
  --print 'step_id'  
  --print @step_id  
 --          
 IF @PassNum <0          
 BEGIN          
  --          
  DELETE FROM UDS_SMS_MobileMsgSendBuffer            
   WHERE  msgid in (          
      SELECT  msgid           
       FROM           
        uds_flow_message          
       WHERE  doc_id   = @docid          
        and flow_id  = @flow_id          
        and step_id  = @step_id             
        and staff_id  = @staffid            
       )          
          
  --          
  DELETE FROM uds_flow_message          
   WHERE  doc_id   = @docid          
    and flow_id  = @flow_id          
    and step_id  = @step_id          
    and staff_id  = @staffid          
            
  --0          
  IF(SELECT COUNT(*) FROM uds_flow_status where doc_id =@docid )<>(SELECT COUNT(*) FROM uds_flow_postil WHERE doc_id =@docid and postil_type =1)          
   RETURN -4            
          
 END          
 ELSE          
 BEGIN          
  --          
  IF @PassNum >0          
  BEGIN          
   --          
   DELETE FROM UDS_SMS_MobileMsgSendBuffer            
    WHERE  msgid in (          
       SELECT  msgid           
        FROM           
         uds_flow_message          
        WHERE  doc_id   = @docid          
         and flow_id  = @flow_id          
         and step_id  = @step_id             
         and staff_id  = @staffid            
        )          
          
   --          
   DELETE FROM uds_flow_message          
    WHERE  doc_id   = @docid          
     and flow_id  = @flow_id          
     and step_id  = @step_id          
     and staff_id = @staffid          
          
   UPDATE uds_flow_status           
  SET  status   = 2           
    WHERE  staff_id  = @staffid           
     and doc_id  = @docid          
   --          
   IF (SELECT COUNT(*) FROM uds_flow_postil WHERE doc_id =@docid and postil_type =1 and step_id = @step_id)<@PassNum          
    RETURN -5          
  END          
  --0          
 END          
          
 --          
 DELETE FROM           
   uds_flow_status           
  WHERE  doc_id   = @DocID          
 --          
 UPDATE uds_flow_document          
  SET  doc_status  = 0,          
   isrunning = 1          
  WHERE  doc_id   = @DocID          
            
 --ID           
 DECLARE @FieldName   varchar(10)          
 DECLARE @Compare   varchar(10)          
 DECLARE @Compare_ValueStr varchar(300)          
 DECLARE @Compare_Value   INT          
 DECLARE @To_Step_id   INT          
          
 DECLARE @Result_Step_ID  INT          
           
 SET @To_Step_id  = -1            
 SET @Result_Step_ID  = -1          
          
 DECLARE @CommandAnd bit          
 DECLARE @Successful bit          
 DECLARE @JumpFlowRule int          
          
 SET @CommandAnd = 0          
 SET @Successful = 0          
 SET @JumpFlowRule = -1          
           
 CREATE TABLE #D (doc_id int)          
          
 --          
 PRINT ''          
 DECLARE cur_Jump Cursor FOR          
  SELECT  FieldName,compare,comparevalue,to_step_id,flow_rule          
   FROM           
    uds_flow_jump          
   WHERE  flow_id  = @flow_id          
    and step_id = @step_id          
   ORDER BY priority          
 OPEN cur_jump          
 --================================================          
 FETCH NEXT FROM cur_jump INTO @FieldName,@Compare,@Compare_Value,@To_Step_id,@JumpFlowRule          
          
 IF @@FETCH_STATUS<>0           
  PRINT ''          
 WHILE @@FETCH_STATUS = 0          
 BEGIN          
  --          
  IF @To_Step_id = @Step_id AND @CommandAnd = 0          
  BEGIN          
   SET @CommandAnd  = 1          
   SET @Successful  = 1           
  END          
          
  --          
  IF @CommandAnd = 1          
  BEGIN          
   --          
   IF @To_Step_id <> @Step_id           
   BEGIN          
    --          
    SET @CommandAnd  = 0          
   END          
          
   IF @FieldName =  'caste'          
   BEGIN          
    SET @SQL = 'INSERT INTO #d SELECT 1 FROM uds_staff           
      WHERE staff_id = ' + CONVERT(VARCHAR(100),@StaffID)          
      + ' AND  CONVERT(numeric(18,2),' + @FieldName + ')' + @Compare + CONVERT(VARCHAR(100),@Compare_Value)           
   END          
   ELSE             
    --          
    SET @SQL = 'Insert INTO #d           
      SELECT doc_id           
       FROM           
        uds_flow_style_data           
       WHERE doc_id = ' + CONVERT(VARCHAR(100),@DocID)          
       + ' AND  CONVERT(numeric(18,2),' + @FieldName + ')' + @Compare + CONVERT(VARCHAR(100),@Compare_Value)           
           
   --PRINT @SQL          
   EXEC (@SQL)           
            
   IF NOT EXISTS(SELECT 1 FROM #D)          
   BEGIN          
    SET @Successful = 0              
   END           
          
   --          
   DELETE FROM #d           
             
   --          
   IF @CommandAnd = 0          
   BEGIN          
    --          
    IF @Successful = 1          
    BEGIN          
     SET @Result_Step_ID = @To_Step_id          
     BREAK          
    END          
   END           
  END          
  --          
  ELSE          
  BEGIN          
   IF @FieldName =  'caste'          
   BEGIN          
    SET @SQL = 'INSERT INTO #d SELECT 1 FROM uds_staff           
      WHERE staff_id = ' + CONVERT(VARCHAR(100),@StaffID)          
      + ' AND  CONVERT(numeric(18,2),' + @FieldName + ')' + @Compare + CONVERT(VARCHAR(100),@Compare_Value)           
   END          
   ELSE          
    --          
    SET @SQL = 'Insert INTO #d           
      SELECT doc_id           
       FROM           
        uds_flow_style_data           
       WHERE doc_id = ' + CONVERT(VARCHAR(100),@DocID)          
       + ' AND  CONVERT(numeric(18,2),' + @FieldName + ')' + @Compare + CONVERT(VARCHAR(100),@Compare_Value)           
           
   --PRINT @SQL          
   --          
   EXEC (@SQL)           
             
   --          
   IF EXISTS(SELECT 1 FROM #D)          
   BEGIN          
    SET @Result_Step_ID = @To_Step_id          
    BREAK          
   END          
  END          
            
  --          
  FETCH NEXT FROM cur_jump INTO @FieldName,@Compare,@Compare_Value,@To_Step_id,@JumpFlowRule          
 END          
             
 --================================================          
 CLOSE cur_jump          
 DEALLOCATE cur_jump          
          
 DROP TABLE #D          
           
 --          
 --print '@result_step_id'  
 --print @Result_Step_ID  
 IF @Result_Step_ID <0     
 BEGIN          
  IF EXISTS(SELECT 1           
     FROM           
      uds_flow_step           
     WHERE  flow_id  = @flow_id          
      and step_id = @step_id+1          
     )          
  BEGIN          
   SET @Result_Step_ID = @step_id + 1          
   PRINT '' + CONVERT(VARCHAR(300),@Result_Step_ID)          
  END          
 END          
 ELSE          
 BEGIN          
   --@Result_Step_ID = 0       
   PRINT '@FlowRule = @JumpFlowRule'  
   PRINT '' + CONVERT(VARCHAR(300),@Result_Step_ID)          
   SET @FlowRule = @JumpFlowRule          
 END          
           
 --          
---------------=======================      
--print 'IF @Result_Step_ID>0 '      
--print @Result_Step_ID      
--print @FlowRule  
--print '---===================='      
 IF @Result_Step_ID>0          
 BEGIN          
  CREATE TABLE #staff (id int)          
            
  --,          
  IF @FlowRule = 0          
  BEGIN          
   INSERT INTO #staff           
    SELECT staff_id           
     FROM  v_uds_flow_staff_in_step          
     WHERE  flow_id  = @flow_id          
      and step_id  = @Result_Step_ID          
          
   PRINT ''          
  END          
  --          
  IF @FlowRule = 1          
  BEGIN          
   --          
------------------------      
--print 'IF @FlowRule = 1        '      
  
--print '-========================'      
   WHILE NOT EXISTS(SELECT 1 FROM #staff)          
   BEGIN          
  --  print 'PRINT @Result_Step_ID        '  
    --PRINT @Result_Step_ID          
    --print 'PRINT @Super_Position_ID        '  
    --PRINT @Super_Position_ID          
    --          
    INSERT INTO #staff          
     SELECT  a.staff_id           
      FROM           
       uds_staff_in_position a,          
       v_uds_flow_staff_in_step b          
      WHERE  a.staff_id   = b.staff_id           
         and a.Position_id  = @Super_Position_ID          
        and b.flow_id   = @Flow_ID             
       and b.step_id  = @Result_Step_ID          
          
      
              
    IF @Position_ID<>@Super_Position_ID          
    BEGIN          
     SET @Position_ID   = @Super_Position_ID          
     SELECT  @Super_Position_ID  = Super_Position_ID           
      FROM           
       uds_Position          
      WHERE  Position_id  = @Position_ID              
    END           
    ELSE          
    BEGIN           
     PRINT ''          
     BREAK          
    END          
               
   END           
   PRINT ':' + convert(varchar(100),@Super_Position_ID)          
  END          
  --          
  IF @FlowRule = 2          
  BEGIN          
   --          
   IF EXISTS(SELECT 1 FROM uds_staff_in_team WHERE team_id = @Project_ID AND staff_id = @staffid and member_type = 2)          
   BEGIN          
    SET @Project_ID = @Parent_Project_ID          
   END          
          
   --          
   WHILE NOT EXISTS(SELECT 1 FROM #staff)          
   BEGIN             
    --              
          
    INSERT INTO #staff          
     SELECT  a.staff_id          
      FROM           
       uds_staff_in_team a,          
       v_uds_flow_staff_in_step b          
      WHERE  a.staff_id  = b.staff_id           
         and a.team_id  = @Project_ID          
         and b.flow_id  = @flow_id          
       and b.step_id  = @Result_Step_ID          
       and a.member_type = 2          
           
    --PRINT @Parent_Project_ID          
              
    IF @Project_ID<>@Parent_Project_ID          
    BEGIN          
     SET  @Project_ID   = @Parent_Project_ID          
     SELECT  @Parent_Project_ID  = ClassParentID           
      FROM           
       uds_class          
      WHERE  classid  = @Project_ID              
    END           
    ELSE          
    BEGIN           
     PRINT ''          
     BREAK          
    END          
               
   END           
   PRINT ''          
  END          
           
            
----------------------------      
--print 'IF EXISTS(SELECT 1 FROM #staff)  '      
      
--print '---============================'      
  --          
  IF EXISTS(SELECT 1 FROM #staff)          
  BEGIN          
   --  
  -- print '@local_alert'  
   --print    @Local_Alert       
   IF @Local_Alert=1          
   BEGIN          
          
    INSERT INTO uds_sms_msg          
     (sender,content,sendtime,type)          
     VALUES(@staffname,@Flow_Name,getdate(),1)          
    SET @msgid = IDENT_CURRENT('uds_sms_msg')          
    INSERT INTO uds_sms_receiver          
     (msgid,receiver,mobileno,type,isread)          
     SELECT  @msgid,          
      b.staff_name,          
      b.mobile,          
      1,0                
      FROM           
       #staff a,          
       uds_staff b          
      WHERE           
       a.id = b.staff_id          
          
   END          
          
   --          
   DELETE FROM UDS_SMS_MobileMsgSendBuffer            
    WHERE  msgid in (          
       SELECT  msgid           
        FROM           
         uds_flow_message          
        WHERE  doc_id   = @docid          
        )          
          
   --          
   DELETE FROM uds_flow_message          
    WHERE doc_id = @docid          
          
   --          
   DECLARE @StendTime DATETIME          
   DECLARE @RepeatTimes int          
   DECLARE @RepeatPeriod int          
             
   SELECT  @StendTime = DATEADD(ss,basehour,getdate()),          
           @RepeatTimes = Cyctimes -1 ,          
    @RepeatPeriod = Period          
    FROM           
     uds_flow_step          
    WHERE           
     flow_id  = @flow_id          
     and step_id  = @step_id          
   IF @RepeatTimes>=0          
   BEGIN          
    DECLARE @staffids VARCHAR(3000)          
    SET  @staffids = ''          
    SELECT  @staffids = @staffids + ',' + CONVERT(varchar(30),id)          
     FROM #staff          
          
    --          
    EXEC sp_Flow_SMS_Send @docid,@flow_id,@Result_Step_ID,@staffids,'',@StendTime,@RepeatTimes,@RepeatPeriod          
   END          
          
   --          
   INSERT INTO uds_flow_status          
    SELECT  @DocID,ID,0          
     FROM           
      #staff          
   --          
   INSERT INTO uds_flow_path (doc_id,flow_id,step_id,staff_id,order_id)          
    SELECT  @DocID,@flow_id,@Result_Step_ID,id,(SELECT COALESCE(MAX(order_id),0)+1 FROM uds_flow_path WHERE doc_id= @docid) AS order_id          
     FROM           
      #staff          
   --          
   UPDATE uds_flow_document           
    SET step_id  = @Result_Step_ID,          
        obj_id = @projectId,          
        obj_type  = @FlowRule          
    WHERE doc_id  = @docid          
   PRINT ''            
   RETURN 0          
  END          
  ELSE          
  BEGIN  
 --print 'select 1 from staff is null'            
   IF @FlowRule = 0          
   BEGIN          
    PRINT ''            
    RETURN -7          
   END          
   IF @FlowRule = 1           
   BEGIN          
   -- PRINT 'here is -2 what is the matter?'            
    RETURN -2          
   END          
   IF @FlowRule = 2           
   BEGIN          
    PRINT ''            
    RETURN -3          
   END          
             
  END          
          
 END          
 ELSE          
 BEGIN          
          
  --          
  DELETE FROM UDS_SMS_MobileMsgSendBuffer          
   WHERE msgid in (           
     SELECT msgid           
       FROM           
        uds_flow_message          
       WHERE  doc_id = @docid          
     )          
          
  --          
  DELETE FROM uds_flow_message          
   WHERE doc_id = @docid          
          
  --          
  INSERT INTO uds_sms_msg          
   (sender,content,sendtime,type)          
   SELECT @StaffName,@Flow_Name,getdate(),1          
    FROM           
     uds_flow_document a,          
     uds_staff b               
    WHERE            
     b.staff_id = a.doc_builder_id          
     and a.doc_id = @docid          
          
  SET @msgid = IDENT_CURRENT('uds_sms_msg')          
  INSERT INTO uds_sms_receiver          
   (msgid,receiver,mobileno,type,isread)          
   SELECT  @msgid,          
    b.staff_name,          
    b.mobile,          
    1,0                
    FROM           
     uds_flow_document a,          
     uds_staff b               
    WHERE            
     b.staff_id = a.doc_builder_id          
     and a.doc_id = @docid          
          
  --          
  Delete FROM uds_flow_status          
   WHERE doc_id  = @DocID           
  --          
  UPDATE uds_flow_document          
   SET doc_status  = 3          
   WHERE doc_id  = @DocID          
  PRINT ''          
  RETURN -1          
 END          
            
END           
          
SET NOCOUNT OFF          
          
          