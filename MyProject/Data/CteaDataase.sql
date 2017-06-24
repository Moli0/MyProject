create database ERP      --drop database ERP
on 
(
  name = 'ERP.mdf',
  filename = 'C:\Users\l\Desktop\����ϵͳ\MyProject\MyProject\Data\ERP.mdf',
  size = 5MB,
  maxsize = 500MB,
  filegrowth = 1%
)
log on
(
  name = 'ERP_Log.ldf',
  filename = 'C:\Users\l\Desktop\����ϵͳ\MyProject\MyProject\Data\ERP_Log.ldf',
  size = 1MB,
  maxsize = 50MB,
  filegrowth = 1MB
)
go
--------------------------------------------------------------------------------------------
use ERP
go
--------------------------------------------------------------------------------------------
create rule ID_rule as
(@value like '[a-z]%' or @value like '[A-Z]' )and len(@value)>5

go
create rule Password_rule as
len(@value)>5
go
create rule theidentity_rule as
@value = '����Ա' or @value = '��ͨ�û�'
go
create rule telephone_style as
@value like '[0-9][1-9][0-9][0-9][1-9][0-9][0-9][0-9][0-9][0-9][0-9]' or @value like  '[1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9] '
go
create rule ID_card_rule as
len(@value) = 15 or len(@value) = 18
go
create rule discount_rule as
@values between 0 and 1
go
create default discount_default as 1
go
create default integral_default as 0
go
create rule value_limit_rule as 
@values = 0 or @values = 1 or @values = 2
go
--------------------------------------------------------------------------------------------
create table theUser     --
(
  ID varchar(16) primary key,
  Password varchar(24) not null,
  Name varchar(10) not null,
  E_mail varchar(50) not null,
  Telephone char(11),
  theidentity varchar(10) not null
)
go 
create table department    --
(
  ID char(6) not null primary key,
  name varchar(16) not null,
  principal varchar(10),
  telephone char(11)
)
go
create table post		--
(
  ID char(4) primary key,
  name varchar(20) not null,
  department_ID char(6) not null,
)
go
create table employee		--drop table employee
(
  department_ID char(6) not null,
  ID char(7) primary key,
  name varchar(10) not null,
  sex char(2) not null,
  wages money not null,
  ID_card varchar(18) not null,
  address varchar(50) null,
  telephone char(11),
  post varchar(20) not null,
  join_time datetime null
)
go
create table customer		--
(
  VIP_ID char(8) primary key,
  name varchar(10) not null,
  integral float not null,
  ID_card varchar(18) not null,
  telephone varchar(11)
)
go
create table goods_type		--
(
  ID char(4) primary key,
  T_name varchar(20) not null
)
go
create table goods		--
(
  ID char(8) primary key,
  name varchar(50) not null,
  Production_Date datetime not null,
  Shelf_life varchar(10) null,
  number varchar(10) null,
  purchase_price money not null,
  price money null,
  discount float null,
  supplier_ID char(4),
  remarks varchar(100) null
)
go
create table supplier		-- 
(
  ID char(4) primary key,
  name varchar(50),  
  contacts varchar(10),
  telephone varchar(11)
)
go
create table Applicants   --drop table Applicants
(
  No int identity(1,1) primary key,
  name varchar(10) not null,
  sex char(2) not null,
  age int not null,
  ID_card varchar(18) not null,
  post varchar(20),
  join_time datetime not null
)
go
create table sign
(
  employee_ID char(7) primary key,     --drop table sign
  employee_name varchar(10) not null,
  SHC  smallint not null,        --should he come
  sign_in smallint not null
)
create table notice
(
  department_id char(6),
  date datetime,
  content varchar(255)null
)
go
create table demand
(
   NO int identity(1,1) primary key,
   department_id char(6) not null,
   post varchar(20) not null,
   rec_Number smallint not null,
   exlain varchar(255) not null,
)
go
----------------------------------------------------------
go
sp_bindrule ID_rule,'theUser.ID'
go
sp_bindrule Password_rule,'theUser.Password'
go
sp_bindrule theidentity_rule,'theUser.theidentity'
go
sp_bindrule telephone_style,'department.telephone'
go
sp_bindrule telephone_style,'employee.telephone'
go
sp_bindrule ID_card_rule,'employee.ID_card'
go
sp_bindrule ID_card_rule,'customer.ID_card'
go
--sp_bindrule telephone_style,'customer.telephone'
go
sp_bindrule discount_rule,'goods.discount'
go
sp_bindefault discount_default,'goods.discount'
go
sp_bindefault integral_default,'customer.integral'
go
sp_bindrule ID_card_rule,'applicants.ID_card'
go
sp_bindefault integral_default,'sign.sign_in'
go
sp_bindrule value_limit_rule,'sign.sign_in'
go
sp_bindrule value_limit_rule,'sign.SHC'
go
sp_bindefault integral_default,'sign.SHC'
go

