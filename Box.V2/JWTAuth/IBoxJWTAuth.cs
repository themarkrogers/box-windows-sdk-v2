using Box.V2.Auth;

namespace Box.V2.JWTAuth
{
    public interface IBoxJWTAuth
    {
        /// <summary>
        /// Create admin BoxClient using an admin access token
        /// </summary>
        /// <param name="adminToken">Admin access token</param>
        /// <param name="asUser">The user ID to set as the 'As-User' header parameter; used to make calls in the context of a user using an admin token</param>
        /// <param name="suppressNotifications">Whether or not to suppress both email and webhook notifications. Typically used for administrative API calls. Your application must have “Manage an Enterprise” scope, and the user making the API calls is a co-admin with the correct "Edit settings for your company" permission.</param>
        /// <returns>BoxClient that uses JWT authentication</returns>
        BoxClient AdminClient(string adminToken, string asUser = null, bool? suppressNotifications = null);

        /// <summary>
        /// Create user BoxClient using a user access token
        /// </summary>
        /// <param name="userToken">User access token</param>
        /// <param name="userId">Id of the user</param>
        /// <returns>BoxClient that uses JWT authentication</returns>
        BoxClient UserClient(string userToken, string userId);

        /// <summary>
        /// Get admin token by posting data to auth url
        /// </summary>
        /// <returns>Admin token</returns>
        string AdminToken();

        /// <summary>
        /// Once you have created an App User, you can request a User Access Token via the App Auth feature, which will return the OAuth 2.0 access token for the specified App User.
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <returns>User token</returns>
        string UserToken(string userId);

        /// <summary>
        /// Create OAuth session from token
        /// </summary>
        /// <param name="token">Access token created by method UserToken, or AdminToken</param>
        /// <returns>OAuth session</returns>
        OAuthSession Session(string token);
    }
}
