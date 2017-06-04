﻿namespace PhotoShare.Client.Core
{
    using System;

    public class Engine
    {
        private readonly CommandDispatcher commandDispatcher;

        public Engine(CommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        public void Run()
        {
            while (true)
            {
                Console.Write("$ ");
                try
                {
                    string input = Console.ReadLine().Trim();
                    string[] data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string result = this.commandDispatcher.DispatchCommand(data);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
