//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

public partial class eLibraryDBEntities : DbContext
{
    public eLibraryDBEntities()
        : base("name=eLibraryDBEntities")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<Admin_Table> Admin_Table { get; set; }
    public virtual DbSet<Author_Table> Author_Table { get; set; }
    public virtual DbSet<Book_Table> Book_Table { get; set; }
    public virtual DbSet<CharityFund_Table> CharityFund_Table { get; set; }
    public virtual DbSet<Contributor_Table> Contributor_Table { get; set; }
    public virtual DbSet<Defaulter_Table> Defaulter_Table { get; set; }
    public virtual DbSet<IssuedBook_Table> IssuedBook_Table { get; set; }
    public virtual DbSet<Member_Table> Member_Table { get; set; }
    public virtual DbSet<Publisher_Table> Publisher_Table { get; set; }
}
