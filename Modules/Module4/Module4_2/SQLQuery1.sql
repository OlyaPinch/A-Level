
-- # 1 Вывести всю информацию из таблицы Sales.Customer 
select  * from Sales.Customer

-- #2 Вывести всю информацию из таблицы Sales.Store отсортированную 
--по Name в алфавитном порядке

select  * from Sales.Store Order by [Name] 

-- #3 Вывести из таблицы HumanResources.Employee всю информацию
--о десяти сотрудниках, которые родились позже 1989-09-28

select * from HumanResources.Employee where [BirthDate]>'1989-09-28 00:00:00.000'

-- #4 Вывести из таблицы HumanResources.Employee сотрудников
--у которых последний символ LoginID является 0.
--Вывести только NationalIDNumber, LoginID, JobTitle.
--Данные должны быть отсортированы по JobTitle по убиванию

select NationalIDNumber, LoginID, JobTitle from HumanResources.Employee where LoginID  like '%0' Order by [JobTitle] desc

-- # 5 Вывести из таблицы Person.Person всю информацию о записях, которые были 
--обновлены в 2008 году (ModifiedDate) и MiddleName содержит
--значение и Title не содержит значение 
------------------------------------------
select * from  Person.Person where ModifiedDate like '%2008%' and MiddleName is not null and Title is null
----------------------ЗАДАНИЕ №6-----------------------------
--Вывести название отдела (HumanResources.Department.Name) БЕЗ повторений
--в которых есть сотрудники
--Использовать таблицы HumanResources.EmployeeDepartmentHistory и HumanResources.Department
-------------------------------------------------------------
select distinct d.Name from HumanResources.Department as d join  HumanResources.EmployeeDepartmentHistory ed on d.[DepartmentID]=ed.[DepartmentID]

----------------------ЗАДАНИЕ №7-----------------------------
--Сгрупировать данные из таблицы Sales.SalesPerson по TerritoryID
--и вывести сумму CommissionPct, если она больше 0
-------------------------------------------------------------
select TerritoryID, SUM (CommissionPct ) from Sales.SalesPerson group by TerritoryID having SUM (CommissionPct )>0


----------------------ЗАДАНИЕ №8-----------------------------
--Вывести всю информацию о сотрудниках (HumanResources.Employee) 
--которые имеют самое большое кол-во 
--отпуска (HumanResources.Employee.VacationHours)
-------------------------------------------------------------
  select * from HumanResources.Employee as p where p.VacationHours=(select max(p1.VacationHours) from HumanResources.Employee as p1)

  ----------------------ЗАДАНИЕ №9-----------------------------
--Вывести всю информацию о сотрудниках (HumanResources.Employee) 
--которые имеют позицию (HumanResources.Employee.JobTitle)
--'Sales Representative' или 'Network Administrator' или 'Network Manager'
-------------------------------------------------------------
 select * from HumanResources.Employee as p where p.jobTitle in  ('Sales Representative','Network Administrator','Network Manager')


----------------------ЗАДАНИЕ №10-----------------------------
--Вывести всю информацию о сотрудниках (HumanResources.Employee) и 
--их заказах (Purchasing.PurchaseOrderHeader). ЕСЛИ У СОТРУДНИКА НЕТ
--ЗАКАЗОВ ОН ДОЛЖЕН БЫТЬ ВЫВЕДЕН ТОЖЕ!!!
-------------------------------------------------------------
select * from HumanResources.Employee as h left join Purchasing.PurchaseOrderHeader  as p on h.BusinessEntityID=p.EmployeeID
