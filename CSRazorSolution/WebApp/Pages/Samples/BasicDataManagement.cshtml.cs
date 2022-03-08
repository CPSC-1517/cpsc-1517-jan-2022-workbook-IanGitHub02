using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class BasicDataManagementModel : PageModel
    {
        // Create bound properties that are directly tied to a control on the form
        // Bound properties have the data automatically transferred from the control into the property
        [BindProperty]
        public int Num { get; set; }
        [BindProperty]
        public string FavouriteCourse { get; set; }
        [BindProperty]
        public string Comments { get; set; }

        // Annotation TempData is required IF you are processing multiple requests (OnPost followed by OnGet)
        // to retain data within the property
        //[TempData]
        public string FeedBack { get; set; }

        public void OnGet()
        {
            // Executes for a Get request
            // The first item the page is requested an automatic Get request is sent
            // Excellent "event" to use to do any initialization to your web page display as the page is shown for the first time
        }
        public void OnPost()
        {
            // Proccess the OnPost request (method="post")
            // The returndatatype can be void or IActionResult
            // The InPost request is the request from a <button> that has NOT indicated
            // a specific process Post using the asp-page-handler
            // Logic that your wish to accomplish shoulb be isolated to the actions desired for the button
            FeedBack = $"Number {Num}, Course {FavouriteCourse} Comments {Comments}";
        }
        public void OnPostA()
        {
            // Proccess the OnPost request (method="post")
            // This method is called due to the helper-tag on the form button
            // The "string" used on the helper-tag asp-page-handler="string" is add to the OnPost method name
            FeedBack = $"Button A was pressed";
        }
        public void OnPostB()
        {
            // Proccess the OnPost request (method="post")
            // This method is called due to the helper-tag on the form button
            // The "string" used on the helper-tag asp-page-handler="string" is add to the OnPost method name
            FeedBack = $"Button B was pressed";
        }
    }
}
