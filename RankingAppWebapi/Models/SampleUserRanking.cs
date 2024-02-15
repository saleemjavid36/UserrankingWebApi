using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RankingAppWebapi.Models;

public partial class SampleUserRanking
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Ranking { get; set; }
}
