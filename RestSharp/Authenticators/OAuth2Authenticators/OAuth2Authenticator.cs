#region License
//   Copyright 2010 John Sheehan
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 
#endregion

namespace RestSharp
{
    /// <summary>
    /// Base class for OAuth 2 Authenticators.
    /// </summary>
    /// <remarks>
    /// Since there are many ways to authenticate in OAuth2,
    /// this is used as a base class to differentiate between 
    /// other authenticators.
    /// 
    /// Any other OAuth2 authenticators must derive from this
    /// abstract class.
    /// </remarks>
    public abstract class OAuth2Authenticator : IAuthenticator
    {
        /// <summary>
        /// Access token to be used when authenticating.
        /// </summary>
        private readonly string accessToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth2Authenticator"/> class.
        /// </summary>
        /// <param name="accessToken">
        /// The access token.
        /// </param>
        protected OAuth2Authenticator(string accessToken)
        {
            this.accessToken = accessToken;
        }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken
        {
            get
            {
                return accessToken;
            }
        }

        public abstract void Authenticate(IRestClient client, IRestRequest request);
    }
}
