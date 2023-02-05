CREATE DATABASE HOTEL
USE HOTEL

CREATE TABLE ACCOUNT(
ACC_ID int IDENTITY (1000,1) primary key,
FIRSTNAME VARCHAR(30) not null,
LASTNAME VARCHAR(30) not null,
ADDRESS VARCHAR(30) not null,
CONTACT VARCHAR(20) not null,
USERNAME VARCHAR(30) not null,
PASSWORD VARCHAR(30) not null,
ACCOUNT_TYPE VARCHAR(5) not null,
CONSTRAINT ACC_INF UNIQUE (FIRSTNAME,LASTNAME),
CONSTRAINT USER_AU UNIQUE (USERNAME))

CREATE PROCEDURE acc_save
@fname varchar(30),
@lname varchar(30),
@add varchar(30),
@cont varchar(20),
@user varchar(30),
@pass varchar(30),
@type varchar(5)
as
INSERT INTO ACCOUNT VALUES (@fname,@lname,@add,@cont,@user,HASHBYTES ('sha1',@pass),@type)

CREATE PROCEDURE acc_login
@user varchar(30),
@pass varchar(30)
as 
SELECT USERNAME, PASSWORD FROM ACCOUNT WHERE USERNAME = @user AND PASSWORD = HASHBYTES ('sha1',@pass)

CREATE PROCEDURE acc_update
@id int,
@fname varchar(30),
@lname varchar(30),
@add varchar(30),
@cont varchar(20),
@user varchar(30),
@pass varchar(30),
@type varchar(5)
as
UPDATE ACCOUNT SET FIRSTNAME = @fname, LASTNAME = @lname, ADDRESS = @add, CONTACT = @cont, USERNAME = @user,
PASSWORD = HASHBYTES ('sha1',@pass), ACCOUNT_TYPE = @type WHERE ACC_ID = @id

CREATE PROCEDURE acc_delete
@id int
as 
DELETE FROM ACCOUNT WHERE ACC_ID = @id

CREATE PROCEDURE acc_search
@key varchar(max)
as SELECT * FROM ACCOUNT WHERE
LASTNAME like '%' +@key + '%' or FIRSTNAME like '%' +@key + '%'

CREATE PROCEDURE acc_view
as
SELECT * FROM ACCOUNT

CREATE TABLE ROOM(
ROOM_ID int identity(1000,1) primary key,
ROOM_NO varchar(5) not null,
ROOM_TYPE varchar(30) not null,
MAX_NUM int not null,
STATUS varchar(10),
ROOM_PRICE int not null,
CONSTRAINT ROOM_UNQ UNIQUE (ROOM_NO))

CREATE PROCEDURE room_add
@num varchar(5),
@type varchar(30),
@max int,
@status varchar(10),
@price int
as
INSERT INTO ROOM VALUES(@num,@type,@max,@status,@price)

CREATE PROCEDURE room_edit
@id int,
@num varchar(5),
@type varchar(30),
@max int,
@status varchar(10),
@price int
as 
UPDATE ROOM SET ROOM_NO = @num, ROOM_TYPE = @type, MAX_NUM = @max, STATUS = @status, ROOM_PRICE = @price WHERE ROOM_ID = @id

CREATE PROCEDURE room_delete
@id int
as
DELETE FROM ROOM WHERE ROOM_ID = @id

CREATE PROCEDURE room_view
as
SELECT * FROM ROOM

CREATE PROCEDURE room_available
as
SELECT ROOM_ID,ROOM_NO,ROOM_TYPE,MAX_NUM,ROOM_PRICE FROM ROOM WHERE STATUS = 'Vacant'

CREATE PROCEDURE room_search
@key varchar(max)
as SELECT * FROM ROOM WHERE
ROOM_TYPE like '%' +@key + '%' or ROOM_NO like '%' +@key + '%'

CREATE PROCEDURE room_search_available
@key varchar(max)
as SELECT ROOM_ID,ROOM_NO,ROOM_TYPE,MAX_NUM,ROOM_PRICE FROM ROOM WHERE STATUS = 'Vacant' AND
ROOM_TYPE like '%' +@key + '%' or ROOM_NO like '%' +@key + '%' 

CREATE PROCEDURE getAccountType
@user varchar(30)
as
SELECT ACCOUNT_TYPE FROM ACCOUNT WHERE USERNAME = @user

CREATE TABLE GUEST(
GUEST_ID int identity(10000,1) primary key,
GUEST_NAME varchar(100) not null,
GUEST_ADD varchar(50) not null,
GUEST_CONTACT varchar(20) not null,
CONSTRAINT GUEST_UNQ UNIQUE (GUEST_NAME))

CREATE PROCEDURE guest_add
@name varchar(100),
@add varchar(50),
@contact varchar(20)
as
INSERT INTO GUEST VALUES(@name,@add,@contact)

CREATE PROCEDURE guest_edit
@id int,
@name varchar(100),
@add varchar(50),
@contact varchar(20)
as
UPDATE GUEST SET GUEST_NAME = @name, GUEST_ADD = @add, GUEST_CONTACT = @contact WHERE GUEST_ID = @id

CREATE PROCEDURE guest_delete
@id int
as
DELETE FROM GUEST WHERE GUEST_ID = @id

