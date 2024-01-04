using System;
using System.Collections.Generic;

namespace MealPlanner.Model;

public partial class InstructionIngredient
{
    public int? InstructionId { get; set; }

    public int? IngredientId { get; set; }

    public double? Quantity { get; set; }

    public string? Notes { get; set; }

    public string? UnitOfMeasure { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual Instruction? Instruction { get; set; }
}
