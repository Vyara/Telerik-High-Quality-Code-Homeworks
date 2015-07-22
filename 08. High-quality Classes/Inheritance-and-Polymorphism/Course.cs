namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<string>();
        }

        public Course(string name, string teacherName)
            : this(name)
        {
            this.TeacherName = teacherName;
        }

        public Course(string name, string teacherName, IList<string> students)
            : this(name, teacherName)
        {
            this.students = new List<string>(students);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

             set
            {
                Validator.StringValidator.CheckIfStringIsNullOrEmpty(value, "Name cannot be null or empty.");
                Validator.StringValidator.CheckIfStringIsNullOrWhiteSpace(value, "Name cannot be null or a white space character.");

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

             set
            {
                Validator.StringValidator.CheckIfStringIsNullOrEmpty(value, "Teacher name cannot be null or empty.");
                Validator.StringValidator.CheckIfStringIsNullOrWhiteSpace(value, "Teacher name cannot be null or a white space character.");

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return new List<string>(this.students);
            }

            set
            {
                if (value != null)
                {
                    foreach (var student in this.students)
                    {
                        this.Students.Add(student);
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} {{ Name = {1}", this.GetType().Name, this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
