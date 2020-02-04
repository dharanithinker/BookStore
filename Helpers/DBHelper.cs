using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Helpers
{
    public static class DBHelper
    {
        private static List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Dharani", LastName = "Kumar", Username = "dharanithinker_007", Password = "dharanithinker_007" },
            new User { Id = 2, FirstName = "MS", LastName = "Dhoni", Username = "msdhoni_007", Password = "msdhoni_007" }
        };

        private static List<Book> _books = new List<Book> {
            new Book {
                Id = 1,
                Title = "Steve Jobs: The Exclusive Biography",
                SubTitle = "",
                CoverPicture = "https://images-na.ssl-images-amazon.com/images/I/41LcuCqSeJL._SX317_BO1,204,203,200_.jpg",
                Author = " Walter Isaacson ", Description = "This is a riveting book, with as much to say about the transformation of modern life in the information age as about its supernaturally gifted and driven subject",
                Price = 500f,
                Category = new Category() { Id = 1,Name = "Biography" },
                Discount = 0
            },
            new Book {
                Id = 2,
                Title = "The Text: A short story",
                SubTitle = "",
                CoverPicture = "https://images-eu.ssl-images-amazon.com/images/I/51JckI5WcOL.jpg",
                Author = "Claire Douglas",
                Description = "A new short story from the Sunday Times bestselling author of Local Girl Missing and Last Seen Alive. Her newest novel, Do Not Disturb, is out now!",
                Price = 650f,
                Category = new Category(){ Id = 2, Name = "Crime" } ,
                Discount = 10
            },
            new Book{
                Id = 3,
                Title = "Good Economics for Hard Times : Better Answers to Our Biggest Problems",
                SubTitle = "",
                CoverPicture = "https://m.media-amazon.com/images/I/81MIp1V-9XL._AC_UY218_ML3_.jpg",
                Author = "Esther Duflo Abhijit Banerjee",
                Description = "WINNERS OF THE NOBEL PRIZE IN ECONOMICS 2019",
                Price = 750f,
                Category = new Category(){ Id = 3, Name = "Economics" } ,
                Discount = 20
            },
            new Book{
                Id = 4,
                Title = "Objective General English",
                SubTitle = "",
                CoverPicture = "https://m.media-amazon.com/images/I/412Up4y0TzL._AC_UY218_ML3_.jpg",
                Author = " S.P. Bakshi ",
                Description = "An essential book that would brush up the language skills of any aspirants who is working towards clearing the competitive examinations for Hotel Management, B Ed, MBA, MCA courses held by many prestigious institutes and university or those conducted by UPSC for many openings for civil and armed forces positions.",
                Price = 880f,
                Category = new Category(){ Id = 4, Name = "General" } ,
                Discount = 20
            },
            new Book{
                Id = 5,
                Title = "1001 Activities Book",
                SubTitle = "",
                CoverPicture = "https://m.media-amazon.com/images/I/61GFWOKgQdL._AC_UY218_ML3_.jpg",
                Author = " Dreamland Publications",
                Description = "Introduce your children to sports and watch them grow fit and active in today's fast urbanization and digitization",
                Price = 470f,
                Category = new Category(){  Id = 5, Name = "Kids" } ,
                Discount = 10
            },
            new Book{
                Id = 6,
                Title = "Mindful Parenting: The First 1,000 Days",
                CoverPicture = "https://m.media-amazon.com/images/I/81VXkCJ8T5L._AC_UY218_ML3_.jpg",
                SubTitle = "",
                Author = "Suchitra Shenoy",
                Description = "Mindful Parenting: The First 1,000 Days ",
                Price = 930f,
                Category = new Category(){  Id = 6, Name = "Parenting" } ,
                Discount = 0
            },
            new Book{
                Id = 7,
                Title = "This Is Not Your Story",
                SubTitle = "",
                CoverPicture = "https://m.media-amazon.com/images/I/A1rpmZ54X9L._AC_UY218_ML3_.jpg",
                Author = "Savi-Sharma",
                Description = "Sometimes, you do not write your story, it writes you. You don't choose your story, it chooses you.",
                Price = 345f,
                Category = new Category(){  Id = 7, Name = "Scifi" } ,
                Discount = 0
            },
            new Book{
                Id = 8,
                Title = "Stories We Never Tell",
                SubTitle = "",
                CoverPicture = "https://images-na.ssl-images-amazon.com/images/I/41quwiKy%2BxL._SX316_BO1,204,203,200_.jpg",
                Author = "Savi Sharma",
                Description = "Visionaries Who Changed the World Series brings significant moments from the professional and personal lives of entrepreneurs who have had a deep impact on the business world.",
                Price = 567f,
                Category = new Category(){  Id = 8, Name = "Indian Writing"},
                Discount = 0
            },
            new Book{
                Id = 9,
                Title = "How Technology Works (Facts Visually Explained)",
                SubTitle = "",
                CoverPicture = "https://images-na.ssl-images-amazon.com/images/I/51pirJ0jFqL._SX419_BO1,204,203,200_.jpg",
                Author = "DK",
                Description = "Have you ever asked yourself how the inventions, gadgets and devices that surround us actually work? Discover the hidden workings of everyday technology with this graphic guide.",
                Price = 845f,
                Category = new Category() { Id = 9, Name = "Technology" },
                Discount = 0
            },
            new Book{
                Id = 10,
                Title = "Human Resource Management, Text & Cases",
                SubTitle = "",
                CoverPicture = "https://images-na.ssl-images-amazon.com/images/I/51traPmaKVL._SX380_BO1,204,203,200_.jpg",
                Author = " K. Aswathappa",
                Description = "This textbook, in its latest edition, continues to capture the rapidly changing trends of the ever-dynamic subject area in an easily comprehensible manner.",
                Price = 387f,
                Category = new Category() {  Id = 10, Name = "TextBooks" } ,
                Discount = 0
            },
        };

        private static List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Biography"},
            new Category { Id = 2, Name = "Crime"},
            new Category { Id = 3, Name = "Economics"},
            new Category { Id = 4, Name = "General"},
            new Category { Id = 5, Name = "Kids"},
            new Category { Id = 6, Name = "Parenting"},
            new Category { Id = 7, Name = "Scifi"},
            new Category { Id = 8, Name = "Indian Writing"},
            new Category { Id = 9, Name = "Technology"},
            new Category { Id = 10, Name = "TextBooks"}
        };


        private static List<UserOrderDetails> _userOrders = new List<UserOrderDetails>()
        {
            new UserOrderDetails {
                UserDetails = _users[0],
                OrderDetails = new List<OrderDetails>()
                        {
                            new OrderDetails() {
                                Id = 1,
                                Items = new List<Item>{
                                    new Item() { OrderedQuantity = 1, Book = _books[0] },
                                    new Item() { OrderedQuantity = 2, Book = _books[1] }
                                },
                                OrderStatus = Status.Delivered,
                                OrderedDate = DateTime.UtcNow.AddDays(-20),
                                DeliveredDate = DateTime.UtcNow.AddDays(-3)
                            },
                            new OrderDetails() {
                                Id = 2,
                                Items = new List<Item>{ new Item() { OrderedQuantity = 2, Book = _books[2] } },
                                OrderStatus = Status.Delivered,
                                OrderedDate = DateTime.UtcNow.AddDays(-20),
                                DeliveredDate = DateTime.UtcNow.AddDays(-3)
                            },
                            new OrderDetails() {
                                Id = 3,
                                Items = new List<Item>{
                                    new Item() { OrderedQuantity = 1, Book = _books[3] },
                                    new Item() { OrderedQuantity = 1, Book = _books[4] }
                                },
                                OrderStatus = Status.Dispatched,
                                OrderedDate = DateTime.UtcNow.AddDays(-20),
                                ExpectedDeliveryDate = DateTime.UtcNow.AddDays(-3)
                            },
                            new OrderDetails() {
                                Id = 4,
                                Items = new List<Item>{
                                    new Item() { OrderedQuantity = 3, Book = _books[5] },
                                    new Item() { OrderedQuantity = 2, Book = _books[6] }
                                },
                                OrderStatus = Status.Cancelled,
                                OrderedDate = DateTime.UtcNow.AddDays(-20),
                                CancelledDate = DateTime.UtcNow.AddDays(-3)
                            },
                        }
            },
            new UserOrderDetails {
                UserDetails = _users[1],
                OrderDetails = new List<OrderDetails>()
                {
                    new OrderDetails() {
                        Id = 5,
                        Items = new List<Item>{
                            new Item() { OrderedQuantity = 3, Book = _books[5] },
                            new Item() { OrderedQuantity = 2, Book = _books[6] }
                        },
                        OrderStatus = Status.Delivered,
                        OrderedDate = DateTime.UtcNow.AddDays(-20),
                        DeliveredDate = DateTime.UtcNow.AddDays(-3)
                    },
                    new OrderDetails() {
                        Id = 6,
                        Items = new List<Item>{
                            new Item() { OrderedQuantity = 5, Book = _books[7] },
                            new Item() { OrderedQuantity = 3, Book = _books[8] }
                        },
                        OrderStatus = Status.Dispatched,
                        OrderedDate = DateTime.UtcNow.AddDays(-20),
                        ExpectedDeliveryDate = DateTime.UtcNow.AddDays(-3)
                    },
                }
            }
        };

        public static List<User> GetAllUsers()
        {
            return _users;
        }

        public static List<Book> GetAllBooks()
        {
            return _books;
        }
        public static List<Category> GetAllCategories()
        {
            return _categories;
        }

        public static List<OrderDetails> GetOrders(int userDetailsID)
        {
            List<OrderDetails> userOrderDetails = new List<OrderDetails>();
            var orderInfo = _userOrders.Where(x => x.UserDetails.Id == userDetailsID).ToList();
            if (orderInfo != null)
                userOrderDetails = orderInfo.First().OrderDetails;
            return userOrderDetails;
        }

        public static bool SaveOrder(int userDetailsID, OrderDetails orderDetails)
        {
            var userDetails = _users.Where(x => x.Id == userDetailsID).FirstOrDefault();
            orderDetails.OrderedDate = DateTime.UtcNow;
            orderDetails.OrderStatus = Status.Success;
            UserOrderDetails userOrderDetails = new UserOrderDetails()
            {
                UserDetails = userDetails,
                // OrderDetails = new List<OrderDetails> { orderDetails }
                OrderDetails = new List<OrderDetails> { _userOrders[0].OrderDetails[0] }
            };
            _userOrders.Add(userOrderDetails);
            return true;
        }
    }
}
