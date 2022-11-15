
using System.Net;
using System;
using System.Text.Json;


namespace Htf2022.Deelbezems.Models
{
    public class Kasten : IKasten
    {
        public async Task<List<Kast>> getData()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("api-key", "369bf6dc627cb08e1be726e6add27ebe");
            client.DefaultRequestHeaders.Add("team-key", "cscherp");

            //  HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.deelbezems.net/kasten");

            var items = new List<Kast>();
            List<Kast> serializer = new List<Kast>();
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                serializer = JsonSerializer.Deserialize<List<Kast>>(content);               
            }
           /* List<KastMessage> messages = new List<KastMessage>();
            foreach (Kast item in serializer)
            {
                KastMessage message = new KastMessage();
                message.kastId = item.id;
                message.capaciteit = item.maxCapaciteit;
                messages.Add(message);
            } */
            return serializer;
        }
    }
}
