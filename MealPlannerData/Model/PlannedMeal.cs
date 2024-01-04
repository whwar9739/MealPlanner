using System;
using System.Collections.Generic;

namespace MealPlanner.Model;

public partial class PlannedMeal
{
    public int? PlanId { get; set; }

    public int? RecipeId { get; set; }

    public int? ServingsPlanned { get; set; }

    public virtual MealPlan? Plan { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
