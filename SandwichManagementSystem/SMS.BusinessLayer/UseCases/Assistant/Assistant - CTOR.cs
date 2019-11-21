using SMS.Shared.Interfaces;

namespace SMS.BusinessLayer.UseCases.Assistant
{
    public partial class Assistant : Participant
    {
        private IUnitOfWork UnitOfWork { get; }

        public Assistant(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
