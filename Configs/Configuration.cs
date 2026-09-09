using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace Desafio_Inoa.Configs
{
    public class Configuration
    {
        public IReadOnlyList<string> EmailList { get; }
        public string Host { get; }
        public string Port { get; }
        public string User { get; }
        public string Password { get; }

        private Configuration(
            IReadOnlyList<string> emailList, 
            string smtpHost,
            string smtpPort,
            string smtpUser,
            string smtpPassword)
        {
            EmailList = emailList;
            Host = smtpHost;
            Port = smtpPort;
            User = smtpUser;
            Password = smtpPassword;
        }

        private static Configuration _configuration;
        private static readonly object _lock = new object();


        public static Configuration GetInstance()
        {
            if (_configuration == null)
            {

                lock (_lock)
                {

                    if (_configuration == null)
                    {
                        string json = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "./Configs/appsettings.json"));

                        JsonNode configs = JsonNode.Parse(json) ?? throw new Exception("Não foi possível ler o arquivo de configuração.");

                        _configuration = new Configuration(
                            configs["emailList"].AsArray().Select(x => x.ToString()).ToList(),
                            configs["smtp"]["host"].ToString(),
                            configs["smtp"]["port"].ToString(),
                            configs["smtp"]["username"].ToString(),
                            configs["smtp"]["appPassword"].ToString()
                        );
                    }
                }
            }
            return _configuration;
        }

    }

}
