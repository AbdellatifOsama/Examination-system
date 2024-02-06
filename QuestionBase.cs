using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public abstract class QuestionBase
    {
        protected string body;
        protected double marks;
        Answers[] answersList;
        private Answers rightAnswer;
        public abstract string Header { get; } 

        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        public double Marks
        {
            get { return marks; }
            set { marks = value; }
        }

        public Answers RightAnswer
        {
            get { return rightAnswer; }
            set { rightAnswer = value; }
        }

        public Answers[] AnswersList
        {
            get { return answersList; }
            set { answersList = value; }
        }

        public Answers this[int id]
        {
            get
            {
                for (int i = 0; i < answersList?.Length; i++)
                {
                    if (answersList[i].AnswerId == id)
                    {
                        return answersList[i];
                    }
                }
                return new Answers();
            }
        }

        public Answers this[string text]
        {
            get
            {
                for (int i = 0; i < answersList?.Length; i++)
                {
                    if (answersList[i].AnswerText == text)
                    {
                        return answersList[i];
                    }
                }
                return new Answers();
            }
        }

        public QuestionBase( string _body, double _marks)
        {
            body = _body;
            marks = _marks;
        }

        public static QuestionBase[] CreateBaseQuestion(int size)
        {
            QuestionBase[] questions = new QuestionBase[size];

            for (int i = 0; i < questions?.Length; i++)
            {
                int questionType;
                do
                {
                    Console.WriteLine($"Please Choose the type of the question Number{i} [1 for T/F Question, 2 for Choose one Question, 3 for MCQ]");
                } while (!int.TryParse(Console.ReadLine(), out questionType) || questionType < 1 || questionType > 3);

                if(questionType == 1)
                {
                    Console.WriteLine($"The data of True Or False Question Number {i + 1}");
                    questions[i] = TFQuestions.AddTFQuestion();
                }
                else if(questionType == 2)
                {
                    Console.WriteLine($"The data of Choose One Question Number {i + 1}");
                    questions[i] = ChooseOneQuestion.AddChooseOneQuestion();
                }
                else if (questionType == 3)
                {
                    Console.WriteLine($"The data of MCQ Question Number {i + 1}");
                    questions[i] = MCQQuestions.AddMCQQuestions();
                }


            }

            return questions;
        }
    }
}
