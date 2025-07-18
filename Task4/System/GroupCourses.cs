using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Interfaces;

namespace Task4
{/*
Задание 4
Разработайте систему управления учебными курсами и студентами. В системе необходимо:

Хранить данные о студентах и их прогрессе в рамках различных курсов с помощью класса Dictionary<Student, List<CourseProgress>>, где:
Student — класс, содержащий информацию о студенте (ФИО, ID, группа).
CourseProgress — класс, отражающий прогресс студента в конкретном курсе (название курса, текущий балл, завершенные темы, текущая тема).
Реализовать функциональность:
Добавления нового студента или обновления информации о существующем студенте.
Добавления курса к студенту и обновления его прогресса.
Поиска и фильтрации студентов по различным критериям (например, по группе, статусу прогресса в курсе, текущему баллу).
Сортировки студентов в зависимости от их успеваемости.*/
    public class GroupCourses
    {
        Dictionary<Student, List<CourseProgress>> studentCourses;
        public GroupCourses()
        {
            studentCourses = new Dictionary<Student, List<CourseProgress>>();
        }
        public void AddStudent(Student student, CourseProgress progress)
        {
            studentCourses.TryGetValue(student, out var progressList);
            if (progressList == null)
            {
                progressList = new List<CourseProgress>();
                studentCourses[student] = progressList;
            }
            progressList.Add(progress);
        }
        public void RemoveStudent(Student student)
        {
            if (studentCourses.ContainsKey(student))
            {
                studentCourses.Remove(student);
            }

        }

        public void UpdateStudentProgress(Student student, CourseProgress progress)
        {
            if (studentCourses.TryGetValue(student, out var progressList))
            {
                var existingProgress = progressList.FirstOrDefault(p => p.Name == progress.Name);
                if (existingProgress != null)
                {
                    existingProgress.UpdateCurrentScore();
                }
                else
                {
                    progressList.Add(progress);
                }
            }
        }

        public void AddStudentMark(Student student, string courseName, int mark)
        {
            if (studentCourses.TryGetValue(student, out var progressList))
            {
                var course = progressList.FirstOrDefault(p => p.Name == courseName);
                if (course == null)
                {
                    Console.WriteLine("Курс не найден у студента.");
                    return;
                }

                if (course.CurrentTopic == null)
                {
                    Console.WriteLine("У курса нет текущей темы.");
                    return;
                }

                course.CurrentTopic.AddMark(mark);
            }
            else
            {
                Console.WriteLine("Студент не найден.");
            }
        }

        public void AddTopicToStudentCourse(Student student, string courseName, Topics topic)
        {
            if (studentCourses.TryGetValue(student, out var progressList))
            {
                var course = progressList.FirstOrDefault(p => p.Name == courseName);
                if (course == null)
                {
                    var newCourse = new CourseProgress(courseName, topic);
                    progressList.Add(newCourse);
                    return;
                }

                if (course.CurrentTopic != null && course.CurrentTopic.IsCompleted)
                {
                    course.CompleteTopic(course.CurrentTopic);
                }

                course.SetCurrentTopic(topic);
            }
            else
            {
                Console.WriteLine("Студент не найден.");
            }
        }

        private string Concatenate()
        {
            var sb = new StringBuilder();

            foreach (var kvp in studentCourses)
            {
                var student = kvp.Key;
                var courses = kvp.Value;

                sb.AppendLine($"Студент: {student.FullName}, ID: {student.ID}, Группа: {student.Group}");

                if (courses.Count == 0)
                {
                    sb.AppendLine("  Нет курсов.");
                }
                else
                {
                    foreach (var course in courses)
                    {
                        string currentTopic = course.CurrentTopic?.Name ?? "пусто";
                        sb.AppendLine($"  Курс: {course.Name}, Текущий балл: {course.CurrentScore}, Текущая тема: {currentTopic}");
                    }
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return Concatenate();
        }

        public void Show()
        {
            Console.WriteLine(Concatenate());
        }








    }
}
