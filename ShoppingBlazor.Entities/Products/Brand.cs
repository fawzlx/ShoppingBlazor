﻿using ShoppingBlazor.Entities.Common;

namespace ShoppingBlazor.Entities.Products;

public class Brand : BaseEntity<short>
{
    public required string Name { get; set; }

    public IEnumerable<Stuff>? Stuffs { get; set; }
}