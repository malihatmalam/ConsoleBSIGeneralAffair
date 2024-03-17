using System.Data;

namespace MVCBSIGeneralAffairCosmetic.Helpers
{
    public static class Auth
    {
        public static bool CheckRole(string roleController, string roleUser) 
        {
            var roles = roleController.Split(',');
            foreach (var item in roles)
            {
                if (item == roleUser)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
