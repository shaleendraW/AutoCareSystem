----------------------------------------------------------------------------wish tables -4
CREATE TABLE employee(
	e_code char(8),
    fname VARCHAR(50),
	lname VARCHAR(50),
	b_date DATE,
	gender VARCHAR(10),
	add_line_01 VARCHAR(50),
	add_line_02 VARCHAR(50),
	city VARCHAR(20),
	nic VARCHAR(10),
	tel_phone VARCHAR(10),
	position VARCHAR(50),
	acpt_holidays INT,
	card_id INT,
	profile_pic image,
	end_date date,
	end_time time,
	technician_status varchar(20),
	CONSTRAINT pk_employee_01 PRIMARY KEY(e_code)
);


CREATE TABLE emp_attendance (
	att_id CHAR(8),
	emp_id CHAR(8),
	arrival_time DATETIME,
	departure_time DATETIME
	
	CONSTRAINT pk_attendance_01 PRIMARY KEY(att_id),
	CONSTRAINT fk_EMPAttendance_01 FOREIGN KEY(emp_id) REFERENCES employee ON DELETE CASCADE,

);



CREATE TABLE emp_salary (
	sal_id CHAR(8),
	emp_id CHAR(8),
	att_id CHAR(8),
	rate_per_hour DECIMAL,
	rate_per_ot_hour DECIMAL,
	work_hour DECIMAL,
	ot_hour DECIMAL,
	total_salary DECIMAL,

	CONSTRAINT pk_emp_salary_01 PRIMARY KEY(sal_id),
	CONSTRAINT fk_emp_salary_01 FOREIGN KEY(emp_id) REFERENCES employee,
	CONSTRAINT fk_emp_attendance_01 FOREIGN KEY(att_id) REFERENCES emp_attendance ON DELETE CASCADE,

);

-------------------------------------------sachin tables -1
CREATE TABLE customers(
	c_code char(8) NOT NULL,
	fname VARCHAR(50),
	lname VARCHAR(50),
	nic VARCHAR(10),
	mobile VARCHAR(10),
	address_1 VARCHAR(50),
	address_2 VARCHAR(50),
	city VARCHAR(50),
	email VARCHAR(50),

	CONSTRAINT pk_cus_01 PRIMARY KEY (c_code),
);

CREATE TABLE appointment(
	appointment_id varchar(8) NOT NULL,
	c_code char(8),
	service_type VARCHAR(20),
	sdate Date,
	stime TIME,
	emp_id char(8),

	CONSTRAINT pk_app_01 PRIMARY KEY (appointment_id),
	CONSTRAINT fk_app_01 Foreign KEY (c_code) REFERENCES customers(c_code),
	CONSTRAINT fk_app_02 Foreign KEY (emp_id) REFERENCES employee(e_code)
);

CREATE TABLE slots(
    slot_id varchar(8),
    slot_type varchar(20),
    slot_status varchar(20),
	end_date date,
	end_time time,


    CONSTRAINT pk_slot_01 PRIMARY KEY(slot_id)
);

---------------------------------------ishara tables -2

CREATE TABLE suppliers(
	sup_code CHAR(8) NOT NULL,
    	full_name VARCHAR(100),
	address_1 VARCHAR(100),
	address_2 VARCHAR(100),
	phone VARCHAR(12),
	email VARCHAR(50),
	created_at DATETIME,
		
	CONSTRAINT pk_suppliers_01 PRIMARY KEY(sup_code)
);

CREATE TABLE stocks(
	item_code CHAR(8) NOT NULL,
    	sup_code CHAR(8) NOT NULL,
    	type VARCHAR(100),
    	name VARCHAR(100),
	brand VARCHAR(100),
    	description VARCHAR(500),
	quantity INT,
	unit_price DECIMAL(20,2),
	created_at DATETIME,
	
	CONSTRAINT pk_stocks_01 PRIMARY KEY(item_code),
	CONSTRAINT fk_stocks_01 FOREIGN KEY(sup_code) REFERENCES suppliers 
);

