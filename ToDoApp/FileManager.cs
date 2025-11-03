using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace TodoApp
{
    public static class FileManager
    {
        private static string filePath = "tasks.txt";

        public static void SaveTasks(List<Task> tasks)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var task in tasks)
                {
                    // Zapis daty w formacie "O" (round-trip ISO 8601) dla bezpiecznego odczytu niezależnie od kultury
                    writer.WriteLine($"{task.Description}|{task.Category}|{task.IsCompleted}|{task.CreatedDate:O}");
                }
            }
        }

        public static List<Task> LoadTasks()
        {
            var tasks = new List<Task>();

            if (!File.Exists(filePath)) return tasks;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 4)
                {
                    var task = new Task(parts[0], parts[1]);

                    // Bezpieczne parsowanie bool
                    task.IsCompleted = bool.TryParse(parts[2], out var isDone) && isDone;

                    // Priorytetowy odczyt w formacie "O", a jeśli się nie powiedzie, próba ogólnego parsowania
                    if (DateTime.TryParseExact(parts[3], "O", CultureInfo.InvariantCulture,
                                               DateTimeStyles.RoundtripKind, out var dt))
                    {
                        task.CreatedDate = dt;
                    }
                    else if (DateTime.TryParse(parts[3], out var dt2))
                    {
                        task.CreatedDate = dt2;
                    }
                    else
                    {
                        task.CreatedDate = DateTime.Now;
                    }

                    tasks.Add(task);
                }
            }

            return tasks;
        }
    }
}