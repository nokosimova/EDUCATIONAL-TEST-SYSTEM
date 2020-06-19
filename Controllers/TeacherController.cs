using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestSystem.Models;
using TestSystem.Db;
using TestSystem.Controllers;


namespace Project.Controllers
{
    public class TeacherController: Controller
    {
        DataContext data { get; set; }     

        public TeacherController(DataContext context)
        {
            data = context;
        }
        
        [HttpGet]
        public IActionResult Index(int TeacherId)
        {  
            if (data.Teachers.Find(TeacherId) != null) 
                return View(data.Teachers.Find(TeacherId));
            return RedirectToAction("Error", new{error = "Пользователь не найден"});
        }

        //создание нового теста
        [HttpGet]
        public IActionResult CreateTest(int TeacherId)
        {

            if (TeacherId > 0)
            {
            CourseFacultySubject model = new
                CourseFacultySubject{
                    Courses = data.Courses,
                    Faculties = data.Faculties,
                    test = new Test{IdTeacher = TeacherId}
                };
               return View(model);
            }
            return RedirectToAction("Error", new{error = "Id не передалось"});
        }
        
        public IActionResult ChooseSubj(int TeacherId, int CourseId, int FacultyId)
        {        
            CourseFacultySubject newmodel = new
                CourseFacultySubject{
                    Subjects = data.Subjects.Where(i=> i.IdFaculty==FacultyId && i.IdCourse==CourseId),
                    test = new Test{
                        IdTeacher = TeacherId
                    }
                };
            return View(newmodel);
        }
     
