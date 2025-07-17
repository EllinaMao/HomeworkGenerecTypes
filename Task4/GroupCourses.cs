using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    internal class GroupCourses
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





    }
}
