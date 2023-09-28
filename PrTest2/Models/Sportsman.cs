using System;
using System.Collections.Generic;

namespace PrTest2.Models;

public partial class Sportsman
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public int Sport { get; set; }

    public int Nationality { get; set; }

    public int Age { get; set; }

    public int? Weight { get; set; }

    public int? Height { get; set; }

    public virtual Nation NationalityNavigation { get; set; } = null!;

    public virtual TypesOfSport SportNavigation { get; set; } = null!;
}
