using System;
using System.Collections.Generic;

namespace MealPlanner.Model;

public partial class Instruction
{
    public int InstructionId { get; set; }

    public int? RecipeId { get; set; }

    public int? StepNumber { get; set; }

    public string? InstructionText { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
