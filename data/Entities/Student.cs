using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace dot7.API.Data.Entities;
public class Students
{
    // public Students(Guid iD, string firstname, string lastname, int? Age, string Gender)
    // {
    //     ID = iD;
    //     firstName = firstname;
    //     lastName = lastname;
    //     age = Age;
    //     gender = Gender;
    // }

    public Guid ID{ get; set; }=Guid.NewGuid();
    public string? firstName { get; set; }=string.Empty;
    public string? lastName { get; set; }=string.Empty;
    public int? age {get;set;}
    public string? gender{get;set;}=string.Empty;

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}