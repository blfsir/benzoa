--select * from uds_class order by classid

insert into uds_class values('�칫�������','�칫�������',57,1,'admin',getdate(),0)
update uds_class set classparentid=437 where classname='�칫�������' 

--select * from uds_proc_type
insert into uds_proc_type values(1,57)



select * from uds_class
insert into uds_class values('�ƻ��ܽ�','�ƻ��ܽ�',58,1,'admin',getdate(),0)
update uds_class set classparentid=448 where classname='�ƻ��ܽ�' 

--select * from uds_proc_type
insert into uds_proc_type values(1,58)