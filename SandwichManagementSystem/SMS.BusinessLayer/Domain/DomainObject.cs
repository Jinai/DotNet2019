using SMS.Shared.Exceptions;

namespace SMS.BusinessLayer.Domain
{
    public abstract class DomainObject
    {
        public int Id { get; set; }

        public virtual void CheckValidity()
        {
            if (Id < 0)
            {
                throw new DomainException("Domain Id must be a positive integer.");
            }
        }
    }
}
