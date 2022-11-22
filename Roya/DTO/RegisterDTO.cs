namespace Roya.DTO
{
    public class RegisterDTO
    {
        public string Name { get; set; }    
        public string Email { get; set; }
        public string PhoneNumper { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public IFormFile imgNmae { get; set; }

    }
}
