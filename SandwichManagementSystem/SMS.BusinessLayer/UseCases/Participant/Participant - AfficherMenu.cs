using SMS.BusinessLayer.Extensions;
using SMS.Shared;
using SMS.Shared.BTO;
using System.Collections.Generic;
using System.Linq;

namespace SMS.BusinessLayer.UseCases.Participant
{
    public partial class Participant
    {
        public List<SandwichBTO> AfficherMenu(string supplier, Language lang)
        {
            return SandwichRepo.GetAll().Select(x => x.ToBTO(lang)).ToList();
        }
    }
}
