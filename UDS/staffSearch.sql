     alter    proc UDS_StaffSearch  
@Name varchar(200),  
@Mobile varchar(100),  
@Email varchar(100),  
@Gender varchar(100),  
@PositionID int,  
@SearchBound varchar(50)  
,@Dept varchar(200)
/*--------------------------------------  
功能：查询人员  
参数：  
 @Name 人员姓名  
 @Mobile 手机号码  
 @Email email  
 @Gender 性别  
 @PositionID 职位id  
 @SearchBound 查询范围  
---------------------------------------*/  
AS  
  
DECLARE @SQL VARCHAR(500)  
DECLARE @HAVECONDITION BIT  
  
IF @PositionID=0  
 SET @SQL = 'SELECT UDS_Position.Position_Name,uds_staff.*,Case Sex When 1 Then ''男'' Else ''女'' End AS SexName FROM UDS_STAFF Left OUTER JOIN UDS_Staff_In_Position ON UDS_STAFF.STAFF_ID=UDS_Staff_In_Position.Staff_ID INNER JOIN UDS_Position ON UDS_Staff_In_Position.Position_ID=UDS_Position.Position_ID'  
ELSE  
 SET @SQL = 'SELECT UDS_Position.Position_Name,uds_staff.*,Case Sex When 1 Then ''男'' Else ''女'' End AS SexName FROM UDS_STAFF INNER JOIN UDS_Staff_In_Position ON UDS_STAFF.STAFF_ID=UDS_Staff_In_Position.Staff_ID INNER JOIN UDS_Position ON UDS_Staff_In_Position.Position_ID=UDS_Position.Position_ID '  
  
SET @HAVECONDITION = 0  
 IF (@Name<>'')  
 BEGIN  
  SET @SQL = @SQL + ' WHERE (Staff_Name LIKE ''%'+@Name+'%'' OR RealName LIKE ''%'+@Name+'%'')'  
  SET @HAVECONDITION = 1  
 END  
  
 IF (@Mobile<>'')  
 BEGIN  
  IF(@HAVECONDITION=0)  
  BEGIN  
   SET @SQL = @SQL + ' WHERE (Mobile LIKE ''%'+@Mobile+'%'')'  
   SET @HAVECONDITION = 1  
  END  
  ELSE  
   SET @SQL = @SQL + ' AND (Mobile LIKE ''%'+@Mobile+'%'')'  
 END  
  
 IF (@Email<>'')  
 BEGIN  
  IF(@HAVECONDITION=0)  
  BEGIN  
   SET @SQL = @SQL + ' WHERE (Email LIKE ''%'+@Email+'%'')'  
   SET @HAVECONDITION = 1  
  END  
  ELSE  
   SET @SQL = @SQL + ' AND (Email LIKE ''%'+@Email+'%'')'  
 END  


IF (@Dept<>0)  
 BEGIN  
  IF(@HAVECONDITION=0)  
  BEGIN  
   SET @SQL = @SQL + ' WHERE (staff_dept LIKE ''%'+@Dept+'%'')'  
   SET @HAVECONDITION = 1  
  END  
  ELSE  
   SET @SQL = @SQL + ' AND (staff_dept LIKE ''%'+@Dept+'%'')'  
 END  
  
  
 IF (@Gender<>'')  
 BEGIN  
  IF(@HAVECONDITION=0)  
  BEGIN  
   IF @Gender='male'  
   BEGIN  
    SET @SQL = @SQL + ' WHERE (Sex=1)'  
    SET @HAVECONDITION = 1  
   END   
   ELSE  
   BEGIN  
    SET @SQL = @SQL + ' WHERE (Sex=0)'  
    SET @HAVECONDITION = 1  
   END  
     
  END  
  ELSE  
   IF @Gender='male'  
   BEGIN  
    SET @SQL = @SQL + ' AND (Sex=1)'  
        
   END  
   ELSE  
   BEGIN  
    SET @SQL = @SQL + ' AND (Sex=0)'  
        
   END  
     
 END  
  
 IF (@PositionID<>0)  
 BEGIN  
  IF(@HAVECONDITION=0)  
  BEGIN  
   SET @SQL = @SQL + ' WHERE (UDS_Position.Position_ID='+Convert(varchar(5),@PositionID)+')'  
   SET @HAVECONDITION = 1  
  END  
  ELSE  
   SET @SQL = @SQL + ' AND (UDS_Position.Position_ID='+Convert(varchar(5),@PositionID)+')'  
 END  
  
 IF (@SearchBound='on')  
 BEGIN  
  IF(@HAVECONDITION=0)  
  BEGIN  
   SET @SQL = @SQL + ' WHERE (UDS_Staff.Dimission=0)'  
   SET @HAVECONDITION = 1  
  END  
  ELSE  
   SET @SQL = @SQL + ' AND (UDS_Staff.Dimission=0)'  
 END  
  
 IF (@SearchBound='off')  
 BEGIN  
  IF(@HAVECONDITION=0)  
  BEGIN  
   SET @SQL = @SQL + ' WHERE (UDS_Staff.Dimission=1)'  
   SET @HAVECONDITION = 1  
  END  
  ELSE  
   SET @SQL = @SQL + ' AND (UDS_Staff.Dimission=1)'  
 END  
  
 PRINT @SQL  
 EXECUTE  (@SQL)  
  
  
  
  
  ------------------
  
    CREATE PROCEDURE SP_Ext_GetDept
  
 AS  
  
 SELECT * FROM uds_department ORDER BY Dept_ID 
  