using System;
using System.Collections.Generic;

namespace PrTest2.Models;

public partial class TypesOfSport
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Sportsman> Sportsmen { get; set; } = new List<Sportsman>();
    
}
