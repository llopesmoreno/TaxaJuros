using System.Linq;
using FluentValidation.Results;
using System.Collections.Generic;

namespace TaxaJurosDocker.Application.Util
{
    public interface INotifier
    {
        bool AnyNotification();
        List<Notification> Notifications();
        string[] GetMessageNotifications();
        void Add(string mensagem);
        void Add(IEnumerable<string> mensagens);
        void Add(IEnumerable<ValidationFailure> validationFailures);
        void ClearNotifications();
    }

    public class Notification
    {
        public Notification(string message)
        {
            Mensagem = message;
        }

        public string Mensagem { get; }
    }

    public class Notifier : INotifier
    {
        private List<Notification> _notifications = new List<Notification>();
        
        public void Add(string message) => _notifications.Add(new Notification(message));
        
        public void Add(IEnumerable<string> message)
        {
            var messageRange = message.Select(mensagem => new Notification(mensagem));
            _notifications.AddRange(messageRange);
        }

        public void Add(IEnumerable<ValidationFailure> validationFailures)
        {
            var message = validationFailures.Select(v => v.ErrorMessage);
            var objetos = message.Select(m => new Notification(m));
            _notifications.AddRange(objetos);
        }

        public void ClearNotifications() => _notifications = new List<Notification>();

        public string[] GetMessageNotifications() => _notifications.Select(n => n.Mensagem).ToArray();
        
        public List<Notification> Notifications() => _notifications;
        
        public bool AnyNotification() =>  _notifications.Any();        
    }
}