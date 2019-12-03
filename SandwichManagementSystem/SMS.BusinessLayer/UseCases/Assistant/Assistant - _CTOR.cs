using SMS.Shared.Interfaces;
using System;

namespace SMS.BusinessLayer.UseCases.Assistant
{
    public partial class Assistant : Participant
    {
        private IUnitOfWork UnitOfWork { get; }

        public Assistant(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}
