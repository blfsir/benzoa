create table UDS_Plan(
	ID int primary key identity,
	PlanObjectType varchar(50),
	PlanPeriodType varchar(50),
	PlanContent text,
	PlanAttach varchar(200),
	PlanConclusion text,
	PlanConclusionAttach varchar(200),
	PlanCreator varchar(50),
	PlanCreateDate DateTime
)