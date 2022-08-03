using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcFiliere.Models;
using MvcStudent.Models;
using MvcCour.Models;
using MvcNote.Models;

    public class MvcSchoolContext : DbContext
    {
        public MvcSchoolContext (DbContextOptions<MvcSchoolContext> options)
            : base(options)
        {
        }
        
        public DbSet<MvcFiliere.Models.Filiere> Filiere { get; set; } = default!;
        public DbSet<MvcStudent.Models.Student> Student { get; set; } = default!;
        public DbSet<MvcCour.Models.Cour> Cour { get; set; } = default!;
        public DbSet<MvcNote.Models.Note> Note { get; set; } = default!;

    }
