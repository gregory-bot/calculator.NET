using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TipCalculatorRazorApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Meal cost is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Meal cost must be greater than 0.")]
        public decimal MealCost { get; set; }

        public decimal Tip10 { get; set; }
        public decimal Tip15 { get; set; }
        public decimal Tip20 { get; set; }

        public void OnGet()
        {
            // Initialize the page with default values
            MealCost = 0;
            Tip10 = 0;
            Tip15 = 0;
            Tip20 = 0;
        }

        public IActionResult OnPostCalculate()
        {
            if (ModelState.IsValid)
            {
                // Calculate the tip amounts
                Tip10 = MealCost * 0.10m;
                Tip15 = MealCost * 0.15m;
                Tip20 = MealCost * 0.20m;
            }
            else
            {
                // Reset tip values on validation errors
                Tip10 = 0;
                Tip15 = 0;
                Tip20 = 0;
            }

            return Page();
        }

        public IActionResult OnPostClear()
        {
            // Reset the form to initial values
            ModelState.Clear();
            MealCost = 0;
            Tip10 = 0;
            Tip15 = 0;
            Tip20 = 0;

            return Page();
        }
    }
}
