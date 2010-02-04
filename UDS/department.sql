create table UDS_Department(
Dept_ID int PRIMARY KEY IDENTITY, 
Detp_Paretn_ID int,
Dept_Name varchar(255),
Dept_Remark varchar(1000)
,Dimission bit null 
)


 CREATE  PROC sp_Flow_AddDept  
 @DeptName varchar(200),    
@DeptRemark varchar(1000)       
AS      
INSERT INTO UDS_Department  (Dept_Name,Dept_Remark)  
   VALUES     (@DeptName,@DeptRemark )      
RETURN IDENT_CURRENT('UDS_Department')  

create PROC sp_Flow_UpdateDept        
 @DeptID int,        
 @DeptName varchar(200),        
 @Remark varchar(1000)         
AS        
UPDATE UDS_Department        
 SET Dept_Name = @DeptName,Dept_Remark = @Remark     
 WHERE Dept_ID = @DeptID        
        
RETURN 0


  
CREATE PROC sp_Flow_DeleteDept     
 @DeptID int      
AS      
DELETE FROM UDS_Department     
 WHERE Dept_ID = @DeptID      
      
RETURN 0      

  CREATE  PROC sp_GetDept        
 @DeptID int = 0        
AS        
IF @DeptID =0         
 SELECT Dept_id,Dept_name,Dept_Remark      
  FROM UDS_Department   
ELSE        
 SELECT Dept_id,Dept_name,Dept_Remark        
  FROM UDS_Department        
  WHERE Dept_ID = @DeptID  
  
  
  
  
  ---
        CREATE       Proc sp_GetAllDept  
        AS
			SELECT *   
			 FROM    
			  UDS_Department   
			 ORDER BY Dept_ID ASC  
			
			
--增加员工表，部门列
			alter table uds_staff add staff_dept varchar(200) null


---修改员工新增的存储过程			
alter      PROC sp_AddStaff    
 @StaffName varchar(300),    
 @Password varchar(300),    
 @RealName varchar(300),    
 @Sex int,    
 @Status int,    
 @Email varchar(300),    
 @RegistedDate as datetime,    
 @PositionID int,    
 @Phone varchar(50)='',    
 @Mobile varchar(50)='',    
 @Birthday datetime=0,    
 @Caste int = 0,    
 @SystemRoleID int =12,  
 @ContractDate datetime,  
 @InsuranceStatus varchar(100),  
 @AccumulationStatus varchar(100),  
 @IDNumber varchar(20),  
 @Marriage varchar(20),  
 @Address varchar(300),  
 @BirthPlace varchar(100),  
 @Education varchar(100),  
 @Features varchar(200),  
 @Remark varchar(500),  
  
  
 @InsuranceBase numeric(18,2),  
 @EndowmentCompany numeric(18,2),  
 @EndowmentPersonal numeric(18,2),  
 @UnemploymentCompany numeric(18,2),  
 @UnemploymentPersonal numeric(18,2),  
 @Injury numeric(18,2),  
 @Maternity numeric(18,2),  
 @MedicalCompany numeric(18,2),  
 @MedicalPersonal numeric(18,2),  
 @InsuranceCompanyTotal numeric(18,2),  
 @InsurancePersonalTotal numeric(18,2),  
 @AccumulationBase numeric(18,2),  
 @AccumulationCompany numeric(18,2),  
 @AccumulationPersonal numeric(18,2)  ,
	@staff_dept varchar(200)
  
/*    
    
=====================================================    
功能: 新增员工    
参数:     
 @StaffName   员工的姓名    
 @Password   登陆密码    
 @RealName   真实姓名    
 @Sex    性别    
 @Status   状态(在职,离职...)    
 @Email    电子邮件     
 @RegistedDate as  注册日期    
 @PositionID   所在职位    
 @Phone    电话号码    
 @Mobile   手机    
 @Birthday   生日    
 @SystemRoleID  系统角色ID(使用系统角色,    
    使每个人可以有共同部分    
    
=====================================================    
    
*/    
AS    
DECLARE @StaffID int    
SET NOCOUNT ON    
    
--判断员工是否已经注册    
IF NOT EXISTS(SELECT 1 FROM uds_staff WHERE staff_name = @StaffName)    
BEGIN     
 --插入新来员工的记录    
 INSERT INTO uds_staff (staff_name  
,[password]  
,realname  
,sex  
,status  
,email  
,registeddate  
,Phone  
,Mobile  
,Birthday  
,Dimission  
,Caste  
,ContractDate   
,InsuranceStatus   
,AccumulationStatus ,  
IDNumber ,  
Marriage ,  
Address,  
BirthPlace ,  
Education ,  
Features ,  
Remark ,  
  
  
InsuranceBase ,  
EndowmentCompany ,  
EndowmentPersonal ,  
UnemploymentCompany ,  
UnemploymentPersonal ,  
Injury ,  
Maternity ,  
MedicalCompany ,  
MedicalPersonal ,  
InsuranceCompanyTotal ,  
InsurancePersonalTotal ,  
AccumulationBase ,  
AccumulationCompany ,  
AccumulationPersonal ,
staff_dept)    
  VALUES(@StaffName,@Password,@RealName,@Sex,@Status,@Email,@RegistedDate,@Phone,@Mobile,@Birthday,0,@Caste,@ContractDate  ,  
 @InsuranceStatus ,  
 @AccumulationStatus ,  
 @IDNumber ,  
 @Marriage ,  
 @Address  ,  
 @BirthPlace ,  
 @Education ,  
 @Features  ,  
 @Remark  ,  
  
  
 @InsuranceBase ,  
 @EndowmentCompany ,  
 @EndowmentPersonal ,  
 @UnemploymentCompany ,  
 @UnemploymentPersonal ,  
 @Injury ,  
 @Maternity ,  
 @MedicalCompany ,  
 @MedicalPersonal ,  
 @InsuranceCompanyTotal ,  
 @InsurancePersonalTotal ,  
 @AccumulationBase ,  
 @AccumulationCompany ,  
 @AccumulationPersonal,
@staff_dept );    
    
 SET @StaffID = @@IDENTITY    
    
 INSERT INTO uds_staff_in_position     
  (staff_id,position_id)     
  VALUES(@StaffID,@PositionID)    
    
 --把新来员工加入到系统角色里    
 INSERT INTO uds_staff_in_role (staff_id,role_id) VALUES(@StaffID,@SystemRoleID)    
     
 --返回新来员工记录    
 SELECT * FROM uds_staff a WHERE staff_id = @StaffID    
 RETURN 0    
END    
ELSE    
 --返回新来员工记录为空    
 SELECT * FROM uds_staff WHERE 1=2    
 RETURN -1    
SET NOCOUNT OFF    
    
  
  
  
  
  
  
  
  
  
  
  