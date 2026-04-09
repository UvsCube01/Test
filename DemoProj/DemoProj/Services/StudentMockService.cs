using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using DemoProj.MVVM.Models.StudentList;

namespace DemoProj.Services
{
    public class StudentMockService : IStudentService
    {
        public ObservableCollection<Student> _students;
        private int _nextId;

        public StudentMockService()
        {
            _students = new ObservableCollection<Student>
            {
                new Student { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Department = "Computer Science" },
                new Student { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Department = "Mathematics" },
                new Student { Id = 3, Name = "Michael Johnson", Email = "michael.johnson@example.com", Department = "Physics" }
            };
            _nextId = _students.Max(s => s.Id) + 1;
        }

        public ObservableCollection<Student> GetAll() 
        { 
            return _students; 
        }

        public Student GetById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public void AddStudent(Student student)
        {
            student.Id = _nextId++;
            _students.Add(student);
        }

        public void Update(Student student)
        {
            var index = Indexof(student.Id);
            _students[index] = student;
        }

        public int Indexof(int id)
        { 
            for (int i = 0; i < _students.Count; i++)
                if (_students[i].Id == id) return i;
            return -1;
        }
    }
}
