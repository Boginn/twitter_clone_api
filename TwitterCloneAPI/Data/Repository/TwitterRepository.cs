using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.Data.Interface;
using TwitterCloneAPI.Models;
using TwitterCloneAPI.Models.DTO;

namespace TwitterCloneAPI.Data.Repository
{
    public class TwitterRepository : IRepository
    {
        private readonly TwitterDatabaseContext _dbContext;
        public TwitterRepository()
        {
            _dbContext = new TwitterDatabaseContext();
            /*
            if(_dbContext.Users.ToList().Count == 0 && 
                _dbContext.Tweets.ToList().Count == 0  && 
                _dbContext.Replies.ToList().Count == 0 &&
                _dbContext.TweetLikes.ToList().Count == 0 &&
                _dbContext.ReplyLikes.ToList().Count == 0)
            {
                InitializeUsers();
                InitializeTweets();
                InitializeReplies();
                InitializeTweetLikes();
                InitializeReplyLikes();
                InitializeFollows();
            }
            */






        }

        public void InitializeUsers()
        {
            List<User> users = new List<User>() {
                new User() { Name = "Neo", Handle = "@theOne", Color = "blue" },
                new User() { Name = "Trinity", Handle = "@falconhoof", Color = "red" },
                new User() { Name = "Cypher", Handle = "@bliss", Color = "green" },
                new User() { Name = "Architect", Handle = "@father", Color = "white" },
                new User() { Name = "Oracle", Handle = "@mom", Color = "black" },
                new User() { Name = "Morpheus", Handle = "@shepherd", Color = "indigo" },
                new User() { Name = "Agent Smith", Handle = "@chaos", Color = "grey" },



            };


            foreach (User user in users)
            {
                bool validated = (_dbContext.Users.Where(
                    x => x.Name == user.Name ||
                    x.Handle == user.Handle)
                    .ToList().Count == 0);
                if (validated)
                {
                    _dbContext.Users.Add(user);
                    _dbContext.SaveChanges();
                }
            }
        }

        public void InitializeTweets()
        {
            List<Tweet> tweets = new List<Tweet>() {
                  new Tweet() { Content = "What is 'real'? How do you define 'real'? If you’re talking about what you can feel, what you can smell, taste and see then 'real' is simply electrical signals interpreted by your brain.",
                      Hashtag = "woke", UserId = 6, Date = new DateTime(2020, 2, 3, 23, 24, 54).ToString() },
                  new Tweet() { Content = "Remember, all I’m offering is the truth. Nothing more.",
                      Hashtag = "woke",  UserId = 6, Date = new DateTime(2020, 2, 19, 22, 49, 37).ToString() },
                  new Tweet() { Content = "I´m in.",
                      Hashtag = "badass", UserId = 2, Date = new DateTime(2020, 2, 22, 19, 24, 6).ToString() },
                  new Tweet() { Content = "I know Kung-Fu!",
                      Hashtag = "badass",  UserId = 1, Date = new DateTime(2020, 3, 4, 14, 22, 48).ToString() },
                  new Tweet() { Content = "Ignorance is bliss",
                      Hashtag = "slept",  UserId = 3, Date = new DateTime(2020, 3, 16, 11, 32, 12).ToString() },
                  new Tweet() { Content = "You hear that Mr. Anderson? That is the sound of inevitability!",
                      Hashtag = "woke",  UserId = 7, Date = new DateTime(2020, 4, 13, 17, 47, 16).ToString() },
                  new Tweet() { Content = "I know what you’re thinking, ’cause right now I’m thinking the same thing. Actually, I’ve been thinking it ever since I got here: Why oh why didn’t I take the blue pill?",
                      Hashtag = "woke",  UserId = 3, Date = new DateTime(2020, 4, 20, 9, 41, 20).ToString() },
                  new Tweet() { Content = "I know why you're here, Neo. I know what you've been doing... why you hardly sleep, why you live alone, and why night after night, you sit by your computer. You're looking for him.",
                      Hashtag = "woke",  UserId = 2, Date = new DateTime(2020, 5, 10, 7, 22, 34).ToString() },
                  new Tweet() { Content = "Hope. It is the quintessential human delusion, simultaneously the source of your greatest strength and your greatest weakness",
                      Hashtag = "woke",  UserId = 4, Date = new DateTime(2020, 5, 15, 8, 5, 10).ToString() },
                  new Tweet() { Content = "Everything that has a beginning has an end. I see the end coming. I see the darkness spreading. I see death. And you are all that stands in his way.",
                      Hashtag = "woke", UserId = 5, Date = new DateTime(2020, 6, 1, 7, 47, 0).ToString() },

            };


            foreach (Tweet tweet in tweets)
            {
                bool validated = (_dbContext.Tweets.Where(
                    x => x.Content == tweet.Content)
                    .ToList().Count == 0);
                if (validated)
                {
                    _dbContext.Tweets.Add(tweet);
                    _dbContext.SaveChanges();
                }
            }
        }

