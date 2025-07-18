using System.Runtime.CompilerServices;

namespace Task4
{
/*
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
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            GroupCourses cource = new GroupCourses();
            var studentNata = new Student("Natalia", 4324231, "12B");
            cource.AddStudent(studentNata, new CourseProgress("Basic"));
            cource.AddStudent(
                new Student("Alia", 123435, "12B"),
                new CourseProgress(
                    "Basic",
                    new Topics("Cpp", "Maria Petrova", new List<int> { 12, 5, 6, 7 })
                )
            );
            cource.AddStudent(
                new Student("Sasha", 321312, "12B"),
                new CourseProgress(
                    "Basic",
                    new Topics("Cpp", "Maria Petrova", new List<int> { 12, 10, 10, 10 })
                )
            );
            cource.AddTopicToStudentCourse(studentNata, "Basic", new Topics("Cpp", "Maria Petrova"));


            for (int i = 0; i < 4; i++)
            {
                cource.AddStudentMark(studentNata,"Basic" ,random.Next(6, 13));

            }
            Console.WriteLine(cource.ToString());






        }
    }
}
