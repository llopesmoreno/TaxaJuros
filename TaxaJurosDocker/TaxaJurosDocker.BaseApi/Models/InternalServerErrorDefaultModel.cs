using System;

namespace TaxaJurosDocker.BaseApi.Models
{
    public class InternalServerErrorDefaultModel
    {
        public InternalServerErrorDefaultModel()
        {
            Valid = false;
            Protocol = Guid.NewGuid();
            Message = new string[]
            {
                "Ops, an error occurred! Contact us and send us the protocol for more information."
            };  
        }

        public bool Valid { get; private set; }
        public string[] Message { get; private set; }
        public Guid Protocol { get; private set; }
    }
}
