namespace School.Test
{
    using System;
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void StudentShouldNotThrowAnException()
        {
            var student = new Student("Jane Dow", 10000);
        }

        [TestMethod]
        public void StudentShouldReturnExpectedName()
        {
            var student = new Student("Jane Dow", 10000);

            Assert.AreEqual("Jane Dow", student.Name);
        }

        [TestMethod]
        public void StudentShouldReturnExpectedId()
        {
            var student = new Student("Jane Dow", 10000);

            Assert.AreEqual(10000, student.UniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldThrowNullReferenceExceptionForNullName()
        {
            var student = new Student(null, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldThrowNullReferenceExceptionForEmptyName()
        {
            var student = new Student(string.Empty, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void StudentShouldThrowArgumentExceptionForInvalidUNumber_LowerBoundary()
        {
            var student = new Student("Jane Dow", 100);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void StudentShouldThrowArgumentExceptionForInvalidUNumber_UpperBoundary()
        {
            var student = new Student("Jane Dow", 1000000);
        }

        [TestMethod]
        public void StudentShouldNotThrowExceptionWhenAttendingCourse()
        {
            var student = new Student("Jane Dow", 10000);
            var course = new Course("Test Course");
            student.JoinCourse(course);
        }

        [TestMethod]
        public void StudentShouldNotThrowExceptionWhenLeavesCourse()
        {
            var student = new Student("Jane Dow", 10000);
            var course = new Course("Test Course");
            student.JoinCourse(course);
            student.LeaveCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldThrowExceptionWhenAttendingNullCourse()
        {
            var student = new Student("Jane Dow", 10000);
            Course course = null;
            student.JoinCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldThrowExceptionWhenLeavingNullCourse()
        {
            var student = new Student("Jane Dow", 10000);
            Course course = null;
            student.LeaveCourse(course);
        }
    }
}
