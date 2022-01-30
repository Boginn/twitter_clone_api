# Twitter Clone API

### by Finnbogi Jökull Pétursson
<br>

## Installation
```
Open the project in Visual Studio.
Open the Package Manager Console.
If a migration is missing, type Add-Migration into the console.
Type Update-Database into the console.

```
### To seed example data: 
<li>
  open the file <i>TwitterRepository.cs</i> located in <i>./TwitterCloneAPI/Data/Repository/'</i>
</li>
<li>
uncomment the initialization methods and run once
</li>
<li>
comment the initialization methods out again
</li>
<br>

## End Points
```
GET   '/api/replies'   
      returns an array of all replies 
GET   '/api/replies/id'
      returns a reply based on the id given    
POST  '/api/replies/create'
      creates a reply if given the properties: content, date, userId, tweetId and recipient 
PUT   '/api/replies/edit/id'
      updates the content of a reply based on the given id    
PUT   '/api/replies/like/id'
      adds/removes a like on a reply based on the id given    
DEL   '/api/replies/delete/id'
      deletes a reply based on the id given    

GET   '/api/tweets'
      returns an array of all tweets 
GET   '/api/tweets/id'
      returns a tweet based on the id given   
POST  '/api/tweets/create'
      creates a tweet if given the properties: content, date, userId and hashtag    
PUT   '/api/tweets/edit/id'
      updates the content of a tweet based on the given id        
PUT   '/api/tweets/like/id'
      adds/removes a like on a tweet based on the id given        
DEL   '/api/tweets/delete/id'
      deletes a tweet based on the id given        

GET   '/api/users'
      returns an array of all users 
GET   '/api/users/id'
      returns a user based on the id given    
GET   '/api/users/handle'
      returns a user based on the handle given    
POST  '/api/users/create'
      creates a user if given the properties: name, handle and color  
PUT   '/api/users/edit/id'
      updates the name, handle and color of a user based on the given id           
PUT   '/api/users/follow/id'
      adds/removes a follow on a user based on the id given           
DEL   '/api/users/delete/id'
      deletes a user based on the id given           

GET   '/api/follows'   
      returns an array of all follows

```



