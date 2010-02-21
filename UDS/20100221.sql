 alter                   PROC sp_Flow_GetMyDraft  
 @StaffName varchar(300)  
AS  
  
DECLARE @staffid int  
  
SELECT @staffid = staff_id   
 FROM uds_staff  
 WHERE staff_name = @StaffName  
   
IF @staffid>0  
  
SELECT  a.Doc_ID,  
 a.a Title,  
 b.Doc_Builder_ID,  
 CONVERT(varchar(10),Doc_Added_Date,120) AS Short_Doc_Added_Date,  
 b.Doc_Status,  
 b.Flow_ID,  
 b.Step_ID,  
 c.realname  AS DocBuilder,  
 d.flow_name  AS FlowName,  
 d.flow_chat,
 '²Ý¸å'   AS status,  
 e.step_name  AS StepName  
 
 FROM   
  uds_flow_Style_Data a,  
  uds_flow_document b,  
  uds_staff c,  
  uds_flow d,  
  uds_flow_step e  
 WHERE  a.Doc_ID   = b.Doc_ID   
  and b.flow_id   = e.flow_id  
  and b.step_id   = e.step_id  
  and b.flow_id   = d.flow_id  
  and b.doc_builder_id  = c.staff_id  
  and c.staff_id   = @staffid   
  and b.isrunning = 0  
  
 ORDER BY b.doc_added_date DESC  
  