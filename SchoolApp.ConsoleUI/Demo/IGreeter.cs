using System.Collections.Generic;

namespace SchoolApp.ConsoleUI.Demo
{
    public interface IGreeter
    {
        void EnumerateFromAppSettings();
        void Greet(IEnumerable<object> objs);
    }
}