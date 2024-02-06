using ExaminationSystem;
using System.Diagnostics;

Subject subject = new Subject(1, "C#");
subject.CreateExam();
Console.Clear();

Console.WriteLine("Do You Want to take the exam now ?(Y | N)");

if(char.Parse(Console.ReadLine()) == 'Y')
{
    Stopwatch s = new Stopwatch();
    s.Start();
    subject.SubjectExam.ShowExam();
    s.Stop();
    Console.WriteLine($"the Elapsed Time = {s.Elapsed}");
}