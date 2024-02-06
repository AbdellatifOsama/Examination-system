using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public enum ExamType { PracticalExam = 1, FinalExam = 2}
    public abstract class Exam
    {
        private int time;
        private int numberOfQuestions;
        private double examGrade;
        QuestionBase[] questions;
        Answers[] answers;

        public abstract ExamType Type { get; set; }

        public int Time
        {
            get { return time; }
            set { time = value; }
        }

        public int NumberOfQuestions
        {
            get { return numberOfQuestions; }
            set { numberOfQuestions = value; }
        }

        public double ExamGrade
        {
            get { return examGrade; }
            set { examGrade = value; }
        }

        public QuestionBase[] Questions
        {
            get { return questions; }
            set { questions = value; }
        }

        public Answers[] Answers
        {
            get { return answers; }
            set { answers = value; }
        }


        public Exam(int _time, int _numberOfQuestions)
        {
            time = _time;
            numberOfQuestions = _numberOfQuestions;
            ExamGrade = 0;
            questions = new QuestionBase[_numberOfQuestions];
            answers = new Answers[_numberOfQuestions];
        }


        public virtual void ShowExam()
        {
            for (int i = 0; i < questions?.Length; i++)
            {
                Console.WriteLine(questions[i]);
                Console.WriteLine("=========================");

                int id;
                string answer = "";

                answers[i] = new Answers();

                if (questions[i].GetType().Name == "MCQQuestions")
                {
                    do
                    {
                        answer = Console.ReadLine();
                    } while (!(answer is string));

                    answers[i].AnswerText = answer;
                }else
                {
                    do
                    {

                    } while (!int.TryParse(Console.ReadLine(), out id));

                    answers[i].AnswerId = id;

                    for (int j = 0; j < questions[i].AnswersList?.Length; j++)
                    {
                        if (questions[i].AnswersList[j].AnswerId == id)
                            answers[i].AnswerText = questions[i].AnswersList[j].AnswerText;
                    }
                }

                Console.WriteLine("========================");



            }
        }


 
            
    }
}
