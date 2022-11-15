using Htf2022.Deelbezems.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Htf2022.Deelbezems.Controllers
{
    [Route("kasten")]
    [ApiController]
    public class KastenController : ControllerBase
    {
        [HttpGetAttribute]
        [ProducesResponseType(200, Type = typeof(List<String>))]
        public async Task<IActionResult> Index()
        {
            List<VisuableMessage> messages = new List<VisuableMessage>();
            foreach (Message item in Bezems.bezems)
            {
                VisuableMessage visuableMessage = new VisuableMessage();
                visuableMessage.bezemId = item.Bezem.Id;
                visuableMessage.statusType = item.StatusType;
                visuableMessage.positie = item.Positie;
                visuableMessage.brandstofLevel = item.BrandstofLevel;
                visuableMessage.kastId = item.KastId;

                messages.Add(visuableMessage);
            }
            List<KastMessage> kastMessages = new List<KastMessage>();
            Kasten kasten = new Kasten();
            List<Kast> kasts = new List<Kast>(); //alle kasten
            kasts = await kasten.getData();      
            foreach (Kast item in kasts)
            {
                int capaciteit = item.maxCapaciteit;
                foreach (Message bezem in Bezems.bezems)
                {
                    if (item.id == bezem.KastId)    //kijken of id gelijk zijn
                    {
                        item.maxCapaciteit--;               //plaatje minde
                    }
                }
                KastMessage kastMessage = new KastMessage() 
                { capaciteit = item.maxCapaciteit, kastId = item.id };
                kastMessages.Add(kastMessage);
            }

            
            return Ok(kastMessages);
        }
    }
}
