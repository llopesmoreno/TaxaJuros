using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using TaxaJurosDocker.BaseApi.Models;
using TaxaJurosDocker.Application.Util;

namespace TaxaJurosDocker.Api.Util
{
    public static class ControllerExtension
    {
        public static ActionResult GetResponse<T>(this ControllerBase controller, INotifier notifier, object response = null)
        {
            if (notifier.AnyNotification())
                return controller.BadRequest(new BadRequestDefaultModel(notifier.GetMessageNotifications()));

            return controller.Ok(JsonConvert.SerializeObject(new SuccessRequestResponseDefault<T>(ConvertObject<T>(response))));
        }

        private static I ConvertObject<I>(object response)
        {
            if (response is I i)
                return i;

            try
            {
                return (I)System.Convert.ChangeType(response, typeof(I));
            }
            catch (System.InvalidCastException)
            {
                throw;
            }
        } 
    }
}
