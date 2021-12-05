using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            CountreviewProductId(list);
        }
        public static void RetriveTop3Records(List<ProductReview> list) //to retrive top 3 records 
        {
            //LINQ syntax 
            var result = from product in list orderby product.Rating descending select product;
            var topThreeRecords = result.Take(3);
            foreach (ProductReview product in topThreeRecords)
            {
                Console.WriteLine("ProductId: " + product.ProductId + " UserId: " + product.UserId + " Rating: " + product.Rating + " Review: " + product.Review + " IsLike: " + product.IsLike);
            }
        }

        public static void RetriveRecordsratingProductId(List<ProductReview> list) //to retrive all records based on rating and product id
        {
            var records = (list.Where(r => r.Rating > 3 && (r.ProductId == 1 || r.ProductId == 4 || r.ProductId == 9))).ToList(); //here Where means List
            foreach(var element in records)
            {
                Console.WriteLine("ProductId : " + element.ProductId + " Rating : " + element.Rating + " UserId : " + element.UserId + " Review : " + element.Review + " IsLike : " + element.IsLike);
            }
        }

        public static void CountreviewProductId(List<ProductReview> list) //to count product review based on product id
        {
            var countId = list.GroupBy(p => p.ProductId).Select(x => new { ProductId = x.Key, count = x.Count() });
            foreach(var element in countId)
            {
                Console.WriteLine("ProductId " + element.ProductId + "\t" + "Count" + element.count);
            }
        }
    }
}
