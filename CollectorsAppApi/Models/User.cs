using System;
using System.Collections.Generic;

namespace CollectorsAppApi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool Admin { get; set; }

    public byte[]? UserImage { get; set; }

    public class AddUserRequest
    {
        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool Admin { get; set; }

        public byte[]? UserImage { get; set; }
    }
    public class ViewUserResponse
    {
        public int UserId { get; set; }

        public string Login { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool Admin { get; set; }

    }
    
}
