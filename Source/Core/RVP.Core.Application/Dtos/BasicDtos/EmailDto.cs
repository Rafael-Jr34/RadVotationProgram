

namespace RVP.Core.Domain.Entities.BasicDtos
{
    public abstract  class EmailDto: LastNameDto
    {
        public required string Email { get; set; }
    }

}
