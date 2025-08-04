using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartFormAutofillAnalyzer.Models;
using SmartFormAutofillAnalyzer.Services;

namespace SmartFormAutofillAnalyzer.Pages
{
    public class SmartFormModel : PageModel
    {
        private readonly GeminiFormService _geminiFormService;

        public SmartFormModel(GeminiFormService geminiFormService)
        {
            _geminiFormService = geminiFormService;
        }

        [BindProperty]
        public FormInput Input { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Input.UserInput))
            {
                ModelState.AddModelError(string.Empty, "Please enter a message.");
                return Page();
            }

            try
            {
                var result = await _geminiFormService.AnalyzeFormAsync(Input.UserInput);

                Input.Name = result.GetValueOrDefault("name", "");
                Input.Email = result.GetValueOrDefault("email", "");
                Input.Address = result.GetValueOrDefault("address", "");
                Input.Phone = result.GetValueOrDefault("phone", "");
                Input.Message = result.GetValueOrDefault("message", "");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error analyzing input: " + ex.Message);
            }

            return Page();
        }
    }
}
