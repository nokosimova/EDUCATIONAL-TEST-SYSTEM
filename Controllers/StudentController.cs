using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestSystem.Models;
using TestSystem.Db;

namespace Project.Controllers
{
    public class StudentController: Controller
    {
        DataContext data { get; set; }      

        public StudentController(DataContext context)
        {
            data = context;
        }
        [HttpGet]
        public IActionResult Index(int? StudentId)
        {          
            if (data.Students.Find(StudentId) != null) 
                return View(data.Students.Find(StudentId));
            return RedirectToAction("Error", new{error = "Пользователь не найден"});
        }
        public IActionResult TestList(int? StudentId)
        {
            Subject allSubject = new Subject{SubjectId = 0, SubjectName = "Все предметы"};
            Student studet = data.Students.Find(StudentId);
            List<Subject> subjects = data.Subjects.Where(i => i.IdCourse == studet.IdCourse
                                                         && i.IdFaculty ==studet.IdFaculty).ToList();
            subjects.Insert(0, allSubject);
            if (studet == null) return RedirectToAction("Error", new{error = "Что-то пошло не так"});
            CourseFacultySubject model = new CourseFacultySubject{
                Subjects = subjects,
                student = studet,
                Tests = data.Tests//.Where(i => data.Courses.Find(i.IdSubject).CourseId == studet.IdCourse).ToList()
                                  //            && data.Subjects.Find(i.IdSubject).IdFaculty ==student.IdFaculty)
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult TestList(int? StudentId, int? SubjectId)
        {
            Student student = data.Students.Find(StudentId);
            Subject allSubject = new Subject{SubjectId = 0, SubjectName = "Все предметы"};
            List<Subject> subjects = data.Subjects.Where(i => i.IdCourse == student.IdCourse
                                                         && i.IdFaculty ==student.IdFaculty).ToList();
            subjects.Insert(0, allSubject);
            if (student == null) return RedirectToAction("Error", new{error = "Что-то пошло не так"});
            CourseFacultySubject model = new CourseFacultySubject{
                Subjects = subjects,
                student = student,
                Tests = (SubjectId != 0)?data.Tests.Where(i => i.IdSubject == SubjectId):
                                         data.Tests};
            return View(model);
        }
    // методы для прохождения студентом тестов
    public IActionResult StartTestPage(int? TestId, int? StudentId)
    {
        Test test = data.Tests.Find(TestId);
        Student student = data.Students.Find(StudentId);
        if (test == null) 
            return RedirectToAction("Error", new{error = "ТЕСТ не найден!"});
        TakeTestHelper model = new TakeTestHelper{
            student = student,
            test = test,
            QuestionAccount = data.Questions.Where(i => i.IdTest == test.TestId).Count(),
            ResultPoint = data.Questions.Where(i => i.IdTest == test.TestId).Sum(i => i.Point)
        };
        return View(model);
    }
    
    [HttpGet]

    public IActionResult Question(int? TestId, int? StudentId, int QuestionOrder)
    {
        Test test = data.Tests.Find(TestId);
        Student student = data.Students.Find(StudentId);
        List<Question> questions = data.Questions.Where(i => i.IdTest == TestId).ToList();
        List<QuestionWithAns> questionWithAnsList = new List<QuestionWithAns>();
        List<Answer> answers = new List<Answer>();
        int QuestionAccount = data.Questions.Where(i => i.IdTest == test.TestId).Count();
        if (QuestionOrder < 0) QuestionOrder = 0;
        if (QuestionOrder == QuestionAccount) // когда ответили на последний вопрос теста
        {  
             return RedirectToAction("TestResults", new {
                TestId = TestId,
                StudentId = StudentId
            });
        }
        Question currectQuestion = data.Questions.Where(i => i.IdTest == test.TestId)
                                                 .OrderBy(i => i.QuestionId).ToList()[QuestionOrder];
        if (currectQuestion == null) 
            return RedirectToAction("Error", new{error = "Вопрос не найден!"});
        answers = data.Answers.Where(i => i.IdQuestion == currectQuestion.QuestionId)
                                      .OrderBy(i=>i.IsRightAnswer).ToList();
        List<int> ordr = randOrdr();
        QuestionWithAns questionWithAns= new QuestionWithAns{
                    question = currectQuestion,                    
                    wrgAns1 = answers[ordr[0]],
                    wrgAns2 = answers[ordr[1]],
                    wrgAns3 = answers[ordr[2]],
                    corrAns = answers[ordr[3]],
                };
        TakeTestHelper model = new TakeTestHelper{
            QuestWithAns = questionWithAns,
            student = student,
            test = test,
            QuestionAccount = data.Questions.Where(i => i.IdTest == test.TestId).Count(),
            QuestionOrder = QuestionOrder
        };
        return View(model);
    }
    [HttpPost]
    public IActionResult Question(int AnswerId, int StudentId, int QuestionId, int QuestionOrder)
    {
        if (!ModelState.IsValid) return RedirectToAction("Error", new{error = "Ответ не дошел!"});
        AnsQuestion studentAns = new AnsQuestion{
            IdAnswer = AnswerId,
            IdQuestion = QuestionId,
            IdStudent = StudentId
        };
        AnsQuestion ans = data.AnsQuestions.FirstOrDefault(i =>
                             i.IdStudent == StudentId && i.IdQuestion == QuestionId);
        if (ans == null)
            data.AnsQuestions.Add(studentAns);
        else
            data.AnsQuestions.Find(ans.AnsQuestionId).IdAnswer = AnswerId;
        data.SaveChanges();
        int TestId = data.Questions.Find(QuestionId).IdTest;
        return RedirectToAction("Question", new{
            TestId = TestId,
            StudentId = StudentId,
            QuestionOrder = QuestionOrder
        });
    }
    public IActionResult TestResults(int TestId, int StudentId)
    {
        Test test = data.Tests.Find(TestId);
        Student student = data.Students.Find(StudentId);
        List<Question> questions = data.Questions.Where(i => i.IdTest == TestId).ToList();
        List<QuestionWithAns> questionWithAnsList = new List<QuestionWithAns>();
        List<Answer> answers = new List<Answer>();         
        int PointSum = 0;
        foreach(var item in questions)
            {
                answers = data.Answers.Where(i => i.IdQuestion == item.QuestionId)
                                      .OrderBy(i=>i.IsRightAnswer).ToList();
                AnsQuestion studAns =  data.AnsQuestions.FirstOrDefault(i => i.IdQuestion == item.QuestionId &&
                                                                i.IdStudent == StudentId);
                QuestionWithAns questionWithAnss= new QuestionWithAns{
                    question = item,                    
                    wrgAns1 = answers[0],
                    wrgAns2 = answers[1],
                    wrgAns3 = answers[2],
                    corrAns = answers[3],
                    studAnsId = studAns.IdAnswer,
                    test = test
                };

                if (questionWithAnss.studAnsId == questionWithAnss.corrAns.AnswerId)
                    PointSum = PointSum + questionWithAnss.question.Point;
                questionWithAnsList.Add(questionWithAnss);
            }
            TakeTestHelper modell = new TakeTestHelper{
                AllQuestionsWithAns = questionWithAnsList,
                MaxPoint = data.Questions.Where(i => i.IdTest == test.TestId).Sum(i => i.Point),
                ResultPoint = PointSum,
                student = student,
                test = test};
           
        return View(modell);
         //return RedirectToAction("Error", new{error = PointSum.ToString() + " из " + modell.MaxPoint.ToString()});
   }
    public static List<int> randOrdr()
    {
        List<int> data = new List<int>{0,1,2,3};
       Random random = new Random();
	    for (int i = data.Count - 1; i >= 1; i--)
        {
   		    int j = random.Next(i + 1);
   		    // обменять значения data[j] и data[i]
   		    var temp = data[j];
   		    data[j] = data[i];
   		    data[i] = temp;
	    }
        return data;
    }
    public string Error(string error)
        {
            return $"ERROR MESSAGE:{error} ";
        }
    }
}