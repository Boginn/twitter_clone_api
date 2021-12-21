using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.Data.Interface;
using TwitterCloneAPI.Models;

namespace TwitterCloneAPI.Data.Repository
{
    public class TwitterRepository : IRepository
    {
        private readonly TwitterDatabaseContext _dbContext;
        public TwitterRepository()
        {
            _dbContext = new TwitterDatabaseContext();


            InitializeUsers();
            InitializeTweets();



        }

        public void InitializeUsers()
        {
            List<User> users = new List<User>() {
                new User() { Name = "Neo", Handle = "@theOne", Color = "blue" },
                new User() { Name = "Trinity", Handle = "@falconhoof", Color = "red" },
                new User() { Name = "Cypher", Handle = "@bliss", Color = "green" },
                new User() { Name = "Architect", Handle = "@father", Color = "white" },
            };


            foreach (User user in users)
            {
                bool validate = (_dbContext.Users.Where(
                    x => x.Name == user.Name ||
                    x.Handle == user.Handle)
                    .ToList().Count == 0);
                if (validate)
                {
                    _dbContext.Users.Add(user);
                    _dbContext.SaveChanges();
                }
            }
        }

        public void InitializeTweets()
        {
            List<Tweet> tweets = new List<Tweet>() {
                  new Tweet() { Content = "A tweet", Likes = 2, UserId = 1 },
                  new Tweet() { Content = "Subtle", Likes = 20, UserId = 2 },
                  new Tweet() { Content = "I´m in.", Likes = 4, UserId = 2 },
                  new Tweet() { Content = "I know Kung-Fu!", Likes = 666, UserId = 1 },
                  new Tweet() { Content = "Ignorance is bliss", Likes = 65, UserId = 3 },
                  new Tweet() { Content = "Which pill, yo?", Likes = 1234, UserId = 1 },
                  new Tweet() { Content = "I´d love a good steak", Likes = 65, UserId = 3 },
                  new Tweet() { Content = "Flipsides", Likes = 33, UserId = 2 },
                  new Tweet() { Content = "Smith... Agent Constructor?", Likes = 20, UserId = 1 },
                  new Tweet() { Content = "idk", Likes = 1, UserId = 2 },

            };


            foreach (Tweet tweet in tweets)
            {
                bool validate = (_dbContext.Tweets.Where(
                    x => x.Content == tweet.Content)
                    .ToList().Count == 0);
                if (validate)
                {
                    _dbContext.Tweets.Add(tweet);
                    _dbContext.SaveChanges();
                }
            }
        }


        // User
        public async Task<List<User>> GetAllUsersAsync()
        {
            using var db = _dbContext;
            return await db.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            using var db = _dbContext;
            return await db.Users.Include(x => x.Tweets).Include(x => x.Replies).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateUserAsync(User user)
        {
            using var db = _dbContext;

            bool validate = (
                db.Users.Where(x => x.Name == user.Name).ToList().Count != 0 || 
                db.Users.Where(x => x.Handle == user.Handle).ToList().Count != 0
                );

            if (validate) 
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            }

       

        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            using var db = _dbContext;
            User res = await db.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
            {
                return null;
            }

            res.Name = user.Name;
            res.Handle = user.Handle;

            await db.SaveChangesAsync();
            return res;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            using var db = _dbContext;
            User res = await db.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
            {
                return false;
            } else
            {
                db.Users.Remove(res);
                await db.SaveChangesAsync();
                return true;
            }
        }


        // Tweet
        public async Task<List<Tweet>> GetAllTweetsAsync()
        {
            using var db = _dbContext;
            return await db.Tweets.Include(x => x.Replies).ToListAsync();
        }

        public async Task<Tweet> GetTweetByIdAsync(int id)
        {
            using var db = _dbContext;
            return await db.Tweets.Include(x => x.Replies).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateTweetAsync(Tweet tweet)
        {
            using var db = _dbContext;
            await db.Tweets.AddAsync(tweet);
            await db.SaveChangesAsync();
        }

        public async Task<Tweet> UpdateTweetContentAsync(int id, Tweet tweet)
        {
            using var db = _dbContext;
            Tweet res = await db.Tweets.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
            {
                return null;
            }

            res.Content = tweet.Content;
            await db.SaveChangesAsync();
            return res;
        }

        public async Task<Tweet> UpdateTweetLikesAsync(int id)
        {
            using var db = _dbContext;
            Tweet res = await db.Tweets.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
            {
                return null;
            }

            res.Likes += 1;
            await db.SaveChangesAsync();
            return res;
        }
        public async Task<bool> DeleteTweetAsync(int id)
        {
            using var db = _dbContext;
            Tweet res = await db.Tweets.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
            {
                return false;
            }
            else
            {
                db.Tweets.Remove(res);
                await db.SaveChangesAsync();
                return true;
            }
        }

        // Reply
        /*
        public async Task<List<Reply>> GetAllRepliesAsync()
        {
            using var db = _dbContext;
            return await db.Replies.ToListAsync();
        }
        */
        public async Task<Reply> GetReplyByIdAsync(int id)
        {
            using var db = _dbContext;
            return await db.Replies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateReplyAsync(Reply reply)
        {
            using var db = _dbContext;
            await db.Replies.AddAsync(reply);
            await db.SaveChangesAsync();
        }

        public async Task<Reply> UpdateReplyContentAsync(int id, Reply reply)
        {
            using var db = _dbContext;
            Reply res = await db.Replies.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
            {
                return null;
            }

            res.Content = reply.Content;
            await db.SaveChangesAsync();
            return res;
        }

        public async Task<Reply> UpdateReplyLikesAsync(int id)
        {
            using var db = _dbContext;
            Reply res = await db.Replies.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
            {
                return null;
            }

            res.Likes += 1;
            await db.SaveChangesAsync();
            return res;
        }

        public async Task<bool> DeleteReplyAsync(int id)
        {
            using var db = _dbContext;
            Reply res = await db.Replies.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
            {
                return false;
            }
            else
            {
                db.Replies.Remove(res);
                await db.SaveChangesAsync();
                return true;
            }
        }











    }
}
