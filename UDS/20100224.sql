
        CREATE      PROC sp_Desktop_GetBBS   
AS  
select * 
 from uds_bbs_forumitem     
ORDER BY send_time  DESC  
  