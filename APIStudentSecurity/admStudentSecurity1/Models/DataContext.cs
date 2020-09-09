namespace admStudentSecurity1.Models
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection") //constructor
        {

        }

        public System.Data.Entity.DbSet<admStudentSecurity1.Models.Student> Students { get; set; }
    }
}