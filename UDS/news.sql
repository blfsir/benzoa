USE [UDS]
GO
/****** 对象:  Table [UDS_News]    脚本日期: 02/02/2010 14:50:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UDS_News](
	[News_ID] [int] IDENTITY(1,1) NOT NULL,
	[News_Name] [varchar](200) COLLATE Chinese_PRC_CI_AS NULL,
	[News_Content] [ntext] COLLATE Chinese_PRC_CI_AS NULL,
	[add_date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF




  CREATE  PROC sp_Flow_GetNews      
 @NewsID int = 0        
AS        
IF @NewsID =0         
 SELECT news_id,news_name,news_content,CONVERT(VARCHAR(10), add_date, 110) add_date  ,add_date dateorder        
  FROM UDS_news  order by dateorder  desc   
ELSE        
 SELECT news_id,news_name,news_content,CONVERT(VARCHAR(10), add_date, 110) add_date   ,add_date dateorder           
  FROM UDS_news        
  WHERE news_ID = @NewsID   order by dateorder  desc 
  
  
   CREATE  PROC sp_Flow_AddNews
 @NewsName varchar(200),    
@NewsContent ntext       
AS      
INSERT INTO UDS_News  (News_Name,News_Content,add_date)  
   VALUES     (@NewsName,@NewsContent,GETDATE())      
RETURN IDENT_CURRENT('UDS_News')   


 CREATE PROC sp_Flow_UpdateNews      
 @NewsID int,      
 @NewsName varchar(200),      
 @NewsContent ntext       
AS      
UPDATE UDS_News      
 SET News_Name = @NewsName,News_Content = @NewsContent   
 WHERE News_ID = @NewsID      
      
RETURN 0


CREATE PROC sp_Flow_DeleteNews     
 @NewsID int      
AS      
DELETE FROM UDS_News      
 WHERE News_ID = @NewsID      
      
RETURN 0      



insert into uds_class values('新闻中心','新闻中心',52,371,'admin',getdate(),0)

update uds_class set classparentid=(select classid from uds_class where classname='新闻中心') where classname='新闻中心'

insert into uds_proc_type values(1,52)
