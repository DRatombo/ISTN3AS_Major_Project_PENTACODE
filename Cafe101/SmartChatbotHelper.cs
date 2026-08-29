using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe101
{
    public static class SmartChatbotHelper
    {
        // Business knowledge
        private static Dictionary<string, string> BusinessKnowledge = new Dictionary<string, string>
        {
            { "order_time", "Most orders are ready within 15-25 minutes, depending on the complexity. Combo meals take about 18 minutes, while individual items like fries take 5-7 minutes." },
            { "delivery", "We currently offer delivery through our partners. Delivery typically takes 30-45 minutes depending on your location." },
            { "operating_hours", "We are open Monday to Friday from 7:00 AM to 10:00 PM, and weekends from 8:00 AM to 11:00 PM." },
            { "popular_items", "Our most popular items are the Chicken Burger, Beef Burger, and our signature Combo Meal. The Cooldrink is also a customer favorite." },
            { "payment_methods", "We accept cash, credit/debit cards, and mobile payments (Apple Pay, Google Pay)." },
            { "catering", "Yes! We offer catering for events. Please contact our manager to discuss your requirements." },
            { "loyalty_program", "We have a loyalty program where customers earn points for every purchase. 100 points = a free drink!" },
            { "cafe101_brand", "Cafe101 is a modern restaurant focused on quality, fresh ingredients, and excellent customer service." },
            { "manager_contact", "You can reach our manager, Zenande Mbeki, at zenandem@cafe101.com or call us at (031) 555-0199." },
            { "reservation", "We accept reservations for groups of 6 or more. Please call us at least 24 hours in advance." }
        };

        // System knowledge (how to use the system)
        private static Dictionary<string, string> SystemKnowledge = new Dictionary<string, string>
        {
            // General system
            { "system_purpose", "Cafe101 is a restaurant management system that helps you manage employees, ingredients, menu items, recipes, and orders." },
            
            // Employees
            { "add_employee", "To add an employee: Open the Employees form, fill in First Name, Surname, Email, Address, Role, and Password. Click 'Add'. All fields must be valid (green)." },
            { "update_employee", "To update an employee: Click a row in the list, edit the fields, and click 'Update'." },
            { "delete_employee", "To delete an employee: Select the employee, click 'Delete', and confirm the deletion." },
            { "reset_password", "To reset an employee's password: Select the employee, click 'Reset PW', and the password will reset to 'temp123'." },
            { "employee_validation", "First Name and Surname accept letters only. Email must contain '@' and a valid domain. Password must be at least 6 characters. Address format: number street, suburb, city." },
            
            // Ingredients
            { "add_ingredient", "To add an ingredient: Open the Ingredients form, fill in Description, Quantity On Hand, Restock Level, and Cost Price. Click 'Add New'." },
            { "update_ingredient", "To update an ingredient: Click a row, edit the fields, and click 'Update'." },
            { "delete_ingredient", "To delete an ingredient: Select the ingredient, click 'Remove', and confirm." },
            { "low_stock", "Ingredients with Quantity On Hand at or below their Restock Level turn YELLOW. These need to be reordered." },
            { "ingredient_validation", "Description accepts only letters and spaces (no numbers or special characters)." },
            
            // Menu Items
            { "add_menuitem", "To add a menu item: Open the Menu Items form, fill in Name, Selling Price, Cost Price, Category, and Preparation Time. Click 'Add New'. You must then add at least one recipe ingredient." },
            { "update_menuitem", "To update a menu item: Click a row, edit the fields, and click 'Update'." },
            { "delete_menuitem", "To delete a menu item: Select the item, click 'Deactivate', and confirm. The item will be removed from the menu." },
            { "menuitem_validation", "Name accepts only letters and spaces. Prep Time accepts only numbers (1-999 minutes)." },
            { "recipe_required", "A menu item cannot be saved without at least one recipe ingredient. You will be redirected to the Recipes form after adding a menu item." },
            { "categories", "Menu item categories are: Burger, Wings, Sides, Drinks, and Combo." },
            
            // Recipes
            { "add_recipe", "To add a recipe link: Select a Menu Item, select an Ingredient, enter Quantity, and click 'Add'." },
            { "remove_recipe", "To remove a recipe link: Select a menu item and ingredient, then click 'Remove'." },
            { "edit_recipe", "To edit a recipe quantity: Click a row in the recipe list, change the quantity, click 'Remove' then 'Add' with the new quantity." },
            { "recipe_purpose", "Recipes connect menu items to ingredients with specific quantities. This determines what ingredients are needed to make each menu item." },
            
            // General navigation
            { "search", "All forms have a search box. Type any keyword and results filter automatically as you type. Click 'Clear' to reset." },
            { "help", "Each form has a 'Help' button. Click it to see step-by-step instructions specific to that form." },
            { "back", "Use the 'Back' button to return to the main menu." },
            { "refresh", "Use the 'Refresh' button to reload all data and clear any active filters." }
        };

        // User context
        private static string LastTopic = "";

        public static string GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return "Please ask me something!";

            string input = userInput.ToLower().Trim();

            if (IsGreeting(input))
                return "👋 Hello! I'm the Cafe101 Assistant. I can help you with questions about the restaurant AND how to use the system. What would you like to know?";

            if (IsGoodbye(input))
                return "👋 Goodbye! Feel free to ask if you need any more help.";

            if (IsThanks(input))
                return "😊 You're welcome! Anything else I can help with?";

            string response = DetectIntent(input);

            if (!string.IsNullOrEmpty(response))
            {
                LastTopic = input;
                return response;
            }

            return "🤔 I'm not sure I understand. Here are some things I can help with:\n\n" +
                   "• Orders and delivery\n" +
                   "• Menu items and popular dishes\n" +
                   "• How to add, update, or delete records\n" +
                   "• How to search and use the system\n" +
                   "• Business hours and contact information\n\n" +
                   "Try asking me a specific question!";
        }

        private static bool IsGreeting(string input)
        {
            string[] greetings = { "hello", "hi", "hey", "howdy", "good morning", "good afternoon", "good evening", "yo" };
            return greetings.Any(g => input.Contains(g));
        }

        private static bool IsGoodbye(string input)
        {
            string[] goodbyes = { "bye", "goodbye", "see you", "cya", "later", "exit", "quit", "done" };
            return goodbyes.Any(g => input.Contains(g));
        }

        private static bool IsThanks(string input)
        {
            string[] thanks = { "thank", "thanks", "thx", "appreciate" };
            return thanks.Any(t => input.Contains(t));
        }

        private static string DetectIntent(string input)
        {
            // ===== BUSINESS INTENTS =====

            if (input.Contains("order") && (input.Contains("how long") || input.Contains("time") || input.Contains("ready") || input.Contains("take")))
                return GetBusinessInfo("order_time") + "\n\n💡 Tip: Complex orders like combos take about 18 minutes.";

            if (input.Contains("delivery") || input.Contains("deliver"))
                return GetBusinessInfo("delivery");

            if (input.Contains("hour") || input.Contains("open") || input.Contains("close") || input.Contains("operating") || input.Contains("time"))
                return GetBusinessInfo("operating_hours");

            if (input.Contains("popular") || input.Contains("best") || input.Contains("favorite") || input.Contains("top"))
                return GetBusinessInfo("popular_items");

            if (input.Contains("pay") || input.Contains("card") || input.Contains("cash") || input.Contains("mobile") || input.Contains("apple") || input.Contains("google"))
                return GetBusinessInfo("payment_methods");

            if (input.Contains("cater") || input.Contains("event"))
                return GetBusinessInfo("catering");

            if (input.Contains("loyalty") || input.Contains("points") || input.Contains("reward"))
                return GetBusinessInfo("loyalty_program");

            if (input.Contains("manager") || input.Contains("contact") || input.Contains("phone") || input.Contains("email"))
                return GetBusinessInfo("manager_contact");

            if (input.Contains("reservation") || input.Contains("book") || input.Contains("group"))
                return GetBusinessInfo("reservation");

            if (input.Contains("cafe101") || input.Contains("brand") || input.Contains("restaurant"))
                return GetBusinessInfo("cafe101_brand");

            // ===== SYSTEM INTENTS =====

            if (input.Contains("employee") || input.Contains("staff") || input.Contains("user"))
            {
                if (input.Contains("add") || input.Contains("create") || input.Contains("new"))
                    return GetSystemInfo("add_employee");
                if (input.Contains("update") || input.Contains("edit") || input.Contains("change"))
                    return GetSystemInfo("update_employee");
                if (input.Contains("delete") || input.Contains("remove"))
                    return GetSystemInfo("delete_employee");
                if (input.Contains("password") || input.Contains("pw") || input.Contains("reset"))
                    return GetSystemInfo("reset_password");
                if (input.Contains("validation") || input.Contains("format") || input.Contains("valid"))
                    return GetSystemInfo("employee_validation");
                return "📋 For employees, you can:\n• Add new employees\n• Update employee details\n• Delete employees\n• Reset passwords\n• Search for employees\n\nWhat specifically would you like to know?";
            }

            if (input.Contains("ingredient") || input.Contains("stock") || input.Contains("inventory") || input.Contains("supply"))
            {
                if (input.Contains("add") || input.Contains("create") || input.Contains("new"))
                    return GetSystemInfo("add_ingredient");
                if (input.Contains("update") || input.Contains("edit") || input.Contains("change"))
                    return GetSystemInfo("update_ingredient");
                if (input.Contains("delete") || input.Contains("remove"))
                    return GetSystemInfo("delete_ingredient");
                if (input.Contains("low") || input.Contains("restock") || input.Contains("warning") || input.Contains("yellow"))
                    return GetSystemInfo("low_stock");
                if (input.Contains("validation") || input.Contains("format"))
                    return GetSystemInfo("ingredient_validation");
                return "📦 For ingredients, you can:\n• Add new ingredients\n• Update stock levels\n• Remove ingredients\n• Monitor low stock (yellow rows)\n\nWhat do you need help with?";
            }

            if (input.Contains("menu") || input.Contains("item") || input.Contains("dish") || input.Contains("food"))
            {
                if (input.Contains("add") || input.Contains("create") || input.Contains("new"))
                    return GetSystemInfo("add_menuitem");
                if (input.Contains("update") || input.Contains("edit") || input.Contains("change"))
                    return GetSystemInfo("update_menuitem");
                if (input.Contains("delete") || input.Contains("remove") || input.Contains("deactivate"))
                    return GetSystemInfo("delete_menuitem");
                if (input.Contains("category"))
                    return GetSystemInfo("categories");
                if (input.Contains("validation") || input.Contains("format"))
                    return GetSystemInfo("menuitem_validation");
                if (input.Contains("recipe") || input.Contains("ingredient"))
                    return GetSystemInfo("recipe_required");
                return "🍔 For menu items, you can:\n• Add new menu items (requires a recipe)\n• Update prices and details\n• Deactivate menu items\n• Categorize items\n\nWhat specific help do you need?";
            }

            if (input.Contains("recipe"))
            {
                if (input.Contains("add") || input.Contains("create") || input.Contains("new"))
                    return GetSystemInfo("add_recipe");
                if (input.Contains("remove") || input.Contains("delete"))
                    return GetSystemInfo("remove_recipe");
                if (input.Contains("edit") || input.Contains("change") || input.Contains("update") || input.Contains("quantity"))
                    return GetSystemInfo("edit_recipe");
                if (input.Contains("purpose") || input.Contains("what") || input.Contains("why"))
                    return GetSystemInfo("recipe_purpose");
                return "📋 For recipes, you can:\n• Add links between menu items and ingredients\n• Remove links\n• Edit quantities\n\nWhat do you want to know about recipes?";
            }

            if (input.Contains("search") || input.Contains("find") || input.Contains("filter"))
                return GetSystemInfo("search");

            if (input.Contains("help"))
                return GetSystemInfo("help");

            if (input.Contains("back") || input.Contains("return"))
                return GetSystemInfo("back");

            if (input.Contains("refresh") || input.Contains("reload"))
                return GetSystemInfo("refresh");

            if (input.Contains("system") && (input.Contains("what") || input.Contains("purpose") || input.Contains("does")))
                return GetSystemInfo("system_purpose");

            return "";
        }

        private static string GetBusinessInfo(string key)
        {
            return BusinessKnowledge.ContainsKey(key) ? BusinessKnowledge[key] : "I don't have that information yet. Please speak to a manager.";
        }

        private static string GetSystemInfo(string key)
        {
            return SystemKnowledge.ContainsKey(key) ? SystemKnowledge[key] : "I don't have that information yet. Try using the Help button on the form.";
        }
    }
}