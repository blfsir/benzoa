--公文流转，第一步就提示‘没有上级职位’错误，此为SP中用到了View v_UDS_staff_in_position,更新此视图即可。
--2010-02-05 at BMC



SELECT  Position_id,        --@Position_ID = 
 Staff_id        --@StaffID = 
 FROM          
  v_UDS_Staff_In_Position        
 WHERE          
  staff_name  = '万利功'         


USE [UDS]
GO
/****** 对象:  View [dbo].[v_UDS_Staff_In_Position]    脚本日期: 02/05/2010 13:33:25 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[v_UDS_Staff_In_Position]'))
DROP VIEW [dbo].[v_UDS_Staff_In_Position]
go

USE [UDS]
GO
/****** 对象:  View [dbo].[v_UDS_Staff_In_Position]    脚本日期: 02/05/2010 13:33:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE  VIEW [dbo].[v_UDS_Staff_In_Position]
AS
SELECT 	A.*,
	B.position_id
	FROM 
		uds_staff A,
		uds_staff_in_position B
	WHERE 	a.staff_id = b.staff_id
	
	
	
	
	
	
	
	
	
	----------------
	
	 
alter          PROC sp_Flow_GetMyFlow    
 @StaffName VARCHAR(300)    
    
AS    
    
DECLARE @staffid int    
    
--ID    
SELECT @staffid = staff_id     
 FROM uds_staff    
 WHERE staff_name = @StaffName    
    
CREATE TABLE #tmpStep (Flow_ID int,Step_ID int)    
    
    
--    
INSERT INTO #tmpStep    
 SELECT flow_id,Step_id    
  FROM     
   UDS_Flow_Step    
  WHERE   step_id = 1    
    
    
SELECT  A.Flow_ID,    
 A.Flow_Name,    
 A.Flow_Class,  
 CONVERT(VARCHAR(10),A.Build_Date,120)  Build_Date,    
 A.Builder,    
 A.Remark,    
 A.Style_ID,    
 B.Style_NAME,    
 a.flow_chat,
 m.Step_id,    

 (SELECT Step_Name FROM uds_flow_Step WHERE Flow_id = m.flow_id and step_id = m.step_id) AS StepName,    
 CONVERT(VARCHAR(10),(SELECT TOP 1 Doc_Added_Date FROM uds_flow_document k WHERE Doc_Builder_ID = @staffid AND flow_id = a.flow_id ORDER BY Doc_Added_Date DESC),120) AS LastUseDate, --    
 (SELECT COUNT(*) FROM uds_flow_document k WHERE Doc_Builder_ID = @staffid AND flow_id = a.flow_id ) AS UsedTimes         --    
 FROM     
  uds_flow a,    
  uds_flow_style b,    
  #tmpStep m,    
  v_UDS_Flow_Staff_In_Step n    
 WHERE  a.style_id = b.style_id    
    and a.flow_id = m.flow_id    
    and m.flow_id = n.flow_id    
  and m.step_id = n.step_id    
  and n.staff_id = @staffid    
    
    
DROP TABLE #tmpStep    
    















-------------------------------

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER      VIEW [dbo].[v_UDS_Flow_Staff_In_Step]
AS
SELECT 	o.staff_id,
		a.flow_id,a.step_id
		FROM 
			uds_flow_member_bind a,
			uds_staff_in_role o,
			uds_staff p
		WHERE 	a.obj_id 	= o.role_id
		  	and a.obj_type 	= 3
		  	and o.staff_id 	= p.staff_id
	          	and p.dimission = 0
	UNION
	SELECT 	o.staff_id,
		a.flow_id,a.step_id 
		FROM 	uds_flow_member_bind a,
			uds_staff_in_position o,
			uds_staff p
		WHERE 	a.obj_id 	= o.position_id
		  	and a.obj_type 	= 1
		  	and o.staff_id 	= p.staff_id
	          	and p.dimission = 0
	UNION
	SELECT 	o.staff_id,
		a.flow_id,a.step_id
		FROM 	uds_flow_member_bind a,
			uds_staff_in_team o,
			uds_staff p
		WHERE 	a.obj_id 	= o.team_id
		  	and a.obj_type 	= 2
		  	and o.staff_id 	= p.staff_id
	          	and p.dimission = 0
			and o.member_type = 1
	UNION
	SELECT 	o.staff_id,
		a.flow_id,a.step_id
		FROM 	uds_flow_member_bind a,
			uds_staff_in_team o,
			uds_staff p
		WHERE 	a.obj_id 	= o.team_id
		  	and a.obj_type 	= 5
		  	and o.staff_id 	= p.staff_id
	          	and p.dimission = 0
			and o.member_type = 2
	UNION
	SELECT 	o.staff_id,
		a.flow_id,a.step_id 
		FROM 	uds_flow_member_bind a,
			uds_staff o
		WHERE 	a.obj_id 	= o.staff_id
		  	and a.obj_type 	= 4
		  	and o.dimission = 0
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO





---------------

update uds_flow set flow_chat='noimg.jpg'  where flow_chat is null
alter table uds_flow add constraint df_flow_chat default 'noimg.jpg' for flow_chat

ALTER TABLE uds_flow ALTER COLUMN flow_chat nvarchar(300) not null