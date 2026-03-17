using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.IO;

namespace MiniSocialMedia
{
         
    public class SocialException : Exception
    {
        public SocialException(string message) : base(message) { }
        public SocialException(string message, Exception inner) : base(message, inner) { }
    }
     
    public interface IPostable
    {
        void AddPost(string content);
        IReadOnlyList<Post> GetPosts();
    }
     
    public class Post
    {
        public User Author { get; }
        public string Content { get; }
        public DateTime CreatedAt { get; }

        public Post(User author, string content)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            Author = author;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Author} • {CreatedAt:MMM dd HH:mm}");
            sb.AppendLine(Content);

            var hashtags = Regex.Matches(Content, @"#[A-Za-z]+");
            if (hashtags.Count > 0)
            {
                sb.Append("Tags: ");
                sb.AppendJoin(", ", hashtags.Cast<Match>().Select(m => m.Value));
            }

            return sb.ToString().TrimEnd();
        }
    }
     
    public partial class User : IPostable, IComparable<User>
    {
        public string Username { get; init; }
        public string Email { get; init; }

        private readonly List<Post> _posts = new();
        private readonly HashSet<string> _following =
            new(StringComparer.OrdinalIgnoreCase);

        public event Action<Post>? OnNewPost;

        public User(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("username");

            if (!Regex.IsMatch(email ?? "", @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new SocialException("Invalid email format");

            Username = username.Trim();
            Email = email.Trim().ToLowerInvariant();
        }

        public void Follow(string username)
        {
            if (string.Equals(username, Username, StringComparison.OrdinalIgnoreCase))
                throw new SocialException("Cannot follow yourself");

            _following.Add(username);
        }

        public bool IsFollowing(string username) =>
            _following.Contains(username);

        public void AddPost(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Post content cannot be empty");

            if (content.Length > 280)
                throw new SocialException("Post too long (max 280 characters)");

            var post = new Post(this, content.Trim());
            _posts.Add(post);
            OnNewPost?.Invoke(post);
        }

        public IReadOnlyList<Post> GetPosts() =>
            _posts.AsReadOnly();

        public int CompareTo(User? other)
        {
            if (other == null) return 1;
            return string.Compare(Username, other.Username, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => $"@{Username}";
    }
     
    public partial class User
    {
        public string GetDisplayName()
        {
            return $"User: {Username} <{Email}>";
        }
    }
     
    public class Repository<T> where T : class
    {
        private readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);
        public IReadOnlyList<T> GetAll() => _items.AsReadOnly();
        public T? Find(Predicate<T> match) => _items.Find(match);
    }
     
    public static class SocialUtils
    {
        public static string FormatTimeAgo(this DateTime date)
        {
            var diff = DateTime.UtcNow - date;

            if (diff.TotalMinutes < 1) return "just now";
            if (diff.TotalMinutes < 60) return $"{(int)diff.TotalMinutes} min ago";
            if (diff.TotalHours < 24) return $"{(int)diff.TotalHours} h ago";

            return date.ToString("MMM dd");
        }
    }
     
    public static class UserExtensions
    {
        public static IEnumerable<string> GetFollowingNames(this User user)
        {
            var field = typeof(User).GetField("_following",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);

            return field?.GetValue(user) as IEnumerable<string>
                   ?? Enumerable.Empty<string>();
        }
    }
     
    public class Program
    {
        private static readonly Repository<User> _users = new();
        private static User? _currentUser;
        private static readonly string _dataFile = "social-data.json";

        static void Main()
        {
            Console.Title = "MiniSocial - Console Edition";
            Console.WriteLine("=== MiniSocial ===");

            LoadData();

            while (true)
            {
                try
                {
                    if (_currentUser == null)
                        ShowLoginMenu();
                    else
                        ShowMainMenu();
                }
                catch (SocialException ex)
                {
                    ConsoleColorWrite(ConsoleColor.Red, $"Error: {ex.Message}");
                    if (ex.InnerException != null)
                        Console.WriteLine($" → {ex.InnerException.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected error occurred.");
                    Console.WriteLine(ex);
                    LogError(ex);
                }

                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowLoginMenu()
        {
            Console.WriteLine("1. Register\n2. Login\n3. Exit");
            var choice = Console.ReadLine();

            if (choice == "1") Register();
            else if (choice == "2") Login();
            else if (choice == "3")
            {
                SaveData();
                Environment.Exit(0);
            }
        }

        static void Register()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            if (_users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)) != null)
                throw new SocialException("Username already exists");

            _users.Add(new User(username!, email!));
            Console.WriteLine("Registration successful!");
        }

        static void Login()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();

            var user = _users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user == null)
                throw new SocialException("User not found");

            _currentUser = user;
            _currentUser.OnNewPost += p =>
                Console.WriteLine($"[Notification] New post by {p.Author}");

            Console.WriteLine("Login successful!");
        }

        static void ShowMainMenu()
        {
            Console.WriteLine(_currentUser!.GetDisplayName());
            Console.WriteLine("1.Post 2.MyPosts 3.Timeline 4.Follow 5.Users 6.Logout 7.Exit");

            var choice = Console.ReadLine();

            if (choice == "1") PostMessage();
            else if (choice == "2") ShowPosts(_currentUser.GetPosts());
            else if (choice == "3") ShowTimeline();
            else if (choice == "4") FollowUser();
            else if (choice == "5") ListUsers();
            else if (choice == "6") _currentUser = null;
            else if (choice == "7")
            {
                SaveData();
                Environment.Exit(0);
            }
        }

        static void PostMessage()
        {
            Console.Write("Post: ");
            var content = Console.ReadLine();
            if (string.IsNullOrEmpty(content)) return;

            _currentUser!.AddPost(content);
            Console.WriteLine("Posted successfully!");
        }

        static void ShowTimeline()
        {
            var posts = new List<Post>();
            posts.AddRange(_currentUser!.GetPosts());

            foreach (var name in _currentUser.GetFollowingNames())
            {
                var user = _users.Find(u => u.Username.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (user != null)
                    posts.AddRange(user.GetPosts());
            }

            ShowPosts(posts.OrderByDescending(p => p.CreatedAt));
        }

        static void ShowPosts(IEnumerable<Post> posts)
        {
            if (!posts.Any())
            {
                Console.WriteLine("No posts.");
                return;
            }

            foreach (var post in posts)
            {
                Console.WriteLine(post);
                Console.WriteLine(post.CreatedAt.FormatTimeAgo());
                Console.WriteLine("-----");
            }
        }

        static void FollowUser()
        {
            Console.Write("Follow username: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name)) return;

            if (_users.Find(u => u.Username.Equals(name, StringComparison.OrdinalIgnoreCase)) == null)
                throw new SocialException("User does not exist");

            _currentUser!.Follow(name);
            Console.WriteLine("Now following " + name);
        }

        static void ListUsers()
        {
            foreach (var user in _users.GetAll().OrderBy(u => u))
                Console.WriteLine(user.GetDisplayName());
        }

        static void SaveData()
        {
            var json = JsonSerializer.Serialize(_users.GetAll());
            File.WriteAllText(_dataFile, json);
        }

        static void LoadData()
        {
            if (!File.Exists(_dataFile)) return;

            var json = File.ReadAllText(_dataFile);
            var users = JsonSerializer.Deserialize<List<User>>(json);
            if (users != null)
                users.ForEach(u => _users.Add(u));
        }

        static void LogError(Exception ex)
        {
            File.AppendAllText("error.log", $"{DateTime.Now}\n{ex}\n\n");
        }

        static void ConsoleColorWrite(ConsoleColor color, string message)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = old;
        }
    }
}
