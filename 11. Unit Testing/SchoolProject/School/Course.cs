namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxStudentsCount = 29;
        private string name;
        private ICollection<Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.StringValidator.CheckIfStringIsNullOrEmpty(value, "Course name cannot be null or empty.");
                Validator.StringValidator.CheckIfStringIsNullOrWhiteSpace(value, "Course name cannot be null or white space.");

                this.name = value;
            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public void AddStudent(Student student)
        {
            Validator.ObjectValidator.CheckIfNull(student, "Course student cannot be null");
            Validator.NumberValidator.CheckIfNumberIsInRange(this.Students.Count + 1, 0, MaxStudentsCount, "Course students should be in range from 0 to 29");

            if (this.students.Contains(student))
            {
                throw new InvalidOperationException("This student is already attending this course");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Validator.ObjectValidator.CheckIfNull(student, "Course student cannot be null");
            if (!this.students.Contains(student))
            {
                throw new InvalidOperationException("The student does not attend this class.");
            }

            this.students.Remove(student);
        }
    }
}
