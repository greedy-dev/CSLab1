using Lab1.Models;

namespace Lab1.Utilities;

public class PersonValidator
{
    public bool Validate(Person person)
    {
        if (string.IsNullOrWhiteSpace(person.FirstName))
        {
            return false;
        }
        
        if (string.IsNullOrWhiteSpace(person.LastName))
        {
            return false;
        }
        
        if (string.IsNullOrWhiteSpace(person.Email))
        {
            return false;
        }

        if (person.DateOfBirth > DateTime.UtcNow)
        {
            return false;
        }

        if (DateTime.UtcNow.Year - person.DateOfBirth.Year >= 135)
        {
            return false;
        }
        
        return true;
    }
}
