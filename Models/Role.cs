﻿namespace HelpDeskApi.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public IList<User> Users { get; set; }
    }
}
