var Recipes = {
    ingredientCount: 1,
    recipeId: 0, 

    getAddRecipeView: function () {
        $.ajax({
            type: 'GET',
            url: 'Authentication/IsUserLoggedIn',
            success(response) {
                if (response == false) {
                    Authentication.login();
                }
                else {
                    window.location.href = "/Recipes/AddRecipe";
                }
            }
        });

        window.location.href = "/Recipes/AddRecipe";
    },

    addIngredient: function () {
        this.ingredientCount++;
        $("<div id=\"ingredient-" + this.ingredientCount + "\" class=\"ingredient-quantity\">" + 
            "<input id = \"ingredient-name-" + this.ingredientCount + "\" class=\"ingredient\" placeholder=\"Ingredient Name\"/>" + 
            "<input id = \"quantity-" + this.ingredientCount + "\" class=\"ingredient quantity\" placeholder=\"Quantity\"/></div>")
           .insertAfter("#ingredient-" + (this.ingredientCount - 1));
    },

    addRecipe: function () {
        var ingredients = [];
        for (var ingredient = 1; ingredient <= this.ingredientCount; ingredient++) {
            ingredients.push({
                name: $("#ingredient-name-" + ingredient).val(),
                quantity: $("#quantity-" + ingredient).val()
            });
        }

        var recipe = {
            name: $("#recipe-name").val(),
            ingredients: ingredients,
            instructions: $("#instructions").val()
        };

        $.ajax({
            type: 'POST',
            url: '/Recipes/AddRecipe',
            data: recipe,
            success: function (response) {
                Recipes.recipeId = response;
                myDropzone.on("sending", function (file, xhr, formData) {
                    formData.append("recipeId", Recipes.recipeId);
                });
                myDropzone.processQueue();
            },
            error: function () {}
        });
    },
   
    //viewRecipe: function (recipeId) {
    //    $.ajax({
    //        type: 'POST',
    //        url: '/Recipes/Recipe',
    //        data: { recipeId: recipeId },
    //        success: function () {
    //        },
    //        error: function () { }
    //    });
    //    window.location.href = '/Recipes/Recipe?recipeId=' + recipeId;
    //}
}
