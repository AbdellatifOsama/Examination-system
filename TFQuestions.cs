using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class TFQuestions : QuestionBase
    {
        public override string Header { get; } = "True Or False Question";

        public TFQuestions(string _body = "", double _marks = 0 ):base(_body,_marks)
        {
            AnswersList = new Answers[2];
            AnswersList[0] = new Answers("True", 1);
            AnswersList[1] = new Answers("False", 2);
        }

        public override string ToString()
        {
            return $"{Header}      Marks({Marks}) \n{Body}\n" + 
                   $"1. {AnswersList[0].AnswerText}\t\t 2. {AnswersList[1].AnswerText}";
        }

        public static TFQuestions AddTFQuestion()
        {
            TFQuestions question = new TFQuestions();
            Console.WriteLine(question.Header);

            Console.WriteLine("Please Enter the body of the question:");
            question.Body = Console.ReadLine();

            Console.WriteLine("Please Enter the marks of the question:");
            question.Marks = double.Parse(Console.ReadLine());

            question.RightAnswer = new Answers();
            int id;
            do
            {
                Console.WriteLine($"Please enter the right answer for the question [ 1 for True , 2 for False]");
            } while (!int.TryParse(Console.ReadLine(), out id) || id < 1 || id > 2);

            question.RightAnswer.AnswerId = id;
            question.RightAnswer.AnswerText = question[id].AnswerText;


            return question;

        }
    }
}
