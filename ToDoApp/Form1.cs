using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TodoApp
{
    public partial class Form1 : Form
    {
        private List<Task> tasks;

        public Form1()
        {
            InitializeComponent();
            tasks = new List<Task>();
            LoadTasksFromFile();
            RefreshTasksList();
            UpdateStats();
        }

        private void LoadTasksFromFile()
        {
            tasks = FileManager.LoadTasks();
        }

        private void SaveTasksToFile()
        {
            FileManager.SaveTasks(tasks);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewTask();
        }

        private void txtNewTask_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // zapobiega dźwiękowi "beep"
                AddNewTask();
            }
        }

        private void AddNewTask()
        {
            string description = txtNewTask.Text.Trim();
            string category = cmbCategory.SelectedItem?.ToString() ?? "Ogólne";

            if (!string.IsNullOrEmpty(description))
            {
                Task newTask = new Task(description, category);
                tasks.Add(newTask);
                txtNewTask.Clear();
                RefreshTasksList();
                UpdateStats();
                SaveTasksToFile();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItems.Count > 0)
            {
                var selectedIndices = lstTasks.SelectedIndices.Cast<int>()
                                         .OrderByDescending(i => i)
                                         .ToList();

                foreach (int index in selectedIndices)
                {
                    tasks.RemoveAt(index);
                }

                RefreshTasksList();
                UpdateStats();
                SaveTasksToFile();
            }
        }

        private void btnToggleComplete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItems.Count > 0)
            {
                var selectedIndices = lstTasks.SelectedIndices.Cast<int>().ToList();

                foreach (int index in selectedIndices)
                {
                    tasks[index].IsCompleted = !tasks[index].IsCompleted;
                }

                RefreshTasksList();
                UpdateStats();
                SaveTasksToFile();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć wszystkie zadania?",
                                        "Potwierdzenie",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                tasks.Clear();
                RefreshTasksList();
                UpdateStats();
                SaveTasksToFile();
            }
        }

        private void RefreshTasksList()
        {
            lstTasks.Items.Clear();

            foreach (Task task in tasks)
            {
                lstTasks.Items.Add(task.ToString());
            }
        }

        private void UpdateStats()
        {
            int totalTasks = tasks.Count;
            int completedTasks = tasks.Count(t => t.IsCompleted);

            lblStats.Text = $"Zadań: {totalTasks} | Wykonanych: {completedTasks} | Pozostało: {totalTasks - completedTasks}";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveTasksToFile();
            base.OnFormClosing(e);
        }
    }
}