using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoProj.MVVM.Models.StudentList;
using DemoProj.Services;

namespace DemoProj.MVVM.ViewModels.StudentList
{
    public partial class StudentPopupViewModel : ObservableObject
    {
        private readonly IStudentService _studentService;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _department;

        private Student? _editingStudent;

        public event Action? CloseRequested;

        public bool IsEditMode => _editingStudent != null;

        public StudentPopupViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void LoadEdit(int id)
        {
            _editingStudent = _studentService.GetById(id);
            if (_editingStudent != null)
            {
                Name = _editingStudent.Name;
                Email = _editingStudent.Email;
                Department = _editingStudent.Department;
            }

            OnPropertyChanged(nameof(IsEditMode));
        }

        [RelayCommand]
        private void Save()
        {
            if (IsEditMode)
            {
                _editingStudent.Name = Name;
                _editingStudent.Email = Email;
                _editingStudent.Department = Department;
                _studentService.Update(_editingStudent);
            }
            else
            {
                _studentService.AddStudent(new Student
                {
                    Name = Name,
                    Email = Email,
                    Department = Department
                });
            }

            CloseRequested?.Invoke();
        }

        [RelayCommand]
        private void Cancel() => CloseRequested?.Invoke();
    }
}
