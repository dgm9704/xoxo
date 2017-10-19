﻿//
//  FilingIndicatorTests.cs
//
//  Author:
//       John Nordberg <john.nordberg@gmail.com>
//
//  Copyright (c) 2015-2017 John Nordberg
//
//  Free Public License 1.0.0
//  Permission to use, copy, modify, and/or distribute this software for any purpose with or without fee is hereby granted.
//  THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES 
//  OF MERCHANTABILITY AND FITNESS.IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES 
//  OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS 
//  ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.

namespace Diwen.Xbrl.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class FilingIndicatorTests
	{
		[Test]
		public void PositiveFilingIndicatorsMatchExactly()
		{
			var ctx = new Context();
			var a = new FilingIndicatorCollection();
			a.Add(ctx, "A.00.01", true);
			var b = new FilingIndicatorCollection();
			b.Add(ctx, "A.00.01", true);
			Assert.AreEqual(a, b);
		}

		[Test]
		public void NegativeFilingIndicatorsMatchExactly()
		{
			var ctx = new Context();
			var a = new FilingIndicatorCollection();
			a.Add(ctx, "A.00.01", false);
			var b = new FilingIndicatorCollection();
			b.Add(ctx, "A.00.01", false);
			Assert.AreEqual(a, b);
		}

		[Test]
		public void PositiveFilingIndicatorsMatchImplicitly()
		{
			var ctx = new Context();
			var a = new FilingIndicatorCollection();
			a.Add(ctx, "A.00.01", true);
			var b = new FilingIndicatorCollection();
			b.Add(ctx, "A.00.01");
			Assert.AreEqual(a, b);
		}

		[Test]
		public void FilingIndicatorCollectionsMatchFunctionally()
		{
			var c0 = new Context();
			var a = new FilingIndicatorCollection();
			a.Add(c0, "A", true);
			a.Add(c0, "B", true);
			a.Add(c0, "C", false);

			var c1 = new Context();
			var b = new FilingIndicatorCollection();
			b.Add(c1, "B");
			b.Add(c1, "A");

			Assert.IsTrue(a.Equals(b));
		}

		[Test]
		public void FilingIndicatorCollectionsDoNotMatchFunctionally()
		{
			var c0 = new Context();
			var a = new FilingIndicatorCollection();
			a.Add(c0, "A", true);
			a.Add(c0, "B", true);
			a.Add(c0, "C", false);

			var c1 = new Context();
			var b = new FilingIndicatorCollection();
			b.Add(c1, "A");
			b.Add(c1, "B");
			b.Add(c1, "C");

			Assert.IsFalse(a.Equals(b));
		}
	}
}

