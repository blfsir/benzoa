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
 '�ݸ�'   AS status,  
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
  
  
       CREATE    proc UDS_StaffSearchByName  
@Name varchar(200)  
/*--------------------------------------  
���ܣ���ѯ��Ա  
������  
 @Name ��Ա����  
---------------------------------------*/  
AS  
  
DECLARE @SQL VARCHAR(500)  
DECLARE @HAVECONDITION BIT  
   
 SET @SQL = 'SELECT UDS_Position.Position_Name,uds_staff.*,Case Sex When 1 Then ''��'' Else ''Ů'' End AS SexName FROM UDS_STAFF Left OUTER JOIN UDS_Staff_In_Position ON UDS_STAFF.STAFF_ID=UDS_Staff_In_Position.Staff_ID INNER JOIN UDS_Position ON UDS_Staff_In_Position.Position_ID=UDS_Position.Position_ID'  
 
SET @HAVECONDITION = 0  
 IF (@Name<>'')  
 BEGIN  
  SET @SQL = @SQL + ' WHERE ( RealName LIKE ''%'+@Name+'%'')'  
  SET @HAVECONDITION = 1  
 END  
 
     
  IF(@HAVECONDITION=0)  
  BEGIN  
   SET @SQL = @SQL + ' WHERE (UDS_Staff.Dimission=0)'  
   SET @HAVECONDITION = 1  
  END  
  ELSE  
   SET @SQL = @SQL + ' AND (UDS_Staff.Dimission=0)'  
   
   
 PRINT @SQL  
 EXECUTE  (@SQL)  
 
 
       alter    proc UDS_StaffSearchByName  
@Name varchar(200)  
/*--------------------------------------  
���ܣ���ѯ��Ա  
������  
 @Name ��Ա����  
---------------------------------------*/  
AS  
  
DECLARE @SQL VARCHAR(500)  
DECLARE @HAVECONDITION BIT  
   
 SET @SQL = 'SELECT UDS_Position.Position_Name,uds_staff.*,Case Sex When 1 Then ''��'' Else ''Ů'' End AS SexName FROM UDS_STAFF Left OUTER JOIN UDS_Staff_In_Position ON UDS_STAFF.STAFF_ID=UDS_Staff_In_Position.Staff_ID INNER JOIN UDS_Position ON UDS_Staff_In_Position.Position_ID=UDS_Position.Position_ID'  
 
SET @HAVECONDITION = 0  
 IF (@Name<>'')  
 BEGIN  
  SET @SQL = @SQL + ' WHERE ( RealName LIKE ''%'+@Name+'%'')'  
  SET @HAVECONDITION = 1  
 END  
 
     
  IF(@HAVECONDITION=0)  
  BEGIN  
   SET @SQL = @SQL + ' WHERE (UDS_Staff.Dimission=0)'  
   SET @HAVECONDITION = 1  
  END  
  ELSE  
   SET @SQL = @SQL + ' AND (UDS_Staff.Dimission=0)'  
   

SET @SQL = @SQL + ' ORDER BY RealName '
   
 PRINT @SQL  
 EXECUTE  (@SQL)  
  
  
  
  
  
      alter           PROC sp_GetMemberInClass   
 @ClassID int  
/*  
  
============================================================  
����: �õ����Ա  
����:  
 @ClassID int  : ��(��)ID  
============================================================  
  
*/  
  
AS  
--�õ�������г�Ա  
SET NOCOUNT ON  
--��@ClassID<=0ʱΪ���еĳ�Ա  
IF @ClassID <=0   
 SELECT * from uds_staff where dimission=0 order by RealName 
ELSE  
 SELECT * from uds_staff where staff_id in (select staff_id from uds_staff_in_team where team_id = @ClassID) and dimission=0   order by RealName 
  
SET NOCOUNT OFF  
  
  
  
  
     alter  PROC sp_GetStaffByPosition   
 @PositionID INT,  
 @Inherit int =3,  
 @Upsides int =3  
/*  
  
============================================================  
����: �õ�ְλ�ĳ�Ա���¼���Ա  
����:  
 @PositionID int  : ְλ  
 @Inherit int =0  : �̳й�ϵ  
 @Upsides int =0  : �Ƿ����ͬ����Ա  
  
  
============================================================  
  
*/  
AS  
SET NOCOUNT ON  
  
BEGIN  
CREATE TABLE #TabStaff (staff_id int)  
--����ͬ����Ա  
IF @Upsides & 1 = 1  
 INSERT INTO #TabStaff (staff_id)  
  SELECT staff_id   
   FROM   
    uds_staff_in_position  
   WHERE Position_id = @PositionID  
