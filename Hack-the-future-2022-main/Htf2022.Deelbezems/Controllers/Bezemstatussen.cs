using Htf2022.Deelbezems.Infrastructure;
using Htf2022.Deelbezems.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Htf2022.Deelbezems.Controllers
{
    [Route("bezemstatussen")]
    [ApiController]
    public class Bezemstatussen : ControllerBase
    {
        private readonly IBezemEventHandler _eventHandler;

        public Bezemstatussen(IBezemEventHandler bezemEventHandler)
        {
            _eventHandler = bezemEventHandler;
        }

        [HttpGetAttribute]

        [ProducesResponseType(200, Type = typeof(List<String>))]
        public IActionResult Index()
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
            return Ok(messages);
            //return Ok(Bezems.bezems);
        }

    }
}
