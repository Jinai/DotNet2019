using SMS.Shared.Interfaces;
using System;

namespace SMS.BusinessLayer.UseCases
{
    public partial class Participant
    {
        private IUnitOfWork UnitOfWork { get; }

        public Participant(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}
