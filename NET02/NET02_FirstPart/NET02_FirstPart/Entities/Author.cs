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
                CheckFieldForEmptyOrLength(value);
                _firstName = value;
            }
        }

        public string SecondName
        {
            get => _secondName;
            set
            {
                CheckFieldForEmptyOrLength(value);
                _secondName = value;
            }
        }

        public Author(string firstName, string secondName)
        {
            FirstName = firstName.ToLower();
            SecondName = secondName.ToLower();
        }

        public override bool Equals(object obj) => (obj is Author author) && author.FirstName == FirstName &&
                                                   author.SecondName == SecondName;

        public override int GetHashCode() => FirstName.GetHashCode() + SecondName.GetHashCode();

        private static void CheckFieldForEmptyOrLength(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException();
            if (value.Length > MaxLength)
                throw new ArgumentException($"Argument must be less than {MaxLength} symbols.");
        }
    }
}
