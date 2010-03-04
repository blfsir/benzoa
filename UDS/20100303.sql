 --req:姓名排列：下拉列表按职位走，所选取的人员以职位为准，不要下级职位
 
 
 alter  PROC sp_GetStaffByPosition     
 @PositionID INT,    
 @Inherit int =3,    
 @Upsides int =3    
/*    
    
============================================================    
功能: 得到职位的成员或下级成员    
参数:    
 @PositionID int  : 职位    
 @Inherit int =0  : 继承关系    
 @Upsides int =0  : 是否包含同级成员    
    
    
============================================================    
    
*/    
AS    
SET NOCOUNT ON    
    
BEGIN    


select * from uds_staff
where staff_id in 
(
	select staff_id from  uds_staff_in_position p where @PositionID=p.position_id
)
AND dimission = 0   order by realname 

--CREATE TABLE #TabStaff (staff_id int)    
----加入同级成员    
--IF @Upsides & 1 = 1    
-- INSERT INTO #TabStaff (staff_id)    
--  SELECT staff_id     
--   FROM     
--    uds_staff_in_position    
--   WHERE Position_id = @PositionID    
----下级成员    
--IF @Upsides & 2 = 2    
--BEGIN    
-- --只加入直属下级成员    
-- IF @Inherit & 1 =1     
--  INSERT INTO #TabStaff (staff_id)    
--   SELECT staff_id FROM uds_staff_in_position    
--   WHERE Position_id in (    
--      SELECT Position_id     
--       FROM     
--        uds_Position     
--       WHERE super_Position_id = @Positionid    
--         and super_Position_id <>Position_id     
--           )    
-- --加入递归多层下级成员    
-- IF @Inherit & 2 =2    
-- BEGIN    
--  DECLARE @ids varchar(2000)    
--  DECLARE @tmpids varchar(2000)    
--  DECLARE @oldids varchar(2000)    
--      
--  SET @ids =''    
--  SET @tmpids=''    
--  SET @oldids =''    
--      
--  SELECT @ids = @ids + convert(varchar,Position_id) + ','     
--   FROM     
--    uds_Position     
--   WHERE      super_Position_id = @Positionid      
--    and super_Position_id <>Position_id     
--  IF LEN(@ids)>0    
--   SET @ids = LEFT(@ids,LEN(@ids)-1)    
--      
--  CREATE TABLE #Position(id int)    
--  SET @oldids = @ids    
--      
--  WHILE LEN(@oldids)>0    
--  BEGIN    
--       
--   EXEC ('INSERT INTO #Position     
--     SELECT Position_id    
--      FROM     
--       uds_Position     
--      WHERE super_Position_id IN (' + @oldids +')')    
--   SET @tmpids=''    
--   SELECT @tmpids = @tmpids + convert(varchar,id) + ','     
--    FROM #Position    
--    
--   IF LEN(@tmpids)>0    
--    SET @tmpids = LEFT(@tmpids,LEN(@tmpids)-1)    
--      
--   SET @oldids = @tmpids    
--   DELETE FROM #Position    
--   SET @ids = @ids + ',' + @tmpids    
--  END    
--  DROP TABLE #Position    
--    
--  IF RIGHT(@ids,1)=','    
--   SET @ids = LEFT(@ids,LEN(@ids)-1)    
--  PRINT 'INSERT INTO #TabStaff (staff_id)    
--    SELECT staff_id     
--     FROM     
--      uds_staff_in_position     
--     WHERE Position_id IN (' + @ids + ')'    
--  if LEN(@ids)>0    
--  EXEC('INSERT INTO #TabStaff (staff_id)    
--    SELECT staff_id     
--     FROM     
--      uds_staff_in_position     
--     WHERE Position_id IN (' + @ids + ')')    
--      
-- END    
--    
--END    
----得到结果    
--SELECT *     
-- FROM uds_staff     
-- WHERE staff_id IN (    
--       SELECT staff_id     
--     FROM #tabStaff    
--      )    
--     AND dimission = 0   order by realname  
--DROP TABLE #tabStaff    
END    
    
    
SET NOCOUNT OFF    
    
    
    
    
    go
    
    
    
create view uds_position_clone
as 
select position_id,(case position_id when 1 then 0 else super_position_id end) as super_position_id
,position_name
from uds_position

go


    
    
    /*--   一个重要的函数,很多处理的地方都会用到   --*/   
  --自定义函数--获取编码累计   
  create   function   f_getmergid(@id   int)   
  returns   varchar(8000)   
  as   
  begin   
  declare   @re   varchar(8000),@pid   int   
    
  --为了数字排序正常,需要统一编码宽度   
  declare   @idlen   int,@idheader   varchar(20)   
  select   @idlen=max(len(position_id))   
  ,@idheader=space(@idlen)   
  from   uds_position_clone   
    
  --得到编码累计   
  set   @re=right(@idheader+cast(@id   as   varchar),@idlen)   
  select   @pid=super_position_id   from   uds_position_clone   where   position_id=@id   
  while   @@rowcount>0   
  select   @re=right(@idheader+cast(@pid   as   varchar),@idlen)+','+@re   
  ,@pid=super_position_id   from   uds_position_clone   where   position_id=@pid   

  return(@re)   
  end   
  go   

--select  * from uds_position_clone order by   uds_old.dbo.f_getmergid(position_id)
 
 
       alter   proc sp_GetAllChildPosition   
 @Position_id int  
/*  
  
======================================================  
功能: 得到此职位所有的子职位  
参数:  
 @Position_id int  : 职位ID  
======================================================  
  
*/  
AS  
  
begin

select  * from uds_position_clone order by   uds.dbo.f_getmergid(position_id)
end
--DECLARE @ids VARCHAR(2000)  
--DECLARE @tmpids VARCHAR(2000)  
--DECLARE @oldids VARCHAR(2000)  
--DECLARE @sql nVARCHAR(2000)  
--  
--SET @ids =''  
--SET @tmpids=''  
--SET @oldids =''  
--  
--SELECT  @ids = @ids + CONVERT(VARCHAR,Position_id) + ','   
-- FROM   
--  uds_Position   
-- WHERE  super_Position_id = @Position_id    
--  and super_Position_id <>Position_id   
--IF LEN(@ids)>0  
-- SET @ids = LEFT(@ids,LEN(@ids)-1)  
--  
--CREATE TABLE #Position(id int)  
--SET @oldids = @ids  
--  
--WHILE LEN(@oldids)>0  
-- BEGIN  
--  SET @sql = N'INSERT INTO #Position   
--    SELECT   
--     Position_id   
--    FROM    
--     uds_Position   
--    WHERE super_Position_id in (' + @oldids +')'  
--  
--  EXEC (@sql)  
--  SET  @tmpids=''  
--  SELECT  @tmpids = @tmpids + CONVERT(VARCHAR,id) + ','   
--   FROM #Position  
--  IF LEN(@tmpids)>0  
--   SET @tmpids = LEFT(@tmpids,LEN(@tmpids)-1)  
--  
--  SET @oldids = @tmpids  
--  DELETE FROM #Position  
--  SET @ids = @ids + ',' + @tmpids  
-- END   
--  
--IF LEN(@ids)>0  
--BEGIN  
-- SET @ids = LEFT(@ids,LEN(@ids)-1)    
--   
-- SET @sql =N'SELECT * FROM uds_Position WHERE Position_id in (' + @ids + ')'  
-- PRINT @sql  
-- EXEC (@sql)  
--END  
--ELSE  
-- SELECT * FROM uds_Position WHERE 1=2  
  go
  
  
  
  

    
    