﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FeedKitchen.Entities.Models;

public partial class Author
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}