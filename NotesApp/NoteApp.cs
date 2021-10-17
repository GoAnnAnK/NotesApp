using System;
using Microsoft.Extensions.DependencyInjection;
using Domain.Services;
using Persistence;
using Persistence.Models;

namespace NotesApp
{
    public class NoteApp
    {
        private readonly INotesService _notesService;
        public NoteApp(INotesService notesService)
        {
            _notesService = notesService;
        }
        public void Start()
        {
            string text;
            string title;
            int id;
            var input = 10;


            while (input != 6)
            {
                Console.WriteLine(
                "------UZRASAI. \n Pasirinkite : \n" +
                "1 - Parodyti visus uzrasus; \n" +
                "2 - Padaryti nauja irasa; \n" +
                "3 - Redaguoti pasirinkta irasa; \n" +
                "4 - Istrinti pasirinkta irasa; \n" +
                "5 - Istrinti viska; \n" +
                "6 - Uzdaryti.  \n " +
                "Jusu pasirinkimas: ");

                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1: //parodyti viska

                        var allNotes = _notesService.GetAll();
                        foreach (var note in allNotes)
                        {
                            Console.WriteLine(note);
                        }

                        break;

                    case 2: //Naujas irasas

                        Console.WriteLine("Iveskite ID: \n");
                        id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Iveskite uzraso  pavadinima: \n");
                        title = Console.ReadLine();

                        Console.WriteLine("Iveskite teksta: \n");
                        text = Console.ReadLine();

                        _notesService.Create(new Note
                        {
                            Id = id,
                            DateCreated = DateTime.Now,
                            Title = title,
                            Text = text
                        });


                        break;

                    case 3: // redaguoti pasirinkta


                        Console.WriteLine("Iveskite ID: ");
                        id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Iveskite antraste: ");
                        title = Console.ReadLine();

                        Console.WriteLine("Iveskite uzrasa: ");
                        text = Console.ReadLine();


                        _notesService.Edit(id, text, title);

                        break;

                    case 4: // trinti viena irasa
                        Console.WriteLine("Iveskite iraso ID, kuri norite pasalinti \n");
                        id = int.Parse(Console.ReadLine());

                        _notesService.DeleteById(id);
                        break;

                    case 5: //Trinti viska

                        _notesService.ClearAll();
                        break;

                    case 6:  //Isejimas
                        input = 6;
                        Console.WriteLine("\n Sekmes!!! Lauksiu nauju irasu... ");
                        break;
                }
            }
        }
    }
}

