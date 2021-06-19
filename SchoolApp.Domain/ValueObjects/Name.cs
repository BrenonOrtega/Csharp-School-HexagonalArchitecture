using SchoolApp.Domain.ValueObjects.Exceptions;

namespace SchoolApp.Domain.ValueObjects
{
    public class Name
    {
        private readonly string _text;

        public Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new EmptyNameException($"field { nameof(Name) } is required. ");

            _text = text;
        }

        public static implicit operator Name(string text) => new Name(text);
        public static implicit operator string(Name name) => name.ToString();

        public override string ToString() => _text;

        public override int GetHashCode() => _text.GetHashCode();

        public override bool Equals(object obj)
        {
            var areEquals =  obj is string text && this._text == text
                            || obj is Name name && this._text == name._text
                            || ReferenceEquals(obj, this)
                            ;
            return areEquals;
        }
    }
}