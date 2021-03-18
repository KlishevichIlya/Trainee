using System;

namespace NET02_FirstPart.Entities
{
    public class Author
    {
        private const int MaxLength = 200;

        private string _firstName;
        private string _secondName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                CheckFieldValue(value);
                CheckFieldLength(value);
                _firstName = value;
            }
        }

        public string SecondName
        {
            get => _secondName;
            set
            {
                CheckFieldValue(value);
                CheckFieldLength(value);
                _secondName = value;
            }
        }

        public Author(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }

        private static void CheckFieldLength(string value)
        {
            if (value?.Length > MaxLength)
                throw new ArgumentException($"Argument must be less than {MaxLength} symbols.");
        }

        private static void CheckFieldValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value)) throw new ArgumentException();
        }
    }
}
