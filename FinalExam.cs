using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class FinalExam : Exam, ICloneable
    {
        public override ExamType Type { get; set; } = ExamType.FinalExam;

        public FinalExam(int _time, int _numberOfQuestions):base(_time, _numberOfQuestions)
        {
            Answers = new Answers[_numberOfQuestions];
        }

        public override void ShowExam()
        {
            base.ShowExam();
            ShowExamResult();

        }

        public void ShowExamResult()
        {
            Console.WriteLine("The Right Answers :");
            double grade = 0;

            for (int i = 0; i < Questions?.Length; i++)
            {
                if (Questions[i].GetType().Name == "MCQQuestions")
                {
                    string answer = "";
                    string[] Arr = Questions[i].RightAnswer.AnswerText.Split(","); // 

                    for (int j = 0; j < Arr?.Length; j++)
                    {
                        if (Arr[j] == Questions[i].AnswersList[j].AnswerText)
                        {
                            answer += Questions[i].AnswersList[j].AnswerText + " ";
                        }

                    }
                    Console.WriteLine($"Question {i + 1} {Questions[i].Body} : {answer}");
                }
                else
                {
                    Console.WriteLine($"Question {i + 1} {Questions[i].Body} : {Questions[i].RightAnswer.AnswerText}");
                }

                if (Answers[i].AnswerText == Questions[i].RightAnswer.AnswerText)
                {
                    grade += Questions[i].Marks;
                }
                
            }
            Console.WriteLine($"Your Grade is {grade} from {ExamGrade}");
        }

        public object Clone()
        {
            return new FinalExam(Time, NumberOfQuestions);
        }
    }
}
