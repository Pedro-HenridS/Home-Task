namespace application.Interfaces.Group
{
    public interface IGroupExistService
    {
        public Task<bool> GroupExist(Guid groupId);
    }
}
