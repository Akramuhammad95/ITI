using System;
using System.Collections.Generic;
using System.Text;

namespace Day2.Task2
{
    public class ToDoList : Queue<string>
    {
        
        public void AddTask(string task)
        {
            Enqueue(task);
        }
        
        public void DisplayAllTasks()
        {
            if (Count == 0)
            {
                Console.WriteLine("No tasks in the to-do list.");
                return;
            }
            
            Console.WriteLine($"To-Do List: You have {Count} tasks");
            foreach (var task in this)
            {
                Console.WriteLine($"- {task}");
            }
        }

        public void MarkTaskAsCompleted()
        {
            if (Count == 0)
            {
                Console.WriteLine("No tasks to mark as completed.");
                return;
            }
            
            string completedTask = Dequeue();
            Console.WriteLine($"Task '{completedTask}' marked as completed.");
        }


    }
}
