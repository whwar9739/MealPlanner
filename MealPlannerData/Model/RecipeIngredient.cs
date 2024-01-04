using System;
using System.Collections.Generic;

namespace MealPlanner.Model;

public partial class RecipeIngredient
{
    public int? RecipeId { get; set; }

    public int? IngredientId { get; set; }

    public double? Quantity { get; set; }

    public string? Notes { get; set; }

    public string? UnitOfMeasure { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
