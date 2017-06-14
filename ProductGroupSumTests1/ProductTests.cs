using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProductGroupSum.Tests
{
	[TestFixture()]
	public class ProductTests
	{
		private readonly List<Product> _products = new List<Product>()
		{
			new Product(){Id =1,Cost = 1,Revenue = 11,SellPrice = 21},
			new Product(){Id =2,Cost = 2,Revenue = 12,SellPrice = 22},
			new Product(){Id =3,Cost = 3,Revenue = 13,SellPrice = 23},
			new Product(){Id =4,Cost = 4,Revenue = 14,SellPrice = 24},
			new Product(){Id =5,Cost = 5,Revenue = 15,SellPrice = 25},
			new Product(){Id =6,Cost = 6,Revenue = 16,SellPrice = 26},
			new Product(){Id =7,Cost = 7,Revenue = 17,SellPrice = 27},
			new Product(){Id =8,Cost = 8,Revenue = 18,SellPrice = 28},
			new Product(){Id =9,Cost = 9,Revenue = 19,SellPrice = 29},
			new Product(){Id =10,Cost = 10,Revenue = 20,SellPrice = 30},
			new Product(){Id =11,Cost = 11,Revenue = 21,SellPrice = 31}
		};

		[TestCase(3, "Cost", ExpectedResult = new[] { 6, 15, 24, 21 }, TestName = "sum_of_cost_3_in_group")]
		[TestCase(4, "Revenue", ExpectedResult = new[] { 50, 66, 60 }, TestName = "sum_of_revinue_4_in_group")]
		[TestCase(11, "SellPrice", ExpectedResult = new[] { 286 }, TestName = "sum_of_sellprice_11_in_group")]
		[TestCase(1, "Cost", ExpectedResult = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, TestName = "sum_of_cost_1_in_group")]
		public int[] GetFieldSumInGroupCountShouldSuccess(int count, string fieldName)
		{
			//Arrange
			var target = new ProductService();
			target.SetProduct(_products);

			//Act
			var actual =  target.GetFieldSumInGroupCount(count, fieldName);

			//Assert
			return actual.ToArray();
		}

		[TestCase(0, "Cost", TestName = "sum_of_cost_0_in_group_should_throw_Expection")]
		[TestCase(-1, "Revenue", TestName = "sum_of_revinue_-1_in_group_should_throw_Expection")]
		[TestCase(12, "SellPrice", TestName = "sum_of_sellprice_12_in_group_should_throw_Expection")]
		[TestCase(3, "WrongField", TestName = "sum_of_WrongField_3_in_group_should_throw_Expection")]
		[TestCase(4, "", TestName = "sum_of_''_4_in_group_should_throw_Expection")]
		public void GetFieldSumInGroupCountShouldThrowExpection(int count, string fieldName)
		{
			//Arrange
			var target = new ProductService();
			target.SetProduct(_products);

			//Act
			//Assert

			TestDelegate action = () => target.GetFieldSumInGroupCount(count, fieldName);

			Assert.Throws<ArgumentException>(action);
		}
	}
}