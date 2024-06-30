using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using vikincode.Model;
using vikincode.Command;
using System.Collections.ObjectModel;
namespace vikincode.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        EmployeeService ObjEmployeeService;
        public EmployeeViewModel()
        {
            ObjEmployeeService = new EmployeeService();
            LoadData();
            CurrentEmployee=new Employee();
            saveCommand = new RelayCommand(Save);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
            
        }
        #region DisplayOperation
        private ObservableCollection<Employee> employeesList;
        public ObservableCollection<Employee> EmployeesList
        {
            get { return employeesList; }
            set { employeesList = value; OnPropertyChanged("EmployeesList"); }
        }

        private void LoadData()
        {
            EmployeesList = new ObservableCollection<Employee>(ObjEmployeeService.GetAll());
        }
        #endregion

        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value;OnPropertyChanged("CurrentEmployee"); }
        }

        private String message;

        public String Message
        {
            get { return message; }
            set { message = value;OnPropertyChanged("Message"); }
        }

        #region SaveOperation
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }
        public void Save()
        {
            try
            {
                var IsSaved = ObjEmployeeService.Add(CurrentEmployee);
                LoadData();
                if (IsSaved)
                    Message = "Employee save";
                else
                    Message = "save operation failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                
            }
        }
        #endregion

        #region UpdateOperation

        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
            
        }
        public void Update ()
        {
            try
            {
                var IsUpdate = ObjEmployeeService.Update(CurrentEmployee);
                if(IsUpdate)
                {
                    Message = "Employee Update";
                    LoadData();
                }
                else
                {
                    Message = "Update operation failed";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }

        #endregion

        #region DeleteOperation

        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
            
        }
        public void Delete()
        {
            try
            {
                var IsDeleted=ObjEmployeeService.Delete(CurrentEmployee.Id);
                if(IsDeleted)
                {
                    Message = "DELETED";
                    LoadData();
                }
                else
                {
                    Message = "delete operation failed";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }
        #endregion


    }
}
