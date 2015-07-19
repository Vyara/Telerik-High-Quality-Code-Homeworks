namespace Methods
{
    using System;

    public class Student
    {
        public Student(string firstName, string lastName, DateTime birthDate, string city, string additionalNotes = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.City = city;
            this.AdditionalNotes = additionalNotes;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string City { get; set; }

        public string AdditionalNotes { get; set; }

        public bool IsOlderThan(Student other)
        {
            return this.BirthDate < other.BirthDate;
        }
    }
}