CREATE TABLE orders(
	order_code CHAR(8) NOT NULL,
    	sup_code CHAR(8) NOT NULL,
	order_date DATE,
	status VARCHAR(15),
	created_at DATETIME,
    
	CONSTRAINT pk_orders_01 PRIMARY KEY(order_code),
	CONSTRAINT fk_orders_01 FOREIGN KEY(sup_code) REFERENCES suppliers 
);

CREATE TABLE ordered_items( 

	order_code CHAR(8) NOT NULL,
	item_code CHAR(8) NOT NULL,
	quantity INT,
	amount DECIMAL(20,2),
    	
	
	CONSTRAINT fk_ordered_items_01 FOREIGN KEY(order_code) REFERENCES orders(order_code) ON DELETE CASCADE,
	CONSTRAINT fk_ordered_items_02 FOREIGN KEY(item_code) REFERENCES stocks
);

--------------------------------------------------------shaleendra tables -3
CREATE TABLE salescustomer(
    cus_id CHAR(8),
    cus_name VARCHAR(100),
	cus_address VARCHAR(100),
	cus_telephone VARCHAR(100),

	CONSTRAINT pk_salescustomer_01 PRIMARY KEY(cus_id)
	);

CREATE TABLE sales(
    sales_id CHAR(8),
	cus_id CHAR(8),
	total_price DECIMAL,
	created_at DATETIME,


	CONSTRAINT pk_sales_01 PRIMARY KEY(sales_id),
	CONSTRAINT fk_sales_01 FOREIGN KEY ( cus_id ) REFERENCES salescustomer,
	);

CREATE TABLE sales_items (
    item_id  CHAR(8),
    stock_id CHAR(8), 
    sales_id CHAR(8), 
    description VARCHAR(500) ,
    quantity FLOAT , 
    discount DECIMAL,       
    price  DECIMAL, 
	return_cnt INT,
	
    CONSTRAINT pk_sales_item_01 PRIMARY KEY (item_id),
    CONSTRAINT fk_sales_item_01 FOREIGN KEY ( stock_id ) REFERENCES stocks,
    CONSTRAINT fk_sales_item_02 FOREIGN KEY ( sales_id ) REFERENCES sales

);

CREATE TABLE return_items (
    return_id CHAR(8),
	sales_id CHAR(8),
	stock_id CHAR(8),
    reason VARCHAR (250),
    return_date DATE , 
    quantity FLOAT ,       
	       
    CONSTRAINT  pk_return_items_01 PRIMARY KEY (return_id ),
	CONSTRAINT fk_return_items_02 FOREIGN KEY ( stock_id ) REFERENCES stocks,
    CONSTRAINT fk_return_items_01 FOREIGN KEY ( sales_id ) REFERENCES Sales

);



-------------------------------------------------------------------------------tharidu tables -5

CREATE TABLE vehicles(
	v_code CHAR(8) NOT NULL,
    c_code CHAR(8) NOT NULL,
    vehicle_number VARCHAR(20),
    vehicle_type VARCHAR(50),
	brand VARCHAR(50),
    model VARCHAR(50),
    created_at DATETIME,
	
	CONSTRAINT pk_vehicles_01 PRIMARY KEY(v_code),
	CONSTRAINT fk_vehicle_01 FOREIGN KEY(c_code) REFERENCES customers(c_code)
);

CREATE TABLE services(
	s_code CHAR(8) NOT NULL,
    v_code CHAR(8) NOT NULL,
	enter_date DATE,
    odo_meter INT,
    next_date DATE,
	
	CONSTRAINT pk_services_01 PRIMARY KEY(s_code),
	CONSTRAINT fk_vehicles_01 FOREIGN KEY(v_code) REFERENCES vehicles 
);

CREATE TABLE service_types(
	stid INT IDENTITY(1,1),
    name VARCHAR(200),
	description VARCHAR(255),
    charges DECIMAL(20,2),
	
	CONSTRAINT pk_service_type_01 PRIMARY KEY(stid)
);

CREATE TABLE provided_services(
	s_code CHAR(8) NOT NULL,
    stid INT,
    charges DECIMAL(20,2),
	created_at DATETIME,

	CONSTRAINT fk_pvd_services_01 FOREIGN KEY(s_code) REFERENCES services(s_code) ON DELETE CASCADE,
	CONSTRAINT fk_pvd_services_02 FOREIGN KEY(stid) REFERENCES service_types

);

