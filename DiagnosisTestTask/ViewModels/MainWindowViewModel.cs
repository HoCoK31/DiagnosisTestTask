using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DiagnosisTestTask.Commands;
using DiagnosisTestTask.Models;
using DiagnosisTestTask.Services;
using DiagnosisTestTask.Services.Interfaces;

namespace DiagnosisTestTask.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IFileService _fileService;
        private readonly IDialogService _dialogService;

        private DiagnosisObject _selectedDiagnosisObject;
        private ObservableCollection<DiagnosisObject> _diagnosisObjects;

        public MainWindowViewModel(IFileService fileService, IDialogService dialogService)
        {
            _fileService = fileService;
            _dialogService = dialogService;
        }

        public ObservableCollection<DiagnosisObject> DiagnosisObjects
        {
            get => _diagnosisObjects ??= new ObservableCollection<DiagnosisObject>();
            set
            {
                _diagnosisObjects = value;
                OnPropertyChanged();
            }
        }

        public DiagnosisObject SelectedDiagnosisObject
        {
            get => _selectedDiagnosisObject;
            set
            {
                _selectedDiagnosisObject = value;
                OnPropertyChanged();
                OnPropertyChanged("IsAnyObjectSelected");
            }
        }

        public bool IsAnyObjectSelected => _selectedDiagnosisObject is not null;

        #region Команды

        private RelayCommand openFileCommand;
        public RelayCommand OpenFileCommand
        {
            get
            {
                return openFileCommand ??= new RelayCommand(obj =>
                {
                    try
                    {
                        if (_dialogService.OpenFileDialog() != true) return;

                        var diagnosisObjects = _fileService.Open(_dialogService.FilePath);
                        DiagnosisObjects.Clear();
                        foreach (var p in diagnosisObjects)
                            DiagnosisObjects.Add(p);
                        _dialogService.ShowMessage("Файл импортирован!");
                    }
                    catch (Exception ex)
                    {
                        _dialogService.ShowMessage(ex.Message);
                    }
                });
            }
        }

        private RelayCommand saveFileCommand;
        public RelayCommand SaveFileCommand
        {
            get
            {
                return saveFileCommand ??= new RelayCommand(obj =>
                {
                    try
                    {
                        if (_dialogService.SaveFileDialog() != true) return;

                        _fileService.Save(_dialogService.FilePath, DiagnosisObjects.ToList());
                        _dialogService.ShowMessage("Файл сохранен!");
                    }
                    catch (Exception ex)
                    {
                        _dialogService.ShowMessage(ex.Message);
                    }
                });
            }
        }

        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
