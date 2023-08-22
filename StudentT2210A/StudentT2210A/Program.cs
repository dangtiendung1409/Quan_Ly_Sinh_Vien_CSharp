using System;
using System.Collections.Generic;
using StudentT2210A.demo1;

public class Program
{
    static List<Student> students = new List<Student>();

    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Cập nhật thông tin sinh viên");
            Console.WriteLine("3. Xóa sinh viên");
            Console.WriteLine("4. Tìm kiếm sinh viên theo tên");
            Console.WriteLine("5. Sắp xếp sinh viên theo điểm trung bình (GPA)");
            Console.WriteLine("6. Sắp xếp sinh viên theo tên");
            Console.WriteLine("7. Sắp xếp sinh viên theo ID");
            Console.WriteLine("8. Hiển thị danh sách sinh viên");
            Console.WriteLine("0. Thoát");
            Console.Write("Nhập lựa chọn: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    UpdateStudent();
                    break;
                case 3:
                    DeleteStudent();
                    break;
                case 4:
                    SearchByName();
                    break;
                case 5:
                    SortByGPA();
                    break;
                case 6:
                    SortByName();
                    break;
                case 7:
                    SortById();
                    break;
                case 8:
                    DisplayStudents();
                    break;
                case 0:
                    Console.WriteLine("Thoát chương trình.");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
        } while (choice != 0);
    }

    static void AddStudent()
    {
        Student newStudent = new Student();

        Console.Write("Nhập ID: ");
        newStudent.Id = int.Parse(Console.ReadLine());

        Console.Write("Nhập tên: ");
        newStudent.Name = Console.ReadLine();

        Console.Write("Nhập giới tính: ");
        newStudent.Gender = Console.ReadLine();

        Console.Write("Nhập tuổi: ");
        newStudent.Age = int.Parse(Console.ReadLine());

        Console.Write("Nhập điểm Toán: ");
        newStudent.MathScore = double.Parse(Console.ReadLine());
        Console.Write("Nhập điểm Lý: ");
        newStudent.PhysicsScore = double.Parse(Console.ReadLine());

        Console.Write("Nhập điểm Hóa: ");
        newStudent.ChemistryScore = double.Parse(Console.ReadLine());

        newStudent.CalculateAverageScore();
        newStudent.CalculateAcademicPerformance();

        students.Add(newStudent);
        Console.WriteLine("Thêm sinh viên thành công.");
    }

    static void UpdateStudent()
    {
        Console.Write("Nhập ID của sinh viên cần cập nhật: ");
        int id = int.Parse(Console.ReadLine());

        Student studentToUpdate = students.Find(s => s.Id == id);
        if (studentToUpdate != null)
        {
            Console.Write("Nhập tên mới: ");
            studentToUpdate.Name = Console.ReadLine();

            Console.Write("Nhập giới tính mới: ");
            studentToUpdate.Gender = Console.ReadLine();

            Console.Write("Nhập tuổi mới: ");
            studentToUpdate.Age = int.Parse(Console.ReadLine());

            Console.Write("Nhập điểm Toán mới: ");
            studentToUpdate.MathScore = double.Parse(Console.ReadLine());

            Console.Write("Nhập điểm Lý mới: ");
            studentToUpdate.PhysicsScore = double.Parse(Console.ReadLine());

            Console.Write("Nhập điểm Hóa mới: ");
            studentToUpdate.ChemistryScore = double.Parse(Console.ReadLine());

            studentToUpdate.CalculateAverageScore();
            studentToUpdate.CalculateAcademicPerformance();

            Console.WriteLine("Cập nhật thông tin sinh viên thành công.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên có ID cần cập nhật.");
        }
    }

    static void DeleteStudent()
    {
        Console.Write("Nhập ID của sinh viên cần xóa: ");
        int id = int.Parse(Console.ReadLine());

        Student studentToDelete = students.Find(s => s.Id == id);
        if (studentToDelete != null)
        {
            students.Remove(studentToDelete);
            Console.WriteLine("Xóa sinh viên thành công.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên có ID cần xóa.");
        }
    }

    static void SearchByName()
    {
        Console.Write("Nhập tên sinh viên cần tìm: ");
        string name = Console.ReadLine();

        List<Student> searchResults = students.FindAll(s => s.Name.ToLower().Contains(name.ToLower()));

        if (searchResults.Count > 0)
        {
            Console.WriteLine("Kết quả tìm kiếm:");
            DisplayStudentList(searchResults);
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên có tên phù hợp.");
        }
    }

    static void SortByGPA()
    {
        students.Sort((s1, s2) => s2.AverageScore.CompareTo(s1.AverageScore));
        Console.WriteLine("Danh sách sinh viên sau khi sắp xếp theo GPA:");
        DisplayStudents();
    }

    static void SortByName()
    {
        students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name));
        Console.WriteLine("Danh sách sinh viên sau khi sắp xếp theo tên:");
        DisplayStudents();
    }

    static void SortById()
    {
        students.Sort((s1, s2) => s1.Id.CompareTo(s2.Id));
        Console.WriteLine("Danh sách sinh viên sau khi sắp xếp theo ID:");
        DisplayStudents();
    }

    static void DisplayStudents()
    {
        if (students.Count > 0)
        {
            DisplayStudentList(students);
        }
        else
        {
            Console.WriteLine("Không có sinh viên trong danh sách.");
        }
    }

    static void DisplayStudentList(List<Student> studentList)
    {
        foreach (var student in studentList)
        {
            Console.WriteLine($"ID: {student.Id}");
            Console.WriteLine($"Tên: {student.Name}");
            Console.WriteLine($"Giới tính: {student.Gender}");
            Console.WriteLine($"Tuổi: {student.Age}");
            Console.WriteLine($"Điểm Toán: {student.MathScore}");
            Console.WriteLine($"Điểm Lý: {student.PhysicsScore}");
            Console.WriteLine($"Điểm Hóa: {student.ChemistryScore}");
            Console.WriteLine($"Điểm trung bình: {student.AverageScore}");
            Console.WriteLine($"Học lực: {student.AcademicPerformance}");
            Console.WriteLine("==============================");
        }
    }
}
