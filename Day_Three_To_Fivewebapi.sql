USE master;

CREATE TABLE student
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	indexNumber CHAR(5) UNIQUE,
	course VARCHAR(200)
);

CREATE TABLE person
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	firstName VARCHAR(30),
	lastName VARCHAR(30),
	oib CHAR(11) UNIQUE,
	placeOfResidence VARCHAR(11),
	dateOfBirth DATE NOT NULL,
	studentId INT FOREIGN KEY REFERENCES student(id) ON DELETE CASCADE
);


INSERT INTO student (indexNumber, course) VALUES ('05623','Racunarstvo');
INSERT INTO student (indexNumber, course) VALUES ('87652','Elektrotehnika');
INSERT INTO student (indexNumber, course) VALUES ('84622','Komunikacije');
INSERT INTO student (indexNumber, course) VALUES ('25112','Racunarstvo');
INSERT INTO student (indexNumber, course) VALUES ('08623','Komunikacije');


INSERT INTO person (firstName, lastName, oib, placeOfResidence, dateofBirth, studentId) VALUES ('Antun', 'Antunovic', '74926401992', 'Osijek', '2000-11-10', 1);
INSERT INTO person (firstName, lastName, oib, placeOfResidence, dateofBirth, studentId) VALUES ('Leon', 'Leonkovic', '75820864271', 'Vukovar', '1999-08-09', 2);
INSERT INTO person (firstName, lastName, oib, placeOfResidence, dateofBirth, studentId) VALUES ('Ivan', 'Ivic', '49282612344', 'Vinkovci', '1997-05-18', 3);
INSERT INTO person (firstName, lastName, oib, placeOfResidence, dateofBirth, studentId) VALUES ('Stefan', 'Stefanovic', '00982635253', 'Osijek', '2022-01-07', 4);
INSERT INTO person (firstName, lastName, oib, placeOfResidence, dateofBirth, studentId) VALUES ('Anamarija', 'Maric', '23323145995', 'Zagreb', '2001-06-10', 5);


SELECT * FROM person;
SELECT * FROM student;


DELETE FROM person;
DELETE FROM student;