        public void InitializeReplies()
        {
            List<Reply> replies = new List<Reply>() {
                  new Reply() { Content = "This is not",
                     UserId = 6, TweetId = 1, Date = new DateTime(2020, 2, 3, 23, 54, 44).ToString() },
                  new Reply() { Content = "Skelter!",
                      UserId = 2, TweetId = 2, Date = new DateTime(2020, 2, 19, 23, 42, 22).ToString() },
                  new Reply() { Content = "Sappy...",
                      UserId = 7, TweetId = 3, Date = new DateTime(2020, 2, 22, 20, 33, 8).ToString() },


            };


            foreach (Reply reply in replies)
            {
                bool validated = (_dbContext.Replies.Where(
                    x => x.Content == reply.Content)
                    .ToList().Count == 0);
                if (validated)
                {
                    _dbContext.Replies.Add(reply);
                    _dbContext.SaveChanges();
                }
            }
        }

        public void InitializeReplyLikes()
        {
            List<ReplyLike> replyLikes = new List<ReplyLike>() {
                  new ReplyLike() { UserId = 6, ReplyId = 1 },
                  new ReplyLike() { UserId = 3, ReplyId = 1 },
                  new ReplyLike() { UserId = 2, ReplyId = 1 },
                  new ReplyLike() { UserId = 5, ReplyId = 2 },
                  new ReplyLike() { UserId = 2, ReplyId = 2 },
                  new ReplyLike() { UserId = 3, ReplyId = 2 },
                  new ReplyLike() { UserId = 4, ReplyId = 3 },
                  new ReplyLike() { UserId = 4, ReplyId = 3 },

            };


            foreach (ReplyLike like in replyLikes)
            {
                bool validated = (_dbContext.ReplyLikes.Where(
                    x => x.UserId == like.UserId && x.ReplyId == like.ReplyId)
                    .ToList().Count == 0);
                if (validated)
                {
                    _dbContext.ReplyLikes.Add(like);
                    _dbContext.SaveChanges();
                }
            }
        }

        public void InitializeTweetLikes()
        {
            List<TweetLike> tweetLikes = new List<TweetLike>() {
                  new TweetLike() { UserId = 2, TweetId = 1 },
                  new TweetLike() { UserId = 3, TweetId = 1 },
                  new TweetLike() { UserId = 4, TweetId = 1 },
                  new TweetLike() { UserId = 5, TweetId = 1 },
                  new TweetLike() { UserId = 2, TweetId = 2 },
                  new TweetLike() { UserId = 3, TweetId = 2 },
                  new TweetLike() { UserId = 4, TweetId = 2 },
                  new TweetLike() { UserId = 5, TweetId = 2 },
                  new TweetLike() { UserId = 6, TweetId = 2 },
                  new TweetLike() { UserId = 4, TweetId = 3 },
                  new TweetLike() { UserId = 5, TweetId = 3 },
                  new TweetLike() { UserId = 6, TweetId = 3 },
                  new TweetLike() { UserId = 7, TweetId = 3 },
                  new TweetLike() { UserId = 2, TweetId = 4 },
                  new TweetLike() { UserId = 5, TweetId = 5 },
                  new TweetLike() { UserId = 6, TweetId = 5 },
                  new TweetLike() { UserId = 7, TweetId = 5 },
                  new TweetLike() { UserId = 3, TweetId = 6 },
                  new TweetLike() { UserId = 6, TweetId = 7 },
                  new TweetLike() { UserId = 2, TweetId = 8 },
                  new TweetLike() { UserId = 3, TweetId = 8 },
                  new TweetLike() { UserId = 6, TweetId = 9 },
                  new TweetLike() { UserId = 7, TweetId = 9 },
                  new TweetLike() { UserId = 4, TweetId = 10 },
                  new TweetLike() { UserId = 5, TweetId = 10 },
            };


            foreach (TweetLike like in tweetLikes)
            {
                bool validated = (_dbContext.TweetLikes.Where(
                    x => x.UserId == like.UserId && x.TweetId == like.TweetId)
                    .ToList().Count == 0);
                if (validated)
                {
                    _dbContext.TweetLikes.Add(like);
                    _dbContext.SaveChanges();
                }
            }
        }

