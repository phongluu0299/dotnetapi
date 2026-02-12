using System;
using System.Collections.Generic;

namespace netCoreApi.Models;

public partial class User
{
    public long UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string? Email { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? Avatar { get; set; }

    public string? MainDeviceId { get; set; }

    public long? UserCreated { get; set; }

    public DateTime? DateCreated { get; set; }

    public long? UserModified { get; set; }

    public DateTime? DateModified { get; set; }
}
