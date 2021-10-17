using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IFileClient
    {


        IEnumerable<T> ReadAll<T>(string fileName);

        void Append<T>(string filename, T item);
        void WriteAll<T>(string fileName, IEnumerable<T> items);

        void DeleteFileContents(string fileName);
    }
}