CREATE PROCEDURE guest_view
as
SELECT * FROM GUEST

CREATE PROCEDURE guest_search
@key varchar(max)
as SELECT * FROM GUEST WHERE
GUEST_NAME like '%' +@key + '%' 

CREATE TABLE ADDED_GUEST(
AG_ID int identity(10000,1) PRIMARY KEY,
GUEST_ID int not null,
GUEST_NAME varchar(100) not null)

CREATE PROCEDURE APPEND_GUEST
@id int,
@name varchar(100)
as
INSERT INTO ADDED_GUEST VALUES(@id,@name)

CREATE PROCEDURE DISPLAY_GUEST_ADDED
as
SELECT GUEST_ID,GUEST_NAME FROM ADDED_GUEST

CREATE PROCEDURE CLEAR_GUEST
as
DELETE FROM ADDED_GUEST

CREATE PROCEDURE REMOVE_GUEST
@id int
as
DELETE FROM ADDED_GUEST WHERE GUEST_ID = @id

CREATE TABLE BOOKING(
BOOK_ID int identity(10000,1) primary key,
CHECK_IN DATE not null,
CHECK_OUT DATE not null,
OUT_TIME TIME not null,
STATUS varchar(20),
ROOM_NO varchar(5)
)

CREATE PROCEDURE add_booking
@in date,
@out date,
@time time,
@status varchar(20),
@no varchar(5)
as
INSERT INTO BOOKING VALUES (@in,@out,@time,@status,@no)

CREATE PROCEDURE view_pending
as
SELECT BOOK_ID, CHECK_IN, CHECK_OUT, ROOM_NO FROM BOOKING WHERE STATUS = 'PENDING'

CREATE PROCEDURE view_checked_in
as
SELECT BOOK_ID, CHECK_OUT, ROOM_NO, OUT_TIME FROM BOOKING WHERE STATUS = 'CHECKED-IN'

CREATE PROCEDURE check_in
@id int,
@status varchar(20)
as
UPDATE BOOKING SET STATUS = @status WHERE BOOK_ID = @id

CREATE PROCEDURE check_out
@id int,
@status varchar(20)
as
UPDATE BOOKING SET STATUS = @status WHERE BOOK_ID = @id

CREATE PROCEDURE change_room_status
@id int,
@status varchar(10)
as
UPDATE ROOM SET STATUS = @status WHERE ROOM_ID = @id

CREATE PROCEDURE change_room_status2
@no varchar(5),
@status varchar(10)
as
UPDATE ROOM SET STATUS = @status WHERE ROOM_NO = @no

CREATE TABLE BOOKED_GUEST(
BG_ID int identity(10000,1) primary key,
GUEST_ID int,
BOOK_ID int,
FOREIGN KEY(GUEST_ID) REFERENCES GUEST (GUEST_ID),
FOREIGN KEY(BOOK_ID) REFERENCES BOOKING (BOOK_ID))

CREATE PROCEDURE add_booked_guest
@id1 int,
@id2 int
as
INSERT INTO BOOKED_GUEST VALUES (@id1,@id2)

CREATE PROCEDURE get_BookID
@no varchar(5)
as
SELECT * FROM BOOKING WHERE ROOM_NO = @no

CREATE PROCEDURE cancel_booking
@id int
as
DELETE FROM BOOKING WHERE BOOK_ID = @id

CREATE PROCEDURE cancel_booking2
@id int
as
DELETE FROM BOOKED_GUEST WHERE BOOK_ID = @id

CREATE TABLE INVOICE(
INV_NO int IDENTITY(10000,1) primary key,
NO_OF_DAYS INT not null,
TOTAL INT not null,
INV_DATE DATE not null,
ACC_ID int,
BOOK_ID int,
GUEST_ID int,
FOREIGN KEY(ACC_ID) REFERENCES ACCOUNT (ACC_ID),
FOREIGN KEY(BOOK_ID) REFERENCES BOOKING (BOOK_ID),
FOREIGN KEY(GUEST_ID) REFERENCES GUEST (GUEST_ID))

CREATE PROCEDURE getAccountID
@user varchar(30)
as
SELECT ACC_ID FROM ACCOUNT WHERE USERNAME = @user

CREATE PROCEDURE create_invoice
@days int,
@total int,
@date date,
@accID int,
@bookID int,
@guestID int
as
INSERT INTO INVOICE VALUES (@days,@total,@date,@accID,@bookID,@guestID)

CREATE PROCEDURE delete_invoice
@id int
as
DELETE FROM INVOICE WHERE BOOK_ID = @id

CREATE PROCEDURE update_invoice
@date date,
@bookID int
as
UPDATE INVOICE SET INV_DATE = @date, BOOK_ID = @bookID


CREATE PROCEDURE view_invoice
@id int
as
SELECT NO_OF_DAYS,TOTAL,GUEST_NAME,FIRSTNAME,LASTNAME,ROOM_NO FROM INVOICE
INNER JOIN ACCOUNT ON INVOICE.ACC_ID = ACCOUNT.ACC_ID
INNER JOIN BOOKING ON INVOICE.BOOK_ID = BOOKING.BOOK_ID
INNER JOIN GUEST ON INVOICE.GUEST_ID = GUEST.GUEST_ID
WHERE INVOICE.BOOK_ID = @id

