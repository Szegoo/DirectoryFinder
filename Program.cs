using System;
using System.IO;

namespace DirectoryFinder
{
	class Program
	{
		public static int count = 0;
		public static bool Check(string dirName, string skip)
		{
			string[] skipList = skip.Split(' ');
			foreach (string dir in skipList)
			{
				if (dirName.Contains(dir))
				{
					return false;
				}
			}
			return true;
		}
		public static void CheckDirectory(string input, string directory, string user, string skip)
		{
			try
			{
				string[] dirs = Directory.GetDirectories($"{directory}", $"{input}*", SearchOption.TopDirectoryOnly);
				foreach (string dir in dirs)
				{
					Console.WriteLine(dir);
					count++;
				}
				foreach (string dir in Directory.GetDirectories($"{directory}"))
				{
					if (skip == "" || Check(dir, skip))
						CheckDirectory(input, dir, user, skip);
				}
			}
			catch (Exception err)
			{

			}
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Directory Finder is running");
			System.Console.WriteLine("Enter your username [windows-user-name]:");
			System.Console.Write("> ");
			string username = Console.ReadLine();
			System.Console.WriteLine("Enter start letters of the direcotry name:");
			System.Console.Write("> ");
			string input = Console.ReadLine();
			System.Console.WriteLine("Enter the direcotry names that you want to skip[like node_modules][separate them by space]: ");
			System.Console.Write("> ");
			string skip = Console.ReadLine();
			CheckDirectory(input, $"C:/Users/{username}/", username, skip);
			Console.WriteLine($"The number of directories starting with {input} is {count}.");
		}
	}
}
