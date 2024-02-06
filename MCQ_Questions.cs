using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class MCQQuestions : QuestionBase, ICloneable
    {
        public override string Header { get; } = "Choose Multi Question";

        public MCQQuestions(string _body = "", double _marks = 0) : base(_body, _marks)
        {
            AnswersList = new Answers[3];
        }

        public override string ToString()
        {
            return $"{Header}      Marks({Marks}) \n{Body}\n" +
                   $"A. {AnswersList[0].AnswerText}\t\t B. {AnswersList[1].AnswerText}\t\t C. {AnswersList[2].AnswerText}";
        } 
        // ali,ahmed
        public static MCQQuestions AddMCQQuestions()
        {
            MCQQuestions question = new MCQQuestions();
            Console.WriteLine(question.Header);

            Console.WriteLine("Please Enter the body of the question:");
            question.Body = Console.ReadLine();

            Console.WriteLine("Please Enter the marks of the question:");
            question.Marks = double.Parse(Console.ReadLine());

            Console.WriteLine("The Choices Of the question");

            for (int i = 0; i < question.AnswersList?.Length; i++)
            {
                question.AnswersList[i] = new Answers();
                Console.WriteLine($"Please enter the choice number {i + 1}");
                question.AnswersList[i].AnswerText = Console.ReadLine();
                question.AnswersList[i].AnswerId = i + 1;
            }

            question.RightAnswer = new Answers();
            string answer = "";
            do
            {
                Console.WriteLine($"Please enter the right answer for the question");
                answer = Console.ReadLine();
            } while (!(answer is string));

            question.RightAnswer.AnswerText = answer;


            return question;

        }

        public object Clone()
        {
            return new MCQQuestions(body, marks);
        }
    }
}
