using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
namespace Task4
{
    internal class CourseProgress: ICourseProgress
    {
        public string Name { get; private set; }
        public Topics? CurrentTopic { get; set; }
        public double CurrentScore { get; set; }
        public List<Topics> CompletedTopics { get; private set; }

        public CourseProgress(string name, Topics? currentTopic = null, List<Topics>? completedTopics = null)
        {
            Name = name;
            CurrentTopic = currentTopic ?? null;
            CompletedTopics = completedTopics ?? new List<Topics>();
            UpdateCurrentScore();
        }
        private void OnMarksUpdated(object? sender, EventArgs e)
        {
            UpdateCurrentScore();
        }
        private void OnTopicCompleted(object? sender, EventArgs e)
        {
            if (sender is Topics topic)
            {
                CompleteTopic(topic);
            }
        }

        public override string ToString()
        {
            return $"Course: {Name}, Current Score: {CurrentScore}, Current Topic: {CurrentTopic?.Name}, Completed Topics: {string.Join(", ", CompletedTopics.Select(t => t.Name))}";
        }

        public void UpdateCurrentScore()
        {
            int totalMark = 0;
            int topicCount = CompletedTopics.Count;

            foreach (var topic in CompletedTopics)
            {
                totalMark += topic.AverageMark;
            }

            if (CurrentTopic != null)
            {
                totalMark += CurrentTopic.AverageMark;
                topicCount++;
            }

            double newScore = topicCount > 0 ? totalMark / topicCount : 0;

            if (newScore != CurrentScore)
            {
                CurrentScore = newScore;
            }
        }   

        public void CompleteTopic(Topics topic)
        {
            if (topic.IsCompleted)
            {
                topic.OnMarksUpdated -= OnMarksUpdated;
                topic.OnMarksUpdated -= OnTopicCompleted;
                CompletedTopics.Add(topic);
                CurrentTopic = null;
                //UpdateCurrentScore();
            }
            else
            {
                throw new InvalidOperationException("Topic must be completed before adding to completed topics.");
            }
        }



        public void SetCurrentTopic(Topics topic)
        {
            UnsubscribeFromTopic(CurrentTopic);
            CurrentTopic = topic;
            SubscribeToTopic(CurrentTopic);

            //UpdateCurrentScore(); // пересчитываем на всякий случай
        }

        private void SubscribeToTopic(Topics? topic)
        {
            if (topic == null) return;
            topic.OnMarksUpdated += OnMarksUpdated;
            topic.OnTopicCompleted += OnTopicCompleted;
        }

        private void UnsubscribeFromTopic(Topics? topic)
        {
            if (topic == null) return;
            topic.OnMarksUpdated -= OnMarksUpdated;
            topic.OnTopicCompleted -= OnTopicCompleted;
        }













    }

}
