public class SurveyController : Controller
{
    public IActionResult DisplayForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult HandleFormSubmission(FormData formData)
    {
        if (ModelState.IsValid)
        {
            // Process form data
            return RedirectToAction("Success");
        }
        return View("DisplayForm");
    }
}
