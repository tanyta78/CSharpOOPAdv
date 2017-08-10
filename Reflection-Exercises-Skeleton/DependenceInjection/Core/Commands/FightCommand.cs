﻿using _03BarracksFactory.Contracts;
using System;

namespace _03BarracksFactory.Core.Commands
{
    public class FightCommand : Command
    {
        public FightCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return String.Empty;
        }

        
    }
}