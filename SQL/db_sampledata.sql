CREATE TABLE Students (
    StudentId INT PRIMARY KEY,
    SchoolName NVARCHAR(64),
    StudentName NVARCHAR(64)
);

CREATE TABLE Absence (
    StudentId INT FOREIGN KEY REFERENCES Students(StudentId),
    AbsenceLength INT
);

CREATE INDEX IX_Students_SchoolName ON Students(SchoolName);
CREATE INDEX IX_Absence_StudentId ON Absence(StudentId);

INSERT INTO Students(StudentId, SchoolName, StudentName) VALUES
(124, 'Testskolan', 'Fredrik Svensson'),
(212, 'Gymnasieskolan', 'Sven Fredriksson'),
(555, 'Grundskolan', 'Karin Andersson'),
(701, 'Specialskolan', 'Anders Andersson'),
(232, 'Trevliga skolan', 'Lars Larsson'),
(129, 'Testskolan', 'Martin Olsson'),
(332, 'Testskolan', 'Klara Olofsson');

INSERT INTO Absence(StudentId, AbsenceLength) VALUES
(124, 0),
(212, 25),
(555, 60),
(701, 20),
(232, 15),
(129, 20),
(332, 15);

GO 
CREATE PROCEDURE SP_CalculateTotalAbsenceForSchool
(
    @SchoolName NVARCHAR(64)
)
AS 
BEGIN
SET NOCOUNT ON;
SELECT SUM(absence.AbsenceLength) AS TotalAbsence 
FROM Absence absence 
JOIN Students students ON absence.StudentId = students.StudentId
WHERE students.SchoolName = @SchoolName
END;
