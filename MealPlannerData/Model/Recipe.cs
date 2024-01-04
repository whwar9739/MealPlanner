using System;
using System.Collections.Generic;

namespace MealPlanner.Model;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public string? RecipeName { get; set; }

    public int? TotalTime { get; set; }

    public string? Source { get; set; }

    public int? Servings { get; set; }

    public virtual ICollection<Instruction> Instructions { get; set; } = new List<Instruction>();

    public virtual ICollection<MealPlan> MealPlans { get; set; } = new List<MealPlan>();
}
