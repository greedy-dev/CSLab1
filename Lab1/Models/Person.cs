namespace Lab1.Models
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _dateOfBirth;

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value?.Trim();
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value?.Trim();
        }

        public string Email
        {
            get => _email;
            set => _email = value?.Trim();
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set => _dateOfBirth = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0, DateTimeKind.Utc);
        }

        public int Age { get; private set; }

        public string SunSign { get; private set; }

        public string ChineseSign { get; private set; }

        public bool IsAdult => DateOfBirth <= DateTime.UtcNow.AddYears(-18);

        public bool IsBirthday => DateOfBirth.Date == DateTime.UtcNow.Date;

        public async Task CalculatePropertiesAsync()
        {
            await Task.Run(() =>
            {
                Age = DateTime.UtcNow.Year - DateOfBirth.Year;
                if (DateTime.UtcNow < DateOfBirth.AddYears(Age)) Age--;

                SunSign = GetSunSign(_dateOfBirth);
                ChineseSign = GetChineseSign(_dateOfBirth);
            });
        }


        private static string GetSunSign(DateTime dateOfBirth)
        {
            int month = dateOfBirth.Month;
            int day = dateOfBirth.Day;
            if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            {
                return "Aquarius";
            }
            else if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
            {
                return "Pisces";
            }
            else if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
            {
                return "Aries";
            }
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
            {
                return "Taurus";
            }
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
            {
                return "Gemini";
            }
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
            {
                return "Cancer";
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            {
                return "Leo";
            }
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
            {
                return "Virgo";
            }
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
            {
                return "Libra";
            }
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
            {
                return "Scorpio";
            }
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
            {
                return "Sagittarius";
            }
            else
            {
                return "Capricorn";
            }
        }

        private static string GetChineseSign(DateTime dateOfBirth)
        {
            int year = dateOfBirth.Year;
            int offset = year % 12;
            switch (offset)
            {
                case 0:
                    return "Monkey";
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                case 11:
                    return "Sheep";
                default:
                    throw new ArgumentException("Invalid date");
            }
        }
    }
}