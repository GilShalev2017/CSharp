using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

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

/*
This C# code defines a system for managing users, teams, and notifications. The primary goal of the code is to process mentions (of both individual users and entire teams) in a message update and then notify all relevant users without sending duplicate messages to anyone.
Here is a step-by-step explanation of what the code does:
1.Data Structures and Initial Setup
The code defines three main classes:
User: Represents an individual user with an id, name, and an array of teams they belong to.
Mention: Represents a reference within a message, specifying if it's a "user" or "team" type and its corresponding id.
Two static dictionaries hold the program's data:
users: A lookup table where the key is the User ID and the value is the User object itself. This starts populated with 4 example users.
teamUsers: This dictionary is initially empty. It's intended to store the reverse relationship: Key = Team ID, Value = A List of User IDs who belong to that team.
2. The Initial Data Processing (Main method)
The Main method is the entry point of the program. Its first action is to populate the teamUsers dictionary:
It iterates through all User objects present in the users dictionary.
For each user, it iterates through their list of teams.
The Core Logic: It checks if the teamId already exists as a key in teamUsers.
If the team ID is new, it creates a new empty list of integers for that team ID and adds the current user's ID to it.
If the team ID already exists, it simply adds the current user's ID to the existing list.
This block effectively builds a reverse index, making it easy to quickly find all members of any given team later.
3. Notification Logic (NotifyAll, GetMentions, Notify)
The program flow then immediately calls NotifyAll(null).
NotifyAll(string update)
This is the central function for distributing messages.
GetMentions(""): It first calls GetMentions. This function currently has hardcoded behavior, returning a fixed array of three mentions:
User with ID 1
User with ID 2
Team with ID 3
Processing Mentions: It iterates through the array of mentions:
If the mention type is "user", the user's ID is added directly to a temporary userIds list.
If the mention type is "team", it looks up that teamId in the teamUsers dictionary (which was populated in Main) and adds every user ID in that team's list to the temporary userIds list.
Removing Duplicates: The crucial step here is userIds.Select(x => x).Distinct().ToArray(). This ensures that even if a user is mentioned individually and is a member of a mentioned team (e.g., User 1 is in Team 3), they only appear once in the final list of recipients.
Notify(...): The unique list of recipient IDs and the message (update, which is null in this run) are passed to the Notify function.
Notify(int[] userIds, string message)
This function handles the actual output/sending of the message.
It iterates through the provided unique userIds.
It uses the users dictionary to look up the user's name for a friendly display.
It prints a message to the console for each unique recipient.
Summary of Execution
When you run this code:
teamUsers is populated.
NotifyAll is called.
Mentions are processed for User 1, User 2, and Team 3.
User 1 is mentioned directly.
User 2 is mentioned directly.
Team 3 contains User 1, User 2, and User 4 (based on the data setup).
The final unique list of users to notify is: User 1, User 2, and User 4.
The console will output the following lines:
text
user user1 received a message 
user user2 received a message 
user user4 received a message 
*/