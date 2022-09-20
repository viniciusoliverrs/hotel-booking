namespace Application.Guest.DTO
{
    public class GuestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string IdNumber { get; set; }
        public int DocumentType { get; set; }

        public static Domain.Entities.Guest MapToEntity(GuestDTO guestDTO)
        {
            return new Domain.Entities.Guest()
            {
                Id = guestDTO.Id,
                Name = guestDTO.Name,
                Surname = guestDTO.Surname,
                Email = guestDTO.Email,
                Document = new Domain.ValueObjects.PersonId
                {
                    IdNumber = guestDTO.IdNumber,
                    DocumentType = (Domain.Enums.DocTypesEnum) guestDTO.DocumentType,
                }
            };
        }
    }
}
