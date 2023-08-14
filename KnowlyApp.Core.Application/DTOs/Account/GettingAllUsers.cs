namespace KnowlyApp.Core.Application.DTOs.Account
{
    //Busca los usuarios activados y desactivados
    public class GettingAllUsers
    {
        public string Id { get; set; }
        public bool isActive { get; set; }
    }
}