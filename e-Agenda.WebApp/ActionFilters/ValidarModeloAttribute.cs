using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace e_Agenda.WebApp.ActionFilters;



public class ValidarModeloAttribute : ActionFilterAttribute
{
    override public void OnActionExecuting(ActionExecutingContext context)
    {
        var modelState = context.ModelState;

        if (!modelState.IsValid)
        {
            var controller = (Controller)context.Controller;

            var viewModel = context.ActionArguments
                .Values.FirstOrDefault(x => x.GetType().Name.EndsWith("ViewModel"));

            var view = controller.View(viewModel);
        } 
    }
}

