
select * from uds_class order by classid

insert into uds_class values('��ԴԤ��','��ԴԤ��',59,1,'admin',getdate(),0)

update uds_class set classparentid=(select classid from uds_class where classname='��ԴԤ��') where classname='��ԴԤ��'

insert into uds_proc_type values(1,59)