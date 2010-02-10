alter   proc sp_UpdateStaffInfo    
 @StaffID int,    
 @RealName varchar(50),    
 @Sex bit,    
 @Birthday DateTime,    
 @Password varchar(255),    
 @Email varchar(500),    
 @Phone varchar(50),    
 @Mobile varchar(50),    
 @PositionID int,    
 @Caste int =0,    
 @PassCheck bit = 0,    
 @ModifyPassword bit = 1 ,  
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
 @AccumulationPersonal numeric(18,2) , 
 @staff_dept  varchar(200)
    
AS    
    
IF @PassCheck = 1     
BEGIN    
 IF EXISTS(SELECT 1 FROM uds_staff WHERE staff_id = @staffid and [password] = @password)    
  RETURN -1    
END     
    
IF @ModifyPassword = 1    
BEGIN    
 UPDATE UDS_Staff     
  SET RealName=@RealName,    
      Sex=@Sex,    
      Birthday = @Birthday,    
      [Password] = @password,    
             Email = @Email,    
      Phone = @Phone,    
      Mobile=@Mobile,    
      Caste = @Caste,  
ContractDate          =@ContractDate  ,  
 InsuranceStatus       =@InsuranceStatus ,  
 AccumulationStatus    =@AccumulationStatus ,  
 IDNumber              =@IDNumber ,  
 Marriage              =@Marriage ,  
 Address              =@Address  ,  
 BirthPlace            =@BirthPlace ,  
 Education             =@Education ,  
 Features              =@Features  ,  
 Remark                =@Remark  ,  
 InsuranceBase         =@InsuranceBase ,  
 EndowmentCompany      =@EndowmentCompany ,  
 EndowmentPersonal     =@EndowmentPersonal ,  
 UnemploymentCompany   =@UnemploymentCompany ,  
 UnemploymentPersonal  =@UnemploymentPersonal ,  
 Injury                =@Injury ,  
 Maternity             =@Maternity ,  
 MedicalCompany        =@MedicalCompany ,  
 MedicalPersonal       =@MedicalPersonal ,  
 InsuranceCompanyTotal =@InsuranceCompanyTotal ,  
 InsurancePersonalTotal=@InsurancePersonalTotal ,  
 AccumulationBase      =@AccumulationBase ,  
 AccumulationCompany   =@AccumulationCompany ,  
AccumulationPersonal=@AccumulationPersonal  ,
staff_dept =  @staff_dept 
     
  WHERE Staff_ID=@StaffID    
 UPDATE UDS_staff_in_position    
  SET position_id = @positionID    
  WHERE STAFF_ID = @staffid    
END    
ELSE    
BEGIN    
 UPDATE UDS_Staff     
  SET RealName=@RealName,    
      Sex=@Sex,    
      Birthday = @Birthday,    
             Email = @Email,    
      Phone = @Phone,    
      Mobile=@Mobile,    
      Caste = @Caste,  
ContractDate          =@ContractDate  ,  
 InsuranceStatus       =@InsuranceStatus ,  
 AccumulationStatus    =@AccumulationStatus ,  
 IDNumber              =@IDNumber ,  
 Marriage              =@Marriage ,  
 Address              =@Address  ,  
 BirthPlace            =@BirthPlace ,  
 Education             =@Education ,  
 Features              =@Features  ,  
 Remark                =@Remark  ,  
 InsuranceBase         =@InsuranceBase ,  
 EndowmentCompany      =@EndowmentCompany ,  
 EndowmentPersonal     =@EndowmentPersonal ,  
 UnemploymentCompany   =@UnemploymentCompany ,  
 UnemploymentPersonal  =@UnemploymentPersonal ,  
 Injury                =@Injury ,  
 Maternity             =@Maternity ,  
 MedicalCompany        =@MedicalCompany ,  
 MedicalPersonal       =@MedicalPersonal ,  
 InsuranceCompanyTotal =@InsuranceCompanyTotal ,  
 InsurancePersonalTotal=@InsurancePersonalTotal ,  
 AccumulationBase      =@AccumulationBase ,  
 AccumulationCompany   =@AccumulationCompany     
,AccumulationPersonal=@AccumulationPersonal  
,staff_dept =  @staff_dept
  WHERE Staff_ID=@StaffID    
 UPDATE UDS_staff_in_position    
  SET position_id = @positionID    
  WHERE STAFF_ID = @staffid    
END    
    
RETURN  0