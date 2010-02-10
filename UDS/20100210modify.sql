
create proc sp_GetChildClass
@Class_id int    
as
select *  FROM uds_class WHERE classparentid = @Class_id  and classparentid <>classid 
