
select * from uds_class order by classid

insert into uds_class values('资源预定','资源预定',59,1,'admin',getdate(),0)

update uds_class set classparentid=(select classid from uds_class where classname='资源预定') where classname='资源预定'

insert into uds_proc_type values(1,59)