CREATE TABLE repairs(
	r_code CHAR(8) NOT NULL,
    e_code CHAR(8) NOT NULL,
    v_code CHAR(8) NOT NULL,
	repair_date DATE,
	
	CONSTRAINT pk_repairs_01 PRIMARY KEY(r_code),
	CONSTRAINT fk_repairs_01 FOREIGN KEY(e_code) REFERENCES employee,
	CONSTRAINT fk_repairs_02 FOREIGN KEY(v_code) REFERENCES vehicles
);

CREATE TABLE repair_types(
	rtid INT IDENTITY(1,1),
    name VARCHAR(200),
	description VARCHAR(255),
    charges DECIMAL(20,2),
	
	CONSTRAINT pk_repair_type_01 PRIMARY KEY(rtid)
);

CREATE TABLE provided_repairs(
	r_code CHAR(8) NOT NULL,
    rtid INT,
    charges DECIMAL(20,2),
	created_at DATETIME,

	CONSTRAINT fk_pvd_repairs_01 FOREIGN KEY(r_code) REFERENCES repairs(r_code) ON DELETE CASCADE,
	CONSTRAINT fk_pvd_repairs_02 FOREIGN KEY(rtid) REFERENCES repair_types 

);

CREATE TABLE error_codes(
	ecid INT IDENTITY(1,1),
    code VARCHAR(20),
	description VARCHAR(255),
	extra_details VARCHAR(255),
	created_at DATETIME,
	
	CONSTRAINT pk_error_codes_01 PRIMARY KEY(ecid),
);

CREATE TABLE vehicle_errors(
	r_code CHAR(8) NOT NULL,
    ecid INT NOT NULL,
	status VARCHAR(10),
	created_at DATETIME,
	
	CONSTRAINT fk_errors_01 FOREIGN KEY(r_code) REFERENCES repairs,
	CONSTRAINT fk_errors_02 FOREIGN KEY(ecid) REFERENCES error_codes
);

---------------------------------------------------------------------------sajith tables  -6
create table rental_vehicle (

	rv_id CHAR(8) NOT NULL,
	rv_brand VARCHAR(50),
	rv_model VARCHAR(50),
	rv_year INT,
	rv_fual_type VARCHAR(50),
	rv_millage INT,
	rv_status VARCHAR(50),
	rv_km_per_day INT,
	rv_rate_per_day FLOAT,
	rv_number VARCHAR(50),
	rv_exceed_rate FLOAT,
	rv_category VARCHAR (50),
	rv_minimum_diposit FLOAT,
	
	CONSTRAINT pk_rental_vehicle_01 PRIMARY KEY(rv_id)
);

create table rental_details (

	rnt_id CHAR(8) NOT NULL,
	rnt_cus_id CHAR(8),
	rnt_vehicle_id CHAR(8),
	rnt_date DATE,
	rnt_return_date DATE,
	rnt_deposit_amount FLOAT,
	rnt_current_millage INT,
	rnt_amount	FLOAT,
	rnt_invoice_is_issued VARCHAR(10),
	rnt_bill_is_issued VARCHAR(10),
	
	
	CONSTRAINT pk_rental_details_01 PRIMARY KEY(rnt_id),
	CONSTRAINT fk_rental_details_01 FOREIGN KEY(rnt_cus_id) REFERENCES customers(c_code), 
	CONSTRAINT fk_rental_details_02 FOREIGN KEY(rnt_vehicle_id) REFERENCES rental_vehicle(rv_id)
);

create table rental_bill_details (

	bill_id CHAR(8) NOT NULL,
	bill_rnt_id CHAR(8),
	bill_date DATE,
	bill_tot_amount FLOAT,
	bill_final_millage INT,
	bill_damage_amount FLOAT,
	
	CONSTRAINT pk_rental_bill_details_01 PRIMARY KEY(bill_id),
	CONSTRAINT fk_rental_bill_details_01 FOREIGN KEY(bill_rnt_id) REFERENCES rental_details(rnt_id), 

);

