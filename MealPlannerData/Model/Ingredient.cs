using System;
using System.Collections.Generic;

namespace MealPlanner.Model;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public string? IngredientName { get; set; }

    public double? CaloriesPerUnit { get; set; }

    public double? ProteinPerUnit { get; set; }

    public double? CarbsPerUnit { get; set; }

    public double? FatPerUnit { get; set; }

    public string? UnitOfMeasure { get; set; }

    public double? Quantity { get; set; }
}
