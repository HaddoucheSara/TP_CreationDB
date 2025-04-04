-- SeedData.sql
USE TP_CreationDB;
GO
----Creation de  Vue SQL : V_Teacher_Subject
CREATE VIEW V_Teacher_Subject AS
SELECT 
    p.Id AS TeacherId, 
  p.FirstName AS TeacherFirstName, 
  p.LastName AS TeacherLastName, 
   s.Name AS SubjectName
FROM Persons p
INNER JOIN Subjects s ON p.SubjectId = s.ID
WHERE p.PersonType = 'Teacher';

--Cr�ation de la Proc�dure Stock�e GetStudentByStudentNumber
GO

CREATE PROCEDURE GetStudentByStudentNumber
  @StudentNumber INT
AS
BEGIN
  SET NOCOUNT ON;

   SELECT * 
    FROM Persons
   WHERE PersonType = 'Student' 
      AND StudentNumber = @StudentNumber;
END;



-- Insertion dans la table Subjects
INSERT INTO Subjects (Name, Description)
VALUES
('Math�matiques', 'Math�matiques de base'),
('Physique', 'Introduction � la physique'),
('Informatique', 'Programmation et structures de donn�es');           

-- Insertion dans la table Persons (enseignants)
INSERT INTO Persons (FirstName, LastName, PersonType, HireDate, SubjectId)
VALUES
('John', 'Doe', 'Teacher', '2015-08-15', 1),  
('Jane', 'Smith', 'Teacher', '2018-01-10', 2),
('Alice', 'Johnson', 'Teacher', '2020-03-21', 3);

-- Insertion dans la table Persons (�tudiants)
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
