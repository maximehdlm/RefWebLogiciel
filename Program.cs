using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RefWebLogiciel
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //chaine de connexion
            // string cs = "Server=localhost;Database=refweblogiciel;User Id=root;Password=;";

            //instancie un objet MySqlConnection
            // using var connection = new MySqlConnection(cs);

            //ouverture de la connexion a la base de données
            // connection.Open();

            // Console.WriteLine($"MySQL Version: {connection.ServerVersion}");

            //requete SQL
            // var stm = "SELECT VERSION()";

            //instancie un objet MySqlCommand
            // var cmd = new MySqlCommand(stm, connection);

            //retourne la premiere ligne de resultat et surtout la premiere colonne
            // var version = cmd.ExecuteScalar().ToString();
            // Console.WriteLine($"MySQL Version: {version}");

            // connection.Close();

            MyScheduler.IntervalInSeconds(12, 19, 5,
            () => {

                Console.WriteLine("Dispatch ok : " + DateTime.Now.ToString());
            });


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
