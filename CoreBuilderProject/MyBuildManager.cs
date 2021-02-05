using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBuilderProject
{
    public class MyBuildManager
    {
        private Dictionary<string, BuildAgent> agents = new Dictionary<string, BuildAgent>();

        public void AddAgent(string agentId, string solutionPath, int intervalSeconds)
        {
            if (agents.ContainsKey(agentId))
                throw new ArgumentException("Agent id already in use [{0}]", agentId);
            agents[agentId] = new BuildAgent(agentId, solutionPath, intervalSeconds);
        }

        public void RemoveAgent(string agentId)
        {
            if (!agents.ContainsKey(agentId))
                throw new ArgumentException("Unknown Agent id [{0}]", agentId);
            agents[agentId].Cancel();
            agents.Remove(agentId);
        }
    }
}
