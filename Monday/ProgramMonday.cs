using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Monday
{
    internal class Program
    {
        //The point is to build the teams out of the data

        //Create a dictionary that the key is the team id and the value is a list of user ids (list of ints)
        //Dictionary<string, List<int>> teamUsers

        public class User
        {
            public int id;
            public string name;
            public int[] teams;
        }

        public class Mention
        {
            public string type;//team/user
            public int id; //team/user
        }

        static Dictionary<int, User> users = new Dictionary<int, User> { 
            { 1, new User { id = 1, name = "user1", teams = new int[] { 1, 2, 3, 10 } } },
            { 2, new User { id = 2, name = "user2", teams = new int[] { 3, 10 } } },
            { 3, new User { id = 3, name = "user3", teams = new int[] { } } },
            { 4, new User { id = 4, name = "user4", teams = new int[] { 1, 2, 3,5 } } }
        };

        static Dictionary<int, List<int>> teamUsers = new Dictionary<int, List<int>>();

        static void Main(string[] args)
        {
            foreach (var user in users.Values)
            {
                foreach (var teamId in user.teams)
                {
                    if (!teamUsers.ContainsKey(teamId))
                    {
                        teamUsers.Add(teamId, new List<int>());
                        teamUsers[teamId].Add(user.id);
                    }
                    else
                    {
                        teamUsers[teamId].Add(user.id);
                    }
                }
            }

            NotifyAll(null);
        }

        //notify user about the message
        public static void Notify(int[] userIds, string message)
        {
            foreach (int userId in userIds)
            {
                if (users.ContainsKey(userId))
                {
                    Console.WriteLine("user " + users[userId].name + " received a message " + message);
                }
            }
        }

        public static Mention[] GetMentions(string update)
        {
            Mention[] mentions = new Mention[]
                {
                  new Mention{type="user", id=1 }, 
                  new Mention{type="user", id=2 },  
                  new Mention{type="team", id=3 },
                };
            return mentions;
        }

        //use GetMentions + Notify
        public static void NotifyAll(string update)
        {
            Mention[] mentions = GetMentions("");
            List<int> userIds = new List<int>();
        
            foreach(Mention mention in mentions)
            {
                if(mention.type == "user")
                {
                    userIds.Add(mention.id);
                }
                else // a team
                {
                    foreach (var userId in teamUsers[mention.id])
                    {
                        userIds.Add(userId);
                    }
                }
            }

            Notify(userIds.Select(x => x).Distinct().ToArray(), update);
           
        }
    }
}
