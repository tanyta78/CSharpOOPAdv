using System;
using System.Linq;
using System.Reflection;

public class MissionFactory:IMissionFactory
    {
        public IMission CreateMission(string missionType, double scoreToComplete)
        {
            Type typeOfMission = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals(missionType, StringComparison.OrdinalIgnoreCase));

            object[] typeArgs = new object[] { scoreToComplete };

            IMission defaultMission = (IMission)Activator.CreateInstance(typeOfMission, typeArgs);

            return defaultMission;
        
        }
}

