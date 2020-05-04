namespace Common.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Poco;

    public class NamesModel : DbContext
    {
        // Your context has been configured to use a 'NamesModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataBaseCon.NamesModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'NamesModel' 
        // connection string in the application configuration file.
        public NamesModel()
            : base("name=SqliteDB")
        {
        }
        public virtual DbSet<Name> Names { get; set; }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}