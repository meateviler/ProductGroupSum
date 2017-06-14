using System.Collections.Generic;

namespace ProductGroupSum
{
	public class ProductService
	{
		private List<Product> _products;

		public void SetProduct(List<Product> products)
		{
			_products = products;
		}

		public int[] GetFieldSumInGroupCount(int count, string fieldName)
		{
			return new int[] { };
		}
	}
}