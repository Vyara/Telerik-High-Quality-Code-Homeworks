namespace Exceptions_Homework
{
    using System;

    public class CSharpExam : Exam
    {
        private const int MinGrade = 0;
        private const int MaxGrade = 100;
        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

           private set
            {
                if (value < CSharpExam.MinGrade || value > CSharpExam.MaxGrade)
                {
                    throw new ArgumentException(string.Format("The score must be between {0} and {1}.", MinGrade, MaxGrade));
                }

                this.score = value;
            }
        }

        public override ExamResult Check()
        {
            if (this.Score < 0 || this.Score > 100)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
            }
        }
    }
}