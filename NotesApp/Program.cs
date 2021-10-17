using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace NotesApp
    {
    class Program
    {
        /* UZDUOTIS
         * - Sukurti aplikaciją - "Užrašų knygutė"
        - Užrašus saugome faile "notes.txt"
        - "Note" klasė turi:
        - Id
        - DateCreated
        - Title
        - Text
        Galimos komandos konsolėje:
        - Show all notes - nuskaito visus užrašus iš failo ir atvaizduoja konsolėje užrašo ID ir Title.Pasirinkus konkretų užrašą išvedama visa užrašo informacija.
        - Add note - įvedamas užrašo "Title" ir "Text" ir jis išsaugomas faile
        - Edit note - pakoreguoja esama užrašą ir išsaugo pakeitimus faile
        - Delete note - ištrina konkretų esama užrašą iš failo
        - Delete all notes - ištrina visus užrašus iš failo*/
        static void Main(string[] args)
        {

            var startup = new Startup();

            var serviceProvider = startup.ConfigureServices();

            var notesApp = serviceProvider.GetService<NoteApp>();

            /* var fileService = serviceProvider.GetService<FileClient>();

             var notes = fileService.ReadAll<Note>("notes.txt");

             foreach (var note in notes)
             {
                 Console.WriteLine(note);
             }*/

            notesApp.Start();

            //       galim iskviesti konkretu ojekta :
            //       var fileService = serviceProvider.GetService<IFileClient>()
            //       var notes = filesService.ReadAll<Note>("notes.txt");
            //    forech (var note in NotesRepository){
            //      Console.WriteLine(note);   }


        }
    }
}
