using EFCore;
using EFCore.DATA;

using (var context = new BloggingContext())
{
    FirstStep(context);
}

void FirstStep(BloggingContext context)
{
    //Create
    Console.WriteLine("Inserting a new blog.");
    context.Blogs.Add(new EFCore.Blog { URL = "http://blogs.com" });
    context.SaveChanges();

    //READ
    Console.WriteLine("Querying for a blog");
    var blog = context.Blogs.First();
    var posts = context.Posts.Where(p => p.BlogId.Equals(1)).ToList(); 
    Console.WriteLine(blog.URL);

    //Update
    Console.WriteLine("Updating the blog and adding a post.");
    blog.URL = "https://facebook.com";
    blog.Posts.Add(new Post { Title="Hello World", Content = "My first EF Core app."});
    context.Posts.Add(new Post { Title = "Hola Mundo", Content = "Mi primera app con EF Core.", BlogId = 2 });
    context.SaveChanges();
}