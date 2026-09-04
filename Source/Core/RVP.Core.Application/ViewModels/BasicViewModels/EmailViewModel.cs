

namespace RVP.Core.Domain.Entities.BasicViewModels
{
    public abstract  class EmailViewModel: LastNameViewModel
    {
        public required string Email { get; set; }
    }

}
