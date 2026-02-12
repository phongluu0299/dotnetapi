using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace netCoreApi.Models;

public partial class Page
{
    public int PageId { get; set; }

    public int Parent { get; set; }

    public string Display { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Icon { get; set; }

    public string Api { get; set; } = null!;

    public string? Func { get; set; }

    public string? Route { get; set; }

    public string? Param { get; set; }

    public bool Hidden { get; set; }

    public int Sort { get; set; }

    public long? UserCreated { get; set; }

    public DateTime? DateCreated { get; set; }

    public long? UserModified { get; set; }

    public DateTime? DateModified { get; set; }
}
