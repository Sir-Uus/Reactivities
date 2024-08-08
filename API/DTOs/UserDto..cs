namespace API.DTOs
{
    public class UserDto
    {
        public required string DisplayName {get;set;}
        public required string Token {get;set;}
        public required string Image {get;set;}
        public required string UserName {get;set;}
    }
}