--�¼���Ա  
IF @Upsides & 2 = 2  
BEGIN  
 --ֻ����ֱ���¼���Ա  
 IF @Inherit & 1 =1   
  INSERT INTO #TabStaff (staff_id)  
   SELECT staff_id FROM uds_staff_in_position  
   WHERE Position_id in (  
      SELECT Position_id   
       FROM   
        uds_Position   
       WHERE super_Position_id = @Positionid  
         and super_Position_id <>Position_id   
           )  
 --����ݹ����¼���Ա  
 IF @Inherit & 2 =2  
 BEGIN  
  DECLARE @ids varchar(2000)  
  DECLARE @tmpids varchar(2000)  
  DECLARE @oldids varchar(2000)  
    
  SET @ids =''  
  SET @tmpids=''  
  SET @oldids =''  
    
  SELECT @ids = @ids + convert(varchar,Position_id) + ','   
   FROM   
    uds_Position   
   WHERE      super_Position_id = @Positionid    
    and super_Position_id <>Position_id   
  IF LEN(@ids)>0  
   SET @ids = LEFT(@ids,LEN(@ids)-1)  
    
  CREATE TABLE #Position(id int)  
  SET @oldids = @ids  
    
  WHILE LEN(@oldids)>0  
  BEGIN  
     
   EXEC ('INSERT INTO #Position   
     SELECT Position_id  
      FROM   
       uds_Position   
      WHERE super_Position_id IN (' + @oldids +')')  
   SET @tmpids=''  
   SELECT @tmpids = @tmpids + convert(varchar,id) + ','   
    FROM #Position  
  
   IF LEN(@tmpids)>0  
    SET @tmpids = LEFT(@tmpids,LEN(@tmpids)-1)  
    
   SET @oldids = @tmpids  
   DELETE FROM #Position  
   SET @ids = @ids + ',' + @tmpids  
  END  
  DROP TABLE #Position  
  
  IF RIGHT(@ids,1)=','  
   SET @ids = LEFT(@ids,LEN(@ids)-1)  
  PRINT 'INSERT INTO #TabStaff (staff_id)  
    SELECT staff_id   
     FROM   
      uds_staff_in_position   
     WHERE Position_id IN (' + @ids + ')'  
  if LEN(@ids)>0  
  EXEC('INSERT INTO #TabStaff (staff_id)  
    SELECT staff_id   
     FROM   
      uds_staff_in_position   
     WHERE Position_id IN (' + @ids + ')')  
    
 END  
  
END  
--�õ����  
SELECT *   
 FROM uds_staff   
 WHERE staff_id IN (  
       SELECT staff_id   
     FROM #tabStaff  
      )  
     AND dimission = 0   order by realname
DROP TABLE #tabStaff  
END  
  
  
SET NOCOUNT OFF  
  
  
  
  
  
  
  
  
  
   CREATE       PROCEDURE sp_GetAllStaff  
 @StaffType bit = 0  
/*  
  
====================================================  
����: �õ����е���Ա  
����:  
 @StaffType bit   : Ա������  
   
====================================================  
  
*/  
AS  
--������ְ��  
IF @StaffType=0  
 SELECT A.*,  
  (CASE   
  WHEN a.birthday is NULL then '-'  
  WHEN datediff(dd,a.birthday,'1900-01-01')=0 then '-'  
  ELSE  
  convert(varchar,datediff(yy,a.birthday,getdate()))  
  END  
  ) AS Age,  
  (CASE sex WHEN 1 then '��' ELSE 'Ů' END) AS SexName,Convert(varchar(10),A.RegistedDate,120) AS RQ,(SELECT Position_name FROM uds_Position WHERE Position_id = b.Position_id) AS Position_Name  
  FROM uds_staff A,uds_staff_in_position b  
  WHERE Dimission =0 and a.staff_id = b.staff_id  
  ORDER BY A.RegistedDate DESC  
--���в���ְ��  
ELSE  
 SELECT A.*,  
  (CASE   
  WHEN a.birthday is NULL then '-'  
  WHEN datediff(dd,a.birthday,'1900-01-01')=0 then '-'  
  ELSE  
  convert(varchar,datediff(yy,a.birthday,getdate()))  
  END  
  ) AS Age,  
  (CASE sex WHEN 1 then '��' ELSE 'Ů' END) AS SexName,Convert(varchar(10),A.RegistedDate,120) AS RQ,(SELECT Position_name FROM uds_Position WHERE Position_id = b.Position_id) AS Position_Name  
  FROM uds_staff A,uds_staff_in_position b  
  WHERE Dimission =1 and a.staff_id = b.staff_id  
  ORDER BY A.RegistedDate DESC  
  
  
  
  
  
  
  
  
    alter       PROCEDURE sp_GetAllStaff  
 @StaffType bit = 0  
/*  
  
====================================================  
����: �õ����е���Ա  
����:  
 @StaffType bit   : Ա������  
   
====================================================  
  
*/  
AS  
--������ְ��  
IF @StaffType=0  
 SELECT A.*,  
  (CASE   
  WHEN a.birthday is NULL then '-'  
  WHEN datediff(dd,a.birthday,'1900-01-01')=0 then '-'  
  ELSE  
  convert(varchar,datediff(yy,a.birthday,getdate()))  
  END  
  ) AS Age,  
  (CASE sex WHEN 1 then '��' ELSE 'Ů' END) AS SexName,Convert(varchar(10),A.RegistedDate,120) AS RQ,(SELECT Position_name FROM uds_Position WHERE Position_id = b.Position_id) AS Position_Name  
  FROM uds_staff A,uds_staff_in_position b  
  WHERE Dimission =0 and a.staff_id = b.staff_id  
  ORDER BY A.RealName 
--���в���ְ��  
ELSE  
 SELECT A.*,  
  (CASE   
  WHEN a.birthday is NULL then '-'  
  WHEN datediff(dd,a.birthday,'1900-01-01')=0 then '-'  
  ELSE  
  convert(varchar,datediff(yy,a.birthday,getdate()))  
  END  
  ) AS Age,  
  (CASE sex WHEN 1 then '��' ELSE 'Ů' END) AS SexName,Convert(varchar(10),A.RegistedDate,120) AS RQ,(SELECT Position_name FROM uds_Position WHERE Position_id = b.Position_id) AS Position_Name  
  FROM uds_staff A,uds_staff_in_position b  
  WHERE Dimission =1 and a.staff_id = b.staff_id  
  ORDER BY A.RealName
  
  
  
     alter          proc sp_GetStaffInTeam   
 @TeamID int  
/*  
  
============================================================  
����: �õ�������@TeamID���е���Ա  
����:  
 @TeamID int  : �飨�ࣩID  
============================================================  
  
*/  
  
AS  
Select  a.Staff_ID staff_id,  
 a.Staff_Name as Staff_Name,  
 a.Realname as RealName,  
 b.Position_name Position_name,  
 (CASE WHEN a.member_type = 2 THEN 1 ELSE 0 END) AS IsLeader  
 From   
  (  
   SELECT uds_staff.*,uds_staff_in_Team.member_type  
    FROM   
     uds_staff,uds_staff_in_Team  
    WHERE   
           uds_staff.staff_id = uds_staff_in_Team.staff_id  
       and uds_staff.dimission=0  
       and uds_staff_in_Team.team_id = @TeamID  
  ) a,  
  uds_Position b,  
  uds_staff_in_position c  
 Where      c.Position_id = b.Position_id  
    and a.staff_id = c.staff_id  
 --ORDER BY a.RealName  
  
  
  
  
  
  
  
  
        alter     proc sp_GetStaffNotInTeam   
 @TeamID int  
/*  
  
============================================================  
����: �õ����в���@TeamID���е���Ա  
����:  
 @TeamID int  : �飨�ࣩID  
============================================================  
  
*/  
AS  
Select a.Staff_ID staff_id ,a.Staff_Name as Staff_Name,a.Realname as RealName,b.Position_name Position_name   
 From (select * from uds_staff   
  Where staff_id not in (select staff_id from uds_staff_in_Team where Team_id = @Teamid) and dimission=0) a,uds_Position b,uds_staff_in_position c  
 Where c.Position_id = b.Position_id  
 and a.staff_id = c.staff_id  
 --order by a.RealName  
  
  
  
  
  
  
       alter       proc sp_GetStaffSubscriptionTeam   
 @TeamID int  
/*  
  
============================================================  
����: �õ�����@TeamID�����Ա  
����:  
 @TeamID int  : �飨�ࣩID  
============================================================  
  
*/  
AS  
Select a.Staff_ID staff_id ,a.Staff_Name as Staff_Name,a.Realname as RealName,b.Position_name Position_name ,c.subscribedate  
 From uds_staff a, uds_Position b ,UDS_Subscription c,uds_staff_in_position d  
 Where d.Position_id = b.Position_id and a.staff_id = c.staff_id and c.classid = @teamid and a.dimission =0  
 and a.staff_id = d.staff_id  
-- ORDER BY a.RealName  
  
  
  
  
    
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  