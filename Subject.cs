using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class Subject
    {
        private string name;
        private int id;
        private Exam subjectExam;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Exam SubjectExam
        {
            get { return subjectExam; }
            set
            {
                subjectExam = value;
            }
        }

        public Subject(string _name,int _id,Exam _subjectExam)
        {
            id = _id;
            name = _name;
            subjectExam = _subjectExam;
        }

        public Subject(int _id, string _name):this(_name, _id,new PracticalExam(60, 3))
        {

        }

        public override string ToString()
        {
            return $"Subject Name {Name}\nSubject Id {Id}\nExam Type {subjectExam}";
        }

        public void CreateExam()
        {
            int time, type;

            do
            {
                Console.WriteLine("Please choose the type of the EXam [1 for Practical, 2 for Final]");
            } while (!int.TryParse(Console.ReadLine(), out type) || type < 1 || type > 2);

            subjectExam.Type = (ExamType)type;

            do
            {
                Console.WriteLine("Please Enter the time of the EXam in minutes :");
            } while (!int.TryParse(Console.ReadLine(), out time) || time < 60 || time > 180);

            subjectExam.Time = time;

            Console.WriteLine("please enter number of Questions:");
            int numberOfQuestions = int.Parse(Console.ReadLine());

            if(subjectExam.Type == ExamType.PracticalExam)
            {
                subjectExam = new PracticalExam(time, numberOfQuestions);
                subjectExam.Questions = QuestionBase.CreateBaseQuestion(numberOfQuestions);
            }else
            {
                subjectExam = new FinalExam(time, numberOfQuestions);
                subjectExam.Questions = QuestionBase.CreateBaseQuestion(numberOfQuestions);
            }

            for (int i = 0; i < subjectExam.Questions?.Length; i++)
            {
                subjectExam.ExamGrade += subjectExam.Questions[i].Marks;
            }
        }
    }
}
