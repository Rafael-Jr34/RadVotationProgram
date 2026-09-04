
namespace RVP.Core.Domain.Entities.BasicViewModels
{
   public abstract class BasicViewModel
    {
        public required int Id { get; set; }
        public required bool IsActive { get; set; }
        // this have 2 purpose  
        // 1- to know if the entity is deleted if is false or
        // 2- to know if the entity is active or not if is true

    }
}
