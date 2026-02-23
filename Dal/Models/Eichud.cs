using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Eichud
{
    public int EichudCode { get; set; }

    public string? Tohar { get; set; }

    public string? FamilyName { get; set; }

    public string? FirstName { get; set; }

    public string? Ending { get; set; }

    public string? FathersName { get; set; }

    public string? Shtibel { get; set; }

    public string? Street { get; set; }

    public string? House { get; set; }

    public string? City { get; set; }

    public int? ZipCode { get; set; }

    public string? HousePhone { get; set; }

    public string? CellPhone { get; set; }

    public string? Shver { get; set; }

    public virtual Volunteer? Volunteer { get; set; }

    public virtual ICollection<Volunteering> Volunteerings { get; set; } = new List<Volunteering>();
}
