using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiftea.DataAccess.Infrastructure
{
	public class Disposable : IDisposable
	{
		private bool isDisposed;
		~Disposable()
		{
			Dispose(false);
		}		

		public void Dispose()
		{
			Dispose(true);
		}
		private void Dispose(bool v)
		{
			if (!isDisposed && v)
			{
				DisposeCore();
			}
			isDisposed = true;
		}

		/// <summary>
		/// this will make other classes inherit this to dispose their own object 
		/// </summary>
		protected virtual void DisposeCore()
		{
			
		}
	}
}