        public void InitializeFollows()
        {
            List<Follow> follows = new List<Follow>() {
                  new Follow() { UserId = 2, FollowerId = 1 },
                  new Follow() { UserId = 6, FollowerId = 1 },
                  new Follow() { UserId = 7, FollowerId = 1 },
                  new Follow() { UserId = 1, FollowerId = 2 },
                  new Follow() { UserId = 6, FollowerId = 2 },
                  new Follow() { UserId = 7, FollowerId = 2 },
                  new Follow() { UserId = 4, FollowerId = 3 },
                  new Follow() { UserId = 7, FollowerId = 3 },
                  new Follow() { UserId = 1, FollowerId = 4 },
                  new Follow() { UserId = 2, FollowerId = 4 },
                  new Follow() { UserId = 3, FollowerId = 4 },
                  new Follow() { UserId = 5, FollowerId = 4 },
                  new Follow() { UserId = 6, FollowerId = 4 },
                  new Follow() { UserId = 7, FollowerId = 4 },
                  new Follow() { UserId = 1, FollowerId = 5 },
                  new Follow() { UserId = 2, FollowerId = 5 },
                  new Follow() { UserId = 3, FollowerId = 5 },
                  new Follow() { UserId = 4, FollowerId = 5 },
                  new Follow() { UserId = 6, FollowerId = 5 },
                  new Follow() { UserId = 7, FollowerId = 5 },
                  new Follow() { UserId = 1, FollowerId = 6 },
                  new Follow() { UserId = 2, FollowerId = 6 },
                  new Follow() { UserId = 3, FollowerId = 6 },
                  new Follow() { UserId = 5, FollowerId = 6 },
                  new Follow() { UserId = 1, FollowerId = 7 },
                  new Follow() { UserId = 6, FollowerId = 7 },
            };

            foreach (Follow f in follows)
            {
    
                    _dbContext.Follows.Add(f);
                    _dbContext.SaveChanges();
                
            }
        }


        // User
        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            using var db = _dbContext;
            List<User> users = await db.Users.ToListAsync();


            List<UserDTO> res = new List<UserDTO>();
            foreach (User u in users)
            {
                res.Add(new UserDTO()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Handle = u.Handle,
                    Color = u.Color,
            });
            }

            return res;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            using var db = _dbContext;
            User u = await db.Users
                .Include(x => x.Tweets)
                .Include(x => x.Replies)
                .Include(x => x.TweetLikes)
                .Include(x => x.ReplyLikes)
                .Include(x => x.Follows)
                .FirstOrDefaultAsync(x => x.Id == id);

            UserDTO res = new UserDTO
            {
                Id = u.Id,
                Name = u.Name,
                Handle = u.Handle,
                Color = u.Color,
                Replies = u.Replies,
                Tweets = u.Tweets,
                TweetLikes = u.TweetLikes,
                ReplyLikes = u.ReplyLikes,
                Follows = u.Follows
            };



