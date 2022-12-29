﻿using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;

using System.Collections.Generic;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(MasonrySkill), 7)]
    public partial class CementWithWetTailingsRecipe : RecipeFamily
    {
        public CementWithWetTailingsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Cement",  //noloc
                displayName: Localizer.DoStr("Cement"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedLimestoneItem), 2f, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                    new IngredientElement(typeof(TailingsItem), 1f, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                
                    new IngredientElement(typeof(ClayItem), 1f, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<CementItem>(2),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1f; // Defines how much experience is gained when crafted.

            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(70, typeof(MasonrySkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(CementWithWetTailingsRecipe), start: 1f, skillType: typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Exotic Salad"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Cement"), recipeType: typeof(CementWithWetTailingsRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(CementKilnObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}