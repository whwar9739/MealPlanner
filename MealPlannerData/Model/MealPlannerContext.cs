using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Model;

public partial class MealPlannerContext : DbContext
{
    public MealPlannerContext()
    {
    }

    public MealPlannerContext(DbContextOptions<MealPlannerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Instruction> Instructions { get; set; }

    public virtual DbSet<InstructionIngredient> InstructionIngredients { get; set; }

    public virtual DbSet<MealPlan> MealPlans { get; set; }

    public virtual DbSet<PlannedMeal> PlannedMeals { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:MealPlannerDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("PK__Ingredie__B0E453CFAE346E7C");

            entity.Property(e => e.IngredientId)
                .ValueGeneratedNever()
                .HasColumnName("ingredient_id");
            entity.Property(e => e.CaloriesPerUnit).HasColumnName("calories_per_unit");
            entity.Property(e => e.CarbsPerUnit).HasColumnName("carbs_per_unit");
            entity.Property(e => e.FatPerUnit).HasColumnName("fat_per_unit");
            entity.Property(e => e.IngredientName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ingredient_name");
            entity.Property(e => e.ProteinPerUnit).HasColumnName("protein_per_unit");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitOfMeasure)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unit_of_measure");
        });

        modelBuilder.Entity<Instruction>(entity =>
        {
            entity.HasKey(e => e.InstructionId).HasName("PK__Instruct__4FC97B74FDBB4545");

            entity.Property(e => e.InstructionId)
                .ValueGeneratedNever()
                .HasColumnName("instruction_id");
            entity.Property(e => e.InstructionText)
                .HasColumnType("text")
                .HasColumnName("instruction_text");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.StepNumber).HasColumnName("step_number");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Instructions)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__Instructi__recip__3B75D760");
        });

        modelBuilder.Entity<InstructionIngredient>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.InstructionId).HasColumnName("instruction_id");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitOfMeasure)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unit_of_measure");

            entity.HasOne(d => d.Ingredient).WithMany()
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("FK__Instructi__ingre__412EB0B6");

            entity.HasOne(d => d.Instruction).WithMany()
                .HasForeignKey(d => d.InstructionId)
                .HasConstraintName("FK__Instructi__instr__403A8C7D");
        });

        modelBuilder.Entity<MealPlan>(entity =>
        {
            entity.HasKey(e => e.PlanId).HasName("PK__MealPlan__BE9F8F1DA071B716");

            entity.Property(e => e.PlanId)
                .ValueGeneratedNever()
                .HasColumnName("plan_id");
            entity.Property(e => e.MealDate).HasColumnName("meal_date");
            entity.Property(e => e.PlanName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("plan_name");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.ServingsPlanned).HasColumnName("servings_planned");

            entity.HasOne(d => d.Recipe).WithMany(p => p.MealPlans)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__MealPlans__recip__440B1D61");
        });

        modelBuilder.Entity<PlannedMeal>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.PlanId).HasColumnName("plan_id");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.ServingsPlanned).HasColumnName("servings_planned");

            entity.HasOne(d => d.Plan).WithMany()
                .HasForeignKey(d => d.PlanId)
                .HasConstraintName("FK__PlannedMe__plan___45F365D3");

            entity.HasOne(d => d.Recipe).WithMany()
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__PlannedMe__recip__46E78A0C");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__Recipes__3571ED9BD1AD4364");

            entity.Property(e => e.RecipeId)
                .ValueGeneratedNever()
                .HasColumnName("recipe_id");
            entity.Property(e => e.RecipeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("recipe_name");
            entity.Property(e => e.Servings).HasColumnName("servings");
            entity.Property(e => e.Source)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("source");
            entity.Property(e => e.TotalTime).HasColumnName("total_time");
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.UnitOfMeasure)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unit_of_measure");

            entity.HasOne(d => d.Ingredient).WithMany()
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("FK__RecipeIng__ingre__3E52440B");

            entity.HasOne(d => d.Recipe).WithMany()
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__RecipeIng__recip__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
