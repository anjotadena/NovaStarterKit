﻿using Domain.Common;

namespace Domain.Entities;

public class Permission : BaseEntity<Guid>
{
    public string Name { get; set; } = string.Empty;

    public string Resource { get; set; } = string.Empty;

    public string Action { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
