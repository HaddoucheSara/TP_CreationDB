-- SeedData.sql
USE TP_CreationDB;
GO

-- Insertion dans la table Subjects
INSERT INTO Subjects (Name, Description)
VALUES
('Mathématiques', 'Mathématiques de base'),
('Physique', 'Introduction à la physique'),
('Informatique', 'Programmation et structures de données');           

-- Insertion dans la table Persons (enseignants)
INSERT INTO Persons (FirstName, LastName, PersonType, HireDate, SubjectId)
VALUES
('John', 'Doe', 'Teacher', '2015-08-15', 1),  
('Jane', 'Smith', 'Teacher', '2018-01-10', 2),
('Alice', 'Johnson', 'Teacher', '2020-03-21', 3);

-- Insertion dans la table Persons (étudiants)
INSERT INTO Persons (FirstName, LastName, PersonType, StudentNumber)
VALUES
('Michael', 'Brown', 'Student', 1001),
('Sarah', 'Davis', 'Student', 1002),
('David', 'Wilson', 'Student', 1003),
('Emily', 'Martinez', 'Student', 1004);

-- Insertion dans la table Classes
INSERT INTO Classes (Name, Level, TeacherId)
VALUES
('Algebra 101', 'Beginner', 1),
('Classical Mechanics', 'Intermediate', 2),
('Introduction to Programming', 'Beginner', 3);

-- Insertion dans la table Enrollments
INSERT INTO Enrollments (StudentId, ClassId, EnrollmentDate)
VALUES
(1, 1, '2024-02-01'),
(2, 1, '2024-02-02'),
(3, 2, '2024-03-15'),
(4, 3, '2024-04-10');
