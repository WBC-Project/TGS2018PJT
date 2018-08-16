using System;
using MySql.Data.MySqlClient;

namespace SQride.Domain
{

    /// <summary>
    /// Mysqlの接続を初期化します。
    /// </summary>
    public class MysqlConstruct
    {
        public MysqlConstruct()
        {
            
        }
    }
    
    /// <summary>
    /// 接続設定
    /// </summary>
    public struct Connection
    {
        private string host;
    
        public string Hots { get { return this.host; } }
        
        private string userId;

        public string UserId { get { return this.userId; } }
        
        private string password;

        public string Password { get { return this.password; } }

        private string dataBaseName;

        public string DataBaseName { get { return this.dataBaseName; } }
    }
}