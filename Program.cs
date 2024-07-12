using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ToDoConsole
{
    internal class Program
    {
        private static List<TodoItem>  todoItems = new List<TodoItem>();

        static int Main(string[] args)
        {
            int choice = 0;
            do
            {
                try
                {
                    displayMenu();
                    Console.Write("Enter choice: ");
                    choice = Convert.ToInt32(Console.ReadLine() ?? "0");
                    switch (choice)
                    {
                        case 1:
                            DisplayTasks();
                            break;
                        case 2:
                            AddTask();
                            break;
                        case 3:
                            UpdateTask();
                            break;
                        case 4:
                            RemoveTask();
                            break;
                        case 5:
                            Console.WriteLine("Quiting program.................");
                            todoItems.Clear();
                            break;
                        default:
                            Console.WriteLine("Option not available");
                            break;
                    }
                } catch (FormatException)
                {
                    Console.WriteLine("Invalid input, Make sure the value entered is numerical");
                } catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.ReadKey();
                Console.Clear();

            } while (choice != 5);

            return 0;
        }

        public static void displayMenu()
        {
            Console.WriteLine("=================================================");
            Console.WriteLine("\tWelcome to Todo Land\t");
            Console.WriteLine("=================================================");
            Console.WriteLine("1. Display List");
            Console.WriteLine("2. Add a Task");
            Console.WriteLine("3. Update a Task");
            Console.WriteLine("4. Delete a Task");
            Console.WriteLine("5. Exit");
        }

        public static void DisplayTasks()
        {
            if (todoItems.Count > 0)
            {
                todoItems.ForEach(item => {
                    Console.WriteLine();
                    Console.WriteLine($"# {item.Id}");
                    Console.WriteLine($"Title: \t\t {item.Title}");
                    Console.WriteLine("Description: \t{item.Description}");
                    Console.WriteLine("Date Created: \t{item.DateCreated}");
                    Console.WriteLine("Date Modified: \t{item.DateUpdated}");
                    Console.WriteLine("Task Completed:\t" + (item.IsCompleted ? "Completed" : "Not Finished"));
                    Console.WriteLine();
                });
            } else
            {
                Console.WriteLine("There are no task items in list yet");
            }
        }

        public static void AddTask()
        {
            try
            {
                Console.Write("Enter the title: ");
                string title = Console.ReadLine() ?? "";
                Console.Write("Enter the description: ");
                string description = Console.ReadLine() ?? "";

                int Id = (todoItems.Count > 0) ? todoItems.Max(item => item.Id) + 1: 1;
                todoItems.Add(new TodoItem(Id, title, description, false));

                Console.WriteLine("Task added successfully");
            } catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\nCould not add Task successfully");
            }
        }

        public static void UpdateTask()
        {
            try
            {
                string title;
                string description;
                Console.Write("Enter ID for item? ");
                int Id = Convert.ToInt32((Console.ReadLine() ?? "0"));
                TodoItem item = todoItems.Find(itm => itm.Id == Id);

                Console.Write("Would you like to update the title? (yes/no) ");
                if (Console.ReadLine() == "yes")
                {
                    Console.Write("Enter the new title? ");
                    title = Console.ReadLine() ?? "";
                }
                else
                {
                    title = item.Title;
                }
                Console.Write("Would you like to update the description? (yes/no) ");
                if (Console.ReadLine() == "yes")
                {
                    Console.Write("Enter the new description? ");
                    description = Console.ReadLine() ?? "";
                }
                else
                {
                    description = item.Description;
                }

                Console.Write("Did you complete this task? (yes/no) ");
                bool isCompleted = Console.ReadLine() == "yes" ? true : false;
                item.Update(title, description, isCompleted);
                Console.WriteLine($"Item: #{item.Id} - {item.Title} updated successfully");
            } catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} \nCould not update Task successfully");
            }
        }

        public static void RemoveTask()
        {
            try
            {
                Console.Write("Enter the ID for item? ");
                int Id = Convert.ToInt32(Console.ReadLine());

                todoItems.Remove(todoItems.Find(item => item.Id == Id));

                Console.WriteLine("Task removed successfully");
            } catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\nCould not remove Task successfully");
            }
        }
    }
}
