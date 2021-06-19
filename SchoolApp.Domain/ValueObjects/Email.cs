using System;
using System.Text.RegularExpressions;
using SchoolApp.Domain.ValueObjects.Exceptions;

namespace SchoolApp.Domain.ValueObjects
{
    public class Email
    {
        private readonly string _text;

        public Email(string address)
        {
            ThrowIfInvalid(address);
            _text = address;
        }

        public static implicit operator Email(string text) => new Email(text);

        public static implicit operator string(Email email) => email?._text;

        private static void ThrowIfInvalid(string text)
        {
            ThrowIfNullOrEmpty(text);
            ThrowIfFormatDoesntMatch(text);
        }

        public override string ToString() => _text.ToString();

        public override int GetHashCode() => _text.GetHashCode();

        public override bool Equals(object obj)
        {
            var areEquals =  obj is string text && this._text == text
                            || obj is Email email && this._text == email._text
                            || ReferenceEquals(obj, this)
                            ;
            return areEquals;
        }

        private static void ThrowIfNullOrEmpty(string text)
        {
            if(String.IsNullOrEmpty(text))
                throw new InvalidEmailException("Email cannot be empty.");
        }

        private static void ThrowIfFormatDoesntMatch(string text)
        {
            var pattern = @"(?i)^[a-z0-9.]+@[a-z0-9]+.(com|net|io){1}";
            var re = new Regex(pattern);

            if(re.IsMatch(text) != true)
                throw new InvalidEmailException("Invalid email format.");
        }

    }
}