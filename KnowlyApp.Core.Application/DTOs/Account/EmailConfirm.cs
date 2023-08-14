namespace KnowlyApp.Core.Application.DTOs.Account
{
    //Email confimado, devuelve el id y un token que valide
    public class EmailConfirm
    {
        public string UserId { get; set; }
        public int Token { get; set; }
        public string De { get; set; }
    }
}