using System;

namespace WebShop.Model.Entities
{
    [Flags]
    public enum Role
    {
        None = 0,
        Admin = 1,
        Manager = 2,
        Accountant = 4,
        SupportService = 8
    }
}