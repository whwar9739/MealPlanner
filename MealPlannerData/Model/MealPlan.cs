using System;
using System.Collections.Generic;

namespace MealPlanner.Model;

public partial class MealPlan
{
    public int PlanId { get; set; }

    public string? PlanName { get; set; }

    public DateOnly? MealDate { get; set; }

    public int? RecipeId { get; set; }

    public int? ServingsPlanned { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
