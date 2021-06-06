using System.Collections.Generic;

namespace firstDataAccess.Demo
{
    public interface IGreeter
    {
        void EnumerateFromAppSettings();
        void Greet(IEnumerable<object> objs);
    }
}