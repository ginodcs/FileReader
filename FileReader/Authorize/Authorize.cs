namespace FileReader
{
    public static class Authorize
    {
        public static bool HasPermission(Roles role, Permissions permission)
        {
            if(role == Roles.Admin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}