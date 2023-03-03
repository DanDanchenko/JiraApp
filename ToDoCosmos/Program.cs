/* using Microsoft.EntityFrameworkCore;

using var context = new StoryContext();
context.Database.EnsureCreated();

var user1 = new User
{
    Name = "Daniel"
};



var Olexandr = new User
{
    Name = "Olexandr"
};
var Dmytro = new User
{
    Name = "Dmytro"
};


   

var subtask1 = new Subtask
{
    Name = "Update Windows",
    Description = "Upadate my PC to Windows 11",
    Assignee = user1,
    IsDone = false

};

var subtask2 = new Subtask
{
    Name = "Azure Database",
    Description = "Create a simple database, using Azure Cosmos DB + .NET",
    Assignee = user1,
    IsDone = false

};

var subtask3 = new Subtask
{
    Name = "Algorithms",
    Description = "Estimate the complexity of the algorithm for filter system",
    Assignee = user1,
    IsDone = false

};

var subtaskForAlex1 = new Subtask
{
    Name = "Processor",
    Description = "Replace the CPU",
    Assignee = Olexandr,
    IsDone = false
};

var subtaskForAlex2 = new Subtask
{
    Name = "RAM",
    Description = "Add 2 modules of RAM",
    Assignee = Olexandr,
    IsDone = false
};

var subtaskForAlex3 = new Subtask
{
    Name = "Videoadapter",
    Description = "Replace the videoadapter",
    Assignee = Olexandr,
    IsDone = false
};

var DmytroSubtask1 = new Subtask
{
    Name = "Statistics",
    Description = "Create a program for math statistics using Python and Numpy library",
    Assignee = Dmytro,
    IsDone = false
};

var DmytroSubtask2 = new Subtask
{
    Name = "Clients",
    Description = "Discuss the product with customers",
    Assignee = Dmytro,
    IsDone = false
};




UserStory DanielStory = new UserStory();
DanielStory.Name = "Daniel task story";
DanielStory.Description = "Task story of the Daniel user";
DanielStory.Assignee = user1;
DanielStory.IsDone = false;
DanielStory.Subtasks.Add(subtask1);
DanielStory.Subtasks.Add(subtask2);
DanielStory.Subtasks.Add(subtask3);

context.Stories.Add(DanielStory);
context.SaveChanges();

UserStory OlexandrStory = new UserStory();
OlexandrStory.Name = "Olexandr story";
OlexandrStory.Description = "Task story of the Olexandr user";
OlexandrStory.Assignee = Olexandr;
OlexandrStory.IsDone = false;
OlexandrStory.Subtasks.Add(subtaskForAlex1);
OlexandrStory.Subtasks.Add(subtaskForAlex2);
OlexandrStory.Subtasks.Add(subtaskForAlex3);

context.Stories.Add(OlexandrStory);
context.SaveChanges();

UserStory DmytroStory = new UserStory();
DmytroStory.Name = "Dmytro story";
DmytroStory.Description = "Task story of the Dmytro user";
DmytroStory.Assignee = Dmytro;
DmytroStory.IsDone = false;
DmytroStory.Subtasks.Add(DmytroSubtask1);
DmytroStory.Subtasks.Add(DmytroSubtask2);

context.Stories.Add(DmytroStory);
context.SaveChanges();





//var DanielStory = new UserStory
//{





//};


public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
}






public class Subtask
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public User Assignee { get; set; }
    public bool IsDone { get; set; }

}

/*public class UserStory
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public User Assignee { get; set; }
    public bool IsDone { get; set; }

    public List<Subtask> Subtasks = new List<Subtask>();
}*/

/*
public class StoryContext : DbContext
{
    public DbSet<UserStory> Stories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Subtask> Subtasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos("https://to-to-app.documents.azure.com:443/", "2WC08KkMPPBoMgVUBkp4KWwTIGwlEokDbIEOR7T40DgCXk1nAzPHmY2hSmSiqcjzeVAFRK5wmmKsACDbWXq9qg==", "ToDoAPIUpdated");
        base.OnConfiguring(optionsBuilder);
    }

}
*/