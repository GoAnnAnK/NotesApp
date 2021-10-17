using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Repositories;
using Persistence.Models;
using Domain.Services;





namespace NotesApp
{
    public class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();


            services.AddTransient<IFileClient, FileClient>();

            services.AddSingleton<INotesRepository, NotesRepository>();


            services.AddSingleton<INotesService, NotesService>();

            services.AddSingleton<NoteApp>();

            return services.BuildServiceProvider();
        }
    }
}