        [HttpPost]
        public IActionResult ChooseSubj(Test test)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", new{error = "Что-то пошло не так"});
            }
            if (data.Subjects.Find(test.IdSubject) == null)
            {
                ModelState.AddModelError("IdSubject", "На данный момент предметов для создания тестов нет!");               
                return RedirectToAction("CreateTest", new{TeacherId = test.IdTeacher});
            }
            if (data.Tests.FirstOrDefault(i => i.TestName == test.TestName) != null)
            {
                ModelState.AddModelError("TestName", "Тест с таким названием уже есть. Выберите другое!");               
                Subject subj = data.Subjects.Find(test.IdSubject);
                CourseFacultySubject newmodel = new
                CourseFacultySubject{
                    Subjects = data.Subjects.Where(i=> i.IdCourse == subj.IdCourse && i.IdFaculty==subj.IdFaculty),
                    test = new Test{
                        IdTeacher = test.IdTeacher
                    }
                };
                return View(newmodel);
            }
            data.Tests.Add(test);
            data.SaveChanges();
            return RedirectToAction("SuccesMessage", new{TeacherId = test.IdTeacher}); 
        }
        public IActionResult SuccesMessage(int TeacherId)
        {
            return View(data.Teachers.Find(TeacherId));
        }
        //методы для просмотра тестов
        public IActionResult TestList(int TeacherId)
        {
            if (!ModelState.IsValid) return RedirectToAction("Error", new{error = "Что-то пошло не так"});
            Course allCourse = new Course{CourseId = 0, CourseName = "Все курсы"};
            Faculty allFaculty = new Faculty{FacultyId = 0, FacultyName = "Все факультеты"};
            List<Course> courses = data.Courses.ToList();
            List<Faculty> faculties = data.Faculties.ToList();
            courses.Insert(0, allCourse);
            faculties.Insert(0, allFaculty);
            
           TestCreateModel model = new TestCreateModel{
                Courses = courses, 
                Faculties = faculties,
                teacher = new Teacher{TeacherId = TeacherId}  };
                model.Subjects = data.Subjects.ToList();
                model.Tests = data.Tests.Where(i => i.IdTeacher == TeacherId)
                                        .OrderBy(i => i.IdSubject).ToList();
                return View(model);
        }
        [HttpPost]
        public IActionResult TestList(int Idcourse, int Idfaculty, int Idteacher)
        {
            if (Idteacher != 1) return RedirectToAction("Error", new{error = "NO ID in POST"});
            Course allCourse = new Course{CourseId = 0, CourseName = "Все курсы"};
            Faculty allFaculty = new Faculty{FacultyId = 0, FacultyName = "Все факультеты"};
            List<Course> courses = data.Courses.ToList();
            List<Faculty> faculties = data.Faculties.ToList();
            courses.Insert(0, allCourse);
            faculties.Insert(0, allFaculty);
            
           TestCreateModel model = new TestCreateModel{
               Courses = courses, 
               Faculties = faculties,
               teacher = new Teacher{TeacherId = Idteacher}  };
               model.Subjects = data.Subjects.ToList();
               model.Tests = data.Tests.Where(i => i.IdTeacher == Idteacher);
            if (Idcourse > 0)
            {
                model.Subjects = model.Subjects.Where(i => i.IdCourse == Idcourse).ToList();
                model.Tests = model.Tests.Where(i => data.Subjects.Find(i.IdSubject).IdCourse == Idcourse)
                                        .OrderBy(i => i.IdSubject).ToList();
            }
            if (Idfaculty > 0)
            {
                model.Subjects = model.Subjects.Where(i => i.IdFaculty == Idfaculty).ToList();
                model.Tests = model.Tests.Where(i => data.Subjects.Find(i.IdSubject).IdFaculty == Idfaculty)
                                        .OrderBy(i => i.IdSubject).ToList();
            }
            return View(model);
        }
        //метод для удаления тестов
        public IActionResult DeleteTest(int? TestId)
        {
            Test test = data.Tests.Find(TestId);
            if (TestId == null) 
                return RedirectToAction("Error", new{error = "ТЕСТid null!"});
            int teacherId = test.IdTeacher;
            data.Tests.Remove(test);
            data.SaveChanges();
            return RedirectToAction("TestList", new{ TeacherId = teacherId });            
        }    
        //методы для редактирования тестов:
        public IActionResult EditTest(int TestId)
        {
            Test test = data.Tests.Find(TestId);
            if (test == null) 
                return RedirectToAction("Error", new{error = "ТЕСТ не найден!"});
            List<Question> questions = data.Questions.Where(i => i.IdTest == TestId).ToList();
            List<QuestionWithAns> questionWithAnsList = new List<QuestionWithAns>();
            List<Answer> answers = new List<Answer>();
            foreach(var item in questions)
            {
                answers = data.Answers.Where(i => i.IdQuestion == item.QuestionId)
                                      .OrderBy(i=>i.IsRightAnswer).ToList();
                QuestionWithAns questionWithAns= new QuestionWithAns{
                    question = item,                    
                    wrgAns1 = answers[0],
                    wrgAns2 = answers[1],
                    wrgAns3 = answers[2],
                    corrAns = answers[3],
                    test = test
                };
                questionWithAnsList.Add(questionWithAns);
            }
            TestEditModel model = new TestEditModel{
                qaList = questionWithAnsList,
                test = test};
            return View(model);            
        }
        public IActionResult AddQuestion(int TestId)
        {
            Test test = data.Tests.Find(TestId);
            if (test == null)
                return RedirectToAction("Error", new{error = "Что-то пошло не так, вернитесь назад!"});
                QuestionWithAns model = new QuestionWithAns{                    
                    question = new Question(),
                    wrgAns1 = new Answer(),
                    wrgAns2 = new Answer(),
                    wrgAns3 = new Answer(),
                    corrAns = new Answer(),
                    test = data.Tests.Find(TestId)
                };
                return View(model);
        }
        [HttpPost]
        public IActionResult AddQuestion(string QText, int TestId, int Point, string CorrAns, 
                                         string WrgAns1, string WrgAns2, string WrgAns3)
        {
            if (!ModelState.IsValid) 
                 return RedirectToAction("Error", new{error = "Данные не передались!"});
            if (Point < 1 || Point > 5)   
            {
                QuestionWithAns model= new QuestionWithAns{
                    question= new Question{QuestionText = QText} ,                    
                    wrgAns1 = new Answer{AnswerText = WrgAns1},
                    wrgAns2 = new Answer{AnswerText = WrgAns2},
                    wrgAns3 = new Answer{AnswerText = WrgAns3},
                    corrAns = new Answer{AnswerText = CorrAns},
                    test = data.Tests.Find(TestId)
                };
                ModelState.AddModelError("Point", "Выберите балл от 1 до 5!!!");  
                return View(model);
            }          
            Question question = new Question{
                QuestionText = QText,
                Point = Point,
                IdTest = TestId    
            };
            data.Questions.Add(question);
            data.SaveChanges();
            int QuestionId = data.Questions.FirstOrDefault(i => i.QuestionText == QText 
                                            && i.IdTest == TestId).QuestionId;
            data.Answers.Add(new Answer{
                AnswerText = CorrAns, 
                IdQuestion = QuestionId,
                IsRightAnswer = true}); //верный ответ
            data.Answers.Add(new Answer{
                AnswerText = WrgAns1, 
                IdQuestion = QuestionId,
                IsRightAnswer = false});
            data.Answers.Add(new Answer{
                AnswerText = WrgAns2, 
                IdQuestion = QuestionId,
                IsRightAnswer = false});
            data.Answers.Add(new Answer{
                AnswerText = WrgAns3, 
                IdQuestion = QuestionId,
                IsRightAnswer = false});
            data.SaveChanges();
            return RedirectToAction("EditTest", new{TestId = TestId});
        }
        public IActionResult DeleteQuestion(int? QuestionId)
        {
            Question question = data.Questions.Find(QuestionId);
            if (question == null) 
                return RedirectToAction("Error", new{error = "Вопрос не найден!"});
            int TestId = question.IdTest;
            data.Questions.Remove(question);
            data.SaveChanges();
            return RedirectToAction("EditTest", new{TestId = TestId});        
        }    
        public IActionResult ChangeQuestion(int? QuestionId)
        {
            if (data.Questions.FirstOrDefault(i=>i.QuestionId == QuestionId) == null)
                return RedirectToAction("Error", new{error = "Вопрос не найден!"});
            Question question = data.Questions.FirstOrDefault(i=>i.QuestionId == QuestionId);
            List<Answer> answers = data.Answers.Where(i => i.IdQuestion == QuestionId)
                                      .OrderBy(i=>i.IsRightAnswer).ToList();
                QuestionWithAns model = new QuestionWithAns{
                    question = question,                    
                    wrgAns1 = answers[0],
                    wrgAns2 = answers[1],
                    wrgAns3 = answers[2],
                    corrAns = answers[3],
                    test = data.Tests.Find(question.IdTest)
                };
            return View(model);
        }
        [HttpPost]
        public IActionResult ChangeQuestion(string QText, int QuestionId, int Point, string CorrAns, string WrgAns1, 
                                            string WrgAns2, string WrgAns3, int id1, int id2, int id3)
        {
            if (data.Questions.Find(QuestionId) == null)
                return RedirectToAction("Error", new{error = "Вопрос не найден!"});
            if (Point < 1 || Point > 5)   
            {    
                ModelState.AddModelError("TestName", "Выберит балл от 1 до 5!!!"); 
                Question question = data.Questions.FirstOrDefault(i=>i.QuestionId == QuestionId);
                List<Answer> answers = data.Answers.Where(i => i.IdQuestion == QuestionId)
                                      .OrderBy(i=>i.IsRightAnswer).ToList();
                QuestionWithAns model = new QuestionWithAns{
                    question = question,                    
                    wrgAns1 = answers[0],
                    wrgAns2 = answers[1],
                    wrgAns3 = answers[2],
                    corrAns = answers[3],
                    test = data.Tests.Find(question.IdTest)
                };
            return View(model);
            } 
            data.Questions.Find(QuestionId).QuestionText = QText;
            data.Questions.Find(QuestionId).Point = Point;
            data.Answers.Find(id1).AnswerText = WrgAns1;
            data.Answers.Find(id2).AnswerText = WrgAns2;
            data.Answers.Find(id3).AnswerText = WrgAns3;
            data.Answers.FirstOrDefault(i => i.IdQuestion == QuestionId 
                                        && i.IsRightAnswer == true).AnswerText = CorrAns;
            data.SaveChanges();
            return RedirectToAction("EditTest", new{TestId =  data.Questions.Find(QuestionId).IdTest });
        }
        public IActionResult TestHistory(int TestId){
            List<TestHistory> historyList = new List<TestHistory>();
            Test test = data.Tests.Find(TestId);
            Teacher teacher = data.Teachers.Find(test.IdTeacher);
            List<AnsQuestion> ansList = data.AnsQuestions.ToList();//.Where(i => data.Questions.Find(i.IdQuestion).IdTest == TestId).ToList();
            var groups = from i in ansList
                         group i by i.IdStudent;
            foreach(var item in groups)
            {
                int PointSum = 0;
                Student student = data.Students.Find(item.Key);
                foreach(var i in item)
                {
                    Question question = data.Questions.Find(i.IdQuestion);
                    if (question.IdTest == TestId)
                        if (data.Answers.Find(i.IdAnswer).IsRightAnswer == true)
                            PointSum = PointSum + question.Point;
                }
                TestHistory hist = new TestHistory{
                    test = test,
                    student = student,
                    result = PointSum
                    };
                    historyList.Add(hist);
            }
            historyList =  historyList.OrderBy(i => i.result).ToList();
            return View(new History{teacher = teacher, historylist = historyList});
        }
        
        public string Error(string error)
        {
            return $"ERROR MESSAGE:{error} ";
        }
    }
}