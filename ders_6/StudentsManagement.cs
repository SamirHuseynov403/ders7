using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ders_6
{
    class StudentsManagement
    {
        private Students[] studentsarray = new Students[1];
        int countAdd = 0;
        int id = 0;
        bool foundMesage = false;
        bool checkMesage = false;
        public void StudentAdd()
        {
            Console.WriteLine("Name Student");
            string namestudent = Console.ReadLine();

            Console.WriteLine("Age Student");
            int agestudent = int.Parse(Console.ReadLine());

            Console.WriteLine("Grade Student");
            string gradestudent = Console.ReadLine();

            if (countAdd >= studentsarray.Length)
            {
                Students[] newArray = new Students[studentsarray.Length + 1];

                for (int i = 0; i < studentsarray.Length; i++)
                {
                    newArray[i] = studentsarray[i];
                }

                studentsarray = newArray;
            }

            studentsarray[countAdd] = new Students { Id = id, Name = namestudent, Age = agestudent, Grade = gradestudent };
            countAdd++;
            id++;
            Console.WriteLine("Student added successfully!");
            Console.WriteLine();
        }
        public void AllStudents()
        {
            if (studentsarray == null || countAdd == 0)
            {
                Console.WriteLine("No students found!");
                return;
            }

            for (int i = 0; i < countAdd; i++)
            {
                if (studentsarray[i] != null)
                {
                    Console.WriteLine(new string('-', 59));
                    Console.WriteLine($"ID: {studentsarray[i].Id.ToString().PadRight(5)}| " +
                        $"Name: {studentsarray[i].Name.PadRight(15)}| " +
                        $"Age: {studentsarray[i].Age.ToString().PadRight(5)}| " +
                        $"Grade: {studentsarray[i].Grade.PadRight(3)}| ");
                    Console.WriteLine(new string('-', 59));
                }
            }
        }
        public void StudentUpdate(int id)
        {
            RequestMesage(id);
            if (foundMesage == true)
            {
                for (int i = 0; i < studentsarray.Length; i++)
                {
                    if (studentsarray[i].Id == id)
                    {
                        Console.WriteLine($"ID: {studentsarray[i].Id.ToString().PadRight(5)}" +
                            $"Name: {studentsarray[i].Name.PadRight(5)}" +
                            $"Age: {studentsarray[i].Age.ToString().PadRight(5)}" +
                            $"Grade: {studentsarray[i].Grade.PadRight(5)} "
                        );
                        Console.Write($"Old name {studentsarray[i].Name} ");
                        Console.WriteLine("New Name");
                        string newName = Console.ReadLine();
                        Console.Write($"Old age {studentsarray[i].Age} ");
                        Console.WriteLine("New Age");
                        string newAgee = Console.ReadLine();
                        Console.Write($"Old grade {studentsarray[i].Grade} ");
                        Console.WriteLine("New Grade");
                        string newGrade = Console.ReadLine();

                        if (newName == "")
                        { newName = studentsarray[i].Name; }
                        if (newAgee == "")
                        { newAgee = studentsarray[i].Age.ToString(); }
                        if (newGrade == "")
                        { newGrade = studentsarray[i].Grade; }

                        studentsarray[i] = new Students { Id = id, Name = newName, Age = int.Parse(newAgee), Grade = newGrade };
                        Console.WriteLine($"ID {id} changed successfully");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"ID {id} not found");
            }
        }
        public void RequestMesage(int id)
        {
            for (int i = 0; i < this.studentsarray.Length; i++)
            {
                if (studentsarray[i] != null && studentsarray[i].Id == id)
                {
                    foundMesage = true;
                    break;
                }
            }
        }
        public void StudentDelete(int id)
        {
            RequestMesage(id);

            if (foundMesage == true)
            {
                Students[] newstudents = new Students[studentsarray.Length - 1];
                int newcountindex = 0;

                for (int i = 0; i < studentsarray.Length; i++)
                {
                    if (i != id)
                    {
                        newstudents[newcountindex] = studentsarray[i];
                        newcountindex++;
                    }
                }
                countAdd--;
                studentsarray = newstudents;
                Console.WriteLine($"ID {id} deleted");
            }
            else
            {
                Console.WriteLine($"ID {id} not found");
            }
        }
        public void AllMenyu()
        {
            Console.WriteLine();
            Console.WriteLine("Student Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Student");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.WriteLine("Make a choice");
        }
        public void Program()
        {
            while (true)
            {
                AllMenyu();
                string checkrequest = Console.ReadLine();
                int choice;

                MenuQuery(checkrequest);

                if (checkMesage == true)
                {
                    choice = int.Parse(checkrequest);

                    if (choice == 1)
                    {
                        StudentAdd();
                    }
                    else if (choice == 2)
                    {
                        AllStudents();
                    }
                    else if (choice == 3)
                    {
                        Console.WriteLine("Type the ID to be corrected");
                        int choiceUpdate = int.Parse(Console.ReadLine());
                        StudentUpdate(choiceUpdate);
                    }
                    else if (choice == 4)
                    {
                        Console.WriteLine("Type the ID to be deleted");
                        int choiceDelete = int.Parse(Console.ReadLine());
                        StudentDelete(choiceDelete);
                    }
                    else if (choice == 5)
                    {
                        Console.WriteLine("Exiting program...");
                    }
                }
                else
                {
                    Console.WriteLine("You didn't make the right choice.");
                }
            }
        }
        public void MenuQuery(string checkNo)
        {
            if (checkNo == "1" || checkNo == "2" || checkNo == "3" || checkNo == "4" || checkNo == "5")
            {
                checkMesage = true;
            }
            else
            {
                checkMesage = false;
            }
        }
    }
}
