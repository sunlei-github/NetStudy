using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {

        /// <summary>
        /// 获取要保护的资源
        /// </summary>
        /// <returns></returns>
        public static List<ApiResource> GetProtecdApiResource()
        {
            return new List<ApiResource>()
            {
                new ApiResource ("bookApi","要保护的Api资源"){ Scopes={ "bookScope" } }
            };
        }

        /// <summary>
        /// 添加资源访问的范围
        /// </summary>
        /// <returns></returns>
        public static List<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope("bookScope","访问范围")
            };
        }

        /// <summary>
        /// 获取可信的客户端
        /// </summary>
        /// <returns></returns>
        public static List<Client> GetTrustingClients()
        {
            return new List<Client>()
            {
                new Client ()
                {
                    //可信的客户端Id
                    ClientId="client",

                    //授权类型 ClientCredentials 只有客户端认证
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    
                    //认证的密码
                    ClientSecrets =
                    {
                    new Secret("secret".Sha256())
                    },

                    //允许访问的资源
                    AllowedScopes={ "bookScope" }
                }
            };
        }
    }
}
