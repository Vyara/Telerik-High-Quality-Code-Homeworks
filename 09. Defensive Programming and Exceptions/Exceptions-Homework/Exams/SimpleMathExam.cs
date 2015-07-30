namespace Exceptions_Homework
{
    using System;

    public class SimpleMathExam : Exam
    {
        private const int MinProblemsSolved = 0;
        private const int MaxProblemsSolved = 10;
        private const string ExcelentResultsComment = "Excellent result: absolutely everything's done correctly.";
        private const string GoodResultsComment = "Good result: almost everything's done correctly.";
        private const string AverageResultsComment = "Average result: almost nothing done.";
        private const string BadResultsComment = "Bad result: nothing done.";
        private const int BadGradeMaxSolvedProblems = 2;
        private const int AverageGradeMaxSolvedProblems = 5;
        private const int GoodGradeMaxSolvedProblems = 8;
        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                if (this.problemsSolved < MinProblemsSolved)
                {
                    return MinProblemsSolved;
                }
                else if (this.problemsSolved > MaxProblemsSolved)
                {
                    return MaxProblemsSolved;
                }
                else
                {
                    return this.problemsSolved;
                }
            }

           private set
            {
                this.problemsSolved = value;
            }
        }

        public override ExamResult Check()
        {
            string comment;

            if (this.ProblemsSolved <= BadGradeMaxSolvedProblems)
            {
                comment = BadResultsComment;
            }
            else if (this.ProblemsSolved <= AverageGradeMaxSolvedProblems)
            {
                comment = AverageResultsComment;
            }
            else if (this.ProblemsSolved <= GoodGradeMaxSolvedProblems)
            {
                comment = GoodResultsComment;
            }
            else
            {
                comment = ExcelentResultsComment;
            }

            return new ExamResult(this.ProblemsSolved, SimpleMathExam.MinProblemsSolved, SimpleMathExam.MaxProblemsSolved, comment);
        }
    }
}