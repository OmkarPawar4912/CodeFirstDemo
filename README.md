#) Package :-
		1) Microsoft.EntityFrameworkCore.SqlServer (3.1.21)
		2) Microsoft.EntityFrameworkCore.Tools (3.1.21)
		3) Microsoft.VisualStudio.Web.CodeGeneration.Design (3.1.5)

#) Add Folder :-
		1) Entities => Create Class Entities(ex :- Student.cs & Division.cs)
		2) Data => Create Class For DBContext (ex :- ApplicationDbContext.cs)		
````
		using DemoRepoPattern.Entities;
		using Microsoft.EntityFrameworkCore;

		namespace DemoRepoPattern.Data
		{
			public class ApplicationBDContext : DbContext
			{
				public ApplicationBDContext(DbContextOptions<ApplicationBDContext> options) : base(options)
				{

				}

				public DbSet<Student> Students { get; set; }
				public DbSet<Division> Divisions { get; set; }
			}
		}
 ```` 	
		 
#) Added Connection String in Appsetting & added DataBase Name
````
		{
		  "Logging": {
			"LogLevel": {
			  "Default": "Information",
			  "Microsoft": "Warning",
			  "Microsoft.Hosting.Lifetime": "Information"
			}
		  },
		  "ConnectionStrings": {
			"DefaultConnection": "Data Source=IN-OMKAR;Initial Catalog=DemoRepoDB;Integrated Security=True"
		  },
		  "AllowedHosts": "*"
		}
````
#) Set up in Startup.cs File :-
		1) using Microsoft.EntityFrameworkCore; NameSpace
		2) ConfigureServices Method added Below Lines (ConnectionStrings)	
````
		 services.AddDbContext<ApplicationBDContext>(o =>
					 o.UseSqlServer(
						 Configuration.GetConnectionString("DefaultConnection")
					 ));
````
#) Create DataBase
		1) Goto Menubar View => Other Window => Package Manger Console (PM)
		2) Add-Migration CreateDB (Your Chpoices) (Its add Migrations Folder in Solutions)
		3) Update-DataBase

#) Add view Using Scaffolding
		1) Right click on Controller => Add => Select New Scaffolded Item
		2) Select MCV Controller with views, using Entity Framework
		3) Select Model Class & Data context class & click on Add btn
#) Repository Pattern
		1) Create Interface "IRepository.cs" in interface Folder(if not exit create folder)
````
			using System;
			namespace DemoRepoPattern.Interfaces
			{
				public interface IRepository<T> : IDisposable where T : class
				{
					void Add(T entity);
					void Remove(T entity);
					int SaveChanges();
				}
			}
````
		2)  Create Interface "IStudentRepository.cs"  in interface Folder 


			using DemoRepoPattern.Entities;
			namespace DemoRepoPattern.Interfaces
			{
				public interface IStudentRepository : IRepository<Student>
				{

				}
			}

#) Implementation
		1) create class "Repository.cs" in Implementations Folder(if not exit create folder)
		2) Inheritance IRepository.cs and implementations all Method
		3) Create constructor and pass Parameter of ApplicationDbContext dbContext(DataBase)
````
			using EFDBFirstApproach.Data;
			using EFDBFirstApproach.Interfaces;
			using Microsoft.EntityFrameworkCore;
			using System;

			namespace EFDBFirstApproach.Implementations
			{
				public class Repository<T> : IRepository<T> where T : class
				{
					protected readonly ApplicationDbContext _context;
					protected readonly DbSet<T> _dbSet;

					public Repository(ApplicationDbContext dbContext)
					{
						_context = dbContext;
						_dbSet = _context.Set<T>();
					}

					public void Add(T obj)
					{
						_dbSet.Add(obj);
					}

					public int SaveChanges()
					{
						var result = _context.SaveChanges();
						return result;
					}

					public void Dispose()
					{
						_context.Dispose();
						GC.SuppressFinalize(this);
					}
				}
			}
````
		4) Create a class "StudentRepository.cs" and Inheritance the  Repository<Student> and IStudentRepository
		5) Create constructor of class
````
			using EFDBFirstApproach.Data;
			using EFDBFirstApproach.Entities;
			using EFDBFirstApproach.Interfaces;
			using Microsoft.EntityFrameworkCore;

			namespace EFDBFirstApproach.Implementations
			{
				public class StudentRepository : Repository<Students>, IStudentRepository
				{
					public StudentRepository(ApplicationDbContext context) : base(context)
					{
					}
				}
			}
````
#) Startup.cs
		1) add this line in ConfigureServices Method
````
			services.AddTransient<IStudentRepository, StudentRepository>();
````
#) Student Controller
		1) create private obj and add to class constructor this IStudentRepository
````
		private readonly IStudentRepository _studentRepository;
        private readonly ApplicationBDContext _context;
		
		public StudentsController(IStudentRepository studentRepository, ApplicationBDContext context)
        {
            _studentRepository=studentRepository;
            _context = context;
        }
````
