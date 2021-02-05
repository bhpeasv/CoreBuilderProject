using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBuilderProject
{
    public class MyBuildManager
    {
        private Dictionary<string, BuildAgent> agents = new Dictionary<string, BuildAgent>();
        private Dictionary<string, int> agentLocks = new Dictionary<string, int>();

        public void AddAgent(string agentId, string solutionPath, int intervalSeconds)
        {
            solutionPath = solutionPath.ToLower();
            if (agents.ContainsKey(agentId))
            { 
                throw new ArgumentException("Agent id already in use [{0}]", agentId);
            }
            if (!agentLocks.ContainsKey(solutionPath))
            { 
                agentLocks.Add(solutionPath, 0);
            }
            var agentLock = ++agentLocks[solutionPath];
            agents[agentId] = new BuildAgent(agentId, solutionPath, intervalSeconds, agentLock);
            Console.WriteLine("Number of agents " + agents.Count);
            Console.WriteLine("Number of locks "+ agentLocks.Count);
        }

        public void RemoveAgent(string agentId)
        {
            if (!agents.ContainsKey(agentId))
                throw new ArgumentException("Unknown Agent id [{0}]", agentId);
            BuildAgent agent = agents[agentId];
            agent.Cancel();

            var agentLock = --agentLocks[agent.BuildPath.ToLower()];
            if (agentLock == 0)
            { 
                agentLocks.Remove(agent.BuildPath.ToLower());
            }
            agents.Remove(agentId);
            Console.WriteLine("Number of agents " + agents.Values.Count);
            Console.WriteLine("Number of locks "+ agentLocks.Count);
        }
    }
}
