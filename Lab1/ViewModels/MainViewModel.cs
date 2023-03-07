using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab1.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private string _welcomeMessage;
        
    public event PropertyChangedEventHandler? PropertyChanged;

    public MainViewModel()
    {
        WelcomeMessage = "Hello, World!";
    }

    public string WelcomeMessage
    {
        get => _welcomeMessage;
        set
        {
            if (value == _welcomeMessage)
            {
                return;
            }
            _welcomeMessage = value;
            OnPropertyChanged();
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}