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
            if (student == null) return RedirectToAction("Error", new{error = "Что-то пошло не так"});
            CourseFacultySubject model = new CourseFacultySubject{
                Subjects = data.Subjects.Where(i => i.IdCourse == student.IdCourse 
                                               && i.IdFaculty == student.IdFaculty),
                student = student,
                Tests = data.Tests.Where(i => i.IdSubject == SubjectId)};
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
            QuestionAmmount = data.Questions.Where(i => i.IdTest == test.TestId).Count(),
            ResultPoint = data.Questions.Where(i => i.IdTest == test.TestId).Sum(i => i.Point)
        };
        return View(model);
    }
    
    [HttpGet]
    public IActionResult Question(int? TestId, int? StudentId, int QuestionOrder)
    {
        Test test = data.Tests.Find(TestId);
        Student student = data.Students.Find(StudentId);
        if (QuestionOrder < 0) QuestionOrder = 0;
        Question currectQuestion = data.Questions.Where(i => i.IdTest == test.TestId)
                                                 .OrderBy(i => i.QuestionId).ToList()[QuestionOrder];
        if (currectQuestion == null) 
            return RedirectToAction("Error", new{error = "Вопрос не найден!"});
        List<Answer> answers = data.Answers.Where(i => i.IdQuestion == currectQuestion.QuestionId)
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
            QuestionAmmount = data.Questions.Where(i => i.IdTest == test.TestId).Count(),
            QuestionOrder = QuestionOrder
        };
        return View(model);
    }
    public static List<int> randOrdr()
    {
        List<int> list = new List<int>();
        Random rand = new Random();
        for (int i = 0; i < 4; i++)
            list.Add(rand.Next(0,3));
        return list;
    }
    public string Error(string error)
        {
            return $"ERROR MESSAGE:{error} ";
        }
    }
}