            return res;
        }

        public async Task CreateUserAsync(User user)
        {
            using var db = _dbContext;

            bool validated = (
                db.Users.Where(x => x.Name == user.Name).ToList().Count == 0 && 
                db.Users.Where(x => x.Handle == user.Handle).ToList().Count == 0
                );

            if (validated) 
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

        public async Task<User> UpdateUserFollowsAsync(int id, User user)
        {
            using var db = _dbContext;
            User res = await db.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
            {
                return null;
            }

            bool validated = (db.Follows.Where(
                x => x.UserId == id &&
                x.FollowerId == user.Id)
                .ToList().Count == 0);
            if (validated)
            {
                db.Follows.Add(new Follow() { UserId = res.Id, FollowerId = user.Id });

            }
            else
            {
                Follow itemToRemove = await db.Follows.FirstOrDefaultAsync(x => x.UserId == res.Id && x.FollowerId == user.Id);

                if (itemToRemove != null)
                {
                    db.Follows.Remove(itemToRemove);
                    await db.SaveChangesAsync();

                }
            }

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
                var userFollowers= db.Follows.Where(x => x.UserId == res.Id).ToList();
                foreach (var followers in userFollowers)
                {
                    db.Follows.Remove(followers);

                }

                var userFollows = db.Follows.Where(x => x.FollowerId == res.Id).ToList();
                foreach (var follow in userFollows)
                {
                    db.Follows.Remove(follow);

                }

                var userTweetLikes = db.TweetLikes.Where(x => x.UserId == res.Id).ToList();
                foreach (var like in userTweetLikes)
                {
                    db.TweetLikes.Remove(like);

                }

                var userReplyLikes = db.ReplyLikes.Where(x => x.UserId == res.Id).ToList();
                foreach (var like in userReplyLikes)
                {
                    db.ReplyLikes.Remove(like);

                }


                var tweets = db.Tweets.Where(x => x.UserId == res.Id).ToList();
                foreach (var tweet in tweets)
                {
                    var tweetLikes = db.TweetLikes.Where(x => x.TweetId == tweet.Id).ToList();
                    foreach (var like in tweetLikes)
                    {
                        db.TweetLikes.Remove(like);

                    }


                    db.Tweets.Remove(tweet);

                }

                var replies = db.Replies.Where(x => x.UserId == res.Id).ToList();
                foreach (var reply in replies)
                {
                    var replyLikes = db.ReplyLikes.Where(x => x.ReplyId == reply.Id).ToList();
                    foreach (var like in replyLikes)
                    {
                        db.ReplyLikes.Remove(like);
                    }


                    db.Replies.Remove(reply);


                }

                db.Users.Remove(res);

                await db.SaveChangesAsync();
                return true;

            }
        }


        // Tweet
        public async Task<List<Tweet>> GetAllTweetsAsync()
        {
            using var db = _dbContext;
            return await db.Tweets.Include(x => x.Replies).Include(x => x.TweetLikes).ToListAsync();
        }

        public async Task<Tweet> GetTweetByIdAsync(int id)
        {
            using var db = _dbContext;
            return await db.Tweets.Include(x => x.Replies).Include(x => x.TweetLikes).FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<Tweet> UpdateTweetLikesAsync(int id, User user)
        {
            using var db = _dbContext;
            Tweet res = await db.Tweets.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
            {
                return null;
            }

            bool validated = (db.TweetLikes.Where(
                x => x.UserId == user.Id &&
                x.TweetId == id)
                .ToList().Count == 0);
            if (validated)
            {
                db.TweetLikes.Add(new TweetLike() { UserId = user.Id, TweetId = res.Id });

            } else
            {
                TweetLike itemToRemove = await db.TweetLikes.FirstOrDefaultAsync(x => x.UserId == user.Id && x.TweetId == res.Id);

                if (itemToRemove != null)
                {
                    db.TweetLikes.Remove(itemToRemove);
                    await db.SaveChangesAsync();

                }
            }

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

            } else
            {
                var tweetLikes = db.TweetLikes.Where(x => x.TweetId == res.Id).ToList();
                foreach (var like in tweetLikes)
                {
                    db.TweetLikes.Remove(like);
                }

                var replies = db.Replies.Where(x => x.TweetId == res.Id).ToList();
                foreach (var reply in replies)
                {

                    var replyLikes = db.ReplyLikes.Where(x => x.ReplyId == reply.Id).ToList();
                    foreach (var like in replyLikes)
                    {
                        db.ReplyLikes.Remove(like);
                    }


                    db.Replies.Remove(reply);


                }

                db.Tweets.Remove(res);

                await db.SaveChangesAsync();
                return true;
            }
        }



        // Reply

        public async Task<List<Reply>> GetAllRepliesAsync()
        {
            using var db = _dbContext;
            return await db.Replies.Include(x => x.ReplyLikes).ToListAsync();
        }
        
        public async Task<Reply> GetReplyByIdAsync(int id)
        {
            using var db = _dbContext;
            return await db.Replies.Include(x => x.ReplyLikes).FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task<Reply> UpdateReplyLikesAsync(int id, User user)
        {
            using var db = _dbContext;
            Reply res = await db.Replies.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
            {
                return null;
            }

            bool validated = (db.ReplyLikes.Where(
                x => x.UserId == user.Id &&
                x.ReplyId == id)
                .ToList().Count == 0);
            if (validated)
            {
                db.ReplyLikes.Add(new ReplyLike() { UserId = user.Id, ReplyId = res.Id });

            }
            else
            {
                ReplyLike itemToRemove = await db.ReplyLikes.FirstOrDefaultAsync(x => x.UserId == user.Id && x.ReplyId == res.Id);

                if (itemToRemove != null)
                {
                    db.ReplyLikes.Remove(itemToRemove);
                    await db.SaveChangesAsync();

                }
            }

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
                var likes = db.ReplyLikes.Where(x => x.ReplyId == res.Id).ToList();
                foreach (var like in likes)
                {
                    db.ReplyLikes.Remove(like);
                }

                db.Replies.Remove(res);

                await db.SaveChangesAsync();
                return true;
            }
        }

        // Follows
        public async Task<List<Follow>> GetAllFollowsAsync()
        {
            using var db = _dbContext;
            return await db.Follows.ToListAsync();
        }











    }
}
