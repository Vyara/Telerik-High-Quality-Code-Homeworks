namespace School
{
    public class Student
    {
        private const int MinUniqueNumberValue = 10000;
        private const int MaxUniqueNumberValue = 99999;
        private string name;
        private int uniqueNumber;

        public Student(string name, int uniqueNumber)
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.StringValidator.CheckIfStringIsNullOrEmpty(value, "Student name cannot be null or empty.");
                Validator.StringValidator.CheckIfStringIsNullOrWhiteSpace(value, "Student name cannot be null or white space.");

                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }

            private set
            {
                Validator.NumberValidator.CheckIfNumberIsInRange(value, MinUniqueNumberValue, MaxUniqueNumberValue, "Student unique number must be between 10000 and 99999");

                this.uniqueNumber = value;
            }
        }

        public void JoinCourse(Course course)
        {
            Validator.ObjectValidator.CheckIfNull(course, "Student's course cannot be null");
            course.AddStudent(this);
        }

        public void LeaveCourse(Course course)
        {
            Validator.ObjectValidator.CheckIfNull(course, "Student's course cannot be null");

            course.RemoveStudent(this);
        }
    }
}
