using System;
using System.Drawing;
using System.Windows.Forms;

namespace TodoApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtNewTask;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstTasks;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnToggleComplete;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblStats;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Inicjalizacja kontrolek
            this.txtNewTask = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnToggleComplete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblStats = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // TextBox dla nowego zadania
            this.txtNewTask.Location = new System.Drawing.Point(12, 12);
            this.txtNewTask.Size = new System.Drawing.Size(200, 20);
            this.txtNewTask.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewTask_KeyPress);

            // ComboBox kategorii
            this.cmbCategory.Location = new System.Drawing.Point(218, 12);
            this.cmbCategory.Size = new System.Drawing.Size(100, 21);
            this.cmbCategory.Items.AddRange(new object[] { "Praca", "Dom", "Studia", "Zakupy", "Ogólne" });
            this.cmbCategory.SelectedIndex = 4;

            // Przycisk Dodaj
            this.btnAdd.Location = new System.Drawing.Point(324, 10);
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Text = "Dodaj";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // ListBox z zadaniami
            this.lstTasks.Location = new System.Drawing.Point(12, 40);
            this.lstTasks.Size = new System.Drawing.Size(387, 200);
            this.lstTasks.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;

            // Przycisk Usuń
            this.btnDelete.Location = new System.Drawing.Point(12, 250);
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.Text = "Usuń";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // Przycisk Zaznacz/Wyczyść
            this.btnToggleComplete.Location = new System.Drawing.Point(93, 250);
            this.btnToggleComplete.Size = new System.Drawing.Size(100, 23);
            this.btnToggleComplete.Text = "Zaznacz/Wyczyść";
            this.btnToggleComplete.Click += new System.EventHandler(this.btnToggleComplete_Click);

            // Przycisk Wyczyść Wszystko
            this.btnClear.Location = new System.Drawing.Point(199, 250);
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.Text = "Wyczyść Wszystko";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // Label ze statystykami
            this.lblStats.Location = new System.Drawing.Point(12, 280);
            this.lblStats.Size = new System.Drawing.Size(387, 20);
            this.lblStats.Text = "Zadań: 0 | Wykonanych: 0";

            // Główne okno
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 311);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.txtNewTask, this.cmbCategory, this.btnAdd,
                this.lstTasks, this.btnDelete, this.btnToggleComplete,
                this.btnClear, this.lblStats
            });
            this.Text = "Lista Zadań";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}