using Htf2022.Deelbezems.Infrastructure;
using System.Collections.Generic;
using System.Text.Json;

namespace Htf2022.Deelbezems.Models
{
    public class BezemEventHandler : IBezemEventHandler
    {
        public Task Handle(string data, CancellationToken cancellationToken)
        {
            Message serializer = JsonSerializer.Deserialize<Message>(data);
            checkIfExisting(serializer);
            return Task.CompletedTask;
        }
        public bool checkIfExisting(Message message)
        {
            foreach (Message item in Bezems.bezems)
            {
                if (item.Bezem.Id == message.Bezem.Id) //bestaat al
                {
                    item.StatusType = message.StatusType;
                    item.Positie = message.Positie;
                    item.BrandstofLevel = message.BrandstofLevel;
                    item.Timestamp = message.Timestamp;
                    item.KastId = message.KastId;
                    return true;
                }
            }
            Bezems.bezems.Add(message);
            return false;
        }
    }
}
