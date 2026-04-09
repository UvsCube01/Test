using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DemoProj.MVVM.Models.StudentList;

namespace DemoProj.Services
{
    public interface IStudentService
    {
        ObservableCollection<Student> GetAll();

        Student GetById(int id);

        void AddStudent(Student student);

        void Update(Student student);
    }
}
