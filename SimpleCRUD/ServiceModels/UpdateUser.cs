namespace SimpleCRUD.ServiceModels
{
    public class UpdateUser
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int RoleId { get; set; }

        public int StateId { get; set; }

        public string Address { get; set; } = null!;
    }
}
