using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoProj.MVVM.Models.StudentList;
using DemoProj.MVVM.Views.StudentList;
using DemoProj.Services;

namespace DemoProj.MVVM.ViewModels.StudentList
{
    public partial class StudentListViewModel : ObservableObject
    {
        private readonly StudentPopup _studentPopup;
        private readonly StudentPopupViewModel _studentPopupViewModel;

        private readonly IStudentService _studentService;

        [ObservableProperty]
        public ObservableCollection<Student> _students;

        public event EventHandler<Popup> ShowPopup;

        public StudentListViewModel(StudentPopup studentPopup, IStudentService studentService, StudentPopupViewModel studentPopupViewModel)
        {
            _studentPopup = studentPopup;
            _studentService = studentService;
            LoadStudents();
            _studentPopupViewModel = studentPopupViewModel;
        }

        private void LoadStudents()
        {
            _students = _studentService.GetAll();
        }

        [RelayCommand]
        private void AddStudent()
        { 
            ShowPopup?.Invoke(this, _studentPopup);
        }

        [RelayCommand]
        private void Edit(Student student)
        {
            _studentPopupViewModel.LoadEdit(student.Id);
            ShowPopup.Invoke(this, _studentPopup);
        }
    }
}
