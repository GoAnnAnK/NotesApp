using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;
using Persistence.Models;
using Persistence.Repositories;

namespace Domain.Services
{
    public class NotesService : INotesService

    {
        private readonly List<string> _swearWords;
        private readonly INotesRepository _notesRepository;
        private readonly IFileClient _fileClient;

        public NotesService(INotesRepository notesRepository, IFileClient fileClient)
        {
            _notesRepository = notesRepository;
            _fileClient = fileClient;
            _swearWords = new List<string>
            {
                "vienas",
                "Kazkas",
                "Kazkur"
            };
        }
        public IEnumerable<Note> GetAll()
        {
            var allNotes = _notesRepository.GetAll();
            var validNotes = allNotes.Where(Note => Note.Text.Length >= 1);

            return validNotes;

            //  return _notesRepository.GetAll();
        }

        public void Create(Note note)
        {
            var isNoteInvalid = _swearWords.Any(swearWord => note.Text.Contains(swearWord));
            if (isNoteInvalid)
            {
                throw new Exception("Note is invalid");
            }
            _notesRepository.Save(note);
        }
        public void Edit(int id, string title, string text)
        {
            _notesRepository.Edit(id, title, text);
        }

        public void DeleteById(int id)
        {
            _notesRepository.Delete(id);
        }
        public void ClearAll()
        {
            _notesRepository.DeleteAll();
        }


    }
}
