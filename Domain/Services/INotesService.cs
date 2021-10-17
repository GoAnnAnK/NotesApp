using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;
using Persistence.Models;

namespace Domain.Services
{
    public interface INotesService
    {
        public IEnumerable<Note> GetAll();
        public void Create(Note note);
        public void Edit(int id, string title, string text);
        public void DeleteById(int id);
        public void ClearAll();

    }
}
