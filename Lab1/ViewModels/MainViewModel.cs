using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab1.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private DateTime _selectedDate;
        private int _age;
        private string _westernZodiacSign;
        private string _chineseZodiacSign;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
                CalculateAge();
                DetermineZodiacSigns();
                CheckBirthday();
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public string WesternZodiacSign
        {
            get => _westernZodiacSign;
            set
            {
                _westernZodiacSign = value;
                OnPropertyChanged();
            }
        }

        public string ChineseZodiacSign
        {
            get => _chineseZodiacSign;
            set
            {
                _chineseZodiacSign = value;
                OnPropertyChanged();
            }
        }

        private void CalculateAge()
        {
            var today = DateTime.Today;
            Age = today.Year - SelectedDate.Year;
            if (SelectedDate.Date > today.AddYears(-Age)) Age--;
        }

        private void DetermineZodiacSigns()
        {
            var month = SelectedDate.Month;
            var day = SelectedDate.Day;

            // Determine western zodiac sign
            switch (month)
            {
                case 1:
                    WesternZodiacSign = day <= 19 ? "Capricorn" : "Aquarius";
                    break;
                case 2:
                    WesternZodiacSign = day <= 18 ? "Aquarius" : "Pisces";
                    break;
                case 3:
                    WesternZodiacSign = day <= 20 ? "Pisces" : "Aries";
                    break;
                case 4:
                    WesternZodiacSign = day <= 19 ? "Aries" : "Taurus";
                    break;
                case 5:
                    WesternZodiacSign = day <= 20 ? "Taurus" : "Gemini";
                    break;
                case 6:
                    WesternZodiacSign = day <= 20 ? "Gemini" : "Cancer";
                    break;
                case 7:
                    WesternZodiacSign = day <= 22 ? "Cancer" : "Leo";
                    break;
                case 8:
                    WesternZodiacSign = day <= 22 ? "Leo" : "Virgo";
                    break;
                case 9:
                    WesternZodiacSign = day <= 22 ? "Virgo" : "Libra";
                    break;
                case 10:
                    WesternZodiacSign = day <= 22 ? "Libra" : "Scorpio";
                    break;
                case 11:
                    WesternZodiacSign = day <= 21 ? "Scorpio" : "Sagittarius";
                    break;
                case 12:
                    WesternZodiacSign = day <= 21 ? "Sagittarius" : "Capricorn";
                    break;
                default:
                    WesternZodiacSign = "";
                    break;
            }

            // Determine Chinese zodiac sign
            switch ((SelectedDate.Year - 4) % 12)
            {
                case 0:
                    ChineseZodiacSign = "Rat";
                    break;
                case 1:
                    ChineseZodiacSign = "Ox";
                    break;
                case 2:
                    ChineseZodiacSign = "Tiger";
                    break;
                case 3:
                    ChineseZodiacSign = "Rabbit";
                    break;
                case 4:
                    ChineseZodiacSign = "Dragon";
                    break;
                case 5:
                    ChineseZodiacSign = "Snake";
                    break;
                case 6:
                    ChineseZodiacSign = "Horse";
                    break;
                case 7:
                    ChineseZodiacSign = "Goat";
                    break;
                case 8:
                    ChineseZodiacSign = "Monkey";
                    break;
                case 9:
                    ChineseZodiacSign = "Rooster";
                    break;
                case 10:
                    ChineseZodiacSign = "Dog";
                    break;
                case 11:
                    ChineseZodiacSign = "Pig";
                    break;
                default:
                    ChineseZodiacSign = "";
                    break;
            }
        }

        private void CheckBirthday()
        {
            if (SelectedDate.Date == DateTime.Today)
            {
                // Display congratulations message
                Console.WriteLine("Happy birthday!");
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}