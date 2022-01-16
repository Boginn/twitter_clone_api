using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.Models;
using TwitterCloneAPI.Models.DTO;

namespace TwitterCloneAPI.Data.Interface
{
    public interface IRepository
    {

        // User
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserByHandleAsync(string handle);
        Task CreateUserAsync(User user);
        Task<User> UpdateUserAsync(int id, User user);
        Task<User> UpdateUserFollowsAsync(int id, User user);

        Task<bool> DeleteUserAsync(int id);


        // Tweet
        Task<List<Tweet>> GetAllTweetsAsync();
        Task<Tweet> GetTweetByIdAsync(int id);
        Task CreateTweetAsync(Tweet tweet);
        Task<Tweet> UpdateTweetContentAsync(int id, Tweet tweet);
        Task<Tweet> UpdateTweetLikesAsync(int id, User user);
        Task<bool> DeleteTweetAsync(int id);



        // Reply
        Task<List<Reply>> GetAllRepliesAsync();
        Task<Reply> GetReplyByIdAsync(int id);
        Task CreateReplyAsync(Reply reply);
        Task<Reply> UpdateReplyContentAsync(int id, Reply reply);
        Task<Reply> UpdateReplyLikesAsync(int id, User user);
        Task<bool> DeleteReplyAsync(int id);


        // Follow
        Task<List<Follow>> GetAllFollowsAsync();
    }
}
