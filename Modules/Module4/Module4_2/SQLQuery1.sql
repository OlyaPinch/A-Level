
-- # 1 ������� ��� ���������� �� ������� Sales.Customer 
select  * from Sales.Customer

-- #2 ������� ��� ���������� �� ������� Sales.Store ��������������� 
--�� Name � ���������� �������

select  * from Sales.Store Order by [Name] 

-- #3 ������� �� ������� HumanResources.Employee ��� ����������
--� ������ �����������, ������� �������� ����� 1989-09-28

select * from HumanResources.Employee where [BirthDate]>'1989-09-28 00:00:00.000'

-- #4 ������� �� ������� HumanResources.Employee �����������
--� ������� ��������� ������ LoginID �������� 0.
--������� ������ NationalIDNumber, LoginID, JobTitle.
--������ ������ ���� ������������� �� JobTitle �� ��������

select NationalIDNumber, LoginID, JobTitle from HumanResources.Employee where LoginID  like '%0' Order by [JobTitle] desc

-- # 5 ������� �� ������� Person.Person ��� ���������� � �������, ������� ���� 
--��������� � 2008 ���� (ModifiedDate) � MiddleName ��������
--�������� � Title �� �������� �������� 
------------------------------------------
select * from  Person.Person where ModifiedDate like '%2008%' and MiddleName is not null and Title is null
----------------------������� �6-----------------------------
--������� �������� ������ (HumanResources.Department.Name) ��� ����������
--� ������� ���� ����������
--������������ ������� HumanResources.EmployeeDepartmentHistory � HumanResources.Department
-------------------------------------------------------------
select distinct d.Name from HumanResources.Department as d join  HumanResources.EmployeeDepartmentHistory ed on d.[DepartmentID]=ed.[DepartmentID]

----------------------������� �7-----------------------------
--������������ ������ �� ������� Sales.SalesPerson �� TerritoryID
--� ������� ����� CommissionPct, ���� ��� ������ 0
-------------------------------------------------------------
select TerritoryID, SUM (CommissionPct ) from Sales.SalesPerson group by TerritoryID having SUM (CommissionPct )>0


----------------------������� �8-----------------------------
--������� ��� ���������� � ����������� (HumanResources.Employee) 
--������� ����� ����� ������� ���-�� 
--������� (HumanResources.Employee.VacationHours)
-------------------------------------------------------------
  select * from HumanResources.Employee as p where p.VacationHours=(select max(p1.VacationHours) from HumanResources.Employee as p1)

  ----------------------������� �9-----------------------------
--������� ��� ���������� � ����������� (HumanResources.Employee) 
--������� ����� ������� (HumanResources.Employee.JobTitle)
--'Sales Representative' ��� 'Network Administrator' ��� 'Network Manager'
-------------------------------------------------------------
 select * from HumanResources.Employee as p where p.jobTitle in  ('Sales Representative','Network Administrator','Network Manager')


----------------------������� �10-----------------------------
--������� ��� ���������� � ����������� (HumanResources.Employee) � 
--�� ������� (Purchasing.PurchaseOrderHeader). ���� � ���������� ���
--������� �� ������ ���� ������� ����!!!
-------------------------------------------------------------
select * from HumanResources.Employee as h left join Purchasing.PurchaseOrderHeader  as p on h.BusinessEntityID=p.EmployeeID
