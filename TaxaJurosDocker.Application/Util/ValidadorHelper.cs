using System.Linq;
using FluentValidation;
using System.Collections.Generic;

namespace TaxaJurosDocker.Application.Util
{
    public static class ValidadorHelper
    {
        public static bool InvalidObject<T>(this IEnumerable<T> obj, IValidator<T> validator, INotifier notifier)
        {
            obj.ToList().ForEach(item => InvalidObject(item, validator, notifier));            
            return notifier.AnyNotification();
        }

        public static bool InvalidObject<T>(this T obj, IValidator<T> validator, INotifier notificador)
        {
            var result = validator.Validate(obj);

            if (result.IsValid)
                return false;

            notificador.Add(result.Errors);

            return notificador.AnyNotification();
        }
    }
}
