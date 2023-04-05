using System.ComponentModel;
using Lab1.Models;
using Lab1.Utilities;

namespace Lab1.ViewModels;

public class PersonViewModel : INotifyPropertyChanged
{
    private static PersonValidator _validator = new PersonValidator();
    private readonly Person _person;

    public string FirstName
    {
        get => _person.FirstName;
        set
        {
            _person.FirstName = value;
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(CanProceed));
        }
    }

    public string LastName
    {
        get => _person.LastName;
        set
        {
            _person.LastName = value;
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(CanProceed));
        }
    }

    public string Email
    {
        get => _person.Email;
        set
        {
            _person.Email = value;
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(CanProceed));
        }
    }

    public DateTime DateOfBirth
    {
        get => _person.DateOfBirth;
        set
        {
            _person.DateOfBirth = value;
            OnPropertyChanged(nameof(DateOfBirth));
            OnPropertyChanged(nameof(CanProceed));
        }
    }

    public bool CanProceed => !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName) && !string.IsNullOrWhiteSpace(Email);

    public bool IsAdult => _person.IsAdult;

    public string SunSign => _person.SunSign;

    public string ChineseSign => _person.ChineseSign;

    public bool IsBirthday => _person.IsBirthday;

    public PersonViewModel()
    {
        _person = new Person();
    }

    public async void CalculateProperties()
    {
        await _person.CalculatePropertiesAsync();
        OnPropertyChanged(nameof(IsAdult));
        OnPropertyChanged(nameof(SunSign));
        OnPropertyChanged(nameof(ChineseSign));
        OnPropertyChanged(nameof(IsBirthday));
    }
    
    public async Task<OperationResult> ProcessAsync()
    {
        if (!_validator.Validate(_person))
        {
            return new OperationResult(false, "Please fill in all required fields or check the entered values.");
        }
        
        await _person.CalculatePropertiesAsync();

        return new OperationResult(true, null);
    }


    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}