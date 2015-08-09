namespace School.Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CreatingNewCourseWithValidNameShouldNotThrowAnError()
        {
            var course = new Course("Test Course");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseShouldThrowExceptionIfNameIsNull()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseShouldThrowExceptionIfNameIsEmpty()
        {
            var course = new Course(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseShouldThrowExceptionIfNameIsWhiteSpace()
        {
            var course = new Course("    ");
        }

        [TestMethod]
        public void CourseShoulReturnCorrectName()
        {
            var course = new Course("Test course");
            Assert.AreEqual("Test course", course.Name);
        }
        
        [TestMethod]
        public void CourseShouldAddStudentCorrectly()
        {
            var course = new Course("Test Course");
            var student = new Student("Jane Dow", 10011);
            course.AddStudent(student);

            Assert.AreSame(student, course.Students.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseShouldThrowExceptionWhenNullStudentAdded()
        {
            var course = new Course("Test Course");
            Student student = null;
            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowExceptionWhenExistingStudentAdded()
        {
            var course = new Course("Test Course");
            Student student = new Student("Jane Dow", 10000); 
            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CourseShouldThrowExceptionWhenMoreThanPossibleStudentsAdded()
        {
            var course = new Course("Test Course");

            for (int i = 0; i < 30; i++)
            {
                course.AddStudent(new Student(i.ToString(), 10000 + 1));
            }
        }

        [TestMethod]
        public void CourseShouldRemoveStudentCorrectly()
        {
            var course = new Course("Test Course");
            var student = new Student("Jane Dow", 99999);
            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseShouldThrowExceptionWhenRemovingNullStudent()
        {
            var course = new Course("Test Course");
            Student student = null;
            course.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowExceptionWhenRemovingUnexistingStudent()
        {
            var course = new Course("Test Course");
            Student student = new Student("Jane Dow", 10000);
            course.RemoveStudent(student);
        }
    }
}