----------------------------------------------------------
insert theUser values('admin1','123456','Boss','2333@32.com','188888','����Ա')
insert theUser values('user01','123456','user','22222@32.com','18882222288','��ͨ�û�')
go
--------------------------------------------------------------------------------------------
insert department values('PU0001','�ɹ���','����','08263113574')
insert department values('ST0001','�ִ���','������','08263157712')
go
--------------------------------------------------------------------------------------------
insert post values('PUby','�ɹ����ɹ���Ա','PU0001')
insert post values('PUck','�ɹ�����Ա','PU0001')
insert post values('STrc','�ִ�������¼��Ա','ST0001')
insert post values('STst','�ִ����ֻ�Ա','ST0001')
insert post values('PUdi','�ɹ�������','PU0001')
insert post values('STdi','�ִ�������','ST0001')
go
--------------------------------------------------------------------------------------------
insert goods_type values('1001','����')
insert goods_type values('1002','ˮ��')
go
--------------------------------------------------------------------------------------------
insert supplier values('SP01','1��ʳƷ���޹�˾','Ӣ����','03511825643')
insert supplier values('SP02','2��ʳƷ���޹�˾','�ƽ�','08263365431')
insert supplier values('SP03','1��ũ�ҹ�԰','Ҧ��','13548653326')
insert supplier values('SP04','2�Ź�԰','���','15864852148')
go
--------------------------------------------------------------------------------------------
insert goods values('10010001','�ɿ���','2017-5-1','12����','100',50,75,1,'SP01','')
insert goods values('10010002','����','2017-4-30','6����','150',20,25,1,'SP01','')
insert goods values('10010003','ţ���','2017-5-3','12����','80',60,88,1,'SP02','')
insert goods values('10020001','����','2017-5-5','20��','100',50,75,0.9,'SP03','')
insert goods values('10020002','������','2017-5-6','10��','100',50,75,1,'SP04','')
insert goods values('10020003','ľ��','2017-5-5','20��','100',50,75,1,'SP03','')
go
--------------------------------------------------------------------------------------------
insert employee values('PU0001','F201001','����','Ů',12000,'416572198204304322','�㶫ʡ������','15075985437','�ɹ�������',GETDATE())
insert employee values('ST0001','FA01001','������','��',10000,'416572198503143325','�㶫ʡ������','13875443030','�ִ�������',GETDATE())
insert employee values('PU0001','F201101','����','��',4000,'485686198803202341','����ʡ������','15042355437','�ɹ����ɹ���Ա',GETDATE())
insert employee values('PU0001','F201102','Ф����','Ů',4000,'345286199011204231','�㶫ʡ������','15025301537','�ɹ����ɹ���Ա',GETDATE())
insert employee values('PU0001','F201103','����','��',4000,'488594199205163351','����������','15595481257','�ɹ����ɹ���Ա',GETDATE())
insert employee values('PU0001','F201104','Ф��','Ů',3500,'476322199204144332','����ʡ������','13534533030','�ɹ����ɹ���Ա',GETDATE())
insert employee values('PU0001','F201201','��ˮ��','Ů',3500,'456325199002124322','����ʡ������','15435285437','�ɹ�����Ա',GETDATE())
insert employee values('PU0001','F201202','��Ҷ','Ů',3500,'486875198808315326','�㶫ʡ��ɽ��','15684823437','�ɹ�����Ա',GETDATE())
insert employee values('PU0001','F201203','��ʫ��','Ů',3500,'456325199302114322','����������','15864235477','�ɹ�����Ա',GETDATE())
insert employee values('ST0001','FA01101','�����','Ů',3500,'476322199312042358','����������','18568424301','�ִ�������¼��Ա',GETDATE())
insert employee values('ST0001','FA01102','������','Ů',3500,'354695199305184593','����ʡ������','14761534025','�ִ�������¼��Ա',GETDATE())
insert employee values('ST0001','FA01201','����','��',4500,'264322198904243325','�㶫ʡï����','13236643030','�ִ����ֻ�Ա',GETDATE())
insert employee values('ST0001','FA01202','������','��',4500,'258469198504305622','����������','14759315030','�ִ����ֻ�Ա',GETDATE())
insert employee values('ST0001','FA01203','������','��',4500,'248611199005283355','����ʡ�Ƹ���','15892153672','�ִ����ֻ�Ա',GETDATE())


go
---------------------------------------------------------------------------------------------
insert customer values('CX000001','������',0,'416086199205150351','13354856953')
insert customer values('CX000002','�ƺ���',0,'416086199405252454','15458580369')
go
---------------------------------------------------------------------------------------------
--update sign set employee_ID = employee.ID from employee
insert into sign(employee_ID,employee_name) select ID,name from employee
go
-------------------------------------------------------------------------------------------
insert notice values('PU0001',GETDATE(),'     XXXX                XXXXXXXX           XXXXXXXXXXXX               XXXXXXX                    XXXXX')
insert notice values('ST0001',GETDATE(),'     XXYYY              XXXXXXYYYYYXXX             XXXXXXXXXXXXXXX                    XXXXX')
insert notice values('PU0001',GETDATE(),'     YYYYYYY              YYYYYYYYYYYYY        YYYYYYYYYYYYY         YYYYYYYYYYY      YYYYY         YY')
insert notice values('ST0001',GETDATE(),'     XHHHH            XHHHHHHHHHHHHHHHHX             XXYFFHHHHHHHHHXX                   CCCXXXXXXXX')
go
--------------------------------------------------------------------------------------------
