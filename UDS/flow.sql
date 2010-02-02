--4.  
  alter   PROC sp_Flow_GetFlow    
 @FlowID int =0    
AS    
IF @FlowID>0    
 SELECT A.Flow_ID,A.Flow_Name,A.Flow_Class,A.flow_chat,CONVERT(VARCHAR(10),A.Build_Date,120)  Build_Date,A.Builder,A.Remark,A.Style_ID,B.Style_NAME    
  FROM uds_flow a,uds_flow_style b    
  WHERE a.style_id = b.style_id    
    AND a.flow_id = @FlowID       
ELSE    
 SELECT A.Flow_ID,A.Flow_Name,A.Flow_Class,A.flow_chat,CONVERT(VARCHAR(10),A.Build_Date,120)  Build_Date,A.Builder,A.Remark,A.Style_ID,B.Style_NAME    
  FROM uds_flow a,uds_flow_style b    
  WHERE a.style_id = b.style_id    