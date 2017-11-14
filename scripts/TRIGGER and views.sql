

-------------------------- view of sales--------------------------------------------
CREATE VIEW SalesandSalesItems AS
SELECT s.sales_id,sc.cus_name,si.item_id,si.stock_id,si.description,si.quantity,si.return_cnt,st.unit_price,s.total_price FROM sales s,sales_items si,stocks st,salescustomer sc
where s.sales_id=si.sales_id and s.cus_id=sc.cus_id and si.stock_id=st.item_code




CREATE VIEW Salesview AS
select s.sales_id ,si.item_id ,sc.cus_id ,sc.cus_name ,sc.cus_address ,sc.cus_telephone ,si.quantity ,s.total_price,si.discount,si.price  from sales s,sales_items si,salescustomer sc 
where s.sales_id=si.sales_id and sc.cus_id=s.cus_id 

select * from Salesview
drop view Salesview
-----------------------trigger---------------------------------


CREATE TRIGGER Triger_SalesandSalesItems
ON SalesandSalesItems
INSTEAD OF Update
AS
BEGIN

DECLARE @salesid char
DECLARE @Total decimal
DECLARE @recount int
DECLARE @Itemid char



select @salesid=sales_id from inserted
select @Total=total_price from inserted
select @recount=return_cnt from inserted
select @Itemid=item_id from inserted


update sales set total_price=@Total where sales_id=@salesid

update sales_items set return_cnt=@recount where item_id=@Itemid

END


CREATE TRIGGER Trigger_Salesview
ON Salesview
INSTEAD OF Update,delete
AS
BEGIN

DECLARE @salesid char
DECLARE @Itemid char
DECLARE @CustomerID char
DECLARE @CustomerName varchar
DECLARE @CustomerAddress varchar
DECLARE @CustomerTelephone varchar
DECLARE @Quntity float
DECLARE @Discount decimal
DECLARE @TotalPrice decimal



SELECT @salesid=sales_id from inserted 

SELECT @Itemid=item_id from inserted

SELECT @CustomerID=cus_id from inserted
 
SELECT @CustomerName=cus_name from inserted

SELECT @CustomerAddress=cus_address from inserted

SELECT @CustomerTelephone=cus_telephone from inserted


SELECT @Quntity=quantity from inserted

SELECT @TotalPrice=total_price from inserted

SELECT @Discount=discount from inserted








update sales set total_price=@TotalPrice where sales_id=@salesid

update sales_items set quantity=@Quntity, discount=@Discount where item_id=@Itemid


update salescustomer set cus_name=@CustomerName ,cus_address=@CustomerAddress , cus_telephone=@CustomerTelephone where cus_id=@CustomerID




SELECT @salesid=sales_id from deleted

SELECT @Itemid=item_id from deleted

SELECT @CustomerID=cus_id from deleted



DELETE from salescustomer WHERE  cus_id=@CustomerID

DELETE from sales_items WHERE item_id=@Itemid





END


