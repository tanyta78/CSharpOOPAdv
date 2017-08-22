﻿public abstract class Mission:IMission
    {
    public Mission(string name, double enduranceRequired, double scoreToComplete, double wearLevelDecrement)
    {
        this.Name = name;
        this.EnduranceRequired = enduranceRequired;
        this.ScoreToComplete = scoreToComplete;
        this.WearLevelDecrement = wearLevelDecrement;
    }

        public string Name { get; }
        public double EnduranceRequired { get; }
        public double ScoreToComplete { get; }
        public double WearLevelDecrement { get; }
    }