create table rental_invoice (

	in_id CHAR(8) NOT NULL,
	in_rnt_id CHAR(8),
	in_date DATE,
	in_advanced_payment FLOAT,
	
	CONSTRAINT pk_rental_invoice_01 PRIMARY KEY(in_id),
	CONSTRAINT fk_rental_invoice_01 FOREIGN KEY(in_rnt_id) REFERENCES rental_details(rnt_id), 

);

create table administrator (

	ad_id CHAR(8) NOT NULL,
	ad_username varchar(25),
	ad_pwd varchar(25),
	
	CONSTRAINT pk_administrator_01 PRIMARY KEY(ad_id),
	

);

--------------------------------------------------------------------------------------------------------lahiru tables -7
CREATE TABLE equipments(
    item_code CHAR(8) NOT NULL,
    item_name VARCHAR(200),
    item_info VARCHAR(255),
	item_invoice_id INT,
    item_price DECIMAL(20,2),
	item_condition VARCHAR(100),
    sup_code CHAR(8),
	warrenty_exp_date DATE,
	status bit,
	
	CONSTRAINT pk_item_01 PRIMARY KEY(item_code),
	CONSTRAINT fk_item_01 FOREIGN KEY(sup_code) REFERENCES suppliers 
);

create table equipment_repair (

	eq_repair_id CHAR(8) NOT NULL,
	item_code CHAR(8),
	info varchar(200),
	invoice_id INT,
	amount DECIMAL(20,2),
	maintanance_date DATE,
	
	CONSTRAINT pk_maintain_equipments PRIMARY KEY(eq_repair_id),
	CONSTRAINT fk_maintain_equipments FOREIGN KEY(item_code) REFERENCES equipments
)

create table rental_vehicle_renew (

	renew_id CHAR(8) NOT NULL,
	rv_id CHAR(8),
	renew_type varchar(100),	
	invoice_id INT,
	amount DECIMAL(20,2),
	renew_date DATE,
	
	CONSTRAINT pk_rent_vehi_renew_01 PRIMARY KEY(renew_id),
	CONSTRAINT fk_rent_vehi_renew_01 FOREIGN KEY(rv_id) REFERENCES rental_vehicle
)

create table rental_vehicle_repair_service (

	maintanance_id CHAR(8) NOT NULL,
	rv_id CHAR(8),
	maintanance_type varchar(100),
	info varchar(200),
	invoice_id INT,
	amount DECIMAL(20,2),
	current_milage int,
	maintanance_date DATE,
	
	CONSTRAINT pk_maintain_rent_vehi_01 PRIMARY KEY(maintanance_id),
	CONSTRAINT fk_maintain_rent_vehi_01 FOREIGN KEY(rv_id) REFERENCES rental_vehicle
)

-------------------------------------------------------------------------------- Sameer Tables -8
CREATE TABLE bills
(
    b_id INT IDENTITY(1,1),
    b_type VARCHAR(50),
	b_total_amount FLOAT,
    b_monthly_amount FLOAT,
    b_issue_date DATE,
    b_paid_amount FLOAT,
	b_paid_date DATE,
	
	CONSTRAINT pk_bills_01 PRIMARY KEY (b_id)
);

CREATE TABLE income
(
	i_id INT IDENTITY(1,1),
	i_cus_id INT,
	i_cus_name VARCHAR(100),
	i_amount FLOAT,
	i_type VARCHAR(50),
	i_date DATE,
	
	CONSTRAINT pk_income_01 PRIMARY KEY (i_id)
);

CREATE TABLE expenses
(
	e_id INT IDENTITY(1,1),
	e_ref_id INT,
	e_amount FLOAT,
	e_type VARCHAR(20),
	e_date DATE,
	
	CONSTRAINT pk_expenses_01 PRIMARY KEY (e_id)
);

CREATE TABLE loans
(
	l_id INT IDENTITY(1,1),
	l_lender_name VARCHAR(100),
	l_start_date DATE,
	l_period INT,
	l_amount FLOAT,
	l_rate FLOAT,
	l_end_date DATE,
	l_monthly_amount FLOAT,
	l_total_amount FLOAT,
	l_paid_months INT,
	
	CONSTRAINT pk_loans_01 PRIMARY KEY (l_id)
);

