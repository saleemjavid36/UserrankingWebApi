using System;
using System.Collections.Generic;

namespace RankingAppWebapi.Models;

public partial class UserRanking
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Ranking { get; set; }
}
