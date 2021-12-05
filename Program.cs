using System;
using System.Collections.Generic;

namespace ProductReviewManagement_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product Review Management Using LINQ");

            List<ProductReview> list = new List<ProductReview>()
            {
                 new ProductReview() { ProductId = 1, UserId = 1, Review = "good", Rating = 17, IsLike = true },
                 new ProductReview() { ProductId = 2, UserId = 3, Review = "bad", Rating = 1, IsLike = false },
                 new ProductReview() { ProductId = 3, UserId = 5, Review = "average", Rating = 20, IsLike = true },
                 new ProductReview() { ProductId = 4, UserId = 7, Review = "good", Rating = 7, IsLike = false },
                 new ProductReview() { ProductId = 5, UserId = 9, Review = "bad", Rating = 5, IsLike = true }
            };
        }
    }
}
