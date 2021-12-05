using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


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
                 new ProductReview() { ProductId = 5, UserId = 9, Review = "bad", Rating = 5, IsLike = true },
                 new ProductReview() { ProductId = 6, UserId = 11, Review = "average", Rating = 20, IsLike = true },
                 new ProductReview() { ProductId = 7, UserId = 13, Review = "good", Rating = 7, IsLike = false },
                 new ProductReview() { ProductId = 8, UserId = 15, Review = "bad", Rating = 5, IsLike = true }
            };
            CreateDatatable();
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

        public static void RetriveProductId(List<ProductReview> list) //to retrive product id and review present in the list
        {
            var prodId = list.Select(product => new { ProductId = product.ProductId, Review = product.Review }).ToList();
            foreach(var element in prodId)
            {
                Console.WriteLine("ProductId : " + element.ProductId + " \t " + "Review" + element.Review);
            }
        }

        public static void SkipTop5Records(List<ProductReview> list) //to skip top 5 records 
        {
            //LINQ syntax 
            var skipTopThree = (list.Where(r => r.ProductId > 5)).ToList(); //here Where means List
            foreach (ProductReview product in skipTopThree)
            {
                Console.WriteLine("ProductId: " + product.ProductId + " UserId: " + product.UserId + " Rating: " + product.Rating + " Review: " + product.Review + " IsLike: " + product.IsLike);
            }
        }

        public static void RetriveOnlyProductId(List<ProductReview> list) //Retrive only product id
        {
            var prodId = list.Select(product => new { ProductId = product.ProductId }).ToList();
            foreach (var element in prodId)
            {
                Console.WriteLine("ProductId : " + element.ProductId);
            }
        }

        public static void CreateDatatable() //to create table and add product review details
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductID", typeof(int));
            table.Columns.Add("UserID", typeof(int));
            table.Columns.Add("Rating", typeof(int));
            table.Columns.Add("Review", typeof(string));
            table.Columns.Add("IsLike", typeof(bool));

            table.Rows.Add(1, 1, 17, "good", true);
            table.Rows.Add(2, 3, 1, "bad", false);
            table.Rows.Add(3, 5, 20, "average", true);
            table.Rows.Add(4, 7, 7, "good", false);
            table.Rows.Add(5, 9, 5, "bad", true);
            table.Rows.Add(6, 11, 20, "average", false);
            table.Rows.Add(7, 13, 7, "good", true);
            table.Rows.Add(8, 15, 5, "bad", false);
        }
    }
}
